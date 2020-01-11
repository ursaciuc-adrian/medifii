using System.Collections.Generic;
using MediatR;
using Medifii.ScraperService.Dto;

namespace Medifii.ScraperService.Queries
{
	public class GetProductsByNameQuery : IRequest<IEnumerable<ProductDto>>
	{
		public string Name { get; set; }
	}
}
