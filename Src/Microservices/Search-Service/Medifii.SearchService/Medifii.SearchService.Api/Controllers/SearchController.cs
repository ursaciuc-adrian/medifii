using System.Collections.Generic;
using System.Threading.Tasks;
using Medifii.SearchService.Api.Domain;
using Medifii.SearchService.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Medifii.SearchService.Api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class SearchController : ControllerBase
	{
		private readonly ILogger<SearchController> _logger;
		private readonly ISearchService _searchService;

		public SearchController(
			ILogger<SearchController> logger,
			ISearchService searchService)
		{
			_logger = logger;
			_searchService = searchService;
		}

		[HttpGet("{name}")]
		public async Task<List<Product>> GetByName([FromRoute] string name)
		{
			return await _searchService.GetProductsByNameAsync(name);
		}
	}
}
