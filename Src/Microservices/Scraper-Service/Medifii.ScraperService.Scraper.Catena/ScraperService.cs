using Medifii.ScraperService.Infrastructure;
using Medifii.ScraperService.Infrastructure.Interfaces;
using Medifii.ScraperService.Infrastructure.Scraper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Medifii.ScraperService.Scraper.Catena
{
	public class ScraperService : IScraperService
	{
		private readonly MedifiiScraper<List<Product>> _scraper;
		public ScraperService()
		{
			_scraper = new CatenaScraper();
		}
		public async Task<List<Product>> GetProducts(string searchString)
		{
			return (await _scraper.Start()).Result;
		}
	}
}
