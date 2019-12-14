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

        public HtmlDocument Document { get; set; }

        public async Task<MedifiiScraper<T>> Start()
		{
			await this.Init();

			if(this.Document == null)
			{
				throw new InvalidOperationException("Request not initialized");
			}

			this.Result = await this.Parse(this.Document);

			return this;
		}

		public virtual Task Init()
		{
			throw new NotImplementedException("Init method not implemented.");
		}

		public virtual Task<T> Parse(HtmlDocument document)
		{
			throw new NotImplementedException("Parse method not implemented");
		}

		protected async Task Request(string url)
		{
			this.Url = url;

            this.Document = await new HtmlWeb().LoadFromWebAsync(url);
        }
	}
}
