using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medifii.ProductService.Repositories.Models;
using Entities = Medifii.ProductService.Data.Entities;

namespace Medifii.ProductService.ServiceTests.Factories
{
    public static class ProductFactory
    {
        private static Guid id;
        public static Entities.Product GetProduct()
        {
            var product = Entities.Product.Create(
                "Aspirina",
                "Medicament",
                3,
                10,
                new DateTime(2020, 01, 01),
                true);
            id = product.Value.Id;

            return product.Value;
        }

        public static Entities.Product GetUpdatedProduct()
        {
            var product = Entities.Product.Create(
                "Aspirina updated",
                "Medicament updated",
                5,
                12,
                new DateTime(2021, 01, 01),
                true);
            id = product.Value.Id;

            return product.Value;
        }

        public static List<Entities.Product> GetProducts()
        {
            return Enumerable.Repeat(GetProduct(), 2).ToList();
        }

        public static Product ToModel(this Entities.Product product)
        {
            return new Product
            {
                Id = product.Id,
                Name = product.Name,
                Quantity = product.Quantity,
                ExpiryDate = product.ExpiryDate,
                Description = product.Description,
                Availability = product.Availability,
                Price = product.Price
            };
        }
    }
}
