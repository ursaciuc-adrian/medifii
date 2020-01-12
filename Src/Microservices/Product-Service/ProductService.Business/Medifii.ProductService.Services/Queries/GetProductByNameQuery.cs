using System.Collections.Generic;
using MediatR;
using Medifii.ProductService.Repositories.Models;

namespace Medifii.ProductService.Services.Queries
{
    public class GetProductByNameQuery : IRequest<IEnumerable<Product>>
    {
        public string Name { get; set; }
    }
}
