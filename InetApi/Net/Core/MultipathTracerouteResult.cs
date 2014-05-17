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
using System.Runtime.Serialization;
using System.Threading;
using InetApi.Net.Core.Protocols;
using InetApi.Net.Core.Protocols.Filters;

namespace InetApi.Net.Core
{
	/// <summary>
	/// A class representing a multipath traceroute result.
	/// </summary>
	[Serializable]
    public sealed class MultipathTracerouteResult : IDisposable
	{
		/// <summary>
		/// An enumeration representing the request type.
		/// </summary>
		public enum RequestType
		{
			None = 0x0,
			Icmp = 0x1,
			Udp = 0x2,
			UdpIdentification = 0x4,
			UdpChecksum = 0x8,
			UdpBoth = 0xC
		}

		/// <summary>
		/// A structure representing the state for a request.
		/// </summary>
		public struct RequestState
		{
			#region Public fields

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

			#endregion
		}

		/// <summary>
		/// An equality comparer class for a request state.
		/// </summary>
		private class RequestStateComparer : IEqualityComparer<RequestState>
		{
			/// <summary>
			/// Compares two request state objects for equality.
			/// </summary>
			/// <param name="left">The left state.</param>
			/// <param name="right">The right state.</param>
			/// <returns><b>True</b> if the states are equal, <b>false</b> otherwise.</returns>
			public bool Equals(RequestState left, RequestState right)
			{
				return (left.Type == right.Type) && (left.Flow == right.Flow) && (left.TimeToLive == right.TimeToLive) && (left.Attempt == right.Attempt);
			}

			/// <summary>
			/// Gets the hash code for the specified request state.
			/// </summary>
			/// <param name="state">The state.</param>
			/// <returns>The hash code.</returns>
			public int GetHashCode(RequestState state)
			{
				return ((int)state.Type << 24) | (state.Flow << 16) | (state.TimeToLive << 8) | state.Attempt;
			}
		}

		private readonly MultipathTracerouteSettings settings;
		[NonSerialized]
		private readonly MultipathTracerouteCallback callback;

		[NonSerialized]
		private readonly object sync = new object();
		[NonSerialized]
		private readonly ManualResetEvent wait = new ManualResetEvent(false);

		[NonSerialized]
		private readonly MultipathTracerouteState state = new MultipathTracerouteState();

		private readonly IPAddress localAddress;
		private readonly IPAddress remoteAddress;

		private readonly MultipathTracerouteFlow[] flows;
		private readonly Dictionary<ushort, byte> flowsIcmpId = new Dictionary<ushort, byte>();
		private readonly Dictionary<ushort, byte> flowsUdpId = new Dictionary<ushort, byte>();

		[NonSerialized]
		private FilterIp[] packetFilters;
		[NonSerialized]
		private readonly HashSet<RequestState> requests = new HashSet<RequestState>(new RequestStateComparer());

		private readonly MultipathTracerouteData[, ,] dataIcmp;
		private readonly MultipathTracerouteData[, ,] dataUdp;
		
		private readonly MultipathTracerouteStatistics[,] statIcmp;
		private readonly MultipathTracerouteStatistics[,] statUdp;

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

			this.settings = settings;

			this.callback = callback;

			// Set the packet filters.
			this.packetFilters = new FilterIp[] {
				new FilterIp { Protocol = ProtoPacketIp.Protocols.Icmp, SourceAddress = localAddress, DestinationAddress = remoteAddress },
				new FilterIp { Protocol = ProtoPacketIp.Protocols.Icmp, SourceAddress = null, DestinationAddress = localAddress },
				new FilterIp { Protocol = ProtoPacketIp.Protocols.Udp, SourceAddress = localAddress, DestinationAddress = remoteAddress }
			};

			// Create the flows.
			this.flows = new MultipathTracerouteFlow[settings.FlowCount];
			for (byte index = 0; index < settings.FlowCount; index++)
			{
				this.flows[index] = new MultipathTracerouteFlow(settings);
				this.flowsIcmpId.Add(this.flows[index].IcmpId, index);
				this.flowsUdpId.Add(this.flows[index].UdpId, index);
			}

			// Create the ICMP data.
			this.dataIcmp = new MultipathTracerouteData[settings.FlowCount, settings.MaximumHops - settings.MinimumHops + 1, settings.AttemptsPerFlow];

			// Create the UDP data.
			this.dataUdp = new MultipathTracerouteData[settings.FlowCount, settings.MaximumHops - settings.MinimumHops + 1, settings.AttemptsPerFlow];

			// Create the ICMP statistics.
			this.statIcmp = new MultipathTracerouteStatistics[settings.FlowCount, settings.AttemptsPerFlow];

			// Create the UDP statistics.
			this.statUdp = new MultipathTracerouteStatistics[settings.FlowCount, settings.AttemptsPerFlow];
		}

		#region Public properties

