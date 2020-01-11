using FluentValidation.AspNetCore;
using IdentityServer4.AccessTokenValidation;
using MediatR;
using Medifii.Common.DataAccess;
using Medifii.Common.Extensions;
using Medifii.ReservationService.Api.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Reflection;
using System.Text;

namespace Medifii.ReservationService.Api
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
			services.AddControllers().AddFluentValidation(opt =>
			{
				opt.RegisterValidatorsFromAssembly(typeof(ReservationService.AppReference).GetTypeInfo().Assembly);
			});

			services.AddDbContext<ReservationsContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

			services.AddScoped<IUnitOfWork<ReservationsContext>, UnitOfWork<ReservationsContext>>();

			services.AddMediatR(Assembly.GetExecutingAssembly());

			services.AddJwtAuthentication(Configuration);

			services.AddSwaggerDocument(config =>
			{
				config.PostProcess = document =>
				{
					document.Info.Version = "v1";
					document.Info.Title = "Reservations API";
				};
			});
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseOpenApi();
			app.UseSwaggerUi3();

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
