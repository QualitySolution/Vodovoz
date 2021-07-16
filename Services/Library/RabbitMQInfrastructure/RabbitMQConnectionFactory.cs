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
		private readonly IConnectionFactory _connectionFactory;

		public RabbitMQConnectionFactory(ILogger<RabbitMQConnectionFactory> logger, IConnectionFactory connectionFactory)
		{
			_logger = logger;
			_connectionFactory = connectionFactory;
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
				catch(BrokerUnreachableException)
				{
					_logger.LogInformation("RabbitMQ instance is unreacheable...");
					Task.Delay(1000).Wait();
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
