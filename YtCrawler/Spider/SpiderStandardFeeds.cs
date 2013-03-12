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
using YtCrawler.Database;
using YtCrawler.Spider.Data;
using DotNetApi.Async;

namespace YtCrawler.Spider
{
	/// <summary>
	/// A spider browsing through the YouTube API version 2 standard video feeds.
	/// </summary>
	public class SpiderStandardFeeds : Spider 
	{
		private Crawler crawler;

		private TypeStandardFeed[] standardFeeds = null;

		/// <summary>
		/// Creates a new spider instance.
		/// </summary>
		/// <param name="crawler">The crawler object.</param>
		public SpiderStandardFeeds(Crawler crawler)
		{
			this.crawler = crawler;
		}

		// Public properties.

		/// <summary>
		/// Gets the standard feeds.
		/// </summary>
		public TypeStandardFeed[] StandardFeeds { get { return this.standardFeeds; } }

		// Public methods.

		/// <summary>
		/// Begins an asynchronous spider crawling using the specified user state.
		/// </summary>
		/// <param name="callback"></param>
		/// <param name="state">The user state.</param>
		/// <returns>The result of the asynchronous operation.</returns>
		public IAsyncResult Crawl(SpiderCallback callback, object state = null)
		{
			// Update the spider state.
			this.OnStart();

			// Create a new spider asynchronous state.
			
			
			// Returns the spider object as the asynchronous state.
			return null;
		}

		// Protected methods.

		/// <summary>
		/// An event handler called when the object is disposed.
		/// </summary>
		protected override void OnDisposed()
		{
			// Call the base class dispose handler.
			base.OnDisposed();
		}
	}
}
