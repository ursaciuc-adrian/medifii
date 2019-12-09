using System;
using System.ComponentModel.DataAnnotations;

namespace Medifii.ProductService.Infrastructure.Entities
{
    public class Product
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
    }
}
