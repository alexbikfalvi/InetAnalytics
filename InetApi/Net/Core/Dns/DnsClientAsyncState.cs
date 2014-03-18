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
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ARSoft.Tools.Net.Dns
{
	/// <summary>
	/// The asynchronous state for a DNS client.
	/// </summary>
	/// <typeparam name="TMessage">The message type.</typeparam>
	internal class DnsClientAsyncState<TMessage> : IAsyncResult where TMessage : DnsMessageBase
	{
		// Internal fields.

		internal List<DnsClientEndpointInfo> EndpointInfos;
		internal int EndpointInfoIndex;

		internal TMessage Query;
		internal byte[] QueryData;
		internal int QueryLength;

		internal DnsServer.SelectTsigKey TSigKeySelector;
		internal byte[] TSigOriginalMac;

		internal TMessage PartialMessage;
		internal List<TMessage> Responses;

		internal Timer Timer;
		internal bool TimedOut;

		internal System.Net.Sockets.Socket UdpClient;
		internal EndPoint UdpEndpoint;

		internal byte[] Buffer;

		internal TcpClient TcpClient;
		internal NetworkStream TcpStream;
		internal int TcpBytesToReceive;

		internal AsyncCallback UserCallback;

		// Private fields.

		private long timeOutUtcTicks;

		private ManualResetEvent waitHandle;

		// Internal properties.

		/// <summary>
		/// Gets or sets the time remaining for the asynchronous operation.
		/// </summary>
		internal long TimeRemaining
		{
			get
			{
				long res = (this.timeOutUtcTicks - DateTime.UtcNow.Ticks) / TimeSpan.TicksPerMillisecond;
				return res > 0 ? res : 0;
			}
			set { this.timeOutUtcTicks = DateTime.UtcNow.Ticks + value * TimeSpan.TicksPerMillisecond; }
		}
		/// <summary>
		/// Gets the asynchronous user state.
		/// </summary>
		public object AsyncState { get; internal set; }
		/// <summary>
		/// Gets whether the asynchronous operation is completed.
		/// </summary>
		public bool IsCompleted { get; private set; }
		/// <summary>
		/// Gets whether the asynchronous operation completed synchronously.
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
		/// Creates a clone of the asynchronous state without the callback.
		/// </summary>
		/// <returns>The clone object.</returns>
		public DnsClientAsyncState<TMessage> CreateTcpCloneWithoutCallback()
		{
			return new DnsClientAsyncState<TMessage>
				{
					EndpointInfos = this.EndpointInfos,
					EndpointInfoIndex = this.EndpointInfoIndex,
					Query = this.Query,
					QueryData = this.QueryData,
					QueryLength = this.QueryLength,
					TSigKeySelector = this.TSigKeySelector,
					TSigOriginalMac = this.TSigOriginalMac,
					Responses = this.Responses,
					timeOutUtcTicks = this.timeOutUtcTicks
				};
		}

		// Internal methods.

		/// <summary>
		/// Completes the asynchronous operation.
		/// </summary>
		internal void SetCompleted()
		{
			this.QueryData = null;

			if (this.Timer != null)
			{
				this.Timer.Dispose();
				this.Timer = null;
			}

			this.IsCompleted = true;
			
			if (this.waitHandle != null)
				this.waitHandle.Set();

			if (this.UserCallback != null)
				this.UserCallback(this);
		}
	}
}