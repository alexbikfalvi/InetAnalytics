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
//using System.Linq;
//using System.Net;
//using System.Net.Sockets;
//using System.Threading;
//using System.Windows.Forms;
//using DotNetApi;
using DotNetApi.Web;
using DotNetApi.Windows.Controls;
//using InetCrawler.Log;
using InetCrawler.Tools;
using InetCrawler.Status;
using InetTools.Tools.Mercury;

namespace InetTools.Controls
{
	/// <summary>
	/// A class representing the control for the Mercury client tool.
	/// </summary>
	public partial class ControlMercuryClient : NotificationControl
	{
		private readonly IToolApi api;
		private readonly MercuryConfig config;

		private readonly CrawlerStatusHandler status = null;
		
		private readonly object sync = new object();

		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		/// <param name="api">The tools API.</param>
		/// <param name="config">The configuration.</param>
		public ControlMercuryClient(IToolApi api, MercuryConfig config)
		{
			// Initialize the component.
			this.InitializeComponent();
			
			// Set the API.
			this.api = api;

			// Set the configuration.
			this.config = config;

			// Load the configuration.
			this.OnLoadConfiguration();

			// Set the status.
			this.status = this.api.Status.GetHandler(this);
			this.status.Send(CrawlerStatus.StatusType.Normal, "Ready.", Properties.Resources.Information_16);
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
			this.textBoxUrl.Text = this.config.ServerUrl;
		}

		/// <summary>
		/// Saves the tool configuration.
		/// </summary>
		private void OnSaveConfiguration()
		{
			this.config.ServerUrl = this.textBoxUrl.Text;
		}

