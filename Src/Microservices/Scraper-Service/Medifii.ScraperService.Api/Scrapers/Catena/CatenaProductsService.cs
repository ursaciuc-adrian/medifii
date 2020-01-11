using System.Collections.Generic;
using System.Threading.Tasks;
using Medifii.ScraperService.Dto;
using Medifii.ScraperService.Interfaces;
using Medifii.ScraperService.Scraper;

namespace Medifii.ScraperService.Api.Scrapers.Catena
{
	public class CatenaProductsService : IScraperService
	{
		private readonly MedifiiScraper<List<ProductDto>> _scraper;

		public CatenaProductsService()
		{
			_scraper = new CatenaScraper();
		}

		public async Task<List<ProductDto>> GetProducts(string searchString)
		{
			var options = new Options
			{
				Url = $"https://www.catena.ro/cauta/{searchString}"
			};
			
			return (await _scraper.Start(options)).Result;
		}
	}
}
