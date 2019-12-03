using Medifii.ScraperService.Infrastructure.Enums;

namespace Medifii.ScraperService.Infrastructure.Entities
{
    public class Product
	{
		public string Name { get; set; }
		public string Url { get; set; }
		public string Description { get; set; }
		public Pharmacy Pharmacy { get; set; }
	}
}
