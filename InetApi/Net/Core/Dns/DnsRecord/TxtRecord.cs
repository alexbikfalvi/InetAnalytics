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
	/// <para>Text strings.</para> <para>Defined in <see cref="!:http://tools.ietf.org/html/rfc1035">RFC 1035</see>.</para>
	/// </summary>
	public class TxtRecord : DnsRecordBase, ITextRecord
	{
		/// <summary>
		/// Internal constructor.
		/// </summary>
		internal TxtRecord() { }

		/// <summary>
		/// Creates a new instance of the TxtRecord class.
		/// </summary>
		/// <param name="name">Name of the record.</param>
		/// <param name="timeToLive">Seconds the record should be cached at most.</param>
		/// <param name="textData">Text data.</param>
		public TxtRecord(string name, int timeToLive, string textData)
			: base(name, RecordType.Txt, RecordClass.INet, timeToLive)
		{
			this.TextData = textData ?? String.Empty;
			this.TextParts = new List<string> { this.TextData };
		}

		/// <summary>
		/// Creates a new instance of the TxtRecord class.
		/// </summary>
		/// <param name="name">Name of the record.</param>
		/// <param name="timeToLive">Seconds the record should be cached at most.</param>
		/// <param name="textParts">All parts of the text data.</param>
		public TxtRecord(string name, int timeToLive, IEnumerable<string> textParts)
			: base(name, RecordType.Txt, RecordClass.INet, timeToLive)
		{
			this.TextParts = new List<string>(textParts);
			this.TextData = String.Join(String.Empty, this.TextParts.ToArray());
		}

		// Public properties.

		/// <summary>
		/// Text data
		/// </summary>
		public string TextData { get; protected set; }
		/// <summary>
		/// The single parts of the text data
		/// </summary>
		public IEnumerable<string> TextParts { get; protected set; }

		// Protected properties.

		/// <summary>
		/// Gets the maximum record data length.
		/// </summary>
		protected internal override int MaximumRecordDataLength
		{
			get { return this.TextData.Length + this.TextParts.Sum(p => (p.Length / 255) + (p.Length % 255 == 0 ? 0 : 1)); }
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
			int endPosition = startPosition + length;

			List<string> textParts = new List<string>();
			while (startPosition < endPosition)
			{
				textParts.Add(DnsMessageBase.ParseText(resultData, ref startPosition));
			}

			this.TextParts = textParts;
			this.TextData = String.Join(String.Empty, textParts.ToArray());
		}

		/// <summary>
		/// Converts the record data to a string.
		/// </summary>
		/// <returns>The record data string.</returns>
		internal override string RecordDataToString()
		{
			return " \"" + this.TextData + "\"";
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
			foreach (var part in this.TextParts)
			{
				DnsMessageBase.EncodeText(messageData, ref currentPosition, part);
			}
		}
	}
}