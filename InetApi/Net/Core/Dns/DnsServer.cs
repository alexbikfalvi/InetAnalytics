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
using System.Net;
using System.Net.Sockets;
using System.Threading;
using ARSoft.Tools.Net.Socket;

namespace ARSoft.Tools.Net.Dns
{
	/// <summary>
	/// Provides a base DNS server interface.
	/// </summary>
	public class DnsServer : IDisposable
	{
		/// <summary>
		/// The server state.
		/// </summary>
		private class ServerState
		{
			#region Public fields

			public IAsyncResult AsyncResult;
			public TcpClient Client;
			public NetworkStream Stream;
			public DnsMessageBase Response;
			public byte[] NextTsigMac;
			public byte[] Buffer;
			public int BytesToReceive;
			public Timer Timer;

			#endregion

			private long timeOutUtcTicks;

			#region Public properties

			/// <summary>
			/// Gets or sets the remaining time.
			/// </summary>
			public long TimeRemaining
			{
				get
				{
					long res = (this.timeOutUtcTicks - DateTime.UtcNow.Ticks) / TimeSpan.TicksPerMillisecond;
					return res > 0 ? res : 0;
				}
				set { this.timeOutUtcTicks = DateTime.UtcNow.Ticks + value * TimeSpan.TicksPerMillisecond; }
			}

			#endregion
		}

		/// <summary>
		/// Represents the method, that will be called to get the response for a specific DNS query.
		/// </summary>
		/// <param name="query">The query, for that a response should be returned.</param>
		/// <param name="clientAddress">The IP address from which the queries comes.</param>
		/// <param name="protocolType">The protocol which was used for the query.</param>
		/// <returns> A DNS message with the response to the query.</returns>
		public delegate DnsMessageBase ProcessQuery(DnsMessageBase query, IPAddress clientAddress, ProtocolType protocolType);

		/// <summary>
		/// Represents the method, that will be called to get the keydata for processing a TSIG signed message
		/// </summary>
		/// <param name="algorithm"> The algorithm which is used in the message.</param>
		/// <param name="keyName"> The keyname which is used in the message.</param>
		/// <returns> Binary representation of the key.</returns>
		public delegate byte[] SelectTsigKey(TSigAlgorithm algorithm, string keyName);

		private const int dnsPort = 53;

		private TcpListener tcpListener;
		private UdpListener udpListener;
		private readonly IPEndPoint bindEndPoint;

		private readonly int udpListenerCount;
		private readonly int tcpListenerCount;

		private int availableUdpListener;
		private bool hasActiveUdpListener;

		private int availableTcpListener;
		private bool hasActiveTcpListener;

		private readonly ProcessQuery processQueryDelegate;

		/// <summary>
		/// Creates a new DNS server instance which will listen on all available interfaces.
		/// </summary>
		/// <param name="udpListenerCount">The count of threads listings on udp, 0 to deactivate udp.</param>
		/// <param name="tcpListenerCount">The count of threads listings on tcp, 0 to deactivate tcp.</param>
		/// <param name="processQuery">Method, which process the queries and returns the response.</param>
		public DnsServer(int udpListenerCount, int tcpListenerCount, ProcessQuery processQuery)
			: this(IPAddress.Any, udpListenerCount, tcpListenerCount, processQuery) {}

		/// <summary>
		/// Creates a new DNS server instance.
		/// </summary>
		/// <param name="bindAddress">The address, on which should be listend.</param>
		/// <param name="udpListenerCount">The count of threads listings on udp, 0 to deactivate udp.</param>
		/// <param name="tcpListenerCount">The count of threads listings on tcp, 0 to deactivate tcp.</param>
		/// <param name="processQuery"> Method, which process the queries and returns the response.</param>
		public DnsServer(IPAddress bindAddress, int udpListenerCount, int tcpListenerCount, ProcessQuery processQuery)
			: this(new IPEndPoint(bindAddress, DnsServer.dnsPort), udpListenerCount, tcpListenerCount, processQuery) {}

