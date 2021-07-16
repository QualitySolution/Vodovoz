using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQInfrastructure;

namespace EmailSendingWorkerService
{
	public class Program
	{
		public static void Main(string[] args)
		{
			CreateHostBuilder(args).Build().Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureServices((hostContext, services) =>
				{
					services.AddScoped<RabbitMQConnectionFactoryFactory>();
					services.AddScoped<RabbitMQConnectionFactory>();

					services.AddScoped<IConnectionFactory>((sp) => sp.GetRequiredService<RabbitMQConnectionFactoryFactory>().CreateConnectionFactory());
					services.AddScoped<IConnection>((sp) => sp.GetRequiredService<RabbitMQConnectionFactory>().CreateConnection());

					services.AddScoped<IModel>((sp) =>
					{
						var channel = sp.GetRequiredService<IConnection>().CreateModel();
						channel.BasicQos(0, 1, false);
						return channel;
					});

					services.AddHostedService<Worker>();
				});
	}
}
