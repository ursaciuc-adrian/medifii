using MediatR;
using Medifii.SearchService.Dto;
using System.Collections.Generic;

namespace Medifii.SearchService.Queries
{
	public class SearchProductsQuery : IRequest<IEnumerable<ProductDto>>, IRequest<IEnumerable<DbProductDto>>
	{
		public string Name { get; set; }
	}
}
