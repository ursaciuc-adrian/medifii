using MediatR;
using Medifii.AuthService.Commands.RegisterUser;
using Medifii.AuthService.Queries.LogInUser;
using Medifii.AuthService.Queries.LogOutUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Medifii.AuthService.Api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class AuthController : ControllerBase
	{
		private readonly IMediator _mediator;

		public AuthController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost("login")]
		public async Task<IActionResult> LogIn([FromBody] LogInUserQuery query)
		{
			var result = await _mediator.Send(query);

			return new JsonResult(result);
		}

		[HttpPost("register")]
		public async Task<IActionResult> Register([FromBody] RegisterUserCommand command)
		{
			var result = await _mediator.Send(command);

			return new JsonResult(result);
		}

		[Authorize]
		[HttpPost("logout")]
		public async Task<IActionResult> LogOut()
		{
			var result = await _mediator.Send(new LogOutUserQuery());

			return new JsonResult(result);
		}
	}
}
