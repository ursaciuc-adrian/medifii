using System;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace Medifii.ScraperService.Scraper
{
	public class MedifiiScraper<T>
		where T : class
	{
		public T Result { get; private set; }

		private HtmlDocument Document { get; set; }
		public Options Options { get; set; }

		public async Task<MedifiiScraper<T>> Start(Options options)
		{
			await this.Init(options);

			if (this.Document == null)
			{
				throw new InvalidOperationException("Request not initialized");
			}

			this.Result = await this.Parse(this.Document);

			return this;
		}

		protected virtual Task Init(Options options)
		{
			throw new NotImplementedException("Init method not implemented.");
		}

		protected virtual Task<T> Parse(HtmlDocument document)
		{
			throw new NotImplementedException("Parse method not implemented");
		}

		protected async Task Request(Options options)
		{
			this.Options = options;
			
			this.Document = await new HtmlWeb().LoadFromWebAsync(options.Url);
		}
	}
}
