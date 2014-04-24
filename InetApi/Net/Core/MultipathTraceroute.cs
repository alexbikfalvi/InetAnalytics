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
using System.Net.Sockets;
using System.Threading;
using DotNetApi;
using InetApi.Net.Core.Protocols;

namespace InetApi.Net.Core
{
	/// <summary>
	/// A delegate used for traceroute callback methods.
	/// </summary>
	/// <param name="result">The multipath traceroute result.</param>
	public delegate void MultipathTracerouteCallback(MultipathTracerouteResult result, MultipathTracerouteState state);

	/// <summary>
	/// A class representing a multipath traceroute.
	/// </summary>
	public sealed class MultipathTraceroute : IDisposable
	{
		private readonly MultipathTracerouteSettings settings;

		private const byte bufferCount = 16;
		private const ushort bufferSize = 1024;

		private const int requestsTimeout = 5000;

		private readonly byte[] bufferSend = new byte[MultipathTraceroute.bufferSize];
		private readonly byte[][] bufferRecv = new byte[MultipathTraceroute.bufferCount][];
		private readonly ManualResetEvent bufferWait = new ManualResetEvent(true);
		private readonly Queue<int> bufferQueue = new Queue<int>(MultipathTraceroute.bufferCount);

		private readonly HashSet<MultipathTracerouteResult> results = new HashSet<MultipathTracerouteResult>();

		private readonly Timer timer;

		private readonly object syncBuffer = new object();
		private readonly object syncResults = new object();

		/// <summary>
		/// Creates a new multipath traceroute with the specified settings.
		/// </summary>
		/// <param name="settings">The settings.</param>
		public MultipathTraceroute(MultipathTracerouteSettings settings)
		{
			// Validate the settings.
			if ((settings.AttemptsPerFlow == 0) || (settings.AttemptsPerFlow > 255))
				throw new ArgumentException("The maximum attempts per flow is invalid (1..255).");
			if ((settings.FlowCount == 0) || (settings.FlowCount > 255))
				throw new ArgumentException("The maximum flow count is invalid (1..255).");
			if (settings.MinimumHops == 0)
				throw new ArgumentException("The minimum hops count is invalid (1..255).");
			if (settings.MaximumHops == 0)
				throw new ArgumentException("The maximum hops count is invalid (1..255).");
			if (settings.MaximumUnknownHops == 0)
				throw new ArgumentException("The maximum unknown hops count is invalid (1..255).");
			if ((settings.DataLength == 0) || (settings.DataLength > 1024))
				throw new ArgumentException("The data length is invalid (1..1024).");

			// Set the settings.
			this.settings = settings;

			// Global parameters.
			ProtoPacketIcmp.IgnoreChecksum = true;

			// Initialize the receiving buffers.
			for (int index = 0; index < MultipathTraceroute.bufferCount; index++)
			{
				this.bufferRecv[index] = new byte[MultipathTraceroute.bufferSize];
				this.bufferQueue.Enqueue(index);
			}

			// Create the timer.
			this.timer = new Timer((object state) =>
			{
				lock (this.syncResults)
				{
					// For all results.
					foreach (MultipathTracerouteResult result in this.results)
					{
						// Call the result timeout method.
						result.Timeout();
					}
				}
			}, null, TimeSpan.Zero, TimeSpan.FromMilliseconds(MultipathTraceroute.requestsTimeout));
		}

		#region Public methods

		/// <summary>
		/// Disposes the current object.
		/// </summary>
		public void Dispose()
		{
			// Dispose the member objects.
			this.bufferWait.Dispose();
			this.timer.Dispose();
			// Suppress the finalizer.
			GC.SuppressFinalize(this);
		}

