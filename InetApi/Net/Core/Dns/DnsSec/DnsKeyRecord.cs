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
	/// <para>DNS Key record.</para>
	/// <para>Defined in <see cref="http://tools.ietf.org/html/rfc4034">RFC 4034</see> and <see cref="http://tools.ietf.org/html/rfc3755">RFC 3755</see>.</para>
	/// </summary>
	public class DnsKeyRecord : DnsRecordBase
	{
		/// <summary>
		/// Internal constructor.
		/// </summary>
		internal DnsKeyRecord() { }

		/// <summary>
		/// Creates a new instance of the DnsKeyRecord class
		/// </summary>
		/// <param name="name"> Name of the record </param>
		/// <param name="recordClass"> Class of the record </param>
		/// <param name="timeToLive"> Seconds the record should be cached at most </param>
		/// <param name="flags"> Flags of the key </param>
		/// <param name="protocol"> Protocol field </param>
		/// <param name="algorithm"> Algorithm of the key </param>
		/// <param name="publicKey"> Binary data of the public key </param>
		public DnsKeyRecord(string name, RecordClass recordClass, int timeToLive, ushort flags, byte protocol, DnsSecAlgorithm algorithm, byte[] publicKey)
			: base(name, RecordType.DnsKey, recordClass, timeToLive)
		{
			this.Flags = flags;
			this.Protocol = protocol;
			this.Algorithm = algorithm;
			this.PublicKey = publicKey ?? new byte[] { };
		}

		/// <summary>
		/// Flags of the key.
		/// </summary>
		public ushort Flags { get; private set; }
		/// <summary>
		/// Protocol field.
		/// </summary>
		public byte Protocol { get; private set; }
		/// <summary>
		/// Algorithm of the key.
		/// </summary>
		public DnsSecAlgorithm Algorithm { get; private set; }
		/// <summary>
		/// Binary data of the public key.
		/// </summary>
		public byte[] PublicKey { get; private set; }
		/// <summary>
		/// Record holds a DNS zone key
		/// </summary>
		public bool IsZoneKey
		{
			get { return (this.Flags & 0x100) != 0; }
			set
			{
				if (value)
				{
					this.Flags |= 0x100;
				}
				else
				{
					this.Flags &= 0xfeff;
				}
			}
		}
		/// <summary>
		/// <para>Key is intended for use as a secure entry point.</para>
		/// <para>Defined in <see cref="http://tools.ietf.org/html/rfc4034">RFC 4034</see> and <see cref="http://tools.ietf.org/html/rfc3757">RFC 3757</see>.</para>
		/// </summary>
		public bool IsSecureEntryPoint
		{
			get { return (this.Flags & 0x01) != 0; }
			set
			{
				if (value)
				{
					this.Flags |= 0x01;
				}
				else
				{
					this.Flags &= 0xfffe;
				}
			}
		}

		// Protected properties.

		/// <summary>
		/// Gets the maximum record data length.
		/// </summary>
		protected internal override int MaximumRecordDataLength
		{
			get { return 4 + this.PublicKey.Length; }
		}

		// Internal methods.

		/// <summary>
		/// Parses the record data.
		/// </summary>
		/// <param name="resultData">The result data.</param>
		/// <param name="startPosition">The start position.</param>
		/// <param name="length">The length.</param>
		internal override void ParseRecordData(byte[] resultData, int startPosition, int length)
		{
			this.Flags = DnsMessageBase.ParseUShort(resultData, ref startPosition);
			this.Protocol = resultData[startPosition++];
			this.Algorithm = (DnsSecAlgorithm)resultData[startPosition++];
			this.PublicKey = DnsMessageBase.ParseByteData(resultData, ref startPosition, length - 4);
		}

		/// <summary>
		/// Converts the record data to a string.
		/// </summary>
		/// <returns>The record data string.</returns>
		internal override string RecordDataToString()
		{
			return this.Flags
				+ " " + this.Protocol
				+ " " + (byte)this.Algorithm
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
			DnsMessageBase.EncodeUShort(messageData, ref currentPosition, this.Flags);
			messageData[currentPosition++] = this.Protocol;
			messageData[currentPosition++] = (byte)this.Algorithm;
			DnsMessageBase.EncodeByteArray(messageData, ref currentPosition, this.PublicKey);
		}
	}
}