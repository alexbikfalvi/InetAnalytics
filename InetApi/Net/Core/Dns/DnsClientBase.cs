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
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading;

namespace ARSoft.Tools.Net.Dns
{
	/// <summary>
	/// The base class for a DNS client.
	/// </summary>
	public abstract class DnsClientBase
	{
		private readonly List<IPAddress> servers;
		private readonly bool isAnyServerMulticast;
		private readonly int port;

		/// <summary>
		/// Creates a new DNS client base instance.
		/// </summary>
		/// <param name="servers">The list of DNS servers.</param>
		/// <param name="queryTimeout">The query timeout.</param>
		/// <param name="port">The DNS server port.</param>
		internal DnsClientBase(List<IPAddress> servers, int queryTimeout, int port)
		{
			this.servers = servers.OrderBy(s => s.AddressFamily == AddressFamily.InterNetworkV6 ? 0 : 1).ToList();
			this.isAnyServerMulticast = servers.Any(s => s.IsMulticast());
			this.port = port;
			this.QueryTimeout = queryTimeout;
		}

		// Public properties.

		/// <summary>
		/// Milliseconds after which a query times out.
		/// </summary>
		public int QueryTimeout { get; private set; }
		/// <summary>
		/// Gets or set a value indicating whether the response is validated as described in <see
		/// cref="http://tools.ietf.org/id/draft-vixie-dnsext-dns0x20-00.txt">draft-vixie-dnsext-dns0x20-00</see>
		/// </summary>
		public bool IsResponseValidationEnabled { get; set; }
		/// <summary>
		/// Gets or set a value indicating whether the query labels are used for additional validation as described in <see
		/// cref="http://tools.ietf.org/id/draft-vixie-dnsext-dns0x20-00.txt">draft-vixie-dnsext-dns0x20-00</see>
		/// </summary>
		public bool Is0x20ValidationEnabled { get; set; }

		// Protected properties.

		/// <summary>
		/// Gets the maximum query message size.
		/// </summary>
		protected abstract int MaximumQueryMessageSize { get; }
		/// <summary>
		/// Gets whether the client supports multiple responses in parallel mode.
		/// </summary>
		protected abstract bool AreMultipleResponsesAllowedInParallelMode { get; }

		// Protected 

		/// <summary>
		/// Sends a DNS message.
		/// </summary>
		/// <typeparam name="TMessage">The message type.</typeparam>
		/// <param name="message">The message.</param>
		/// <returns>The response message.</returns>
		protected TMessage SendMessage<TMessage>(TMessage message) where TMessage : DnsMessageBase, new()
		{
			int messageLength;
			byte[] messageData;
			DnsServer.SelectTsigKey tsigKeySelector;
			byte[] tsigOriginalMac;

			this.PrepareMessage(message, out messageLength, out messageData, out tsigKeySelector, out tsigOriginalMac);

			bool sendByTcp = ((messageLength > MaximumQueryMessageSize) || message.IsTcpUsingRequested);

			var endpointInfos = GetEndpointInfos<TMessage>();

			for (int i = 0; i < endpointInfos.Count; i++)
			{
				TcpClient tcpClient = null;
				NetworkStream tcpStream = null;

				try
				{
					var endpointInfo = endpointInfos[i];

					IPAddress responderAddress;
					byte[] resultData = sendByTcp ? this.QueryByTcp(endpointInfo.ServerAddress, messageData, messageLength, ref tcpClient, ref tcpStream, out responderAddress) : QueryByUdp(endpointInfo, messageData, messageLength, out responderAddress);

					if (resultData != null)
					{
						TMessage result = new TMessage();

						try
						{
							result.Parse(resultData, false, tsigKeySelector, tsigOriginalMac);
						}
						catch (Exception e)
						{
							Trace.TraceError("Error on DNS query: " + e);
							continue;
						}

						if (!ValidateResponse(message, result))
							continue;

						if ((result.ReturnCode == ReturnCode.ServerFailure) && (i != endpointInfos.Count - 1))
						{
							continue;
						}

						if (result.IsTcpResendingRequested)
						{
							resultData = QueryByTcp(responderAddress, messageData, messageLength, ref tcpClient, ref tcpStream, out responderAddress);
							if (resultData != null)
							{
								TMessage tcpResult = new TMessage();

								try
								{
									tcpResult.Parse(resultData, false, tsigKeySelector, tsigOriginalMac);
								}
								catch (Exception e)
								{
									Trace.TraceError("Error on DNS query: " + e);
									continue;
								}

								if (tcpResult.ReturnCode == ReturnCode.ServerFailure)
								{
									if (i != endpointInfos.Count - 1)
									{
										continue;
									}
								}
								else
								{
									result = tcpResult;
								}
							}
						}

						bool isTcpNextMessageWaiting = result.IsTcpNextMessageWaiting;
						bool isSucessfullFinished = true;

						while (isTcpNextMessageWaiting)
						{
							resultData = this.QueryByTcp(responderAddress, null, 0, ref tcpClient, ref tcpStream, out responderAddress);
							if (resultData != null)
							{
								TMessage tcpResult = new TMessage();

								try
								{
									tcpResult.Parse(resultData, false, tsigKeySelector, tsigOriginalMac);
								}
								catch (Exception e)
								{
									Trace.TraceError("Error on DNS query: " + e);
									isSucessfullFinished = false;
									break;
								}

								if (tcpResult.ReturnCode == ReturnCode.ServerFailure)
								{
									isSucessfullFinished = false;
									break;
								}
								else
								{
									result.AnswerRecords.AddRange(tcpResult.AnswerRecords);
									isTcpNextMessageWaiting = tcpResult.IsTcpNextMessageWaiting;
								}
							}
							else
							{
								isSucessfullFinished = false;
								break;
							}
						}

						if (isSucessfullFinished)
							return result;
					}
				}
				finally
				{
					try
					{
						if (tcpStream != null)
							tcpStream.Dispose();
						if (tcpClient != null)
							tcpClient.Close();
					}
					catch {}
				}
			}

			return null;
		}

