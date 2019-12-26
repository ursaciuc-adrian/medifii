using System;
using CSharpFunctionalExtensions;
using Medifii.PharmacyService.Repositories.Models;

namespace Medifii.PharmacyService.Repositories.ServiceInterfaces
{
    public interface IPharmacyService
    {
        Result<Pharmacy> GetById(Guid id);

        Result Create(Pharmacy pharmacy);

        Result Update(Guid id, Pharmacy pharmacy);

        Result Delete(Guid id);

    }
}
