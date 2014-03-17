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
	/// <para>Transaction key.</para> <para>Defined in <see cref="http://tools.ietf.org/html/rfc2930">RFC 2930</see>.</para>
	/// </summary>
	public class TKeyRecord : DnsRecordBase
	{
		/// <summary>
		/// Mode of transaction.
		/// </summary>
		public enum TKeyMode : ushort
		{
			/// <summary>
			/// <para>Server assignment.</para> <para>Defined in <see cref="http://tools.ietf.org/html/rfc2930">RFC 2930</see>.</para>
			/// </summary>
			ServerAssignment = 1, // RFC2930
			/// <summary>
			/// <para>Diffie-Hellman exchange.</para> <para>Defined in <see cref="http://tools.ietf.org/html/rfc2930">RFC 2930</see>.</para>
			/// </summary>
			DiffieHellmanExchange = 2, // RFC2930
			/// <summary>
			/// <para>GSS-API negotiation.</para> <para>Defined in <see cref="http://tools.ietf.org/html/rfc2930">RFC 2930</see>.</para>
			/// </summary>
			GssNegotiation = 3, // RFC2930
			/// <summary>
			/// <para>Resolver assignment.</para> <para>Defined in <see cref="http://tools.ietf.org/html/rfc2930">RFC 2930</see>.</para>
			/// </summary>
			ResolverAssignment = 4, // RFC2930
			/// <summary>
			/// <para>Key deletion.</para> <para>Defined in <see cref="http://tools.ietf.org/html/rfc2930">RFC 2930</see>.</para>
			/// </summary>
			KeyDeletion = 5, // RFC2930
		}

		internal TKeyRecord() {}

		/// <summary>
		/// Creates a new instance of the TKeyRecord class.
		/// </summary>
		/// <param name="name">Name of the record.</param>
		/// <param name="algorithm">Algorithm of the key.</param>
		/// <param name="inception">Date from which the key is valid.</param>
		/// <param name="expiration">Date to which the key is valid.</param>
		/// <param name="mode">Mode of transaction.</param>
		/// <param name="error">Error field.</param>
		/// <param name="key">Binary data of the key.</param>
		/// <param name="otherData">Binary other data.</param>
		public TKeyRecord(string name, TSigAlgorithm algorithm, DateTime inception, DateTime expiration, TKeyMode mode, ReturnCode error, byte[] key, byte[] otherData)
			: base(name, RecordType.TKey, RecordClass.Any, 0)
		{
			this.Algorithm = algorithm;
			this.Inception = inception;
			this.Expiration = expiration;
			this.Mode = mode;
			this.Error = error;
			this.Key = key ?? new byte[] { };
			this.OtherData = otherData ?? new byte[] { };
		}

		// Public properties.

		/// <summary>
		/// Algorithm of the key.
		/// </summary>
		public TSigAlgorithm Algorithm { get; private set; }
		/// <summary>
		/// Date from which the key is valid.
		/// </summary>
		public DateTime Inception { get; private set; }
		/// <summary>
		/// Date to which the key is valid.
		/// </summary>
		public DateTime Expiration { get; private set; }
		/// <summary>
		/// Mode of transaction.
		/// </summary>
		public TKeyMode Mode { get; private set; }
		/// <summary>
		/// Error field.
		/// </summary>
		public ReturnCode Error { get; private set; }
		/// <summary>
		/// Binary data of the key.
		/// </summary>
		public byte[] Key { get; private set; }
		/// <summary>
		/// Binary other data.
		/// </summary>
		public byte[] OtherData { get; private set; }

		// Protected properties.

		/// <summary>
		/// Gets the maximum record data length.
		/// </summary>
		protected internal override int MaximumRecordDataLength
		{
			get { return 18 + TSigAlgorithmHelper.GetDomainName(this.Algorithm).Length + this.Key.Length + this.OtherData.Length; }
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
			this.Algorithm = TSigAlgorithmHelper.GetAlgorithmByName(DnsMessageBase.ParseDomainName(resultData, ref startPosition));
			this.Inception = ParseDateTime(resultData, ref startPosition);
			this.Expiration = ParseDateTime(resultData, ref startPosition);
			this.Mode = (TKeyMode)DnsMessageBase.ParseUShort(resultData, ref startPosition);
			this.Error = (ReturnCode)DnsMessageBase.ParseUShort(resultData, ref startPosition);
			int keyLength = DnsMessageBase.ParseUShort(resultData, ref startPosition);
			this.Key = DnsMessageBase.ParseByteData(resultData, ref startPosition, keyLength);
			int otherDataLength = DnsMessageBase.ParseUShort(resultData, ref startPosition);
			this.OtherData = DnsMessageBase.ParseByteData(resultData, ref startPosition, otherDataLength);
		}

		/// <summary>
		/// Converts the record data to a string.
		/// </summary>
		/// <returns>The record data string.</returns>
		internal override string RecordDataToString()
		{
			return TSigAlgorithmHelper.GetDomainName(this.Algorithm)
				+ " " + (int)(this.Inception - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds
				+ " " + (int)(this.Expiration - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds
				+ " " + (ushort)this.Mode
				+ " " + (ushort)this.Error
				+ " " + this.Key.ToBase64String()
				+ " " + this.OtherData.ToBase64String();
		}

		/// <summary>
		/// Encodes the date-time.
		/// </summary>
		/// <param name="buffer">The buffer.</param>
		/// <param name="currentPosition">The buffer position.</param>
		/// <param name="value">The date-time value.</param>
		internal static void EncodeDateTime(byte[] buffer, ref int currentPosition, DateTime value)
		{
			int timeStamp = (int)(value.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
			DnsMessageBase.EncodeInt(buffer, ref currentPosition, timeStamp);
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
			DnsMessageBase.EncodeDomainName(messageData, offset, ref currentPosition, TSigAlgorithmHelper.GetDomainName(this.Algorithm), false, domainNames);
			EncodeDateTime(messageData, ref currentPosition, this.Inception);
			EncodeDateTime(messageData, ref currentPosition, this.Expiration);
			DnsMessageBase.EncodeUShort(messageData, ref currentPosition, (ushort)this.Mode);
			DnsMessageBase.EncodeUShort(messageData, ref currentPosition, (ushort)this.Error);
			DnsMessageBase.EncodeUShort(messageData, ref currentPosition, (ushort)this.Key.Length);
			DnsMessageBase.EncodeByteArray(messageData, ref currentPosition, this.Key);
			DnsMessageBase.EncodeUShort(messageData, ref currentPosition, (ushort)this.OtherData.Length);
			DnsMessageBase.EncodeByteArray(messageData, ref currentPosition, this.OtherData);
		}

		// Private methods.

		/// <summary>
		/// Parses the date-time.
		/// </summary>
		/// <param name="buffer">The buffer.</param>
		/// <param name="currentPosition">The buffer position.</param>
		/// <returns>The date-time value.</returns>
		private static DateTime ParseDateTime(byte[] buffer, ref int currentPosition)
		{
			int timeStamp = DnsMessageBase.ParseInt(buffer, ref currentPosition);
			return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(timeStamp).ToLocalTime();
		}
	}
}