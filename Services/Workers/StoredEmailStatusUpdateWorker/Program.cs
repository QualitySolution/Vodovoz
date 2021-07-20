using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQInfrastructure;
using Vodovoz.EntityRepositories;

namespace StoredEmailStatusUpdateWorker
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
					services.AddTransient<RabbitMQConnectionFactory>();

					services.AddTransient<IConnection>((sp) => sp.GetRequiredService<RabbitMQConnectionFactory>().CreateConnection());

					services.AddTransient<IModel>((sp) =>
					{
						var channel = sp.GetRequiredService<IConnection>().CreateModel();
						channel.BasicQos(0, 1, false);
						return channel;
					});

					services.AddTransient<IEmailRepository, EmailRepository>();

					services.AddHostedService<Worker>();
				});
	}
}