		/// <summary>
		/// Creates a new DNS server instance.
		/// </summary>
		/// <param name="bindEndPoint">The endpoint, on which should be listend.</param>
		/// <param name="udpListenerCount">The count of threads listings on udp, 0 to deactivate udp.</param>
		/// <param name="tcpListenerCount">The count of threads listings on tcp, 0 to deactivate tcp.</param>
		/// <param name="processQuery">Method, which process the queries and returns the response.</param>
		public DnsServer(IPEndPoint bindEndPoint, int udpListenerCount, int tcpListenerCount, ProcessQuery processQuery)
		{
			this.bindEndPoint = bindEndPoint;
			this.processQueryDelegate = processQuery;

			this.udpListenerCount = udpListenerCount;
			this.tcpListenerCount = tcpListenerCount;

			this.Timeout = 120000;
		}

		#region Public properties

		/// <summary>
		/// Method that will be called to get the keydata for processing a TSIG signed message.
		/// </summary>
		public SelectTsigKey TsigKeySelector;
		/// <summary>
		/// Gets or sets the timeout for sending and receiving data.
		/// </summary>
		public int Timeout { get; set; }

		#endregion

		#region Public events

		/// <summary>
		/// This event is fired on exceptions of the listeners. You can use it for custom logging.
		/// </summary>
		public event EventHandler<ExceptionEventArgs> ExceptionThrown;
		/// <summary>
		/// This event is fired whenever a message is received, that is not correct signed
		/// </summary>
		public event EventHandler<InvalidSignedMessageEventArgs> InvalidSignedMessageReceived;

		#endregion

		#region Public methods

		/// <summary>
		/// Disposes the current object.
		/// </summary>
		public void Dispose()
		{
			// Stop the server.
			this.Stop();
			// Suppress the finalizer.
			GC.SuppressFinalize(this);
		}

		/// <summary>
		/// Starts the server.
		/// </summary>
		public void Start()
		{
			if (this.udpListenerCount > 0)
			{
				this.availableUdpListener = this.udpListenerCount;
				this.udpListener = new UdpListener(this.bindEndPoint);
				this.StartUdpListen();
			}

			if (this.tcpListenerCount > 0)
			{
				this.availableTcpListener = this.tcpListenerCount;
				this.tcpListener = new TcpListener(this.bindEndPoint);
				this.tcpListener.Start();
				this.StartTcpAcceptConnection();
			}
		}

		/// <summary>
		/// Stops the server.
		/// </summary>
		public void Stop()
		{
			if (this.udpListenerCount > 0)
			{
				this.udpListener.Dispose();
			}
			if (this.tcpListenerCount > 0)
			{
				this.tcpListener.Stop();
			}
		}

		#endregion

		#region Private methods

		/// <summary>
		/// Starts the UDP listener.
		/// </summary>
		private void StartUdpListen()
		{
			try
			{
				lock (this.udpListener)
				{
					if ((this.availableUdpListener > 0) && !this.hasActiveUdpListener)
					{
						this.availableUdpListener--;
						this.hasActiveUdpListener = true;
						this.udpListener.BeginReceive(EndUdpReceive, null);
					}
				}
			}
			catch (Exception e)
			{
				lock (this.udpListener)
				{
					this.hasActiveUdpListener = false;
				}
				this.HandleUdpException(e);
			}
		}

