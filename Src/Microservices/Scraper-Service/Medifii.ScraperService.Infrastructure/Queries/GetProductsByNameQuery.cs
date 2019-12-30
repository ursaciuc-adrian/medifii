using MediatR;
using Medifii.ScraperService.Infrastructure.Entities;
using System.Collections.Generic;

namespace Medifii.ScraperService.Infrastructure.Queries
{
	public class GetProductsByNameQuery : IRequest<IEnumerable<Product>>
	{
		public string Name { get; set; }
	}
}
