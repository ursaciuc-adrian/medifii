namespace Medifii.ScraperService.Infrastructure
{
	public enum Pharmacy
	{
		Catena
	}

	public class Product
	{
		public string Name { get; set; }
		public string Url { get; set; }
		public string Description { get; set; }
		public Pharmacy Pharmacy { get; set; }
	}
}