		/// <summary>
		/// Ends a UDP receive operation.
		/// </summary>
		/// <param name="asyncResult">The asynchronous result.</param>
		private void EndUdpReceive(IAsyncResult asyncResult)
		{
			try
			{
				lock (this.udpListener)
				{
					this.hasActiveUdpListener = false;
				}
				this.StartUdpListen();

				IPEndPoint endpoint;

				byte[] buffer = this.udpListener.EndReceive(asyncResult, out endpoint);

				DnsMessageBase query;
				byte[] originalMac;
				try
				{
					query = DnsMessageBase.Create(buffer, true, TsigKeySelector, null);
					originalMac = (query.TSigOptions == null) ? null : query.TSigOptions.Mac;
				}
				catch (Exception e)
				{
					throw new Exception("Error parsing DNS query", e);
				}

				DnsMessageBase response;
				try
				{
					response = ProcessMessage(query, endpoint.Address, ProtocolType.Udp);
				}
				catch (Exception ex)
				{
					OnExceptionThrown(ex);
					response = null;
				}

				if (response == null)
				{
					response = query;
					query.IsQuery = false;
					query.ReturnCode = ReturnCode.ServerFailure;
				}

				int length = response.Encode(false, originalMac, out buffer);

				#region Truncating
				DnsMessage message = response as DnsMessage;

				if (message != null)
				{
					int maxLength = 512;
					if (query.IsEDnsEnabled && message.IsEDnsEnabled)
					{
						maxLength = Math.Max(512, (int) message.EDnsOptions.UpdPayloadSize);
					}

					while (length > maxLength)
					{
						// First step: remove data from additional records except the opt record
						if ((message.IsEDnsEnabled && (message.AdditionalRecords.Count > 1)) || (!message.IsEDnsEnabled && (message.AdditionalRecords.Count > 0)))
						{
							for (int i = message.AdditionalRecords.Count - 1; i >= 0; i--)
							{
								if (message.AdditionalRecords[i].RecordType != RecordType.Opt)
								{
									message.AdditionalRecords.RemoveAt(i);
								}
							}

							length = message.Encode(false, originalMac, out buffer);
							continue;
						}

						int savedLength = 0;
						if (message.AuthorityRecords.Count > 0)
						{
							for (int i = message.AuthorityRecords.Count - 1; i >= 0; i--)
							{
								savedLength += message.AuthorityRecords[i].MaximumLength;
								message.AuthorityRecords.RemoveAt(i);

								if ((length - savedLength) < maxLength)
								{
									break;
								}
							}

							message.IsTruncated = true;

							length = message.Encode(false, originalMac, out buffer);
							continue;
						}

						if (message.AnswerRecords.Count > 0)
						{
							for (int i = message.AnswerRecords.Count - 1; i >= 0; i--)
							{
								savedLength += message.AnswerRecords[i].MaximumLength;
								message.AnswerRecords.RemoveAt(i);

								if ((length - savedLength) < maxLength)
								{
									break;
								}
							}

							message.IsTruncated = true;

							length = message.Encode(false, originalMac, out buffer);
							continue;
						}

						if (message.Questions.Count > 0)
						{
							for (int i = message.Questions.Count - 1; i >= 0; i--)
							{
								savedLength += message.Questions[i].MaximumLength;
								message.Questions.RemoveAt(i);

								if ((length - savedLength) < maxLength)
								{
									break;
								}
							}

							message.IsTruncated = true;

							length = message.Encode(false, originalMac, out buffer);
						}
					}
				}
				#endregion

				this.udpListener.BeginSend(buffer, 0, length, endpoint, EndUdpSend, null);
			}
			catch (Exception e)
			{
				this.HandleUdpException(e);
			}
		}

		/// <summary>
		/// Processes a DNS message.
		/// </summary>
		/// <param name="query">The query message.</param>
		/// <param name="ipAddress">The IP address.</param>
		/// <param name="protocolType">The protocol type.</param>
		/// <returns>The processed message.</returns>
		private DnsMessageBase ProcessMessage(DnsMessageBase query, IPAddress ipAddress, ProtocolType protocolType)
		{
			if (query.TSigOptions != null)
			{
				switch (query.TSigOptions.ValidationResult)
				{
					case ReturnCode.BadKey:
					case ReturnCode.BadSig:
						query.IsQuery = false;
						query.ReturnCode = ReturnCode.NotAuthoritive;
						query.TSigOptions.Error = query.TSigOptions.ValidationResult;
						query.TSigOptions.KeyData = null;

						if (InvalidSignedMessageReceived != null)
							InvalidSignedMessageReceived(this, new InvalidSignedMessageEventArgs(query));

						return query;

					case ReturnCode.BadTime:
						query.IsQuery = false;
						query.ReturnCode = ReturnCode.NotAuthoritive;
						query.TSigOptions.Error = query.TSigOptions.ValidationResult;
						query.TSigOptions.OtherData = new byte[6];
						int tmp = 0;
						TSigRecord.EncodeDateTime(query.TSigOptions.OtherData, ref tmp, DateTime.Now);

						if (InvalidSignedMessageReceived != null)
							InvalidSignedMessageReceived(this, new InvalidSignedMessageEventArgs(query));

						return query;
				}
			}

			return this.processQueryDelegate(query, ipAddress, protocolType);
		}

