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
	/// <para>NSAP address, NSAP style A record</para> <para>Defined in <see cref="!:http://tools.ietf.org/html/rfc1706">RFC 1706</see>
	/// and <see cref="!:http://tools.ietf.org/html/rfc1348">RFC 1348</see>.</para>
	/// </summary>
	public class NsapRecord : DnsRecordBase
	{
		/// <summary>
		/// Internal constructor.
		/// </summary>
		internal NsapRecord() { }

		/// <summary>
		/// Creates a new instance of the NsapRecord class.
		/// </summary>
		/// <param name="name">Name of the record.</param>
		/// <param name="timeToLive">Seconds the record should be cached at most.</param>
		/// <param name="recordData">Binary encoded NSAP data.</param>
		public NsapRecord(string name, int timeToLive, byte[] recordData)
			: base(name, RecordType.Nsap, RecordClass.INet, timeToLive)
		{
			this.RecordData = recordData ?? new byte[] { };
		}

		#region Public properties

		/// <summary>
		/// Binary encoded NSAP data.
		/// </summary>
		public byte[] RecordData { get; private set; }

		#endregion

		#region Protected properties.

		/// <summary>
		/// Gets the maximum record data length.
		/// </summary>
		protected internal override int MaximumRecordDataLength
		{
			get { return RecordData.Length; }
		}
		
		#endregion

		#region Internal methods.

		/// <summary>
		/// Parses the record data.
		/// </summary>
		/// <param name="resultData">The result data.</param>
		/// <param name="startPosition">The start position.</param>
		/// <param name="length">The length.</param>
		internal override void ParseRecordData(byte[] resultData, int startPosition, int length)
		{
			this.RecordData = DnsMessageBase.ParseByteData(resultData, ref startPosition, length);
		}

		/// <summary>
		/// Converts the record data to a string.
		/// </summary>
		/// <returns>The record data string.</returns>
		internal override string RecordDataToString()
		{
			return "0x" + this.RecordData.ToBase16String();
		}

		#endregion

		#region Protected methods.

		/// <summary>
		/// Encodes the data for this record.
		/// </summary>
		/// <param name="messageData">The message data.</param>
		/// <param name="offset">The offset.</param>
		/// <param name="currentPosition">The current position.</param>
		/// <param name="domainNames">The domain names.</param>
		protected internal override void EncodeRecordData(byte[] messageData, int offset, ref int currentPosition, Dictionary<string, ushort> domainNames)
		{
			DnsMessageBase.EncodeByteArray(messageData, ref currentPosition, this.RecordData);
		}

		#endregion
	}
}