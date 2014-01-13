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
		/// Begins an asychronous traceroute to the specified destination.
		/// </summary>
		/// <param name="destination">The destination IP address.</param>
		/// <param name="callback">The callback method.</param>
		/// <param name="state">The user state.</param>
		/// <returns>The result of the asynchronous operation.</returns>
		public IAsyncResult Begin(IPAddress destination, AsyncCallback callback, object state)
		{
			lock (this.settings)
			{
				// Create a new traceroute state.
				TracerouteState asyncState = new TracerouteState(destination, this.settings.DataLength, callback, state);

				// Send a traceroute.
				this.Send(asyncState);

				// Return the asynchronous state.
				return asyncState;
			}
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

			// If there is an exception, throw the exception.
			if (asyncState.LastException != null) throw asyncState.LastException;

			// Else, return the result.
			return asyncState;
		}

		/// <summary>
		/// Cancels the traceroute.
		/// </summary>
		/// <param name="result">The result of the asynchronous operation.</param>
		public void Cancel(IAsyncResult result)
		{
			// Get the traceroute state.
			TracerouteState asyncState = result as TracerouteState;

			// Cancel the operation.
			asyncState.Cancel();
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
					// Finish sending a traceroute message using the state.
					asyncState.End(asyncResult);

					// A flag indicated whether the traceroute has completed.
					bool completed = false;

					lock (this.settings.Sync)
					{
						// Check whether the traceroute reached the destination.
						completed = completed || (asyncState.LastReply != null ? asyncState.Destination.Equals(asyncState.LastReply.Address) &&
							(this.settings.StopHopOnSuccess ? asyncState.TtlSuccess : asyncState.CurrentAttempt >= this.settings.MaximumAttempts) : false);
						// Check whether the maximum number of hops was reached.
						completed = completed || (asyncState.CurrentTtl > this.settings.MaximumHops);
						// Check whether the maximum number of failed hops was reached.
						completed = completed || (this.settings.StopTracerouteOnFail && (asyncState.LastFailedTtlCount + 1 >= this.settings.MaximumFailedHops) && (asyncState.CurrentAttempt >= this.settings.MaximumAttempts));
						// Check whether the operation was canceled.
						completed = completed || asyncState.CancellationToken.IsCancellationRequested;
					}

					// If the traceroute is completed, complete the asynchronous operation.
					if (completed) asyncState.Complete();

					// Call the callback method.
					if (null != asyncState.Callback) asyncState.Callback(asyncState);

					// If the operation is not completed.
					if (!completed)
					{
						lock (this.settings.Sync)
						{
							// If the hop was successful, and the traceroute stops on success; or if the maximum number of attempts was reached.
							if ((this.settings.StopHopOnSuccess && asyncState.TtlSuccess) || (asyncState.CurrentAttempt >= this.settings.MaximumAttempts))
							{
								// Increment the TTL.
								asyncState.Next();
							}
						}
						// Send a new message.
						this.Send(asyncState);
					}
					else
					{
						// Dispose the asynchronous state.
						asyncState.Dispose();
					}
				});
		}
	}
}