		/// <summary>
		/// Ends sending a DNS responese.
		/// </summary>
		/// <param name="asyncResult">The asynchronous result.</param>
		private void EndUdpSend(IAsyncResult asyncResult)
		{
			try
			{
				this.udpListener.EndSend(asyncResult);
			}
			catch (Exception e)
			{
				this.HandleUdpException(e);
			}

			lock (this.udpListener)
			{
				this.availableUdpListener++;
			}
			this.StartUdpListen();
		}

		/// <summary>
		/// Starts accepting a TCP connection.
		/// </summary>
		private void StartTcpAcceptConnection()
		{
			try
			{
				lock (this.tcpListener)
				{
					if ((this.availableTcpListener > 0) && !this.hasActiveTcpListener)
					{
						this.availableTcpListener--;
						this.hasActiveTcpListener = true;
						this.tcpListener.BeginAcceptTcpClient(EndTcpAcceptConnection, null);
					}
				}
			}
			catch (Exception e)
			{
				lock (this.tcpListener)
				{
					this.hasActiveTcpListener = false;
				}
				this.HandleTcpException(e, null, null);
			}
		}

		/// <summary>
		/// Ends accepting a TCP connection.
		/// </summary>
		/// <param name="asyncResult">The asynchronous result.</param>
		private void EndTcpAcceptConnection(IAsyncResult asyncResult)
		{
			TcpClient client = null;
			NetworkStream stream = null;

			try
			{
				client = this.tcpListener.EndAcceptTcpClient(asyncResult);
				lock (this.tcpListener)
				{
					this.hasActiveTcpListener = false;
					this.StartTcpAcceptConnection();
				}

				stream = client.GetStream();

				ServerState state =
					new ServerState
					{
						Client = client,
						Stream = stream,
						Buffer = new byte[2],
						BytesToReceive = 2,
						TimeRemaining = Timeout
					};

				state.Timer = new Timer(TcpTimedOut, state, state.TimeRemaining, System.Threading.Timeout.Infinite);
				state.AsyncResult = stream.BeginRead(state.Buffer, 0, 2, EndTcpReadLength, state);
			}
			catch (Exception e)
			{
				this.HandleTcpException(e, stream, client);
			}
		}

		/// <summary>
		/// A method called when a TCP operation timed out.
		/// </summary>
		/// <param name="timeoutState">The timeout state.</param>
		private void TcpTimedOut(object timeoutState)
		{
			ServerState state = timeoutState as ServerState;

			if ((state != null) && (state.AsyncResult != null) && !state.AsyncResult.IsCompleted)
			{
				try
				{
					if (state.Stream != null)
					{
						state.Stream.Close();
					}
				}
				catch {}

				try
				{
					if (state.Client != null)
					{
						state.Client.Close();
					}
				}
				catch {}
			}
		}

		/// <summary>
		/// Ends reading the length for a TCP connection.
		/// </summary>
		/// <param name="asyncResult">The asynchronous result.</param>
		private void EndTcpReadLength(IAsyncResult asyncResult)
		{
			TcpClient client = null;
			NetworkStream stream = null;

			try
			{
				ServerState state = (ServerState) asyncResult.AsyncState;
				client = state.Client;
				stream = state.Stream;

				state.Timer.Dispose();

				state.BytesToReceive -= stream.EndRead(asyncResult);

				if (state.BytesToReceive > 0)
				{
					if (!IsTcpClientConnected(client))
					{
						this.HandleTcpException(null, stream, client);
						return;
					}

					state.Timer = new Timer(TcpTimedOut, state, state.TimeRemaining, System.Threading.Timeout.Infinite);
					state.AsyncResult = stream.BeginRead(state.Buffer, state.Buffer.Length - state.BytesToReceive, state.BytesToReceive, EndTcpReadLength, state);
				}
				else
				{
					int tmp = 0;
					int length = DnsMessageBase.ParseUShort(state.Buffer, ref tmp);

					if (length > 0)
					{
						state.Buffer = new byte[length];

						state.Timer = new Timer(TcpTimedOut, state, state.TimeRemaining, System.Threading.Timeout.Infinite);
						state.AsyncResult = stream.BeginRead(state.Buffer, 0, length, EndTcpReadData, state);
					}
					else
					{
						this.HandleTcpException(null, stream, client);
					}
				}
			}
			catch (Exception e)
			{
				this.HandleTcpException(e, stream, client);
			}
		}

