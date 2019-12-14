using Medifii.ProductService.Business.Models;
using Medifii.ProductService.Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Medifii.ProductService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(this.productService.GetAll());
        }

        [HttpPost]
        public void AddProduct([FromBody] Product product)
        {
            productService.Add(product);
        }
    }
}
