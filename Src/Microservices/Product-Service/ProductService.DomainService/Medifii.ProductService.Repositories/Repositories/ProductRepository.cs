using System;
using System.Collections.Generic;
using System.Linq;
using CSharpFunctionalExtensions;
using Medifii.ProductService.Data.Entities;
using Medifii.ProductService.Data.RepositoryInterfaces;
using Medifii.ProductService.Persistence;

namespace Medifii.ProductService.Repositories.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext productContext;

        public ProductRepository(ProductContext productContext)
        {
            this.productContext = productContext;
        }

        public IEnumerable<Product> GetAll()
        {
            return productContext.Products.ToList();
        }

        public Maybe<Product> GetById(Guid id)
        {
            return productContext.Products.SingleOrDefault(product => product.Id == id);
        }

        public void Create(Product product)
        {
            productContext.Add(product);
        }

        public void Update(Product product)
        {
            productContext.Update(product);
        }

        public void Delete(Product product)
        {
            productContext.Remove(product);
        }

        public void SaveChanges()
        {
            productContext.SaveChanges();
        }
    }
}