		/// <summary>
		/// Sens a DNS message in parallel.
		/// </summary>
		/// <typeparam name="TMessage">The message type.</typeparam>
		/// <param name="message">The message.</param>
		/// <returns>The list of response messages.</returns>
		protected List<TMessage> SendMessageParallel<TMessage>(TMessage message) where TMessage : DnsMessageBase, new()
		{
			IAsyncResult asyncResult = BeginSendMessageParallel(message, null, null);
			asyncResult.AsyncWaitHandle.WaitOne();
			return this.EndSendMessageParallel<TMessage>(asyncResult);
		}

		/// <summary>
		/// Validates a response message.
		/// </summary>
		/// <typeparam name="TMessage">The message type.</typeparam>
		/// <param name="message">The request message.</param>
		/// <param name="result">The result message.</param>
		/// <returns><b>True</b> if the reponse message is valid.</returns>
		private bool ValidateResponse<TMessage>(TMessage message, TMessage result) where TMessage : DnsMessageBase
		{
			if (IsResponseValidationEnabled)
			{
				if ((result.ReturnCode == ReturnCode.NoError) || (result.ReturnCode == ReturnCode.NxDomain))
				{
					if (message.TransactionID != result.TransactionID)
						return false;

					if ((message.Questions == null) || (result.Questions == null))
						return false;

					if ((message.Questions.Count != result.Questions.Count))
						return false;

					for (int j = 0; j < message.Questions.Count; j++)
					{
						DnsQuestion queryQuestion = message.Questions[j];
						DnsQuestion responseQuestion = message.Questions[j];

						if ((queryQuestion.RecordClass != responseQuestion.RecordClass)
						    || (queryQuestion.RecordType != responseQuestion.RecordType)
						    || (queryQuestion.Name != responseQuestion.Name))
						{
							return false;
						}
					}
				}
			}
			return true;
		}

		/// <summary>
		/// Begins sending a request message.
		/// </summary>
		/// <typeparam name="TMessage">The message type.</typeparam>
		/// <param name="message">The message.</param>
		/// <param name="requestCallback">The request callback.</param>
		/// <param name="state">The user state.</param>
		/// <returns>The result of the asynchronous operation.</returns>
		protected IAsyncResult BeginSendMessage<TMessage>(TMessage message, AsyncCallback requestCallback, object state)
			where TMessage : DnsMessageBase, new()
		{
			return BeginSendMessage(message, GetEndpointInfos<TMessage>(), requestCallback, state);
		}

		/// <summary>
		/// Begins sending a request message in parallel.
		/// </summary>
		/// <typeparam name="TMessage">The message type.</typeparam>
		/// <param name="message">The message.</param>
		/// <param name="requestCallback">The request callback.</param>
		/// <param name="state">The user state.</param>
		/// <returns>The result of the asynchronous operation.</returns>
		protected IAsyncResult BeginSendMessageParallel<TMessage>(TMessage message, AsyncCallback requestCallback, object state)
			where TMessage : DnsMessageBase, new()
		{
			List<DnsClientEndpointInfo> endpointInfos = GetEndpointInfos<TMessage>();

			DnsClientParallelAsyncState<TMessage> asyncResult =
				new DnsClientParallelAsyncState<TMessage>
				{
					UserCallback = requestCallback,
					AsyncState = state,
					Responses = new List<TMessage>(),
					ResponsesToReceive = endpointInfos.Count
				};

			foreach (var endpointInfo in endpointInfos)
			{
				DnsClientParallelState<TMessage> parallelState = new DnsClientParallelState<TMessage> { ParallelMessageAsyncState = asyncResult };

				lock (parallelState.Lock)
				{
					parallelState.SingleMessageAsyncResult = this.BeginSendMessage(message, new List<DnsClientEndpointInfo> { endpointInfo }, SendMessageFinished<TMessage>, parallelState);
				}
			}
			return asyncResult;
		}

		/// <summary>
		/// Ends a send message request.
		/// </summary>
		/// <typeparam name="TMessage">The message type.</typeparam>
		/// <param name="asyncResult">The result of the asynchronous operation.</param>
		/// <returns>The list of response messages.</returns>
		protected List<TMessage> EndSendMessage<TMessage>(IAsyncResult asyncResult)
			where TMessage : DnsMessageBase, new()
		{
			DnsClientAsyncState<TMessage> state = (DnsClientAsyncState<TMessage>)asyncResult;
			return state.Responses;
		}

