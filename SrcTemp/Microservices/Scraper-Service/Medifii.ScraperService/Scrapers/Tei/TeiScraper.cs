using System.Collections.Generic;
using System.Threading.Tasks;

using HtmlAgilityPack;

using Medifii.ScraperService.Infrastructure.Entities;
using Medifii.ScraperService.Infrastructure.Enums;
using Medifii.ScraperService.Infrastructure.Scraper;

namespace Medifii.ScraperService.Scrapers.Tei
{
    internal class TeiScraper : MedifiiScraper<List<Product>>
    {
        public override async Task Init()
        {
            await this.Request("https://comenzi.farmaciatei.ro/search/coldrex");
        }

        public override Task<List<Product>> Parse(HtmlDocument document)
        {
            var products = new List<Product>();

            var productNodes = document.DocumentNode.SelectNodes("//*/div/ul[@class='products-grid row']/li");

            foreach (var productNode in productNodes)
            {
                var product = new Product
                {
                    Name = productNode.SelectSingleNode(".//div[@class='item-title']/a").InnerText,
                    Url = this.BaseUrl + productNode.SelectSingleNode(".//div/a").GetAttributeValue("href", string.Empty),
                    Pharmacy = Pharmacy.Tei
                };

                products.Add(product);
            }

            return Task.FromResult(products);
        }
    }
}
