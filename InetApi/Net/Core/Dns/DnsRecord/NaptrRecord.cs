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
	/// <para>Naming authority pointer record</para> <para>Defined in <see cref="http://tools.ietf.org/html/rfc2915">RFC 2915</see>,
	/// <see cref="http://tools.ietf.org/html/rfc2168">RFC 2168</see> and <see cref="http://tools.ietf.org/html/rfc3403">RFC 3403</see>.</para>
	/// </summary>
	public class NaptrRecord : DnsRecordBase
	{
		/// <summary>
		/// Internal constructor.
		/// </summary>
		internal NaptrRecord() { }

		/// <summary>
		/// Creates a new instance of the NaptrRecord class.
		/// </summary>
		/// <param name="name">Name of the record.</param>
		/// <param name="timeToLive">Seconds the record should be cached at most.</param>
		/// <param name="order">Order of the record.</param>
		/// <param name="preference">Preference of record with same order.</param>
		/// <param name="flags">Flags of the record.</param>
		/// <param name="services">Available services.</param>
		/// <param name="regExp">Substitution expression that is applied to the original string.</param>
		/// <param name="replacement">The next name to query.</param>
		public NaptrRecord(string name, int timeToLive, ushort order, ushort preference, string flags, string services, string regExp, string replacement)
			: base(name, RecordType.Naptr, RecordClass.INet, timeToLive)
		{
			this.Order = order;
			this.Preference = preference;
			this.Flags = flags ?? String.Empty;
			this.Services = services ?? String.Empty;
			this.RegExp = regExp ?? String.Empty;
			this.Replacement = replacement ?? String.Empty;
		}

		// Public properties.

		/// <summary>
		/// Order of the record.
		/// </summary>
		public ushort Order { get; private set; }
		/// <summary>
		/// Preference of record with same order.
		/// </summary>
		public ushort Preference { get; private set; }
		/// <summary>
		/// Flags of the record.
		/// </summary>
		public string Flags { get; private set; }
		/// <summary>
		/// Available services.
		/// </summary>
		public string Services { get; private set; }
		/// <summary>
		/// Substitution expression that is applied to the original string.
		/// </summary>
		public string RegExp { get; private set; }
		/// <summary>
		/// The next name to query.
		/// </summary>
		public string Replacement { get; private set; }

		// Protected properties.

		/// <summary>
		/// Gets the maximum record data length.
		/// </summary>
		protected internal override int MaximumRecordDataLength
		{
			get { return this.Flags.Length + this.Services.Length + this.RegExp.Length + this.Replacement.Length + 13; }
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
			this.Order = DnsMessageBase.ParseUShort(resultData, ref startPosition);
			this.Preference = DnsMessageBase.ParseUShort(resultData, ref startPosition);
			this.Flags = DnsMessageBase.ParseText(resultData, ref startPosition);
			this.Services = DnsMessageBase.ParseText(resultData, ref startPosition);
			this.RegExp = DnsMessageBase.ParseText(resultData, ref startPosition);
			this.Replacement = DnsMessageBase.ParseDomainName(resultData, ref startPosition);
		}

		/// <summary>
		/// Converts the record data to a string.
		/// </summary>
		/// <returns>The record data string.</returns>
		internal override string RecordDataToString()
		{
			return this.Order
				+ " " + this.Preference
				+ " \"" + this.Flags + "\""
				+ " \"" + this.Services + "\""
				+ " \"" + this.RegExp + "\""
				+ " \"" + this.Replacement + "\"";
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
			DnsMessageBase.EncodeUShort(messageData, ref currentPosition, this.Order);
			DnsMessageBase.EncodeUShort(messageData, ref currentPosition, this.Preference);
			DnsMessageBase.EncodeText(messageData, ref currentPosition, this.Flags);
			DnsMessageBase.EncodeText(messageData, ref currentPosition, this.Services);
			DnsMessageBase.EncodeText(messageData, ref currentPosition, this.RegExp);
			DnsMessageBase.EncodeDomainName(messageData, offset, ref currentPosition, this.Replacement, false, domainNames);
		}
	}
}