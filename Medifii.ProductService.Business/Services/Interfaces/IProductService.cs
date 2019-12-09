using System;
using System.Collections.Generic;
using System.Text;
using Medifii.ProductService.Business.Models;

namespace Medifii.ProductService.Business.Services.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Product> GetAll();
    }
}
