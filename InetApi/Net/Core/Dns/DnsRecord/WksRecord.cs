/* 
 * Copyright (C) 2010-2012 Alexander Reinert
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * 
 *   http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;

namespace ARSoft.Tools.Net.Dns
{
	/// <summary>
	/// <para>Well known services record.</para> <para>Defined in <see cref="!:http://tools.ietf.org/html/rfc1035">RFC 1035</see>.</para>
	/// </summary>
	public class WksRecord : DnsRecordBase
	{
		/// <summary>
		/// Internal constructor.
		/// </summary>
		internal WksRecord() { }

		/// <summary>
		/// Creates a new instance of the WksRecord class.
		/// </summary>
		/// <param name="name">Name of the host.</param>
		/// <param name="timeToLive">Seconds the record should be cached at most.</param>
		/// <param name="address">IP address of the host.</param>
		/// <param name="protocol">Type of the protocol.</param>
		/// <param name="ports">List of ports which are supported by the host.</param>
		public WksRecord(string name, int timeToLive, IPAddress address, ProtocolType protocol, List<ushort> ports)
			: base(name, RecordType.Wks, RecordClass.INet, timeToLive)
		{
			this.Address = address ?? IPAddress.None;
			this.Protocol = protocol;
			this.Ports = ports ?? new List<ushort>();
		}

		// Public properties.

		/// <summary>
		/// IP address of the host
		/// </summary>
		public IPAddress Address { get; private set; }
		/// <summary>
		/// Type of the protocol
		/// </summary>
		public ProtocolType Protocol { get; private set; }
		/// <summary>
		/// List of ports which are supported by the host
		/// </summary>
		public List<ushort> Ports { get; private set; }

		// Protected properties.

		/// <summary>
		/// Gets the maximum record data length.
		/// </summary>
		protected internal override int MaximumRecordDataLength
		{
			get { return 5 + this.Ports.Max() / 8 + 1; }
		}

		// Internal methods.

		/// <summary>
		/// Parses the record data.
		/// </summary>
		/// <param name="resultData">The result data.</param>
		/// <param name="startPosition">The start position.</param>
		/// <param name="length">The length.</param>
		internal override void ParseRecordData(byte[] resultData, int currentPosition, int length)
		{
			int endPosition = currentPosition + length;

			this.Address = new IPAddress(DnsMessageBase.ParseByteData(resultData, ref currentPosition, 4));
			this.Protocol = (ProtocolType) resultData[currentPosition++];
			this.Ports = new List<ushort>();

			int octetNumber = 0;
			while (currentPosition < endPosition)
			{
				byte octet = resultData[currentPosition++];

				for (int bit = 0; bit < 8; bit++)
				{
					if ((octet & (1 << Math.Abs(bit - 7))) != 0)
					{
						this.Ports.Add((ushort) (octetNumber * 8 + bit));
					}
				}

				octetNumber++;
			}
		}

		/// <summary>
		/// Converts the record data to a string.
		/// </summary>
		/// <returns>The record data string.</returns>
		internal override string RecordDataToString()
		{
			return this.Address
				+ " " + (byte)this.Protocol
				+ " " + String.Join(" ", this.Ports.ConvertAll(port => port.ToString()).ToArray());
		}

		// Protected methods.

		/// <summary>
		/// Encodes the data for this record.
		/// </summary>
		/// <param name="messageData">The message data.</param>
		/// <param name="offset">The offset.</param>
		/// <param name="currentPosition">The current position.</param>
		/// <param name="domainNames">The domain names.</param>
		protected internal override void EncodeRecordData(byte[] messageData, int offset, ref int currentPosition, Dictionary<string, ushort> domainNames)
		{
			DnsMessageBase.EncodeByteArray(messageData, ref currentPosition, this.Address.GetAddressBytes());
			messageData[currentPosition++] = (byte)this.Protocol;

			foreach (ushort port in this.Ports)
			{
				int octetPosition = port / 8 + currentPosition;
				int bitPos = port % 8;
				byte octet = messageData[octetPosition];
				octet |= (byte) (1 << Math.Abs(bitPos - 7));
				messageData[octetPosition] = octet;
			}
			currentPosition += this.Ports.Max() / 8 + 1;
		}
	}
}