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
	/// <para>Security Key record.</para>
	/// <para>Defined in <see cref="http://tools.ietf.org/html/rfc4034">RFC 4034</see>, <see cref="http://tools.ietf.org/html/rfc3755">RFC 3755</see>,
	/// <see cref="http://tools.ietf.org/html/rfc2535">RFC 2535</see> and <see cref="http://tools.ietf.org/html/rfc2930">RFC 2930</see>.</para>
	/// </summary>
	public class KeyRecord : KeyRecordBase
	{
		/// <summary>
		/// Internal constructor.
		/// </summary>
		internal KeyRecord() { }

		/// <summary>
		/// Creates of new instance of the KeyRecord class.
		/// </summary>
		/// <param name="name">Name of the record.</param>
		/// <param name="recordClass">Class of the record.</param>
		/// <param name="timeToLive">Seconds the record should be cached at most.</param>
		/// <param name="flags">Flags of the key.</param>
		/// <param name="protocol">Protocol for which the key is used.</param>
		/// <param name="algorithm">Algorithm of the key.</param>
		/// <param name="publicKey">Binary data of the public key.</param>
		public KeyRecord(string name, RecordClass recordClass, int timeToLive, ushort flags, ProtocolType protocol, DnsSecAlgorithm algorithm, byte[] publicKey)
			: base(name, recordClass, timeToLive, flags, protocol, algorithm)
		{
			this.PublicKey = publicKey ?? new byte[] { };
		}

		// Public properties.

		/// <summary>
		/// Binary data of the public key.
		/// </summary>
		public byte[] PublicKey { get; private set; }

		// Protected properties.

		/// <summary>
		/// Gets the maximum public key length.
		/// </summary>
		protected override int MaximumPublicKeyLength
		{
			get { return this.PublicKey.Length; }
		}

		// Protected methods.

		/// <summary>
		/// Parses the public key.
		/// </summary>
		/// <param name="resultData">The result data.</param>
		/// <param name="startPosition">The start position.</param>
		/// <param name="length">The length.</param>
		protected override void ParsePublicKey(byte[] resultData, int startPosition, int length)
		{
			this.PublicKey = DnsMessageBase.ParseByteData(resultData, ref startPosition, length);
		}

		/// <summary>
		/// Converts the public key to a string.
		/// </summary>
		/// <returns>The public key string.</returns>
		protected override string PublicKeyToString()
		{
			return this.PublicKey.ToBase64String();
		}

		/// <summary>
		/// Encodes the public key for this record.
		/// </summary>
		/// <param name="messageData">The message data.</param>
		/// <param name="offset">The offset.</param>
		/// <param name="currentPosition">The current position.</param>
		/// <param name="domainNames">The domain names.</param>
		protected override void EncodePublicKey(byte[] messageData, int offset, ref int currentPosition, Dictionary<string, ushort> domainNames)
		{
			DnsMessageBase.EncodeByteArray(messageData, ref currentPosition, this.PublicKey);
		}
	}
}