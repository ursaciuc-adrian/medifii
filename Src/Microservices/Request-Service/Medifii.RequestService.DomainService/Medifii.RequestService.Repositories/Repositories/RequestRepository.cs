using System;
using System.Collections.Generic;
using System.Linq;
using CSharpFunctionalExtensions;
using Medifii.RequestService.Data.Entities;
using Medifii.RequestService.Data.RepositoryInterfaces;
using Medifii.RequestService.Persistence;

namespace Medifii.RequestService.Repositories.Repositories
{
    public class RequestRepository : IRequestRepository
    {
        private readonly RequestContext _requestContext;

        public RequestRepository(RequestContext requestContext)
        {
            _requestContext = requestContext;
        }

        public IEnumerable<Request> GetAll()
        {
            return _requestContext.Requests.ToList();
        }

        public Maybe<Request> GetById(Guid id)
        {
            return _requestContext.Requests.SingleOrDefault(r => r.Id == id);
        }

        public void MakeRequest(Request request)
        {
            _requestContext.Add(request);
        }

        public void ResolveRequest(Request request)
        {
            _requestContext.Update(request);
        }

        public void SaveChanges()
        {
            _requestContext.SaveChanges();
        }
    }
}
