using System.Threading.Tasks;
using MediatR;
using Medifii.SearchService.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Medifii.SearchService.Api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class SearchController : ControllerBase
	{
		private readonly IMediator _mediator;

		public SearchController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost]
		public async Task<IActionResult> GetByName([FromBody] SearchProductsQuery query)
		{
			var result = await _mediator.Send(query);

			return new JsonResult(result);
		}
	}
}
