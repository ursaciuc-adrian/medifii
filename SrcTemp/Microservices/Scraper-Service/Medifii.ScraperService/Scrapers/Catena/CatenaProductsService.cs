using System.Collections.Generic;
using System.Threading.Tasks;

using Medifii.ScraperService.Infrastructure.Entities;
using Medifii.ScraperService.Infrastructure.Interfaces;
using Medifii.ScraperService.Infrastructure.Scraper;

namespace Medifii.ScraperService.Scrapers.Catena
{
	public class CatenaProductsService : IProductsService
	{
		private readonly MedifiiScraper<List<Product>> _scraper;

		public CatenaProductsService()
		{
			_scraper = new CatenaScraper();
		}

		public async Task<List<Product>> GetProducts(string searchString)
		{
			return (await _scraper.Start()).Result;
		}
	}
}
