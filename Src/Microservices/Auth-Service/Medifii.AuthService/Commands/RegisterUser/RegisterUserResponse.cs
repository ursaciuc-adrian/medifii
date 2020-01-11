using System;

namespace Medifii.AuthService.Commands.RegisterUser
{
	public class RegisterUserResponse
	{
		public Guid PharmacyId { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string Email { get; set; }
	}
}
