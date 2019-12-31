using Medifii.ScraperService.Infrastructure.Dto;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Medifii.ScraperService.Infrastructure.Interfaces
{
	public interface IScraperService
	{
		Task<List<ProductDto>> GetProducts(string searchString);
	}
}
