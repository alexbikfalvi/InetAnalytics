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
using System.Collections.Generic;
using System.Net;
using System.Threading;
using Microsoft.Win32;
using YtApi.Api.V2;
using YtApi.Api.V2.Data;
using YtCrawler.Database;
using YtCrawler.Database.Data;
using DotNetApi;
using DotNetApi.Async;
using DotNetApi.Web;

namespace YtCrawler.Spider
{
	/// <summary>
	/// A spider browsing through the YouTube API version 2 standard video feeds.
	/// </summary>
	public sealed class SpiderStandardFeeds : Spider 
	{
		public struct CrawlInfo
		{
			public CrawlInfo(IDictionary<string, DbObjectStandardFeed> feeds)
			{
				this.Feeds = feeds;
			}

			public IDictionary<string, DbObjectStandardFeed> Feeds;
		}

		public struct FeedStartedInfo
		{
			public FeedStartedInfo(DbObjectStandardFeed feed, int index, int count)
			{
				this.Feed = feed;
				this.Index = index;
				this.Count = count;
			}

			public DbObjectStandardFeed Feed;
			public int Index;
			public int Count;
		}

		public struct FeedFinishedInfo
		{
			public FeedFinishedInfo(DbObjectStandardFeed feed, int index, int count, CrawlResult result)
			{
				this.Feed = feed;
				this.Index = index;
				this.Count = count;
				this.Result = result;
			}

			public DbObjectStandardFeed Feed;
			public int Index;
			public int Count;
			public CrawlResult Result;
		}

		public enum CrawlResult
		{
			Success = 0,
			Warning = 1,
			Fail = 2,
			Canceled = 3
		}

		private Crawler crawler;

		private DbObjectStandardFeed[] standardFeeds = null;

		/// <summary>
		/// Creates a new spider instance.
		/// </summary>
		/// <param name="crawler">The crawler object.</param>
		public SpiderStandardFeeds(Crawler crawler)
		{
			// Set the crawler.
			this.crawler = crawler;
		}

		// Public properties.

		/// <summary>
		/// Gets the standard feeds.
		/// </summary>
		public DbObjectStandardFeed[] StandardFeeds { get { return this.standardFeeds; } }

		// Public events.

		/// <summary>
		/// An event raised when the spider began crawling the feeds.
		/// </summary>
		public event SpiderInfoEventHandler<CrawlInfo> FeedsCrawlStarted;
		/// <summary>
		/// An event raised when the spider finished crawling the feeds.
		/// </summary>
		public event SpiderInfoEventHandler<CrawlInfo> FeedsCrawlFinished;
		/// <summary>
		/// An event raised when the spider began crawling a standard feed.
		/// </summary>
		public event SpiderInfoEventHandler<FeedStartedInfo> FeedCrawlStarted;
		/// <summary>
		/// An event raised when the spider finished crawling a standard feed.
		/// </summary>
		public event SpiderInfoEventHandler<FeedFinishedInfo> FeedCrawlFinished;

		// Public methods.

