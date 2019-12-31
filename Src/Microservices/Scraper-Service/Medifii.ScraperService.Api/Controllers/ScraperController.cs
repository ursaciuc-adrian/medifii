using MediatR;
using Medifii.ScraperService.Infrastructure.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Medifii.ScraperService.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ScraperController : ControllerBase
	{
		private readonly IMediator _mediator;

		public ScraperController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost]
		public async Task<IActionResult> ScrapeByName([FromBody] GetProductsByNameQuery query)
		{
			var result = await _mediator.Send(query);

			return new JsonResult(result);
		}
	}
}
