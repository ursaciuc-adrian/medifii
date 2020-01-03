using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Medifii.ApiGateway
{
	public class Program
	{
		public static void Main(string[] args)
		{
			CreateHostBuilder(args).Build().Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureAppConfiguration((hostingContext, config) =>
				{
					config
						.SetBasePath(hostingContext.HostingEnvironment.ContentRootPath)
						.AddJsonFile("appsettings.json", true, true)
						.AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", true, true)
						.AddJsonFile("ocelot.json")
						.AddEnvironmentVariables();
				})
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				});

		//public static void Main(string[] args)
		//{
		//	new WebHostBuilder()
		//		.UseKestrel()
		//		.UseContentRoot(Directory.GetCurrentDirectory())
		//		.ConfigureAppConfiguration((hostingContext, config) =>
		//		{
		//			config
		//				.SetBasePath(hostingContext.HostingEnvironment.ContentRootPath)
		//				.AddJsonFile("appsettings.json", true, true)
		//				.AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", true, true)
		//				.AddJsonFile("ocelot.json")
		//				.AddEnvironmentVariables();
		//		})
		//		.ConfigureServices(s =>
		//		{
		//			s.AddCors(options =>
		//			{
		//				options.AddPolicy("CorsPolicy",
		//					builder => builder.AllowAnyOrigin()
		//						.AllowAnyMethod()
		//						.AllowAnyHeader());
		//			});
		//			s.AddOcelot();
		//		})
		//		.ConfigureLogging((hostingContext, logging) =>
		//		{
		//			logging.AddConsole();
		//		})
		//		.UseIISIntegration()
		//		.Configure(app =>
		//		{
		//			app.UseCors("CorsPolicy");
		//			app.UseOcelot().Wait();
		//		})
		//		.Build()
		//		.Run();
		//}
	}
}
