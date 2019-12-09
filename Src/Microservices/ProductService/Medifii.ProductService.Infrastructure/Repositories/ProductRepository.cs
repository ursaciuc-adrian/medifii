using System.Collections.Generic;
using Medifii.ProductService.Domain.Entities;
using Medifii.ProductService.Domain.Repositories;

namespace Medifii.ProductService.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext context;

        public ProductRepository(ProductContext context)
        {
            this.context = context;
        }

        public IEnumerable<Product> GetAll()
        {
            return context.Set<Product>();
        }
    }
}