		/// <summary>
		/// Determines whether a TCP client is connected.
		/// </summary>
		/// <param name="client">The TCP client.</param>
		/// <returns><b>True</b> if the client is connected, <b>false</b> otherwise.</returns>
		private static bool IsTcpClientConnected(TcpClient client)
		{
			if (!client.Connected)
				return false;

			if (client.Client.Poll(0, SelectMode.SelectRead))
			{
				if (client.Connected)
				{
					byte[] b = new byte[1];
					try
					{
						if (client.Client.Receive(b, SocketFlags.Peek) == 0)
						{
							return false;
						}
					}
					catch
					{
						return false;
					}
				}
			}

			return true;
		}

		/// <summary>
		/// Ends reading the data for a TCP connection.
		/// </summary>
		/// <param name="asyncResult">The asynchronous result.</param>
		private void EndTcpReadData(IAsyncResult asyncResult)
		{
			TcpClient client = null;
			NetworkStream stream = null;

			try
			{
				ServerState state = (ServerState) asyncResult.AsyncState;
				client = state.Client;
				stream = state.Stream;

				state.Timer.Dispose();

				state.BytesToReceive -= stream.EndRead(asyncResult);

				if (state.BytesToReceive > 0)
				{
					if (!IsTcpClientConnected(client))
					{
						this.HandleTcpException(null, stream, client);
						return;
					}

					state.Timer = new Timer(TcpTimedOut, state, state.TimeRemaining, System.Threading.Timeout.Infinite);
					state.AsyncResult = stream.BeginRead(state.Buffer, state.Buffer.Length - state.BytesToReceive, state.BytesToReceive, EndTcpReadData, state);
				}
				else
				{
					DnsMessageBase query;
					try
					{
						query = DnsMessageBase.Create(state.Buffer, true, TsigKeySelector, null);
						state.NextTsigMac = (query.TSigOptions == null) ? null : query.TSigOptions.Mac;
					}
					catch (Exception e)
					{
						throw new Exception("Error parsing dns query", e);
					}

					try
					{
						state.Response = this.ProcessMessage(query, ((IPEndPoint) client.Client.RemoteEndPoint).Address, ProtocolType.Tcp);
					}
					catch (Exception e)
					{
						this.OnExceptionThrown(e);
						state.Response = null;
					}

					this.ProcessAndSendTcpResponse(state, false);
				}
			}
			catch (Exception e)
			{
				this.HandleTcpException(e, stream, client);
			}
		}

