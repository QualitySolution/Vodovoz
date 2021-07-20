﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using QS.DomainModel.UoW;
using QS.Project.DB;
using QSProjectsLib;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.MailSending;
using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Vodovoz.Domain.StoredEmails;
using Vodovoz.EntityRepositories;

namespace StoredEmailStatusUpdateWorker
{
	public class Worker : BackgroundService
	{
		private const string _queuesConfigurationSection = "Queues";

		private readonly string _storedEmailStatusUpdatingQueueId;

		private readonly ILogger<Worker> _logger;
		private readonly IModel _channel;
		private readonly IEmailRepository _emailRepository;
		private readonly AsyncEventingBasicConsumer _consumer;

		public Worker(ILogger<Worker> logger, IConfiguration configuration, IModel channel, IEmailRepository emailRepository)
		{
			if(configuration is null)
			{
				throw new ArgumentNullException(nameof(configuration));
			}

			_logger = logger ?? throw new ArgumentNullException(nameof(logger));
			_channel = channel ?? throw new ArgumentNullException(nameof(channel));
			_emailRepository = emailRepository ?? throw new ArgumentNullException(nameof(emailRepository));
			_storedEmailStatusUpdatingQueueId = configuration.GetSection(_queuesConfigurationSection)
				.GetValue<string>("StoredEmailStatusUpdatingQueue");
			_channel.QueueDeclare(_storedEmailStatusUpdatingQueueId, true, false, false, null);
			_consumer = new AsyncEventingBasicConsumer(_channel);
			_consumer.Received += MessageRecieved;

			try
			{
				var conStrBuilder = new MySqlConnectionStringBuilder();

				var databaseSection = configuration.GetSection("Database");

				conStrBuilder.Server = databaseSection.GetValue("Host", "localhost");
				conStrBuilder.Port = databaseSection.GetValue<uint>("Port", 3306);
				conStrBuilder.UserID = databaseSection.GetValue("Username", "");
				conStrBuilder.Password = databaseSection.GetValue("Password", "");
				conStrBuilder.Database = databaseSection.GetValue("DatabaseName", "");
				conStrBuilder.SslMode = MySqlSslMode.None;

				QSMain.ConnectionString = conStrBuilder.GetConnectionString(true);
				var db_config = FluentNHibernate.Cfg.Db.MySQLConfiguration.Standard
										 .Dialect<NHibernate.Spatial.Dialect.MySQL57SpatialDialect>()
										 .ConnectionString(QSMain.ConnectionString);

				OrmConfig.ConfigureOrm(db_config,
					new System.Reflection.Assembly[] {
					System.Reflection.Assembly.GetAssembly(typeof(Vodovoz.HibernateMapping.OrganizationMap)),
					System.Reflection.Assembly.GetAssembly(typeof(QS.Banks.Domain.Bank)),
					System.Reflection.Assembly.GetAssembly(typeof(QS.HistoryLog.HistoryMain)),
					System.Reflection.Assembly.GetAssembly(typeof(QS.Project.Domain.UserBase))
				});

				QS.HistoryLog.HistoryMain.Enable();
			}
			catch(Exception ex)
			{
				_logger.LogCritical(ex, "Ошибка чтения конфигурационного файла.");
				return;
			}
		}

		protected override async Task ExecuteAsync(CancellationToken stoppingToken)
		{
			_channel.BasicConsume(_storedEmailStatusUpdatingQueueId, false, _consumer);
			await Task.Delay(0, stoppingToken);
		}

		public override Task StartAsync(CancellationToken cancellationToken)
		{
			_logger.LogInformation("Starting Stored Email Status Update Worker...");
			return base.StartAsync(cancellationToken);
		}

		public override Task StopAsync(CancellationToken cancellationToken)
		{
			_logger.LogInformation("Stopping Stored Email Status Update Worker...");
			return base.StopAsync(cancellationToken);
		}

		private async Task MessageRecieved(object sender, BasicDeliverEventArgs e)
		{
			try
			{
				var body = e.Body;

				var message = JsonSerializer.Deserialize<UpdateStoredEmailStatusMessage>(body.Span);

				_logger.LogInformation($"Recieved message to update status for stored email with id: { message.EventPayload.Id }" +
					$" to status: { message.Status }, request recieved at: { message.RecievedAt }");

				if(message.EventPayload.Trackable)
				{
					using (var unitOfWork = UnitOfWorkFactory.CreateWithoutRoot("Status update worker"))
					{
						var storedEmail = _emailRepository.GetById(unitOfWork, message.EventPayload.Id);

						if(storedEmail != null)
						{
							_logger.LogInformation($"Found Email: { storedEmail.Id }, externalId { storedEmail.ExternalId }, status { storedEmail.State }");

							if(storedEmail.StateChangeDate < message.RecievedAt)
							{
								var newStatus = ConvertFromMailjetStatus(message.Status);

								if(newStatus == StoredEmailStates.Undelivered || newStatus == StoredEmailStates.SendingError)
								{
									storedEmail.AddDescription(message.ErrorInfo);
								}

								storedEmail.State = newStatus;
								storedEmail.StateChangeDate = message.RecievedAt;

								unitOfWork.Save(storedEmail);
								unitOfWork.Commit();
							}
						}
						else
						{
							_logger.LogWarning($"Stored Email with id: { message.EventPayload.Id } not found");
						}
					}
				}

				_channel.BasicAck(e.DeliveryTag, false);
			}
			catch(Exception ex)
			{
				_logger.LogError(ex.Message);
				throw;
			}
		}

		private StoredEmailStates ConvertFromMailjetStatus(string mailjetStatus)
		{
			switch(mailjetStatus)
			{
				case "sent":
					return StoredEmailStates.Delivered;
				case "open":
					return StoredEmailStates.Opened;
				case "spam":
					return StoredEmailStates.MarkedAsSpam;
				case "bounce":
				case "blocked":
					return StoredEmailStates.Undelivered;
			}

			throw new ArgumentOutOfRangeException(nameof(mailjetStatus), $"Тип события { mailjetStatus } не поддерживается");
		}
	}
}
