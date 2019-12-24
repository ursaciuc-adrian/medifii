using System;
using CSharpFunctionalExtensions;
using Medifii.ProductService.Repositories.Models;

namespace Medifii.ProductService.Repositories.ServiceInterfaces
{
    public interface IProductService
    {
        Result<Product> GetById(Guid id);

        Result Create(Product product);

        Result Update(Guid id, Product product);

        Result Delete(Guid id);
    }
}
