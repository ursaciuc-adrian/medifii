using System;
using System.Linq;
using CSharpFunctionalExtensions;
using Medifii.PharmacyService.Data.Entities;
using Medifii.PharmacyService.Data.RepositoryInterfaces;
using Medifii.PharmacyService.Persistence;

namespace Medifii.PharmacyService.Repositories.Repositories
{
    public class PharmacyRepository : IPharmacyRepository
    {
        private readonly PharmacyContext context;

        public PharmacyRepository(PharmacyContext context)
        {
            this.context = context;
        }

        public Maybe<Pharmacy> GetById(Guid id)
        {
            return context.Pharmacies.SingleOrDefault(x => x.Id == id);
        }

        public void Create(Pharmacy pharmacy)
        {
            context.Add(pharmacy);
        }

        public void Update(Pharmacy pharmacy)
        {
            context.Update(pharmacy);
        }

        public void Delete(Pharmacy pharmacy)
        {
            context.Remove(pharmacy);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
