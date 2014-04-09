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
	/// Unknown EDNS option.
	/// </summary>
	public class UnknownOption : EDnsOptionBase
	{
		/// <summary>
		/// Internal constructor.
		/// </summary>
		internal UnknownOption(EDnsOptionType type)
			: base(type) {}

		/// <summary>
		/// Creates a new instance of the UnknownOption class.
		/// </summary>
		/// <param name="type">Type of the option.</param>
		public UnknownOption(EDnsOptionType type, byte[] data)
			: this(type)
		{
			Data = data;
		}

		// Public properties.

		/// <summary>
		/// Binary data of the option.
		/// </summary>
		public byte[] Data { get; private set; }

		// Internal properties.

		/// <summary>
		/// Gets the data length.
		/// </summary>
		internal override ushort DataLength
		{
			get { return (ushort)((this.Data == null) ? 0 : this.Data.Length); }
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
			this.Data = DnsMessageBase.ParseByteData(resultData, ref startPosition, length);
		}

		/// <summary>
		/// Encodes the option.
		/// </summary>
		/// <param name="messageData">The message data.</param>
		/// <param name="currentPosition">The current position.</param>
		internal override void EncodeData(byte[] messageData, ref int currentPosition)
		{
			DnsMessageBase.EncodeByteArray(messageData, ref currentPosition, this.Data);
		}
	}
}