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
		[Get("{name}")]
		Task<List<Product>> GetProductsAsync([Path] string name);
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

		public async Task<List<Product>> GetProductsAsync([Query] string name)
		{
			return await _client.GetProductsAsync(name);
		}
	}
}
