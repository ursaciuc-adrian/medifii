using System.Collections.Generic;
using CSharpFunctionalExtensions;

namespace Medifii.PharmacyService.Data.ValueObjects
{
    public class Name : ValueObject
    {
        private Name(string value)
        {
            Value = value;
        }

        public string Value { get; private set; }

        public static implicit operator string(Name name)
        {
            return name.Value;
        }

        public static Result<Name> Create(string name)
        {
            return Maybe<string>.From(name)
                .ToResult("Name is empty")
                .Ensure(name => !string.IsNullOrEmpty(name), "Name is empty")
                .Map(name => new Name(name.Trim()));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
