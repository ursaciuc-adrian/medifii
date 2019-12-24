using System;
using CSharpFunctionalExtensions;
using Medifii.ProductService.Data.ValueObjects;

namespace Medifii.ProductService.Data.Entities
{
    public class Product
    {
        protected Product(Guid id, Name name, Text description, Price price)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
        }

        protected Product()
        {
        }

        public Guid Id { get; set; }

        public Name Name { get; set; }

        public Text Description { get; set; }

        public Price Price { get; set; }

        public static Result<Product> Create(string name, string description, float price)
        {
            var id = Guid.NewGuid();
            var nameResult = Name.Create(name);
            var descriptionResult = Text.Create(description);
            var priceResult = Price.Create(price);

            return Result.Combine(nameResult, descriptionResult, priceResult)
                .Map(() => new Product(id, nameResult.Value, descriptionResult.Value, priceResult.Value));
        }

        public Result Update(string name, string description, float price)
        {
            var nameResult = Name.Create(name);
            var descriptionResult = Text.Create(description);
            var priceResult = Price.Create(price);

            return Result.Combine(nameResult, descriptionResult, priceResult)
                .Tap(() =>
                {
                    Name = nameResult.Value;
                    Description = descriptionResult.Value;
                    Price = priceResult.Value;
                });
        }
    }
}
