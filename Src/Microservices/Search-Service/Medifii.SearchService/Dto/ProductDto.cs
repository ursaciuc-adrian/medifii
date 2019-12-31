using Medifii.SearchService.Enums;

namespace Medifii.SearchService.Dto
{
	public class ProductDto
	{
		public string Name { get; set; }
		public string Url { get; set; }
		public string Description { get; set; }
		public PharmacyType Pharmacy { get; set; }
	}
}
