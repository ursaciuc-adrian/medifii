using MediatR;
using Medifii.ScraperService.Infrastructure.Dto;
using Medifii.ScraperService.Infrastructure.Interfaces;
using Medifii.ScraperService.Infrastructure.Queries;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Medifii.ScraperService.Api.Queries
{
	public class GetProductsByNameHandler : IRequestHandler<GetProductsByNameQuery, IEnumerable<ProductDto>>
	{
		private readonly IEnumerable<IScraperService> _scraperServices;

		public GetProductsByNameHandler(IEnumerable<IScraperService> scraperServices)
		{
			_scraperServices = scraperServices;
		}

		public async Task<IEnumerable<ProductDto>> Handle(GetProductsByNameQuery request, CancellationToken cancellationToken)
		{
			var products = new List<ProductDto>();

			foreach (var scraper in _scraperServices)
			{
				products.AddRange(await scraper.GetProducts(request.Name));
			}

			return products.AsEnumerable();
		}
	}
}
