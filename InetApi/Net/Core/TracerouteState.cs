/* 
 * Copyright (C) 2014 Alex Bikfalvi
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
using System.Net.NetworkInformation;
using System.Threading;
using DotNetApi.Async;

namespace InetApi.Net.Core
{
	/// <summary>
	/// A class representing a traceroute asynchronous state.
	/// </summary>
	public sealed class TracerouteState : TracerouteResult
	{
		private readonly Ping ping = new Ping();
		private readonly CancellationTokenSource cancel = new CancellationTokenSource();

		private readonly IPAddress destination;
		private readonly AsyncCallback callback;
		private readonly byte[] data = null;

		/// <summary>
		/// Creates a new traceroute asynchronous state, bound to the specified local address.
		/// </summary>
		/// <param name="destination">The local address.</param>
		/// <param name="callback">The callback method.</param>
		/// <param name="state">The user state.</param>
		public TracerouteState(IPAddress destination, int dataLength, AsyncCallback callback, object state)
			: base(state)
		{
			this.destination = destination;
			this.data = new byte[dataLength];
			this.callback = callback;

			this.Timeout = 1000;
			this.DontFragment = true;

			this.CurrentTtl = 1;
			this.CurrentAttempt = 0;
			this.TtlSuccess = false;
			
			this.LastFailedTtlCount = 0;
			this.LastReply = null;
			this.LastException = null;

			this.IsCanceled = false;
		}

		// Internal properties.

		/// <summary>
		/// Gets the destination.
		/// </summary>
		internal IPAddress Destination { get { return this.destination; } }
		/// <summary>
		/// Gets the callback method.
		/// </summary>
		internal AsyncCallback Callback { get { return this.callback; } }
		/// <summary>
		/// Gets or sets the ICMP data length.
		/// </summary>
		internal int DataLength
		{
			get { return this.data != null ? this.data.Length : 0; }
		}
		/// <summary>
		/// Gets the cancellation token.
		/// </summary>
		internal CancellationToken CancellationToken { get { return this.cancel.Token; } }

		// Internal methods.

		/// <summary>
		/// Begins a traceroute request to the specified destination.
		/// </summary>
		/// <param name="destination">The destination.</param>
		/// <param name="callback"></param>
		/// <returns></returns>
		internal IAsyncResult Begin(AsyncCallback callback)
		{
			// Create an asynchronous state.
			PingState asyncState = new PingState(this);

			// Increment the attempt for the current TTL.
			this.CurrentAttempt++;

			// Send the ICMP request on the thread pool.
			ThreadPool.QueueUserWorkItem((object state) =>
				{
					try
					{
						// Send the ICMP request.
						asyncState.Result = this.ping.Send(this.destination, this.Timeout, this.data, new PingOptions(this.CurrentTtl, this.DontFragment));
					}
					catch (Exception exception)
					{
						// Set the ping exception.
						asyncState.Exception = exception;
					}
					finally
					{
						// Set the operation as completed.
						asyncState.Complete();
						// Call the callback method.
						if (null != callback) callback(asyncState);
						// Dispose the ping state.
						asyncState.Dispose();
					}
				});

			// Return the asynchronous state.
			return asyncState;
		}

		/// <summary>
		/// Ends a traceroute request.
		/// </summary>
		/// <param name="result">The result of the asychronous operation.</param>
		internal void End(IAsyncResult result)
		{
			// Get the asynchronous state.
			PingState asyncState = result as PingState;

			// Set the last result and exception.
			if (null != asyncState.Exception)
			{
				this.LastReply = null;
				this.LastException = asyncState.Exception;
				this.IsSuccess = false;
				this.ErrorCount++;
			}
			else
			{
				this.LastReply = asyncState.Result;
				this.LastException = null;
				this.LastFailedTtlCount = 0;
				if ((asyncState.Result != null) && ((asyncState.Result.Status == IPStatus.Success) || (asyncState.Result.Status == IPStatus.TtlExpired)))
				{
					this.IsSuccess = true;
					this.TtlSuccess = true;
					this.SuccessCount++;
					this.AddRoundtripTime(asyncState.Result.RoundtripTime);
				}
				else
				{
					this.IsSuccess = false;
					this.ErrorCount++;
				}
			}
		}

		/// <summary>
		/// Increments the time-to-live of the traceroute state.
		/// </summary>
		internal void Next()
		{
			// If the current hop was unsuccessful, increment the number of failed TTLs.
			if (!this.TtlSuccess)
			{
				this.LastFailedTtlCount++;
			}
			this.CurrentTtl++;
			this.CurrentAttempt = 0;
			this.TtlSuccess = false;
			this.IsSuccess = false;
			this.SuccessCount = 0;
			this.ErrorCount = 0;
			this.ResetRoundtripTime();
		}

		/// <summary>
		/// Cancels the current operation.
		/// </summary>
		internal void Cancel()
		{
			this.IsCanceled = true;
			this.cancel.Cancel();
		}

		// Protected methods.

		/// <summary>
		/// Disposes the current object.
		/// </summary>
		/// <param name="disposing">If <b>true</b>, clean both managed and native resources. If <b>false</b>, clean only native resources.</param>
		protected override void Dispose(bool disposing)
		{
			// Dispose the current objects.
			if (disposing)
			{
				this.ping.Dispose();
				this.cancel.Dispose();
			}
			// Call the base class method.
			base.Dispose(disposing);
		}
	}
}
