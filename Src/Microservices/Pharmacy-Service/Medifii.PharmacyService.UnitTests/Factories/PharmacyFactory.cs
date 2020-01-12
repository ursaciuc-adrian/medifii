using System.Collections.Generic;
using System.Linq;
using Medifii.PharmacyService.Repositories.Models;
using Entities = Medifii.PharmacyService.Data.Entities;

namespace Medifii.PharmacyService.UnitTests.Factories
{
    public static class PharmacyFactory
    {
        public static Entities.Pharmacy GetPharmacy()
        {
            var pharmacy = Entities.Pharmacy.Create("Catena");
            return pharmacy.Value;
        }

        public static Entities.Pharmacy GetUpdatePharmacy()
        {
            var pharmacy = Entities.Pharmacy.Create("Sensiblu");
            return pharmacy.Value;
        }

        public static IEnumerable<Entities.Pharmacy> GetPharmacies()
        {
            return Enumerable.Repeat(GetPharmacy(), 2);
        }

        public static Pharmacy ToModel(this Entities.Pharmacy pharmacy)
        {
            return new Pharmacy
            {
                Id = pharmacy.Id,
                Name = pharmacy.Name
            };
        }
    }
}
