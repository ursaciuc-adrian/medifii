using System.Collections.Generic;
using System.Linq;
using Medifii.ProductService.Domain.Entities;
using Models = Medifii.ProductService.Business.Models;

namespace Medifii.ProductService.Business.Mappers
{
    public static class DataMappers
    {
        public static Models.Product ToModel(this Product product)
        {
            return new Models.Product
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price
            };
        }

        public static IEnumerable<Models.Product> ToModel(this IEnumerable<Product> products)
        {
            return products.Select(x => x.ToModel());
        }

        public static Product ToEntity(this Models.Product product)
        {
            return new Product
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price
            };
        }
    }
}
