using Medifii.SearchService.Api.Models;
using RestEase;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Medifii.SearchService.Api.Clients
{
	public interface IScraperClient
	{
		[Get]
		Task<List<Product>> GetProductsAsync([Query] string searchString);
	}

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

		public async Task<List<Product>> GetProductsAsync([Query] string searchString)
		{
			return await _client.GetProductsAsync(searchString);
		}
	}
}
