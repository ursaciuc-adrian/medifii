using AutoMapper;
using Medifii.ScraperService.Infrastructure.Dto;
using Medifii.ScraperService.Models;

namespace Medifii.ScraperService.Profiles
{
	public class ProductProfile : Profile
	{
		public ProductProfile()
		{
			CreateMap<ProductDto, ProductModel>();
		}
	}
}
