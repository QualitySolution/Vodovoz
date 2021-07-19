using Mailjet.Client;
using Mailjet.Client.Resources;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.MailSending;
using System;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace EmailSendingWorkerService
{
	public class Worker : BackgroundService
	{
		private const string _mailjetConfigurationSection = "Mailjet";
		private const string _queuesConfigurationSection = "Queues";

		private readonly ILogger<Worker> _logger;
		private readonly IModel _channel;
		private readonly IMailjetClient _mailjetClient;
		private readonly string _mailSendingQueueId;
		private readonly AsyncEventingBasicConsumer _consumer;
		private readonly bool _sandboxMode; 

		public Worker(ILogger<Worker> logger, IConfiguration configuration, IModel channel, IMailjetClient mailjetClient)
		{
			if(configuration is null)
			{
				throw new ArgumentNullException(nameof(configuration));
			}

			_logger = logger ?? throw new ArgumentNullException(nameof(logger));
			_mailSendingQueueId = configuration.GetSection(_queuesConfigurationSection).GetValue<string>("MailSendingQueue");
			_channel = channel ?? throw new ArgumentNullException(nameof(channel));
			_mailjetClient = mailjetClient ?? throw new ArgumentNullException(nameof(mailjetClient));
			_channel.QueueDeclare(_mailSendingQueueId, true, false, false, null);
			_consumer = new AsyncEventingBasicConsumer(_channel);
			_consumer.Received += MessageRecieved;
			_sandboxMode = configuration.GetSection(_mailjetConfigurationSection).GetValue("Sandbox", true);
		}

		protected override async Task ExecuteAsync(CancellationToken stoppingToken)
		{
			_channel.BasicConsume(_mailSendingQueueId, false, _consumer);
			await Task.Delay(0, stoppingToken);
		}

		public override Task StartAsync(CancellationToken cancellationToken)
		{
			_logger.LogInformation("Starting Email Send Worker...");
			return base.StartAsync(cancellationToken);
		}

		public override Task StopAsync(CancellationToken cancellationToken)
		{
			_logger.LogInformation("Stopping Email Send Worker...");
			return base.StopAsync(cancellationToken);
		}

		private async Task MessageRecieved(object sender, BasicDeliverEventArgs e)
		{
			try
			{
				var body = e.Body;

				var message = JsonSerializer.Deserialize<SendEmailMessage>(body.Span);

				_logger.LogInformation($"Recieved message to send to recipient: { message.To.Email }" +
					$" with subject: \"{ message.Subject }\", with { message.Attachments?.Count() ?? 0 } attachments");

				var maijetRequest = new MailjetRequest
				{
					Resource = Send.Resource
				}
					.Property(Send.Messages, new JArray
					{
						new JObject
						{
							{ "From", new JObject
								{
									{ "Name", message.From.Name },
									{ "Email", message.From.Email }
								}
							},
							{ "To", new JArray
								{
									new JObject
									{
										{ "Name", message.To.Name },
										{ "Email", message.To.Email }
									}
								}
							},
							{ "Subject", message.Subject },
							{ "TextPart", message.TextPart },
							{ "HTMLPart", message.HTMLPart },
							{ "EventPayload", message.EventPayload.ToString() }
						}
					})
					.Property(Send.SandboxMode, _sandboxMode);

				var response = await _mailjetClient.PostAsync(maijetRequest);

				if(!response.IsSuccessStatusCode)
				{
					_channel.BasicPublish("", _mailSendingQueueId, null, body);
					_channel.BasicAck(e.DeliveryTag, false);
					throw new ResponseNotSuccededException(response.GetErrorInfo());
				}

				_channel.BasicAck(e.DeliveryTag, false);
			}
			catch(ResponseNotSuccededException ex)
			{
				_logger.LogError(ex.Message);
			}
			catch(Exception ex)
			{
				_logger.LogError(ex.Message);
			}
		}
	}
}
