﻿/* 
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
	/// Base class representing a DNS record.
	/// </summary>
	public abstract class DnsRecordBase : DnsMessageEntryBase
	{
		/// <summary>
		/// Protected constructor.
		/// </summary>
		protected DnsRecordBase() { }

		/// <summary>
		/// Creates a new DNS record instance.
		/// </summary>
		/// <param name="name">The record name.</param>
		/// <param name="recordType">The record type.</param>
		/// <param name="recordClass">The record class.</param>
		/// <param name="timeToLive">The record time-to-live.</param>
		protected DnsRecordBase(string name, RecordType recordType, RecordClass recordClass, int timeToLive)
		{
			this.Name = name ?? String.Empty;
			this.RecordType = recordType;
			this.RecordClass = recordClass;
			this.TimeToLive = timeToLive;
		}

		// Public properties.

		/// <summary>
		/// Seconds which a record should be cached at most.
		/// </summary>
		public int TimeToLive { get; internal set; }

		// Internal properties.

		/// <summary>
		/// The start position.
		/// </summary>
		internal int StartPosition { get; set; }
		/// <summary>
		/// The record data length.
		/// </summary>
		internal ushort RecordDataLength { get; set; }

		// Internal methods.

		/// <summary>
		/// Creates a new DNS record instance.
		/// </summary>
		/// <param name="type">The record type.</param>
		/// <param name="resultData">The DNS record data.</param>
		/// <param name="recordDataPosition">The position in the DNS record data.</param>
		/// <returns>The DNS record.</returns>
		internal static DnsRecordBase Create(RecordType type, byte[] resultData, int recordDataPosition)
		{
			switch (type)
			{
				case RecordType.A:
					return new ARecord();
				case RecordType.Ns:
					return new NsRecord();
				case RecordType.CName:
					return new CNameRecord();
				case RecordType.Soa:
					return new SoaRecord();
				case RecordType.Wks:
					return new WksRecord();
				case RecordType.Ptr:
					return new PtrRecord();
				case RecordType.HInfo:
					return new HInfoRecord();
				case RecordType.Mx:
					return new MxRecord();
				case RecordType.Txt:
					return new TxtRecord();
				case RecordType.Rp:
					return new RpRecord();
				case RecordType.Afsdb:
					return new AfsdbRecord();
				case RecordType.X25:
					return new X25Record();
				case RecordType.Isdn:
					return new IsdnRecord();
				case RecordType.Rt:
					return new RtRecord();
				case RecordType.Nsap:
					return new NsapRecord();
				case RecordType.Sig:
					return new SigRecord();
				case RecordType.Key:
					if (resultData[recordDataPosition + 3] == (byte) DnsSecAlgorithm.DiffieHellman)
					{
						return new DiffieHellmanKeyRecord();
					}
					else
					{
						return new KeyRecord();
					}
				case RecordType.Px:
					return new PxRecord();
				case RecordType.GPos:
					return new GPosRecord();
				case RecordType.Aaaa:
					return new AaaaRecord();
				case RecordType.Loc:
					return new LocRecord();
				case RecordType.Srv:
					return new SrvRecord();
				case RecordType.Naptr:
					return new NaptrRecord();
				case RecordType.Kx:
					return new KxRecord();
				case RecordType.Cert:
					return new CertRecord();
				case RecordType.DName:
					return new DNameRecord();
				case RecordType.Opt:
					return new OptRecord();
				case RecordType.Apl:
					return new AplRecord();
				case RecordType.Ds:
					return new DsRecord();
				case RecordType.SshFp:
					return new SshFpRecord();
				case RecordType.IpSecKey:
					return new IpSecKeyRecord();
				case RecordType.RrSig:
					return new RrSigRecord();
				case RecordType.NSec:
					return new NSecRecord();
				case RecordType.DnsKey:
					return new DnsKeyRecord();
				case RecordType.Dhcid:
					return new DhcidRecord();
				case RecordType.NSec3:
					return new NSec3Record();
				case RecordType.NSec3Param:
					return new NSec3ParamRecord();
				case RecordType.Hip:
					return new HipRecord();
				case RecordType.Spf:
					return new SpfRecord();
				case RecordType.TKey:
					return new TKeyRecord();
				case RecordType.TSig:
					return new TSigRecord();
				case RecordType.Dlv:
					return new DlvRecord();

				default:
					return new UnknownRecord();
			}
		}

		#region ToString
		internal abstract string RecordDataToString();

		/// <summary>
		/// Returns the textual representation of a record
		/// </summary>
		/// <returns> Textual representation </returns>
		public override string ToString()
		{
			string recordData = (RecordDataLength != 0) ? RecordDataToString() : null;

			return Name + " " + TimeToLive + " " + ToString(RecordClass) + " " + ToString(RecordType) + (String.IsNullOrEmpty(recordData) ? "" : " " + recordData);
		}

		protected static string ToString(RecordClass recordClass)
		{
			switch (recordClass)
			{
				case RecordClass.INet:
					return "IN";
				case RecordClass.Chaos:
					return "CH";
				case RecordClass.Hesiod:
					return "HS";
				case RecordClass.None:
					return "NONE";
				case RecordClass.Any:
					return "*";
				default:
					return "CLASS" + (int) recordClass;
			}
		}

		protected static string ToString(RecordType recordType)
		{
			string res;
			if (!EnumHelper<RecordType>.Names.TryGetValue(recordType, out res))
			{
				return "TYPE" + (int) recordType;
			}
			return res.ToUpper();
		}
		#endregion

		#region Parsing
		internal abstract void ParseRecordData(byte[] resultData, int startPosition, int length);

		internal virtual void ParseRecordData(string[] stringRepresentation) {}
		#endregion

		#region Encoding
		internal override sealed int MaximumLength
		{
			get { return Name.Length + 12 + MaximumRecordDataLength; }
		}

		internal void Encode(byte[] messageData, int offset, ref int currentPosition, Dictionary<string, ushort> domainNames)
		{
			int recordDataOffset;
			EncodeRecordHeader(messageData, offset, ref currentPosition, domainNames, out recordDataOffset);

			EncodeRecordData(messageData, offset, ref recordDataOffset, domainNames);

			EncodeRecordLength(messageData, offset, ref currentPosition, domainNames, recordDataOffset);
		}

		internal void EncodeRecordHeader(byte[] messageData, int offset, ref int currentPosition, Dictionary<string, ushort> domainNames, out int recordPosition)
		{
			DnsMessageBase.EncodeDomainName(messageData, offset, ref currentPosition, Name, true, domainNames);
			DnsMessageBase.EncodeUShort(messageData, ref currentPosition, (ushort) RecordType);
			DnsMessageBase.EncodeUShort(messageData, ref currentPosition, (ushort) RecordClass);
			DnsMessageBase.EncodeInt(messageData, ref currentPosition, TimeToLive);

			recordPosition = currentPosition + 2;
		}

		internal void EncodeRecordLength(byte[] messageData, int offset, ref int recordDataOffset, Dictionary<string, ushort> domainNames, int recordPosition)
		{
			DnsMessageBase.EncodeUShort(messageData, ref recordDataOffset, (ushort) (recordPosition - recordDataOffset - 2));
			recordDataOffset = recordPosition;
		}


		protected internal abstract int MaximumRecordDataLength { get; }

		protected internal abstract void EncodeRecordData(byte[] messageData, int offset, ref int currentPosition, Dictionary<string, ushort> domainNames);
		#endregion
	}
}