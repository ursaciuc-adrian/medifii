using Medifii.ProductService.Business.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Medifii.ProductService.Business.Ioc
{
    public static class ServiceCollectionExtension
    {
        public static void AddCore(this IServiceCollection service)
        {
            service.AddScoped<IProductService, Services.ProductService>();
        }
    }
}
