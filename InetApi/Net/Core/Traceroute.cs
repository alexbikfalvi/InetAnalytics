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
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace InetApi.Net.Core
{
	/// <summary>
	/// A class that performs an Internet traceroute.
	/// </summary>
	public class Traceroute : IDisposable
	{
		public readonly TracerouteSettings settings;

		/// <summary>
		/// Creates a new traceroute instance.
		/// </summary>
		/// <param name="settings">The traceroute settings.</param>
		public Traceroute(TracerouteSettings settings)
		{
			// Set the traceroute settings.
			this.settings = settings;
		}

		// Public methods.

		/// <summary>
		/// Disposes the current object.
		/// </summary>
		public void Dispose()
		{
			// Call the dispose method.
			this.Dispose(true);
			// Suppress the finalizer.
			GC.SuppressFinalize(this);
		}

		/// <summary>
		/// Creates a traceroute asynchronous state.
		/// </summary>
		/// <param name="localAddress"></param>
		/// <returns></returns>
		//public static TracerouteState Create(IPAddress localAddress)
		//{

		//}

		//public IAsyncResult BeginIcmp(IPAddress destination, byte ttl, AsyncCallback callback, object state)
		//{
		//	// Create a new traceroute state.
		//	//TracerouteState asyncState = new TracerouteState();
		//}

		/// <summary>
		/// Begins an asychronous traceroute to the specified destination.
		/// </summary>
		/// <param name="destination">The destination IP address.</param>
		/// <param name="callback">The callback method.</param>
		/// <param name="state">The user state.</param>
		/// <returns>The result of the asynchronous operation.</returns>
		public IAsyncResult Begin(IPAddress destination, AsyncCallback callback, object state)
		{
			// Create a new traceroute state.
			TracerouteState asyncState = new TracerouteState(destination, callback, state);

			// Send a traceroute.
			this.Send(asyncState);

			// Return the asynchronous state.
			return asyncState;
		}

		/// <summary>
		/// Ends an asycnhronous traceroute operation.
		/// </summary>
		/// <param name="result">The result of the asynchronous traceroute operation.</param>
		/// <returns>The result of the traceroute operation.</returns>
		public TracerouteResult End(IAsyncResult result)
		{
			// Get the traceroute state.
			TracerouteState asyncState = result as TracerouteState;

			try
			{
				// Send a

				// Return the asynchronous state.
				return null;
			}
			finally
			{
				// Dispose the asynchronous state.
				asyncState.Dispose();
			}
		}

		// Protected methods.

		/// <summary>
		/// Disposes the current object.
		/// </summary>
		/// <param name="disposing">If <b>true</b>, clean both managed and native resources. If <b>false</b>, clean only native resources.</param>
		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
			}
		}

		// Private methods.

		/// <summary>
		/// Send a traceroute message using the specified traceroute state.
		/// </summary>
		/// <param name="asyncState">The traceroute state.</param>
		private void Send(TracerouteState asyncState)
		{
			// Begin sending a traceroute message using the state.
			IAsyncResult result = asyncState.Begin((IAsyncResult asyncResult) =>
				{
					try
					{
						// Finish sending a traceroute message using the state.
						PingReply reply = asyncState.End(asyncResult);

						// Call the callback method using the result.
					}
					catch (Exception exception)
					{
						// Call the callback method using the exception.
					}
					finally
					{
						// Increment the TTL and send a new message.
					}
				});
		}
	}
}
