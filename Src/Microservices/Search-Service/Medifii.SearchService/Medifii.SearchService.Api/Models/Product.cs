namespace Medifii.SearchService.Api.Models
{
	public enum Pharmacy
	{
		Catena,
		Tei
	}

	public class Product
	{
		public string Name { get; set; }
		public string Url { get; set; }
		public string Description { get; set; }
		public Pharmacy Pharmacy { get; set; }
	}
}
