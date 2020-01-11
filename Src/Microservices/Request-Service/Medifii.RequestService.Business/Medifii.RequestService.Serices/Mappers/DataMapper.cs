using Medifii.RequestService.Repositories.Models;
using Entities = Medifii.RequestService.Data.Entities;

namespace Medifii.RequestService.Services.Mappers
{
    public static class DataMapper
    {
        public static Request ToModel(this Entities.Request request)
        {
            return new Request
            {
                Id = request.Id,
                PharmacyId = request.PharmacyId,
                ProductName = request.ProductName,
                ResolvedStatus = request.ResolvedStatus,
                UserId = request.UserId
            };
        }
    }
}