		/// <summary>
		/// An event handler called when the user clicks on the start button.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnStart(object sender, EventArgs e)
		{
			//// Call the request started event handler.
			//this.OnRequestStarted();

			//// Save the server URL.
			//this.config.ServerUrl = this.textBoxUrl.Text;

			//// Set the status.
			//this.status.Send(CrawlerStatus.StatusType.Busy, "Requesting the CDN Finder data...", Properties.Resources.Busy_16);
			//// Show a message.
			//this.ShowMessage(
			//	Properties.Resources.GlobeClock_48,
			//	"CDN Finder Request",
			//	"Requesting the CDN Finder data...");
			//// Log the events.
			//this.controlLog.Add(this.api.Log(
			//	LogEventLevel.Verbose,
			//	LogEventType.Information,
			//	"Started a request for the CDN Finder data."
			//	));

			//// Compute the server URI.
			//Uri uri = new Uri(this.textBoxUrl.Text);

			//lock (this.sync)
			//{
			//	// Compute the list of sites.
			//	SiteInfo[] sites = new SiteInfo[this.listViewSites.Items.Count];
			//	for (int index = 0; index < this.listViewSites.Items.Count; index++)
			//	{
			//		// Get the site information.
			//		sites[index] = this.listViewSites.Items[index].Tag as SiteInfo;
			//	}

			//	// Create a new cancellation token.
			//	this.asyncCancel = new CancellationTokenSource();

			//	// Get the cancellation token.
			//	CancellationToken cancelToken = this.asyncCancel.Token;

			//	// Execute the request on the thread pool.
			//	ThreadPool.QueueUserWorkItem((object state) =>
			//	{
			//		// Get the list of subdomains.
			//		string[] subdomains = this.config.Subdomains;

			//		// Compute the site names.
			//		foreach (SiteInfo site in sites)
			//		{
			//			// If the operation has been canceled.
			//			if (cancelToken.IsCancellationRequested)
			//			{
			//				// Dispose of the cancellation token.
			//				lock (this.sync)
			//				{
			//					this.asyncCancel.Dispose();
			//					this.asyncCancel = null;
			//				}
			//				// Update the status label.
			//				this.status.Send(CrawlerStatus.StatusType.Normal, "Requesting the CDN Finder data was canceled.", Properties.Resources.Canceled_16);
			//				// Show a message.
			//				this.ShowMessage(
			//					Properties.Resources.GlobeCanceled_48,
			//					"CDN Finder Request",
			//					"Requesting the CDN Finder data was canceled.",
			//					false,
			//					(int)this.api.Config.MessageCloseDelay.TotalMilliseconds,
			//					(object[] parameters) =>
			//					{
			//						// Call the request finished event handler.
			//						this.OnRequestFinished();
			//					});
			//				// Log the events.
			//				this.controlLog.Add(this.api.Log(
			//					LogEventLevel.Normal,
			//					LogEventType.Canceled,
			//					"Requesting the CDN Finder data was canceled."
			//					));
			//				// Exit the work item.
			//				return;
			//			}

			//			// Set the hostname to the initial name.
			//			string hostname = site.SiteName;
			//			// Set the flag on whether the hostname was found.
			//			bool found = false;
			//			// The prefix index.
			//			int index = 0;

			//			// Set the site URL to empty.
			//			site.SiteUrl = string.Empty;

			//			// Loop until a hostname is found or the list of subdomains is exhaused.
			//			do
			//			{
			//				try
			//				{
			//					// Check the hostname has an IP address.
			//					if (Dns.GetHostAddresses(hostname).Length > 0)
			//					{
			//						// Set the found flag to true.
			//						found = true;
			//					}
			//					else if (index < subdomains.Length)
			//					{
			//						// Use the next subdomain.
			//						hostname = "{0}.{1}".FormatWith(subdomains[index], site.SiteName);
			//					}
			//				}
			//				catch
			//				{
			//					if (index < subdomains.Length)
			//					{
			//						// Use the next subdomain.
			//						hostname = "{0}.{1}".FormatWith(subdomains[index], site.SiteName);
			//					}
			//				}
			//			}
			//			while ((!found) && ((++index) <= subdomains.Length));

			//			// If found.
			//			if (found)
			//			{
			//				// Set the site URL.
			//				site.SiteUrl = @"{0}://{1}/".FormatWith(this.config.Protocol, hostname);
			//			}
			//			// Update the site information.
			//			this.Invoke(() =>
			//			{
			//				// Get the list view item corresponding to this site.
			//				ListViewItem item = this.listViewSites.Items.FirstOrDefault((ListViewItem it) =>
			//				{
			//					// Return true if the item has the same site information.
			//					return object.ReferenceEquals(it.Tag, site);
			//				});

			//				// If the item is not null.
			//				if (null != item)
			//				{
			//					// Update the site information.
			//					item.SubItems[2].Text = found ? site.SiteUrl : "(non-existing domain)";
			//					item.ImageKey = found ? "GlobeQuestion" : "GlobeError";
			//				}
			//			});
			//		}

			//		try
			//		{
			//			lock (this.sync)
			//			{
			//				// Dispose of the cancellation token.
			//				this.asyncCancel.Dispose();
			//				this.asyncCancel = null;

			//				// Begin the request.
			//				this.asyncResult = this.request.Begin(uri, sites, this.OnCallback);
			//			}
			//		}
			//		catch (Exception exception)
			//		{
			//			// Update the status label.
			//			this.status.Send(CrawlerStatus.StatusType.Normal, "Requesting the CDN Finder data failed. {0}".FormatWith(exception.Message), Properties.Resources.Error_16);
			//			// Show a message.
			//			this.ShowMessage(
			//				Properties.Resources.GlobeError_48,
			//				"CDN Finder Request",
			//				"Requesting the CDN Finder data failed.{0}{1}".FormatWith(Environment.NewLine, exception.Message),
			//				false,
			//				(int)this.api.Config.MessageCloseDelay.TotalMilliseconds,
			//				(object[] parameters) =>
			//				{
			//					// Call the request finished event handler.
			//					this.OnRequestFinished();
			//				});
			//			// Log the events.
			//			this.controlLog.Add(this.api.Log(
			//				LogEventLevel.Important,
			//				LogEventType.Error,
			//				"Requesting the CDN Finder data failed. {0}",
			//				new object[] { exception.Message },
			//				exception
			//				));
			//		}
			//	});
			//}
		}