		/// <summary>
		/// Runs a multipath traceroute to the specified destination.
		/// </summary>
		/// <param name="localAddress">The local IP address.</param>
		/// <param name="remoteAddress">The remote IP address.</param>
		/// <param name="cancel">The cancellation token.</param>
		/// <param name="callback">The callback method.</param>
		/// <returns>The result of the traceroute operation.</returns>
		public MultipathTracerouteResult RunIpv4(IPAddress localAddress, IPAddress remoteAddress, CancellationToken cancel, MultipathTracerouteCallback callback)
		{
			// Validate the arguments.
			if (null == localAddress) throw new ArgumentNullException("localAddress");
			if (null == remoteAddress) throw new ArgumentNullException("remoteAddress");
			if (localAddress.AddressFamily != remoteAddress.AddressFamily) throw new ArgumentException("The local and remote addresses have a different address family.");
			if (localAddress.AddressFamily != AddressFamily.InterNetwork) throw new ArgumentException("Unsupported address family.");

			// Create the traceroute result.
			using (MultipathTracerouteResult result = new MultipathTracerouteResult(localAddress, remoteAddress, this.settings, callback))
			{
				// Add the result to the list of result.
				lock (this.syncResults)
				{
					this.results.Add(result);
				}

				// Create the local end-point.
				IPEndPoint localEndPoint = new IPEndPoint(localAddress, 0);
				IPEndPoint remoteEndPoint = new IPEndPoint(remoteAddress, 0);

				// Create a receiving socket.
				using (Socket socketRecv = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.IP))
				{
					// Bind the socket to the local address.
					socketRecv.Bind(localEndPoint);

					// Indicate the IP header included by the application.
					socketRecv.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.HeaderIncluded, true);

					// Set the control code for receiving all packets.
					socketRecv.IOControl(IOControlCode.ReceiveAll, new byte[4] { 1, 0, 0, 0 }, new byte[4] { 1, 0, 0, 0 });

					// Wait for packets.
					this.ReceivePacket(socketRecv, cancel, result);

					// Create a sending socket.
					using (Socket socketSend = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.IPv4))
					{
						// Bind the socket to the local address.
						socketSend.Bind(localEndPoint);

						// Indicate the IP header included by the application.
						socketSend.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.HeaderIncluded, true);

						// Run the traceroute using ICMP.
						this.RunIcmpv4(localEndPoint, remoteEndPoint, socketSend, cancel, result);

