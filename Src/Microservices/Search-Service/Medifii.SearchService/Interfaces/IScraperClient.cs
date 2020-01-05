using Medifii.SearchService.Dto;
using Medifii.SearchService.Queries;
using RestEase;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Medifii.SearchService.Interfaces
{
	public interface IScraperClient
	{
		[Post("/api/scraper")]
		Task<List<ProductDto>> GetProductsAsync([Body] GetProductsByNameScraperQuery query);
	}
}
