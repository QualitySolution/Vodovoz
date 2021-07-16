using Mailjet.Client;
using Mailjet.Client.Resources;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
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
		private readonly EventingBasicConsumer _consumer;
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
			_consumer = new EventingBasicConsumer(_channel);
			_consumer.Received += MessageRecieved;
			_sandboxMode = configuration.GetSection(_mailjetConfigurationSection).GetValue("Sandbox", true);
		}

		protected override async Task ExecuteAsync(CancellationToken stoppingToken)
		{
			_logger.LogInformation("Running Email Send Worker...");

			while(!stoppingToken.IsCancellationRequested)
			{
				var someResponse = _channel.BasicConsume(_mailSendingQueueId, false, _consumer);
				_logger.LogInformation($"Some response after consume: { someResponse }");
				_logger.LogInformation("Stepped after consume");
				await Task.Delay(1000, stoppingToken);
			}

			_logger.LogInformation("Stopping Email Send Worker...");
		}

		private void MessageRecieved(object sender, BasicDeliverEventArgs e)
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
				};

				maijetRequest.Property(Send.SandboxMode, _sandboxMode);
				maijetRequest.Property(Send.Messages, new [] { message } );

				_mailjetClient.PostAsync(maijetRequest);

				_channel.BasicAck(e.DeliveryTag, false);
			}
			catch(Exception ex)
			{
				
			}
		}
	}
}
