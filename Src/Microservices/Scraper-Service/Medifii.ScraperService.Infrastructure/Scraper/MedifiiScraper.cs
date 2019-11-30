using HtmlAgilityPack;
using System;
using System.Threading.Tasks;

namespace Medifii.ScraperService.Infrastructure.Scraper
{
	public class MedifiiScraper<T>
		where T : class
	{
		public string Url { get; private set; }
		public string BaseUrl => new Uri(Url).GetLeftPart(UriPartial.Authority);
		public T Result { get; private set; }

		private Response Response { get; set; }

		public async Task<MedifiiScraper<T>> Start()
		{
			await this.Init();

			if(this.Response == null)
			{
				throw new InvalidOperationException("Request not initialized");
			}

			this.Result = await this.Parse(this.Response);

			return this;
		}

		public virtual Task Init()
		{
			throw new NotImplementedException("Init method not implementd");
		}

		public virtual Task<T> Parse(Response response)
		{
			throw new NotImplementedException("Parse method not implementd");
		}

		protected async Task Request(string url)
		{
			this.Url = url;

			this.Response = new Response
			{
				Document = await new HtmlWeb().LoadFromWebAsync(url)
			};
		}
	}
}
