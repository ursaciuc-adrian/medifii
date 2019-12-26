﻿using System;
using System.Net;
using Medifii.ProductService.Mappers;
using Medifii.ProductService.Repositories.Models;
using Medifii.ProductService.Repositories.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace Medifii.ProductService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        // GET: api/Product/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(Guid id)
        {
            var product = productService.GetById(id);
            return product.AsActionResult(NotFound);
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