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

		/// <summary>
		/// Creates a new multipath traceroute with the specified settings.
		/// </summary>
		/// <param name="settings">The settings.</param>
		public MultipathTraceroute(MultipathTracerouteSettings settings)
		{
			this.settings = settings;
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
		public MultipathTracerouteResult RunIcmpV4(IPAddress localAddress, IPAddress remoteAddress, CancellationToken cancel, MultipathTracerouteCallback callback)
		{
			// Validate the arguments.
			if (null == localAddress) throw new ArgumentNullException("localAddress");
			if (null == remoteAddress) throw new ArgumentNullException("remoteAddress");
			if (localAddress.AddressFamily != remoteAddress.AddressFamily) throw new ArgumentException("The local and remote addresses have a different address family.");
			if (localAddress.AddressFamily != AddressFamily.InterNetwork) throw new ArgumentException("Unsupported address family.");

			// Create the traceroute result.
			MultipathTracerouteResult result = new MultipathTracerouteResult(localAddress, remoteAddress);

			// Create the local end-point.
			IPEndPoint localEndPoint = new IPEndPoint(localAddress, 0);
			IPEndPoint remoteEndPoint = new IPEndPoint(remoteAddress, 0);

			byte[] buffer = new byte[20];

			// Create an IP version 4 packet.
			ProtoPacketIp packet = new ProtoPacketIp(localAddress, remoteAddress);
			packet.Write(buffer, 0);

			// Create a sending socket.
			using (Socket socketSend = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.IPv4))
			{
				// Bind the socket to the local address.
				socketSend.Bind(localEndPoint);

				// Indicate the IP header included by the application.
				socketSend.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.HeaderIncluded, true);

				// Send a packet.
				socketSend.SendTo(buffer, remoteEndPoint);
			}


			return null;
		}

		#endregion
	}
}