		/// <summary>
		/// Ends a parallel send message request.
		/// </summary>
		/// <typeparam name="TMessage">The message type.</typeparam>
		/// <param name="asyncResult">The result of the asynchronous operation.</param>
		/// <returns>The list of response messages.</returns>
		protected List<TMessage> EndSendMessageParallel<TMessage>(IAsyncResult asyncResult)
			where TMessage : DnsMessageBase, new()
		{
			DnsClientParallelAsyncState<TMessage> state = (DnsClientParallelAsyncState<TMessage>)asyncResult;
			return state.Responses;
		}

		// Private methods.

		/// <summary>
		/// Prepares a request message.
		/// </summary>
		/// <typeparam name="TMessage">The message type.</typeparam>
		/// <param name="message">The message.</param>
		/// <param name="messageLength">The message length.</param>
		/// <param name="messageData">The message data.</param>
		/// <param name="tsigKeySelector">The transaction signature key selector.</param>
		/// <param name="tsigOriginalMac">The transaction signature original MAC.</param>
		private void PrepareMessage<TMessage>(TMessage message, out int messageLength, out byte[] messageData, out DnsServer.SelectTsigKey tsigKeySelector, out byte[] tsigOriginalMac)
			where TMessage : DnsMessageBase, new()
		{
			if (message.TransactionID == 0)
			{
				message.TransactionID = (ushort) new Random().Next(0xffff);
			}

			if (Is0x20ValidationEnabled)
			{
				message.Questions.ForEach(q => q.Name = Add0x20Bits(q.Name));
			}

			messageLength = message.Encode(false, out messageData);

			if (message.TSigOptions != null)
			{
				tsigKeySelector = (n, a) => message.TSigOptions.KeyData;
				tsigOriginalMac = message.TSigOptions.Mac;
			}
			else
			{
				tsigKeySelector = null;
				tsigOriginalMac = null;
			}
		}

		/// <summary>
		/// Adds the 0x20 bits to the specified name.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <returns>The new string.</returns>
		private static string Add0x20Bits(string name)
		{
			char[] res = new char[name.Length];

			Random random = new Random();

			for (int i = 0; i < name.Length; i++)
			{
				bool isLower = random.Next(0, 1000) > 500;

				char current = name[i];

				if (!isLower && current >= 'A' && current <= 'Z')
				{
					current = (char) (current + 0x20);
				}
				else if (isLower && current >= 'a' && current <= 'z')
				{
					current = (char) (current - 0x20);
				}

				res[i] = current;
			}

			return new string(res);
		}

		/// <summary>
		/// Sends a DNS query using UDP.
		/// </summary>
		/// <param name="endpointInfo">The end-point information of the DNS client.</param>
		/// <param name="messageData">The message data.</param>
		/// <param name="messageLength">The message length.</param>
		/// <param name="responderAddress">The responder address.</param>
		/// <returns>The response data.</returns>
		private byte[] QueryByUdp(DnsClientEndpointInfo endpointInfo, byte[] messageData, int messageLength, out IPAddress responderAddress)
		{
			using (Socket socket = new Socket(endpointInfo.LocalAddress.AddressFamily, SocketType.Dgram, ProtocolType.Udp))
			{
				try
				{
					socket.ReceiveTimeout = this.QueryTimeout;

					this.PrepareAndBindUdpSocket(endpointInfo, socket);

					EndPoint serverEndpoint = new IPEndPoint(endpointInfo.ServerAddress, port);

					socket.SendTo(messageData, messageLength, SocketFlags.None, serverEndpoint);

					if (endpointInfo.IsMulticast)
						serverEndpoint = new IPEndPoint(socket.AddressFamily == AddressFamily.InterNetwork ? IPAddress.Any : IPAddress.IPv6Any, port);

					byte[] buffer = new byte[65535];
					int length = socket.ReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref serverEndpoint);

					responderAddress = ((IPEndPoint) serverEndpoint).Address;

					byte[] res = new byte[length];
					Buffer.BlockCopy(buffer, 0, res, 0, length);
					return res;
				}
				catch (Exception e)
				{
					Trace.TraceError("Error on DNS query: " + e);
					responderAddress = default(IPAddress);
					return null;
				}
			}
		}

		/// <summary>
		/// Prepares a UDP socket for the specified end-point.
		/// </summary>
		/// <param name="endpointInfo">The end-point information.</param>
		/// <param name="socket">The socket.</param>
		private void PrepareAndBindUdpSocket(DnsClientEndpointInfo endpointInfo, Socket socket)
		{
			if (endpointInfo.IsMulticast)
			{
				socket.Bind(new IPEndPoint(endpointInfo.LocalAddress, 0));
			}
			else
			{
				socket.Connect(endpointInfo.ServerAddress, port);
			}
		}

