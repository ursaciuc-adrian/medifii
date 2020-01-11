using System;
using System.Collections.Generic;
using System.Linq;
using CSharpFunctionalExtensions;
using Entities = Medifii.RequestService.Data.Entities;
using Medifii.RequestService.Data.RepositoryInterfaces;
using Medifii.RequestService.Repositories.Models;
using Medifii.RequestService.Repositories.ServiceInterfaces;
using Medifii.RequestService.Services.Mappers;

namespace Medifii.RequestService.Services.Services
{
    public class RequestService : IRequestService
    {
        private readonly IRequestRepository _requestRepository;

        public RequestService(IRequestRepository requestRepository)
        {
            _requestRepository = requestRepository;
        }

        public IEnumerable<Request> GetAll()
        {
            return _requestRepository.GetAll().Select(r => r.ToModel());
        }

        public Result MakeRequest(Request request)
        {
            return Result.Combine()
                .Tap(() => CreateRequest(request));
        }

        public Result ResolveRequest(Guid id)
        {
            var request = _requestRepository.GetById(id).ToResult("Request not found");
            return Result.Combine(request)
                .Tap(() => UpdatePharmacy(request.Value))
                .Tap(() => _requestRepository.ResolveRequest(request.Value))
                .Tap(() => _requestRepository.SaveChanges());
        }

        private Result<Entities.Request> CreateRequest(Request request)
        {
            return Entities.Request.Create(request.PharmacyId, request.ProductName, request.UserId)
                .Tap(requestModel => _requestRepository.MakeRequest(requestModel))
                .Tap(_ => _requestRepository.SaveChanges());
        }

        private Result<Entities.Request> UpdatePharmacy(Entities.Request request)
        {
            return request.Resolve().Map(() => request);
        }
    }
}
