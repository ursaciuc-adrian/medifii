using System.Collections.Generic;
using CSharpFunctionalExtensions;

namespace Medifii.ProductService.Data.ValueObjects
{
    public class Text : ValueObject
    {
        private Text()
        {

        }

        private Text(string value)
        {
            Value = value;
        }

        public string Value { get; private set; }

        public static implicit operator string(Text text)
        {
            return text.Value;
        }

        public static Result<Text> Create(string text)
        {
            return Maybe<string>.From(text)
                .ToResult("Text is empty")
                .Ensure(text => !string.IsNullOrEmpty(text), "Text is empty")
                .Map(text => new Text(text.Trim()));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
