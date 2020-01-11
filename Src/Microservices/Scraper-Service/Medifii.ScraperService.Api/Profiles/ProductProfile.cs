using AutoMapper;
using Medifii.ScraperService.Api.Models;
using Medifii.ScraperService.Dto;

namespace Medifii.ScraperService.Api.Profiles
{
	public class ProductProfile : Profile
	{
		public ProductProfile()
		{
			CreateMap<ProductDto, ProductModel>();
		}
	}
}
