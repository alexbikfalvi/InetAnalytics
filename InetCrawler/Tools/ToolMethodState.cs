/* 
 * Copyright (C) 2013 Alex Bikfalvi
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

namespace InetCrawler.Tools
{
	/// <summary>
	/// A class representing the result of a tool method call.
	/// </summary>
	public sealed class ToolMethodState : IAsyncResult, IDisposable
	{
		private readonly ManualResetEvent wait = new ManualResetEvent(false);
		private readonly CancellationTokenSource cancel = new CancellationTokenSource();

		/// <summary>
		/// Creates a new tool method result.
		/// </summary>
		/// <param name="state">The user state.</param>
		public ToolMethodState(object state)
		{
			this.AsyncState = state;
			this.CompletedSynchronously = false;
			this.IsCompleted = false;
			this.Exception = null;
		}

		// Public properties.

		/// <summary>
		/// Gets the state of the asynchrnous operation.
		/// </summary>
		public object AsyncState { get; private set; }
		/// <summary>
		/// Gets the wait handle for the asynchronous operation.
		/// </summary>
		public WaitHandle AsyncWaitHandle { get { return this.wait; } }
		/// <summary>
		/// Indicates whether the asynchronous operation has completed synchronously.
		/// </summary>
		public bool CompletedSynchronously { get; private set; }
		/// <summary>
		/// Indicates whether the asynchronous operation has completed.
		/// </summary>
		public bool IsCompleted { get; private set; }
		/// <summary>
		/// Gets the cancellation token for the current asynchronous operation.
		/// </summary>
		public CancellationToken CancellationToken { get { return this.cancel.Token; } }
		/// <summary>
		/// Gets or sets the asynchronous operation exception.
		/// </summary>
		public Exception Exception { get; internal set; }
		/// <summary>
		/// Gets or sets the result of the asynchronous operation.
		/// </summary>
		public object Result { get; internal set; }

		// Public methods.

		/// <summary>
		/// Disposes the current object.
		/// </summary>
		public void Dispose()
		{
			// Dispose the wait handle.
			this.wait.Dispose();
			// Dispose the cancellation token source.
			this.cancel.Dispose();
			// Suppress the finalizer.
			GC.SuppressFinalize(this);
		}

		// Internal methods.

		/// <summary>
		/// Completes the asynchronous operation.
		/// </summary>
		internal void Complete()
		{
			// Set the completed flag to true.
			this.IsCompleted = true;
			// Set the wait handle to the signaled state.
			this.wait.Set();
		}

		/// <summary>
		/// Cancels the asynchronous operation.
		/// </summary>
		internal void Cancel()
		{
			// If the operation has completed, return.
			if (this.IsCompleted) return;
			// Cancel the operation.
			this.cancel.Cancel();
		}
	}
}
