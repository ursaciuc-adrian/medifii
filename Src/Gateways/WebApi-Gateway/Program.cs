using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
				.ConfigureServices(s =>
				{
					s.AddCors(options =>
					{
						options.AddPolicy("CorsPolicy",
							builder => builder.AllowAnyOrigin()
								.AllowAnyMethod()
								.AllowAnyHeader());
					});
					s.AddOcelot();
				})
				.ConfigureLogging((hostingContext, logging) =>
				{
					logging.AddConsole();
				})
				.UseIISIntegration()
				.Configure(app =>
				{
					app.UseCors("CorsPolicy");
					app.UseOcelot().Wait();
				})
				.Build()
				.Run();
		}
	}
}
