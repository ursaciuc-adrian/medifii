using MediatR;
using Medifii.SearchService.Dto;
using Medifii.SearchService.Interfaces;
using Medifii.SearchService.Queries;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Medifii.SearchService.Api.Mappers;

namespace Medifii.SearchService.Api.Queries
{
	public class SearchProductsHandler : IRequestHandler<SearchProductsQuery, IEnumerable<ProductDto>>
	{
		private readonly IScraperClient _scraperClient;
        private readonly IProductClient _productClient;

		public SearchProductsHandler(IScraperClient scraperClient, IProductClient productClient)
		{
			_scraperClient = scraperClient;
            _productClient = productClient;
        }

		public async Task<IEnumerable<ProductDto>> Handle(SearchProductsQuery request, CancellationToken cancellationToken)
        {
            var dbProducts = await _productClient.GetProducts(request.Name);
			var scraperProducts =  await _scraperClient.GetProductsAsync(request.Name);
            var dbProductsDto = dbProducts.ToProductDto();
            var allProducts = dbProductsDto.ToList();
            allProducts.AddRange(scraperProducts);
            return allProducts;
        }
	}
}
