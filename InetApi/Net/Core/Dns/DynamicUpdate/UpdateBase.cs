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

namespace ARSoft.Tools.Net.Dns.DynamicUpdate
{
	/// <summary>
	///   Base update action of dynamic dns update
	/// </summary>
	public abstract class UpdateBase : DnsRecordBase
	{
		/// <summary>
		/// Internal constructor.
		/// </summary>
		internal UpdateBase() { }

		/// <summary>
		/// Creates a new update record instance.
		/// </summary>
		/// <param name="name">The record name.</param>
		/// <param name="recordType">The record type.</param>
		/// <param name="recordClass">The record class.</param>
		/// <param name="timeToLive">The record time-to-live.</param>
		protected UpdateBase(string name, RecordType recordType, RecordClass recordClass, int timeToLive)
			: base(name, recordType, recordClass, timeToLive) {}
	}
}