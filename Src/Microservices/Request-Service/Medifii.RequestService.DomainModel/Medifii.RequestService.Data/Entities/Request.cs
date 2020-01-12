using System;
using CSharpFunctionalExtensions;
using Medifii.RequestService.Data.ValueObjects;

namespace Medifii.RequestService.Data.Entities
{
    public class Request
    {
        public Request(
            Guid id, 
            Guid pharmacyId, 
            Name productName,
            Guid userId,
            bool resolvedStatus,
            int quantity)
        {
            Id = id;
            PharmacyId = pharmacyId;
            ProductName = productName;
            UserId = userId;
            ResolvedStatus = resolvedStatus;
            Quantity = quantity;
        }

        protected Request() { }

        public Guid Id { get; set; }

        public Guid PharmacyId { get; set; }

        public Name ProductName { get; set; }

        public Guid UserId { get; set; }

        public bool ResolvedStatus { get; set; }

        public int Quantity { get; set; }

        public static Result<Request> Create(
            Guid pharmacyId, 
            string productName, 
            Guid userId,
            int quantity)
        {
            var id = Guid.NewGuid();
            var productNameResult = Name.Create(productName);

            return Result.Combine(productNameResult).Map(() => 
                new Request(id, pharmacyId, productNameResult.Value, userId, false, quantity));
        }

        public Result Update(Guid pharmacyId, string productName, bool resolvedStatus, int quantity)
        {
            var nameResult = Name.Create(productName);

            return Result.Combine(nameResult).Tap(() =>
            {
                ProductName = nameResult.Value;
                PharmacyId = pharmacyId;
                ResolvedStatus = resolvedStatus;
                Quantity = quantity;
            });
        }

        public Result Resolve()
        {
            return Result.Combine().Tap(() =>
            {
                ResolvedStatus = true;
            });
        }
    }
}
