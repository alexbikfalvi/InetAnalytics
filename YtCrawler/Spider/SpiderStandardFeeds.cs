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
using System.Net;
using System.Threading;
using YtApi.Api.V2;
using YtApi.Api.V2.Data;
using YtCrawler.Database;
using YtCrawler.Database.Data;
using DotNetApi.Async;
using DotNetApi.Web;

namespace YtCrawler.Spider
{
	public delegate void SpiderStandardFeedsEventHandler(string feedName);

	/// <summary>
	/// A spider browsing through the YouTube API version 2 standard video feeds.
	/// </summary>
	public class SpiderStandardFeeds : Spider 
	{
		private Crawler crawler;

		private DbObjectStandardFeed[] standardFeeds = null;

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
		public DbObjectStandardFeed[] StandardFeeds { get { return this.standardFeeds; } }

		// Public events.

		/// <summary>
		/// An event raised when the spider began crawling a standard feed.
		/// </summary>
		public event SpiderStandardFeedsEventHandler CrawlFeedStarted;
		/// <summary>
		/// An event raised when the spider finished crawling a standard feed.
		/// </summary>
		public event SpiderStandardFeedsEventHandler CrawlFeedFinished;

		// Public methods.

		/// <summary>
		/// Begins an asynchronous spider crawling using the specified user state.
		/// </summary>
		/// <param name="callback"></param>
		/// <param name="userState">The user state.</param>
		/// <returns>The result of the asynchronous operation.</returns>
		public IAsyncResult Crawl(SpiderCallback callback, object userState = null)
		{
			// Update the spider state.
			this.OnStarted();

			// Create a new spider asynchronous result.
			SpiderAsyncResult result = new SpiderAsyncResult(userState);

			// Execute the crawl on the thread pool.
			ThreadPool.QueueUserWorkItem((object state) =>
				{
					// Create the table of standard feeds.

					// For all standard feeds.
					foreach (YouTubeStandardFeed feed in YouTube.StandardFeeds)
					{
						// Get the valid times for this feed.
						YouTubeTimeId[] times = YouTubeUri.GetValidTime(feed);

						// For all times corresponding to this feed.
						foreach (YouTubeTimeId time in times)
						{
							// For all assignable and non-deprecated categories.
							foreach (YouTubeCategory category in this.crawler.Categories)
							{
								// If the category supports browsable regions.
								if (category.Browsable != null)
								{
									foreach (string region in category.Browsable)
									{
									}
								}
							}
						}
					}

					// Update the spider state.
					this.OnFinished();
				});
			
			// Returns the spider object as the asynchronous state.
			return result;
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

		// Private methods.

		/// <summary>
		/// Crawls the feed at the specified parameters.
		/// </summary>
		/// <param name="feedId">The feed.</param>
		/// <param name="timeId">The time.</param>
		/// <param name="category">The category.</param>
		/// <param name="regionId">The region.</param>
		private void CrawlFeed(YouTubeStandardFeed feedId, YouTubeTimeId timeId, string category, string regionId)
		{
			// Compute the feed URI starting at index 1 and ask for 1 result.
			Uri uri = YouTubeUri.GetStandardFeed(feedId, regionId, category, timeId, 1, 1);

			// Create a new video request.
			YouTubeRequestFeed<Video> request = new YouTubeRequestFeed<Video>(this.crawler.Settings);

			try
			{
				// Begin an asynchronous request for the standard feed.
				IAsyncResult result = request.Begin(uri, (AsyncWebResult asyncResult) => { });

				// Wait for the asynchronous operation to complete.
				result.AsyncWaitHandle.WaitOne();

				// Complete the request and get the video feed.
				Feed<Video> feed = request.End(result);
			}
			catch (WebException exception)
			{
			}
			catch (Exception exception)
			{
			}
		}
	}
}
