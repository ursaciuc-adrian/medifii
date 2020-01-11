using System.Collections.Generic;
using System.Threading.Tasks;
using Medifii.ScraperService.Dto;

namespace Medifii.ScraperService.Interfaces
{
	public interface IScraperService
	{
		Task<List<ProductDto>> GetProducts(string searchString);
	}
}
