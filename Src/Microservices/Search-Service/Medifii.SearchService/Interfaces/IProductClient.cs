using System.Collections.Generic;
using System.Threading.Tasks;
using Medifii.ScraperService.Infrastructure.Queries;
using Medifii.SearchService.Dto;
using RestEase;

namespace Medifii.SearchService.Interfaces
{
    public interface IProductClient
    {
        [Post]
        Task<List<DbProductDto>> GetProducts([Body] GetProductsByNameQuery query);
    }
}
