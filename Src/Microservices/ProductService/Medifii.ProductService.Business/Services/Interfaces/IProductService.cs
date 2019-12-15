using System.Collections.Generic;
using Medifii.ProductService.Business.Models;

namespace Medifii.ProductService.Business.Services.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Product> GetAll();

        void Add(Product product);
    }
}
