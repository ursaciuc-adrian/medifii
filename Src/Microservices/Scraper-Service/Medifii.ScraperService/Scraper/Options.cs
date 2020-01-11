﻿using System;

namespace Medifii.ScraperService.Scraper
{
	public class Options
	{
		public string Url { get; set; }
		public string BaseUrl => new Uri(Url).GetLeftPart(UriPartial.Authority);
	}
}
