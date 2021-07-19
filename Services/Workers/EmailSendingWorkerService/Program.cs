using Mailjet.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQInfrastructure;
using System;

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

					services.AddScoped<IMailjetClient>((sp) =>
					{
						var configuration = sp.GetRequiredService<IConfiguration>();
						var mailjetConfiguration = configuration.GetSection("Mailjet");
						var userId = mailjetConfiguration.GetValue<string>("UserId");
						var userKey = mailjetConfiguration.GetValue<string>("UserKey");
						return new MailjetClient(userId, userKey) { Version = ApiVersion.V3_1 /*, BaseAdress = ""*/ };
					});

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