		/// <summary>
		/// Sends a DNS query using TCP.
		/// </summary>
		/// <param name="nameServer">The name server.</param>
		/// <param name="messageData">The message data.</param>
		/// <param name="messageLength">The message length.</param>
		/// <param name="tcpClient">The TCP client.</param>
		/// <param name="tcpStream">The TCP stream.</param>
		/// <param name="responderAddress">The responder address.</param>
		/// <returns>The response data.</returns>
		private byte[] QueryByTcp(IPAddress nameServer, byte[] messageData, int messageLength, ref TcpClient tcpClient, ref NetworkStream tcpStream, out IPAddress responderAddress)
		{
			responderAddress = nameServer;

			IPEndPoint endPoint = new IPEndPoint(nameServer, port);

			try
			{
				if (tcpClient == null)
				{
					tcpClient = new TcpClient(nameServer.AddressFamily)
					{
						ReceiveTimeout = this.QueryTimeout,
						SendTimeout = this.QueryTimeout
					};

					tcpClient.Connect(endPoint);
					tcpStream = tcpClient.GetStream();
				}

				int tmp = 0;
				byte[] lengthBuffer = new byte[2];

				if (messageLength > 0)
				{
					DnsMessageBase.EncodeUShort(lengthBuffer, ref tmp, (ushort) messageLength);

					tcpStream.Write(lengthBuffer, 0, 2);
					tcpStream.Write(messageData, 0, messageLength);
				}

				lengthBuffer[0] = (byte) tcpStream.ReadByte();
				lengthBuffer[1] = (byte) tcpStream.ReadByte();

				tmp = 0;
				int length = DnsMessageBase.ParseUShort(lengthBuffer, ref tmp);

				byte[] resultData = new byte[length];

				int readBytes = 0;

				while (readBytes < length)
				{
					readBytes += tcpStream.Read(resultData, readBytes, length - readBytes);
				}

				return resultData;
			}
			catch (Exception e)
			{
				Trace.TraceError("Error on DNS query: " + e);
				return null;
			}
		}

		/// <summary>
		/// A method called when a sending message operation has finished.
		/// </summary>
		/// <typeparam name="TMessage">The message type.</typeparam>
		/// <param name="asyncResult">The asynchronous result.</param>
		private void SendMessageFinished<TMessage>(IAsyncResult asyncResult)
			where TMessage : DnsMessageBase, new()
		{
			DnsClientParallelState<TMessage> state = (DnsClientParallelState<TMessage>) asyncResult.AsyncState;

			List<TMessage> responses;

			lock (state.Lock)
			{
				responses = EndSendMessage<TMessage>(state.SingleMessageAsyncResult);
			}

			lock (state.ParallelMessageAsyncState.Responses)
			{
				state.ParallelMessageAsyncState.Responses.AddRange(responses);
				state.ParallelMessageAsyncState.ResponsesToReceive--;

				if (state.ParallelMessageAsyncState.ResponsesToReceive == 0)
					state.ParallelMessageAsyncState.SetCompleted();
			}
		}

		/// <summary>
		/// Begins sending a DNS message.
		/// </summary>
		/// <typeparam name="TMessage">The message type.</typeparam>
		/// <param name="message">The message.</param>
		/// <param name="endpointInfos">The list of end-points.</param>
		/// <param name="requestCallback">The callback method.</param>
		/// <param name="state">The user state.</param>
		/// <returns>The result of the asynchronous operation.</returns>
		private IAsyncResult BeginSendMessage<TMessage>(TMessage message, List<DnsClientEndpointInfo> endpointInfos, AsyncCallback requestCallback, object state)
			where TMessage : DnsMessageBase, new()
		{
			DnsClientAsyncState<TMessage> asyncResult =
				new DnsClientAsyncState<TMessage>
				{
					Query = message,
					Responses = new List<TMessage>(),
					UserCallback = requestCallback,
					AsyncState = state,
					EndpointInfoIndex = 0
				};

			this.PrepareMessage(message, out asyncResult.QueryLength, out asyncResult.QueryData, out asyncResult.TSigKeySelector, out asyncResult.TSigOriginalMac);
			asyncResult.EndpointInfos = endpointInfos;

			if ((asyncResult.QueryLength > MaximumQueryMessageSize) || message.IsTcpUsingRequested)
			{
				this.TcpBeginConnect(asyncResult);
			}
			else
			{
				this.UdpBeginSend(asyncResult);
			}

			return asyncResult;
		}