        /// <summary>
        /// Gets the traceroute settings.
        /// </summary>
        public MultipathTracerouteSettings Settings { get { return this.settings; } }
		/// <summary>
		/// Gets the local address.
		/// </summary>
		public IPAddress LocalAddress { get { return this.localAddress; } }
		/// <summary>
		/// Gets the remote address.
		/// </summary>
		public IPAddress RemoteAddress { get { return this.remoteAddress; } }
		/// <summary>
		/// Gets the wait handle for the traceroute result.
		/// </summary>
		public WaitHandle Wait { get { return this.wait; } }
		/// <summary>
		/// Gets the list of flows.
		/// </summary>
		public MultipathTracerouteFlow[] Flows { get { return this.flows; } }
		/// <summary>
		/// Gets the ICMP data.
		/// </summary>
		public MultipathTracerouteData[, ,] IcmpData { get { return this.dataIcmp; } }
		/// <summary>
		/// Gets the ICMP statistics.
		/// </summary>
		public MultipathTracerouteStatistics[,] IcmpStatistics { get { return this.statIcmp; } }
		/// <summary>
		/// Gets the UDP data.
		/// </summary>
		public MultipathTracerouteData[, ,] UdpData { get { return this.dataUdp; } }
		/// <summary>
		/// Gets the UDP statistics.
		/// </summary>
		public MultipathTracerouteStatistics[,] UdpStatistics { get { return this.statUdp; } }

		#endregion

		#region Internal properties

