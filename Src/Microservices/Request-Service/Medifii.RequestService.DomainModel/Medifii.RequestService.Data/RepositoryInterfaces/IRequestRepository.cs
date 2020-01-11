using System;
using System.Collections.Generic;
using CSharpFunctionalExtensions;
using Medifii.RequestService.Data.Entities;

namespace Medifii.RequestService.Data.RepositoryInterfaces
{
    public interface IRequestRepository
    {
        IEnumerable<Request> GetAll();

        Maybe<Request> GetById(Guid id);

        void MakeRequest(Request request);

        void ResolveRequest(Request request);

        void SaveChanges();
    }
}
