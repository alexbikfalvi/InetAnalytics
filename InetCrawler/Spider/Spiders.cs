/* 
 * Copyright (C) 2012-2013 Alex Bikfalvi
 *
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 3 of the License, or (at
 * your option) any later version.
 *
 * This program is distributed in the hope that it will be useful, but
 * WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 * General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301, USA.
 */

using System;

namespace InetCrawler.Spider
{
	/// <summary>
	/// The collection of spiders for the YouTube analytics program.
	/// </summary>
	public sealed class Spiders : IDisposable
	{
		private Crawler crawler;

		private SpiderStandardFeeds spiderStandardFeeds;

		/// <summary>
		/// Creates a new spider collection instance.
		/// </summary>
		/// <param name="crawler">The crawler object.</param>
		public Spiders(Crawler crawler)
		{
			this.crawler = crawler;

			// Create the spiders.
			this.spiderStandardFeeds = new SpiderStandardFeeds(this.crawler);
		}

		// Public properties.

		/// <summary>
		/// Gets the spider to browse the standard feeds.
		/// </summary>
		public SpiderStandardFeeds StandardFeeds { get { return this.spiderStandardFeeds; } }

		// Public methods.

		/// <summary>
		/// Disposes the spider collection.
		/// </summary>
		public void Dispose()
		{
			this.spiderStandardFeeds.Dispose();
		}
	}
}
