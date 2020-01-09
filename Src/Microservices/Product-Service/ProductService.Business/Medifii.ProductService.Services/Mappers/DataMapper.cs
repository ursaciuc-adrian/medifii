using Medifii.ProductService.Data.Entities;
using Models = Medifii.ProductService.Repositories.Models;

namespace Medifii.ProductService.Services.Mappers
{
    public static class DataMapper
    {
        public static Models.Product ToModel(this Product product)
        {
            return new Models.Product
            {
                Id = product.Id,
                Name = product.Name.Value,
                Description = product.Description.Value,
                Price = product.Price.Value,
                ExpiryDate = product.ExpiryDate,
                Availability = product.Availability,
                Quantity = product.Quantity
            };
        }
    }
}
