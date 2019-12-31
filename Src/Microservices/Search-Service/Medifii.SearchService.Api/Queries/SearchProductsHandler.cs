using MediatR;
using Medifii.SearchService.Dto;
using Medifii.SearchService.Interfaces;
using Medifii.SearchService.Queries;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Medifii.SearchService.Api.Queries
{
	public class SearchProductsHandler : IRequestHandler<SearchProductsQuery, IEnumerable<ProductDto>>
	{
		private readonly IScraperClient _scraperClient;

		public SearchProductsHandler(IScraperClient scraperClient)
		{
			_scraperClient = scraperClient;
		}

		public async Task<IEnumerable<ProductDto>> Handle(SearchProductsQuery request, CancellationToken cancellationToken)
		{
			return await _scraperClient.GetProductsAsync(request);
		}
	}
}
