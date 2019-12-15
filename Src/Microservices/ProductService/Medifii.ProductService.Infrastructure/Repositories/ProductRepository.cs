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

        public void Create(Product product)
        {
            context.Set<Product>().Add(product);
            context.SaveChanges();
        }

        public void Update(Product product)
        {
            context.Set<Product>().Update(product);
            context.SaveChanges();
        }

        public void Delete(Product product)
        {
            context.Set<Product>().Remove(product);
            context.SaveChanges();
        }
    }
}
