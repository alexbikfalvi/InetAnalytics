﻿/* 
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
	/// <para>Hashed next owner.</para><para>Defined in <see cref="http://tools.ietf.org/html/rfc5155">RFC 5155</see>.</para>
	/// </summary>
	public class NSec3Record : DnsRecordBase
	{
		/// <summary>
		/// Internal constructor.
		/// </summary>
		internal NSec3Record() { }

		/// <summary>
		/// Creates of new instance of the NSec3Record class.
		/// </summary>
		/// <param name="name">Name of the record.</param>
		/// <param name="recordClass">Class of the record.</param>
		/// <param name="timeToLive">Seconds the record should be cached at most.</param>
		/// <param name="hashAlgorithm">Algorithm of hash.</param>
		/// <param name="flags">Flags of the record.</param>
		/// <param name="iterations">Number of iterations.</param>
		/// <param name="salt">Binary data of salt.</param>
		/// <param name="nextHashedOwnerName">Binary data of hash of next owner.</param>
		/// <param name="types">Types of next owner.</param>
		public NSec3Record(string name, RecordClass recordClass, int timeToLive, DnsSecAlgorithm hashAlgorithm, byte flags, ushort iterations, byte[] salt, byte[] nextHashedOwnerName, List<RecordType> types)
			: base(name, RecordType.NSec3, recordClass, timeToLive)
		{
			this.HashAlgorithm = hashAlgorithm;
			this.Flags = flags;
			this.Iterations = iterations;
			this.Salt = salt ?? new byte[] { };
			this.NextHashedOwnerName = nextHashedOwnerName ?? new byte[] { };

			if ((types == null) || (types.Count == 0))
			{
				this.Types = new List<RecordType>();
			}
			else
			{
				this.Types = new List<RecordType>(types);
				types.Sort((left, right) => ((ushort) left).CompareTo((ushort) right));
			}
		}

		// Public properties.

		/// <summary>
		/// Algorithm of hash
		/// </summary>
		public DnsSecAlgorithm HashAlgorithm { get; private set; }
		/// <summary>
		/// Flags of the record
		/// </summary>
		public byte Flags { get; private set; }
		/// <summary>
		/// Number of iterations
		/// </summary>
		public ushort Iterations { get; private set; }
		/// <summary>
		/// Binary data of salt
		/// </summary>
		public byte[] Salt { get; private set; }
		/// <summary>
		/// Binary data of hash of next owner
		/// </summary>
		public byte[] NextHashedOwnerName { get; private set; }
		/// <summary>
		/// Types of next owner
		/// </summary>
		public List<RecordType> Types { get; private set; }

		// Protected properties.

		/// <summary>
		/// Gets the maximum record data length.
		/// </summary>
		protected internal override int MaximumRecordDataLength
		{
			get { return 6 + this.Salt.Length + this.NextHashedOwnerName.Length + NSecRecord.GetMaximumTypeBitmapLength(this.Types); }
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

			HashAlgorithm = (DnsSecAlgorithm) resultData[currentPosition++];
			Flags = resultData[currentPosition++];
			Iterations = DnsMessageBase.ParseUShort(resultData, ref currentPosition);
			int saltLength = resultData[currentPosition++];
			Salt = DnsMessageBase.ParseByteData(resultData, ref currentPosition, saltLength);
			int hashLength = resultData[currentPosition++];
			NextHashedOwnerName = DnsMessageBase.ParseByteData(resultData, ref currentPosition, hashLength);
			Types = NSecRecord.ParseTypeBitmap(resultData, ref currentPosition, endPosition);
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
				+ " " + ((this.Salt.Length == 0) ? "-" : Salt.ToBase16String())
				+ " " + this.NextHashedOwnerName.ToBase32HexString()
				+ " " + String.Join(" ", this.Types.ConvertAll<String>(ToString).ToArray());
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
			DnsMessageBase.EncodeByteArray(messageData, ref currentPosition, Salt);
			messageData[currentPosition++] = (byte)this.NextHashedOwnerName.Length;
			DnsMessageBase.EncodeByteArray(messageData, ref currentPosition, this.NextHashedOwnerName);
			NSecRecord.EncodeTypeBitmap(messageData, ref currentPosition, this.Types);
		}
	}
}