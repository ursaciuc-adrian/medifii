using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medifii.AuthService.Identity
{
	public sealed class AppUser : IdentityUser<Guid>
	{
		public Guid PharmacyId { get; set; }

		public string FirstName { get; set; }
		public string LastName { get; set; }

		[NotMapped]
		public string FullName => $"{FirstName} {LastName}";
	}
}
