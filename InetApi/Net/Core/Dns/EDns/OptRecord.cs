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

namespace ARSoft.Tools.Net.Dns
{
	/// <summary>
	/// <para>OPT record.</para> <para>Defined in<see cref="http://tools.ietf.org/html/rfc2671">RFC 2671</see>.</para>
	/// </summary>
	public class OptRecord : DnsRecordBase
	{
		/// <summary>
		/// Creates a new instance of the OptRecord
		/// </summary>
		public OptRecord()
			: base(".", RecordType.Opt, unchecked((RecordClass) 512), 0)
		{
			this.Options = new List<EDnsOptionBase>();
		}

		// Public methods.

		/// <summary>
		/// Gets or set the sender's UDP payload size.
		/// </summary>
		public ushort UpdPayloadSize
		{
			get { return (ushort)this.RecordClass; }
			set { this.RecordClass = (RecordClass)value; }
		}
		/// <summary>
		/// Gets or sets the high bits of return code (EXTENDED-RCODE).
		/// </summary>
		public ReturnCode ExtendedReturnCode
		{
			get { return (ReturnCode)((this.TimeToLive & 0xff000000) >> 20); }
			set
			{
				int clearedTtl = (this.TimeToLive & 0x00ffffff);
				this.TimeToLive = (clearedTtl | ((int)value << 20));
			}
		}
		/// <summary>
		/// Gets or set the EDNS version.
		/// </summary>
		public byte Version
		{
			get { return (byte)((TimeToLive & 0x00ff0000) >> 16); }
			set
			{
				int clearedTtl = (int)((uint)this.TimeToLive & 0xff00ffff);
				this.TimeToLive = clearedTtl | (value << 16);
			}
		}
		/// <summary>
		/// <para>Gets or sets the DNSSEC OK (DO) flag.</para>
		/// <para>Defined in <see cref="http://tools.ietf.org/html/rfc4035">RFC 4035</see> and<see cref="http://tools.ietf.org/html/rfc3225">RFC 3225</see>.</para>
		/// </summary>
		public bool IsDnsSecOk
		{
			get { return (this.TimeToLive & 0x8000) != 0; }
			set
			{
				if (value)
				{
					this.TimeToLive |= 0x8000;
				}
				else
				{
					this.TimeToLive &= 0x7fff;
				}
			}
		}
		/// <summary>
		/// Gets or set additional EDNS options
		/// </summary>
		public List<EDnsOptionBase> Options { get; private set; }

		// Protected properties.

		/// <summary>
		/// Gets the maximum record data length.
		/// </summary>
		protected internal override int MaximumRecordDataLength
		{
			get
			{
				if ((Options == null) || (Options.Count == 0))
				{
					return 0;
				}
				else
				{
					return Options.Sum(option => option.DataLength + 4);
				}
			}
		}


		// Public methods.

		/// <summary>
		/// Parses the data into an option instance.
		/// </summary>
		/// <param name="resultData">The result data.</param>
		/// <param name="startPosition">The start position.</param>
		/// <param name="length">The data length.</param>
		internal override void ParseRecordData(byte[] resultData, int startPosition, int length)
		{
			int endPosition = startPosition + length;

			this.Options = new List<EDnsOptionBase>();
			while (startPosition < endPosition)
			{
				EDnsOptionType type = (EDnsOptionType) DnsMessageBase.ParseUShort(resultData, ref startPosition);
				ushort dataLength = DnsMessageBase.ParseUShort(resultData, ref startPosition);

				EDnsOptionBase option;

				switch (type)
				{
					case EDnsOptionType.LongLivedQuery:
						option = new LongLivedQueryOption();
						break;
					case EDnsOptionType.UpdateLease:
						option = new UpdateLeaseOption();
						break;
					case EDnsOptionType.NsId:
						option = new NsIdOption();
						break;
					case EDnsOptionType.Owner:
						option = new OwnerOption();
						break;
					default:
						option = new UnknownOption(type);
						break;
				}

				option.ParseData(resultData, startPosition, dataLength);
				this.Options.Add(option);
				startPosition += dataLength;
			}
		}

		/// <summary>
		/// Returns the textual representation of the OptRecord
		/// </summary>
		/// <returns> The textual representation </returns>
		public override string ToString()
		{
			return this.RecordDataToString();
		}

		// Internal methods.

		/// <summary>
		/// Converts the options record to a string.
		/// </summary>
		/// <returns>The string.</returns>
		internal override string RecordDataToString()
		{
			string flags = IsDnsSecOk ? "DO" : "";
			return String.Format("; EDNS version: {0}; flags: {1}; udp: {2}", Version, flags, UpdPayloadSize);
		}

		// Protected methods.

		/// <summary>
		/// Encodes the options record data.
		/// </summary>
		/// <param name="messageData">The message data.</param>
		/// <param name="offset">The offset.</param>
		/// <param name="currentPosition">The current position.</param>
		/// <param name="domainNames">The domain names.</param>
		protected internal override void EncodeRecordData(byte[] messageData, int offset, ref int currentPosition, Dictionary<string, ushort> domainNames)
		{
			if ((this.Options != null) && (this.Options.Count != 0))
			{
				foreach (EDnsOptionBase option in this.Options)
				{
					DnsMessageBase.EncodeUShort(messageData, ref currentPosition, (ushort) option.Type);
					DnsMessageBase.EncodeUShort(messageData, ref currentPosition, option.DataLength);
					option.EncodeData(messageData, ref currentPosition);
				}
			}
		}
	}
}