using Medifii.ScraperService.Infrastructure.Entities;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Medifii.ScraperService.Infrastructure.Interfaces
{
    public interface IProductsService
	{
		Task<List<Product>> GetProducts(string searchString);
	}
}
