using AutoMapper;
using Medifii.ScraperService.Infrastructure.Interfaces;
using Medifii.ScraperService.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Medifii.ScraperService.Infrastructure.Entities;
using MediatR;
using Medifii.ScraperService.Infrastructure.Queries;

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

		[HttpGet("{name}")]
		public async Task<IActionResult> ScrapeByName([FromRoute] string name)
		{
			//var products = new List<Product>();

			//foreach (var scraper in _scraperServices)
			//{
			//	products.AddRange(await scraper.GetProducts(searchString));
			//}

			//return new JsonResult(_mapper.Map<List<ProductModel>>(products));

			var result = await _mediator.Send(new GetProductsByNameQuery { Name = name });

			return new JsonResult(result);
		}

		[HttpGet]
		[Route("test")]
		public string GetTest(string searchString)
		{
			return "You searched for: " + searchString;
		}
	}
}
