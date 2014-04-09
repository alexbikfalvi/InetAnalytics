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
	/// <para>Security signature record.</para>
	/// <para>Defined in <see cref="http://tools.ietf.org/html/rfc4034">RFC 4034</see>, <see cref="http://tools.ietf.org/html/rfc3755">RFC 3755</see>,
	/// <see cref="http://tools.ietf.org/html/rfc2535">RFC 2535</see> and <see cref="http://tools.ietf.org/html/rfc2931">RFC 2931</see>.</para>
	/// </summary>
	public class SigRecord : DnsRecordBase
	{
		/// <summary>
		/// Internal constructor.
		/// </summary>
		internal SigRecord() { }

		/// <summary>
		/// Creates a new instance of the SigRecord class.
		/// </summary>
		/// <param name="name">Name of the record.</param>
		/// <param name="recordClass">Class of the record.</param>
		/// <param name="timeToLive">Seconds the record should be cached at most.</param>
		/// <param name="typeCovered"><see cref="RecordType">Record type</see> that is covered by this record.</param>
		/// <param name="algorithm"><see cref="DnsSecAlgorithm">Algorithm</see> that is used for signature.</param>
		/// <param name="labels">Label count of original record that is covered by this record.</param>
		/// <param name="originalTimeToLive">Original time to live value of original record that is covered by this record.</param>
		/// <param name="signatureExpiration">Signature is valid until this date.</param>
		/// <param name="signatureInception">Signature is valid from this date.</param>
		/// <param name="keyTag">Key tag.</param>
		/// <param name="signersName">Domain name of generator of the signature.</param>
		/// <param name="signature">Binary data of the signature.</param>
		public SigRecord(string name, RecordClass recordClass, int timeToLive, RecordType typeCovered, DnsSecAlgorithm algorithm, byte labels, int originalTimeToLive, DateTime signatureExpiration, DateTime signatureInception, ushort keyTag, string signersName, byte[] signature)
			: base(name, RecordType.Sig, recordClass, timeToLive)
		{
			this.TypeCovered = typeCovered;
			this.Algorithm = algorithm;
			this.Labels = labels;
			this.OriginalTimeToLive = originalTimeToLive;
			this.SignatureExpiration = signatureExpiration;
			this.SignatureInception = signatureInception;
			this.KeyTag = keyTag;
			this.SignersName = signersName ?? String.Empty;
			this.Signature = signature ?? new byte[] { };
		}

		// Public properties.

		/// <summary>
		/// <see cref="RecordType">Record type</see> that is covered by this record.
		/// </summary>
		public RecordType TypeCovered { get; private set; }
		/// <summary>
		/// <see cref="DnsSecAlgorithm">Algorithm</see> that is used for signature.
		/// </summary>
		public DnsSecAlgorithm Algorithm { get; private set; }
		/// <summary>
		/// Label count of original record that is covered by this record.
		/// </summary>
		public byte Labels { get; private set; }
		/// <summary>
		/// Original time to live value of original record that is covered by this record.
		/// </summary>
		public int OriginalTimeToLive { get; private set; }
		/// <summary>
		/// Signature is valid until this date.
		/// </summary>
		public DateTime SignatureExpiration { get; private set; }
		/// <summary>
		/// Signature is valid from this date.
		/// </summary>
		public DateTime SignatureInception { get; private set; }
		/// <summary>
		/// Key tag.
		/// </summary>
		public ushort KeyTag { get; private set; }
		/// <summary>
		/// Domain name of generator of the signature.
		/// </summary>
		public string SignersName { get; private set; }
		/// <summary>
		/// Binary data of the signature.
		/// </summary>
		public byte[] Signature { get; private set; }

		// Protected properties.

		/// <summary>
		/// Gets the maximum record data length.
		/// </summary>
		protected internal override int MaximumRecordDataLength
		{
			get { return 20 + SignersName.Length + Signature.Length; }
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
			int currentPosition = startPosition;

			this.TypeCovered = (RecordType)DnsMessageBase.ParseUShort(resultData, ref currentPosition);
			this.Algorithm = (DnsSecAlgorithm)resultData[currentPosition++];
			this.Labels = resultData[currentPosition++];
			this.OriginalTimeToLive = DnsMessageBase.ParseInt(resultData, ref currentPosition);
			this.SignatureExpiration = ParseDateTime(resultData, ref currentPosition);
			this.SignatureInception = ParseDateTime(resultData, ref currentPosition);
			this.KeyTag = DnsMessageBase.ParseUShort(resultData, ref currentPosition);
			this.SignersName = DnsMessageBase.ParseDomainName(resultData, ref currentPosition);
			this.Signature = DnsMessageBase.ParseByteData(resultData, ref currentPosition, length + startPosition - currentPosition);
		}

		/// <summary>
		/// Converts the record data to a string.
		/// </summary>
		/// <returns>The record data string.</returns>
		internal override string RecordDataToString()
		{
			return DnsRecordBase.ToString(this.TypeCovered)
				+ " " + (byte)this.Algorithm
				+ " " + this.Labels
				+ " " + this.OriginalTimeToLive
				+ " " + this.SignatureExpiration.ToString("yyyyMMddHHmmss")
				+ " " + this.SignatureInception.ToString("yyyyMMddHHmmss")
				+ " " + this.KeyTag
				+ " " + this.SignersName
				+ " " + this.Signature.ToBase64String();
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
			DnsMessageBase.EncodeUShort(messageData, ref currentPosition, (ushort) TypeCovered);
			messageData[currentPosition++] = (byte) Algorithm;
			messageData[currentPosition++] = Labels;
			DnsMessageBase.EncodeInt(messageData, ref currentPosition, OriginalTimeToLive);
			EncodeDateTime(messageData, ref currentPosition, SignatureExpiration);
			EncodeDateTime(messageData, ref currentPosition, SignatureInception);
			DnsMessageBase.EncodeUShort(messageData, ref currentPosition, KeyTag);
			DnsMessageBase.EncodeDomainName(messageData, offset, ref currentPosition, SignersName, false, null);
			DnsMessageBase.EncodeByteArray(messageData, ref currentPosition, Signature);
		}

		/// <summary>
		/// Encodes a date-time value.
		/// </summary>
		/// <param name="buffer">The buffer.</param>
		/// <param name="currentPosition">The current position.</param>
		/// <param name="value">The value.</param>
		internal static void EncodeDateTime(byte[] buffer, ref int currentPosition, DateTime value)
		{
			int timeStamp = (int) (value.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
			DnsMessageBase.EncodeInt(buffer, ref currentPosition, timeStamp);
		}

		// Private methods.

		/// <summary>
		/// Parses a date-time value.
		/// </summary>
		/// <param name="buffer">The buffer.</param>
		/// <param name="currentPosition">The current position.</param>
		/// <returns>The date-time value.</returns>
		private static DateTime ParseDateTime(byte[] buffer, ref int currentPosition)
		{
			int timeStamp = DnsMessageBase.ParseInt(buffer, ref currentPosition);
			return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(timeStamp).ToLocalTime();
		}
	}
}