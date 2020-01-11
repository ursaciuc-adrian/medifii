using MediatR;

namespace Medifii.AuthService.Queries.Identity
{
	public class GetUserIdentityQuery : IRequest<GetUserIdentityResponse>
	{
		public string Email { get; set; }
	}
}
