using System.Collections.Generic;
using System.Threading.Tasks;
using Medifii.SearchService.Dto;
using RestEase;

namespace Medifii.SearchService.Interfaces
{
    public interface IProductClient
    {
        [Get("/api/product/{name}")]
        Task<List<DbProductDto>> GetProducts([Path] string name);
    }
}
