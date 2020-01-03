using Medifii.ScraperService.Infrastructure.Queries;
using Medifii.SearchService.Dto;
using Medifii.SearchService.Interfaces;
using Microsoft.Extensions.Configuration;
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

		public ScraperClient(IConfiguration configuration)
		{
			var httpClient = new HttpClient()
			{
				BaseAddress = new Uri(configuration.GetValue<string>("ScraperServiceUri"))
			};

			_client = RestClient.For<IScraperClient>(httpClient);
		}

		public async Task<List<ProductDto>> GetProductsAsync([Body] GetProductsByNameQuery query)
		{
			return await _client.GetProductsAsync(query);
		}
	}
}
