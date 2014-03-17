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

namespace ARSoft.Tools.Net.Dns
{
	/// <summary>
	/// <para>Host identity protocol</para> <para>Defined in <see cref="http://tools.ietf.org/html/rfc5205">RFC 5205</see>.</para>
	/// </summary>
	public class HipRecord : DnsRecordBase
	{
		/// <summary>
		/// Internal constructor.
		/// </summary>
		internal HipRecord() { }

		/// <summary>
		/// Creates a new instace of the HipRecord class.
		/// </summary>
		/// <param name="name">Name of the record </param>
		/// <param name="timeToLive">Seconds the record should be cached at most.</param>
		/// <param name="algorithm">Algorithm of the key.</param>
		/// <param name="hit">Host identity tag.</param>
		/// <param name="publicKey">Binary data of the public key.</param>
		/// <param name="rendezvousServers">Possible rendezvous servers.</param>
		public HipRecord(string name, int timeToLive, IpSecKeyRecord.IpSecAlgorithm algorithm, byte[] hit, byte[] publicKey, List<string> rendezvousServers)
			: base(name, RecordType.Hip, RecordClass.INet, timeToLive)
		{
			this.Algorithm = algorithm;
			this.Hit = hit ?? new byte[] { };
			this.PublicKey = publicKey ?? new byte[] { };
			this.RendezvousServers = rendezvousServers ?? new List<string>();
		}

		// Public properties.

		/// <summary>
		/// Algorithm of the key.
		/// </summary>
		public IpSecKeyRecord.IpSecAlgorithm Algorithm { get; private set; }
		/// <summary>
		/// Host identity tag.
		/// </summary>
		public byte[] Hit { get; private set; }
		/// <summary>
		/// Binary data of the public key.
		/// </summary>
		public byte[] PublicKey { get; private set; }
		/// <summary>
		/// Possible rendezvous servers.
		/// </summary>
		public List<string> RendezvousServers { get; private set; }

		// Protected properties.

		/// <summary>
		/// Gets the maximum record data length.
		/// </summary>
		protected internal override int MaximumRecordDataLength
		{
			get
			{
				int res = 4;
				res += this.Hit.Length;
				res += this.PublicKey.Length;
				res += this.RendezvousServers.Sum(s => s.Length + 2);
				return res;
			}
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

			int hitLength = resultData[currentPosition++];
			this.Algorithm = (IpSecKeyRecord.IpSecAlgorithm) resultData[currentPosition++];
			int publicKeyLength = DnsMessageBase.ParseUShort(resultData, ref currentPosition);
			Hit = DnsMessageBase.ParseByteData(resultData, ref currentPosition, hitLength);
			this.PublicKey = DnsMessageBase.ParseByteData(resultData, ref currentPosition, publicKeyLength);
			this.RendezvousServers = new List<string>();
			while (currentPosition < endPosition)
			{
				this.RendezvousServers.Add(DnsMessageBase.ParseDomainName(resultData, ref currentPosition));
			}
		}

		/// <summary>
		/// Converts the record data to a string.
		/// </summary>
		/// <returns>The record data string.</returns>
		internal override string RecordDataToString()
		{
			return (byte) this.Algorithm
				+ " " + this.Hit.ToBase16String()
				+ " " + this.PublicKey.ToBase64String()
				+ String.Join("", this.RendezvousServers.Select(s => " " + s).ToArray());
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
			messageData[currentPosition++] = (byte) this.Hit.Length;
			messageData[currentPosition++] = (byte) this.Algorithm;
			DnsMessageBase.EncodeUShort(messageData, ref currentPosition, (ushort) this.PublicKey.Length);
			DnsMessageBase.EncodeByteArray(messageData, ref currentPosition, this.Hit);
			DnsMessageBase.EncodeByteArray(messageData, ref currentPosition, this.PublicKey);
			foreach (string server in this.RendezvousServers)
			{
				DnsMessageBase.EncodeDomainName(messageData, offset, ref currentPosition, server, false, domainNames);
			}
		}
	}
}