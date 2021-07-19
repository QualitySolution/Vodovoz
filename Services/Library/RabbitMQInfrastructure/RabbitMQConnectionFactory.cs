using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Exceptions;
using System;
using System.Threading.Tasks;

namespace RabbitMQInfrastructure
{
	public class RabbitMQConnectionFactory
	{
		private readonly ILogger<RabbitMQConnectionFactory> _logger;
		private readonly IConfiguration _configuration;
		private readonly IConnectionFactory _connectionFactory;

		public RabbitMQConnectionFactory(ILogger<RabbitMQConnectionFactory> logger, IConfiguration configuration)
		{
			_configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
			_logger = logger ?? throw new ArgumentNullException(nameof(logger));

			var section = _configuration.GetSection("MessageBroker");

			_connectionFactory=  new ConnectionFactory
			{
				HostName = section.GetValue<string>("Hostname"),
				UserName = section.GetValue<string>("Username"),
				Password = section.GetValue<string>("Password"),
				VirtualHost = section.GetValue<string>("VirtualHost"),
				DispatchConsumersAsync = true
			};
		}

		public IConnection CreateConnection()
		{
			bool waitingForRabbit = true;

			IConnection connection = null;

			_logger.LogInformation("Trying to establish connection...");

			while(waitingForRabbit)
			{
				try
				{
					connection = _connectionFactory.CreateConnection();
				}
				catch(BrokerUnreachableException ex)
				{
					if(ex.InnerException is AuthenticationFailureException authException)
					{
						_logger.LogInformation("RabbitMQ credentials is wrong...");
						throw;
					}
					_logger.LogInformation("RabbitMQ instance is unreacheable...");
					Task.Delay(5000).Wait();
					continue;
				}

				waitingForRabbit = false;
			}

			if(connection == null)
			{
				throw new Exception("Connection not established");
			}

			return connection;
		}
	}
}
