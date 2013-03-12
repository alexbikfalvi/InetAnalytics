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
	public delegate void SpiderCallback(Spider spider, AsyncResult asyncState);
	public delegate void SpiderStateChangedEventHandler(Spider spider);

	/// <summary>
	/// A class that represents a crawling spider, which is the basic unit of gathering YouTube data.
	/// Spider data can be collected from the YouTube API or read from the database.
	/// </summary>
	public abstract class Spider : IDisposable
	{
		public enum CrawlState
		{
			Ready = 0,
			Running = 1,
			Finished = 2
		}

		private CrawlState state;
		private DateTime lastUpdated;
		private Mutex mutex = new Mutex();

		/// <summary>
		/// Creates a crawling spider with an undefined data origin.
		/// </summary>
		public Spider()
		{
			this.state = CrawlState.Ready;
			this.lastUpdated = DateTime.MinValue;
		}

		// Public events.
		public event SpiderStateChangedEventHandler StateChanged;

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
			// Call the disposing event handler.
			this.OnDisposed();
		}

		// Protected methods.

		/// <summary>
		/// An event handler called when the spider starts crawling.
		/// </summary>
		protected void OnStart()
		{
			// Lock the mutex.
			this.mutex.WaitOne();
			try
			{
				// If the spider is in the running state, throw an exception.
				if (this.state == CrawlState.Running) throw new SpiderException("Cannot begin spider crawling because the spider is already in the running state.");
				// Change the spider state to running.
				this.state = CrawlState.Running;
				// Raise the event.
				if (this.StateChanged != null) this.StateChanged(this);
			}
			finally
			{
				// Unlock the mutex.
				this.mutex.ReleaseMutex();
			}
		}

		/// <summary>
		/// An event handler called when the spider finishes crawling.
		/// </summary>
		protected void Finished()
		{
			// Lock the mutex.
			this.mutex.WaitOne();
			try
			{
				// If the spider is not in the running state, throw an exception.
				if (this.state != CrawlState.Running) throw new SpiderException("Cannot finish spider crawling because the spider is not in the running state.");
				// Change the spider state to running.
				this.state = CrawlState.Finished;
				// Raise the event.
				if (this.StateChanged != null) this.StateChanged(this);
			}
			finally
			{
				// Unlock the mutex.
				this.mutex.ReleaseMutex();
			}
		}

		/// <summary>
		/// An event handler called when the object is being disposed.
		/// </summary>
		protected virtual void OnDisposed()
		{
		}
	}
}
