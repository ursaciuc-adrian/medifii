using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace Medifii.ApiGateway
{
	public class Program
	{
		public static void Main(string[] args)
		{
			new WebHostBuilder()
			.UseKestrel()
			.UseContentRoot(Directory.GetCurrentDirectory())
			.ConfigureAppConfiguration((hostingContext, config) =>
			{
				config
					.SetBasePath(hostingContext.HostingEnvironment.ContentRootPath)
					.AddJsonFile("appsettings.json", true, true)
					.AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", true, true)
					.AddJsonFile("ocelot.json")
					.AddEnvironmentVariables();
			})
			.ConfigureServices(s => s.AddOcelot())
			.ConfigureLogging((hostingContext, logging) =>
			{
				logging.AddConsole();
			})
			.UseIISIntegration()
			.Configure(app =>
			{
				app.UseOcelot().Wait();
			})
			.Build()
			.Run();
		}
	}
}
