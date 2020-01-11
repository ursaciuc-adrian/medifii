using System;
using CSharpFunctionalExtensions;
using Medifii.RequestService.Repositories.Models;

namespace Medifii.RequestService.Repositories.ServiceInterfaces
{
    public interface IRequestService
    {
        Result MakeRequest(Request request);

        Result ResolveRequest(Guid id);
    }
}
