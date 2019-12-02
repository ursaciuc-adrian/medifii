using System.Collections.Generic;
using System.Threading.Tasks;
using Medifii.ScraperService.Infrastructure;
using Medifii.ScraperService.Infrastructure.Interfaces;
using Medifii.ScraperService.Infrastructure.Scraper;

namespace Medifii.ScraperService.Scraper.Tei
{
    public class TeiService : IScraperService
    {
        private readonly MedifiiScraper<List<Product>> _scraper;
        public TeiService()
        {
            _scraper = new ScraperTei();
        }

        public async Task<List<Product>> GetProducts(string searchString)
        {
            return (await _scraper.Start()).Result;
        }
    }
}
