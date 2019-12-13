using System.Collections.Generic;
using Medifii.ProductService.Domain.Entities;

namespace Medifii.ProductService.Domain.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        void Create(Product product);
        void Update(Product product);
        void Delete(Product product);
    }
}
