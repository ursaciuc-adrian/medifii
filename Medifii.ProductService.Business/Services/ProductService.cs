using System.Collections.Generic;
using Medifii.ProductService.Business.Mappers;
using Medifii.ProductService.Business.Models;
using Medifii.ProductService.Business.Services.Interfaces;
using Medifii.ProductService.Domain.Repositories;

namespace Medifii.ProductService.Business.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public IEnumerable<Product> GetAll()
        {
            return this.productRepository.GetAll().ToModel();
        }

        public void Add(Product product)
        {
            this.productRepository.Create(product.ToEntity());
        }
    }
}
