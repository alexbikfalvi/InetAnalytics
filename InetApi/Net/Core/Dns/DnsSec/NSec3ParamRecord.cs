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

namespace InetApi.Net.Core.Dns
{
	/// <summary>
	/// <para>Hashed next owner parameter record.</para>
	/// <para>Defined in <see cref="http://tools.ietf.org/html/rfc5155">RFC 5155</see>.</para>
	/// </summary>
	public class NSec3ParamRecord : DnsRecordBase
	{
		/// <summary>
		/// Internal constructor.
		/// </summary>
		internal NSec3ParamRecord() { }

		/// <summary>
		/// Creates a new instance of the NSec3ParamRecord class.
		/// </summary>
		/// <param name="name">Name of the record.</param>
		/// <param name="recordClass">Class of the record.</param>
		/// <param name="timeToLive">Seconds the record should be cached at most.</param>
		/// <param name="hashAlgorithm">Algorithm of hash.</param>
		/// <param name="flags">Flags of the record.</param>
		/// <param name="iterations">Number of iterations.</param>
		/// <param name="salt">Binary data of salt.</param>
		public NSec3ParamRecord(string name, RecordClass recordClass, int timeToLive, DnsSecAlgorithm hashAlgorithm, byte flags, ushort iterations, byte[] salt)
			: base(name, RecordType.NSec3Param, recordClass, timeToLive)
		{
			this.HashAlgorithm = hashAlgorithm;
			this.Flags = flags;
			this.Iterations = iterations;
			this.Salt = salt ?? new byte[] { };
		}

		// Public properties.

		/// <summary>
		/// Algorithm of the hash.
		/// </summary>
		public DnsSecAlgorithm HashAlgorithm { get; private set; }
		/// <summary>
		/// Flags of the record.
		/// </summary>
		public byte Flags { get; private set; }
		/// <summary>
		/// Number of iterations.
		/// </summary>
		public ushort Iterations { get; private set; }
		/// <summary>
		/// Binary data of salt.
		/// </summary>
		public byte[] Salt { get; private set; }

		// Protected properties.

		/// <summary>
		/// Gets the maximum public key length.
		/// </summary>
		protected internal override int MaximumRecordDataLength
		{
			get { return 5 + this.Salt.Length; }
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
			this.HashAlgorithm = (DnsSecAlgorithm)resultData[currentPosition++];
			this.Flags = resultData[currentPosition++];
			this.Iterations = DnsMessageBase.ParseUShort(resultData, ref currentPosition);
			int saltLength = resultData[currentPosition++];
			this.Salt = DnsMessageBase.ParseByteData(resultData, ref currentPosition, saltLength);
		}

		/// <summary>
		/// Converts the record data to a string.
		/// </summary>
		/// <returns>The record data string.</returns>
		internal override string RecordDataToString()
		{
			return (byte)this.HashAlgorithm
				+ " " + this.Flags
				+ " " + this.Iterations
				+ " " + ((this.Salt.Length == 0) ? "-" : this.Salt.ToBase16String());
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
			messageData[currentPosition++] = (byte)this.HashAlgorithm;
			messageData[currentPosition++] = this.Flags;
			DnsMessageBase.EncodeUShort(messageData, ref currentPosition, this.Iterations);
			messageData[currentPosition++] = (byte)this.Salt.Length;
			DnsMessageBase.EncodeByteArray(messageData, ref currentPosition, this.Salt);
		}
	}
}