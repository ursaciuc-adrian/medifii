using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Medifii.ScraperService
{
	public class Startup
	{
        private readonly string AllowedOrigins = "allowedOrigins";

        public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}


		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();
            services.AddCors(options =>
            {
                options.AddPolicy(AllowedOrigins, builder =>
                        {
                            builder.WithOrigins("http://localhost:4200")
                                .AllowCredentials()
                                .AllowAnyMethod()
                                .AllowAnyHeader();
                        });
            });
            services.AddMvc(option => option.EnableEndpointRouting = false).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        }

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

            app.UseCors(AllowedOrigins);

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