		/// <summary>
		/// Returns a list of end-points.
		/// </summary>
		/// <typeparam name="TMessage">The message type.</typeparam>
		/// <returns>The list of end-points.</returns>
		private List<DnsClientEndpointInfo> GetEndpointInfos<TMessage>() where TMessage : DnsMessageBase, new()
		{
			List<DnsClientEndpointInfo> endpointInfos;
			if (this.isAnyServerMulticast)
			{
				var localIPs = NetworkInterface.GetAllNetworkInterfaces()
					.Where(n => n.SupportsMulticast && (n.OperationalStatus == OperationalStatus.Up) && (n.NetworkInterfaceType != NetworkInterfaceType.Loopback))
					.SelectMany(n => n.GetIPProperties().UnicastAddresses.Select(a => a.Address))
					.Where(a => !IPAddress.IsLoopback(a) && ((a.AddressFamily == AddressFamily.InterNetwork) || a.IsIPv6LinkLocal))
					.ToList();

				endpointInfos = servers.SelectMany(
					s =>
						{
							if (s.IsMulticast())
							{
								return localIPs
									.Where(l => l.AddressFamily == s.AddressFamily)
									.Select(l => new DnsClientEndpointInfo
										{
											IsMulticast = true,
											ServerAddress = s,
											LocalAddress = l
										});
							}
							else
							{
								return new[]
								{
									new DnsClientEndpointInfo
									{
										IsMulticast = false,
										ServerAddress = s,
										LocalAddress = s.AddressFamily == AddressFamily.InterNetwork ? IPAddress.Any : IPAddress.IPv6Any
									}
								};
							}
						}).ToList();
			}
			else
			{
				endpointInfos = servers.Select(
					s => new DnsClientEndpointInfo
					{
						IsMulticast = false,
						ServerAddress = s,
						LocalAddress = s.AddressFamily == AddressFamily.InterNetwork ? IPAddress.Any : IPAddress.IPv6Any
					}).ToList();
			}
			return endpointInfos;
		}

		/// <summary>
		/// Begins a UDP request.
		/// </summary>
		/// <typeparam name="TMessage">The message state.</typeparam>
		/// <param name="state">The DNS client asynchronous state.</param>
		private void UdpBeginSend<TMessage>(DnsClientAsyncState<TMessage> state)
			where TMessage : DnsMessageBase, new()
		{
			if (state.EndpointInfoIndex == state.EndpointInfos.Count)
			{
				state.UdpClient = null;
				state.UdpEndpoint = null;
				state.SetCompleted();
				return;
			}

			try
			{
				DnsClientEndpointInfo endpointInfo = state.EndpointInfos[state.EndpointInfoIndex];

				state.UdpEndpoint = new IPEndPoint(endpointInfo.ServerAddress, port);

				state.UdpClient = new System.Net.Sockets.Socket(state.UdpEndpoint.AddressFamily, SocketType.Dgram, ProtocolType.Udp);

				this.PrepareAndBindUdpSocket(endpointInfo, state.UdpClient);

				state.TimedOut = false;
				state.TimeRemaining = QueryTimeout;

				IAsyncResult asyncResult = state.UdpClient.BeginSendTo(state.QueryData, 0, state.QueryLength, SocketFlags.None, state.UdpEndpoint, UdpSendCompleted<TMessage>, state);
				state.Timer = new Timer(UdpTimedOut<TMessage>, asyncResult, state.TimeRemaining, Timeout.Infinite);
			}
			catch (Exception e)
			{
				Trace.TraceError("Error on DNS query: " + e);

				try
				{
					state.UdpClient.Close();
					state.Timer.Dispose();
				}
				catch {}

				state.EndpointInfoIndex++;
				this.UdpBeginSend(state);
			}
		}

		/// <summary>
		/// A method called when a UDP request has timed-out.
		/// </summary>
		/// <typeparam name="TMessage">The message type.</typeparam>
		/// <param name="state">The asynchronous state.</param>
		private static void UdpTimedOut<TMessage>(object state)
			where TMessage : DnsMessageBase, new()
		{
			IAsyncResult asyncResult = (IAsyncResult) state;

			if (!asyncResult.IsCompleted)
			{
				DnsClientAsyncState<TMessage> asyncState = (DnsClientAsyncState<TMessage>) asyncResult.AsyncState;
				asyncState.TimedOut = true;
				asyncState.UdpClient.Close();
			}
		}

		/// <summary>
		/// Completes a UDP send request.
		/// </summary>
		/// <typeparam name="TMessage">The message type.</typeparam>
		/// <param name="result">The result of the asynchronous operation.</param>
		private void UdpSendCompleted<TMessage>(IAsyncResult result)
			where TMessage : DnsMessageBase, new()
		{
			DnsClientAsyncState<TMessage> state = (DnsClientAsyncState<TMessage>) result.AsyncState;

			if (state.Timer != null)
				state.Timer.Dispose();

			if (state.TimedOut)
			{
				state.EndpointInfoIndex++;
				this.UdpBeginSend(state);
			}
			else
			{
				try
				{
					state.UdpClient.EndSendTo(result);

					state.Buffer = new byte[65535];

					if (state.EndpointInfos[state.EndpointInfoIndex].IsMulticast)
						state.UdpEndpoint = new IPEndPoint(state.UdpClient.AddressFamily == AddressFamily.InterNetwork ? IPAddress.Any : IPAddress.IPv6Any, port);

					IAsyncResult asyncResult = state.UdpClient.BeginReceiveFrom(state.Buffer, 0, state.Buffer.Length, SocketFlags.None, ref state.UdpEndpoint, UdpReceiveCompleted<TMessage>, state);
					state.Timer = new Timer(UdpTimedOut<TMessage>, asyncResult, state.TimeRemaining, Timeout.Infinite);
				}
				catch (Exception e)
				{
					Trace.TraceError("Error on DNS query: " + e);

					try
					{
						state.UdpClient.Close();
						state.Timer.Dispose();
					}
					catch {}

					state.EndpointInfoIndex++;
					this.UdpBeginSend(state);
				}
			}
		}

