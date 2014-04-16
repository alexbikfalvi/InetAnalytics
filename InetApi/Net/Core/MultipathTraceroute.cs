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
using InetApi.Net.Core.Protocols;

namespace InetApi.Net.Core
{
	/// <summary>
	/// A delegate used for traceroute callback methods.
	/// </summary>
	/// <param name="result">The multipath traceroute result.</param>
	public delegate void MultipathTracerouteCallback(MultipathTracerouteResult result);

	/// <summary>
	/// A class representing a multipath traceroute.
	/// </summary>
	public sealed class MultipathTraceroute
	{
		private readonly MultipathTracerouteSettings settings;

		private const byte bufferCount = 16;
		private const ushort bufferSize = 1024;

		private const int bufferWaitTimeout = 1000;

		private readonly byte[] bufferSend = new byte[MultipathTraceroute.bufferSize];
		private readonly byte[][] bufferRecv = new byte[MultipathTraceroute.bufferCount][];
		private readonly ManualResetEvent bufferWait = new ManualResetEvent(true);
		private readonly Queue<int> bufferQueue = new Queue<int>(MultipathTraceroute.bufferCount);

		private readonly object sync = new object();

		/// <summary>
		/// Creates a new multipath traceroute with the specified settings.
		/// </summary>
		/// <param name="settings">The settings.</param>
		public MultipathTraceroute(MultipathTracerouteSettings settings)
		{
			// Set the settings.
			this.settings = settings;

			// Initialize the receiving buffers.
			for (int index = 0; index < MultipathTraceroute.bufferCount; index++)
			{
				this.bufferRecv[index] = new byte[MultipathTraceroute.bufferSize];
				this.bufferQueue.Enqueue(index);
			}
		}

		#region Public methods

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
			MultipathTracerouteResult result = new MultipathTracerouteResult(localAddress, remoteAddress, this.settings);

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
				this.ReceivePacket(socketRecv, cancel);

				// Create a sending socket.
				using (Socket socketSend = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.IPv4))
				{
					// Bind the socket to the local address.
					socketSend.Bind(localEndPoint);

					// Indicate the IP header included by the application.
					socketSend.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.HeaderIncluded, true);

					// Run the traceroute using ICMP.
					this.RunIcmpv4(localEndPoint, remoteEndPoint, socketSend, cancel, callback, result);

					// Run the traceroute using UDP.
					//this.RunUdp(localAddress, remoteAddress, socketSend, cancel, callback, result);
				}
				// Wait to receive the last packet.
				Thread.Sleep(settings.HopTimeout);
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
		/// <param name="callback">The callback.</param>
		/// <param name="result">The result.</param>
		private void RunIcmpv4(IPEndPoint localEndPoint, IPEndPoint remoteEndPoint, Socket socket, CancellationToken cancel, MultipathTracerouteCallback callback, MultipathTracerouteResult result)
		{
			// The ICMP payload.
			byte[] icmpPayload = new byte[this.settings.DataLength];

			// Create an ICMP echo request packet.
			ProtoPacketIcmpEchoRequest packetIcmpEchoRequest = new ProtoPacketIcmpEchoRequest(1, 1, icmpPayload);
			// Create an IP traceroute option.
			ProtoPacketIpOptionTraceroute packetIpOptionTraceroute = new ProtoPacketIpOptionTraceroute(0, 0, 0, localEndPoint.Address);
			// Create an IP record route option.
			ProtoPacketIpOptionRecordRoute packetIpOptionRecordRoute = new ProtoPacketIpOptionRecordRoute(9);
			// Create an IP version 4 packet.
			ProtoPacketIp packetIp = new ProtoPacketIp(localEndPoint.Address, remoteEndPoint.Address, packetIcmpEchoRequest);

			for (byte ttl = 1; ttl < 20; ttl++)
			{
				// Set the packet time-to-live.
				packetIp.TimeToLive = ttl;

				for (byte flow = 0; flow < 3; flow++)
				{
					// Set the diff serv header.
					packetIp.DifferentiatedServices = (byte)(flow << 3);
					// Set the ICMP data.
					for (int index = 0; index < icmpPayload.Length; index++)
					{
						icmpPayload[index] = flow;
					}
					// Write the packet to the buffer.
					packetIp.Write(bufferSend, 0);

					for (byte attempt = 0; attempt < 3; attempt++)
					{
						// Send a packet.
						socket.SendTo(bufferSend, (int)packetIp.Length, SocketFlags.None, remoteEndPoint);
					}
				}
			}
		}

		/// <summary>
		/// Receives a packet from the specified socket.
		/// </summary>
		/// <param name="socket">The socket.</param>
		/// <param name="cancel">The cancellation token.</param>
		private void ReceivePacket(Socket socket, CancellationToken cancel)
		{
			// The remote end-point.
			EndPoint endPoint = new IPEndPoint(IPAddress.Any, 0);

			// The buffer index.
			int bufferIndex = -1;

			do
			{
				// Wait for a buffer to become available.
				this.bufferWait.WaitOne();

				lock (this.sync)
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

			// If the operation was canceled, return.
			if (cancel.IsCancellationRequested) return;

			try
			{
				// Begin receiving a packet.
				socket.BeginReceiveFrom(this.bufferRecv[bufferIndex], 0, bufferRecv[bufferIndex].Length, SocketFlags.None, ref endPoint, (IAsyncResult asyncResult) =>
					{
						try
						{
							// End receiving a packet.
							int count = socket.EndReceiveFrom(asyncResult, ref endPoint);

							//
							Console.WriteLine("RECV {0} bytes", count);

							// Begin receiving the next packet.
							this.ReceivePacket(socket, cancel);
						}
						catch (Exception exception)
						{

						}
					}, null);
			}
			catch (Exception exception)
			{

			}
		}

		#endregion
	}
}
