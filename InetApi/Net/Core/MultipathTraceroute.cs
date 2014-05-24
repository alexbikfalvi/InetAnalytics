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
		/// <summary>
		/// An enumeration representing the multipath algorithm.
		/// </summary>
		public enum MultipathAlgorithm
		{
			Icmp = 0x1,
			Udp = 0x8,
			UdpType = 0x6,
			UdpIdentification = 0xA,
			UdpChecksum = 0xC,
			UdpTest = 0x10
		}

		/// <summary>
		/// An event handler for the packet processing method.
		/// </summary>
		/// <param name="ip">The IP packet.</param>
		/// <param name="length">The data length.</param>
		/// <param name="result">The result.</param>
		private delegate void ProcessPacketHandler(ProtoPacketIp ip, int length, MultipathTracerouteResult result);

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
		private readonly object syncProcess = new object();

		private ProcessPacketHandler processPacket = null;

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
			if (settings.MinimumHops >= settings.MaximumHops)
				throw new ArgumentException("The minimum hops must be smaller than the maximum hops.");
			if (settings.MaximumUnknownHops == 0)
				throw new ArgumentException("The maximum unknown hops count is invalid (1..255).");
			if ((settings.DataLength == 0) || (settings.DataLength > 1024))
				throw new ArgumentException("The data length is invalid (1..1024).");
			if ((settings.MinimumPort < 1024) || (settings.MinimumPort > 65520))
				throw new ArgumentException("The minimum port is invalid (1024..65520).");
			if ((settings.MaximumPort < 1024) || (settings.MaximumPort > 65520))
				throw new ArgumentException("The maximum port is invalid (1024..65520).");
			if (settings.MinimumPort >= settings.MaximumPort)
				throw new ArgumentException("The minimum port must be smaller than the maximum port.");
			if (settings.DataLength < 2)
				throw new ArgumentException("The minimum data length is 2.");

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

						if ((this.settings.Algorithm & MultipathAlgorithm.Icmp) != 0)
						{
							// Run the traceroute using ICMP.
							this.RunIcmpv4(localEndPoint, remoteEndPoint, socketSend, cancel, result);
						}

						if ((this.settings.Algorithm & MultipathAlgorithm.Udp) != 0)
						{
							// Run the traceroute using UDP.
							this.RunUdpv4(localEndPoint, remoteEndPoint, socketSend, cancel, result, MultipathAlgorithm.Udp);
						}

						if ((this.settings.Algorithm & MultipathAlgorithm.UdpTest) != 0)
						{
							// Run the traceroute for the UDP test.
							this.RunUdpv4(localEndPoint, remoteEndPoint, socketSend, cancel, result, MultipathAlgorithm.UdpTest);
						}
					}
				}

				// Remove the result from the results list.
				lock (this.syncResults)
				{
					this.results.Remove(result);
				}

				return result;
			}
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
			// Set the packet processing delegate.
			lock (this.syncProcess)
			{
				this.processPacket = this.ProcessPacketIcmp;
			}

			// The data payload.
			byte[] data = new byte[this.settings.DataLength];
			for (int index = 2; index < data.Length; index++)
			{
				data[index] = (byte)((index - 2) & 0xFF);
			}

			// Create an ICMP echo request packet.
			ProtoPacketIcmpEchoRequest packetIcmpEchoRequest = new ProtoPacketIcmpEchoRequest(0, 0, data);
			// Create an IP traceroute option.
			//ProtoPacketIpOptionTraceroute packetIpOptionTraceroute = new ProtoPacketIpOptionTraceroute(0, 0, 0, localEndPoint.Address);
			// Create an IP record route option.
			//ProtoPacketIpOptionRecordRoute packetIpOptionRecordRoute = new ProtoPacketIpOptionRecordRoute(ProtoPacketIpOptionRecordRoute.maxSize);
			// Create an IP version 4 packet.
			ProtoPacketIp packetIp = new ProtoPacketIp(localEndPoint.Address, remoteEndPoint.Address, packetIcmpEchoRequest);

			// Begin the ICMP measurements.
			result.Callback(MultipathTracerouteState.StateType.BeginAlgorithm, MultipathAlgorithm.Icmp);

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

                    for (byte retry = 0; (retry < this.settings.MaximumRetries) && (!result.IsIcmpDataComplete(flow, attempt)); retry++)
                    {
                        // If the retry is greater than zero, wait a random time.
                        if (retry > 0)
                        {
                            // Wait before beginning the next attempt.
                            Thread.Sleep(this.settings.RetryDelay);
                        }

                        // For each time-to-live.
                        for (byte ttl = this.settings.MinimumHops; ttl <= this.settings.MaximumHops; ttl++)
                        {
                            // If the response was received for this flow, TTL and attempt, skip.
                            if (result.IsIcmpDataResponseReceived(flow, ttl, attempt))
                                continue;

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
                    }
                    // Call the end flow handler.
					result.Callback(MultipathTracerouteState.StateType.EndFlow, flow);

                    // Wait before beginning the next attempt.
                    Thread.Sleep(this.settings.AttemptDelay);
				}
			}

			// Wait for the result to complete.
			result.Wait.WaitOne();

			// Process the result statistics.
			result.ProcessStatistics(MultipathTracerouteResult.ResultAlgorithm.Icmp);

			// End the ICMP measurements.
			result.Callback(MultipathTracerouteState.StateType.EndAlgorithm, MultipathAlgorithm.Icmp);

			// Clear the packet processing delegate.
			lock (this.syncProcess)
			{
				this.processPacket = null;
			}
		}

		/// <summary>
		/// Runs the traceroute using UDP over IP version 4.
		/// </summary>
		/// <param name="localEndPoint">The local end point.</param>
		/// <param name="remoteEndPoint">The remote end point.</param>
		/// <param name="socket">The sending socket.</param>
		/// <param name="cancel">The cancellation token.</param>
		/// <param name="result">The result.</param>
		/// <param name="algorithm">The multipath algorithm.</param>
		private void RunUdpv4(IPEndPoint localEndPoint, IPEndPoint remoteEndPoint, Socket socket, CancellationToken cancel, MultipathTracerouteResult result, MultipathAlgorithm algorithm)
		{
			// The request type.
			MultipathTracerouteResult.RequestType requestType = MultipathTracerouteResult.RequestType.None;

			if ((this.settings.Algorithm & MultipathAlgorithm.UdpType & MultipathAlgorithm.UdpIdentification) != 0)
			{
				// Set the request type.
				requestType = requestType | MultipathTracerouteResult.RequestType.UdpIdentification;
			}
			if ((this.settings.Algorithm & MultipathAlgorithm.UdpType & MultipathAlgorithm.UdpChecksum) != 0)
			{
				// Set the request type.
				requestType = requestType | MultipathTracerouteResult.RequestType.UdpChecksum;
			}
			if ((this.settings.Algorithm & MultipathAlgorithm.UdpTest) != 0)
			{
				// Set the request type.
				requestType = MultipathTracerouteResult.RequestType.UdpBoth;
			}

			// Set the packet processing delegate
			lock (this.syncProcess)
			{
				if ((requestType & MultipathTracerouteResult.RequestType.UdpIdentification) != 0)
					this.processPacket = this.ProcessPacketUdpIdentification;
				else
					this.processPacket = this.ProcessPacketUdpChecksum;
			}

			// The data payload.
			byte[] data = new byte[this.settings.DataLength];
			for (int index = 2; index < data.Length; index++)
			{
				data[index] = (byte)((index - 2) & 0xFF);
			}

			// Create an UDP packet.
			ProtoPacketUdp packetUdp = new ProtoPacketUdp(0, 0, data);
			// Create an IP version 4 packet.
			ProtoPacketIp packetIp = new ProtoPacketIp(localEndPoint.Address, remoteEndPoint.Address, packetUdp);

			packetIp.DifferentiatedServices = 0x80;

			// Begin the UDP measurements.
			result.Callback(MultipathTracerouteState.StateType.BeginAlgorithm, algorithm);

			// For each attempt.
			for (byte attempt = 0; attempt < settings.AttemptsPerFlow; attempt++)
			{
				// For each flow.
				for (byte flow = 0; flow < result.Flows.Length; flow++)
				{
					// Call the start flow handler.
					result.Callback(MultipathTracerouteState.StateType.BeginFlow, flow);

					// Set the UDP packet source port.
					packetUdp.SourcePort = result.Flows[flow].UdpSourcePort;
					// Set the UDP packet destination port.
					packetUdp.DestinationPort = result.Flows[flow].UdpDestinationPort;

                    for (byte retry = 0; (retry < this.settings.MaximumRetries) && (!result.IsUdpDataComplete(flow, attempt)); retry++)
                    {
                        // If the retry is greater than zero, wait a random time.
                        if (retry > 0)
                        {
                            // Wait before beginning the next attempt.
                            Thread.Sleep(this.settings.RetryDelay);
                        }

                        // For each time-to-live.
                        for (byte ttl = this.settings.MinimumHops; ttl <= this.settings.MaximumHops; ttl++)
                        {
                            // If the response was received for this flow, TTL and attempt, skip.
                            if (result.IsUdpDataResponseReceived(flow, ttl, attempt))
                                continue;

                            // Call the begin time-to-live.
                            result.Callback(MultipathTracerouteState.StateType.BeginTtl, ttl);

                            // Set the packet TTL.
                            packetIp.TimeToLive = ttl;

                            if ((requestType & MultipathTracerouteResult.RequestType.UdpIdentification) != 0)
                            {
                                // Set the packet identification.
                                packetIp.Identification = (ushort)((ttl << 8) | attempt);
                            }

                            if ((requestType & MultipathTracerouteResult.RequestType.UdpChecksum) != 0)
                            {
                                // Compute the UDP data to set the checksum.
                                ushort checksum = (ushort)((ttl << 8) | attempt);
                                int checksumDiff = (ushort)(~checksum & 0xFFFF) + ProtoPacket.ChecksumOneComplement16Bit(data, 2, data.Length - 2,
                                    packetUdp.SourcePort,
                                    packetUdp.DestinationPort,
                                    packetUdp.Length,
                                    (ushort)((packetIp.SourceAddressBytes[0] << 8) | packetIp.SourceAddressBytes[1]),
                                    (ushort)((packetIp.SourceAddressBytes[2] << 8) | packetIp.SourceAddressBytes[3]),
                                    (ushort)((packetIp.DestinationAddressBytes[0] << 8) | packetIp.DestinationAddressBytes[1]),
                                    (ushort)((packetIp.DestinationAddressBytes[2] << 8) | packetIp.DestinationAddressBytes[3]),
                                    packetIp.Protocol,
                                    packetUdp.Length);
                                checksumDiff = ((checksumDiff >> 16) + (checksumDiff & 0xFFFF)) & 0xFFFF;

                                // Set the data checksum difference.
                                data[0] = (byte)(checksumDiff >> 8);
                                data[1] = (byte)(checksumDiff & 0xFF);
                            }

                            // Write the packet to the buffer.
                            packetIp.Write(bufferSend, 0);

                            try
                            {
                                // Send a packet.
                                socket.SendTo(bufferSend, (int)packetIp.Length, SocketFlags.None, remoteEndPoint);

                                // Add the request.
                                MultipathTracerouteResult.RequestState state = result.AddRequest(MultipathTracerouteResult.RequestType.Udp, flow, ttl, attempt, TimeSpan.FromMilliseconds(this.settings.HopTimeout));

                                // Set the data.
                                result.UdpDataRequestSent(flow, ttl, attempt, state.Timestamp);
                            }
                            catch { }

                            // Call the end time-to-live.
                            result.Callback(MultipathTracerouteState.StateType.EndTtl, ttl);
                        }
                    }
                    // Call the end flow handler.
                    result.Callback(MultipathTracerouteState.StateType.EndFlow, flow);

                    // Wait before beginning the next attempt.
                    Thread.Sleep(this.settings.AttemptDelay);
                }
			}

			// Wait for the result to complete.
			result.Wait.WaitOne();

			// Process the result statistics.
			result.ProcessStatistics(MultipathTracerouteResult.ResultAlgorithm.Udp);

			// End the UDP measurements.
			result.Callback(MultipathTracerouteState.StateType.EndAlgorithm, algorithm);

			// Clear the packet processing delegate.
			lock (this.syncProcess)
			{
				this.processPacket = null;
			}
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
							catch (ObjectDisposedException) { }
							catch (Exception exception)
							{
								// Ignore all errors for received packets.
								result.Callback(MultipathTracerouteState.StateType.PacketError, exception);
							}
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
			// Set the buffer index.
			int index = 0;
			// The packets.
			ProtoPacketIp ip;

			// Try and parse the packet using the specified filter.
			if (ProtoPacketIp.ParseFilter(buffer, ref index, length, result.PacketFilters, out ip))
			{
				// Call the callback methods.
				result.Callback(MultipathTracerouteState.StateType.PacketCapture, ip);

				// Process the packet for the current protocol.
				lock (this.syncProcess)
				{
					if (null != this.processPacket) this.processPacket(ip, length, result);
				}
			}
		}

		/// <summary>
		/// Processes a received packet for an ICMP request.
		/// </summary>
		/// <param name="ip">The IP packet.</param>
		/// <param name="length">The data length.</param>
		/// <param name="result">The result.</param>
		private void ProcessPacketIcmp(ProtoPacketIp ip, int length, MultipathTracerouteResult result)
		{
			ProtoPacketIcmp icmp;

			// If the packet payload is ICMP.
			if ((icmp = ip.Payload as ProtoPacketIcmp) != null)
			{
				if (icmp.Type == (byte)ProtoPacketIcmp.IcmpType.EchoReply)
				{
					// If the packet type is ICMP echo reply.
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
						result.IcmpDataResponseReceived(flow, ttl, attempt, MultipathTracerouteData.ResponseType.EchoReply, DateTime.Now, ip);

						// Remove the corresponding request.
						result.RemoveRequest(MultipathTracerouteResult.RequestType.Icmp, flow, ttl, attempt);
					}
				}
				else if (icmp.Type == (byte)ProtoPacketIcmp.IcmpType.TimeExceeded)
				{
					// If the packet type is ICMP time exceeded.
					ProtoPacketIcmpTimeExceeded icmpTimeExceeded = icmp as ProtoPacketIcmpTimeExceeded;

					// Use the ICMP request identifier to find the flow.
					ushort flowId = (ushort)((icmpTimeExceeded.IpPayload[4] << 8) | icmpTimeExceeded.IpPayload[5]);
					byte flow;
					if (result.TryGetIcmpFlow(flowId, out flow))
					{
						// Get the time-to-live.
						byte ttl = icmpTimeExceeded.IpPayload[6];
						// Get the attempt.
						byte attempt = icmpTimeExceeded.IpPayload[7];

						// Add the result.
						result.IcmpDataResponseReceived(flow, ttl, attempt, MultipathTracerouteData.ResponseType.TimeExceeded, DateTime.Now, ip);

						// Remove the corresponding request.
						result.RemoveRequest(MultipathTracerouteResult.RequestType.Icmp, flow, ttl, attempt);
					}
				}
			}
		}

		/// <summary>
		/// Processes a received packet for a UDP request using the identification field.
		/// </summary>
		/// <param name="ip">The IP packet.</param>
		/// <param name="length">The data length.</param>
		/// <param name="result">The result.</param>
		private void ProcessPacketUdpIdentification(ProtoPacketIp ip, int length, MultipathTracerouteResult result)
		{
			ProtoPacketIcmp icmp;

			// If the packet payload is ICMP.
			if ((icmp = ip.Payload as ProtoPacketIcmp) != null)
			{
				if (icmp.Type == (byte)ProtoPacketIcmp.IcmpType.TimeExceeded)
				{
					// If the packet type is ICMP time exceeded.
					ProtoPacketIcmpTimeExceeded icmpTimeExceeded = icmp as ProtoPacketIcmpTimeExceeded;

					// Use the last bytes of the UDP ports to find the flow.
					ushort flowId = (ushort)((icmpTimeExceeded.IpPayload[1] << 8) | icmpTimeExceeded.IpPayload[3]);
					byte flow;
					if (result.TryGetUdpFlow(flowId, out flow))
					{
						// Get the time-to-live.
						byte ttl = (byte)(icmpTimeExceeded.IpHeader.Identification >> 8);
						// Get the attempt.
						byte attempt = (byte)(icmpTimeExceeded.IpHeader.Identification & 0xF);

						// Add the result.
						result.UdpDataResponseReceived(flow, ttl, attempt, MultipathTracerouteData.ResponseType.TimeExceeded, DateTime.Now, ip);

						// Remove the corresponding request.
						result.RemoveRequest(MultipathTracerouteResult.RequestType.Udp, flow, ttl, attempt);
					}
				}
				else if (icmp.Type == (byte)ProtoPacketIcmp.IcmpType.DestinationUnreachable)
				{
					// If the packet type is ICMP destination unreachable.
					ProtoPacketIcmpDestinationUnreachable icmpDestinationUnreachable = icmp as ProtoPacketIcmpDestinationUnreachable;

					// Check the message is a port unreachable.
					if (icmpDestinationUnreachable.Code == (byte)ProtoPacketIcmpDestinationUnreachable.DestinationUnreachableCode.PortUnreachable)
					{
						// Use the last bytes of the UDP ports to find the flow.
						ushort flowId = (ushort)((icmpDestinationUnreachable.IpPayload[1] << 8) | icmpDestinationUnreachable.IpPayload[3]);
						byte flow;
						if (result.TryGetUdpFlow(flowId, out flow))
						{
							// Get the time-to-live.
							byte ttl = (byte)(icmpDestinationUnreachable.IpHeader.Identification >> 8);
							// Get the attempt.
							byte attempt = (byte)(icmpDestinationUnreachable.IpHeader.Identification & 0xF);

							// Add the result.
							result.UdpDataResponseReceived(flow, ttl, attempt, MultipathTracerouteData.ResponseType.DestinationUnreachable, DateTime.Now, ip);

							// Remove the corresponding request.
							result.RemoveRequest(MultipathTracerouteResult.RequestType.Udp, flow, ttl, attempt);
						}
					}
				}
			}
		}

		/// <summary>
		/// Processes a received packet for a UDP request using the checksum field.
		/// </summary>
		/// <param name="ip">The IP packet.</param>
		/// <param name="length">The data length.</param>
		/// <param name="result">The result.</param>
		private void ProcessPacketUdpChecksum(ProtoPacketIp ip, int length, MultipathTracerouteResult result)
		{
		}

		#endregion
	}
}
