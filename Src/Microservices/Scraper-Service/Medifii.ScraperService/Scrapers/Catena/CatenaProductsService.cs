using System.Collections.Generic;
using System.Threading.Tasks;

using Medifii.ScraperService.Infrastructure.Entities;
using Medifii.ScraperService.Infrastructure.Interfaces;
using Medifii.ScraperService.Infrastructure.Scraper;

namespace Medifii.ScraperService.Scrapers.Catena
{
	public class CatenaProductsService : IScraperService
	{
		private readonly MedifiiScraper<List<Product>> _scraper;

		public CatenaProductsService()
		{
			_scraper = new CatenaScraper();
		}

		public async Task<List<Product>> GetProducts(string searchString)
		{
			var options = new Options
			{
				Url = $"https://www.catena.ro/cauta/{searchString}"
			};
			
			return (await _scraper.Start(options)).Result;
		}
	}
}