		/// <summary>
		/// Begins an asynchronous spider crawling using the specified user state.
		/// </summary>
		/// <param name="callback"></param>
		/// <param name="userState">The user state.</param>
		/// <returns>The result of the asynchronous spider operation.</returns>
		public IAsyncResult BeginCrawl(SpiderCallback callback, object userState = null)
		{
			// Update the spider state.
			base.OnStarted();

			try
			{
				// Compute the standard feeds to crawl.
				Dictionary<string, DbObjectStandardFeed> feeds = new Dictionary<string, DbObjectStandardFeed>();

				// For all standard feeds.
				foreach (YouTubeStandardFeed feed in YouTube.StandardFeeds)
				{
					// If the feed is not selected, continue.
					if (!this.GetFeedSelected(feed)) continue;

					// Get the valid times for this feed.
					YouTubeTimeId[] times = YouTubeUri.GetValidTime(feed);

					// For all times corresponding to this feed.
					foreach (YouTubeTimeId time in times)
					{
						// Create a new standard feed object.
						DbObjectStandardFeed obj = new DbObjectStandardFeed();
						obj.Id = this.EncodeFeedKey(feed, time, null, null);
						obj.FeedId = (int)feed;
						obj.TimeId = (int)time;
						obj.Category = null;
						obj.Region = null;
						feeds.Add(obj.Id, obj);

						// For all assignable and non-deprecated categories.
						foreach (YouTubeCategory category in this.crawler.Categories)
						{
							// If the category supports browsable regions.
							if (category.Browsable != null)
							{
								// Create a new standard feed object.
								obj = new DbObjectStandardFeed();
								obj.Id = this.EncodeFeedKey(feed, time, category.Label, null);
								obj.FeedId = (int)feed;
								obj.TimeId = (int)time;
								obj.Category = category.Term;
								obj.Region = null;
								feeds.Add(obj.Id, obj);

								// For all browsable regions.
								foreach (string region in category.Browsable)
								{
									// Create a new standard feed object.
									obj = new DbObjectStandardFeed();
									obj.Id = this.EncodeFeedKey(feed, time, category.Label, region);
									obj.FeedId = (int)feed;
									obj.TimeId = (int)time;
									obj.Category = category.Label;
									obj.Region = region;
									feeds.Add(obj.Id, obj);
								}
							}
						}
					}
				}

				// Raise the crawl feeds started event.
				if (this.FeedsCrawlStarted != null) this.FeedsCrawlStarted(this, new SpiderInfoEventArgs<CrawlInfo>(this, new CrawlInfo(feeds)));

				// Create a new spider asynchronous result.
				SpiderAsyncResult asyncResult = new SpiderAsyncResult(userState);

				// Set the crawl result counters.
				int counterSuccess = 0;
				int counterWarning = 0;
				int counterFailed = 0;
				int counterPending = feeds.Count;

				// Execute the crawl on the thread pool.
				ThreadPool.QueueUserWorkItem((object state) =>
					{
						// Set the feed index.
						int index = 0;
						// For each feed in the feeds collection.
						foreach(KeyValuePair<string, DbObjectStandardFeed> feed in feeds)
						{
							// Check if the crawl has been canceled.
							if (asyncResult.IsCanceled) break;

							// Increment the feed index.
							index++;

							// Get the object.
							DbObjectStandardFeed obj = feed.Value;

							// Call the feed started event handler.
							if (this.FeedCrawlStarted != null) this.FeedCrawlStarted(this, new SpiderInfoEventArgs<FeedStartedInfo>(this, new FeedStartedInfo(obj, index, feeds.Count)));

							// Crawl the feed.
							CrawlResult result = this.CrawlFeed(
								asyncResult,
								(YouTubeStandardFeed)obj.FeedId,
								(YouTubeTimeId)obj.TimeId,
								obj.Category,
								obj.Region,
								ref obj);

							// Call the feed finished event handler.
							if (this.FeedCrawlFinished != null) this.FeedCrawlFinished(this, new SpiderInfoEventArgs<FeedFinishedInfo>(this, new FeedFinishedInfo(obj, index, feeds.Count, result)));
						}

						// Set the result.
						asyncResult.Result = feeds;

						// Raise the crawl feeds finished event.
						if (this.FeedsCrawlFinished != null) this.FeedsCrawlFinished(this, new SpiderInfoEventArgs<CrawlInfo>(this, new CrawlInfo(feeds)));

						// Update the spider state.
						base.OnFinished();
					});
				// Returns the spider object as the asynchronous state.
				return asyncResult;
			}
			catch (Exception)
			{
				// If an exception occurs, update the spider state.
				base.OnFinished();
				// Rethrow the exception.
				throw;
			}
		}

		/// <summary>
		/// Completes the spider crawl and returns the crawl result.
		/// </summary>
		/// <param name="result">The asynchronous result.</param>
		/// <returns>The crawled standard feeds.</returns>
		public IDictionary<string, DbObjectStandardFeed> EndCrawl(IAsyncResult result)
		{
			// Convert the result to a spider asynchronous result.
			SpiderAsyncResult asyncResult = result as SpiderAsyncResult;

			// If an exception occurred during the crawl, throw the exception.
			if (asyncResult.Exception != null)
			{
				throw new SpiderException("An exception occurred during the spider crawling.", asyncResult.Exception);
			}

			// Else, return the result.
			return asyncResult.Result as IDictionary<string, DbObjectStandardFeed>;
		}

		/// <summary>
		/// Cancels an asynchronous crawling operation.
		/// </summary>
		/// <param name="result">The asynchronous result.</param>
		public void CancelCrawl(IAsyncResult result)
		{
			// Update the spider state.
			base.OnCanceled();

			// Get the asynchronous result.
			SpiderAsyncResult asyncResult = result as SpiderAsyncResult;

			// Cancel the operation.
			asyncResult.Cancel();
		}

		/// <summary>
		/// Computes the feed key for a set of feed parameters.
		/// </summary>
		/// <param name="feedId">The feed ID.</param>
		/// <param name="timeId">The time ID.</param>
		/// <param name="category">The category.</param>
		/// <param name="regionId">The region ID.</param>
		/// <returns>The feed key.</returns>
		public string EncodeFeedKey(YouTubeStandardFeed feedId, YouTubeTimeId timeId, string category, string regionId)
		{
			return "{0}.{1}.{2}.{3}".FormatWith(
				(int)feedId,
				(int)timeId,
				category != null ? category : string.Empty,
				regionId != null ? regionId : string.Empty);
		}

