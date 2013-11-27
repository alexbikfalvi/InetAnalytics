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
using System.Linq;
using System.Windows.Forms;
using DotNetApi;
using DotNetApi.Web;
using DotNetApi.Windows.Controls;
using InetCrawler.Log;
using InetCrawler.Tools;
using InetCrawler.Status;
using InetTools.Forms;
using InetTools.Tools.Alexa;
using InetTools.Tools.CdnFinder;

namespace InetTools.Controls
{
	/// <summary>
	/// A class representing the control for the CDN finder tool.
	/// </summary>
	public partial class ControlCdnFinder : NotificationControl
	{
		private readonly IToolApi api;
		private readonly CdnFinderConfig config;

		private readonly CrawlerStatusHandler status = null;
		
		private readonly object sync = new object();

		private readonly CdnFinderRequest request;
		private IAsyncResult result = null;

		private CdnFinderDomains domains = null;

		private readonly FormCdnFinderSettings formSettings = new FormCdnFinderSettings();

		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		/// <param name="api">The tools API.</param>
		/// <param name="config">The configuration.</param>
		public ControlCdnFinder(IToolApi api, CdnFinderConfig config)
		{
			// Initialize the component.
			this.InitializeComponent();
			
			// Set the API.
			this.api = api;

			// Set the configuration.
			this.config = config;

			// Set the status.
			this.status = this.api.Status.GetHandler(this);
			this.status.Send(CrawlerStatus.StatusType.Normal, "Ready.", Properties.Resources.Information_16);

			// Create the request.
			this.request = new CdnFinderRequest(this.config);

			// Load the configuration.
			this.textBoxUrl.Text = this.config.ServerUrl;
		}

		// Private methods.

		/// <summary>
		/// An event handler called when a request has started.
		/// </summary>
		private void OnRequestStarted()
		{
			// Set the controls enabled state.
			this.buttonStart.Enabled = false;
			this.buttonStop.Enabled = true;
			this.buttonOpen.Enabled = false;
			this.buttonSettings.Enabled = false;
			this.textBoxUrl.Enabled = false;
		}

		/// <summary>
		/// An event handler called when a request has finished.
		/// </summary>
		private void OnRequestFinished()
		{
			// Set the controls enabled state.
			this.buttonStart.Enabled = true;
			this.buttonStop.Enabled = false;
			this.buttonOpen.Enabled = true;
			this.buttonSettings.Enabled = true;
			this.textBoxUrl.Enabled = true;
		}

