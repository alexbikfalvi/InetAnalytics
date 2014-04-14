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
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using InetApi.Net.Core.Dns.DynamicUpdate;

namespace InetApi.Net.Core.Dns
{
	/// <summary>
	/// Provides a client for querying DNS records.
	/// </summary>
	public class DnsClient : DnsClientBase
	{
		/// <summary>
		/// Returns a default instance of the DNS client, which uses the configured DNS servers of the executing computer and a query timeout of 10 seconds.
		/// </summary>
		public static DnsClient Default { get; private set; }

		/// <summary>
		/// Static constructor.
		/// </summary>
		static DnsClient()
		{
			DnsClient.Default = new DnsClient(DnsClient.GetDnsServers(), 10000);
		}

		/// <summary>
		/// Provides a new instance with custom DNS server and query timeout
		/// </summary>
		/// <param name="queryTimeout">Query timeout in milliseconds.</param>
		public DnsClient(int queryTimeout)
			: this(new List<IPAddress>(), queryTimeout) { }

		/// <summary>
		/// Provides a new instance with custom DNS server and query timeout
		/// </summary>
		/// <param name="dnsServer">The IPAddress of the DNS server to use.</param>
		/// <param name="queryTimeout">Query timeout in milliseconds.</param>
		public DnsClient(IPAddress dnsServer, int queryTimeout)
			: this(new List<IPAddress> { dnsServer }, queryTimeout) {}

		/// <summary>
		/// Provides a new instance with custom DNS servers and query timeout
		/// </summary>
		/// <param name="dnsServers">The IPAddresses of the DNS servers to use.</param>
		/// <param name="queryTimeout">Query timeout in milliseconds.</param>
		public DnsClient(List<IPAddress> dnsServers, int queryTimeout)
			: base(dnsServers, queryTimeout, 53) {}

		// Protected properties.

		/// <summary>
		/// Gets the maximum query message size.
		/// </summary>
		protected override int MaximumQueryMessageSize
		{
			get { return 512; }
		}
		/// <summary>
		/// Gets whether the client supports multiple responses in parallel mode.
		/// </summary>
		protected override bool AreMultipleResponsesAllowedInParallelMode
		{
			get { return false; }
		}

		// Public methods.

		/// <summary>
		/// Queries a DNS server for address records.
		/// </summary>
		/// <param name="name"> Domain, that should be queried </param>
		/// <returns> The complete response of the DNS server </returns>
		public DnsMessage Resolve(string name)
		{
			return Resolve(name, RecordType.A, RecordClass.INet);
		}

		/// <summary>
		/// Queries a DNS server for specified records.
		/// </summary>
		/// <param name="name"> Domain, that should be queried </param>
		/// <param name="recordType"> Recordtype the should be queried </param>
		/// <returns> The complete response of the DNS server </returns>
		public DnsMessage Resolve(string name, RecordType recordType)
		{
			return Resolve(name, recordType, RecordClass.INet);
		}

		/// <summary>
		/// Queries a DNS server for specified records.
		/// </summary>
		/// <param name="name"> Domain, that should be queried </param>
		/// <param name="recordType"> Type the should be queried </param>
		/// <param name="recordClass"> Class the should be queried </param>
		/// <returns> The complete response of the DNS server </returns>
		public DnsMessage Resolve(string name, RecordType recordType, RecordClass recordClass)
		{
			if (String.IsNullOrEmpty(name))
			{
				throw new ArgumentException("The name is missing.", "name");
			}

			DnsMessage message = new DnsMessage() { IsQuery = true, OperationCode = OperationCode.Query, IsRecursionDesired = true };
			message.Questions.Add(new DnsQuestion(name, recordType, recordClass));

			return SendMessage(message);
		}

		/// <summary>
		/// Queries a DNS server for specified records.
		/// </summary>
		/// <param name="name"> Domain, that should be queried </param>
		/// <param name="localAddress">The local IP address.</param>
		/// <param name="serverAddress">The server IP address.</param>
		/// <param name="recordType"> Type the should be queried </param>
		/// <param name="recordClass"> Class the should be queried </param>
		/// <returns> The complete response of the DNS server </returns>
		public DnsMessage Resolve(string name, IPAddress localAddress, IPAddress serverAddress, RecordType recordType, RecordClass recordClass)
		{
			if (String.IsNullOrEmpty(name))
			{
				throw new ArgumentException("The name is missing.", "name");
			}

			DnsMessage message = new DnsMessage() { IsQuery = true, OperationCode = OperationCode.Query, IsRecursionDesired = true };
			message.Questions.Add(new DnsQuestion(name, recordType, recordClass));

			return SendMessage(message, localAddress, serverAddress);
		}

