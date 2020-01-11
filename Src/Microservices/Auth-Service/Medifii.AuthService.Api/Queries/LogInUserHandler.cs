using MediatR;
using Medifii.AuthService.Identity;
using Medifii.AuthService.Queries.LogInUser;
using Medifii.AuthService.Services;
using System.Threading;
using System.Threading.Tasks;

namespace Medifii.AuthService.Api.Queries
{
	public class LogInUserHandler : IRequestHandler<LogInUserQuery, LogInUserResponse>
	{
		private readonly IUserService<AppUser> _userService;

		public LogInUserHandler(IUserService<AppUser> userService)
		{
			_userService = userService;
		}

		public async Task<LogInUserResponse> Handle(LogInUserQuery request, CancellationToken cancellationToken)
		{
			var result = await _userService.AuthenticateAsync(request.Email, request.Password);

			if (string.IsNullOrEmpty(result))
			{
				return new LogInUserResponse();
			}

			return new LogInUserResponse
			{
				Token = result
			};
		}
	}
}