		/// <summary>
		/// Completes a UDP receive request.
		/// </summary>
		/// <typeparam name="TMessage">The message type.</typeparam>
		/// <param name="result">The asynchronous result.</param>
		private void UdpReceiveCompleted<TMessage>(IAsyncResult result)
			where TMessage : DnsMessageBase, new()
		{
			DnsClientAsyncState<TMessage> state = (DnsClientAsyncState<TMessage>) result.AsyncState;

			if (state.Timer != null)
				state.Timer.Dispose();

			if (state.TimedOut)
			{
				state.EndpointInfoIndex++;
				this.UdpBeginSend(state);
			}
			else
			{
				try
				{
					int length = state.UdpClient.EndReceiveFrom(result, ref state.UdpEndpoint);
					byte[] responseData = new byte[length];
					Buffer.BlockCopy(state.Buffer, 0, responseData, 0, length);

					TMessage response = new TMessage();
					response.Parse(responseData, false, state.TSigKeySelector, state.TSigOriginalMac);

					if (this.AreMultipleResponsesAllowedInParallelMode)
					{
						if (this.ValidateResponse(state.Query, response))
						{
							if (response.IsTcpResendingRequested)
							{
								this.TcpBeginConnect<TMessage>(state.CreateTcpCloneWithoutCallback(), ((IPEndPoint) state.UdpEndpoint).Address);
							}
							else
							{
								state.Responses.Add(response);
							}
						}

						state.Buffer = new byte[65535];

						if (state.EndpointInfos[state.EndpointInfoIndex].IsMulticast)
							state.UdpEndpoint = new IPEndPoint(state.UdpClient.AddressFamily == AddressFamily.InterNetwork ? IPAddress.Any : IPAddress.IPv6Any, port);

						IAsyncResult asyncResult = state.UdpClient.BeginReceiveFrom(state.Buffer, 0, state.Buffer.Length, SocketFlags.None, ref state.UdpEndpoint, UdpReceiveCompleted<TMessage>, state);
						state.Timer = new Timer(UdpTimedOut<TMessage>, asyncResult, state.TimeRemaining, Timeout.Infinite);
					}
					else
					{
						state.UdpClient.Close();
						state.UdpClient = null;
						state.UdpEndpoint = null;

						if (!ValidateResponse(state.Query, response) || (response.ReturnCode == ReturnCode.ServerFailure))
						{
							state.EndpointInfoIndex++;
							this.UdpBeginSend(state);
						}
						else
						{
							if (response.IsTcpResendingRequested)
							{
								this.TcpBeginConnect<TMessage>(state, ((IPEndPoint) state.UdpEndpoint).Address);
							}
							else
							{
								state.Responses.Add(response);
								state.SetCompleted();
							}
						}
					}
				}
				catch (Exception e)
				{
					Trace.TraceError("Error on DNS query: " + e);

					try
					{
						state.UdpClient.Close();
						state.Timer.Dispose();
					}
					catch {}

					state.EndpointInfoIndex++;
					this.UdpBeginSend(state);
				}
			}
		}

		/// <summary>
		/// Begins a TCP connection.
		/// </summary>
		/// <typeparam name="TMessage">The message type.</typeparam>
		/// <param name="state">The DNS client asynchronous state.</param>
		private void TcpBeginConnect<TMessage>(DnsClientAsyncState<TMessage> state)
			where TMessage : DnsMessageBase, new()
		{
			if (state.EndpointInfoIndex == state.EndpointInfos.Count)
			{
				state.TcpStream = null;
				state.TcpClient = null;
				state.SetCompleted();
				return;
			}

			this.TcpBeginConnect(state, state.EndpointInfos[state.EndpointInfoIndex].ServerAddress);
		}

		/// <summary>
		/// Begins a TCP connection.
		/// </summary>
		/// <typeparam name="TMessage">The message type.</typeparam>
		/// <param name="state">The DNS client asynchronous state.</param>
		/// <param name="server">The DNS server address.</param>
		private void TcpBeginConnect<TMessage>(DnsClientAsyncState<TMessage> state, IPAddress server)
			where TMessage : DnsMessageBase, new()
		{
			if (state.EndpointInfoIndex == state.EndpointInfos.Count)
			{
				state.TcpStream = null;
				state.TcpClient = null;
				state.SetCompleted();
				return;
			}

			try
			{
				state.TcpClient = new TcpClient(server.AddressFamily);
				state.TimedOut = false;
				state.TimeRemaining = QueryTimeout;

				IAsyncResult asyncResult = state.TcpClient.BeginConnect(server, port, TcpConnectCompleted<TMessage>, state);
				state.Timer = new Timer(TcpTimedOut<TMessage>, asyncResult, state.TimeRemaining, Timeout.Infinite);
			}
			catch (Exception e)
			{
				Trace.TraceError("Error on DNS query: " + e);

				try
				{
					state.TcpClient.Close();
					state.Timer.Dispose();
				}
				catch {}

				state.EndpointInfoIndex++;
				this.TcpBeginConnect(state);
			}
		}

