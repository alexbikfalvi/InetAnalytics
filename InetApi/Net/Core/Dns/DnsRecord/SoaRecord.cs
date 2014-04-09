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
	/// <para>Start of zone of authority record</para> <para>Defined in <see cref="http://tools.ietf.org/html/rfc1035">RFC 1035</see>.</para>
	/// </summary>
	public class SoaRecord : DnsRecordBase
	{
		internal SoaRecord() {}

		/// <summary>
		/// Creates a new instance of the SoaRecord class.
		/// </summary>
		/// <param name="name">Name of the zone.</param>
		/// <param name="timeToLive">Seconds the record should be cached at most.</param>
		/// <param name="masterName">Hostname of the primary name server.</param>
		/// <param name="responsibleName">Mail address of the responsable person. The @ should be replaced by a dot.</param>
		/// <param name="serialNumber">Serial number of the zone</param>
		/// <param name="refreshInterval">Seconds before the zone should be refreshed</param>
		/// <param name="retryInterval">Seconds that should be elapsed before retry of failed transfer</param>
		/// <param name="expireInterval">Seconds that can elapse before the zone is no longer authorative /param>
		/// <param name="negativeCachingTTL"><para>Seconds a negative answer could be cached.</para> <para>Defined in<see cref="http://tools.ietf.org/html/rfc2308">RFC 2308</see>.</para></param>
		public SoaRecord(string name, int timeToLive, string masterName, string responsibleName, uint serialNumber, int refreshInterval, int retryInterval, int expireInterval, int negativeCachingTTL)
			: base(name, RecordType.Soa, RecordClass.INet, timeToLive)
		{
			this.MasterName = masterName ?? String.Empty;
			this.ResponsibleName = responsibleName ?? String.Empty;
			this.SerialNumber = serialNumber;
			this.RefreshInterval = refreshInterval;
			this.RetryInterval = retryInterval;
			this.ExpireInterval = expireInterval;
			this.NegativeCachingTTL = negativeCachingTTL;
		}

		// Public properties.

		/// <summary>
		/// Hostname of the primary name server
		/// </summary>
		public string MasterName { get; private set; }
		/// <summary>
		/// Mail address of the responsable person. The @ should be replaced by a dot.
		/// </summary>
		public string ResponsibleName { get; private set; }
		/// <summary>
		/// Serial number of the zone
		/// </summary>
		public uint SerialNumber { get; private set; }
		/// <summary>
		/// Seconds before the zone should be refreshed
		/// </summary>
		public int RefreshInterval { get; private set; }
		/// <summary>
		/// Seconds that should be elapsed before retry of failed transfer
		/// </summary>
		public int RetryInterval { get; private set; }
		/// <summary>
		/// Seconds that can elapse before the zone is no longer authorative
		/// </summary>
		public int ExpireInterval { get; private set; }
		/// <summary>
		/// <para>Seconds a negative answer could be cached</para> <para>Defined in <see cref="http://tools.ietf.org/html/rfc2308">RFC 2308</see>.</para>
		/// </summary>
		public int NegativeCachingTTL { get; private set; }

		// Protected properties.

		/// <summary>
		/// Gets the maximum record data length.
		/// </summary>
		protected internal override int MaximumRecordDataLength
		{
			get { return this.MasterName.Length + this.ResponsibleName.Length + 24; }
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
			this.MasterName = DnsMessageBase.ParseDomainName(resultData, ref startPosition);
			this.ResponsibleName = DnsMessageBase.ParseDomainName(resultData, ref startPosition);

			this.SerialNumber = DnsMessageBase.ParseUInt(resultData, ref startPosition);
			this.RefreshInterval = DnsMessageBase.ParseInt(resultData, ref startPosition);
			this.RetryInterval = DnsMessageBase.ParseInt(resultData, ref startPosition);
			this.ExpireInterval = DnsMessageBase.ParseInt(resultData, ref startPosition);
			this.NegativeCachingTTL = DnsMessageBase.ParseInt(resultData, ref startPosition);
		}

		/// <summary>
		/// Converts the record data to a string.
		/// </summary>
		/// <returns>The record data string.</returns>
		internal override string RecordDataToString()
		{
			return this.MasterName
				+ " " + this.ResponsibleName
				+ " " + this.SerialNumber
				+ " " + this.RefreshInterval
				+ " " + this.RetryInterval
				+ " " + this.ExpireInterval
				+ " " + this.NegativeCachingTTL;
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
			DnsMessageBase.EncodeDomainName(messageData, offset, ref currentPosition, this.MasterName, true, domainNames);
			DnsMessageBase.EncodeDomainName(messageData, offset, ref currentPosition, this.ResponsibleName, true, domainNames);
			DnsMessageBase.EncodeUInt(messageData, ref currentPosition, this.SerialNumber);
			DnsMessageBase.EncodeInt(messageData, ref currentPosition, this.RefreshInterval);
			DnsMessageBase.EncodeInt(messageData, ref currentPosition, this.RetryInterval);
			DnsMessageBase.EncodeInt(messageData, ref currentPosition, this.ExpireInterval);
			DnsMessageBase.EncodeInt(messageData, ref currentPosition, this.NegativeCachingTTL);
		}
	}
}