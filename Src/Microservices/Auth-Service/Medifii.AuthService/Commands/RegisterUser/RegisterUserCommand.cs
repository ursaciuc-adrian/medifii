using MediatR;
using System;

namespace Medifii.AuthService.Commands.RegisterUser
{
	public class RegisterUserCommand : IRequest<RegisterUserResponse>
	{
		public Guid PharmacyId { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string Email { get; set; }

		public string Password { get; set; }

		public string ConfirmPassword { get; set; }
	}
}
