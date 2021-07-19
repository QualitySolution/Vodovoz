using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.MailSending;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace StoredEmailStatusUpdateWorker
{
	public class Worker : BackgroundService
	{
		private const string _queuesConfigurationSection = "Queues";

		private readonly string _storedEmailStatusUpdatingQueueId;

		private readonly ILogger<Worker> _logger;
		private readonly IModel _channel;
		private readonly AsyncEventingBasicConsumer _consumer;

		public Worker(ILogger<Worker> logger, IConfiguration configuration, IModel channel)
		{
			if(configuration is null)
			{
				throw new ArgumentNullException(nameof(configuration));
			}

			_logger = logger ?? throw new ArgumentNullException(nameof(logger));
			_channel = channel ?? throw new ArgumentNullException(nameof(channel));
			_storedEmailStatusUpdatingQueueId = configuration.GetSection(_queuesConfigurationSection)
				.GetValue<string>("StoredEmailStatusUpdatingQueue");
			_channel.QueueDeclare(_storedEmailStatusUpdatingQueueId, true, false, false, null);
			_consumer = new AsyncEventingBasicConsumer(_channel);
			_consumer.Received += MessageRecieved;
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
					// Status update
				}

				_channel.BasicAck(e.DeliveryTag, false);
			}
			catch(Exception ex)
			{
				_logger.LogError(ex.Message);
				throw;
			}
		}
	}
}
