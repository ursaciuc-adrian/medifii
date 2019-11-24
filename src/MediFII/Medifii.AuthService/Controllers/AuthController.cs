using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Medifii.AuthService.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class AuthController : ControllerBase
	{
		private readonly ILogger<AuthController> _logger;

		public AuthController(ILogger<AuthController> logger)
		{
			_logger = logger;
		}

		[HttpGet]
		public IActionResult Get()
		{
			return Ok("Adrian Ursaciuc");
		}
	}
}
