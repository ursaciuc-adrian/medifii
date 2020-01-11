using MediatR;
using Medifii.AuthService.Identity;
using Medifii.AuthService.Queries.Identity;
using Medifii.AuthService.Services;
using System.Threading;
using System.Threading.Tasks;

namespace Medifii.AuthService.Api.Queries
{
	public class GetUserIdentityHandler : IRequestHandler<GetUserIdentityQuery, GetUserIdentityResponse>
	{
		private readonly IUserService<AppUser> _userService;

		public GetUserIdentityHandler(IUserService<AppUser> userService)
		{
			_userService = userService;
		}

		public async Task<GetUserIdentityResponse> Handle(GetUserIdentityQuery request, CancellationToken cancellationToken)
		{
			var result = await _userService.GetLoggedInUser(request.Email);

			if(result == null)
			{
				return new GetUserIdentityResponse();
			}

			return new GetUserIdentityResponse
			{
				FullName = result.FullName,
				PharmacyId = result.PharmacyId,
				Email = result.Email
			};
		}
	}
}
