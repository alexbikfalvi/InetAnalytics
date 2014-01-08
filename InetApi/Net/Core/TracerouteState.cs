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
	public sealed class TracerouteState : AsyncResult
	{
		private readonly Ping ping = new Ping();

		private readonly IPAddress destination;
		private readonly AsyncCallback callback;
		private byte[] data = null;

		/// <summary>
		/// Creates a new traceroute asynchronous state, bound to the specified local address.
		/// </summary>
		/// <param name="destination">The local address.</param>
		/// <param name="callback">The callback method.</param>
		/// <param name="state">The user state.</param>
		public TracerouteState(IPAddress destination, AsyncCallback callback, object state)
			: base(state)
		{
			this.destination = destination;
			this.callback = callback;

			this.HopIndex = 1;
			this.AttemptIndex = 0;
			this.Timeout = 1000;
			this.DontFragment = true;
			this.DataLength = 32;
		}

		// Internal properties.

		/// <summary>
		/// Gets or sets the hop index.
		/// </summary>
		internal int HopIndex { get; set; }
		/// <summary>
		/// Gets or sets the attempt index.
		/// </summary>
		internal int AttemptIndex { get; set; }
		/// <summary>
		/// Gets or sets the ICMP timeout.
		/// </summary>
		internal int Timeout { get; set; }
		/// <summary>
		/// Gets or sets whether the ICMP don't fragment bit is set.
		/// </summary>
		internal bool DontFragment { get; set; }
		/// <summary>
		/// Gets or sets the ICMP data length.
		/// </summary>
		internal int DataLength
		{
			get { return this.data != null ? this.data.Length : 0; }
			set { this.data = new byte[value]; }
		}

		// Internal methods.

		/// <summary>
		/// Sends a traceroute request to the specified destination.
		/// </summary>
		/// <param name="destination">The destination.</param>
		/// <param name="callback"></param>
		/// <returns></returns>
		internal IAsyncResult Begin(AsyncCallback callback)
		{
			// Create an asynchronous state.
			PingState asyncState = new PingState(this);

			// Send the ICMP request on the thread pool.
			ThreadPool.QueueUserWorkItem((object state) =>
				{
					try
					{
						// Send the ICMP request.
						asyncState.Result = this.ping.Send(this.destination, this.Timeout, this.data, new PingOptions(this.HopIndex, this.DontFragment));
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
						if (null != callback) this.callback(asyncState);
					}
				});

			// Return the asynchronous state.
			return asyncState;
		}

		internal PingReply End(IAsyncResult result)
		{
			// Get the asynchronous state.
			PingState asyncState = result as PingState;

			// If there is an exception, throw the exception.
			if (null != asyncState.Exception) throw asyncState.Exception;

			// Else, return the result.
			return asyncState.Result;
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
			}
			// Call the base class method.
			base.Dispose(disposing);
		}
	}
}
