using System.Net;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;

namespace Medifii.RequestService.Api.Mappers
{
    public static class ResultExtension
    {
        public static IActionResult AsActionResult(this Result result, HttpStatusCode statusCodeResponse)
        {
            if (result.IsSuccess)
            {
                return new StatusCodeResult((int)statusCodeResponse);
            }

            if (result.Error.Equals("Request not found"))
            {
                return new StatusCodeResult((int)HttpStatusCode.NotFound);
            }

            return new BadRequestObjectResult(result.Error);
        }
    }
}
