﻿using System.Collections.Generic;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Medifii.ScraperService.Dto;
using Medifii.ScraperService.Enums;
using Medifii.ScraperService.Scraper;

namespace Medifii.ScraperService.Api.Scrapers.Tei
{
	internal class TeiScraper : MedifiiScraper<List<ProductDto>>
	{
		protected override async Task Init(Options options)
		{
			await this.Request(options);
		}

		protected override Task<List<ProductDto>> Parse(HtmlDocument document)
		{
			var products = new List<ProductDto>();

			var productNodes = document.DocumentNode.SelectNodes("//*/div/ul[@class='products-grid row']/li");

			if (productNodes == null)
			{
				return Task.FromResult(products);
			}
			
			foreach (var productNode in productNodes)
			{
				var product = new ProductDto
				{
					Name = productNode.SelectSingleNode(".//div[@class='item-title']/a").InnerText,
					Url = this.Options.BaseUrl + productNode.SelectSingleNode(".//div/a").GetAttributeValue("href", string.Empty),
					Pharmacy = PharmacyType.Tei
				};

				products.Add(product);
			}

			return Task.FromResult(products);
		}
	}
}
