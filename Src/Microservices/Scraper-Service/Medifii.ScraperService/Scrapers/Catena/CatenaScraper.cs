﻿using System.Collections.Generic;
using System.Threading.Tasks;

using HtmlAgilityPack;

using Medifii.ScraperService.Infrastructure.Entities;
using Medifii.ScraperService.Infrastructure.Enums;
using Medifii.ScraperService.Infrastructure.Scraper;

namespace Medifii.ScraperService.Scrapers.Catena
{
    internal class CatenaScraper : MedifiiScraper<List<Product>>
	{
		protected override async Task Init(Options options)
		{
			await this.Request(options);
		}

		protected override Task<List<Product>> Parse(HtmlDocument document)
		{
			var products = new List<Product>();

			var productNodes = document.DocumentNode.SelectNodes("//*/div/ul[@class='searchedprods']/li");

			if (productNodes == null)
			{
				return Task.FromResult(products);
			}
			
			foreach (var productNode in productNodes)
			{
				var product = new Product
				{
					Name = productNode.SelectSingleNode(".//div/h2/a").InnerText,
					Url = this.Options.BaseUrl + productNode.SelectSingleNode(".//div/h2/a").GetAttributeValue("href", string.Empty),
					Pharmacy = Pharmacy.Catena
				};

				products.Add(product);
			}
			
			return Task.FromResult(products);
		}
	}
}
