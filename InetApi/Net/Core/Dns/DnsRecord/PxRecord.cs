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
	/// <para>X.400 mail mapping information record</para> <para>Defined in <see cref="http://tools.ietf.org/html/rfc2163">RFC 2163</see>.</para>
	/// </summary>
	public class PxRecord : DnsRecordBase
	{
		/// <summary>
		/// Internal constructor.
		/// </summary>
		internal PxRecord() { }

		/// <summary>
		/// Creates a new instance of the PxRecord class
		/// </summary>
		/// <param name="name"> Name of the record </param>
		/// <param name="timeToLive"> Seconds the record should be cached at most </param>
		/// <param name="preference"> Preference of the record </param>
		/// <param name="map822"> Domain name containing the RFC822 domain </param>
		/// <param name="mapX400"> Domain name containing the X.400 part </param>
		public PxRecord(string name, int timeToLive, ushort preference, string map822, string mapX400)
			: base(name, RecordType.Px, RecordClass.INet, timeToLive)
		{
			this.Preference = preference;
			this.Map822 = map822 ?? String.Empty;
			this.MapX400 = mapX400 ?? String.Empty;
		}

		// Public properties.

		/// <summary>
		/// Preference of the record.
		/// </summary>
		public ushort Preference { get; private set; }
		/// <summary>
		/// Domain name containing the RFC822 domain.
		/// </summary>
		public string Map822 { get; private set; }
		/// <summary>
		/// Domain name containing the X.400 part.
		/// </summary>
		public string MapX400 { get; private set; }

		// Protected properties.

		/// <summary>
		/// Gets the maximum record data length.
		/// </summary>
		protected internal override int MaximumRecordDataLength
		{
			get { return 6 + this.Map822.Length + this.MapX400.Length; }
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
			this.Map822 = DnsMessageBase.ParseDomainName(resultData, ref startPosition);
			this.MapX400 = DnsMessageBase.ParseDomainName(resultData, ref startPosition);
		}

		/// <summary>
		/// Converts the record data to a string.
		/// </summary>
		/// <returns>The record data string.</returns>
		internal override string RecordDataToString()
		{
			return this.Preference + " " + this.Map822 + " " + this.MapX400;
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
			DnsMessageBase.EncodeDomainName(messageData, offset, ref currentPosition, this.Map822, false, domainNames);
			DnsMessageBase.EncodeDomainName(messageData, offset, ref currentPosition, this.MapX400, false, domainNames);
		}
	}
}