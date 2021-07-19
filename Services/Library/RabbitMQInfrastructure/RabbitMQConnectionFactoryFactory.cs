using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;

namespace RabbitMQInfrastructure
{
	public class RabbitMQConnectionFactoryFactory
	{
		private readonly IConfiguration _configuration;

		public RabbitMQConnectionFactoryFactory(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public IConnectionFactory CreateConnectionFactory()
		{
			var section = _configuration.GetSection("MessageBroker");

			return new ConnectionFactory
			{
				HostName = section.GetValue<string>("Hostname"),
				UserName = section.GetValue<string>("Username"),
				Password = section.GetValue<string>("Password"),
				VirtualHost = section.GetValue<string>("VirtualHost"),
				DispatchConsumersAsync = true
			};
		}
	}
}
