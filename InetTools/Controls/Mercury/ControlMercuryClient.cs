/* 
 * Copyright (C) 2013 Alex Bikfalvi
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
using System.Net;
using System.Windows.Forms;
using DotNetApi;
using DotNetApi.Web;
using DotNetApi.Windows.Controls;
using InetAnalytics;
using InetCrawler.Log;
using InetCrawler.Tools;
using InetCrawler.Status;
using InetTools.Forms;
using InetTools.Tools.Mercury;

namespace InetTools.Controls.Mercury
{
	/// <summary>
	/// A class representing the control for the Mercury client tool.
	/// </summary>
	public partial class ControlMercuryClient : NotificationControl
	{
		private readonly MercuryConfig config;

		private readonly CrawlerStatusHandler status = null;

		private readonly MercuryRequest request = new MercuryRequest();
		private IAsyncResult result = null;

		private readonly FormMercuryClientSettings formSettings = new FormMercuryClientSettings();

		private readonly object sync = new object();

		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		/// <param name="config">The configuration.</param>
		public ControlMercuryClient(MercuryConfig config)
		{
			// Initialize the component.
			this.InitializeComponent();
			
			// Set the configuration.
			this.config = config;

			// Load the configuration.
			this.OnLoadConfiguration();

			// Set the status.
			this.status = this.config.Api.Status.GetHandler(this);
			this.status.Send(CrawlerStatus.StatusType.Normal, "Ready.", Resources.Information_16);
		}

		// Private methods.

		/// <summary>
		/// An event handler called when a request has started.
		/// </summary>
		private void OnRequestStarted()
		{
			// Set the controls enabled state.
			this.buttonUpload.Enabled = false;
			this.buttonCancel.Enabled = true;
			this.textBoxUrl.Enabled = false;
			this.codeTextBox.Enabled = false;
		}

		/// <summary>
		/// An event handler called when a request has finished.
		/// </summary>
		private void OnRequestFinished()
		{
			// Set the controls enabled state.
			this.buttonUpload.Enabled = true;
			this.buttonCancel.Enabled = false;
			this.textBoxUrl.Enabled = true;
			this.codeTextBox.Enabled = true;
		}

		/// <summary>
		/// Loads the tool configuration.
		/// </summary>
		private void OnLoadConfiguration()
		{
			this.textBoxUrl.Text = this.config.UploadTracerouteUrl;
		}

		/// <summary>
		/// Saves the tool configuration.
		/// </summary>
		private void OnSaveConfiguration()
		{
			this.config.UploadTracerouteUrl = this.textBoxUrl.Text;
		}

		/// <summary>
		/// An event handler called when the user clicks on the start button.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnStart(object sender, EventArgs e)
		{
			// Check there is no pending request.
			lock (this.sync)
			{
				if (null != this.result)
				{
					// Show an error message.
					MessageBox.Show(this, "There is another Mercury request in progress. Wait for the current request to complete, and try again.", "Mercury Request", MessageBoxButtons.OK, MessageBoxIcon.Error);
					// Return.
					return;
				}
			}

			// The Mercury traceroute.
			MercuryTraceroute traceroute;

			try
			{
				// Try and parse the traceroute.
				traceroute = new MercuryTraceroute(Guid.Empty, null, IPAddress.Parse("0.0.0.0"), this.codeTextBox.Text);

				// Set the traceroute.
				this.controlTraceroute.Set(traceroute);
			}
			catch (Exception exception)
			{
				// Show an error message.
				MessageBox.Show(this, "An error occurred while parsing the traceroute data. {0}".FormatWith(exception.Message), "Invalid Traceroute Format", MessageBoxButtons.OK, MessageBoxIcon.Error);
				// Return.
				return;
			}

			// Save the server URL.
			this.config.UploadTracerouteUrl = this.textBoxUrl.Text;

			// Call the request started event handler.
			this.OnRequestStarted();

			// Set the status.
			this.status.Send(CrawlerStatus.StatusType.Busy, "Uploading the traceroute to the Mercury server...", Resources.Busy_16);
			// Show a message.
			this.ShowMessage(
				Resources.GlobeClock_48,
				"Mercury Server Request",
				"Uploading the traceroute to the Mercury server...");
			// Log the events.
			this.controlLog.Add(this.config.Api.Log(
				LogEventLevel.Verbose,
				LogEventType.Information,
				@"Uploading the traceroute to the Mercury server '{0}'.",
				new object[] { this.config.UploadTracerouteUrl }
				));

			// Compute the server URI.
			Uri uri = new Uri(this.textBoxUrl.Text);

			try
			{
				lock (this.sync)
				{
					// Begin the request.
					this.result = this.request.BeginUploadTraceroute(uri, traceroute, this.OnCallback);
				}
			}
			catch (Exception exception)
			{
				// Update the status label.
				this.status.Send(CrawlerStatus.StatusType.Normal, "Uploading the traceroute to the Mercury server failed. {0}".FormatWith(exception.Message), Resources.Error_16);
				// Show a message.
				this.ShowMessage(
					Resources.GlobeError_48,
					"Mercury Server Request",
					"Uploading the traceroute to the Mercury server failed.{0}{1}".FormatWith(Environment.NewLine, exception.Message),
					false,
					(int)this.config.Api.Config.MessageCloseDelay.TotalMilliseconds,
					(object[] parameters) =>
					{
						// Call the request finished event handler.
						this.OnRequestFinished();
					});
				// Log the events.
				this.controlLog.Add(this.config.Api.Log(
					LogEventLevel.Important,
					LogEventType.Error,
					@"Uploading the traceroute to the Mercury server '{0}' failed. {1}",
					new object[] { this.config.UploadTracerouteUrl, exception.Message },
					exception
					));
			}
		}

		/// <summary>
		/// A method called when receiving the web response.
		/// </summary>
		/// <param name="result">The result of the asynchronous operation.</param>
		private void OnCallback(AsyncWebResult result)
		{
			// Set the result to null.
			lock (this.sync)
			{
				this.result = null;
			}

			try
			{
				// Complete the request.
				this.request.End(result);
				// Update the status label.
				this.status.Send(
					CrawlerStatus.StatusType.Normal,
					"Uploading the traceroute to the Mercury server completed successfully.",
					Resources.Success_16);
				// Show a message.
				this.ShowMessage(
					Resources.GlobeSuccess_48,
					"Mercury Server Request",
					"Uploading the traceroute to the Mercury server successfully.",
					false,
					(int)this.config.Api.Config.MessageCloseDelay.TotalMilliseconds,
					(object[] parameters) =>
					{
						// Call the request finished event handler.
						this.OnRequestFinished();
					});
				// Log the events.
				this.controlLog.Add(this.config.Api.Log(
					LogEventLevel.Verbose,
					LogEventType.Success,
					@"Uploading the traceroute to the Mercury server '{0}' completed successfully.",
					new object[] {  this.config.UploadTracerouteUrl }
					));
			}
			catch (WebException exception)
			{
				if (exception.Status == WebExceptionStatus.RequestCanceled)
				{
					// Update the status label.
					this.status.Send(CrawlerStatus.StatusType.Normal, "Uploading the traceroute to the Mercury server was canceled.", Resources.Canceled_16);
					// Show a message.
					this.ShowMessage(
						Resources.GlobeCanceled_48,
						"Mercury Server Request",
						"Uploading the traceroute to the Mercury server was canceled.",
						false,
						(int)this.config.Api.Config.MessageCloseDelay.TotalMilliseconds,
						(object[] parameters) =>
						{
							// Call the request finished event handler.
							this.OnRequestFinished();
						});
					// Log the events.
					this.controlLog.Add(this.config.Api.Log(
						LogEventLevel.Normal,
						LogEventType.Canceled,
						@"Uploading the traceroute to the Mercury server '{0}' was canceled.",
						new object[] { this.config.UploadTracerouteUrl }
						));
				}
				else
				{
					// Update the status label.
					this.status.Send(CrawlerStatus.StatusType.Normal, "Uploading the traceroute to the Mercury server failed. {0}".FormatWith(exception.Message), Resources.Error_16);
					// Show a message.
					this.ShowMessage(
						Resources.GlobeError_48,
						"Mercury Server Request",
						"Uploading the traceroute to the Mercury server failed.{0}{1}".FormatWith(Environment.NewLine, exception.Message),
						false,
						(int)this.config.Api.Config.MessageCloseDelay.TotalMilliseconds,
						(object[] parameters) =>
						{
							// Call the request finished event handler.
							this.OnRequestFinished();
						});
					// Log the events.
					this.controlLog.Add(this.config.Api.Log(
						LogEventLevel.Important,
						LogEventType.Error,
						@"Uploading the traceroute to the Mercury server '{0}' failed. {1}",
						new object[] { this.config.UploadTracerouteUrl, exception.Message },
						exception
						));
				}
			}
			catch (Exception exception)
			{
				// Update the status label.
				this.status.Send(CrawlerStatus.StatusType.Normal, "Uploading the traceroute to the Mercury server failed. {0}".FormatWith(exception.Message), Resources.Error_16);
				// Show a message.
				this.ShowMessage(
					Resources.GlobeError_48,
					"Mercury Server Request",
					"Uploading the traceroute to the Mercury server failed.{0}{1}".FormatWith(Environment.NewLine, exception.Message),
					false,
					(int)this.config.Api.Config.MessageCloseDelay.TotalMilliseconds,
					(object[] parameters) =>
					{
						// Call the request finished event handler.
						this.OnRequestFinished();
					});
				// Log the events.
				this.controlLog.Add(this.config.Api.Log(
					LogEventLevel.Important,
					LogEventType.Error,
					@"Uploading the traceroute to the Mercury server '{0}' failed. {0}",
					new object[] { this.config.UploadTracerouteUrl, exception.Message },
					exception
					));
			}
		}

		/// <summary>
		/// An event handler called when the user clicks on the stop button.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnStop(object sender, EventArgs e)
		{
			// Set the controls enabled state.
			this.buttonCancel.Enabled = false;

			lock (this.sync)
			{
				// If the request result is not null.
				if (null != this.result)
				{
					// Cancel the asynchronous operation.
					this.request.Cancel(this.result);
					// Set the result to null.
					this.result = null;
				}
			}
		}

		/// <summary>
		/// An event handler called when the input has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnInputChanged(object sender, EventArgs e)
		{
			// Changed the enabled state of the start button.
			this.buttonUpload.Enabled = (!string.IsNullOrWhiteSpace(this.textBoxUrl.Text)) && (!string.IsNullOrWhiteSpace(this.codeTextBox.Text));
		}


		/// <summary>
		/// An event handler called when the user clicks on the settings button.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSettingsClick(object sender, EventArgs e)
		{
			// Show the settings dialog.
			if (this.formSettings.ShowDialog(this, this.config) == DialogResult.OK)
			{
				// Upload the configuration.
				this.textBoxUrl.Text = this.config.UploadTracerouteUrl;
			}
		}
	}
}
