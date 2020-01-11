using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Medifii.ProductService.Repositories.Models;
using Medifii.ProductService.Repositories.Queries;
using Medifii.ProductService.Repositories.ServiceInterfaces;

namespace Medifii.ProductService.Queries
{
    public class ProductHandler : IRequestHandler<GetProductByNameQuery, IEnumerable<Product>>
    {
        public ProductHandler(IProductService productServices)
        {
            this.productServices = productServices;
        }

        private readonly IProductService productServices;

        public async Task<IEnumerable<Product>> Handle(GetProductByNameQuery request, CancellationToken cancellationToken)
        {
            var products = productServices.GetProductsByName(request.Name);
            return products;
        }
    }
}