						// Run the traceroute using UDP.
						//this.RunUdp(localAddress, remoteAddress, socketSend, cancel, callback, result);
					}
				}

				// Remove the result from the results list.
				lock (this.syncResults)
				{
					this.results.Remove(result);
				}
			}

			return null;
		}

		#endregion

		#region Private methods

		/// <summary>
		/// Runs the traceroute using ICMP version 4.
		/// </summary>
		/// <param name="localEndPoint">The local end point.</param>
		/// <param name="remoteEndPoint">The remote end point.</param>
		/// <param name="socket">The sending socket.</param>
		/// <param name="cancel">The cancellation token.</param>
		/// <param name="result">The result.</param>
		private void RunIcmpv4(IPEndPoint localEndPoint, IPEndPoint remoteEndPoint, Socket socket, CancellationToken cancel, MultipathTracerouteResult result)
		{
			// The data payload.
			byte[] data = new byte[this.settings.DataLength];
			for (int index = 2; index < data.Length; index++)
			{
				data[index] = (byte)((index - 2) & 0xFF);
			}

			// Create an ICMP echo request packet.
			ProtoPacketIcmpEchoRequest packetIcmpEchoRequest = new ProtoPacketIcmpEchoRequest(0, 0, data);
			// Create an UDP packet.
			//ProtoPacketUdp packetUdp = new ProtoPacketUdp(10000, 10000, data);
			// Create an IP traceroute option.
			ProtoPacketIpOptionTraceroute packetIpOptionTraceroute = new ProtoPacketIpOptionTraceroute(0, 0, 0, localEndPoint.Address);
			// Create an IP record route option.
			ProtoPacketIpOptionRecordRoute packetIpOptionRecordRoute = new ProtoPacketIpOptionRecordRoute(ProtoPacketIpOptionRecordRoute.maxSize);
			// Create an IP version 4 packet.
			ProtoPacketIp packetIp = new ProtoPacketIp(localEndPoint.Address, remoteEndPoint.Address, packetIcmpEchoRequest);

			// Begin the ICMP measurements.
			result.Callback(MultipathTracerouteState.StateType.BeginIcmp);

			// For each attempt.
			for (byte attempt = 0; attempt < settings.AttemptsPerFlow; attempt++)
			{
				// For each flow.
				for (byte flow = 0; flow < result.Flows.Length; flow++)
				{
					// Call the start flow handler.
					result.Callback(MultipathTracerouteState.StateType.BeginFlow, flow);

					// Set the ICMP packet identifier.
					packetIcmpEchoRequest.Identifier = result.Flows[flow].IcmpId;

					// For each time-to-live.
					for (byte ttl = this.settings.MinimumHops; ttl <= this.settings.MaximumHops; ttl++)
					{
						// Call the begin time-to-live.
						result.Callback(MultipathTracerouteState.StateType.BeginTtl, ttl);

						// Set the packet TTL.
						packetIp.TimeToLive = ttl;

						// Set the ICMP packet sequence number.
						packetIcmpEchoRequest.Sequence = (ushort)((ttl << 8) | attempt);

						// Compute the ICMP data to set the checksum.
						int checksumDiff = (ushort)(~result.Flows[flow].IcmpChecksum & 0xFFFF) + ProtoPacket.ChecksumOneComplement16Bit(data, 2, data.Length - 2,
							(ushort)((packetIcmpEchoRequest.Type << 8) | packetIcmpEchoRequest.Code),
							packetIcmpEchoRequest.Identifier,
							packetIcmpEchoRequest.Sequence);
						checksumDiff = ((checksumDiff >> 16) + (checksumDiff & 0xFFFF)) & 0xFFFF;

						// Set the data checksum difference.
						data[0] = (byte)(checksumDiff >> 8);
						data[1] = (byte)(checksumDiff & 0xFF);

						// Write the packet to the buffer.
						packetIp.Write(bufferSend, 0);

						try
						{
							// Send a packet.
							socket.SendTo(bufferSend, (int)packetIp.Length, SocketFlags.None, remoteEndPoint);

							// Add the request.
							MultipathTracerouteResult.RequestState state = result.AddRequest(MultipathTracerouteResult.RequestType.Icmp, flow, ttl, attempt, TimeSpan.FromMilliseconds(this.settings.HopTimeout));

							// Set the data.
							result.IcmpDataRequestSent(flow, ttl, attempt, state.Timestamp);
						}
						catch { }

						// Call the end time-to-live.
						result.Callback(MultipathTracerouteState.StateType.EndTtl, ttl);
					}

					// Wait before beginning the next attempt.
					Thread.Sleep(this.settings.AttemptDelay);

					// Call the end flow handler.
					result.Callback(MultipathTracerouteState.StateType.EndFlow, flow);
				}
			}

			// Wait for the result to complete.
			result.Wait.WaitOne();

			// End the ICMP measurements.
			result.Callback(MultipathTracerouteState.StateType.EndIcmp);
		}

		/// <summary>
		/// Requests a receiving buffer. The method blocks until a buffer is available or until the cancellation is requested.
		/// </summary>
		/// <param name="cancel">The cancellation token.</param>
		/// <returns>The buffer index.</returns>
		private int RequestBuffer(CancellationToken cancel)
		{
			// The buffer index.
			int bufferIndex = -1;

			do
			{
				// Wait for a buffer to become available.
				this.bufferWait.WaitOne();

				lock (this.syncBuffer)
				{
					// If the buffer queue is not empty.
					if (this.bufferQueue.Count > 0)
					{
						// Get the first buffer index.
						bufferIndex = this.bufferQueue.Dequeue();

						// If the queue is empty, reset the buffer wait handle.
						if (this.bufferQueue.Count == 0) this.bufferWait.Reset();
					}
				}
			}
			while ((bufferIndex == -1) && (!cancel.IsCancellationRequested));

			// Return the buffer index.
			return bufferIndex;
		}

		/// <summary>
		/// Releases the specified buffer.
		/// </summary>
		/// <param name="bufferIndex">The buffer index.</param>
		private void ReleaseBuffer(int bufferIndex)
		{
			// Release the buffer.
			lock (this.syncBuffer)
			{
				// If the buffer queue is empty, set the buffer wait handle.
				if (this.bufferQueue.Count == 0) this.bufferWait.Set();

				// Add the buffer index to the queue.
				this.bufferQueue.Enqueue(bufferIndex);
			}
		}

		/// <summary>
		/// Receives a packet from the specified socket.
		/// </summary>
		/// <param name="socket">The socket.</param>
		/// <param name="cancel">The cancellation token.</param>
		/// <param name="result">The result.</param>
		private void ReceivePacket(Socket socket, CancellationToken cancel, MultipathTracerouteResult result)
		{
			// The remote end-point.
			EndPoint endPoint = new IPEndPoint(IPAddress.Any, 0);

			// Request a buffer.
			int bufferIndex = this.RequestBuffer(cancel);

			// If the operation was canceled, return.
			if (cancel.IsCancellationRequested) return;

			// Synchronization object.
			object localSync = new object();

			// Buffer flag.
			bool bufferFlag = true;

			try
			{
				// Begin receiving a packet.
				socket.BeginReceiveFrom(this.bufferRecv[bufferIndex], 0, this.bufferRecv[bufferIndex].Length, SocketFlags.None, ref endPoint, (IAsyncResult asyncResult) =>
					{
						lock (localSync)
						{
							try
							{
								// End receiving a packet.
								int length = socket.EndReceiveFrom(asyncResult, ref endPoint);

								// Process the packet.
								this.ProcessPacket(this.bufferRecv[bufferIndex], length, result);
							}
							catch (Exception) { }
							finally
							{
								// If the buffer flag is set.
								if (bufferFlag)
								{
									// Release the buffer.
									this.ReleaseBuffer(bufferIndex);
									// Begin receiving the next packet.
									this.ReceivePacket(socket, cancel, result);
									// Set the flag to false.
									bufferFlag = false;
								}
							}
						}
					}, null);
			}
			catch (ObjectDisposedException) { }
			catch (Exception)
			{
				lock (localSync)
				{
					// If the buffer flag is set.
					if (bufferFlag)
					{
						// Release the buffer.
						this.ReleaseBuffer(bufferIndex);
						// Begin receiving the next packet.
						this.ReceivePacket(socket, cancel, result);
						// Set the flag to false.
						bufferFlag = false;
					}
				}
			}
		}

		/// <summary>
		/// Processes a received packet.
		/// </summary>
		/// <param name="buffer">The data buffer.</param>
		/// <param name="length">The data length.</param>
		/// <param name="result">The result.</param>
		private void ProcessPacket(byte[] buffer, int length, MultipathTracerouteResult result)
		{
			try
			{
				// Set the buffer index.
				int index = 0;
				// The packets.
				ProtoPacketIp ip;
				ProtoPacketIcmp icmp;

				// Try and parse the packet using the specified filter.
				if (ProtoPacketIp.ParseFilter(buffer, ref index, length, result.PacketFilters, out ip))
				{
					// Call the callback methods.
					result.Callback(MultipathTracerouteState.StateType.PacketCapture, ip);

					// If the packet payload is ICMP.
					if ((icmp = ip.Payload as ProtoPacketIcmp) != null)
					{
						// If the packet type is ICMP echo reply.
						if (icmp.Type == (byte)ProtoPacketIcmp.IcmpType.EchoReply)
						{
							ProtoPacketIcmpEchoReply icmpEchoReply = icmp as ProtoPacketIcmpEchoReply;

							// Use the reply identifier to find the flow.
							byte flow;
							if (result.TryGetIcmpFlow(icmpEchoReply.Identifier, out flow))
							{
								// Get the time-to-live.
								byte ttl = (byte)(icmpEchoReply.Sequence >> 8);
								// Get the attempt.
								byte attempt = (byte)(icmpEchoReply.Sequence & 0xFF);

								// Add the result.
								result.IcmpDataResponseReceived(flow, ttl, attempt, MultipathTracerouteData.ResponseType.EchoReply, ip.SourceAddress, DateTime.Now);

								// Remove the corresponding request.
								result.RemoveRequest(MultipathTracerouteResult.RequestType.Icmp, flow, ttl, attempt);
							}
						}
						else if (icmp.Type == (byte)ProtoPacketIcmp.IcmpType.TimeExceeded)
						{
							ProtoPacketIcmpTimeExceeded icmpTimeExceeded = icmp as ProtoPacketIcmpTimeExceeded;

							// Use the IP payload to find the flow.
							ushort flowId = (ushort)((icmpTimeExceeded.IpPayload[4] << 8) | icmpTimeExceeded.IpPayload[5]);
							byte flow;
							if (result.TryGetIcmpFlow(flowId, out flow))
							{
								// Get the time-to-live.
								byte ttl = icmpTimeExceeded.IpPayload[6];
								// Get the attempt.
								byte attempt = icmpTimeExceeded.IpPayload[7];

								// Add the result.
								result.IcmpDataResponseReceived(flow, ttl, attempt, MultipathTracerouteData.ResponseType.TimeExceeded, ip.SourceAddress, DateTime.Now);

								// Remove the corresponding request.
								result.RemoveRequest(MultipathTracerouteResult.RequestType.Icmp, flow, ttl, attempt);
							}
						}
					}
				}
			}
			catch (Exception exception)
			{
				// Ignore all errors for received packets.
				result.Callback(MultipathTracerouteState.StateType.PacketError, exception);
			}
		}

		#endregion
	}
}
