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
using System.Net;

namespace InetApi.Net.Core.Dns
{
	/// <summary>
	/// <para>IPsec key storage</para> <para>Defined in <see cref="http://tools.ietf.org/html/rfc4025">RFC 4025</see>.</para>
	/// </summary>
	public class IpSecKeyRecord : DnsRecordBase
	{
		/// <summary>
		/// Algorithm of key.
		/// </summary>
		public enum IpSecAlgorithm : byte
		{
			/// <summary>
			/// None.
			/// </summary>
			None = 0,
			/// <summary>
			/// <para>RSA</para> <para>Defined in <see cref="http://tools.ietf.org/html/rfc4025">RFC 4025</see>.</para>
			/// </summary>
			Rsa = 1,
			/// <summary>
			/// <para>DSA</para> <para>Defined in <see cref="http://tools.ietf.org/html/rfc4025">RFC 4025</see>.</para>
			/// </summary>
			Dsa = 2
		}

		/// <summary>
		/// Type of gateway.
		/// </summary>
		public enum IpSecGatewayType : byte
		{
			/// <summary>
			/// None.
			/// </summary>
			None = 0,
			/// <summary>
			/// <para>Gateway is a IPv4 address</para> <para>Defined in <see cref="http://tools.ietf.org/html/rfc4025">RFC 4025</see>.</para>
			/// </summary>
			IpV4 = 1,
			/// <summary>
			/// <para>Gateway is a IPv6 address</para> <para>Defined in <see cref="http://tools.ietf.org/html/rfc4025">RFC 4025</see>.</para>
			/// </summary>
			IpV6 = 2,
			/// <summary>
			/// <para>Gateway is a domain name</para> <para>Defined in <see cref="http://tools.ietf.org/html/rfc4025">RFC 4025</see>.</para>
			/// </summary>
			Domain = 3
		}

		/// <summary>
		/// Internal constructor.
		/// </summary>
		internal IpSecKeyRecord() { }

		/// <summary>
		/// Creates a new instance of the IpSecKeyRecord class
		/// </summary>
		/// <param name="name"> Name of the record </param>
		/// <param name="timeToLive"> Seconds the record should be cached at most </param>
		/// <param name="precedence"> Precedence of the record </param>
		/// <param name="gatewayType"> Type of gateway </param>
		/// <param name="algorithm"> Algorithm of the key </param>
		/// <param name="gateway"> Address of the gateway </param>
		/// <param name="publicKey"> Binary data of the public key </param>
		public IpSecKeyRecord(string name, int timeToLive, byte precedence, IpSecGatewayType gatewayType, IpSecAlgorithm algorithm, string gateway, byte[] publicKey)
			: base(name, RecordType.IpSecKey, RecordClass.INet, timeToLive)
		{
			this.Precedence = precedence;
			this.GatewayType = gatewayType;
			this.Algorithm = algorithm;
			this.Gateway = gateway ?? String.Empty;
			this.PublicKey = publicKey ?? new byte[] { };
		}

		/// <summary>
		/// Precedence of the record.
		/// </summary>
		public byte Precedence { get; private set; }
		/// <summary>
		/// Type of gateway.
		/// </summary>
		public IpSecGatewayType GatewayType { get; private set; }
		/// <summary>
		/// Algorithm of the key.
		/// </summary>
		public IpSecAlgorithm Algorithm { get; private set; }
		/// <summary>
		/// Address of the gateway.
		/// </summary>
		public string Gateway { get; private set; }
		/// <summary>
		/// Binary data of the public key.
		/// </summary>
		public byte[] PublicKey { get; private set; }

		// Protected properties.

		/// <summary>
		/// Gets the maximum record data length.
		/// </summary>
		protected internal override int MaximumRecordDataLength
		{
			get
			{
				int res = 3;
				switch (this.GatewayType)
				{
					case IpSecGatewayType.IpV4:
						res += 4;
						break;
					case IpSecGatewayType.IpV6:
						res += 16;
						break;
					case IpSecGatewayType.Domain:
						res += 2 + this.Gateway.Length;
						break;
				}
				res += this.PublicKey.Length;
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
			int startPosition = currentPosition;

			this.Precedence = resultData[currentPosition++];
			this.GatewayType = (IpSecGatewayType) resultData[currentPosition++];
			this.Algorithm = (IpSecAlgorithm) resultData[currentPosition++];
			switch (GatewayType)
			{
				case IpSecGatewayType.None:
					this.Gateway = String.Empty;
					break;
				case IpSecGatewayType.IpV4:
					this.Gateway = new IPAddress(DnsMessageBase.ParseByteData(resultData, ref currentPosition, 4)).ToString();
					break;
				case IpSecGatewayType.IpV6:
					this.Gateway = new IPAddress(DnsMessageBase.ParseByteData(resultData, ref currentPosition, 16)).ToString();
					break;
				case IpSecGatewayType.Domain:
					this.Gateway = DnsMessageBase.ParseDomainName(resultData, ref currentPosition);
					break;
			}
			this.PublicKey = DnsMessageBase.ParseByteData(resultData, ref currentPosition, length + startPosition - currentPosition);
		}

		/// <summary>
		/// Converts the record data to a string.
		/// </summary>
		/// <returns>The record data string.</returns>
		internal override string RecordDataToString()
		{
			return Precedence
				+ " " + (byte)this.GatewayType
				+ " " + (byte)this.Algorithm
				+ " " + ((this.GatewayType == IpSecGatewayType.None) ? "." : this.Gateway)
				+ " " + this.PublicKey.ToBase64String();
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
			messageData[currentPosition++] = this.Precedence;
			messageData[currentPosition++] = (byte)this.GatewayType;
			messageData[currentPosition++] = (byte)this.Algorithm;
			switch (GatewayType)
			{
				case IpSecGatewayType.IpV4:
				case IpSecGatewayType.IpV6:
					byte[] addressBuffer = IPAddress.Parse(this.Gateway).GetAddressBytes();
					DnsMessageBase.EncodeByteArray(messageData, ref currentPosition, addressBuffer);
					break;
				case IpSecGatewayType.Domain:
					DnsMessageBase.EncodeDomainName(messageData, offset, ref currentPosition, this.Gateway, false, domainNames);
					break;
			}
			DnsMessageBase.EncodeByteArray(messageData, ref currentPosition, this.PublicKey);
		}
	}
}