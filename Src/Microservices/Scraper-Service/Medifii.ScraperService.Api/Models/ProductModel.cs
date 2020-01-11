using Medifii.ScraperService.Api.Models.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Medifii.ScraperService.Api.Models
{
	public class ProductModel
	{
		public string Name { get; set; }

		public string Url { get; set; }

		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string Description { get; set; }

		[JsonConverter(typeof(StringEnumConverter))]
		public Pharmacy Pharmacy { get; set; }
	}
}