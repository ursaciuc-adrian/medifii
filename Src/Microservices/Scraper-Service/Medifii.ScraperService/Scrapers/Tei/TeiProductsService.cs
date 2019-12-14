using System.Collections.Generic;
using System.Threading.Tasks;

using Medifii.ScraperService.Infrastructure.Entities;
using Medifii.ScraperService.Infrastructure.Interfaces;
using Medifii.ScraperService.Infrastructure.Scraper;

namespace Medifii.ScraperService.Scrapers.Tei
{
	public class TeiProductsService : IProductsService
	{
		private readonly MedifiiScraper<List<Product>> _scraper;

		public TeiProductsService()
		{
			_scraper = new TeiScraper();
		}

		public async Task<List<Product>> GetProducts(string searchString)
		{
			var options = new Options
			{
				Url = $"https://comenzi.farmaciatei.ro/search/{searchString}"
			};
			
			return (await _scraper.Start(options)).Result;
		}
	}
}
