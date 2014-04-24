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
using System.Collections.Generic;
using System.Net;
using System.Threading;
using InetApi.Net.Core.Protocols;
using InetApi.Net.Core.Protocols.Filters;

namespace InetApi.Net.Core
{
	/// <summary>
	/// A class representing a multipath traceroute result.
	/// </summary>
	public sealed class MultipathTracerouteResult : IDisposable
	{
		/// <summary>
		/// An enumeration representing the request type.
		/// </summary>
		internal enum RequestType
		{
			Icmp = 0,
			Udp = 0
		}

		/// <summary>
		/// A structure representing the state for a request.
		/// </summary>
		private struct RequestState
		{
			/// <summary>
			/// The request type.
			/// </summary>
			public RequestType Type;
			/// <summary>
			/// The request timestamp.
			/// </summary>
			public DateTime Timestamp;
			/// <summary>
			/// The request timeout.
			/// </summary>
			public TimeSpan Timeout;
			/// <summary>
			/// The flow.
			/// </summary>
			public byte Flow;
			/// <summary>
			/// The attempt.
			/// </summary>
			public byte Attempt;
			/// <summary>
			/// The time-to-live.
			/// </summary>
			public byte TimeToLive;


			public override int GetHashCode()
			{
 				 return base.GetHashCode();
			}
		}

		private readonly MultipathTracerouteCallback callback;

		private readonly object sync = new object();
		private readonly ManualResetEvent wait = new ManualResetEvent(false);

		private readonly MultipathTracerouteState state = new MultipathTracerouteState();

		private readonly IPAddress localAddress;
		private readonly IPAddress remoteAddress;

		private readonly MultipathTracerouteFlow[] flows;

		private readonly HashSet<RequestState> requests = new HashSet<RequestState>();

		/// <summary>
		/// Creates a new multipath traceroute result instance.
		/// </summary>
		/// <param name="localAddress">The local address.</param>
		/// <param name="remoteAddress">The remote address.</param>
		/// <param name="settings">The multipath traceroute settings.</param>
		/// <param name="callback">The callback method.</param>
		internal MultipathTracerouteResult(IPAddress localAddress, IPAddress remoteAddress, MultipathTracerouteSettings settings, MultipathTracerouteCallback callback)
		{
			this.localAddress = localAddress;
			this.remoteAddress = remoteAddress;

			this.callback = callback;

			// Set the packet filters.
			this.PacketFilters = new FilterIp[] {
				new FilterIp { Protocol = ProtoPacketIp.Protocols.Icmp, SourceAddress = localAddress, DestinationAddress = remoteAddress },
				new FilterIp { Protocol = ProtoPacketIp.Protocols.Icmp, SourceAddress = null, DestinationAddress = localAddress },
				new FilterIp { Protocol = ProtoPacketIp.Protocols.Udp, SourceAddress = localAddress, DestinationAddress = remoteAddress }
			};

			// Create the flows.
			this.flows = new MultipathTracerouteFlow[settings.FlowCount];
			for (int index = 0; index < settings.FlowCount; index++)
			{
				this.flows[index] = new MultipathTracerouteFlow(settings);
			}
		}

		#region Public properties

		/// <summary>
		/// Gets the wait handle for the traceroute result.
		/// </summary>
		public WaitHandle Wait { get { return this.wait; } }
		/// <summary>
		/// Gets the list of flows.
		/// </summary>
		public MultipathTracerouteFlow[] Flows { get { return this.flows; } }

		#endregion

		#region Internal properties

		/// <summary>
		/// Gets the list of filters.
		/// </summary>
		internal FilterIp[] PacketFilters { get; private set; }

		#endregion

		#region Public methods

		/// <summary>
		/// Disposes the current object.
		/// </summary>
		public void Dispose()
		{
			// Dispose the wait handle.
			this.wait.Dispose();
			// Suppress the finalizer.
			GC.SuppressFinalize(this);
		}

		#endregion

		#region Internal methods

		/// <summary>
		/// Calls the callback method using the specified state.
		/// </summary>
		/// <param name="type">The state type.</param>
		/// <param name="parameters">The list of parameters.</param>
		internal void Callback(MultipathTracerouteState.StateType type, params object[] parameters)
		{
			lock (this.sync)
			{
				this.state.Type = type;
				this.state.Parameters = parameters;
				if (this.callback != null) this.callback(this, this.state);
			}
		}

		/// <summary>
		/// A method called to indicate the timeout of request.
		/// </summary>
		internal void Timeout()
		{
			lock (this.sync)
			{
				// Remove all requests that have expired.
				this.requests.RemoveWhere((RequestState requestState) =>
					{
						if (requestState.Timestamp + requestState.Timeout > DateTime.Now)
						{
							this.Callback(MultipathTracerouteState.StateType.RequestExpired, requestState);
							return true;
						}
						else return false;
					});
			}
		}

		/// <summary>
		/// Adds a new request to the requests list.
		/// </summary>
		/// <param name="type">The request type.</param>
		/// <param name="flow">The flow.</param>
		/// <param name="attempt">The attempt.</param>
		/// <param name="ttl">The TTL.</param>
		/// <param name="timeout">The request timeout.</param>
		internal void AddRequest(RequestType type, byte flow, byte attempt, byte ttl, TimeSpan timeout)
		{

		}

		internal void RemoveRequest(RequestType type, byte flow, byte attempt, byte ttl)

		#endregion
	}
}