		/// <summary>
		/// An event handler called when the user clicks on the start button.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnStart(object sender, EventArgs e)
		{
			// Call the request started event handler.
			this.OnRequestStarted();

			// Save the server URL.
			this.config.ServerUrl = this.textBoxUrl.Text;

			try
			{
				lock (this.sync)
				{
					// Compute the server URI.
					Uri uri = new Uri(this.textBoxUrl.Text);
					// Compute the list of domains.
					string[] domains = new string[this.listView.Items.Count];
					for (int index = 0; index < this.listView.Items.Count; index++)
					{
						domains[index] = this.listView.Items[index].Tag as string;
					}
					// Begin the request.
					this.result = this.request.Begin(uri, domains, this.OnCallback);
				}

				// Set the status.
				this.status.Send(CrawlerStatus.StatusType.Busy, "Requesting the CDN Finder data...", Properties.Resources.Busy_16);
				// Show a message.
				this.ShowMessage(
					Properties.Resources.GlobeClock_48,
					"CDN Finder Request",
					"Requesting the CDN Finder data...");
				// Log the events.
				this.controlLog.Add(this.api.Log(
					LogEventLevel.Verbose,
					LogEventType.Information,
					"Started a request for the CDN Finder data."
					));
			}
			catch (Exception exception)
			{
				// Call the request finished event handler.
				this.OnRequestFinished();
				// Update the status label.
				this.status.Send(CrawlerStatus.StatusType.Normal, "Requesting the CDN Finder data failed. {0}".FormatWith(exception.Message), Properties.Resources.Error_16);
				// Show a message.
				this.ShowMessage(
					Properties.Resources.GlobeError_48,
					"CDN Finder Request",
					"Requesting the CDN Finder data failed.{0}{1}".FormatWith(Environment.NewLine, exception.Message),
					false,
					(int)this.api.Config.MessageCloseDelay.TotalMilliseconds);
				// Log the events.
				this.controlLog.Add(this.api.Log(
					LogEventLevel.Important,
					LogEventType.Error,
					"Requesting the CDN Finder data failed. {0}",
					new object[] { exception.Message },
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
				CdnFinderDomains domains = this.request.End(result);
				// Update the status label.
				this.status.Send(
					CrawlerStatus.StatusType.Normal,
					"Requesting the CDN Finder data completed successfully.",
					"{0} web domains received.".FormatWith(domains.Count),
					Properties.Resources.Success_16);
				// Show a message.
				this.ShowMessage(
					Properties.Resources.GlobeSuccess_48,
					"CDN Finder Request",
					"Requesting the CDN Finder data completed successfully.",
					false,
					(int)this.api.Config.MessageCloseDelay.TotalMilliseconds,
					(object[] parameters) =>
					{
						// Call the request finished event handler.
						this.OnRequestFinished();
						// Update the domain information.
						this.OnUpdateDomains(domains);
					});
				// Log the events.
				this.controlLog.Add(this.api.Log(
					LogEventLevel.Verbose,
					LogEventType.Success,
					"Requesting the CDN Finder data completed successfully."
					));
			}
			catch (WebException exception)
			{
				if (exception.Status == WebExceptionStatus.RequestCanceled)
				{
					// Update the status label.
					this.status.Send(CrawlerStatus.StatusType.Normal, "Requesting the CDN Finder data was canceled.".FormatWith(exception.Message), Properties.Resources.Canceled_16);
					// Show a message.
					this.ShowMessage(
						Properties.Resources.GlobeCanceled_48,
						"CDN Finder Request",
						"Requesting the CDN Finder data was canceled.",
						false,
						(int)this.api.Config.MessageCloseDelay.TotalMilliseconds,
						(object[] parameters) =>
						{
							// Call the request finished event handler.
							this.OnRequestFinished();
						});
					// Log the events.
					this.controlLog.Add(this.api.Log(
						LogEventLevel.Normal,
						LogEventType.Canceled,
						"Requesting the CDN Finder data was canceled."
						));
				}
				else
				{
					// Update the status label.
					this.status.Send(CrawlerStatus.StatusType.Normal, "Requesting the CDN Finder data failed. {0}".FormatWith(exception.Message), Properties.Resources.Error_16);
					// Show a message.
					this.ShowMessage(
						Properties.Resources.GlobeError_48,
						"CDN Finder Request",
						"Requesting the CDN Finder data failed.{0}{1}".FormatWith(Environment.NewLine, exception.Message),
						false,
						(int)this.api.Config.MessageCloseDelay.TotalMilliseconds,
						(object[] parameters) =>
						{
							// Call the request finished event handler.
							this.OnRequestFinished();
						});
					// Log the events.
					this.controlLog.Add(this.api.Log(
						LogEventLevel.Important,
						LogEventType.Error,
						"Requesting the CDN Finder data failed. {0}",
						new object[] { exception.Message },
						exception
						));
				}
			}
			catch (Exception exception)
			{
				// Update the status label.
				this.status.Send(CrawlerStatus.StatusType.Normal, "Requesting the CDN Finder data failed. {0}".FormatWith(exception.Message), Properties.Resources.Error_16);
				// Show a message.
				this.ShowMessage(
					Properties.Resources.GlobeError_48,
					"CDN Finder Request",
					"Requesting the CDN Finder data failed.{0}{1}".FormatWith(Environment.NewLine, exception.Message),
					false,
					(int)this.api.Config.MessageCloseDelay.TotalMilliseconds,
					(object[] parameters) =>
					{
						// Call the request finished event handler.
						this.OnRequestFinished();
					});
				// Log the events.
				this.controlLog.Add(this.api.Log(
					LogEventLevel.Important,
					LogEventType.Error,
					"Requesting the CDN Finder data failed. {0}",
					new object[] { exception.Message },
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
			this.buttonStop.Enabled = false;

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
		/// An event handler called when reading data from an Alexa ranking.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnOpen(object sender, EventArgs e)
		{
			// Imports a list of domains from the specified Alexa ranking file.
			if (this.openFileDialog.ShowDialog(this) == DialogResult.OK)
			{
				// Check the filter index.
				switch (this.openFileDialog.FilterIndex)
				{
					case 1:
						this.OnOpenAlexaRankingFile(this.openFileDialog.FileName);
						break;
				}
			}
		}

		/// <summary>
		/// Opens the specified Alexa ranking XML file.
		/// </summary>
		/// <param name="fileName">The file name.</param>
		private void OnOpenAlexaRankingFile(string fileName)
		{
			try
			{
				// Open the Alexa ranking file.
				AlexaRanking ranking = AlexaRanking.Load(fileName);

				// Update the domains list.
				lock (this.sync)
				{
					// Clear the sites list.
					this.listView.Items.Clear();
					// Updates the sites list.
					foreach (AlexaRank rank in ranking)
					{
						// Create the site item.
						ListViewItem item = new ListViewItem(new string[] { rank.Site, "N/A" });
						item.ImageKey = "Globe";
						item.Tag = @"http://{0}/".FormatWith(rank.Site);
						this.listView.Items.Add(item);
					}
				}

				// Call the input changed event handler.
				this.OnInputChanged(this, EventArgs.Empty);
			}
			catch (Exception exception)
			{
				// Show an error message.
				MessageBox.Show(this,
					"An error occurred while opening the Alexa ranking file. The file is inaccessible or has the wrong format.{0}{1}".FormatWith(Environment.NewLine, exception.Message),
					"Open Alexa Ranking",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
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
			this.buttonStart.Enabled = (!string.IsNullOrWhiteSpace(this.textBoxUrl.Text)) && (this.listView.Items.Count > 0);
		}

		/// <summary>
		/// An event handler called when the user clicks on the settings button.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSettingsClick(object sender, EventArgs e)
		{
			// Show the settings dialog.
			this.formSettings.ShowDialog(this, this.config);
		}

		/// <summary>
		/// Updates the list of domains with the specified results.
		/// </summary>
		/// <param name="domains">The domains.</param>
		private void OnUpdateDomains(CdnFinderDomains domains)
		{
			lock (this.sync)
			{
				// Set the current domains.
				this.domains = domains;

				// Update the list view items.
				foreach (ListViewItem item in this.listView.Items)
				{
					// Get the domain information.
					CdnFinderDomain domain = domains.Where((CdnFinderDomain dom) =>
						{
							return dom.Domain == item.Tag as string;
						}).FirstOrDefault();
					// If the domain is null.
					if (null == domain)
					{
						item.ImageKey = "GlobeError";
						item.SubItems[1].Text = "N/A";
					}
					else if (domain.Success)
					{
						item.ImageKey = "GlobeSuccess";
						item.SubItems[1].Text = domain.Resources.Count.ToString();
					}
					else
					{
						item.ImageKey = "GlobeWarning";
						item.SubItems[1].Text = "N/A";
					}
				}
			}
		}
	}
}
