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
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace InetApi.Net.Socket
{
	/// <summary>
	/// A UDP listener.
	/// </summary>
	internal class UdpListener : IDisposable
	{
		/// <summary>
		/// The listener asynchronous result.
		/// </summary>
		private class ListenerAsyncResult : IAsyncResult
		{
			#region Public fields

			public IAsyncResult AsyncResult;
			public AsyncCallback Callback;
			public object State;

			public EndPoint EndPoint;
			public byte[] Buffer;

			#endregion

			#region Public properties

			/// <summary>
			/// Gets the asynchronous user state.
			/// </summary>
			public object AsyncState
			{
				get { return this.State; }
			}
			/// <summary>
			/// Gets the wait handle of the asynchronous operation.
			/// </summary>
			public WaitHandle AsyncWaitHandle
			{
				get { return this.AsyncResult.AsyncWaitHandle; }
			}
			/// <summary>
			/// Gets whether the asynchronous operation has completed synchronously.
			/// </summary>
			public bool CompletedSynchronously
			{
				get { return this.AsyncResult.CompletedSynchronously; }
			}
			/// <summary>
			/// Gets whether the asynchronous operation has completed.
			/// </summary>
			public bool IsCompleted
			{
				get { return this.AsyncResult.IsCompleted; }
			}

			#endregion
		}

		private readonly System.Net.Sockets.Socket socket;
		private readonly IPEndPoint endPoint;

		/// <summary>
		/// Creates a new UDP listener at the specified address and port.
		/// </summary>
		/// <param name="address">The IP address.</param>
		/// <param name="port">The port.</param>
		public UdpListener(IPAddress address, int port)
			: this(new IPEndPoint(address, port)) {}

		/// <summary>
		/// Creates a new UDP listener at the specified end point.
		/// </summary>
		/// <param name="endPoint">The end point.</param>
		public UdpListener(IPEndPoint endPoint)
		{
			this.endPoint = endPoint;
			this.socket = new System.Net.Sockets.Socket(this.endPoint.AddressFamily, SocketType.Dgram, ProtocolType.Udp);
			this.socket.Bind(this.endPoint);
		}

		#region Public methods.

		/// <summary>
		/// Begins an ansynchronous receive operation.
		/// </summary>
		/// <param name="callback">The callback method.</param>
		/// <param name="state">The user state.</param>
		/// <returns>The result of the asynchronous operation.</returns>
		public IAsyncResult BeginReceive(AsyncCallback callback, object state)
		{
			ListenerAsyncResult result =
				new ListenerAsyncResult()
				{
					Buffer = new byte[65535],
					EndPoint = this.endPoint,
					Callback = callback,
					State = state
				};

			result.AsyncResult = this.socket.BeginReceiveFrom(result.Buffer, 0, 65535, SocketFlags.None, ref result.EndPoint, OnSocketCallback, result);

			return result;
		}

		/// <summary>
		/// Ends an asynchronous receive operation.
		/// </summary>
		/// <param name="asyncResult">The asynchronous result.</param>
		/// <param name="endPoint">The end point.</param>
		/// <returns>The received data.</returns>
		public byte[] EndReceive(IAsyncResult asyncResult, out IPEndPoint endPoint)
		{
			ListenerAsyncResult receiveAsyncResult = asyncResult as ListenerAsyncResult;

			if (receiveAsyncResult == null)
				throw new ArgumentException("Invalid Async Result", "asyncResult");

			int length = this.socket.EndReceiveFrom(receiveAsyncResult.AsyncResult, ref receiveAsyncResult.EndPoint);

			endPoint = receiveAsyncResult.EndPoint as IPEndPoint;

			if (length == 65535)
			{
				return receiveAsyncResult.Buffer;
			}
			else
			{
				byte[] result = new byte[length];
				Buffer.BlockCopy(receiveAsyncResult.Buffer, 0, result, 0, length);
				return result;
			}
		}

		/// <summary>
		/// Begins an asynchronous send operation.
		/// </summary>
		/// <param name="buffer">The buffer.</param>
		/// <param name="offset">The offset.</param>
		/// <param name="length">The sending data length.</param>
		/// <param name="endPoint">The end point.</param>
		/// <param name="callback">The callback method.</param>
		/// <param name="state">The user state.</param>
		/// <returns>The asynchronous result.</returns>
		public IAsyncResult BeginSend(byte[] buffer, int offset, int length, IPEndPoint endPoint, AsyncCallback callback, object state)
		{
			ListenerAsyncResult result =
				new ListenerAsyncResult()
				{
					Callback = callback,
					State = state
				};

			result.AsyncResult = this.socket.BeginSendTo(buffer, offset, length, SocketFlags.None, endPoint, OnSocketCallback, result);

			return result;
		}

		/// <summary>
		/// Ends an asynchronous send operation.
		/// </summary>
		/// <param name="asyncResult">The asynchronous result.</param>
		/// <returns>The operation code.</returns>
		public int EndSend(IAsyncResult asyncResult)
		{
			ListenerAsyncResult receiveAsyncResult = asyncResult as ListenerAsyncResult;

			if (receiveAsyncResult == null)
				throw new ArgumentException("Invalid Async Result", "asyncResult");

			return this.socket.EndSendTo(receiveAsyncResult.AsyncResult);
		}

		// Disposes the current object.
		public void Dispose()
		{
			// Dispose the socket.
			this.socket.Dispose();
			// Suppress the finalizer.
			GC.SuppressFinalize(this);
		}

		#endregion

		#region Private methods

		/// <summary>
		/// An event handler called when an asynchronous socket operation has completed.
		/// </summary>
		/// <param name="asyncResult">The asynchronous result.</param>
		private static void OnSocketCallback(IAsyncResult asyncResult)
		{
			ListenerAsyncResult receiveAsyncResult = asyncResult.AsyncState as ListenerAsyncResult;
			if ((receiveAsyncResult != null) && (receiveAsyncResult.Callback != null))
			{
				receiveAsyncResult.AsyncResult = asyncResult;
				receiveAsyncResult.Callback(receiveAsyncResult);
			}
		}

		#endregion
	}
}