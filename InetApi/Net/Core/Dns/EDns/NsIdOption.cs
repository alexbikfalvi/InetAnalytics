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

namespace InetApi.Net.Core.Dns
{
	/// <summary>
	/// <para>Name server ID option.</para> <para>Defined in <see cref="http://tools.ietf.org/html/rfc5001">RFC 5001</see>.</para>
	/// </summary>
	public class NsIdOption : EDnsOptionBase
	{
		/// <summary>
		/// Internal constructor.
		/// </summary>
		internal NsIdOption()
			: base(EDnsOptionType.NsId) {}

		/// <summary>
		/// Creates a new instance of the NsIdOption class
		/// </summary>
		public NsIdOption(byte[] payload)
			: this()
		{
			this.Payload = payload;
		}

		/// <summary>
		/// Binary data of the payload.
		/// </summary>
		public byte[] Payload { get; private set; }

		// Internal properties.

		/// <summary>
		/// Gets the data length.
		/// </summary>
		internal override ushort DataLength
		{
			get { return (ushort)((this.Payload == null) ? 0 : this.Payload.Length); }
		}

		// Internal methods.

		/// <summary>
		/// Parses the data into an option instance.
		/// </summary>
		/// <param name="resultData">The result data.</param>
		/// <param name="startPosition">The start position.</param>
		/// <param name="length">The data length.</param>
		internal override void ParseData(byte[] resultData, int startPosition, int length)
		{
			this.Payload = DnsMessageBase.ParseByteData(resultData, ref startPosition, length);
		}

		/// <summary>
		/// Encodes the option.
		/// </summary>
		/// <param name="messageData">The message data.</param>
		/// <param name="currentPosition">The current position.</param>
		internal override void EncodeData(byte[] messageData, ref int currentPosition)
		{
			DnsMessageBase.EncodeByteArray(messageData, ref currentPosition, this.Payload);
		}
	}
}