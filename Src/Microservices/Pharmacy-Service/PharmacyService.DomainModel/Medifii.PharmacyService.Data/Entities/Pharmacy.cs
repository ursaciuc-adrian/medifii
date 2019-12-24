using System;
using System.Collections.Generic;
using Medifii.PharmacyService.Data.ValueObjects;

namespace Medifii.PharmacyService.Data.Entities
{
    public class Pharmacy
    {
        public Guid Id { get; set; }

        public Name Name { get; set; }

        public List<PharmacyProducts> Products { get; set; }
    }
}
