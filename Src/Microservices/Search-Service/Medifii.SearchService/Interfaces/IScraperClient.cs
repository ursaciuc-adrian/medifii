using Medifii.SearchService.Dto;
using RestEase;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Medifii.SearchService.Interfaces
{
	public interface IScraperClient
	{
		[Get("/api/scraper/{name}")]
		Task<List<ProductDto>> GetProductsAsync([Path] string name);
	}
}
