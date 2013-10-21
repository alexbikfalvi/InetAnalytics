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
using PlanetLab.Database;
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

		private readonly PlRequest request = new PlRequest(PlRequest.RequestMethod.GetSites);
		
		private MapMarker marker = null;
		private string filter = string.Empty;

		private readonly FormObjectProperties<ControlSiteProperties> formSiteProperties = new FormObjectProperties<ControlSiteProperties>();
		private readonly FormExport formExport = new FormExport();
		private readonly FormExportMap formExportMap = new FormExportMap();

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

			// Set the site list event handler.
			this.crawler.Config.PlanetLab.Sites.Cleared += this.OnSitesCleared;
			this.crawler.Config.PlanetLab.Sites.Updated += this.OnSitesUpdated;
			this.crawler.Config.PlanetLab.Sites.Added += this.OnSitesAdded;
			this.crawler.Config.PlanetLab.Sites.Removed += this.OnSitesRemoved;

			// Get the status handler.
			this.status = this.crawler.Status.GetHandler(this);
		
			// Enable the control.
			this.Enabled = true;

			// Update the list of PlanetLab sites.
			this.OnSitesUpdated(this, EventArgs.Empty);
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
			this.buttonExport.Enabled = false;
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
				try
				{
					// Update the list of PlanetLab sites.
					this.crawler.Config.PlanetLab.Sites.CopyFrom(response.Value as XmlRpcArray);

					// Log
					this.crawler.Log.Add(
						LogEventLevel.Verbose,
						LogEventType.Success,
						ControlSites.logSource,
						"Refreshing the list of PlanetLab sites completed successfully.");
				}
				catch
				{
					// Log
					this.crawler.Log.Add(
						LogEventLevel.Important,
						LogEventType.Error,
						ControlSites.logSource,
						"Refreshing the list of PlanetLab sites failed.");
				}
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
			this.buttonExport.Enabled = true;
		}

		// Private methods.

		/// <summary>
		/// An event handler called when the site has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSiteChanged(object sender, PlObjectEventArgs e)
		{
			// Get the site.
			PlSite site = e.Object as PlSite;
			// Find the list view item corresponding to the slice.
			ListViewItem item = this.listViewSites.Items.FirstOrDefault((ListViewItem it) =>
			{
				// Get the slice info.
				Pair<PlSite, MapMarker> tag = (Pair<PlSite, MapMarker>)it.Tag;
				// Return true if the item corresponds to the same slice.
				return object.ReferenceEquals(site, tag.First);
			});
			// If the item is not null.
			if (null != item)
			{
				// Update the item.
				item.SubItems[0].Text = site.SiteId.ToString();
				item.SubItems[1].Text = site.Name;
				item.SubItems[2].Text = site.Url;
				item.SubItems[3].Text = site.NodeIds.Length.ToString();
				item.SubItems[4].Text = site.DateCreated.ToString();
				item.SubItems[5].Text = site.LastUpdated.ToString();
				item.SubItems[6].Text = site.Latitude.HasValue ? site.Latitude.Value.LatitudeToString() : string.Empty;
				item.SubItems[7].Text = site.Longitude.HasValue ? site.Longitude.Value.LongitudeToString() : string.Empty;
			}
		}

		/// <summary>
		/// An event handler called when the list of PlanetLab sites has been cleared.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSitesCleared(object sender, EventArgs e)
		{
			// For all items.
			foreach (ListViewItem item in this.listViewSites.Items)
			{
				// Get the slice tag.
				Pair<PlSite, MapMarker> tag = (Pair<PlSite, MapMarker>)item.Tag;
				// Remove the slice changed event handler.
				tag.First.Changed -= this.OnSiteChanged;
			}
			// Clear the list view.
			this.listViewSites.Items.Clear();
			// Clear the map markers.
			this.mapControl.Markers.Clear();

			// Update the label.
			this.status.Send("Showing {0} of {1} PlanetLab site{2}.".FormatWith(
				this.listViewSites.Items.Count,
				this.crawler.Config.PlanetLab.Sites.Count,
				this.crawler.Config.PlanetLab.Sites.Count.PluralSuffix()), Resources.GlobeLab_16);
		}

		/// <summary>
		/// An event handler called when the list of PlanetLab sites has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSitesUpdated(object sender, EventArgs e)
		{
			int numNodes = 0;

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
							if (this.menuItemInvertFilter.Checked ^ (!site.Name.ToLower().Contains(this.filter.ToLower()))) continue;
						}
					}
					// If the site has zero nodes and the filter is checked, continue.
					if ((site.NodeIds.Length == 0) && this.menuItemFilterNodes.Checked) continue;

					// Add a site.
					this.OnAddSite(site);

					// Increment the number of nodes.
					numNodes += site.NodeIds.Length;
				}
			}
			finally
			{
				this.crawler.Config.PlanetLab.Sites.Unlock();
			}

			// Update the label.
			this.status.Send(
				"Showing {0} of {1} PlanetLab site{2}.".FormatWith(
				this.listViewSites.Items.Count,
				this.crawler.Config.PlanetLab.Sites.Count,
				this.crawler.Config.PlanetLab.Sites.Count.PluralSuffix()),
				"Sites have {0} nodes.".FormatWith(numNodes),
				Resources.GlobeLab_16);
		}

		/// <summary>
		/// An event handler called when a new site has been added.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSitesAdded(object sender, PlObjectEventArgs<PlSite> e)
		{
			// The filter flag.
			bool filterFlag = false;

			// If the filter is not null or empty.
			if (!string.IsNullOrEmpty(this.filter))
			{
				// If the site name does not match the filter, return.
				if (!string.IsNullOrEmpty(e.Object.Name))
				{
					filterFlag = !e.Object.Name.ToLower().Contains(this.filter.ToLower());
				}
			}

			// If the site is not filtered.
			if (!filterFlag)
			{
				// Add the site.
				this.OnAddSite(e.Object);
			}

			// Update the label.
			this.status.Send("Showing {0} of {1} PlanetLab site{2}.".FormatWith(
				this.listViewSites.Items.Count,
				this.crawler.Config.PlanetLab.Sites.Count,
				this.crawler.Config.PlanetLab.Sites.Count.PluralSuffix()), Resources.GlobeLab_16);
		}

		/// <summary>
		/// An event handler called when a site has been removed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSitesRemoved(object sender, PlObjectEventArgs<PlSite> e)
		{
			// Get the list view item containing the site.
			ListViewItem item = this.listViewSites.Items.FirstOrDefault((ListViewItem it) =>
				{
					// Get the item tag.
					Pair<PlSite, MapMarker> tag = (Pair<PlSite, MapMarker>)it.Tag;
					// Return true if the tag slice matches the current slice.
					return object.ReferenceEquals(tag.First, e.Object);
				});
			// If the item is not null.
			if (null != item)
			{
				// Get the item tag.
				Pair<PlSite, MapMarker> tag = (Pair<PlSite, MapMarker>)item.Tag;
				// Remove the slice changed event handler.
				tag.First.Changed -= this.OnSiteChanged;
				// Remove the map marker.
				this.mapControl.Markers.Remove(tag.Second);
				// Dispose the map marker.
				tag.Second.Dispose();
				// Remove the item.
				this.listViewSites.Items.Remove(item);
			}
		}

		/// <summary>
		/// An event handler called when disposing the list of sites.
		/// </summary>
		private void OnDisposeSites()
		{
			// For all items.
			foreach (ListViewItem item in this.listViewSites.Items)
			{
				// Get the slice tag.
				Pair<PlSite, MapMarker> tag = (Pair<PlSite, MapMarker>)item.Tag;
				// Remove the slice changed event handler.
				tag.First.Changed -= this.OnSiteChanged;
			}
		}

		/// <summary>
		/// Adds a site to the site list.
		/// </summary>
		/// <param name="site">The site.</param>
		private void OnAddSite(PlSite site)
		{
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
						site.NodeIds.Length.ToString(),
						site.DateCreated.ToString(),
						site.LastUpdated.ToString(),
						site.Latitude.HasValue ? site.Latitude.Value.LatitudeToString() : string.Empty,
						site.Longitude.HasValue ? site.Longitude.Value.LongitudeToString() : string.Empty
					}, 0);
			item.Tag = new Pair<PlSite, MapMarker>(site, marker);
			this.listViewSites.Items.Add(item);

			// Add the site event handler.
			site.Changed += this.OnSiteChanged;

			// Add the item to the marker.
			if (null != marker)
			{
				marker.Tag = item;
			}
		}

		/// <summary>
		/// An event handler called when the user refreshes the list of PlanetLab slices.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnRefresh(object sender, EventArgs e)
		{
			// Clear the current list of sites.
			this.crawler.Config.PlanetLab.Sites.Clear();

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
			this.buttonExport.Enabled = true;
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
				Pair<PlSite, MapMarker> tag = (Pair<PlSite, MapMarker>)this.listViewSites.SelectedItems[0].Tag;
				// If the marker is not null, emphasize the marker.
				if (tag.Second != null)
				{
					this.marker = tag.Second;
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
			Pair<PlSite, MapMarker> tag = (Pair<PlSite, MapMarker>)this.listViewSites.SelectedItems[0].Tag;

			// Show the site properties.
			this.formSiteProperties.ShowDialog(this, "Site", tag.First);
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
				// Update the filter.
				this.filter = this.textBoxFilter.Text.Trim();
				// Update the clear button state.
				this.buttonClear.Enabled = !string.IsNullOrWhiteSpace(this.textBoxFilter.Text);
				// Clear the sites.
				this.OnSitesCleared(sender, e);
				// Update the sites.
				this.OnSitesUpdated(sender, e);
			}
		}

		/// <summary>
		/// An event handler called when the filter has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnFilterChanged(object sender, EventArgs e)
		{
			// Clear the sites.
			this.OnSitesCleared(sender, e);
			// Update the sites.
			this.OnSitesUpdated(sender, e);
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

		/// <summary>
		/// An event handler called when exporting the sites list as a CSV file.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnExportListCsv(object sender, EventArgs e)
		{
			// Lock the sites.
			this.crawler.Config.PlanetLab.Sites.Lock();
			try
			{
				// Show the export dialog.
				this.formExport.ShowDialog<PlSite>(this, typeof(PlSite.Fields), this.crawler.Config.PlanetLab.Sites);
			}
			finally
			{
				// Unlock the sites.
				this.crawler.Config.PlanetLab.Sites.Unlock();
			}
		}

		/// <summary>
		/// An event handler called when exporting the sites map.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnExportMap(object sender, EventArgs e)
		{
			// Show the export map dialog.
			this.formExportMap.ShowDialog(this, this.mapControl);
		}
	}
}
