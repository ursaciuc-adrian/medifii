using System;

namespace Medifii.AuthService.Queries.Identity
{
	public class GetUserIdentityResponse
	{
		public Guid PharmacyId { get; set; }
		public string FullName { get; set; }
		public string Email { get; set; }
	}
}
