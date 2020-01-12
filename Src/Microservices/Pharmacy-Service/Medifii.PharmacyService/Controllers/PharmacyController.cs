using System;
using System.Net;
using Medifii.PharmacyService.Mappers;
using Medifii.PharmacyService.Repositories.Models;
using Medifii.PharmacyService.Repositories.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace Medifii.PharmacyService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmacyController : ControllerBase
    {
        private readonly IPharmacyService pharmacyService;

        public PharmacyController(IPharmacyService pharmacyService)
        {
            this.pharmacyService = pharmacyService;
        }

        [HttpGet("get")]
        public IActionResult GetAll()
        {
            var result = pharmacyService.GetAll();
            return Ok(result);
        }

        // GET: api/Pharmacy/5
        [HttpGet("get/{id}", Name = "Get")]
        public IActionResult GetById(Guid id)
        {
            var result = pharmacyService.GetById(id);
            return result.AsActionResult(NotFound);
        }

        // POST: api/Pharmacy
        [HttpPost("create")]
        public IActionResult Post([FromBody] Pharmacy pharmacy)
        {
            var result = pharmacyService.Create(pharmacy);
            return result.AsActionResult(HttpStatusCode.Created);
        }

        // PUT: api/Pharmacy/5
        [HttpPut("update/{id}")]
        public IActionResult Put(Guid id, [FromBody] Pharmacy pharmacy)
        {
            var result = pharmacyService.Update(id, pharmacy);
            return result.AsActionResult(HttpStatusCode.NoContent);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(Guid id)
        {
            var result = pharmacyService.Delete(id);
            return result.AsActionResult(HttpStatusCode.NoContent);
        }
    }
}
