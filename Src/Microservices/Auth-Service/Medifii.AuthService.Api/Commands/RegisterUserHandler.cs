using FluentValidation.Results;
using MediatR;
using Medifii.AuthService.Commands.RegisterUser;
using Medifii.AuthService.Identity;
using Medifii.AuthService.Services;
using NJsonSchema.Validation;
using System.Threading;
using System.Threading.Tasks;

namespace Medifii.AuthService.Api.Commands
{
	public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, RegisterUserResponse>
	{
		private readonly IUserService<AppUser> _userService;

		public RegisterUserHandler(IUserService<AppUser> userService)
		{
			_userService = userService;
		}

		public async Task<RegisterUserResponse> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
		{
			var appUser = new AppUser
			{
				PharmacyId = request.PharmacyId,
				FirstName = request.FirstName,
				LastName = request.LastName,
				UserName = request.Email,
				Email = request.Email

			};

			var result = await _userService.CreateAsync(appUser, request.Password);

			if(result != null)
			{
				return new RegisterUserResponse
				{
					Email = result.Email,
					FirstName = result.FirstName,
					LastName = result.LastName,
					PharmacyId = result.PharmacyId
				};
			}

			return null;
		}
	}
}
