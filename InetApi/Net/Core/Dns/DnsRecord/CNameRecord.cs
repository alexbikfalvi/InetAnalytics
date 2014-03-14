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
	/// <para>Canonical name for an alias</para> <para>Defined in <see cref="http://tools.ietf.org/html/rfc1035">RFC 1035</see>.</para>
	/// </summary>
	public class CNameRecord : DnsRecordBase
	{
		/// <summary>
		/// Internal constructor.
		/// </summary>
		internal CNameRecord() { }

		/// <summary>
		///   Creates a new instance of the CNameRecord class
		/// </summary>
		/// <param name="name"> Domain name the host </param>
		/// <param name="timeToLive"> Seconds the record should be cached at most </param>
		/// <param name="canonicalName"> Canocical name for the alias of the host </param>
		public CNameRecord(string name, int timeToLive, string canonicalName)
			: base(name, RecordType.CName, RecordClass.INet, timeToLive)
		{
			this.CanonicalName = canonicalName ?? String.Empty;
		}

		// Public properties.

		/// <summary>
		/// Canonical name.
		/// </summary>
		public string CanonicalName { get; private set; }

		// Protected properties.

		/// <summary>
		/// Gets the maximum record data length.
		/// </summary>
		protected internal override int MaximumRecordDataLength
		{
			get { return this.CanonicalName.Length + 2; }
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
			this.CanonicalName = DnsMessageBase.ParseDomainName(resultData, ref startPosition);
		}

		/// <summary>
		/// Converts the record data to a string.
		/// </summary>
		/// <returns>The record data string.</returns>
		internal override string RecordDataToString()
		{
			return this.CanonicalName;
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
			DnsMessageBase.EncodeDomainName(messageData, offset, ref currentPosition, this.CanonicalName, true, domainNames);
		}
	}
}