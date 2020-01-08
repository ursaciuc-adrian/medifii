using System;
using CSharpFunctionalExtensions;
using Medifii.ProductService.Data.ValueObjects;

namespace Medifii.ProductService.Data.Entities
{
    public class Product
    {
        protected Product(
            Guid id, 
            Name name, 
            Text description, 
            Price price,
            int quantity,
            DateTime expiryDate,
            bool availability)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            Quantity = quantity;
            ExpiryDate = expiryDate;
            Availability = availability;
        }

        protected Product()
        {
        }

        public Guid Id { get; private set; }

        public Name Name { get; private set; }

        public Text Description { get; private set; }

        public Price Price { get; private set; }

        public int Quantity { get; set; }

        public DateTime ExpiryDate { get; set; }

        public bool Availability { get; set; }

        public static Result<Product> Create(
            string name, 
            string description, 
            float price, 
            int quantity, 
            DateTime expiryDate,
            bool availability)
        {
            var id = Guid.NewGuid();
            var nameResult = Name.Create(name);
            var descriptionResult = Text.Create(description);
            var priceResult = Price.Create(price);


            return Result.Combine(nameResult, descriptionResult, priceResult)
                .Map(() => new Product(id, nameResult.Value, descriptionResult.Value, priceResult.Value, quantity, expiryDate, availability));
        }

        public Result Update(
            string name, 
            string description, 
            float price,
            int quantity,
            DateTime expiryDate,
            bool availability)
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
                    Quantity = quantity;
                    ExpiryDate = expiryDate;
                    Availability = availability;
                });
        }
    }
}
