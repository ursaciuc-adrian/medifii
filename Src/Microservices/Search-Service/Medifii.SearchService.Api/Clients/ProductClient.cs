using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Medifii.SearchService.Dto;
using Medifii.SearchService.Interfaces;
using Microsoft.Extensions.Configuration;
using RestEase;

namespace Medifii.SearchService.Api.Clients
{
    public class ProductClient : IProductClient
    {
        private readonly IProductClient _productClient;

        public ProductClient(IConfiguration configuration)
        {
            var httpClient = new HttpClient()
            {
                BaseAddress = new Uri(configuration.GetValue<string>("ProductService"))
            };

            _productClient = RestClient.For<IProductClient>(httpClient);
        }

        public async Task<List<DbProductDto>> GetProducts(string query)
        {
            return await _productClient.GetProducts(query);
        }
    }
}
