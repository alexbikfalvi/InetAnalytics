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
using System.Threading;
using DotNetApi.Async;
using DotNetApi.Web;

namespace InetCrawler.Spider
{
	/// <summary>
	/// Represents the result of a spider asynchronous operation.
	/// </summary>
	public sealed class SpiderAsyncResult : AsyncResult
	{
		private SpiderException exception = null;
		private object result = null;
		private bool canceled = false;

		private readonly HashSet<AsyncWebOperation> asyncWeb = new HashSet<AsyncWebOperation>();

		private readonly object sync = new object();

		/// <summary>
		/// Creates a new asynchronous result instance using the specified user state.
		/// </summary>
		/// <param name="state">The user state.</param>
		public SpiderAsyncResult(object state)
			: base(state)
		{
		}

		// Public properties.
		
		/// <summary>
		/// Gets or sets the asynchronous result exception.
		/// </summary>
		public SpiderException Exception
		{
			get { return this.exception; }
			set { this.exception = value; }
		}

		/// <summary>
		/// Returns the result of the asynchronous spider operation.
		/// </summary>
		public object Result
		{
			get { return this.result; }
			set { this.result = value; }
		}

		/// <summary>
		/// If <b>true</b> the asynchronous operation has been canceled.
		/// </summary>
		public bool IsCanceled
		{
			get { return this.canceled; }
			set { this.canceled = value; }
		}

		/// <summary>
		/// The collection of web requests executed during this asynchronous operation.
		/// </summary>
		public ICollection<AsyncWebOperation> AsyncWeb { get { return this.asyncWeb; } }

		// Public methods.

		/// <summary>
		/// Adds the result of an asynchronous web operation to the collection of web requests.
		/// </summary>
		/// <param name="request"></param>
		/// <param name="result">The result of the web request.</param>
		public AsyncWebOperation AddAsyncWeb(AsyncWebRequest request, AsyncWebResult result)
		{
			// Create the asynchronous web operation.
			AsyncWebOperation operation = new AsyncWebOperation(request, result);

			lock (this.sync)
			{
				// Add the result.
				this.asyncWeb.Add(operation);
			}

			// Return the web operation.
			return operation;
		}

		/// <summary>
		/// Removes the result of an asynchronous web operation from the collection of web requests.
		/// </summary>
		/// <param name="operation">The asynchronous web operation.</param>
		public void RemoveAsyncWeb(AsyncWebOperation operation)
		{
			lock (this.sync)
			{
				// Remove the result.
				this.asyncWeb.Remove(operation);
			}
		}

		/// <summary>
		/// Cancels the asynchronous spider operation, by setting the canceled flag to <b>true</b>, and cancelling
		/// all web requests added for this operation.
		/// </summary>
		public void Cancel()
		{
			// Set the canceled flag.
			this.canceled = true;

			lock (this.sync)
			{
				// Cancel all web operations.
				foreach (AsyncWebOperation operation in this.asyncWeb)
				{
					operation.Cancel();
				}
			}
		}
	}
}