		/// <summary>
		/// Gets whether the specified standard feed is selected.
		/// </summary>
		/// <param name="feed">The standard feed.</param>
		/// <returns><b>True</b> if the standard feed is selected, <b>false</b> otherwise.</returns>
		public bool GetFeedSelected(YouTubeStandardFeed feed)
		{
			return DotNetApi.Windows.Registry.GetBoolean(this.crawler.Config.SpidersConfigPath + "\\StandardFeeds", feed.ToString(), false);
		}

		/// <summary>
		/// Sets whether the specified standard feed is selected.
		/// </summary>
		/// <param name="feed">The standard feed.</param>
		/// <param name="selected"><b>True</b> if the standard feed is selected, <b>false</b> otherwise.</param>
		public void SetFeedSelected(YouTubeStandardFeed feed, bool selected)
		{
			DotNetApi.Windows.Registry.SetBoolean(this.crawler.Config.SpidersConfigPath + "\\StandardFeeds", feed.ToString(), selected);
		}

		// Protected methods.

		/// <summary>
		/// Disposes the current object.
		/// </summary>
		/// <param name="disposing">If <b>true</b>, clean both managed and native resources. If <b>false</b>, clean only native resources.</param>
		protected override void Dispose(bool disposing)
		{
			// Call the base class dispose handler.
			base.Dispose(disposing);
		}

		// Private methods.

		/// <summary>
		/// Crawls the feed at the specified parameters.
		/// </summary>
		/// <param name="asyncResult">The asynchronous result.</param>
		/// <param name="feedId">The feed.</param>
		/// <param name="timeId">The time.</param>
		/// <param name="category">The category.</param>
		/// <param name="regionId">The region.</param>
		/// <param name="obj">The standard feed object.</param>
		/// <returns>The crawl result.</returns>
		private CrawlResult CrawlFeed(
			SpiderAsyncResult asyncResult,
			YouTubeStandardFeed feedId,
			YouTubeTimeId timeId,
			string category,
			string regionId,
			ref DbObjectStandardFeed obj)
		{
			// If the asynchronousn operation has been canceled, do nothing.
			if (asyncResult.IsCanceled) return CrawlResult.Canceled;

			// Compute the feed key.
			string key = this.EncodeFeedKey(feedId, timeId, category, regionId);

			// Compute the feed URI starting at index 1 and ask for 1 result.
			Uri uri = YouTubeUri.GetStandardFeed(feedId, regionId, category, timeId, 1, 1);

			// Create a new video request.
			YouTubeRequestFeed<Video> request = new YouTubeRequestFeed<Video>(this.crawler.Settings);

			// Set the feed URL.
			obj.Url = uri.AbsoluteUri;

			try
			{
				// Begin an asynchronous request for the standard feed.
				AsyncWebResult result = request.Begin(uri, (AsyncWebResult webResult) => { }) as AsyncWebResult;

				// Add the result of the web operation to the collection of web requests.
				AsyncWebOperation operation = asyncResult.AddAsyncWeb(request, result);

				// Wait for the asynchronous operation to complete.
				result.AsyncWaitHandle.WaitOne();

				// Remove the result of the web operation from the collection of web requests.
				asyncResult.RemoveAsyncWeb(operation);

				// Complete the request and get the video feed.
				Feed<Video> feed = request.End(result);

				// If the operation completed successfully, set the browsable to true.
				obj.Browsable = true;
				// Set the response HTTP code.
				obj.HttpCode = (int)(result as AsyncWebResult).Response.StatusCode;
				
				// Return the result.
				return (feed.FailuresAtom.Count == 0) && (feed.FailuresEntry.Count == 0) ? CrawlResult.Success : CrawlResult.Warning;
			}
			catch (WebException exception)
			{
				if (exception.Status == WebExceptionStatus.RequestCanceled)
				{
					return CrawlResult.Canceled;
				}
				else
				{
					// If the operation failed with a web exception, set the browsable to false.
					obj.Browsable = false;
					// Set the response HTTP code.
					obj.HttpCode = (int)(exception.Response as HttpWebResponse).StatusCode;
					// Return the result.
					return CrawlResult.Fail;
				}
			}
			catch (Exception)
			{
				// If the operation failed with a web exception, set the browsable to false.
				obj.Browsable = false;
				// Set the response HTTP code to null.
				obj.HttpCode = null;
				// Return the result.
				return CrawlResult.Fail;
			}
		}
	}
}
