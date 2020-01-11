using System;
using System.Collections.Generic;
using System.Linq;
using CSharpFunctionalExtensions;
using Entities = Medifii.PharmacyService.Data.Entities;
using Medifii.PharmacyService.Data.RepositoryInterfaces;
using Medifii.PharmacyService.Repositories.Models;
using Medifii.PharmacyService.Repositories.ServiceInterfaces;
using Medifii.PharmacyService.Services.Mappers;

namespace Medifii.PharmacyService.Services.Services
{
    public class PharmacyService : IPharmacyService
    {
        private readonly IPharmacyRepository pharmacyRepository;

        public PharmacyService(IPharmacyRepository pharmacyRepository)
        {
            this.pharmacyRepository = pharmacyRepository;
        }

        public IEnumerable<Pharmacy> GetAll()
        {
            return pharmacyRepository.GetAll().Select(ph => ph.ToModel());
        }

        public Result<Pharmacy> GetById(Guid id)
        {
            return pharmacyRepository
                .GetById(id)
                .ToResult("Pharmacy not found")
                .Map(pharmacy => pharmacy.ToModel());
        }

        public Result Create(Pharmacy pharmacy)
        {
            return Result
                .Combine()
                .Tap(() => CreatePharmacy(pharmacy));
        }

        public Result Update(Guid id, Pharmacy pharmacyModel)
        {
            var pharmacy = pharmacyRepository.GetById(id).ToResult("Pharmacy not found");
            return Result.Combine(pharmacy)
                .Tap(() => UpdatePharmacy(pharmacyModel, pharmacy.Value))
                .Tap(() => pharmacyRepository.Update(pharmacy.Value))
                .Tap(() => pharmacyRepository.SaveChanges());
        }

        public Result Delete(Guid id)
        {
            return pharmacyRepository
                .GetById(id)
                .ToResult("Pharmacy not found")
                .Tap(pharmacy => pharmacyRepository.Delete(pharmacy))
                .Tap(() => pharmacyRepository.SaveChanges());
        }

        private Result<Entities.Pharmacy> CreatePharmacy(Pharmacy pharmacy)
        {
            return Entities.Pharmacy.Create(pharmacy.Name)
                .Tap(pharmacyModel => pharmacyRepository.Create(pharmacyModel))
                .Tap(_ => pharmacyRepository.SaveChanges());
        }

        private Result<Entities.Pharmacy> UpdatePharmacy(Pharmacy pharmacyModel, Entities.Pharmacy pharmacy)
        {
            return pharmacy.Update(pharmacyModel.Name).Map(() => pharmacy);
        }
    }
}
