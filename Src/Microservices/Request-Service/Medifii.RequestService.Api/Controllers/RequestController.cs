using System;
using System.Net;
using Medifii.RequestService.Api.Mappers;
using Medifii.RequestService.Repositories.Models;
using Medifii.RequestService.Repositories.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace Medifii.RequestService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IRequestService _requestService;

        public RequestController(IRequestService requestService)
        {
            _requestService = requestService;
        }

        [HttpGet("get")]
        public IActionResult GetAll()
        {
            var result = _requestService.GetAll();
            return Ok(result);
        }

        // POST: api/Pharmacy
        [HttpPost("create")]
        public IActionResult CreateRequest([FromBody] Request pharmacy)
        {
            var result = _requestService.MakeRequest(pharmacy);
            return result.AsActionResult(HttpStatusCode.Created);
        }

        // PUT: api/Pharmacy/5
        [HttpPut("resolve/{id}")]
        public IActionResult Put(Guid id)
        {
            var result = _requestService.ResolveRequest(id);
            return result.AsActionResult(HttpStatusCode.NoContent);
        }
    }
}