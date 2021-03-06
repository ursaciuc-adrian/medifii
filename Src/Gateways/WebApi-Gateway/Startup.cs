﻿using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace Medifii.ApiGateway
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
			var authProviderKey = "TestKey";

			services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
				.AddIdentityServerAuthentication(authProviderKey, o =>
				{
					o.Authority = "http://localhost:7000";
					o.SupportedTokens = SupportedTokens.Both;
					o.RequireHttpsMetadata = false;
				});

			services.AddCors(options =>
			{
				options.AddPolicy("CorsPolicy",
					builder => builder.AllowAnyOrigin()
						.AllowAnyMethod()
						.AllowAnyHeader());
			});

			services.AddOcelot();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseCors("CorsPolicy");
			app.UseOcelot().Wait();
		}
	}
}
