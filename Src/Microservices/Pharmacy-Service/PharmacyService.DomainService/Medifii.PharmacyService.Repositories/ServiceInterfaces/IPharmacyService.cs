using System;
using System.Collections.Generic;
using CSharpFunctionalExtensions;
using Medifii.PharmacyService.Repositories.Models;

namespace Medifii.PharmacyService.Repositories.ServiceInterfaces
{
    public interface IPharmacyService
    {
        IEnumerable<Pharmacy> GetAll();

        Result<Pharmacy> GetById(Guid id);

        Result Create(Pharmacy pharmacy);

        Result Update(Guid id, Pharmacy pharmacy);

        Result Delete(Guid id);

    }
}
