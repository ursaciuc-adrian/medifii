using FluentValidation.AspNetCore;
using MediatR;
using Medifii.AuthService.Api.Context;
using Medifii.AuthService.Api.Extensions;
using Medifii.AuthService.Api.Options;
using Medifii.AuthService.Api.Services;
using Medifii.AuthService.Identity;
using Medifii.AuthService.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace Medifii.AuthService.Api
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
			services.Configure<JwtOptions>(options => Configuration.GetSection("Jwt").Bind(options));

			services.AddControllers().AddFluentValidation(opt =>
			{
				opt.RegisterValidatorsFromAssembly(typeof(AuthService.AppReference).GetTypeInfo().Assembly);
			}); ;

			services.AddDbContext<AuthContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

			services.AddIdentity<AppUser, AppRole>()
				.AddEntityFrameworkStores<AuthContext>()
				.AddDefaultTokenProviders();

			services.AddMediatR(Assembly.GetExecutingAssembly());

			services.AddTransient<IUserService<AppUser>, UserService>();

			services.AddJwtAuthentication(Configuration);

			services.AddSwaggerDocument(config =>
			{
				config.PostProcess = document =>
				{
					document.Info.Version = "v1";
					document.Info.Title = "Auth API";
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

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseOpenApi();
			app.UseSwaggerUi3();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
