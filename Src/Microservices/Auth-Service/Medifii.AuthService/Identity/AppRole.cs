using Microsoft.AspNetCore.Identity;
using System;

namespace Medifii.AuthService.Identity
{
	public sealed class AppRole : IdentityRole<Guid>
	{
		public AppRole() { }

		public AppRole(string name)
		{
			Name = name;
		}
	}
}
