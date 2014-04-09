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

namespace InetApi.Net.Core.Dns.DynamicUpdate
{
	/// <summary>
	/// <para>Dynamic DNS update message.</para> <para>Defined in <see cref="http://tools.ietf.org/html/rfc2136">RFC 2136</see>.</para>
	/// </summary>
	public class DnsUpdateMessage : DnsMessageBase
	{
		private List<PrequisiteBase> prequisites;
		private List<UpdateBase> updates;

		/// <summary>
		/// Creates a new instance of the DnsUpdateMessage class.
		/// </summary>
		public DnsUpdateMessage()
		{
			OperationCode = OperationCode.Update;
		}

		// Public properties.

		/// <summary>
		/// Gets or sets the zone name
		/// </summary>
		public string ZoneName
		{
			get { return this.Questions.Count > 0 ? this.Questions[0].Name : null; }
			set { this.Questions = new List<DnsQuestion>() { new DnsQuestion(value, RecordType.Soa, RecordClass.Any) }; }
		}
		/// <summary>
		/// Gets or sets the entries in the prerequisites section
		/// </summary>
		public List<PrequisiteBase> Prequisites
		{
			get { return this.prequisites ?? (this.prequisites = new List<PrequisiteBase>()); }
			set { this.prequisites = value; }
		}
		/// <summary>
		/// Gets or sets the entries in the update section
		/// </summary>
		public List<UpdateBase> Updates
		{
			get { return this.updates ?? (this.updates = new List<UpdateBase>()); }
			set { this.updates = value; }
		}

		// Internal properties.

		/// <summary>
		/// Gets whether TCP using is requested.
		/// </summary>
		internal override bool IsTcpUsingRequested
		{
			get { return false; }
		}
		/// <summary>
		/// Gets whether TCP resending is requested.
		/// </summary>
		internal override bool IsTcpResendingRequested
		{
			get { return false; }
		}
		/// <summary>
		/// Gets whether TCP next message is waiting.
		/// </summary>
		internal override bool IsTcpNextMessageWaiting
		{
			get { return false; }
		}

		// Protected methods.

		/// <summary>
		/// A method called when preparing the encoding.
		/// </summary>
		protected override void PrepareEncoding()
		{
			this.AnswerRecords = (this.Prequisites != null ? this.Prequisites.Cast<DnsRecordBase>().ToList() : new List<DnsRecordBase>());
			this.AuthorityRecords = (this.Updates != null ? this.Updates.Cast<DnsRecordBase>().ToList() : new List<DnsRecordBase>());
		}

		/// <summary>
		/// A method called when the parsing of a message has finished.
		/// </summary>
		protected override void FinishParsing()
		{
			this.Prequisites =
				this.AnswerRecords.ConvertAll<PrequisiteBase>(
					record =>
					{
						if ((record.RecordClass == RecordClass.Any) && (record.RecordDataLength == 0))
						{
							return new RecordExistsPrequisite(record.Name, record.RecordType);
						}
						else if (record.RecordClass == RecordClass.Any)
						{
							return new RecordExistsPrequisite(record);
						}
						else if ((record.RecordClass == RecordClass.None) && (record.RecordDataLength == 0))
						{
							return new RecordNotExistsPrequisite(record.Name, record.RecordType);
						}
						else if ((record.RecordClass == RecordClass.Any) && (record.RecordType == RecordType.Any))
						{
							return new NameIsInUsePrequisite(record.Name);
						}
						else if ((record.RecordClass == RecordClass.None) && (record.RecordType == RecordType.Any))
						{
							return new NameIsNotInUsePrequisite(record.Name);
						}
						else
						{
							return null;
						}
					}).Where(prequisite => (prequisite != null)).ToList();

			this.Updates =
				this.AuthorityRecords.ConvertAll<UpdateBase>(
					record =>
					{
						if (record.TimeToLive != 0)
						{
							return new AddRecordUpdate(record);
						}
						else if ((record.RecordType == RecordType.Any) && (record.RecordClass == RecordClass.Any) && (record.RecordDataLength == 0))
						{
							return new DeleteAllRecordsUpdate(record.Name);
						}
						else if ((record.RecordClass == RecordClass.Any) && (record.RecordDataLength == 0))
						{
							return new DeleteRecordUpdate(record.Name, record.RecordType);
						}
						else if (record.RecordClass == RecordClass.Any)
						{
							return new DeleteRecordUpdate(record);
						}
						else
						{
							return null;
						}
					}).Where(update => (update != null)).ToList();
		}
	}
}