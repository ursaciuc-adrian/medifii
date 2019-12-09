using System.Collections.Generic;
using Medifii.ProductService.Domain.Entities;

namespace Medifii.ProductService.Domain.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
    }
}
