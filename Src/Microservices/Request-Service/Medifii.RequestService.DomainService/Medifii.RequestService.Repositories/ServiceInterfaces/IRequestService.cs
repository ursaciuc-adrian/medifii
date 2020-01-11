using System;
using System.Collections.Generic;
using CSharpFunctionalExtensions;
using Medifii.RequestService.Repositories.Models;

namespace Medifii.RequestService.Repositories.ServiceInterfaces
{
    public interface IRequestService
    {
        IEnumerable<Request> GetAll();

        Result MakeRequest(Request request);

        Result ResolveRequest(Guid id);
    }
}
