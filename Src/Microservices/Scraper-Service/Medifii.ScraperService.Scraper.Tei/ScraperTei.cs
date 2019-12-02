using System.Collections.Generic;
using System.Threading.Tasks;
using Medifii.ScraperService.Infrastructure;
using Medifii.ScraperService.Infrastructure.Scraper;

namespace Medifii.ScraperService.Scraper.Tei
{
    public class ScraperTei : MedifiiScraper<List<Product>>
    {
        public override async Task Init()
        {
            await this.Request("https://comenzi.farmaciatei.ro/search/coldrex");
        }

        public override Task<List<Product>> Parse(Response response)
        {
            var products = new List<Product>();

            var productNodes = response.Document.DocumentNode.SelectNodes("//*/div/ul[@class='products-grid row']/li");

            foreach (var productNode in productNodes)
            {
                var product = new Product
                {
                    Name = productNode.SelectSingleNode(".//div[@class='item-title']/a").InnerText,
                    Url = this.BaseUrl + productNode.SelectSingleNode(".//div/a").GetAttributeValue("href", string.Empty),
                    Pharmacy = Pharmacy.Catena
                };

                products.Add(product);
            }

            return Task.FromResult(products);
        }
    }
}
