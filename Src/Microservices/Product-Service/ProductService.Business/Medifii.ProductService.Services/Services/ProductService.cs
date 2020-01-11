using System;
using System.Collections.Generic;
using System.Linq;
using CSharpFunctionalExtensions;
using Entities = Medifii.ProductService.Data.Entities;
using Medifii.ProductService.Data.RepositoryInterfaces;
using Medifii.ProductService.Repositories.Models;
using Medifii.ProductService.Repositories.ServiceInterfaces;
using Medifii.ProductService.Services.Mappers;

namespace Medifii.ProductService.Services.Services
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
            return productRepository.GetAll().Select(x => x.ToModel());
        }

        public IEnumerable<Product> GetProductsByName(string name)
        {
            return productRepository.GetAll().Where(prod => prod.Name.Value.Trim().ToLower().Equals(name.Trim().ToLower())).Select(prod => prod.ToModel());
        }

        public Result<Product> GetById(Guid id)
        {
            return productRepository
                .GetById(id)
                .ToResult("Product not found")
                .Map(product => product.ToModel());
        }

        public Result Create(Product product)
        {
            return Result
                .Combine()
                .Tap(() => CreateProduct(product));
        }

        public Result Update(Guid id, Product productModel)
        {
            var product = productRepository.GetById(id).ToResult("Product not found");

            return Result
                .Combine(product)
                .Tap(() => UpdateProduct(productModel, product.Value))
                .Tap(() => productRepository.Update(product.Value))
                .Tap(() => productRepository.SaveChanges());
        }

        public Result Delete(Guid id)
        {
            return productRepository
                .GetById(id)
                .ToResult("Product not found")
                .Tap(product => productRepository.Delete(product))
                .Tap(() => productRepository.SaveChanges());
        }

        private Result<Entities.Product> CreateProduct(Product product)
        {
            return Entities.Product.Create(product.Name, 
                                            product.Description, 
                                            product.Price, 
                                            product.Quantity, 
                                            product.ExpiryDate, 
                                            product.Availability)
                .Tap(productModel => productRepository.Create(productModel))
                .Tap(_ => productRepository.SaveChanges());
        }

        private static Result<Entities.Product> UpdateProduct(Product productModel, Entities.Product product)
        {
            return product.Update(productModel.Name, 
                                    productModel.Description, 
                                    productModel.Price,
                                    productModel.Quantity,
                                    productModel.ExpiryDate,
                                    productModel.Availability)
                .Map(() => product);
        }
    }
}
