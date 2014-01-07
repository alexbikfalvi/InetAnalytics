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
using System.Net.NetworkInformation;
using DotNetApi.Async;

namespace InetApi.Net.Core
{
	/// <summary>
	/// A class representing a traceroute asynchronous state.
	/// </summary>
	public class TracerouteState : AsyncState
	{
		private readonly Socket socketSend;
		private readonly Socket socketRecv;

		/// <summary>
		/// Creates a new traceroute asynchronous state, bound to the specified local address.
		/// </summary>
		/// <param name="localAddress">The local address.</param>
		public TracerouteState(IPAddress localAddress, object state)
			: base(state)
		{
			// Create the sending socket.
			this.socketSend = new Socket(localAddress.AddressFamily, SocketType.Raw, ProtocolType.Icmp);
			this.socketSend.Bind(new IPEndPoint(localAddress, 0));

			// Create the receiving socket.
			this.socketRecv = new Socket(localAddress.AddressFamily, SocketType.Raw, ProtocolType.Icmp);
			this.socketRecv.Bind(new IPEndPoint(localAddress, 0));
		}

		// Internal properties.

		// Protected methods.

		/// <summary>
		/// Disposes the current object.
		/// </summary>
		/// <param name="disposing">If <b>true</b>, clean both managed and native resources. If <b>false</b>, clean only native resources.</param>
		protected override void Dispose(bool disposing)
		{
			// Dispose the sockets.
			if (disposing)
			{
				this.socketSend.Dispose();
				this.socketRecv.Dispose();
			}

			// Call the base class method.
			base.Dispose(disposing);
		}
	}
}
