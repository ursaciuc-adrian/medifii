using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Medifii.AuthService.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class AuthController : ControllerBase
	{
		[HttpGet]
		public IActionResult Get()
		{
			return Ok("Adrian Ursaciuc");
		}
	}
}
