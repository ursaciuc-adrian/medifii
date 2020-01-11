using System;
using System.Collections.Generic;
using CSharpFunctionalExtensions;
using Medifii.ProductService.Repositories.Models;

namespace Medifii.ProductService.Repositories.ServiceInterfaces
{
    public interface IProductService
    {
        IEnumerable<Product> GetAll();

        IEnumerable<Product> GetProductsByName(string name);

        Result<Product> GetById(Guid id);

        Result Create(Product product);

        Result Update(Guid id, Product product);

        Result Delete(Guid id);
    }
}
