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

namespace ARSoft.Tools.Net.Dns
{
	/// <summary>
	/// Base class for a DNS name identity.
	/// </summary>
	public abstract class DnsMessageEntryBase
	{
		// Public properties.

		/// <summary>
		/// Domain name.
		/// </summary>
		public string Name { get; internal set; }
		/// <summary>
		/// Type of the record.
		/// </summary>
		public RecordType RecordType { get; internal set; }
		/// <summary>
		/// Class of the record.
		/// </summary>
		public RecordClass RecordClass { get; internal set; }

		// Internal properties.

		/// <summary>
		/// The maximum length.
		/// </summary>
		internal abstract int MaximumLength { get; }

		// Public methods.

		/// <summary>
		/// Returns the textual representation.
		/// </summary>
		/// <returns>Textual representation.</returns>
		public override string ToString()
		{
			return this.Name + " " + this.RecordType + " " + this.RecordClass;
		}
	}
}