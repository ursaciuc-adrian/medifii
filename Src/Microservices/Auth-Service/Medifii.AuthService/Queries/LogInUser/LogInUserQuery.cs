using MediatR;

namespace Medifii.AuthService.Queries.LogInUser
{
	public class LogInUserQuery : IRequest<LogInUserResponse>
	{
		public string Email { get; set; }
		public string Password { get; set; }
	}
}
