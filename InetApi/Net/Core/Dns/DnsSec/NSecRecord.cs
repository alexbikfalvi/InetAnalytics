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
using System.Linq;

namespace InetApi.Net.Core.Dns
{
	/// <summary>
	/// <para>Next owner.</para>
	/// <para>Defined in <see cref="http://tools.ietf.org/html/rfc4034">RFC 4034</see> and <see cref="http://tools.ietf.org/html/rfc3755">RFC 3755</see>.</para>
	/// </summary>
	public class NSecRecord : DnsRecordBase
	{
		/// <summary>
		/// Internal constructor.
		/// </summary>
		internal NSecRecord() { }

		/// <summary>
		/// Creates a new instance of the NSecRecord class.
		/// </summary>
		/// <param name="name">Name of the record.</param>
		/// <param name="recordClass">Class of the record.</param>
		/// <param name="timeToLive">Seconds the record should be cached at most.</param>
		/// <param name="nextDomainName">Name of next owner.</param>
		/// <param name="types">Record types of the next owner.</param>
		public NSecRecord(string name, RecordClass recordClass, int timeToLive, string nextDomainName, List<RecordType> types)
			: base(name, RecordType.NSec, recordClass, timeToLive)
		{
			this.NextDomainName = nextDomainName ?? String.Empty;

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
		/// Name of next owner.
		/// </summary>
		public string NextDomainName { get; private set; }
		/// <summary>
		/// Record types of the next owner.
		/// </summary>
		public List<RecordType> Types { get; private set; }

		// Protected properties.

		/// <summary>
		/// Gets the maximum record data length.
		/// </summary>
		protected internal override int MaximumRecordDataLength
		{
			get { return 2 + this.NextDomainName.Length + GetMaximumTypeBitmapLength(this.Types); }
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

			this.NextDomainName = DnsMessageBase.ParseDomainName(resultData, ref currentPosition);
			this.Types = ParseTypeBitmap(resultData, ref currentPosition, endPosition);
		}

		/// <summary>
		/// Parses a bitmap into a list of records types.
		/// </summary>
		/// <param name="resultData">The result data.</param>
		/// <param name="currentPosition">The current position.</param>
		/// <param name="endPosition">The end position.</param>
		/// <returns>The list of record types.</returns>
		internal static List<RecordType> ParseTypeBitmap(byte[] resultData, ref int currentPosition, int endPosition)
		{
			List<RecordType> types = new List<RecordType>();
			while (currentPosition < endPosition)
			{
				byte windowNumber = resultData[currentPosition++];
				byte windowLength = resultData[currentPosition++];

				for (int i = 0; i < windowLength; i++)
				{
					byte bitmap = resultData[currentPosition++];

					for (int bit = 0; bit < 8; bit++)
					{
						if ((bitmap & (1 << Math.Abs(bit - 7))) != 0)
						{
							types.Add((RecordType) (windowNumber * 256 + i * 8 + bit));
						}
					}
				}
			}
			return types;
		}

		/// <summary>
		/// Converts the record data to a string.
		/// </summary>
		/// <returns>The record data string.</returns>
		internal override string RecordDataToString()
		{
			return this.NextDomainName
				+ " " + String.Join(" ", this.Types.ConvertAll<String>(ToString).ToArray());
		}

		/// <summary>
		/// Gets the maximum length of a type bitmap.
		/// </summary>
		/// <param name="types">The list of record types.</param>
		/// <returns>The maximum bitmap length.</returns>
		internal static int GetMaximumTypeBitmapLength(List<RecordType> types)
		{
			int res = 0;

			int windowEnd = 255;
			ushort lastType = 0;

			foreach (ushort type in types.Select(t => (ushort) t))
			{
				if (type > windowEnd)
				{
					res += 3 + lastType % 256 / 8;
					windowEnd = (type / 256 + 1) * 256 - 1;
				}

				lastType = type;
			}

			return res + 3 + lastType % 256 / 8;
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
			DnsMessageBase.EncodeDomainName(messageData, offset, ref currentPosition, NextDomainName, false, domainNames);
			EncodeTypeBitmap(messageData, ref currentPosition, Types);
		}

		/// <summary>
		/// Encodes a type bitmap.
		/// </summary>
		/// <param name="messageData">The message data.</param>
		/// <param name="currentPosition">The current position.</param>
		/// <param name="types">The list of record types.</param>
		internal static void EncodeTypeBitmap(byte[] messageData, ref int currentPosition, List<RecordType> types)
		{
			int windowEnd = 255;
			byte[] windowData = new byte[32];
			int windowLength = 0;

			foreach (ushort type in types.Select(t => (ushort) t))
			{
				if (type > windowEnd)
				{
					if (windowLength > 0)
					{
						messageData[currentPosition++] = (byte) (windowEnd / 256);
						messageData[currentPosition++] = (byte) windowLength;
						DnsMessageBase.EncodeByteArray(messageData, ref currentPosition, windowData, windowLength);
					}

					windowEnd = (type / 256 + 1) * 256 - 1;
					windowLength = 0;
				}

				int typeLower = type % 256;

				int octetPos = typeLower / 8;
				int bitPos = typeLower % 8;

				while (windowLength <= octetPos)
				{
					windowData[windowLength] = 0;
					windowLength++;
				}

				byte octet = windowData[octetPos];
				octet |= (byte) (1 << Math.Abs(bitPos - 7));
				windowData[octetPos] = octet;
			}

			if (windowLength > 0)
			{
				messageData[currentPosition++] = (byte) (windowEnd / 256);
				messageData[currentPosition++] = (byte) windowLength;
				DnsMessageBase.EncodeByteArray(messageData, ref currentPosition, windowData, windowLength);
			}
		}
	}
}