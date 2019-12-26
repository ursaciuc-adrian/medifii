using System;
using System.Net;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;

namespace Medifii.PharmacyService.Mappers
{
    public static class ResultExtension
    {
        public static IActionResult AsActionResult(this Result result, HttpStatusCode statusCodeResponse)
        {
            if (result.IsSuccess)
            {
                return new StatusCodeResult((int)statusCodeResponse);
            }

            if (result.Error.Equals("Pharmacy not found"))
            {
                return new StatusCodeResult((int)HttpStatusCode.NotFound);
            }

            return new BadRequestObjectResult(result.Error);
        }

        public static IActionResult AsActionResult<T>(this Result<T> result, Func<T, IActionResult> func)
        {
            if (result.IsSuccess)
            {
                return new OkObjectResult(result.Value);
            }

            if (result.Error.Equals("Pharmacy not found"))
            {
                return new StatusCodeResult((int)HttpStatusCode.NotFound);
            }

            return func(result.Value);
        }
    }
}
