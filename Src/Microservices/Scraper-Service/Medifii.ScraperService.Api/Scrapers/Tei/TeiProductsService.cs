using System.Collections.Generic;
using System.Threading.Tasks;
using Medifii.ScraperService.Dto;
using Medifii.ScraperService.Interfaces;
using Medifii.ScraperService.Scraper;

namespace Medifii.ScraperService.Api.Scrapers.Tei
{
	public class TeiProductsService : IScraperService
	{
		private readonly MedifiiScraper<List<ProductDto>> _scraper;

		public TeiProductsService()
		{
			_scraper = new TeiScraper();
		}

		public async Task<List<ProductDto>> GetProducts(string searchString)
		{
			var options = new Options
			{
				Url = $"https://comenzi.farmaciatei.ro/search/{searchString}"
			};
			
			return (await _scraper.Start(options)).Result;
		}
	}
}
