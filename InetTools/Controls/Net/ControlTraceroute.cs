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
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using DotNetApi;
using DotNetApi.Windows.Controls;
using InetAnalytics;
using InetAnalytics.Forms.Net;
using InetApi.Net.Core;
using InetCommon.Status;
using InetCrawler;
using InetCrawler.Log;
using InetCrawler.Tools;
using InetTools.Tools.Net;

namespace InetTools.Controls.Net
{
	/// <summary>
	/// A class representing the control for the traceroute analytics tool.
	/// </summary>
	public partial class ControlTraceroute : NotificationControl
	{
		private readonly TracerouteConfig config;

		private readonly ApplicationStatusHandler status = null;

		private readonly TracerouteSettings settings;
		private readonly Traceroute traceroute;

		private readonly FormIpSelectAddress formSelectAddress = new FormIpSelectAddress();

		private readonly object sync = new object();
		private IAsyncResult result = null;

		private bool configurationChanged = false;

		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		/// <param name="config">The tool configuration.</param>
		public ControlTraceroute(TracerouteConfig config)
		{
			// Initialize the component.
			this.InitializeComponent();
			
			// Set the configuration.
			this.config = config;

			// Create the traceroute settings.
			this.settings = new TracerouteSettings();
			// Create the traceroute instance.
			this.traceroute = new Traceroute(this.settings);

			// Load the configuration.
			this.OnLoadConfiguration();

			// Set the status.
			this.status = this.config.Api.Status.GetHandler(this);
			this.status.Send(ApplicationStatus.StatusType.Normal, "Ready.", Resources.Information_16);
		}

		// Private methods.

		/// <summary>
		/// Loads the tool configuration.
		/// </summary>
		private void OnLoadConfiguration()
		{
			// Load the configuration.
			this.textBoxDestination.Text = this.config.Destination;

			this.numericUpDownMaximumHops.Value = this.config.MaximumHops;
			this.numericUpDownMaximumAttempts.Value = this.config.MaximumAttempts;
			this.numericUpDownMaximumFailedHops.Value = this.config.MaximumFailedHops;
			this.numericUpDownDataLength.Value = this.config.DataLength;

			this.checkBoxAutomaticNameResolution.Checked = this.config.AutomaticNameResolution;
			this.checkBoxStopHopOnSuccess.Checked = this.config.StopHopOnSuccess;
			this.checkBoxStopOnFail.Checked = this.config.StopTracerouteOnFail;

			// Disable the save and undo buttons.
			this.buttonSave.Enabled = false;
			this.buttonUndo.Enabled = false;
		}

		/// <summary>
		/// Saves the tool configuration.
		/// </summary>
		private void OnSaveConfiguration()
		{
			// Save the configuration.
			this.config.Destination = this.textBoxDestination.Text;

			this.config.MaximumHops = (byte)this.numericUpDownMaximumHops.Value;
			this.config.MaximumAttempts = (byte)this.numericUpDownMaximumAttempts.Value;
			this.config.MaximumFailedHops = (byte)this.numericUpDownMaximumFailedHops.Value;
			this.config.DataLength = (int)this.numericUpDownDataLength.Value;

			this.config.AutomaticNameResolution = this.checkBoxAutomaticNameResolution.Checked;
			this.config.StopHopOnSuccess = this.checkBoxStopHopOnSuccess.Checked;
			this.config.StopTracerouteOnFail = this.checkBoxStopOnFail.Checked;

			// Disable the save and undo buttons.
			this.buttonSave.Enabled = false;
			this.buttonUndo.Enabled = false;
		}

		/// <summary>
		/// Sets the controls, except the request control buttons, to the disabled state.
		/// </summary>
		private void OnDisableControls()
		{
			// Save the enabled state.
			this.configurationChanged = this.buttonSave.Enabled;

			// Disable the controls.
			this.textBoxDestination.Enabled = false;

			this.buttonSave.Enabled = false;
			this.buttonUndo.Enabled = false;
		}

		/// <summary>
		/// Sets the controls, except the request control buttons, to the enabled state.
		/// </summary>
		private void OnEnableControls()
		{
			// Enable the controls.
			this.textBoxDestination.Enabled = true;

			this.buttonSave.Enabled = this.configurationChanged;
			this.buttonUndo.Enabled = this.configurationChanged;
		}

		/// <summary>
		/// An event handler called when the input has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnInputChanged(object sender, EventArgs e)
		{
			// Set the controls enabled state.
			this.buttonStart.Enabled = !string.IsNullOrWhiteSpace(this.textBoxDestination.Text);
			this.labelMaximumFailedHops.Enabled = this.checkBoxStopOnFail.Checked;
			this.numericUpDownMaximumFailedHops.Enabled = this.checkBoxStopOnFail.Checked;

			// Enable the save and undo buttons.
			this.buttonSave.Enabled = true;
			this.buttonUndo.Enabled = true;
		}

