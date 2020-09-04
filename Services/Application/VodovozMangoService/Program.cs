using System;
using System.Net;
using Grpc.Core;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Nini.Config;
using NLog.Web;

namespace VodovozMangoService
{
	public class Program
    {
	    private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
	    private static readonly string configFile = "/etc/vodovoz-mango-service.conf";
	    
	    //MangoService
	    private static int notficationServicePort;
	    private static int mangoServiceHTTPPort; 
	    private static int mangoServiceHTTPSPort; 
	    
	    //Mysql
	    private static string mysqlServerHostName;
	    private static string mysqlServerPort;
	    private static string mysqlUser;
	    private static string mysqlPassword;
	    private static string mysqlDatabase;
	    
	    //Mango
	    public static string VpbxApiKey;
	    public static string VpbxApiSalt;

	    public static NotificationServiceImpl NotificationServiceInstance;
	    public static void Main(string[] args)
        {
	        #region Читаем конфигурацию
	        try {
		        IniConfigSource confFile = new IniConfigSource(configFile);
		        confFile.Reload();

		        IConfig serviceConfig = confFile.Configs["MangoService"];
		        notficationServicePort = serviceConfig.GetInt("grps_client_port");
		        mangoServiceHTTPPort = serviceConfig.GetInt("http_port");
		        mangoServiceHTTPSPort = serviceConfig.GetInt("https_port");
		        
		        IConfig mysqlConfig = confFile.Configs["Mysql"];
				mysqlServerHostName = mysqlConfig.GetString("mysql_server_host_name");
				mysqlServerPort = mysqlConfig.GetString("mysql_server_port", "3306");
				mysqlUser = mysqlConfig.GetString("mysql_user");
				mysqlPassword = mysqlConfig.GetString("mysql_password");
				mysqlDatabase = mysqlConfig.GetString("mysql_database");
				
				IConfig mangoConfig = confFile.Configs["Mango"];
				VpbxApiKey = mangoConfig.GetString("vpbx_api_key");
				VpbxApiSalt = mangoConfig.GetString("vpbx_api_salt");
	        }
	        catch(Exception ex) {
		        logger.Fatal(ex, "Ошибка чтения конфигурационного файла.");
		        return;
	        }
	        #endregion
	        
	        InitNotifacationService();
	        CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
	            .ConfigureLogging(logging =>
	            {
		            logging.ClearProviders();
		            logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
	            })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                        .UseKestrel(k =>
                        {
                            var appServices = k.ApplicationServices;
                            k.Listen(
                                IPAddress.Any, mangoServiceHTTPSPort,
                                o => o.UseHttps(h =>
                                {
                                    h.UseLettuceEncrypt(appServices);
                                }));
                            k.Listen(IPAddress.Any, mangoServiceHTTPPort);
                        })
                        .UseStartup<Startup>();
                })
	            .UseNLog();

        private static void InitNotifacationService()
        {
	        var service = NotificationServiceInstance = new NotificationServiceImpl();
            Server server = new Server
            {
                Services = { NotificationService.BindService(service) },
                Ports = { new ServerPort("0.0.0.0", notficationServicePort, ServerCredentials.Insecure) }
            };
            server.Start();
        }
    }
}