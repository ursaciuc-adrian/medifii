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
				BaseAddress = new Uri(configuration.GetValue<string>("ScraperService"))
			};

			_client = RestClient.For<IScraperClient>(httpClient);
		}

		public async Task<List<ProductDto>> GetProductsAsync(string name)
		{
			return await _client.GetProductsAsync(name);
		}
	}
}
