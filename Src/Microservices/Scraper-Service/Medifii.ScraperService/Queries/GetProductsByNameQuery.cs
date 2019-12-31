using MediatR;
using Medifii.ScraperService.Infrastructure.Dto;
using System.Collections.Generic;

namespace Medifii.ScraperService.Infrastructure.Queries
{
	public class GetProductsByNameQuery : IRequest<IEnumerable<ProductDto>>
	{
		public string Name { get; set; }
	}
}
