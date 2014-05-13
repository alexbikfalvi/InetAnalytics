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

namespace InetApi.Net.Core
{
	/// <summary>
	/// A class representing a multipath traceroute flow.
	/// </summary>
	[Serializable]
    public class MultipathTracerouteFlow
	{
		private readonly byte[] id;

		/// <summary>
		/// Creates a new flow instance.
		/// </summary>
		/// <param name="settings">The settings.</param>
		public MultipathTracerouteFlow(MultipathTracerouteSettings settings)
		{
			// Set the identifier.
			this.Id = Guid.NewGuid();

			// Set the short identifier.
			this.id = this.Id.ToByteArray();
			this.ShortId = 0;
			for (int index = 0; index < this.id.Length - 1; index += 2)
			{
				this.ShortId ^= (ushort)((this.id[index] << 8) | this.id[index + 1]);
			}

			// Set the TTL count.
			this.TtlCount = settings.MaximumHops - settings.MinimumHops + 1;

			// Create the ICMP data.
			this.IcmpData = new MultipathTracerouteData[this.TtlCount, settings.AttemptsPerFlow];
			// Create the UDP data.
			this.UdpData = new MultipathTracerouteData[this.TtlCount, settings.AttemptsPerFlow];
			
			// Compute the UDP source port.
			this.UdpSourcePort = (ushort)((settings.MinimumPort + (settings.MaximumPort - settings.MinimumPort) * (ushort)((this.id[4] << 8) | this.id[5]) / 0x10000) & 0xFFFF);

			// Compute the UDP destination port.
			this.UdpDestinationPort = (ushort)((settings.MinimumPort + (settings.MaximumPort - settings.MinimumPort) * (ushort)((this.id[6] << 8) | this.id[7]) / 0x10000) & 0xFFFF);
		}

		#region Public properties

		/// <summary>
		/// The flow identifier.
		/// </summary>
		public Guid Id { get; private set; }
		/// <summary>
		/// The short flow identifier.
		/// </summary>
		public ushort ShortId { get; private set; }
		/// <summary>
		/// The ICMP identifier.
		/// </summary>
		public ushort IcmpId { get { return (ushort)((this.id[0] << 8) | this.id[1]); } }
		/// <summary>
		/// The ICMP checksum.
		/// </summary>
		public ushort IcmpChecksum { get { return (ushort)((this.id[2] << 8) | this.id[3]); } }
		/// <summary>
		/// The UDP source port.
		/// </summary>
		public ushort UdpSourcePort { get; private set; }
		/// <summary>
		/// The UDP destination port.
		/// </summary>
		public ushort UdpDestinationPort { get; private set; }
		/// <summary>
		/// The UDP identifier.
		/// </summary>
		public ushort UdpId { get { return (ushort)(((this.UdpSourcePort & 0xFF) << 8) | (this.UdpDestinationPort & 0xFF)); } }
		/// <summary>
		/// The TTL count.
		/// </summary>
		public int TtlCount { get; private set; }
		/// <summary>
		/// The ICMP data.
		/// </summary>
		public MultipathTracerouteData[,] IcmpData { get; private set; }
		/// <summary>
		/// The UDP data.
		/// </summary>
		public MultipathTracerouteData[,] UdpData { get; private set; }

		#endregion
	}
}