		/// <summary>
		/// Queries a DNS server for specified records asynchronously.
		/// </summary>
		/// <param name="name"> Domain, that should be queried </param>
		/// <param name="requestCallback"> An <see cref="System.AsyncCallback" /> delegate that references the method to invoked then the operation is complete. </param>
		/// <param name="state"> A user-defined object that contains information about the receive operation. This object is passed to the <paramref
		///  name="requestCallback" /> delegate when the operation is complete. </param>
		/// <returns> An <see cref="System.IAsyncResult" /> IAsyncResult object that references the asynchronous receive. </returns>
		public IAsyncResult BeginResolve(string name, AsyncCallback requestCallback, object state)
		{
			return this.BeginResolve(name, RecordType.A, RecordClass.INet, requestCallback, state);
		}

		/// <summary>
		/// Queries a DNS server for specified records asynchronously.
		/// </summary>
		/// <param name="name"> Domain, that should be queried </param>
		/// <param name="recordType"> Type the should be queried </param>
		/// <param name="requestCallback"> An <see cref="System.AsyncCallback" /> delegate that references the method to invoked then the operation is complete. </param>
		/// <param name="state"> A user-defined object that contains information about the receive operation. This object is passed to the <paramref
		///  name="requestCallback" /> delegate when the operation is complete. </param>
		/// <returns> An <see cref="System.IAsyncResult" /> IAsyncResult object that references the asynchronous receive. </returns>
		public IAsyncResult BeginResolve(string name, RecordType recordType, AsyncCallback requestCallback, object state)
		{
			return this.BeginResolve(name, recordType, RecordClass.INet, requestCallback, state);
		}

		/// <summary>
		/// Queries a DNS server for specified records asynchronously.
		/// </summary>
		/// <param name="name"> Domain, that should be queried </param>
		/// <param name="recordType"> Type the should be queried </param>
		/// <param name="recordClass"> Class the should be queried </param>
		/// <param name="requestCallback"> An <see cref="System.AsyncCallback" /> delegate that references the method to invoked then the operation is complete. </param>
		/// <param name="state"> A user-defined object that contains information about the receive operation. This object is passed to the <paramref
		///  name="requestCallback" /> delegate when the operation is complete. </param>
		/// <returns> An <see cref="System.IAsyncResult" /> IAsyncResult object that references the asynchronous receive. </returns>
		public IAsyncResult BeginResolve(string name, RecordType recordType, RecordClass recordClass, AsyncCallback requestCallback, object state)
		{
			if (String.IsNullOrEmpty(name))
			{
				throw new ArgumentException("Name must be provided", "name");
			}

			DnsMessage message = new DnsMessage() { IsQuery = true, OperationCode = OperationCode.Query, IsRecursionDesired = true };
			message.Questions.Add(new DnsQuestion(name, recordType, recordClass));

			return this.BeginSendMessage(message, requestCallback, state);
		}

		/// <summary>
		/// Queries a DNS server for specified records asynchronously.
		/// </summary>
		/// <param name="name"> Domain, that should be queried </param>
		/// <param name="localAddress">The local IP address.</param>
		/// <param name="serverAddress">The server IP address.</param>
		/// <param name="recordType"> Type the should be queried </param>
		/// <param name="recordClass"> Class the should be queried </param>
		/// <param name="requestCallback"> An <see cref="System.AsyncCallback" /> delegate that references the method to invoked then the operation is complete. </param>
		/// <param name="state"> A user-defined object that contains information about the receive operation. This object is passed to the <paramref
		///  name="requestCallback" /> delegate when the operation is complete. </param>
		/// <returns> An <see cref="System.IAsyncResult" /> IAsyncResult object that references the asynchronous receive. </returns>
		public IAsyncResult BeginResolve(string name, IPAddress localAddress, IPAddress serverAddress, RecordType recordType, RecordClass recordClass, AsyncCallback requestCallback, object state)
		{
			if (String.IsNullOrEmpty(name))
			{
				throw new ArgumentException("Name must be provided", "name");
			}

			DnsMessage message = new DnsMessage() { IsQuery = true, OperationCode = OperationCode.Query, IsRecursionDesired = true };
			message.Questions.Add(new DnsQuestion(name, recordType, recordClass));

			return this.BeginSendMessage(message, localAddress, serverAddress, requestCallback, state);
		}

		/// <summary>
		/// Ends a pending asynchronous operation.
		/// </summary>
		/// <param name="asyncResult"> An <see cref="System.IAsyncResult" /> object returned by a call to <see cref="InetApi.Net.Core.Dns.DnsClient.BeginResolve" />.</param>
		/// <returns> The complete response of the DNS server </returns>
		public DnsMessage EndResolve(IAsyncResult asyncResult)
		{
			return this.EndSendMessage<DnsMessage>(asyncResult).FirstOrDefault();
		}

		/// <summary>
		/// Send a custom message to the DNS server and returns the answer.
		/// </summary>
		/// <param name="message"> Message, that should be send to the DNS server </param>
		/// <returns> The complete response of the DNS server </returns>
		public DnsMessage SendMessage(DnsMessage message)
		{
			if (message == null)
				throw new ArgumentNullException("message");

			if ((message.Questions == null) || (message.Questions.Count == 0))
				throw new ArgumentException("At least one question must be provided", "message");

			return this.SendMessage<DnsMessage>(message);
		}

