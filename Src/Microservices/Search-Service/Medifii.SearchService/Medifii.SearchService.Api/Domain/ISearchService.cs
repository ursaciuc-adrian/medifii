using Medifii.SearchService.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Medifii.SearchService.Api.Domain
{
	public interface ISearchService
	{
		Task<List<Product>> GetProductsByNameAsync(string name);
	}
}