		/// <summary>
		/// Gets the list of filters.
		/// </summary>
		internal FilterIp[] PacketFilters
		{
			get { return this.packetFilters; }
		}

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
						if (requestState.Timestamp + requestState.Timeout < DateTime.Now)
						{
							this.Callback(MultipathTracerouteState.StateType.RequestExpired, requestState);
							return true;
						}
						else return false;
					});

				// If the requests table is empty.
				if (this.requests.Count == 0)
				{
					// Set the wait handle.
					this.wait.Set();
				}
			}
		}

		/// <summary>
		/// Adds a new request to the requests list.
		/// </summary>
		/// <param name="type">The request type.</param>
		/// <param name="flow">The flow.</param>
		/// <param name="ttl">The time-to-live.</param>
		/// <param name="attempt">The attempt.</param>
		/// <param name="timeout">The request timeout.</param>
		/// <returns>The request state.</returns>
		internal RequestState AddRequest(RequestType type, byte flow, byte ttl, byte attempt, TimeSpan timeout)
		{
			lock (this.sync)
			{
				// Create a state for this request.
				RequestState state = new RequestState()
				{
					Type = type,
					Flow = flow,
					TimeToLive = ttl,
					Attempt = attempt,
					Timestamp = DateTime.Now,
					Timeout = timeout
				};

				// If the request table is empty.
				if (this.requests.Count == 0)
				{
					// Reset the wait handle.
					this.wait.Reset();
				}

				// Add the state to the request table.
				this.requests.Add(state);

				return state;
			}
		}

		/// <summary>
		/// Removes a request from the request list.
		/// </summary>
		/// <param name="type">The request type.</param>
		/// <param name="flow">The flow.</param>
		/// <param name="ttl">The TTL.</param>
		/// <param name="attempt">The attempt.</param>
		internal void RemoveRequest(RequestType type, byte flow, byte ttl, byte attempt)
		{
			lock (this.sync)
			{
				// Create a state for this request.
				RequestState state = new RequestState()
				{
					Type = type,
					Flow = flow,
					TimeToLive = ttl,
					Attempt = attempt,
					Timestamp = DateTime.MinValue,
					Timeout = TimeSpan.Zero
				};

				// Remove the request.
				this.requests.Remove(state);

				// If the requests table is empty.
				if (this.requests.Count == 0)
				{
					// Set the wait handle.
					this.wait.Set();
				}
			}
		}

		/// <summary>
		/// Tries to get the flow with the specified ICMP identifier.
		/// </summary>
		/// <param name="id">The flow identifier.</param>
		/// <param name="flow">The flow index.</param>
		/// <returns><b>True</b> if the value was found, <b>false</b> otherwise.</returns>
		internal bool TryGetIcmpFlow(ushort id, out byte flow)
		{
			return this.flowsIcmpId.TryGetValue(id, out flow);
		}

		/// <summary>
		/// Tries to get the flow with the specified UDP identifier.
		/// </summary>
		/// <param name="id">The flow identifier.</param>
		/// <param name="flow">The flow index.</param>
		/// <returns><b>True</b> if the value was found, <b>false</b> otherwise.</returns>
		internal bool TryGetUdpFlow(ushort id, out byte flow)
		{
			return this.flowsUdpId.TryGetValue(id, out flow);
		}

		/// <summary>
		/// Sets the ICMP data when a request was sent.
		/// </summary>
		/// <param name="flow">The flow.</param>
		/// <param name="ttl">The TTL.</param>
		/// <param name="attempt">The attempt.</param>
		/// <param name="timestamp">The request timestamp.</param>
		internal void IcmpDataRequestSent(byte flow, byte ttl, byte attempt, DateTime timestamp)
		{
			byte ttlIndex = (byte)(ttl - this.settings.MinimumHops);

			this.dataIcmp[flow, ttlIndex, attempt].State = MultipathTracerouteData.DataState.RequestSent;
			this.dataIcmp[flow, ttlIndex, attempt].RequestTimestamp = timestamp;
			this.dataIcmp[flow, ttlIndex, attempt].TimeToLive = ttl;
		}

		/// <summary>
		/// Sets the ICMP data when a response was received.
		/// </summary>
		/// <param name="flow">The flow.</param>
		/// <param name="ttl">The TTL.</param>
		/// <param name="attempt">The attempt.</param>
		/// <param name="type">The response type.</param>
		/// <param name="timestamp">The timestamp.</param>
		/// <param name="packet">The response packet.</param>
		internal void IcmpDataResponseReceived(byte flow, byte ttl, byte attempt, MultipathTracerouteData.ResponseType type, DateTime timestamp, ProtoPacketIp packet)
		{
			byte ttlIndex = (byte)(ttl - this.settings.MinimumHops);

			this.dataIcmp[flow, ttlIndex, attempt].State = MultipathTracerouteData.DataState.ResponseReceived;
			this.dataIcmp[flow, ttlIndex, attempt].ResponseTimestamp = timestamp;
			this.dataIcmp[flow, ttlIndex, attempt].Type = type;
			this.dataIcmp[flow, ttlIndex, attempt].Response = packet;
		}

		/// <summary>
		/// Sets the UDP data when a request was sent.
		/// </summary>
		/// <param name="flow">The flow.</param>
		/// <param name="ttl">The TTL.</param>
		/// <param name="attempt">The attempt.</param>
		/// <param name="timestamp">The request timestamp.</param>
		internal void UdpDataRequestSent(byte flow, byte ttl, byte attempt, DateTime timestamp)
		{
			byte ttlIndex = (byte)(ttl - this.settings.MinimumHops);

			this.dataUdp[flow, ttlIndex, attempt].State = MultipathTracerouteData.DataState.RequestSent;
			this.dataUdp[flow, ttlIndex, attempt].RequestTimestamp = timestamp;
			this.dataUdp[flow, ttlIndex, attempt].TimeToLive = ttl;
		}

		/// <summary>
		/// Sets the UDP data when a response was received.
		/// </summary>
		/// <param name="flow">The flow.</param>
		/// <param name="ttl">The TTL.</param>
		/// <param name="attempt">The attempt.</param>
		/// <param name="type">The response type.</param>
		/// <param name="timestamp">The timestamp.</param>
		/// <param name="packet">The response packet.</param>
		internal void UdpDataResponseReceived(byte flow, byte ttl, byte attempt, MultipathTracerouteData.ResponseType type, DateTime timestamp, ProtoPacketIp packet)
		{
			byte ttlIndex = (byte)(ttl - this.settings.MinimumHops);

			this.dataUdp[flow, ttlIndex, attempt].State = MultipathTracerouteData.DataState.ResponseReceived;
			this.dataUdp[flow, ttlIndex, attempt].ResponseTimestamp = timestamp;
			this.dataUdp[flow, ttlIndex, attempt].Type = type;
			this.dataUdp[flow, ttlIndex, attempt].Response = packet;
		}

		/// <summary>
		/// Computes the statistics for the ICMP data.
		/// </summary>
		internal void ProcessIcmpStatistics()
		{
			this.ProcessStatistics(this.dataIcmp, this.statIcmp);
		}

		/// <summary>
		/// Computes the statistics for the UDP data.
		/// </summary>
		internal void ProcessUdpStatistics()
		{
			this.ProcessStatistics(this.dataUdp, this.statUdp);
		}

		/// <summary>
		/// Computes the statistics for the specified data.
		/// </summary>
		/// <param name="data">The data array.</param>
		/// <param name="stat">The statistics array.</param>
		internal void ProcessStatistics(MultipathTracerouteData[, ,] data, MultipathTracerouteStatistics[,] stat)
		{
			// For each flow.
			for (byte flow = 0; flow < this.settings.FlowCount; flow++)
			{
				// For each attempt.
				for (byte attempt = 0; attempt < this.settings.AttemptsPerFlow; attempt++)
				{
					// The completed flag.
					bool completed = false;

					// For each time-to-live.
					for (byte ttl = 0; (ttl < this.settings.MaximumHops - this.settings.MinimumHops + 1) && (!completed); ttl++)
					{
						if (data[flow, ttl, attempt].State == MultipathTracerouteData.DataState.ResponseReceived)
						{
							// Set the maximum time-to-live.
							stat[flow, attempt].MaximumTimeToLive = data[flow, ttl, attempt].TimeToLive;
							// Set the completed.
							completed = (data[flow, ttl, attempt].Type == MultipathTracerouteData.ResponseType.EchoReply) ||
								(data[flow, ttl, attempt].Type == MultipathTracerouteData.ResponseType.DestinationUnreachable);
						}
					}

					// Set the state.
					stat[flow, attempt].State = completed ? MultipathTracerouteStatistics.StatisticsState.Completed : MultipathTracerouteStatistics.StatisticsState.Unreachable;
				}
			}
		}

		#endregion
	}
}
