/* 
 * Copyright (C) 2012-2013 Alex Bikfalvi
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
using System.Windows.Forms;
using DotNetApi;
using DotNetApi.Web;
using DotNetApi.Web.XmlRpc;
using DotNetApi.Windows.Controls;
using MapApi;
using PlanetLab;
using PlanetLab.Api;
using PlanetLab.Requests;
using YtAnalytics.Forms.PlanetLab;
using YtCrawler;
using YtCrawler.Log;
using YtCrawler.Status;

namespace YtAnalytics.Controls.PlanetLab
{
	/// <summary>
	/// A control class for PlanetLab sites.
	/// </summary>
	public sealed partial class ControlSites : ControlRequest
	{
		private static readonly string logSource = "PlanetLab";

		// Private variables.

		private Crawler crawler = null;
		private StatusHandler status = null;

		private PlRequest request = new PlRequest(PlRequest.RequestMethod.GetSites);
		
		private MapMarker marker = null;
		private string filter = string.Empty;

		private FormObjectProperties<ControlSiteProperties> formSiteProperties = new FormObjectProperties<ControlSiteProperties>();

		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlSites()
		{
			// Initialize component.
			InitializeComponent();

			// Set the default control properties.
			this.Visible = false;
			this.Dock = DockStyle.Fill;

			// Load the map.
			this.mapControl.LoadMap("Ne110mAdmin0Countries");
		}

		// Public methods.

		/// <summary>
		/// Initializes the control with a crawler object.
		/// </summary>
		/// <param name="crawler">The crawler object.</param>
		public void Initialize(Crawler crawler)
		{
			// Save the parameters.
			this.crawler = crawler;

			// Get the status handler.
			this.status = this.crawler.Status.GetHandler(this);
		
			// Enable the control.
			this.Enabled = true;

			// Update the list of PlanetLab sites.
			this.OnUpdateSites();
		}

		// Protected methods.

		/// <summary>
		/// An event handler called when the current request begins, and the notification box is displayed.
		/// </summary>
		/// <param name="state">The request state.</param>
		protected override void OnRequestStarted(RequestState state)
		{
			// Set the button enabled state.
			this.buttonRefresh.Enabled = false;
			this.buttonCancel.Enabled = true;
			this.buttonProperties.Enabled = false;
			this.menuItemProperties.Enabled = false;
		}

		/// <summary>
		/// An event handler called when the control completes an asynchronous request for a PlanetLab resource.
		/// </summary>
		/// <param name="response">The XML-RPC response.</param>
		/// <param name="state">The request state.</param>
		protected override void OnRequestResult(XmlRpcResponse response, RequestState state)
		{
			// If the request has not failed.
			if ((null == response.Fault) && (null != response.Value))
			{
				// Get the slices array.
				XmlRpcArray slices = response.Value as XmlRpcArray;

				// Update the list of PlanetLab sites.
				this.crawler.Config.PlanetLab.Sites.Update(response.Value as XmlRpcArray);

				// Update the list of sites.
				this.OnUpdateSites();

				// Log
				this.crawler.Log.Add(
					LogEventLevel.Verbose,
					LogEventType.Success,
					ControlSites.logSource,
					"Refreshing the list of PlanetLab sites completed successfully.");
			}
			else
			{
				// Update the status.
				this.status.Send("Refreshing the list of PlanetLab sites failed.", Resources.GlobeError_16);
				if (null == response.Fault)
				{
					// Log
					this.crawler.Log.Add(
						LogEventLevel.Important,
						LogEventType.Error,
						ControlSites.logSource,
						"Refreshing the list of PlanetLab sites failed.");
				}
				else
				{
					// Log
					this.crawler.Log.Add(
						LogEventLevel.Important,
						LogEventType.Error,
						ControlSites.logSource,
						"Refreshing the list of PlanetLab sites failed with code {0} ({1}).",
						new object[] { response.Fault.FaultCode, response.Fault.FaultString });
				}
			}
		}

		/// <summary>
		/// An event handler called when an asynchronous request for a PlanetLab resource was canceled.
		/// </summary>
		/// <param name="state">The request state.</param>
		protected override void OnRequestCanceled(RequestState state)
		{
			// Set the button enabled state.
			this.buttonCancel.Enabled = false;
			// Update the status.
			this.status.Send("Refreshing the list of PlanetLab sites was canceled.", Resources.GlobeCanceled_16);
			// Log
			this.crawler.Log.Add(
				LogEventLevel.Verbose,
				LogEventType.Canceled,
				ControlSites.logSource,
				"Refreshing the list of PlanetLab sites was canceled.");
		}

		/// <summary>
		/// An event handler called when the current request throws an exception.
		/// </summary>
		/// <param name="exception">The exception.</param>
		/// <param name="state">The request state.</param>
		protected override void OnRequestException(Exception exception, RequestState state)
		{
			// Update the status.
			this.status.Send("Refreshing the list of PlanetLab sites failed.", Resources.GlobeError_16);
			// Log
			this.crawler.Log.Add(
				LogEventLevel.Important,
				LogEventType.Error,
				ControlSites.logSource,
				"Refreshing the list of PlanetLab sites failed. {1}",
				new object[] { exception.Message },
				exception);
		}

		/// <summary>
		/// An event handler called when the current request finishes, and the notification box is hidden.
		/// </summary>
		/// <param name="state">The request state.</param>
		protected override void OnRequestFinished(RequestState state)
		{
			// Set the button enabled state.
			this.buttonRefresh.Enabled = true;
			this.buttonCancel.Enabled = false;
		}

		// Private methods.

		/// <summary>
		/// An event handler called when the user refreshes the list of PlanetLab slices.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnRefresh(object sender, EventArgs e)
		{
			// Clear the list.
			this.listViewSites.Items.Clear();
			// Clear the map markers.
			this.mapControl.Markers.Clear();

			// Update the status.
			this.status.Send("Refreshing the list of PlanetLab sites...", Resources.GlobeClock_16);
			// Log
			this.crawler.Log.Add(
				LogEventLevel.Verbose,
				LogEventType.Information,
				ControlSites.logSource,
				"Refreshing the list of PlanetLab sites.");

			// Begin an asynchronous PlanetLab request.
			this.BeginRequest(
				this.request,
				CrawlerStatic.PlanetLabUsername,
				CrawlerStatic.PlanetLabPassword);
		}

		/// <summary>
		/// An event handler called when the user cancels the refresh of PlanetLab slices.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnCancel(object sender, EventArgs e)
		{
			// Disable the cancel button.
			this.buttonCancel.Enabled = false;
			// Cancel the request.
			this.CancelRequest();
		}

		/// <summary>
		/// An event handler called when the request has completed.
		/// </summary>
		/// <param name="parameters">The task parameters.</param>
		private void OnComplete(object[] parameters)
		{
			// Set the button enabled state.
			this.buttonRefresh.Enabled = true;
			this.buttonCancel.Enabled = false;
		}

		/// <summary>
		/// Updates the list of PlanetLab sites.
		/// </summary>
		private void OnUpdateSites()
		{
			// Clear the list view.
			this.listViewSites.Items.Clear();
			// Clear the map markers.
			this.mapControl.Markers.Clear();

			// Update the filter.
			this.filter = this.textBoxFilter.Text.Trim();
			// The number of displayed sites.
			int count = 0;

			// Lock the sites.
			this.crawler.Config.PlanetLab.Sites.Lock();
			try
			{
				// Add the list view items.
				foreach (PlSite site in this.crawler.Config.PlanetLab.Sites)
				{
					// If the filter is not null or empty.
					if (!string.IsNullOrEmpty(this.filter))
					{
						// If the site name does not match the filter, continue.
						if (!string.IsNullOrEmpty(site.Name))
						{
							if (!site.Name.ToLower().Contains(this.filter.ToLower())) continue;
						}
					}

					// Increment the number of displayed sites.
					count++;

					// Create a new geo marker for this site.
					MapMarker marker = null;
					// If the site has coordinates.
					if (site.Latitude.HasValue && site.Longitude.HasValue)
					{
						// Create a circular marker.
						marker = new MapBulletMarker(new MapPoint(site.Longitude.Value, site.Latitude.Value));
						marker.Name = site.Name;
						// Add the marker to the map.
						this.mapControl.Markers.Add(marker);
					}

					// Create the list view item.
					ListViewItem item = new ListViewItem(new string[] {
						site.SiteId.ToString(),
						site.Name,
						site.Url,
						site.DateCreated.ToString(),
						site.LastUpdated.ToString(),
						site.Latitude.HasValue ? site.Latitude.Value.LatitudeToString() : string.Empty,
						site.Longitude.HasValue ? site.Longitude.Value.LongitudeToString() : string.Empty
					}, 0);
					item.Tag = new KeyValuePair<PlSite, MapMarker>(site, marker);
					this.listViewSites.Items.Add(item);

					if (null != marker)
					{
						marker.Tag = item;
					}
				}
			}
			finally
			{
				this.crawler.Config.PlanetLab.Sites.Unlock();
			}

			// Update the label.
			this.status.Send("Showing {0} of {1} PlanetLab sites.".FormatWith(count, this.crawler.Config.PlanetLab.Sites.Count), Resources.GlobeLab_16);
		}

		/// <summary>
		/// An event handler called when the site selection has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSelectionChanged(object sender, EventArgs e)
		{
			// If there exists an emphasized marker, de-emphasize it.
			if (this.marker != null)
			{
				this.marker.Emphasized = false;
				this.marker = null;
			}
			// If no site is selected.
			if (this.listViewSites.SelectedItems.Count == 0)
			{
				// Change the properties button enabled state.
				this.buttonProperties.Enabled = false;
				this.menuItemProperties.Enabled = false;
			}
			else
			{
				// Change the properties button enabled state.
				this.buttonProperties.Enabled = true;
				this.menuItemProperties.Enabled = true;
				// Get the site-marker for this item.
				KeyValuePair<PlSite, MapMarker> tag = (KeyValuePair<PlSite, MapMarker>)this.listViewSites.SelectedItems[0].Tag;
				// If the marker is not null, emphasize the marker.
				if (tag.Value != null)
				{
					this.marker = tag.Value;
					this.marker.Emphasized = true;
				}
			}
		}

		/// <summary>
		/// An event handler called when the user selects to view the site properties.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnProperties(object sender, EventArgs e)
		{
			// If there is no selected site item, do nothing.
			if (this.listViewSites.SelectedItems.Count == 0) return;
	
			// Get the site-marker for this item.
			KeyValuePair<PlSite, MapMarker> tag = (KeyValuePair<PlSite, MapMarker>)this.listViewSites.SelectedItems[0].Tag;

			// Show the site properties.
			this.formSiteProperties.ShowDialog(this, "Site", tag.Key);
		}

		/// <summary>
		/// An event handler called when the filter text has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnFilterTextChanged(object sender, EventArgs e)
		{
			// If the filter has changed.
			if (this.filter != this.textBoxFilter.Text.Trim())
			{
				// Update the clear button state.
				this.buttonClear.Enabled = !string.IsNullOrWhiteSpace(this.textBoxFilter.Text);
				// Update the sites.
				this.OnUpdateSites();
			}
		}

		/// <summary>
		/// An event handler called when the filter is cleared.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnFilterClear(object sender, EventArgs e)
		{
			this.textBoxFilter.Text = string.Empty;
		}

		/// <summary>
		/// An event handler called when a map marker is clicked.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnMapMarkerClick(object sender, EventArgs e)
		{
			// If the highlighted map marker is null, do nothing.
			if (null == this.mapControl.HighlightedMarker) return;
			// Get the marker tag as a list view item.
			ListViewItem item = this.mapControl.HighlightedMarker.Tag as ListViewItem;
			// If the list view item is null, do nothing.
			if (null == item) return;
			// Clear the current selection.
			this.listViewSites.SelectedItems.Clear();
			// Select the corresponding item.
			item.Selected = true;
			item.EnsureVisible();
		}

		/// <summary>
		/// An event handler called when a map marker is double-clicked.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnMapMarkerDoubleClick(object sender, EventArgs e)
		{
			// Call the click event handler.
			this.OnMapMarkerClick(sender, e);
			// Call the properties event handler.
			this.OnProperties(sender, e);
		}

		/// <summary>
		/// An event handler called when the user clicks on the list view.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnMouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				if (this.listViewSites.FocusedItem != null)
				{
					if (this.listViewSites.FocusedItem.Bounds.Contains(e.Location))
					{
						this.contextMenu.Show(this.listViewSites, e.Location);
					}
				}
			}
		}
	}
}
