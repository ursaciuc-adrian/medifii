using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Medifii.ScraperService.Infrastructure;
using Medifii.ScraperService.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Medifii.ScraperService.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ScraperController : ControllerBase
	{
		private readonly ILogger<ScraperController> _logger;

		public ScraperController(ILogger<ScraperController> logger)
		{
			_logger = logger;
		}

		[HttpGet]
		public async Task<IActionResult> Index(string searchString)
		{
			IScraperService service = new Scraper.Catena.ScraperService();

			return Ok(await service.GetProducts(searchString));
		}

        [HttpGet("/tei")]
        public async Task<IActionResult> GetTeiResults(string searchString)
        {
            IScraperService service = new Scraper.Tei.TeiService();

            return Ok(await service.GetProducts(searchString));
        }
    }
}
