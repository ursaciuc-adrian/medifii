using System;
using CSharpFunctionalExtensions;
using Medifii.PharmacyService.Data.ValueObjects;

namespace Medifii.PharmacyService.Data.Entities
{
    public class Pharmacy
    {
        protected Pharmacy(Guid id, Name name)
        {
            Id = id;
            Name = name;
        }

        protected Pharmacy() { }

        public Guid Id { get; private set; }

        public Name Name { get; private set; }

        public static Result<Pharmacy> Create(string name)
        {
            var id = Guid.NewGuid();
            var nameResult = Name.Create(name);

            return Result.Combine(nameResult).Map(() => new Pharmacy(id, nameResult.Value));
        }

        public Result Update(string name)
        {
            var nameResult = Name.Create(name);

            return Result.Combine(nameResult).Tap(() => { Name = nameResult.Value; });
        }
    }
}