		/// <summary>
		/// An event handler called when the user clicks on the start button.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnStart(object sender, EventArgs e)
		{
			// Set the traceroute settings.
			lock (this.settings.Sync)
			{
				this.settings.MaximumHops = this.config.MaximumHops;
				this.settings.MaximumAttempts = this.config.MaximumAttempts;
				this.settings.MaximumFailedHops = this.config.MaximumFailedHops;
				this.settings.DataLength = this.config.DataLength;

				this.settings.StopHopOnSuccess = this.config.StopHopOnSuccess;
				this.settings.StopTracerouteOnFail = this.config.StopTracerouteOnFail;
			}

			// Change the controls state.
			this.OnDisableControls();
			// Change the buttons state.
			this.buttonStart.Enabled = false;
			this.buttonStop.Enabled = true;

			// Switch to the traceroute tab page.
			this.tabControl.SelectedTab = this.tabPageRoute;

			// Clear the response headers.
			this.listViewRoute.Items.Clear();

			// Get the traceroute destination.
			string destination = this.textBoxDestination.Text;

			// Set the status.
			this.status.Send(ApplicationStatus.StatusType.Busy, "Running Internet traceroute to \'{0}\'...".FormatWith(destination), Resources.Busy_16);
			// Show a message.
			this.ShowMessage(
				Resources.GlobeClock_48,
				"Internet Traceroute",
				"Running Internet traceroute to \'{0}\' with a maximum of {1} hop{2} and up to {3} attempt{4} per hop.".FormatWith(destination, this.settings.MaximumHops, this.settings.MaximumHops.PluralSuffix(), this.settings.MaximumAttempts, this.settings.MaximumAttempts.PluralSuffix())
				);
			// Log
			this.log.Add(this.config.Api.Log(
				LogEventLevel.Verbose,
				LogEventType.Information,
				"Running Internet traceroute to \'{0}\' with a maximum of {1} hop(s) and up to {2} attempt(s) per hop.",
				new object[] { destination,  this.settings.MaximumHops, this.settings.MaximumAttempts }));

			try
			{
				// Get the IP addresses of the specified destination.
				IAsyncResult asyncResult = Dns.BeginGetHostAddresses(destination, (IAsyncResult result) =>
					{
						try
						{
							// Get the list of IP addresses.
							IPAddress[] addresses = Dns.EndGetHostAddresses(result);

							this.Invoke(() =>
								{
									// Select the IP address.
									if (this.formSelectAddress.ShowDialog(this, addresses) == DialogResult.OK)
									{
										// Get the IP address.
										IPAddress address = this.formSelectAddress.Address;

										// Run the traceroute.
										this.OnRun(destination, address);
									}
									else
									{
										// Update the status label.
										this.status.Send(ApplicationStatus.StatusType.Normal, "Internet traceroute to \'{0}\' canceled".FormatWith(destination), Resources.Canceled_16);
										// Show a message.
										this.ShowMessage(
											Resources.GlobeCanceled_48,
											"Internet Traceroute",
											"Internet traceroute to \'{0}\' was canceled.".FormatWith(destination),
											false,
											(int)CrawlerConfig.Static.ConsoleMessageCloseDelay.TotalMilliseconds);
										// Log the result.
										this.log.Add(this.config.Api.Log(
											LogEventLevel.Verbose,
											LogEventType.Canceled,
											"Internet traceroute to \'{0}\' was canceled.",
											new object[] { destination }));
										// Change the controls state.
										this.OnEnableControls();
										// Change the buttons state.
										this.buttonStart.Enabled = true;
										this.buttonStop.Enabled = false;
									}
								});
						}
						catch (Exception exception)
						{
							// Update the status label.
							this.status.Send(ApplicationStatus.StatusType.Normal, "Running Internet traceroute to \'{0}\' failed".FormatWith(destination), Resources.Error_16);
							// Show a message.
							this.ShowMessage(
								Resources.GlobeError_48,
								"Internet Traceroute",
								"Running Internet traceroute to \'{0}\' failed. {1}".FormatWith(destination, exception.Message),
								false,
								(int)CrawlerConfig.Static.ConsoleMessageCloseDelay.TotalMilliseconds, (object[] parameters) =>
								{
									// Change the controls state.
									this.OnEnableControls();
									// Change the buttons state.
									this.buttonStart.Enabled = true;
									this.buttonStop.Enabled = false;
								});
							// Log the result.
							this.log.Add(this.config.Api.Log(
								LogEventLevel.Important,
								LogEventType.Error,
								"Running Internet traceroute to \'{0}\' failed. {1}",
								new object[] { destination, exception.Message },
								exception));
						}
					}, null);
			}
			catch (Exception exception)
			{
				// Update the status label.
				this.status.Send(ApplicationStatus.StatusType.Normal, "Running Internet traceroute to \'{0}\' failed.".FormatWith(destination), Resources.Error_16);
				// Show a message.
				this.ShowMessage(
					Resources.GlobeError_48,
					"Internet Traceroute",
					"Running Internet traceroute to \'{0}\' failed. {1}".FormatWith(destination, exception.Message),
					false,
					(int)CrawlerConfig.Static.ConsoleMessageCloseDelay.TotalMilliseconds);
				// Log the result.
				this.log.Add(this.config.Api.Log(
					LogEventLevel.Important,
					LogEventType.Error,
					"Running Internet traceroute to \'{0}\' failed. {1}",
					new object[] { destination, exception.Message },
					exception));
				// Change the controls state.
				this.OnEnableControls();
				// Change the buttons state.
				this.buttonStart.Enabled = true;
				this.buttonStop.Enabled = false;
			}
		}

