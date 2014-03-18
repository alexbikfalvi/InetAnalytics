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
using System.Threading;

namespace ARSoft.Tools.Net.Dns
{
	/// <summary>
	/// The asynchronous state for the DNS client parallel request.
	/// </summary>
	/// <typeparam name="TMessage">The message type.</typeparam>
	internal class DnsClientParallelAsyncState<TMessage> : IAsyncResult where TMessage : DnsMessageBase
	{
		private ManualResetEvent waitHandle;

		// Internal fields.

		internal int ResponsesToReceive;
		internal List<TMessage> Responses;
		internal AsyncCallback UserCallback;

		// Public properties.

		/// <summary>
		/// Gets the asynchronous user state.
		/// </summary>
		public object AsyncState { get; internal set; }
		/// <summary>
		/// Gets whether the asynchronous operation is completed.
		/// </summary>
		public bool IsCompleted { get; private set; }
		/// <summary>
		/// Gets whether the asynchronous operation completed successfully.
		/// </summary>
		public bool CompletedSynchronously
		{
			get { return false; }
		}
		/// <summary>
		/// Gets the wait handle of the asynchronous operation.
		/// </summary>
		public WaitHandle AsyncWaitHandle
		{
			get { return this.waitHandle ?? (this.waitHandle = new ManualResetEvent(this.IsCompleted)); }
		}

		// Public methods.

		/// <summary>
		/// Completes the asynchronous operation.
		/// </summary>
		internal void SetCompleted()
		{
			this.IsCompleted = true;

			if (this.waitHandle != null)
				this.waitHandle.Set();

			if (this.UserCallback != null)
				this.UserCallback(this);
		}
	}
}