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
	/// <para>SSH key fingerprint record.</para> <para>Defined in<see cref="http://tools.ietf.org/html/rfc4255">RFC 4255</see></para>
	/// </summary>
	public class SshFpRecord : DnsRecordBase
	{
		/// <summary>
		/// Algorithm of the fingerprint.
		/// </summary>
		public enum SshFpAlgorithm : byte
		{
			/// <summary>
			/// None.
			/// </summary>
			None = 0,
			/// <summary>
			/// <para>RSA.</para> <para>Defined in <see cref="http://tools.ietf.org/html/rfc4255">RFC 4255</see>.</para>
			/// </summary>
			Rsa = 1,
			/// <summary>
			/// <para>DSA.</para> <para>Defined in <see cref="http://tools.ietf.org/html/rfc4255">RFC 4255</see>.</para>
			/// </summary>
			Dsa = 2
		}

		/// <summary>
		/// Type of the fingerprint.
		/// </summary>
		public enum SshFpFingerPrintType : byte
		{
			/// <summary>
			/// None.
			/// </summary>
			None = 0,
			/// <summary>
			/// <para>SHA-1.</para> <para>Defined in <see cref="http://tools.ietf.org/html/rfc4255">RFC 4255</see>.</para>
			/// </summary>
			Sha1 = 1,
		}

		/// <summary>
		/// Internal constructor.
		/// </summary>
		internal SshFpRecord() { }

		/// <summary>
		/// Creates a new instance of the SshFpRecord class.
		/// </summary>
		/// <param name="name">Name of the record.</param>
		/// <param name="timeToLive">Seconds the record should be cached at most.</param>
		/// <param name="algorithm">Algorithm of fingerprint.</param>
		/// <param name="fingerPrintType">Type of fingerprint.</param>
		/// <param name="fingerPrint">Binary data of the fingerprint.</param>
		public SshFpRecord(string name, int timeToLive, SshFpAlgorithm algorithm, SshFpFingerPrintType fingerPrintType, byte[] fingerPrint)
			: base(name, RecordType.SshFp, RecordClass.INet, timeToLive)
		{
			this.Algorithm = algorithm;
			this.FingerPrintType = fingerPrintType;
			this.FingerPrint = fingerPrint ?? new byte[] { };
		}

		/// <summary>
		/// Algorithm of fingerprint.
		/// </summary>
		public SshFpAlgorithm Algorithm { get; private set; }
		/// <summary>
		/// Type of fingerprint.
		/// </summary>
		public SshFpFingerPrintType FingerPrintType { get; private set; }
		/// <summary>
		/// Binary data of the fingerprint.
		/// </summary>
		public byte[] FingerPrint { get; private set; }

		// Protected properties.

		/// <summary>
		/// Gets the maximum record data length.
		/// </summary>
		protected internal override int MaximumRecordDataLength
		{
			get { return 2 + this.FingerPrint.Length; }
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
			this.Algorithm = (SshFpAlgorithm) resultData[currentPosition++];
			this.FingerPrintType = (SshFpFingerPrintType)resultData[currentPosition++];
			this.FingerPrint = DnsMessageBase.ParseByteData(resultData, ref currentPosition, length - 2);
		}

		/// <summary>
		/// Converts the record data to a string.
		/// </summary>
		/// <returns>The record data string.</returns>
		internal override string RecordDataToString()
		{
			return (byte) this.Algorithm
				+ " " + (byte) this.FingerPrintType
				+ " " + this.FingerPrint.ToBase16String();
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
			messageData[currentPosition++] = (byte)this.Algorithm;
			messageData[currentPosition++] = (byte)this.FingerPrintType;
			DnsMessageBase.EncodeByteArray(messageData, ref currentPosition, this.FingerPrint);
		}
	}
}