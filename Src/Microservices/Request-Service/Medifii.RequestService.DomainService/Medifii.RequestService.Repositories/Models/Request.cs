using System;

namespace Medifii.RequestService.Repositories.Models
{
    public class Request
    {
        public Guid Id { get; set; }

        public Guid PharmacyId { get; set; }

        public string ProductName { get; set; }

        public bool ResolvedStatus { get; set; }

        public int Quantity { get; set; }
    }
}
