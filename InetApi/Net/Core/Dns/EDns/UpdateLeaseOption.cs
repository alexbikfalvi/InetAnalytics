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

namespace ARSoft.Tools.Net.Dns
{
	/// <summary>
	/// <para>Update lease option.</para> <para>Defined in <see cref="http://files.dns-sd.org/draft-sekar-dns-ul.txt">draft-sekar-dns-ul</see>.</para>
	/// </summary>
	public class UpdateLeaseOption : EDnsOptionBase
	{
		/// <summary>
		/// Internal constructor.
		/// </summary>
		internal UpdateLeaseOption()
			: base(EDnsOptionType.UpdateLease) {}

		/// <summary>
		/// Creates a new instance of the UpdateLeaseOption class
		/// </summary>
		public UpdateLeaseOption(TimeSpan leaseTime)
			: this()
		{
			this.LeaseTime = leaseTime;
		}

		// Public properties.

		/// <summary>
		/// Desired lease (request) or granted lease (response)
		/// </summary>
		public TimeSpan LeaseTime { get; private set; }

		// Internal properties.

		/// <summary>
		/// Gets the data length.
		/// </summary>
		internal override ushort DataLength
		{
			get { return 4; }
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
			this.LeaseTime = TimeSpan.FromSeconds(DnsMessageBase.ParseInt(resultData, ref startPosition));
		}

		/// <summary>
		/// Encodes the option.
		/// </summary>
		/// <param name="messageData">The message data.</param>
		/// <param name="currentPosition">The current position.</param>
		internal override void EncodeData(byte[] messageData, ref int currentPosition)
		{
			DnsMessageBase.EncodeInt(messageData, ref currentPosition, (int)this.LeaseTime.TotalSeconds);
		}
	}
}