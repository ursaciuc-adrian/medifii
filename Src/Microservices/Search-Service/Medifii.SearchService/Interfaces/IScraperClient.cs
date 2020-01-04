using Medifii.ScraperService.Infrastructure.Queries;
using Medifii.SearchService.Dto;
using RestEase;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Medifii.SearchService.Interfaces
{
	public interface IScraperClient
	{
		[Post]
		Task<List<ProductDto>> GetProductsAsync([Body] GetProductsByNameQuery query);
	}
}