		/// <summary>
		/// A method called when receiving the web response.
		/// </summary>
		/// <param name="result">The result of the asynchronous operation.</param>
		private void OnCallback(AsyncWebResult result)
		{
			//// Set the result to null.
			//lock (this.sync)
			//{
			//	this.asyncResult = null;
			//}

			//try
			//{
			//	// Complete the request.
			//	CdnFinderSites sites = this.request.End(result);
			//	// Update the status label.
			//	this.status.Send(
			//		CrawlerStatus.StatusType.Normal,
			//		"Requesting the CDN Finder data completed successfully.",
			//		"{0} web sites received.".FormatWith(sites.Count),
			//		Properties.Resources.Success_16);
			//	// Show a message.
			//	this.ShowMessage(
			//		Properties.Resources.GlobeSuccess_48,
			//		"CDN Finder Request",
			//		"Requesting the CDN Finder data completed successfully.",
			//		false,
			//		(int)this.api.Config.MessageCloseDelay.TotalMilliseconds,
			//		(object[] parameters) =>
			//		{
			//			// Call the request finished event handler.
			//			this.OnRequestFinished();
			//			// Update the site information.
			//			this.OnUpdateDomains(sites);
			//		});
			//	// Log the events.
			//	this.controlLog.Add(this.api.Log(
			//		LogEventLevel.Verbose,
			//		LogEventType.Success,
			//		"Requesting the CDN Finder data completed successfully."
			//		));
			//}
			//catch (WebException exception)
			//{
			//	if (exception.Status == WebExceptionStatus.RequestCanceled)
			//	{
			//		// Update the status label.
			//		this.status.Send(CrawlerStatus.StatusType.Normal, "Requesting the CDN Finder data was canceled.", Properties.Resources.Canceled_16);
			//		// Show a message.
			//		this.ShowMessage(
			//			Properties.Resources.GlobeCanceled_48,
			//			"CDN Finder Request",
			//			"Requesting the CDN Finder data was canceled.",
			//			false,
			//			(int)this.api.Config.MessageCloseDelay.TotalMilliseconds,
			//			(object[] parameters) =>
			//			{
			//				// Call the request finished event handler.
			//				this.OnRequestFinished();
			//			});
			//		// Log the events.
			//		this.controlLog.Add(this.api.Log(
			//			LogEventLevel.Normal,
			//			LogEventType.Canceled,
			//			"Requesting the CDN Finder data was canceled."
			//			));
			//	}
			//	else
			//	{
			//		// Update the status label.
			//		this.status.Send(CrawlerStatus.StatusType.Normal, "Requesting the CDN Finder data failed. {0}".FormatWith(exception.Message), Properties.Resources.Error_16);
			//		// Show a message.
			//		this.ShowMessage(
			//			Properties.Resources.GlobeError_48,
			//			"CDN Finder Request",
			//			"Requesting the CDN Finder data failed.{0}{1}".FormatWith(Environment.NewLine, exception.Message),
			//			false,
			//			(int)this.api.Config.MessageCloseDelay.TotalMilliseconds,
			//			(object[] parameters) =>
			//			{
			//				// Call the request finished event handler.
			//				this.OnRequestFinished();
			//			});
			//		// Log the events.
			//		this.controlLog.Add(this.api.Log(
			//			LogEventLevel.Important,
			//			LogEventType.Error,
			//			"Requesting the CDN Finder data failed. {0}",
			//			new object[] { exception.Message },
			//			exception
			//			));
			//	}
			//}
			//catch (Exception exception)
			//{
			//	// Update the status label.
			//	this.status.Send(CrawlerStatus.StatusType.Normal, "Requesting the CDN Finder data failed. {0}".FormatWith(exception.Message), Properties.Resources.Error_16);
			//	// Show a message.
			//	this.ShowMessage(
			//		Properties.Resources.GlobeError_48,
			//		"CDN Finder Request",
			//		"Requesting the CDN Finder data failed.{0}{1}".FormatWith(Environment.NewLine, exception.Message),
			//		false,
			//		(int)this.api.Config.MessageCloseDelay.TotalMilliseconds,
			//		(object[] parameters) =>
			//		{
			//			// Call the request finished event handler.
			//			this.OnRequestFinished();
			//		});
			//	// Log the events.
			//	this.controlLog.Add(this.api.Log(
			//		LogEventLevel.Important,
			//		LogEventType.Error,
			//		"Requesting the CDN Finder data failed. {0}",
			//		new object[] { exception.Message },
			//		exception
			//		));
			//}
		}

		/// <summary>
		/// An event handler called when the user clicks on the stop button.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnStop(object sender, EventArgs e)
		{
			//// Set the controls enabled state.
			//this.buttonCancel.Enabled = false;

			//lock (this.sync)
			//{
			//	// If the cancellation token is not null.
			//	if (null != this.asyncCancel)
			//	{
			//		// Cancel the asynchronous operation.
			//		this.asyncCancel.Cancel();
			//	}
			//	// If the request result is not null.
			//	if (null != this.asyncResult)
			//	{
			//		// Cancel the asynchronous operation.
			//		this.request.Cancel(this.asyncResult);
			//		// Set the result to null.
			//		this.asyncResult = null;
			//	}
			//}
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
	}
}
