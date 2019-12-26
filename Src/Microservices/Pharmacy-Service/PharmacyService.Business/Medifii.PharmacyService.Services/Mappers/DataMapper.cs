using Medifii.PharmacyService.Data.Entities;
using Models = Medifii.PharmacyService.Repositories.Models;

namespace Medifii.PharmacyService.Services.Mappers
{
    public static class DataMapper
    {
        public static Models.Pharmacy ToModel(this Pharmacy pharmacy)
        {
            return new Models.Pharmacy
            {
                Id = pharmacy.Id,
                Name = pharmacy.Name
            };
        }
    }
}
