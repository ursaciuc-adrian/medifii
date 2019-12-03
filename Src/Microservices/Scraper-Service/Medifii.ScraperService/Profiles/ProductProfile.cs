using AutoMapper;

using Medifii.ScraperService.Infrastructure;
using Medifii.ScraperService.Infrastructure.Entities;
using Medifii.ScraperService.Models;

namespace Medifii.ScraperService.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductModel>();
        }
    }
}
