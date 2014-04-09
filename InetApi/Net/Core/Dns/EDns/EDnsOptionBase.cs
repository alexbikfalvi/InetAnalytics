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
using System.Text;

namespace InetApi.Net.Core.Dns
{
	/// <summary>
	/// Base class of EDNS options.
	/// </summary>
	public abstract class EDnsOptionBase
	{
		/// <summary>
		/// Internal constructor.
		/// </summary>
		/// <param name="optionType">The option type.</param>
		internal EDnsOptionBase(EDnsOptionType optionType)
		{
			Type = optionType;
		}

		// Public properties.

		/// <summary>
		/// Type of the option.
		/// </summary>
		public EDnsOptionType Type { get; internal set; }

		// Internal properties.

		/// <summary>
		/// Gets the data length.
		/// </summary>
		internal abstract ushort DataLength { get; }

		// Internal methods.

		/// <summary>
		/// Parses the data into an option instance.
		/// </summary>
		/// <param name="resultData">The result data.</param>
		/// <param name="startPosition">The start position.</param>
		/// <param name="length">The data length.</param>
		internal abstract void ParseData(byte[] resultData, int startPosition, int length);

		/// <summary>
		/// Encodes the option.
		/// </summary>
		/// <param name="messageData">The message data.</param>
		/// <param name="currentPosition">The current position.</param>
		internal abstract void EncodeData(byte[] messageData, ref int currentPosition);
	}
}