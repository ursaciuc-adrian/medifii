using Medifii.ProductService.Business.Models;
using Medifii.ProductService.Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Medifii.ProductService.Controllers
{
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public IEnumerable<Product> GetAll()
        {
            return this.productService.GetAll();
        }

    }
}
