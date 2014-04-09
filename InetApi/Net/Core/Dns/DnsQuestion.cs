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
	/// A single entry of the question section of a DNS query.
	/// </summary>
	public class DnsQuestion : DnsMessageEntryBase
	{
		/// <summary>
		/// Internal constructor.
		/// </summary>
		internal DnsQuestion() { }

		/// <summary>
		/// Creates a new instance of the DnsQuestion class.
		/// </summary>
		/// <param name="name">Domain name </param>
		/// <param name="recordType">Record type.</param>
		/// <param name="recordClass">Record class.</param>
		public DnsQuestion(string name, RecordType recordType, RecordClass recordClass)
		{
			base.Name = name ?? String.Empty;
			base.RecordType = recordType;
			base.RecordClass = recordClass;
		}

		#region Internal properties.

		/// <summary>
		/// Gets the maximum length.
		/// </summary>
		internal override int MaximumLength
		{
			get { return base.Name.Length + 6; }
		}

		#endregion

		#region Internal methods

		/// <summary>
		/// Encodes the DNS question.
		/// </summary>
		/// <param name="messageData">The message data.</param>
		/// <param name="offset">The offset.</param>
		/// <param name="currentPosition">The current position.</param>
		/// <param name="domainNames">The domain names.</param>
		internal void Encode(byte[] messageData, int offset, ref int currentPosition, Dictionary<string, ushort> domainNames)
		{
			DnsMessageBase.EncodeDomainName(messageData, offset, ref currentPosition, base.Name, true, domainNames);
			DnsMessageBase.EncodeUShort(messageData, ref currentPosition, (ushort)base.RecordType);
			DnsMessageBase.EncodeUShort(messageData, ref currentPosition, (ushort)base.RecordClass);
		}

		#endregion
	}
}