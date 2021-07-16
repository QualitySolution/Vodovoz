using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace EmailSendingWorkerService
{
	public class Worker : BackgroundService
	{
		private readonly ILogger<Worker> _logger;
		private readonly IModel _channel;
		private readonly string _mailSendingQueueId;
		private readonly EventingBasicConsumer _consumer;

		public Worker(ILogger<Worker> logger, IConfiguration configuration, IModel channel)
		{
			_logger = logger;
			_mailSendingQueueId = configuration.GetSection("Queues").GetValue<string>("MailSendingQueue");
			_channel = channel;
			_channel.QueueDeclare(_mailSendingQueueId, true, false, false, null);
			_consumer = new EventingBasicConsumer(_channel);
			_consumer.Received += MessageRecieved;
		}

		protected override async Task ExecuteAsync(CancellationToken stoppingToken)
		{
			_logger.LogInformation("Running Email Send Worker...");

			while(!stoppingToken.IsCancellationRequested)
			{
				_channel.BasicConsume(_mailSendingQueueId, false, _consumer);
				await Task.Delay(1000, stoppingToken);
			}

			_logger.LogInformation("Stopping Email Send Worker...");
		}

		private void MessageRecieved(object sender, BasicDeliverEventArgs e)
		{
			var body = e.Body;

			var message = JsonSerializer.Deserialize<MailMessage>(body.Span);

			_logger.LogInformation($"Recieved message to send:\n" +
				$"From: { message.From }\n" +
				$"To: { message.To }\n" +
				$"Body: { message.Body }\n" +
				$"With { message.Attachments?.Count ?? 0 } attachments");

			_channel.BasicAck(e.DeliveryTag, false);
		}
	}
}
