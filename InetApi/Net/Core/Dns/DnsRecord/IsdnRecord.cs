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
	/// <para>ISDN address</para> <para>Defined in <see cref="http://tools.ietf.org/html/rfc1183">RFC 1183</see>.</para>
	/// </summary>
	public class IsdnRecord : DnsRecordBase
	{
		/// <summary>
		/// Internal constructor.
		/// </summary>
		internal IsdnRecord() { }

		/// <summary>
		/// Creates a new instance of the IsdnRecord class.
		/// </summary>
		/// <param name="name">Name of the record.</param>
		/// <param name="timeToLive">Seconds the record should be cached at most.</param>
		/// <param name="isdnAddress">ISDN number.</param>
		public IsdnRecord(string name, int timeToLive, string isdnAddress)
			: this(name, timeToLive, isdnAddress, String.Empty) {}

		/// <summary>
		/// Creates a new instance of the IsdnRecord class.
		/// </summary>
		/// <param name="name">Name of the record.</param>
		/// <param name="timeToLive">Seconds the record should be cached at most.</param>
		/// <param name="isdnAddress">ISDN number.</param>
		/// <param name="subAddress">Sub address.</param>
		public IsdnRecord(string name, int timeToLive, string isdnAddress, string subAddress)
			: base(name, RecordType.Isdn, RecordClass.INet, timeToLive)
		{
			this.IsdnAddress = isdnAddress ?? String.Empty;
			this.SubAddress = subAddress ?? String.Empty;
		}

		// Public properties.

		/// <summary>
		/// ISDN number
		/// </summary>
		public string IsdnAddress { get; private set; }
		/// <summary>
		/// Sub address
		/// </summary>
		public string SubAddress { get; private set; }

		// Protected properties.

		/// <summary>
		/// Gets the maximum record data length.
		/// </summary>
		protected internal override int MaximumRecordDataLength
		{
			get { return 2 + this.IsdnAddress.Length + this.SubAddress.Length; }
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

			this.IsdnAddress = DnsMessageBase.ParseText(resultData, ref currentPosition);
			this.SubAddress = (currentPosition < endPosition) ? DnsMessageBase.ParseText(resultData, ref currentPosition) : String.Empty;
		}

		/// <summary>
		/// Converts the record data to a string.
		/// </summary>
		/// <returns>The record data string.</returns>
		internal override string RecordDataToString()
		{
			return IsdnAddress
				+ (String.IsNullOrEmpty(this.SubAddress) ? String.Empty : " " + this.SubAddress);
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
			DnsMessageBase.EncodeText(messageData, ref currentPosition, this.IsdnAddress);
			DnsMessageBase.EncodeText(messageData, ref currentPosition, this.SubAddress);
		}
	}
}