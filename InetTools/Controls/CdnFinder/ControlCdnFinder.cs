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
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Linq;
using DotNetApi;
using DotNetApi.Web;
using DotNetApi.Windows.Controls;
using InetAnalytics;
using InetCrawler.Log;
using InetCrawler.Tools;
using InetCrawler.Status;
using InetTools.Forms.CdnFinder;
using InetTools.Tools.Alexa;
using InetTools.Tools.CdnFinder;

namespace InetTools.Controls.CdnFinder
{
	/// <summary>
	/// A class representing the control for the CDN finder tool.
	/// </summary>
	public partial class ControlCdnFinder : NotificationControl
	{
		/// <summary>
		/// A structure representing the site information.
		/// </summary>
		private sealed class SiteInfo
		{
			/// <summary>
			/// Create a new site information instance.
			/// </summary>
			/// <param name="siteName">The site name.</param>
			public SiteInfo(string siteName)
			{
				this.SiteName = siteName;
			}

			// Public properties.

			/// <summary>
			/// Gets the site name.
			/// </summary>
			public string SiteName { get; private set; }
			/// <summary>
			/// Gets or sets the site URL.
			/// </summary>
			public string SiteUrl { get; set; }
			/// <summary>
			/// Gets or sets the CDN Finder site.
			/// </summary>
			public CdnFinderSite Site { get; set; }

			// Public methods.

			/// <summary>
			/// Converts the current object to a string.
			/// </summary>
			/// <returns>The string.</returns>
			public override string ToString()
			{
				return this.SiteUrl;
			}
		}

		private readonly CdnFinderConfig config;

		private readonly CrawlerStatusHandler status = null;
		
		private readonly object sync = new object();

		private readonly CdnFinderRequest request;
		private IAsyncResult asyncResult = null;
		private CancellationTokenSource asyncCancel = null;

		private CdnFinderSites sites = null;

		private readonly FormCdnFinderSettings formSettings = new FormCdnFinderSettings();

		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		/// <param name="config">The tool configuration.</param>
		public ControlCdnFinder(CdnFinderConfig config)
		{
			// Initialize the component.
			this.InitializeComponent();
			
			// Set the configuration.
			this.config = config;

			// Set the status.
			this.status = this.config.Api.Status.GetHandler(this);
			this.status.Send(CrawlerStatus.StatusType.Normal, "Ready.", Resources.Information_16);

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

			// Set the status.
			this.status.Send(CrawlerStatus.StatusType.Busy, "Requesting the CDN Finder data...", Resources.Busy_16);
			// Show a message.
			this.ShowMessage(
				Resources.GlobeClock_48,
				"CDN Finder Request",
				"Requesting the CDN Finder data...");
			// Log the events.
			this.controlLog.Add(this.config.Api.Log(
				LogEventLevel.Verbose,
				LogEventType.Information,
				"Started a request for the CDN Finder data."
				));

			// Compute the server URI.
			Uri uri = new Uri(this.textBoxUrl.Text);

			lock (this.sync)
			{
				// Compute the list of sites.
				SiteInfo[] sites = new SiteInfo[this.listViewSites.Items.Count];
				for (int index = 0; index < this.listViewSites.Items.Count; index++)
				{
					// Get the site information.
					sites[index] = this.listViewSites.Items[index].Tag as SiteInfo;
				}

				// Create a new cancellation token.
				this.asyncCancel = new CancellationTokenSource();

				// Get the cancellation token.
				CancellationToken cancelToken = this.asyncCancel.Token;

				// Execute the request on the thread pool.
				ThreadPool.QueueUserWorkItem((object state) =>
				{
					// Get the list of subdomains.
					string[] subdomains = this.config.Subdomains;

					// Compute the site names.
					foreach (SiteInfo site in sites)
					{
						// If the operation has been canceled.
						if (cancelToken.IsCancellationRequested)
						{
							// Dispose of the cancellation token.
							lock (this.sync)
							{
								this.asyncCancel.Dispose();
								this.asyncCancel = null;
							}
							// Update the status label.
							this.status.Send(CrawlerStatus.StatusType.Normal, "Requesting the CDN Finder data was canceled.", Resources.Canceled_16);
							// Show a message.
							this.ShowMessage(
								Resources.GlobeCanceled_48,
								"CDN Finder Request",
								"Requesting the CDN Finder data was canceled.",
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
								"Requesting the CDN Finder data was canceled."
								));
							// Exit the work item.
							return;
						}

						// Set the hostname to the initial name.
						string hostname = site.SiteName;
						// Set the flag on whether the hostname was found.
						bool found = false;
						// The prefix index.
						int index = 0;

						// Set the site URL to empty.
						site.SiteUrl = string.Empty;

						// Loop until a hostname is found or the list of subdomains is exhaused.
						do
						{
							try
							{
								// Check the hostname has an IP address.
								if (Dns.GetHostAddresses(hostname).Length > 0)
								{
									// Set the found flag to true.
									found = true;
								}
								else if (index < subdomains.Length)
								{
									// Use the next subdomain.
									hostname = "{0}.{1}".FormatWith(subdomains[index], site.SiteName);
								}
							}
							catch
							{
								if (index < subdomains.Length)
								{
									// Use the next subdomain.
									hostname = "{0}.{1}".FormatWith(subdomains[index], site.SiteName);
								}
							}
						}
						while ((!found) && ((++index) <= subdomains.Length));

						// If found.
						if (found)
						{
							// Set the site URL.
							site.SiteUrl = @"{0}://{1}/".FormatWith(this.config.Protocol, hostname);
						}
						// Update the site information.
						this.Invoke(() =>
						{
							// Get the list view item corresponding to this site.
							ListViewItem item = this.listViewSites.Items.FirstOrDefault((ListViewItem it) =>
							{
								// Return true if the item has the same site information.
								return object.ReferenceEquals(it.Tag, site);
							});

							// If the item is not null.
							if (null != item)
							{
								// Update the site information.
								item.SubItems[2].Text = found ? site.SiteUrl : "(non-existing domain)";
								item.ImageKey = found ? "GlobeQuestion" : "GlobeError";
							}
						});
					}

					try
					{
						lock (this.sync)
						{
							// Dispose of the cancellation token.
							this.asyncCancel.Dispose();
							this.asyncCancel = null;

							// Begin the request.
							this.asyncResult = this.request.Begin(uri, sites, this.OnCallback);
						}
					}
					catch (Exception exception)
					{
						// Update the status label.
						this.status.Send(CrawlerStatus.StatusType.Normal, "Requesting the CDN Finder data failed. {0}".FormatWith(exception.Message), Resources.Error_16);
						// Show a message.
						this.ShowMessage(
							Resources.GlobeError_48,
							"CDN Finder Request",
							"Requesting the CDN Finder data failed.{0}{1}".FormatWith(Environment.NewLine, exception.Message),
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
							"Requesting the CDN Finder data failed. {0}",
							new object[] { exception.Message },
							exception
							));
					}
				});
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
				this.asyncResult = null;
			}

