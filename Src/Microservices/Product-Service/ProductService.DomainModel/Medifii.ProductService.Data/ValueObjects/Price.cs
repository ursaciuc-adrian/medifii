using System.Collections.Generic;
using CSharpFunctionalExtensions;

namespace Medifii.ProductService.Data.ValueObjects
{
    public class Price : ValueObject
    {
        private Price()
        {
        }

        private Price(float price)
        {
            Value = price;
        }

        public float Value { get; private set; }

        public static implicit operator float(Price price)
        {
            return price.Value;
        }

        public static Result<Price> Create(float price)
        {
            return Maybe<float>.From(price)
                .ToResult("Price is negative")
                .Ensure(price => price > 0, "Price is negative")
                .Map(price => new Price(price));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
