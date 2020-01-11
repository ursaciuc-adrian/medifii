using Medifii.AuthService.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Medifii.AuthService.Api.Context
{
	public class AuthContext : IdentityDbContext<AppUser, AppRole, Guid>
	{
		public AuthContext(DbContextOptions options)
			: base(options)
		{
			Database.EnsureCreated();
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.Entity<AppUser>().ToTable("Users");
			builder.Entity<AppRole>().ToTable("Roles");
			builder.Entity<IdentityUserRole<Guid>>().ToTable("UserRoles");
			builder.Entity<IdentityUserClaim<Guid>>().ToTable("Claims");
			builder.Entity<IdentityUserLogin<Guid>>().ToTable("UserLogins");
			builder.Entity<IdentityRoleClaim<Guid>>().ToTable("RoleClaims");
			builder.Entity<IdentityUserToken<Guid>>().ToTable("UserTokens");
		}
	}
}
