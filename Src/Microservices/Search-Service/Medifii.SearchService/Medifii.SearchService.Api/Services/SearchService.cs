using Medifii.SearchService.Api.Clients;
using Medifii.SearchService.Api.Domain;
using Medifii.SearchService.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Medifii.SearchService.Api.Services
{
	public class SearchService : ISearchService
	{
		private readonly IScraperClient _scraperClient;

		public SearchService(IScraperClient scraperClient)
		{
			_scraperClient = scraperClient;
		}

		public async Task<List<Product>> GetProductsByNameAsync(string name)
		{
			return await _scraperClient.GetProductsAsync(name);
		}
	}
}
