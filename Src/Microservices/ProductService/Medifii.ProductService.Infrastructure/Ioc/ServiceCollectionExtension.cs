using Medifii.ProductService.Domain.Repositories;
using Medifii.ProductService.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Medifii.ProductService.Infrastructure.Ioc
{
    public static class ServiceCollectionExtension
    {
        public static void AddDataAccess(this IServiceCollection service)
        {
            service.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}
