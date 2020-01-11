using MediatR;
using Medifii.AuthService.Identity;
using Medifii.AuthService.Queries.LogOutUser;
using Medifii.AuthService.Services;
using System.Threading;
using System.Threading.Tasks;

namespace Medifii.AuthService.Api.Queries
{
	public class LogOutUserHandler : IRequestHandler<LogOutUserQuery>
	{
		private readonly IUserService<AppUser> _userService;

		public LogOutUserHandler(IUserService<AppUser> userService)
		{
			_userService = userService;
		}

		public async Task<Unit> Handle(LogOutUserQuery request, CancellationToken cancellationToken)
		{
			await _userService.SignOutAsync();

			return Unit.Value;
		}
	}
}
