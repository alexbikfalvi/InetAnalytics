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
using System.Threading;
using DotNetApi.Async;

namespace YtCrawler.Spider
{
	/// <summary>
	/// A delegate used when completing a spider asynchronous operation.
	/// </summary>
	/// <param name="spider">The spider.</param>
	/// <param name="asyncState">The state of the asynchronous operation.</param>
	public delegate void SpiderCallback(Spider spider, SpiderAsyncResult asyncState);

	/// <summary>
	/// A class that represents a crawling spider, which is the basic unit of gathering YouTube data.
	/// Spider data can be collected from the YouTube API or read from the database.
	/// </summary>
	public abstract class Spider : IDisposable
	{
		public enum CrawlState
		{
			Stopped = 0,
			Running = 1,
			Canceling = 2
		}

		private readonly object sync = new object();

		private CrawlState state;
		private DateTime lastUpdated;

		/// <summary>
		/// Creates a crawling spider with an undefined data origin.
		/// </summary>
		public Spider()
		{
			this.state = CrawlState.Stopped;
			this.lastUpdated = DateTime.MinValue;
		}

		// Public events.
		
		/// <summary>
		/// An event raised when the spider state has changed.
		/// </summary>
		public event SpiderEventHandler StateChanged;
		/// <summary>
		/// An event raised when the spider crawl has started.
		/// </summary>
		public event SpiderEventHandler CrawlStarted;
		/// <summary>
		/// An event raised when the spider crawl has finished.
		/// </summary>
		public event SpiderEventHandler CrawlFinished;


		// Public properties.

		/// <summary>
		/// Gets the crawl state of the spider.
		/// </summary>
		public CrawlState State { get { return this.state; } }
		/// <summary>
		/// Gets the data/time when the spider data was last updated.
		/// </summary>
		public DateTime LastUpdated { get { return this.lastUpdated; } }

		// Public methods.
	
		/// <summary>
		/// Disposes the current spider object.
		/// </summary>
		public void Dispose()
		{
			// Call the dispose event handler.
			this.Dispose(true);
			// Suppress the finalizer.
			GC.SuppressFinalize(this);
		}

		// Protected methods.

		/// <summary>
		/// Disposes the current object.
		/// </summary>
		/// <param name="disposing">If <b>true</b>, clean both managed and native resources. If <b>false</b>, clean only native resources.</param>
		protected virtual void Dispose(bool disposing)
		{
		}

		/// <summary>
		/// An event handler called when the spider starts crawling.
		/// </summary>
		protected void OnStarted()
		{
			lock (this.sync)
			{
				// If the spider is in the running state, throw an exception.
				if (this.state != CrawlState.Stopped) throw new SpiderException("Cannot begin spider crawling because the spider is not in the stopped state.");
				// Change the spider state to running.
				this.state = CrawlState.Running;
				// Raise the events.
				if (this.StateChanged != null) this.StateChanged(this, new SpiderEventArgs(this));
				if (this.CrawlStarted != null) this.CrawlStarted(this, new SpiderEventArgs(this));
			}
		}

		/// <summary>
		/// An event handler called when the spider finishes crawling.
		/// </summary>
		protected void OnFinished()
		{
			lock (this.sync)
			{
				// If the spider is not in the running state, throw an exception.
				if (this.state == CrawlState.Stopped) throw new SpiderException("Cannot finish spider crawling because the spider is already in the stopped state.");
				// Change the spider state to running.
				this.state = CrawlState.Stopped;
				// Raise the event.
				if (this.StateChanged != null) this.StateChanged(this, new SpiderEventArgs(this));
				if (this.CrawlFinished != null) this.CrawlFinished(this, new SpiderEventArgs(this));
			}
		}

		/// <summary>
		/// An event handler called when the user cancels the spider crawling.
		/// </summary>
		protected void OnCanceled()
		{
			lock (this.sync)
			{
				// If the spider is not in the running state, throw an exception.
				if (this.state != CrawlState.Running) throw new SpiderException("Cannot cancel spider crawling because the spider is not in the running state.");
				// Change the spider state to canceling.
				this.state = CrawlState.Canceling;
				// Raise the event.
				if (this.StateChanged != null) this.StateChanged(this, new SpiderEventArgs(this));
			}
		}
	}
}
