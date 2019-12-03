using AutoMapper;
using Medifii.ScraperService.Infrastructure;
using Medifii.ScraperService.Infrastructure.Interfaces;
using Medifii.ScraperService.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Medifii.ScraperService.Infrastructure.Entities;

namespace Medifii.ScraperService.Controllers
{
    [ApiController]
	[Route("[controller]")]
	public class ScraperController : ControllerBase
	{
        private readonly IEnumerable<IProductsService> _scraperServices;
        private readonly IMapper _mapper;

        public ScraperController(
            IEnumerable<IProductsService> scraperServices, 
            IMapper mapper)
        {
            _scraperServices = scraperServices;
            _mapper = mapper;
        }

		[HttpGet]
		public async Task<IActionResult> Index(string searchString)
		{
            var products = new List<Product>();

            foreach (var scraper in _scraperServices)
            {
                products.AddRange(await scraper.GetProducts(searchString));
            }

			return new JsonResult(_mapper.Map<List<ProductModel>>(products));
		}
    }
}
