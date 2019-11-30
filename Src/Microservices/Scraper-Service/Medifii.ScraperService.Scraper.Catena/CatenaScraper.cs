using Medifii.ScraperService.Infrastructure;
using Medifii.ScraperService.Infrastructure.Scraper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Medifii.ScraperService.Scraper.Catena
{
	internal class CatenaScraper : MedifiiScraper<List<Product>>
	{
		public override async Task Init()
		{
			await this.Request("https://www.catena.ro/cauta/aspirina");
		}

		public override Task<List<Product>> Parse(Response response)
		{
			var products = new List<Product>();

			var productNodes = response.Document.DocumentNode.SelectNodes("//*/div/ul[@class='searchedprods']/li");

			foreach (var productNode in productNodes)
			{
				var product = new Product
				{
					Name = productNode.SelectSingleNode(".//div/h2/a").InnerText,
					Url = this.BaseUrl + productNode.SelectSingleNode(".//div/h2/a").GetAttributeValue("href", string.Empty),
					Pharmacy = Pharmacy.Catena
				};

				products.Add(product);
			}

			//foreach (var product in Products)
			//{
			//	htmlDoc = web.Load(product.Url);

			//	product.Description = Regex.Replace(htmlDoc.DocumentNode.SelectSingleNode("//*[@id='tabs1']/div").InnerText, @"\t|\n|\r", "").Trim();
			//}

			return Task.FromResult(products);
		}
	}
}
