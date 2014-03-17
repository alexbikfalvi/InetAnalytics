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
	/// <para>Mail exchange</para> <para>Defined in <see cref="http://tools.ietf.org/html/rfc1035">RFC 1035</see>.</para>
	/// </summary>
	public class MxRecord : DnsRecordBase
	{
		/// <summary>
		/// Internal constructor.
		/// </summary>
		internal MxRecord() { }

		/// <summary>
		/// Creates a new instance of the MxRecord class.
		/// </summary>
		/// <param name="name">Name of the zone.</param>
		/// <param name="timeToLive">Seconds the record should be cached at most.</param>
		/// <param name="preference">Preference of the record.</param>
		/// <param name="exchangeDomainName">Host name of the mail exchanger.</param>
		public MxRecord(string name, int timeToLive, ushort preference, string exchangeDomainName)
			: base(name, RecordType.Mx, RecordClass.INet, timeToLive)
		{
			this.Preference = preference;
			this.ExchangeDomainName = exchangeDomainName ?? String.Empty;
		}

		// Public properties.

		/// <summary>
		/// Preference of the record.
		/// </summary>
		public ushort Preference { get; private set; }
		/// <summary>
		/// Host name of the mail exchanger.
		/// </summary>
		public string ExchangeDomainName { get; private set; }

		// Protected properties.

		/// <summary>
		/// Gets the maximum record data length.
		/// </summary>
		protected internal override int MaximumRecordDataLength
		{
			get { return this.ExchangeDomainName.Length + 4; }
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
			this.Preference = DnsMessageBase.ParseUShort(resultData, ref startPosition);
			this.ExchangeDomainName = DnsMessageBase.ParseDomainName(resultData, ref startPosition);
		}

		/// <summary>
		/// Converts the record data to a string.
		/// </summary>
		/// <returns>The record data string.</returns>
		internal override string RecordDataToString()
		{
			return this.Preference + " " + this.ExchangeDomainName;
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
			DnsMessageBase.EncodeUShort(messageData, ref currentPosition, this.Preference);
			DnsMessageBase.EncodeDomainName(messageData, offset, ref currentPosition, this.ExchangeDomainName, true, domainNames);
		}
	}
}