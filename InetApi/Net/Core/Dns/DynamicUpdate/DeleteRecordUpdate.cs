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

namespace ARSoft.Tools.Net.Dns.DynamicUpdate
{
	/// <summary>
	/// Delete record action.
	/// </summary>
	public class DeleteRecordUpdate : UpdateBase
	{
		/// <summary>
		/// Internal constructor.
		/// </summary>
		internal DeleteRecordUpdate() { }

		/// <summary>
		/// Creates a new instance of the DeleteRecordUpdate class.
		/// </summary>
		/// <param name="name">Name of the record that should be deleted.</param>
		/// <param name="recordType">Type of the record that should be deleted.</param>
		public DeleteRecordUpdate(string name, RecordType recordType)
			: base(name, recordType, RecordClass.Any, 0) {}

		/// <summary>
		/// Creates a new instance of the DeleteRecordUpdate class.
		/// </summary>
		/// <param name="record">Record that should be deleted.</param>
		public DeleteRecordUpdate(DnsRecordBase record)
			: base(record.Name, record.RecordType, RecordClass.None, 0)
		{
			this.Record = record;
		}

		// Public properties.

		/// <summary>
		/// Record that should be deleted.
		/// </summary>
		public DnsRecordBase Record { get; private set; }

		// Protected properties.

		/// <summary>
		/// Gets the maximum record length.
		/// </summary>
		protected internal override int MaximumRecordDataLength
		{
			get { return (this.Record == null) ? 0 : this.Record.MaximumRecordDataLength; }
		}

		// Internal methods.

		/// <summary>
		/// Parses the record data.
		/// </summary>
		/// <param name="resultData">The result data.</param>
		/// <param name="startPosition">The start position.</param>
		/// <param name="length">The length.</param>
		internal override void ParseRecordData(byte[] resultData, int startPosition, int length) { }

		/// <summary>
		/// Converts the record data to a string.
		/// </summary>
		/// <returns>The string.</returns>
		internal override string RecordDataToString()
		{
			return (this.Record == null) ? null : this.Record.RecordDataToString();
		}

		// Protected methods.

		/// <summary>
		/// Encodes the record data.
		/// </summary>
		/// <param name="messageData">The buffer.</param>
		/// <param name="offset">The offset.</param>
		/// <param name="currentPosition">The current position.</param>
		/// <param name="domainNames">The list of domain names.</param>
		protected internal override void EncodeRecordData(byte[] messageData, int offset, ref int currentPosition, Dictionary<string, ushort> domainNames)
		{
			if (this.Record != null)
				this.Record.EncodeRecordData(messageData, offset, ref currentPosition, domainNames);
		}
	}
}