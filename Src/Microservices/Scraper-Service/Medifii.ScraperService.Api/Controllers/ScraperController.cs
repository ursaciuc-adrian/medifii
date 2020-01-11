using System.Threading.Tasks;
using MediatR;
using Medifii.ScraperService.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Medifii.ScraperService.Api.Controllers
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

		[HttpGet("{name}")]
		public async Task<IActionResult> ScrapeByName([FromRoute] GetProductsByNameQuery query)
		{
			var result = await _mediator.Send(query);

			return new JsonResult(result);
		}
	}
}