		/// <summary>
		/// A method called when the TCP connection timed-out.
		/// </summary>
		/// <typeparam name="TMessage">The message type.</typeparam>
		/// <param name="state">The asynchronous state.</param>
		private static void TcpTimedOut<TMessage>(object state)
			where TMessage : DnsMessageBase, new()
		{
			IAsyncResult asyncResult = (IAsyncResult) state;

			if (!asyncResult.IsCompleted)
			{
				DnsClientAsyncState<TMessage> asyncState = (DnsClientAsyncState<TMessage>) asyncResult.AsyncState;
				asyncState.PartialMessage = null;
				asyncState.TimedOut = true;
				if (asyncState.TcpStream != null)
					asyncState.TcpStream.Close();
				asyncState.TcpClient.Close();
			}
		}

		/// <summary>
		/// Completes a TCP connection.
		/// </summary>
		/// <typeparam name="TMessage">The message type.</typeparam>
		/// <param name="result">The result of the asynchronous operation.</param>
		private void TcpConnectCompleted<TMessage>(IAsyncResult result)
			where TMessage : DnsMessageBase, new()
		{
			DnsClientAsyncState<TMessage> state = (DnsClientAsyncState<TMessage>) result.AsyncState;

			if (state.Timer != null)
				state.Timer.Dispose();

			if (state.TimedOut)
			{
				state.EndpointInfoIndex++;
				TcpBeginConnect(state);
			}
			else
			{
				try
				{
					state.TcpClient.EndConnect(result);

					state.TcpStream = state.TcpClient.GetStream();

					int tmp = 0;

					state.Buffer = new byte[2];
					DnsMessageBase.EncodeUShort(state.Buffer, ref tmp, (ushort) state.QueryLength);

					IAsyncResult asyncResult = state.TcpStream.BeginWrite(state.Buffer, 0, 2, TcpSendLengthCompleted<TMessage>, state);
					state.Timer = new Timer(DnsClientBase.TcpTimedOut<TMessage>, asyncResult, state.TimeRemaining, Timeout.Infinite);
				}
				catch (Exception e)
				{
					Trace.TraceError("Error on DNS query: " + e);

					try
					{
						state.TcpClient.Close();
						state.Timer.Dispose();
					}
					catch {}

					state.EndpointInfoIndex++;
					this.TcpBeginConnect(state);
				}
			}
		}

		/// <summary>
		/// Completes sending a TCP length request.
		/// </summary>
		/// <typeparam name="TMessage">The message type.</typeparam>
		/// <param name="result">The asynchronous result.</param>
		private void TcpSendLengthCompleted<TMessage>(IAsyncResult result)
			where TMessage : DnsMessageBase, new()
		{
			DnsClientAsyncState<TMessage> state = (DnsClientAsyncState<TMessage>) result.AsyncState;

			if (state.Timer != null)
				state.Timer.Dispose();

			if (state.TimedOut)
			{
				state.EndpointInfoIndex++;
				TcpBeginConnect(state);
			}
			else
			{
				try
				{
					state.TcpStream.EndWrite(result);

					IAsyncResult asyncResult = state.TcpStream.BeginWrite(state.QueryData, 0, state.QueryLength, TcpSendCompleted<TMessage>, state);
					state.Timer = new Timer(DnsClientBase.TcpTimedOut<TMessage>, asyncResult, state.TimeRemaining, Timeout.Infinite);
				}
				catch (Exception e)
				{
					Trace.TraceError("Error on DNS query: " + e);

					try
					{
						state.TcpClient.Close();
						state.Timer.Dispose();
					}
					catch {}

					state.EndpointInfoIndex++;
					this.TcpBeginConnect(state);
				}
			}
		}

		/// <summary>
		/// Completes a TCP send request.
		/// </summary>
		/// <typeparam name="TMessage">The message type.</typeparam>
		/// <param name="result">The asynchronous result.</param>
		private void TcpSendCompleted<TMessage>(IAsyncResult result)
			where TMessage : DnsMessageBase, new()
		{
			DnsClientAsyncState<TMessage> state = (DnsClientAsyncState<TMessage>) result.AsyncState;

			if (state.Timer != null)
				state.Timer.Dispose();

			if (state.TimedOut)
			{
				state.EndpointInfoIndex++;
				this.TcpBeginConnect(state);
			}
			else
			{
				try
				{
					state.TcpStream.EndWrite(result);

					state.TcpBytesToReceive = 2;

					IAsyncResult asyncResult = state.TcpStream.BeginRead(state.Buffer, 0, 2, TcpReceiveLengthCompleted<TMessage>, state);
					state.Timer = new Timer(DnsClientBase.TcpTimedOut<TMessage>, asyncResult, state.TimeRemaining, Timeout.Infinite);
				}
				catch (Exception e)
				{
					Trace.TraceError("Error on DNS query: " + e);

					try
					{
						state.TcpClient.Close();
						state.Timer.Dispose();
					}
					catch {}

					state.EndpointInfoIndex++;
					this.TcpBeginConnect(state);
				}
			}
		}

