﻿using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Threading;
using System.Threading.Tasks;
using BitrixApi.REST;
using BitrixIntegration;
using BitrixIntegration.ServiceInterfaces;
using Mono.Unix;
using Mono.Unix.Native;
using MySql.Data.MySqlClient;
using Nini.Config;
using NLog;
using QS.DomainModel.UoW;
using QS.Project.DB;
using QSProjectsLib;
using QSSupportLib;
using Vodovoz.Core.DataService;
using Vodovoz.EntityRepositories;
using Vodovoz.Models;
using Vodovoz.Repositories.Client;
using Vodovoz.Services;

namespace VodovozBitrixIntegrationService
{
	class Service
	{
		private static Logger logger = LogManager.GetCurrentClassLogger();

		private static readonly string configFile = "/home/gavr/vodovoz-bitrix-integration-service.conf"; 
		// private static readonly string configFile = "/etc/vodovoz-bitrix-integration-service.conf"; 
			
		//Service
		private static string serviceHostName;
		private static string servicePort;
		private static string serviceWebPort;

		//Mysql
		private static string mysqlServerHostName;
		private static string mysqlServerPort;
		private static string mysqlUser;
		private static string mysqlPassword;
		private static string mysqlDatabase;
		
		//Bitrix
		private static string token;
		

		public static void Main(string[] args)
		{
			AppDomain.CurrentDomain.UnhandledException += AppDomain_CurrentDomain_UnhandledException;
			AppDomain.CurrentDomain.ProcessExit += CurrentDomain_ProcessExit;
			logger.Info("Чтение конфигурационного файла...");
			// ReadConfig();

			#region ReadConfig

			try {
				IniConfigSource confFile = new IniConfigSource(configFile);
				confFile.Reload();
				IConfig serviceConfig = confFile.Configs["Service"];
				serviceHostName = serviceConfig.GetString("service_host_name");
				servicePort = serviceConfig.GetString("service_port");
				serviceWebPort = serviceConfig.GetString("service_web_port");

				IConfig mysqlConfig = confFile.Configs["Mysql"];
				mysqlServerHostName = mysqlConfig.GetString("mysql_server_host_name");
				mysqlServerPort = mysqlConfig.GetString("mysql_server_port", "3306");
				mysqlUser = mysqlConfig.GetString("mysql_user");
				mysqlPassword = mysqlConfig.GetString("mysql_password");
				mysqlDatabase = mysqlConfig.GetString("mysql_database");
				
				IConfig bitrixConfig = confFile.Configs["Bitrix"];
				token = bitrixConfig.GetString("api_key");
				
			}
			catch(Exception ex) {
				logger.Fatal(ex, "Ошибка чтения конфигурационного файла.");
				return;
			}

			#endregion ReadCOnfig
			logger.Info("Настройка подключения к БД...");
			ConfigureDBConnection();
			
			RunServiceLoop();
		}

		#region Configure

		//TODO gavr в отдельной функции не работает изза бага в Nini
		static void ReadConfig()
		{
			try {
				IniConfigSource confFile = new IniConfigSource(configFile);
				confFile.Reload();
				IConfig serviceConfig = confFile.Configs["Service"];
				serviceHostName = serviceConfig.GetString("service_host_name");
				servicePort = serviceConfig.GetString("service_port");
				serviceWebPort = serviceConfig.GetString("service_web_port");

				IConfig mysqlConfig = confFile.Configs["Mysql"];
				mysqlServerHostName = mysqlConfig.GetString("mysql_server_host_name");
				mysqlServerPort = mysqlConfig.GetString("mysql_server_port", "3306");
				mysqlUser = mysqlConfig.GetString("mysql_user");
				mysqlPassword = mysqlConfig.GetString("mysql_password");
				mysqlDatabase = mysqlConfig.GetString("mysql_database");
				
				IConfig bitrixConfig = confFile.Configs["Bitrix"];
				token = bitrixConfig.GetString("api_key");
			}
			
			catch(Exception ex) {
				logger.Fatal(ex, "Ошибка чтения конфигурационного файла.");
				return;
			}
		}

