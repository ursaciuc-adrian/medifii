using System;
using System.Collections.Generic;
using CSharpFunctionalExtensions;
using Medifii.ProductService.Data.Entities;

namespace Medifii.ProductService.Data.RepositoryInterfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();

        Maybe<Product> GetById(Guid id);

        void Create(Product product);

        void Update(Product product);

        void Delete(Product product);

        void SaveChanges();
    }
}