		/// <summary>
		/// Send an dynamic update to the DNS server and returns the answer.
		/// </summary>
		/// <param name="message"> Update, that should be send to the DNS server </param>
		/// <returns> The complete response of the DNS server </returns>
		public DnsUpdateMessage SendUpdate(DnsUpdateMessage message)
		{
			if (message == null)
				throw new ArgumentNullException("message");

			if (String.IsNullOrEmpty(message.ZoneName))
				throw new ArgumentException("Zone name must be provided", "message");

			return this.SendMessage(message);
		}

		/// <summary>
		/// Send a custom message to the DNS server and returns the answer asynchronously.
		/// </summary>
		/// <param name="message"> Message, that should be send to the DNS server </param>
		/// <param name="requestCallback"> An <see cref="System.AsyncCallback" /> delegate that references the method to invoked then the operation is complete. </param>
		/// <param name="state"> A user-defined object that contains information about the receive operation. This object is passed to the <paramref
		///  name="requestCallback" /> delegate when the operation is complete. </param>
		/// <returns> An <see cref="System.IAsyncResult" /> IAsyncResult object that references the asynchronous receive. </returns>
		public IAsyncResult BeginSendMessage(DnsMessage message, AsyncCallback requestCallback, object state)
		{
			if (message == null)
				throw new ArgumentNullException("message");

			if ((message.Questions == null) || (message.Questions.Count == 0))
				throw new ArgumentException("At least one question must be provided", "message");

			return this.BeginSendMessage<DnsMessage>(message, requestCallback, state);
		}

		/// <summary>
		/// Send an dynamic update to the DNS server and returns the answer asynchronously.
		/// </summary>
		/// <param name="message"> Update, that should be send to the DNS server </param>
		/// <param name="requestCallback"> An <see cref="System.AsyncCallback" /> delegate that references the method to invoked then the operation is complete. </param>
		/// <param name="state"> A user-defined object that contains information about the receive operation. This object is passed to the <paramref
		///  name="requestCallback" /> delegate when the operation is complete. </param>
		/// <returns> An <see cref="System.IAsyncResult" /> IAsyncResult object that references the asynchronous receive. </returns>
		public IAsyncResult BeginSendUpdate(DnsUpdateMessage message, AsyncCallback requestCallback, object state)
		{
			if (message == null)
				throw new ArgumentNullException("message");

			if (String.IsNullOrEmpty(message.ZoneName))
				throw new ArgumentException("Zone name must be provided", "message");

			return this.BeginSendMessage(message, requestCallback, state);
		}

		/// <summary>
		/// Ends a pending asynchronous operation.
		/// </summary>
		/// <param name="asyncResult"> An <see cref="System.IAsyncResult" /> object returned by a call to <see cref="InetApi.Net.Core.Dns.DnsClient.BeginSendMessage" />.</param>
		/// <returns> The complete response of the DNS server </returns>
		public DnsMessage EndSendMessage(IAsyncResult asyncResult)
		{
			return this.EndSendMessage<DnsMessage>(asyncResult).FirstOrDefault();
		}

		/// <summary>
		/// Ends a pending asynchronous operation.
		/// </summary>
		/// <param name="asyncResult"> An <see cref="System.IAsyncResult" /> object returned by a call to <see cref="InetApi.Net.Core.Dns.DnsClient.BeginSendUpdate" />.</param>
		/// <returns> The complete response of the DNS server </returns>
		public DnsUpdateMessage EndSendUpdate(IAsyncResult asyncResult)
		{
			return this.EndSendMessage<DnsUpdateMessage>(asyncResult).FirstOrDefault();
		}

		// Private methods.

		/// <summary>
		/// Gets the lisy of DNS servers.
		/// </summary>
		/// <returns>The list of DNS servers.</returns>
		private static List<IPAddress> GetDnsServers()
		{
			List<IPAddress> addresses = new List<IPAddress>();

			try
			{
				foreach (NetworkInterface iface in NetworkInterface.GetAllNetworkInterfaces())
				{
					if ((iface.OperationalStatus == OperationalStatus.Up) && (iface.NetworkInterfaceType != NetworkInterfaceType.Loopback))
					{
						foreach (IPAddress address in iface.GetIPProperties().DnsAddresses)
						{
							if (!addresses.Contains(address))
							{
								addresses.Add(address);
							}
						}
					}
				}
			}
			catch { }

			// If the address list is empty, use the Google DNS servers.
			if (addresses.Count == 0)
			{
				addresses.Add(IPAddress.Parse("8.8.4.4"));
				addresses.Add(IPAddress.Parse("8.8.8.8"));
			}

			return addresses.OrderBy(x => x.AddressFamily == AddressFamily.InterNetworkV6 ? 1 : 0).ToList();
		}
	}
}