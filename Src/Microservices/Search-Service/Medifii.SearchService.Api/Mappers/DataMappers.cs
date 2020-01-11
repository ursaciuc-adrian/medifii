using System.Collections.Generic;
using System.Linq;
using Medifii.SearchService.Dto;

namespace Medifii.SearchService.Api.Mappers
{
    public static class DataMappers
    {
        public static ProductDto ToProductDto(this DbProductDto dbProduct)
        {
            return new ProductDto
            {
                Name = dbProduct.Name,
                Description = dbProduct.Description
            };
        }

        public static IEnumerable<ProductDto> ToProductDto(this IEnumerable<DbProductDto> dbProducts)
        {
            return dbProducts.Select(prod => prod.ToProductDto());
        }
    }
}