		/// <summary>
		/// Completes receiving a TCP length.
		/// </summary>
		/// <typeparam name="TMessage">The message type.</typeparam>
		/// <param name="result">The asynchronous result.</param>
		private void TcpReceiveLengthCompleted<TMessage>(IAsyncResult result)
			where TMessage : DnsMessageBase, new()
		{
			DnsClientAsyncState<TMessage> state = (DnsClientAsyncState<TMessage>) result.AsyncState;

			if (state.Timer != null)
				state.Timer.Dispose();

			if (state.TimedOut)
			{
				state.EndpointInfoIndex++;
				this.TcpBeginConnect(state);
			}
			else
			{
				try
				{
					state.TcpBytesToReceive -= state.TcpStream.EndRead(result);

					if (state.TcpBytesToReceive > 0)
					{
						IAsyncResult asyncResult = state.TcpStream.BeginRead(state.Buffer, 2 - state.TcpBytesToReceive, state.TcpBytesToReceive, TcpReceiveLengthCompleted<TMessage>, state);
						state.Timer = new Timer(DnsClientBase.TcpTimedOut<TMessage>, asyncResult, state.TimeRemaining, Timeout.Infinite);
					}
					else
					{
						int tmp = 0;
						int responseLength = DnsMessageBase.ParseUShort(state.Buffer, ref tmp);

						state.Buffer = new byte[responseLength];
						state.TcpBytesToReceive = responseLength;

						IAsyncResult asyncResult = state.TcpStream.BeginRead(state.Buffer, 0, responseLength, TcpReceiveCompleted<TMessage>, state);
						state.Timer = new Timer(DnsClientBase.TcpTimedOut<TMessage>, asyncResult, state.TimeRemaining, Timeout.Infinite);
					}
				}
				catch (Exception e)
				{
					Trace.TraceError("Error on DNS query: " + e);

					try
					{
						state.TcpClient.Close();
						state.Timer.Dispose();
					}
					catch {}

					state.EndpointInfoIndex++;
					this.TcpBeginConnect(state);
				}
			}
		}

		/// <summary>
		/// Completes receiving the response for a TCP request.
		/// </summary>
		/// <typeparam name="TMessage">The request type.</typeparam>
		/// <param name="result">The asynchronous result.</param>
		private void TcpReceiveCompleted<TMessage>(IAsyncResult result)
			where TMessage : DnsMessageBase, new()
		{
			DnsClientAsyncState<TMessage> state = (DnsClientAsyncState<TMessage>) result.AsyncState;

			if (state.Timer != null)
				state.Timer.Dispose();

			if (state.TimedOut)
			{
				state.EndpointInfoIndex++;
				this.TcpBeginConnect(state);
			}
			else
			{
				try
				{
					state.TcpBytesToReceive -= state.TcpStream.EndRead(result);

					if (state.TcpBytesToReceive > 0)
					{
						IAsyncResult asyncResult = state.TcpStream.BeginRead(state.Buffer, state.Buffer.Length - state.TcpBytesToReceive, state.TcpBytesToReceive, TcpReceiveCompleted<TMessage>, state);
						state.Timer = new Timer(DnsClientBase.TcpTimedOut<TMessage>, asyncResult, state.TimeRemaining, Timeout.Infinite);
					}
					else
					{
						byte[] buffer = state.Buffer;
						state.Buffer = null;

						TMessage response = new TMessage();
						response.Parse(buffer, false, state.TSigKeySelector, state.TSigOriginalMac);

						if (!ValidateResponse(state.Query, response) || (response.ReturnCode == ReturnCode.ServerFailure))
						{
							state.EndpointInfoIndex++;
							state.PartialMessage = null;
							state.TcpStream.Close();
							state.TcpClient.Close();
							state.TcpStream = null;
							state.TcpClient = null;
							TcpBeginConnect(state);
						}
						else
						{
							if (state.PartialMessage != null)
							{
								state.PartialMessage.AnswerRecords.AddRange(response.AnswerRecords);
							}
							else
							{
								state.PartialMessage = response;
							}

							if (response.IsTcpNextMessageWaiting)
							{
								state.TcpBytesToReceive = 2;
								state.Buffer = new byte[2];

								IAsyncResult asyncResult = state.TcpStream.BeginRead(state.Buffer, 0, 2, TcpReceiveLengthCompleted<TMessage>, state);
								state.Timer = new Timer(DnsClientBase.TcpTimedOut<TMessage>, asyncResult, state.TimeRemaining, Timeout.Infinite);
							}
							else
							{
								state.TcpStream.Close();
								state.TcpClient.Close();
								state.TcpStream = null;
								state.TcpClient = null;

								state.Responses.Add(state.PartialMessage);
								state.SetCompleted();
							}
						}
					}
				}
				catch (Exception e)
				{
					Trace.TraceError("Error on DNS query: " + e);

					try
					{
						state.TcpClient.Close();
						state.Timer.Dispose();
					}
					catch {}

					state.EndpointInfoIndex++;
					this.TcpBeginConnect(state);
				}
			}
		}
	}
}