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
	/// <para>Responsible person record</para> <para>Defined in <see cref="http://tools.ietf.org/html/rfc1183">RFC 1183</see>.</para>
	/// </summary>
	public class RpRecord : DnsRecordBase
	{
		internal RpRecord() {}

		/// <summary>
		/// Creates a new instance of the RpRecord class
		/// </summary>
		/// <param name="name"> Name of the record </param>
		/// <param name="timeToLive"> Seconds the record should be cached at most </param>
		/// <param name="mailBox"> Mail address of responsable person, the @ should be replaced by a dot </param>
		/// <param name="txtDomainName"> Domain name of a <see cref="TxtRecord" /> with additional information </param>
		public RpRecord(string name, int timeToLive, string mailBox, string txtDomainName)
			: base(name, RecordType.Rp, RecordClass.INet, timeToLive)
		{
			this.MailBox = mailBox ?? String.Empty;
			TxtDomainName = txtDomainName ?? String.Empty;
		}

		/// <summary>
		/// Mail address of responsable person, the @ should be replaced by a dot.
		/// </summary>
		public string MailBox { get; protected set; }
		/// <summary>
		/// Domain name of a <see cref="TxtRecord"/> with additional information.
		/// </summary>
		public string TxtDomainName { get; protected set; }

		// Protected properties.

		/// <summary>
		/// Gets the maximum record data length.
		/// </summary>
		protected internal override int MaximumRecordDataLength
		{
			get { return 4 + this.MailBox.Length + this.TxtDomainName.Length; }
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
			MailBox = DnsMessageBase.ParseDomainName(resultData, ref startPosition);
			TxtDomainName = DnsMessageBase.ParseDomainName(resultData, ref startPosition);
		}

		/// <summary>
		/// Converts the record data to a string.
		/// </summary>
		/// <returns>The record data string.</returns>
		internal override string RecordDataToString()
		{
			return this.MailBox + " " + this.TxtDomainName;
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
			DnsMessageBase.EncodeDomainName(messageData, offset, ref currentPosition, this.MailBox, false, domainNames);
			DnsMessageBase.EncodeDomainName(messageData, offset, ref currentPosition, this.TxtDomainName, false, domainNames);
		}
	}
}