		/// <summary>
		/// Processes and sends a response for a TCP connection.
		/// </summary>
		/// <param name="state">The server state.</param>
		/// <param name="isSubSequentResponse">If <b>true</b> it indicates that there exists a subsequent response.</param>
		private void ProcessAndSendTcpResponse(ServerState state, bool isSubSequentResponse)
		{
			if (state.Response == null)
			{
				state.Response = DnsMessageBase.Create(state.Buffer, true, TsigKeySelector, null);
				state.Response.IsQuery = false;
				state.Response.AdditionalRecords.Clear();
				state.Response.AuthorityRecords.Clear();
				state.Response.ReturnCode = ReturnCode.ServerFailure;
			}

			byte[] newTsigMac;

			int length = state.Response.Encode(true, state.NextTsigMac, isSubSequentResponse, out state.Buffer, out newTsigMac);

			if (length > 65535)
			{
				if ((state.Response.Questions.Count == 0) || (state.Response.Questions[0].RecordType != RecordType.Axfr))
				{
					this.OnExceptionThrown(new ArgumentException("The length of the serialized response is greater than 65,535 bytes"));
					state.Response = DnsMessageBase.Create(state.Buffer, true, TsigKeySelector, null);
					state.Response.IsQuery = false;
					state.Response.ReturnCode = ReturnCode.ServerFailure;
					state.Response.AdditionalRecords.Clear();
					state.Response.AuthorityRecords.Clear();
					length = state.Response.Encode(true, state.NextTsigMac, isSubSequentResponse, out state.Buffer, out newTsigMac);
				}
				else
				{
					List<DnsRecordBase> nextPacketRecords = new List<DnsRecordBase>();

					do
					{
						int lastIndex = Math.Min(500, state.Response.AnswerRecords.Count / 2);
						int removeCount = state.Response.AnswerRecords.Count - lastIndex;

						nextPacketRecords.InsertRange(0, state.Response.AnswerRecords.GetRange(lastIndex, removeCount));
						state.Response.AnswerRecords.RemoveRange(lastIndex, removeCount);

						length = state.Response.Encode(true, state.NextTsigMac, isSubSequentResponse, out state.Buffer, out newTsigMac);
					} while (length > 65535);

					state.Response.AnswerRecords = nextPacketRecords;
				}
			}
			else
			{
				state.Response = null;
			}

			state.NextTsigMac = newTsigMac;

			state.Timer = new Timer(TcpTimedOut, state, state.TimeRemaining, System.Threading.Timeout.Infinite);
			state.AsyncResult = state.Stream.BeginWrite(state.Buffer, 0, length, EndTcpSendData, state);
		}

		/// <summary>
		/// Ends sending the data for a TCP connection.
		/// </summary>
		/// <param name="asyncResult">The asynchronous result.</param>
		private void EndTcpSendData(IAsyncResult asyncResult)
		{
			TcpClient client = null;
			NetworkStream stream = null;

			try
			{
				ServerState state = (ServerState) asyncResult.AsyncState;
				client = state.Client;
				stream = state.Stream;

				state.Timer.Dispose();

				stream.EndWrite(asyncResult);

				if (state.Response == null)
				{
					if (state.NextTsigMac == null)
					{
						state.Buffer = new byte[2];
						state.BytesToReceive = 2;
						state.TimeRemaining = Timeout;

						state.Timer = new Timer(TcpTimedOut, state, state.TimeRemaining, System.Threading.Timeout.Infinite);
						state.AsyncResult = stream.BeginRead(state.Buffer, 0, 2, EndTcpReadLength, state);
					}
					else
					{
						// Since support for multiple tsig signed messages is not finished, just close connection after response to first signed query
						state.Stream.Close();
						state.Client.Close();
					}
				}
				else
				{
					this.ProcessAndSendTcpResponse(state, true);
				}
			}
			catch (Exception e)
			{
				this.HandleTcpException(e, stream, client);
			}
		}

		/// <summary>
		/// Handles an exception for a UDP request.
		/// </summary>
		/// <param name="e">The exception.</param>
		private void HandleUdpException(Exception e)
		{
			lock (this.udpListener)
			{
				this.availableUdpListener++;
			}
			this.StartUdpListen();

			this.OnExceptionThrown(e);
		}

		/// <summary>
		/// Handles an exception for a TCP request.
		/// </summary>
		/// <param name="e">The exception.</param>
		/// <param name="stream">The stream.</param>
		/// <param name="client">The TCP client.</param>
		private void HandleTcpException(Exception e, NetworkStream stream, TcpClient client)
		{
			try
			{
				if (stream != null)
				{
					stream.Close();
				}
			}
			catch {}

			try
			{
				if (client != null)
				{
					client.Close();
				}
			}
			catch {}

			lock (this.tcpListener)
			{
				this.availableTcpListener++;
			}
			this.StartTcpAcceptConnection();

			if (e != null)
				this.OnExceptionThrown(e);
		}

		/// <summary>
		/// An event handler called when an exception is thrown.
		/// </summary>
		/// <param name="e">The exception.</param>
		private void OnExceptionThrown(Exception e)
		{
			if (e is ObjectDisposedException)
				return;

			if (ExceptionThrown != null)
			{
				this.ExceptionThrown(this, new ExceptionEventArgs(e));
			}
			else
			{
				Trace.TraceError(e.ToString());
			}
		}

		#endregion
	}
}