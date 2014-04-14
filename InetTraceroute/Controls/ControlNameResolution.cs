/* 
 * Copyright (C) 2014 Alex Bikfalvi
 *
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 3 of the License, or (at
 * your option) any later version.
 *
 * This program is distributed in the hope that it will be useful, but
 * WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 * General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301, USA.
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using DotNetApi;
using DotNetApi.Windows.Controls;
using InetApi.Net.Core.Dns;
using InetCommon.Log;
using InetCommon.Net;
using InetCommon.Status;

namespace InetTraceroute.Controls
{
	/// <summary>
	/// A control allowing the execution of the name resolution for a server.
	/// </summary>
	public partial class ControlNameResolution : NotificationControl
	{
		private static readonly string logSource = "Domain Name System";

		private TracerouteApplication application = null;
		private ApplicationStatusHandler status = null;

		private readonly DnsClient dnsClient = new DnsClient(3000);

		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlNameResolution()
		{
			// Initialize the component.
			this.InitializeComponent();

			// Set the control properties.
			this.Enabled = false;

			// Add the DNS records to the list check box.
			foreach (RecordType type in Enum.GetValues(typeof(RecordType)))
			{
				if (type.HasDescription())
				{
					this.listRecords.AddItem(type, type.GetDescription(), (type == RecordType.A) || (type == RecordType.Aaaa) ? CheckState.Checked : CheckState.Unchecked);
				}
			}
		}

		#region Public methods

		/// <summary>
		/// Initializes the control.
		/// </summary>
		/// <param name="application">The application.</param>
		public void Initialize(TracerouteApplication application)
		{
			// Set the application.
			this.application = application;
			// Set the control status.
			this.status = this.application.Status.GetHandler(this);

			// Enable the control.
			this.Enabled = true;
		}

		#endregion

		#region Private methods

		/// <summary>
		/// An event handler called when the name has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnNameChanged(object sender, EventArgs e)
		{
			this.buttonStart.Enabled = !string.IsNullOrWhiteSpace(this.textBoxName.Text);
		}

		/// <summary>
		/// An event handler called when the user clicks on the start button.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnStart(object sender, EventArgs e)
		{
			// Disable the controls.
			this.buttonStart.Enabled = false;
			this.buttonStop.Enabled = true;
			this.buttonRecords.Enabled = false;
			this.textBoxName.Enabled = false;

			// Get the host name.
			string name = this.textBoxName.Text;

			// Set the client query timeout.
			this.dnsClient.QueryTimeout = (int)this.application.Config.DnsQueryTimeout.TotalMilliseconds;

			// Clear the result.
			this.textBoxResult.Clear();

			// Write an information message.
			this.textBoxResult.AppendText("Resolving name ");
			this.textBoxResult.AppendText(Color.Cyan, name);
			this.textBoxResult.AppendText(" using a timeout of ");
			this.textBoxResult.AppendText(Color.Cyan, "{0}", this.dnsClient.QueryTimeout);
			this.textBoxResult.AppendDoubleLine(" milliseconds...");

			// Execute the name resolution on the thread pool.
			ThreadPool.QueueUserWorkItem((object state) =>
				{
					// Show the message.
					this.ShowMessage(Resources.GlobeClock_48, "Name Resolution", "Resolving name \'{0}\'...".FormatWith(name));

					// Get the list of local IP addresses.
					List<UnicastNetworkAddressInformation> localInfo;
					lock (NetworkAddresses.Sync)
					{
						localInfo = NetworkAddresses.Unicast.ToList();
					}

					// For all local addresses.
					foreach (UnicastNetworkAddressInformation info in localInfo)
					{
						// If the interface is not selected, do nothing.
						if (!info.Selected) continue;

						// If the interface is not operational, do nothing.
						if ((info.Interface.OperationalStatus != OperationalStatus.Up) || (info.Interface.NetworkInterfaceType == NetworkInterfaceType.Loopback)) continue;

						// For each interface, select the list of DNS servers.
						foreach (IPAddress serverAddress in info.Interface.GetIPProperties().DnsAddresses)
						{
							// Skip the addresses that do not have the same family as the local address.
							if (serverAddress.AddressFamily != info.UnicastInformation.Address.AddressFamily) continue;

							this.Invoke(() =>
								{
									// Write the local IP address.
									this.textBoxResult.AppendText("[Local: ");
									this.textBoxResult.AppendText(Color.SkyBlue, info.UnicastInformation.Address.ToString());
									this.textBoxResult.AppendText(" Interface: ");
									this.textBoxResult.AppendText(Color.SkyBlue, info.Interface.Name);
									this.textBoxResult.AppendText(" Server: ");
									this.textBoxResult.AppendText(Color.SkyBlue, serverAddress.ToString());
									this.textBoxResult.AppendLine("]");
								});

							// For all records type.
							foreach (CheckedListItem item in this.listRecords.CheckedItems)
							{
								// Get the record type.
								RecordType recordType = (RecordType)item.Item;

								// Show the record type.
								//this.Invoke(() =>
								//	{
								//		this.textBoxResult.AppendText("Record: ");
								//		this.textBoxResult.AppendLine(Color.Yellow, recordType.GetDescription());
								//	});

								try
								{
									// Resolve the DNS name.
									DnsMessage response = this.dnsClient.Resolve(name, info.UnicastInformation.Address, serverAddress, recordType, RecordClass.INet);

									this.Invoke(() =>
										{
											// Show the questions.
											this.textBoxResult.AppendLine(Color.White, "Questions");
											foreach (DnsQuestion question in response.Questions)
											{
												this.textBoxResult.AppendLine(Color.Red, "{0} {1} {2}", question.Name, question.RecordClass.GetDescription(), question.RecordType.GetDescription());
											}
											this.textBoxResult.AppendLine();
											// Show the answer.
											this.textBoxResult.AppendLine(Color.White, "Answers");
											foreach (DnsRecordBase record in response.AnswerRecords)
											{
												this.textBoxResult.AppendLine(Color.Lime, record.ToString());
											}
											this.textBoxResult.AppendLine();
											// Show the authority.
											this.textBoxResult.AppendLine(Color.White, "Authority");
											foreach (DnsRecordBase record in response.AuthorityRecords)
											{
												this.textBoxResult.AppendLine(Color.Cyan, record.ToString());
											}
											this.textBoxResult.AppendLine();
											// Show the additional records.
											this.textBoxResult.AppendLine(Color.White, "Additional");
											foreach (DnsRecordBase record in response.AdditionalRecords)
											{
												this.textBoxResult.AppendLine(Color.Yellow, record.ToString());
											}
											this.textBoxResult.AppendLine();
										});
								}
								catch (Exception exception)
								{

								}
							}
						}
					}

					// Get the DNS se
					//;

					// Hide the message.
					this.HideMessage((object[] parameters) =>
						{
							// Enable the controls.
							this.buttonStart.Enabled = true;
							this.buttonStop.Enabled = false;
							this.buttonRecords.Enabled = false;
							this.textBoxName.Enabled = true;
						});
				});
		}

		/// <summary>
		/// An event handler called when the user clicks on the stop button.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnStop(object sender, EventArgs e)
		{

		}

		#endregion
	}
}
