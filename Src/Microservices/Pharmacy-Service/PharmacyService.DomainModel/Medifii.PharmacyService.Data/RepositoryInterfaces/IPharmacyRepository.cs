using System;
using System.Collections.Generic;
using CSharpFunctionalExtensions;
using Medifii.PharmacyService.Data.Entities;

namespace Medifii.PharmacyService.Data.RepositoryInterfaces
{
    public interface IPharmacyRepository
    {
        IEnumerable<Pharmacy> GetAll();

        Maybe<Pharmacy> GetById(Guid id);

        void Create(Pharmacy pharmacy);

        void Update(Pharmacy pharmacy);

        void Delete(Pharmacy pharmacy);

        void SaveChanges();
    }
}
