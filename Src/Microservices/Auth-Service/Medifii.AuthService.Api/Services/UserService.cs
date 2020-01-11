using Medifii.AuthService.Api.Options;
using Medifii.AuthService.Identity;
using Medifii.AuthService.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Medifii.AuthService.Api.Services
{
	public class UserService : IUserService<AppUser>
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly SignInManager<AppUser> _signInManager;
		private readonly IOptions<JwtOptions> _options;

		public UserService(
			UserManager<AppUser> userManager,
			SignInManager<AppUser> signInManager,
			IOptions<JwtOptions> options)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_options = options;
		}

		public async Task<string> AuthenticateAsync(string email, string password)
		{
			var result = await _signInManager.PasswordSignInAsync(email, password, false, false);

			if (result.Succeeded)
			{
				var appUser = await _userManager.FindByEmailAsync(email);
				var token = GenerateJwtToken(email, appUser);

				return token;
			}

			return string.Empty;
		}

		public async Task<AppUser> CreateAsync(AppUser user, string password)
		{
			var result = await _userManager.CreateAsync(user, password);

			if (result.Succeeded)
			{
				return user;
			}

			return null;
		}

		public async Task<AppUser> GetLoggedInUser(string email)
		{
			return await _userManager.FindByEmailAsync(email);
		}

		public async Task SignOutAsync()
		{
			await _signInManager.SignOutAsync();
		}

		private string GenerateJwtToken(string email, AppUser user)
		{
			var claims = new List<Claim>
			{
				new Claim("PharmacyId", user.PharmacyId.ToString()),
				new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
				new Claim(ClaimTypes.Email, email)
			};

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Value.Key));
			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
			var expires = DateTime.Now.AddDays(Convert.ToDouble(_options.Value.ExpireDays));

			var token = new JwtSecurityToken(
				_options.Value.Issuer,
				_options.Value.Issuer,
				claims,
				expires: expires,
				signingCredentials: creds
			);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}
	}
}
