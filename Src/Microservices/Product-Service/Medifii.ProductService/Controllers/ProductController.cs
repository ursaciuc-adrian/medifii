using System;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Medifii.ProductService.Mappers;
using Medifii.ProductService.Repositories.Models;
using Medifii.ProductService.Repositories.Queries;
using Medifii.ProductService.Repositories.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace Medifii.ProductService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        private readonly IMediator mediator;

        public ProductController(IProductService productService, IMediator mediator)
        {
            this.productService = productService;
            this.mediator = mediator;
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetProductsByName([FromRoute] string name)
        {

            var query = new GetProductByNameQuery
            {
                Name = name
            };

            var products = await mediator.Send(query);

            return new JsonResult(products);
        }

        // GET
        [HttpGet]
        public IActionResult GetAll()
        {
            var products = productService.GetAll();
            return Ok(products);
        }

        // POST: api/Product
        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            var result = productService.Create(product);
            return result.AsActionResult(HttpStatusCode.Created);
        }

        // PUT: api/Product/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Product product)
        {
            var result = productService.Update(id, product);
            return result.AsActionResult(HttpStatusCode.NoContent);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var result = productService.Delete(id);
            return result.AsActionResult(HttpStatusCode.NoContent);
        }
    }
}
