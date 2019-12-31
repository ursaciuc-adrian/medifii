using Medifii.ScraperService.Infrastructure.Queries;
using Medifii.SearchService.Dto;
using Medifii.SearchService.Interfaces;
using Medifii.SearchService.Queries;
using RestEase;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Medifii.SearchService.Api.Clients
{
	public class ScraperClient : IScraperClient
	{
		private readonly IScraperClient _client;

		public ScraperClient()
		{
			var httpClient = new HttpClient()
			{
				BaseAddress = new Uri("http://localhost:7020/api/scraper")
			};

			_client = RestClient.For<IScraperClient>(httpClient);
		}

		public async Task<List<ProductDto>> GetProductsAsync([Body] GetProductsByNameQuery query)
		{
			return await _client.GetProductsAsync(query);
		}
	}
}