			try
			{
				// Complete the request.
				CdnFinderSites sites = this.request.End(result);
				// Update the status label.
				this.status.Send(
					CrawlerStatus.StatusType.Normal,
					"Requesting the CDN Finder data completed successfully.",
					"{0} web sites received.".FormatWith(sites.Count),
					Resources.Success_16);
				// Show a message.
				this.ShowMessage(
					Resources.GlobeSuccess_48,
					"CDN Finder Request",
					"Requesting the CDN Finder data completed successfully.",
					false,
					(int)this.config.Api.Config.MessageCloseDelay.TotalMilliseconds,
					(object[] parameters) =>
					{
						// Call the request finished event handler.
						this.OnRequestFinished();
						// Update the site information.
						this.OnUpdateDomains(sites);
					});
				// Log the events.
				this.controlLog.Add(this.config.Api.Log(
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
					this.status.Send(CrawlerStatus.StatusType.Normal, "Requesting the CDN Finder data was canceled.", Resources.Canceled_16);
					// Show a message.
					this.ShowMessage(
						Resources.GlobeCanceled_48,
						"CDN Finder Request",
						"Requesting the CDN Finder data was canceled.",
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
						"Requesting the CDN Finder data was canceled."
						));
				}
				else
				{
					// Update the status label.
					this.status.Send(CrawlerStatus.StatusType.Normal, "Requesting the CDN Finder data failed. {0}".FormatWith(exception.Message), Resources.Error_16);
					// Show a message.
					this.ShowMessage(
						Resources.GlobeError_48,
						"CDN Finder Request",
						"Requesting the CDN Finder data failed.{0}{1}".FormatWith(Environment.NewLine, exception.Message),
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
						"Requesting the CDN Finder data failed. {0}",
						new object[] { exception.Message },
						exception
						));
				}
			}
			catch (Exception exception)
			{
				// Update the status label.
				this.status.Send(CrawlerStatus.StatusType.Normal, "Requesting the CDN Finder data failed. {0}".FormatWith(exception.Message), Resources.Error_16);
				// Show a message.
				this.ShowMessage(
					Resources.GlobeError_48,
					"CDN Finder Request",
					"Requesting the CDN Finder data failed.{0}{1}".FormatWith(Environment.NewLine, exception.Message),
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
				// If the cancellation token is not null.
				if (null != this.asyncCancel)
				{
					// Cancel the asynchronous operation.
					this.asyncCancel.Cancel();
				}
				// If the request result is not null.
				if (null != this.asyncResult)
				{
					// Cancel the asynchronous operation.
					this.request.Cancel(this.asyncResult);
					// Set the result to null.
					this.asyncResult = null;
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
			// Imports a list of sites from the specified Alexa ranking file.
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

				// Update the sites list.
				lock (this.sync)
				{
					// Clear the sites list.
					this.listViewSites.Items.Clear();
					// Updates the sites list.
					for (int index = 0; index < ranking.Count; index++)
					{
						// Create the site item.
						ListViewItem item = new ListViewItem(new string[] { (index + 1).ToString(), ranking[index].Site, "(unknown)", "(unknown)" });
						item.ImageKey = "GlobeQuestion";
						item.Tag = new SiteInfo(ranking[index].Site);
						this.listViewSites.Items.Add(item);
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
			this.buttonStart.Enabled = (!string.IsNullOrWhiteSpace(this.textBoxUrl.Text)) && (this.listViewSites.Items.Count > 0);
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
		/// Updates the list of sites with the specified results.
		/// </summary>
		/// <param name="sites">The sites.</param>
		private void OnUpdateDomains(CdnFinderSites sites)
		{
			lock (this.sync)
			{
				// Set the current sites.
				this.sites = sites;

				// Update the list view items.
				foreach (ListViewItem item in this.listViewSites.Items)
				{
					// Get the site information.
					CdnFinderSite site = sites.FirstOrDefault((CdnFinderSite dom) =>
						{
							// Get the site information.
							SiteInfo inf = item.Tag as SiteInfo;
							// Check the site URL matches the returned  URL.
							return dom.Site == inf.SiteUrl;
						});
					
					// Get the item site information.
					SiteInfo info = item.Tag as SiteInfo;

					// Set the CDN Finder site.
					info.Site = site;
					
					// If the site is null.
					if (null == site)
					{
						item.ImageKey = "GlobeError";
						item.SubItems[3].Text = "(unknown)";
					}
					else if (site.Success)
					{
						item.ImageKey = "GlobeSuccess";
						item.SubItems[3].Text = site.Resources.Count.ToString();
					}
					else
					{
						item.ImageKey = "GlobeWarning";
						item.SubItems[3].Text = "(unknown)";
					}
				}

				// Enable the save button.
				this.buttonSave.Enabled = true;
			}

			// Call the site selection changed event handler.
			this.OnSiteSelectionChanged(this, EventArgs.Empty);
		}

		/// <summary>
		/// An event handler calle when the site selection has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSiteSelectionChanged(object sender, EventArgs e)
		{
			// If there are no selected items, or if the list of sites is empty.
			lock (this.sync)
			{
				if ((0 == this.listViewSites.SelectedItems.Count) || (null == this.sites))
				{
					// Clear the site information.
					this.controlSite.Clear();
					// Return.
					return;
				}
			}

			// Get the selected item.
			ListViewItem item = this.listViewSites.SelectedItems[0];

			// Get the item site information.
			SiteInfo info = item.Tag as SiteInfo;

			// Set the site information.
			this.controlSite.Set(info.SiteName, info.Site);
		}

		/// <summary>
		/// An event handler called when saving the sites data.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSaveSites(object sender, EventArgs e)
		{
			// If the sites data is null, do nothing.
			if (null == this.sites) return;
			// Set th dialog properties.
			this.saveFileDialog.Title = "Save Sites Data";
			this.saveFileDialog.Filter = "CDN Finder data files (*.cdn)|*.cdn";
			// Show the dialog.
			if (this.saveFileDialog.ShowDialog(this) == DialogResult.OK)
			{
				try
				{
					// Save the sites to an XML file.
					this.sites.SaveSites(this.saveFileDialog.FileName);
				}
				catch (Exception exception)
				{
					// Show an error message.
					MessageBox.Show(
						this,
						"Saving the CDN file sites information failed. {0}".FormatWith(exception.Message),
						"Save Sites Data",
						MessageBoxButtons.OK,
						MessageBoxIcon.Error);
				}
			}
		}

		/// <summary>
		/// An event handler called when saving the resources data.
		/// </summary>
		/// <param name="sender">The sender objects.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSaveResources(object sender, EventArgs e)
		{
			// If the sites data is null, do nothing.
			if (null == this.sites) return;
			// Set th dialog properties.
			this.saveFileDialog.Title = "Save Sites Resources";
			this.saveFileDialog.Filter = "Text files (*.txt)|*.txt";
			// Show the dialog.
			if (this.saveFileDialog.ShowDialog(this) == DialogResult.OK)
			{
				try
				{
					// Save the resources to a text file.
					this.sites.SaveResources(this.saveFileDialog.FileName);
				}
				catch (Exception exception)
				{
					// Show an error message.
					MessageBox.Show(
						this,
						"Saving the CDN file sites information failed. {0}".FormatWith(exception.Message),
						"Save Sites Data",
						MessageBoxButtons.OK,
						MessageBoxIcon.Error);
				}
			}
		}
	}
}
