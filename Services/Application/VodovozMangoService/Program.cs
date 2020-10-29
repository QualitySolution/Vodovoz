using System;
using System.Net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;

namespace VodovozMangoService
{
	public class Program
    {
	    private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
	    private static readonly string configFile = "/etc/vodovoz-mango-service.conf";
	    public static void Main(string[] args)
        {
	        CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
	            .ConfigureAppConfiguration((context, builder) =>
	            {
		            builder.AddIniFile(configFile);
	            })
	            .ConfigureLogging(logging =>
	            {
		            logging.ClearProviders();
		            logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
	            })
	            .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                        .UseKestrel( (context, k) =>
                        {
                            var appServices = k.ApplicationServices;
                            k.Listen(
                                IPAddress.Any, Int32.Parse(context.Configuration["MangoService:https_port"]),
                                o => o.UseHttps(h =>
                                {
                                    h.UseLettuceEncrypt(appServices);
                                }));
                            k.Listen(IPAddress.Any, Int32.Parse(context.Configuration["MangoService:http_port"]));
                        })
                        .UseStartup<Startup>();
                })
	            .UseNLog();
    }
}