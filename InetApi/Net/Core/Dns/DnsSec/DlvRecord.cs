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
	/// <para>DNSSEC lookaside validation.</para>
	/// <para>Defined in <see cref="http://tools.ietf.org/html/rfc4431">RFC 4431</see>.</para>
	/// </summary>
	public class DlvRecord : DnsRecordBase
	{
		/// <summary>
		/// Internal constructor.
		/// </summary>
		internal DlvRecord() { }

		/// <summary>
		/// Creates a new instance of the DlvRecord class.
		/// </summary>
		/// <param name="name">Name of the record.</param>
		/// <param name="recordClass">Class of the record.</param>
		/// <param name="timeToLive">Seconds the record should be cached at most.</param>
		/// <param name="keyTag">Key tag.</param>
		/// <param name="algorithm">Algorithm used.</param>
		/// <param name="digestType">Type of the digest.</param>
		/// <param name="digest">Binary data of the digest.</param>
		public DlvRecord(string name, RecordClass recordClass, int timeToLive, ushort keyTag, DnsSecAlgorithm algorithm, DnsSecDigestType digestType, byte[] digest)
			: base(name, RecordType.Dlv, recordClass, timeToLive)
		{
			this.KeyTag = keyTag;
			this.Algorithm = algorithm;
			this.DigestType = digestType;
			this.Digest = digest ?? new byte[] { };
		}

		// Public properties.

		/// <summary>
		/// Key tag
		/// </summary>
		public ushort KeyTag { get; private set; }
		/// <summary>
		/// Algorithm used
		/// </summary>
		public DnsSecAlgorithm Algorithm { get; private set; }
		/// <summary>
		/// Type of the digest
		/// </summary>
		public DnsSecDigestType DigestType { get; private set; }
		/// <summary>
		/// Binary data of the digest
		/// </summary>
		public byte[] Digest { get; private set; }

		// Protected properties.

		/// <summary>
		/// Gets the maximum record data length.
		/// </summary>
		protected internal override int MaximumRecordDataLength
		{
			get { return 4 + this.Digest.Length; }
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
			this.KeyTag = DnsMessageBase.ParseUShort(resultData, ref startPosition);
			this.Algorithm = (DnsSecAlgorithm)resultData[startPosition++];
			this.DigestType = (DnsSecDigestType)resultData[startPosition++];
			this.Digest = DnsMessageBase.ParseByteData(resultData, ref startPosition, length - 4);
		}

		/// <summary>
		/// Converts the record data to a string.
		/// </summary>
		/// <returns>The record data string.</returns>
		internal override string RecordDataToString()
		{
			return this.KeyTag
				+ " " + (byte)this.Algorithm
				+ " " + (byte)this.DigestType
				+ " " + this.Digest.ToBase64String();
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
			DnsMessageBase.EncodeUShort(messageData, ref currentPosition, this.KeyTag);
			messageData[currentPosition++] = (byte)this.Algorithm;
			messageData[currentPosition++] = (byte)this.DigestType;
			DnsMessageBase.EncodeByteArray(messageData, ref currentPosition, this.Digest);
		}
	}
}