		/// <summary>
		/// An event handler called when the user clicks on the stop button.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnStop(object sender, EventArgs e)
		{
			// Disable the stop button.
			this.buttonStop.Enabled = false;

			lock (this.sync)
			{
				if (null != this.result)
				{
					// Cancel the traceroute.
					this.traceroute.Cancel(this.result);
					this.result = null;
				}
			}
		}

		/// <summary>
		/// An event handler called when the user clicks on the save button.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSave(object sender, EventArgs e)
		{
			// Save the configuration.
			this.OnSaveConfiguration();
		}

		/// <summary>
		/// An event handler called when the user clicks on the undo button.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnUndo(object sender, EventArgs e)
		{
			// Load the configuration.
			this.OnLoadConfiguration();
		}

		/// <summary>
		/// Runs the traceroute for the specified destination and IP address.
		/// </summary>
		/// <param name="destination">The destination string.</param>
		/// <param name="address">The destination IP address.</param>
		private void OnRun(string destination, IPAddress address)
		{
			// Set the status.
			this.status.Send(ApplicationStatus.StatusType.Busy, "Running Internet traceroute to \'{0}\' ({1})...".FormatWith(destination, address), Resources.Busy_16);
			// Show a message.
			this.ShowMessage(
				Resources.GlobeClock_48,
				"Internet Traceroute",
				"Running Internet traceroute to \'{0}\' ({1}) with a maximum of {2} hop{3} and up to {4} attempt{5} per hop.".FormatWith(destination, address, this.settings.MaximumHops, this.settings.MaximumHops.PluralSuffix(), this.settings.MaximumAttempts, this.settings.MaximumAttempts.PluralSuffix())
				);

			try
			{
				lock (this.sync)
				{
					// Begin the traceroute.
					this.result = this.traceroute.Begin(address, (IAsyncResult result) =>
						{
							bool isCanceled = false;
							try
							{
								// End the traceroute.
								TracerouteResult tracerouteResult = this.traceroute.End(result);

								// Set whether the operation was canceled.
								isCanceled = tracerouteResult.IsCanceled;

								this.Invoke(() =>
									{
										// If there is an item for the current hop.
										if (this.listViewRoute.Items.Count > tracerouteResult.CurrentTtl - 1)
										{
											// Update the list view item.
											ListViewItem item = this.listViewRoute.Items[tracerouteResult.CurrentTtl - 1];

											// Set the item subitems.
											if (tracerouteResult.IsSuccess)
											{
												item.SubItems[1].Text = tracerouteResult.LastReply.Address.ToString();
											}
											item.SubItems[2].Text = tracerouteResult.RoundtripTimeCount > 0 ? "{0:G3} ms (avg) {1:G3} ms (min) {2:G3} ms (max)".FormatWith(tracerouteResult.RoundtripTimeAverage, tracerouteResult.RoundtripTimeMinimum, tracerouteResult.RoundtripTimeMaximum) : string.Empty;
											item.SubItems[3].Text = tracerouteResult.SuccessCount.ToString();
											item.SubItems[4].Text = tracerouteResult.ErrorCount.ToString();
											item.SubItems[5].Text = (tracerouteResult.SuccessCount + tracerouteResult.ErrorCount).ToString();

											// Set the item image.
											item.ImageKey = ControlTraceroute.GetItemImageKey(tracerouteResult);
										}
										else
										{
											// Add a list view item.
											ListViewItem item = new ListViewItem(new string[] {
											tracerouteResult.CurrentTtl.ToString(),
											tracerouteResult.IsSuccess ? tracerouteResult.LastReply.Address.ToString() : "*",
											tracerouteResult.RoundtripTimeCount > 0 ? "{0:G3} ms (avg) {1:G3} ms (min) {2:G3} ms (max)".FormatWith(tracerouteResult.RoundtripTimeAverage, tracerouteResult.RoundtripTimeMinimum, tracerouteResult.RoundtripTimeMaximum) : string.Empty,
											tracerouteResult.SuccessCount.ToString(),
											tracerouteResult.ErrorCount.ToString(),
											(tracerouteResult.SuccessCount + tracerouteResult.ErrorCount).ToString()
										});
											// Set the item image.
											item.ImageKey = ControlTraceroute.GetItemImageKey(tracerouteResult);
											// Add the list view item.
											this.listViewRoute.Items.Add(item);
										}
									});
							}
							catch (Exception exception)
							{
								// Log the result.
								this.log.Add(this.config.Api.Log(
									LogEventLevel.Important,
									LogEventType.Error,
									"An error ocurred during an Internet traceroute to \'{0}\'. {1}",
									new object[] { destination, exception.Message },
									exception));
							}
							finally
							{
								// If the traceroute has completed.
								if (result.IsCompleted)
								{
									if (isCanceled)
									{
										// Update the status label.
										this.status.Send(ApplicationStatus.StatusType.Normal, "Internet traceroute to \'{0}\' was canceled.".FormatWith(destination), Resources.Success_16);
										// Show a message.
										this.ShowMessage(
											Resources.GlobeCanceled_48,
											"Internet Traceroute",
											"Internet traceroute to \'{0}\' was canceled.".FormatWith(destination),
											false,
											(int)CrawlerConfig.Static.ConsoleMessageCloseDelay.TotalMilliseconds,
											(object[] parameters) =>
											{
												// Change the controls state.
												this.OnEnableControls();
												// Change the buttons state.
												this.buttonStart.Enabled = true;
												this.buttonStop.Enabled = false;
											});
										// Log the result.
										this.log.Add(this.config.Api.Log(
											LogEventLevel.Verbose,
											LogEventType.Canceled,
											"Internet traceroute to \'{0}\' was canceled.",
											new object[] { destination }));
									}
									else
									{
										// Update the status label.
										this.status.Send(ApplicationStatus.StatusType.Normal, "Internet traceroute to \'{0}\' completed successfully.".FormatWith(destination), Resources.Success_16);
										// Show a message.
										this.ShowMessage(
											Resources.GlobeSuccess_48,
											"Internet Traceroute",
											"Internet traceroute to \'{0}\' completed successfully.".FormatWith(destination),
											false,
											(int)CrawlerConfig.Static.ConsoleMessageCloseDelay.TotalMilliseconds,
											(object[] parameters) =>
											{
												// Change the controls state.
												this.OnEnableControls();
												// Change the buttons state.
												this.buttonStart.Enabled = true;
												this.buttonStop.Enabled = false;
											});
										// Log the result.
										this.log.Add(this.config.Api.Log(
											LogEventLevel.Verbose,
											LogEventType.Success,
											"Internet traceroute to \'{0}\' completed successfully.",
											new object[] { destination }));
									}
								}
							}
						}, null);
				}
			}
			catch (Exception exception)
			{
				// Update the status label.
				this.status.Send(ApplicationStatus.StatusType.Normal, "Running Internet traceroute to \'{0}\' failed.".FormatWith(destination), Resources.Error_16);
				// Show a message.
				this.ShowMessage(
					Resources.GlobeError_48,
					"Internet Traceroute",
					"Running Internet traceroute to \'{0}\' failed. {1}".FormatWith(destination, exception.Message),
					false,
					(int)CrawlerConfig.Static.ConsoleMessageCloseDelay.TotalMilliseconds);
				// Log the result.
				this.log.Add(this.config.Api.Log(
					LogEventLevel.Important,
					LogEventType.Error,
					"Running Internet traceroute to \'{0}\' failed. {1}",
					new object[] { destination, exception.Message },
					exception));
				// Change the controls state.
				this.OnEnableControls();
				// Change the buttons state.
				this.buttonStart.Enabled = true;
				this.buttonStop.Enabled = false;
			}
		}

		/// <summary>
		/// Returns the item image key for the specified traceroute result.
		/// </summary>
		/// <param name="result">The traceroute result.</param>
		/// <returns>The image key.</returns>
		private static string GetItemImageKey(TracerouteResult result)
		{
			if (result.SuccessCount > 0)
			{
				if (result.ErrorCount > 0) return "SuccessWarning";
				else return "Success";
			}
			else return "Error";
		}
	}
}
