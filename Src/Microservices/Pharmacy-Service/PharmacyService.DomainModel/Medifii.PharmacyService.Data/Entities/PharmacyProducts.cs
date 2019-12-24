using System;

namespace Medifii.PharmacyService.Data.Entities
{
    public class PharmacyProducts
    {
        public Guid Id { get; set; }

        public Guid PharmacyId { get; set; }

        public Pharmacy Pharmacy { get; set; }

        public Guid ProductId { get; set; }
    }
}
