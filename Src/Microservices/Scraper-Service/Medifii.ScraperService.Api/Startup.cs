using System.Reflection;
using AutoMapper;
using MediatR;
using Medifii.ScraperService.Api.Scrapers.Catena;
using Medifii.ScraperService.Api.Scrapers.Tei;
using Medifii.ScraperService.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Medifii.ScraperService.Api
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();
			services.AddAutoMapper(typeof(Startup));

			services.AddMvc(option => option.EnableEndpointRouting = false)
				.SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
				.AddNewtonsoftJson();

			services.AddTransient<IScraperService, CatenaProductsService>();
			services.AddTransient<IScraperService, TeiProductsService>();

			services.AddMediatR(Assembly.GetExecutingAssembly());
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});

			app.UseMvc();
		}
	}
}