		static void ConfigureDBConnection()
		{
			try
			{
				var conStrBuilder = new MySqlConnectionStringBuilder
				{
					Server = mysqlServerHostName,
					Port = UInt32.Parse(mysqlServerPort),
					Database = mysqlDatabase,
					UserID = mysqlUser,
					Password = mysqlPassword,
					SslMode = MySqlSslMode.None
				};
				
				QSMain.ConnectionString = conStrBuilder.GetConnectionString(true);
				var dbConfig = FluentNHibernate.Cfg.Db.MySQLConfiguration.Standard
					.ConnectionString(conStrBuilder.GetConnectionString(true)); 

				OrmConfig.ConfigureOrm(
					dbConfig,
					new[]
					{
						System.Reflection.Assembly.GetAssembly(typeof(Vodovoz.HibernateMapping.OrganizationMap)),
						System.Reflection.Assembly.GetAssembly(typeof(QS.Banks.Domain.Bank)),
						System.Reflection.Assembly.GetAssembly(typeof(QS.HistoryLog.HistoryMain)),
						System.Reflection.Assembly.GetAssembly(typeof(QS.Project.Domain.UserBase))
					});

				MainSupport.LoadBaseParameters();
				QS.HistoryLog.HistoryMain.Enable();
			}
			catch (Exception ex)
			{
				logger.Fatal(ex, "Ошибка в настройке подключения к БД.");
			}
		}
		
		#endregion

		#region StartService
		static void RunServiceLoop()
		{
			try
			{
				StartService();
				logger.Info("Server started.");

				if(Environment.OSVersion.Platform == PlatformID.Unix) {
					UnixSignal[] signals = {
						new UnixSignal (Signum.SIGINT),
						new UnixSignal (Signum.SIGHUP),
						new UnixSignal (Signum.SIGTERM)
					};
					UnixSignal.WaitAny(signals);
				}
				else {
					Console.ReadLine();
				}
			}
			catch(Exception e) {
				logger.Fatal(e);
			}
			finally {
				if(Environment.OSVersion.Platform == PlatformID.Unix)
					Thread.CurrentThread.Abort();
				Environment.Exit(0);
			}
		}
		
		static async void StartService()
		{
			IBitrixServiceSettings baseParameters = new BaseParametersProvider();
			var bitrixInstanceProvider = new BitrixInstanceProvider(baseParameters);
			
			var bitrixHost = new BitrixServiceHost(bitrixInstanceProvider);

			var webContract = typeof(IBitrixServiceWeb);
			var webBinding = new WebHttpBinding();
			var webAddress = $"http://{serviceHostName}:{serviceWebPort}/BitrixServiceWeb";

			var webEndPoint = bitrixHost.AddServiceEndpoint(webContract, webBinding, webAddress);
			
			
			WebHttpBehavior httpBehavior = new WebHttpBehavior();
			webEndPoint.Behaviors.Add(httpBehavior);

			var contract = typeof(IBitrixService);
			var binding = new BasicHttpBinding();
			var address = $"http://{serviceHostName}:{servicePort}/BitrixService";


			BitrixManager.SetToken(token);
//ТЕСТ текущих функций
			logger.Info($"{address}");
			logger.Info($"{webAddress}");

			// BitrixManager.AddEvent(deal);
			var uow = UnitOfWorkFactory.CreateWithoutRoot();
			var matcher = new Matcher();
			var bitrixApi = BitrixRestApiFactory.CreateBitrixRestApi(token);
			var orderOrganizationProviderFactory = new OrderOrganizationProviderFactory();
			var orderOrganizationProvider = orderOrganizationProviderFactory.CreateOrderOrganizationProvider();
			var counterpartyContractRepository = new CounterpartyContractRepository(orderOrganizationProvider);
			var counterpartyContractFactory = new CounterpartyContractFactory(orderOrganizationProvider, counterpartyContractRepository);
			
				var cor = new CoR(
					baseParameters, 
					bitrixApi,
					uow, 
					matcher,
					counterpartyContractRepository,
					counterpartyContractFactory
				);
				
				// await cor.Process(158740); //138768 //150772 // 158740 тестовый
				var dealCollector = new DealCollector(bitrixApi);
				var mainCycle = new MainCycle(uow);
				
				await IdeaTests(cor, dealCollector, mainCycle);
				
			BitrixManager.SetCoR(cor);

			bitrixHost.AddServiceEndpoint(contract, binding, address);
			
			bitrixHost.Description.Behaviors.Add(new PreFilter());
			ServiceDebugBehavior debug = bitrixHost.Description.Behaviors.Find<ServiceDebugBehavior>();
			debug.IncludeExceptionDetailInFaults = true;
			
			bitrixHost.Open();

			logger.Log(LogLevel.Info, "Сервис запущен");

		

#if DEBUG
			// MailjetEventsHost.Description.Behaviors.Add(new PreFilter());
#endif
			// EmailSendingHost.Open();
			// MailjetEventsHost.Open();
		}

		private static async Task IdeaTests(CoR cor, DealCollector dealCollector, MainCycle cycle)
		{
			await cycle.RunProcessCycle(cor, dealCollector);
		}

		//

		#endregion StartService

		#region Signals

		static void CurrentDomain_ProcessExit(object sender, EventArgs e)
		{
			BitrixManager.StopWorkers();
		}

		static void AppDomain_CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
		{
			logger.Fatal((Exception)e.ExceptionObject, "UnhandledException");
		}

		#endregion
		
	}
}