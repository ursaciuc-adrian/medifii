using System.Collections.Generic;
using System.Threading.Tasks;

namespace Medifii.ScraperService.Infrastructure.Interfaces
{
	public interface IScraperService
	{
		Task<List<Product>> GetProducts(string searchString);
	}
}
