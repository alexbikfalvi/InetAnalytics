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
using System.Windows.Forms;
using DotNetApi;
using DotNetApi.Web.XmlRpc;
using DotNetApi.Windows.Controls;
using MapApi;
using YtAnalytics.Events;
using YtAnalytics.Forms.PlanetLab;
using YtCrawler;
using PlanetLab.Api;
using PlanetLab.Requests;

namespace YtAnalytics.Controls.PlanetLab
{
	/// <summary>
	/// A control that receives user input data to add a new node to a PlanetLab slice by location.
	/// </summary>
	public sealed partial class ControlAddNodeLocation : ControlRequest
	{
		private enum State
		{
			Sites = 0,
			Nodes = 1
		};

		private State state = State.Sites;

		private readonly PlRequest requestSites = new PlRequest(PlRequest.RequestMethod.GetSites);
		private readonly PlRequest requestNodes = new PlRequest(PlRequest.RequestMethod.GetNodes);
		
		private readonly PlList<PlSite> sites = new PlList<PlSite>();
		private readonly PlList<PlNode> nodes = new PlList<PlNode>();
		
		private string filterSite = string.Empty;
		private string filterNode = string.Empty;

		private readonly FormObjectProperties<ControlSiteProperties> formSiteProperties = new FormObjectProperties<ControlSiteProperties>();
		private readonly FormObjectProperties<ControlNodeProperties> formNodeProperties = new FormObjectProperties<ControlNodeProperties>();

		private readonly string[] status = new string[] { string.Empty, string.Empty };

		private MapMarker marker = null;

		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlAddNodeLocation()
		{
			// Initialize the component.
			this.InitializeComponent();

			// Load the map.
			this.mapControl.LoadMap("Ne110mAdmin0Countries");
		}

		// Public events.

		/// <summary>
		/// An event raised when a PlanetLab operation has started.
		/// </summary>
		public event EventHandler RequestStarted;
		/// <summary>
		/// An event raised when a PlanetLab operation has finished.
		/// </summary>
		public event EventHandler RequestFinished;
		/// <summary>
		/// An event raised when a PlanetLab site was selected.
		/// </summary>
		public event PlanetLabObjectEventHandler<PlNode> Selected;
		/// <summary>
		/// An event raised when user closes the selection.
		/// </summary>
		public event EventHandler Closed;

		// Public methods.

		/// <summary>
		/// Refreshes the control using the PlanetLab sites from the current configuration.
		/// </summary>
		/// <param name="config">The crawler configuration.</param>
		public void Refresh(CrawlerConfig config)
		{
			// Update the sites list.
			this.sites.CopyFrom(config.PlanetLab.Sites);
			// Set the default state.
			this.tabControl.SelectedIndex = 0;
			// Update the sites.
			this.OnUpdateSites();
		}

		// Protected methods.

		/// <summary>
		/// An event handler called when the current request begins, and the notification box is displayed.
		/// </summary>
		/// <param name="parameters">The task parameters.</param>
		protected override void OnBeginRequest(object[] parameters = null)
		{
			// Disable the buttons.
			this.buttonRefresh.Enabled = false;
			this.buttonCancel.Enabled = true;
			this.buttonBack.Enabled = false;
			this.buttonNext.Enabled = false;
			this.buttonClose.Enabled = false;
			this.tabControl.Enabled = false;
			// Update the label.
			this.labelStatus.Text = "Refreshing...";

			// Raise the PlanetLab request started event.
			if (this.RequestStarted != null) this.RequestStarted(this, EventArgs.Empty);
		}

		/// <summary>
		/// An event handler called when the control completes an asynchronous request for a PlanetLab resource.
		/// </summary>
		/// <param name="response">The XML-RPC response.</param>
		protected override void OnCompleteRequest(XmlRpcResponse response)
		{
			//// If the request has not failed.
			//if ((null == response.Fault) && (null != response.Value))
			//{
			//	// Update the list of PlanetLab slices list for the given response.
			//	this.slices.Update(response.Value as XmlRpcArray);
			//	// Update the list view.
			//	this.OnUpdateSites();
			//}
			//else
			//{
			//	// Update the status.
			//	this.labelStatus.Text = "Refresh failed. {0}".FormatWith(response.Fault);
			//}
		}

		/// <summary>
		/// An event handler called when an asynchronous request for a PlanetLab resource was canceled.
		/// </summary>
		protected override void OnCancelRequest()
		{
			// Update the status.
			this.labelStatus.Text = "Refresh canceled.";
		}

		/// <summary>
		/// An event handler called when the current request ends, and the notification box is hidden.
		/// </summary>
		/// <param name="parameters">The task parameters.</param>
		protected override void OnEndRequest(object[] parameters = null)
		{
			//// Enable the buttons.
			//this.buttonRefresh.Enabled = true;
			//this.buttonCancel.Enabled = false;
			//this.buttonNext.Enabled = this.listView.Items.Count > 0;
			//this.buttonClose.Enabled = true;
			//// Raise the PlanetLab request finished event.
			//if (this.RequestFinished != null) this.RequestFinished(this, EventArgs.Empty);
		}

		// Private methods.

		/// <summary>
		/// Refreshes the list of PlanetLab sites.
		/// </summary>
		public void RefreshListSites()
		{
			// Clear the sites and nodes list.
			this.listViewSites.Items.Clear();
			this.listViewNodes.Items.Clear();
			// Clear the filters.
			this.textBoxFilterSite.Clear();
			this.textBoxFilterNode.Clear();
			// Clear the lists.
			this.sites.Clear();
			this.nodes.Clear();
			try
			{
				// Begin the PlanetLab sites request.
				this.BeginRequest(this.requestSites, CrawlerStatic.PlanetLabUsername, CrawlerStatic.PlanetLabPassword);
			}
			catch
			{
				// Update the label.
				this.labelStatus.Text = "Refresh failed.";
			}
		}

		/// <summary>
		/// An event handler called when the user refreshes the list of items.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnRefreshStarted(object sender, EventArgs e)
		{
			//// Refresh the list.
			//this.RefreshList();
		}

		/// <summary>
		/// An event handler called when the user clicks on the back button.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnBack(object sender, EventArgs e)
		{
		}

		/// <summary>
		/// An event handler called when the user clicks on the next button.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnNext(object sender, EventArgs e)
		{
			// Switch according to the state.
			switch (this.state)
			{
				case State.Sites:
					break;
				case State.Nodes:
					break;
			}

			//// If there is no selected PlanetLab object, do nothing.
			//if (this.listView.SelectedItems.Count == 0) return;
			//// Else, get the PlanetLab object.
			//PlSlice result = this.listView.SelectedItems[0].Tag as PlSlice;
			//// Raise the event.
			//if (this.Selected != null) this.Selected(this, new PlanetLabObjectEventArgs<PlSlice>(result));
		}

		/// <summary>
		/// An event handler called when the user selects the close button.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnClose(object sender, EventArgs e)
		{
			// Raise the close event.
			if (this.Closed != null) this.Closed(sender, e);
		}

		/// <summary>
		/// An event handler called when the site selection has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSiteSelectionChanged(object sender, EventArgs e)
		{
			// If there exists an emphasized marker, de-emphasize it.
			if (this.marker != null)
			{
				this.marker.Emphasized = false;
				this.marker = null;
			}
			// If there is a selected site.
			if (this.listViewSites.SelectedItems.Count > 0)
			{
				// Get the site-marker for this item.
				KeyValuePair<PlSite, MapMarker> tag = (KeyValuePair<PlSite, MapMarker>)this.listViewSites.SelectedItems[0].Tag;
				// If the marker is not null, emphasize the marker.
				if (tag.Value != null)
				{
					this.marker = tag.Value;
					this.marker.Emphasized = true;
				}
			}
			// If the current state is sites.
			if (this.state == State.Sites)
			{
				// Update the controls state.
				this.buttonNext.Enabled = this.listViewSites.SelectedItems.Count > 0;
			}
		}

		/// <summary>
		/// <summary>
		/// An event handler called when the node selection has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnNodeSelectionChanged(object sender, EventArgs e)
		{
			//// Set the select button enabled state.
			//this.buttonNext.Enabled = this.listView.SelectedItems.Count > 0;
		}

		/// <summary>
		/// An event handler called when the user selects to view the site properties.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSiteProperties(object sender, EventArgs e)
		{
			// If there is no selected site item, do nothing.
			if (this.listViewSites.SelectedItems.Count == 0) return;

			// Get the site-marker for this item.
			KeyValuePair<PlSite, MapMarker> tag = (KeyValuePair<PlSite, MapMarker>)this.listViewSites.SelectedItems[0].Tag;

			// Show the site properties.
			this.formSiteProperties.ShowDialog(this, "Site", tag.Key);
		}

		/// <summary>
		/// An event handler called when the user views the properties of the PlanetLab node.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnNodeProperties(object sender, EventArgs e)
		{
			//// If there is no selected PlanetLab object, do nothing.
			//if (this.listView.SelectedItems.Count == 0) return;
			//// Show the properties dialog.
			//this.formProperties.ShowDialog(this, "Slice", this.listView.SelectedItems[0].Tag as PlSlice);
		}

		/// <summary>
		/// An event handler called when the user cancel a current database command.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnCancel(object sender, EventArgs e)
		{
			// Disable the cancel button.
			this.buttonCancel.Enabled = false;
			// Cancel the current request.
			this.CancelRequest();
		}

		/// <summary>
		/// An event handler called when the site filter text has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSiteFilterTextChanged(object sender, EventArgs e)
		{
			// If the filter has changed.
			if (this.filterSite != this.textBoxFilterSite.Text.Trim())
			{
				// Update the list.
				this.OnUpdateSites();
			}
		}

		/// <summary>
		/// An event handler called when the node filter text has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnNodeFilterTextChanged(object sender, EventArgs e)
		{
			//// If the filter has changed.
			//if (this.filter != this.textBoxFilterSite.Text.Trim())
			//{
			//	// Update the list.
			//	this.OnUpdateList();
			//}
		}

		/// <summary>
		/// Updates the list of PlanetLab sites.
		/// </summary>
		private void OnUpdateSites()
		{
			// Clear the list view.
			this.listViewSites.Items.Clear();
			this.listViewNodes.Items.Clear();
			// Clear the map markers.
			this.mapControl.Markers.Clear();
			// Reset the filters.
			this.textBoxFilterSite.Clear();
			this.textBoxFilterNode.Clear();
			// Reset the tabs.
			this.tabControl.SelectedIndex = 0;

			// Update the filter.
			this.filterSite = this.textBoxFilterSite.Text.Trim();
			// The number of displayed sites.
			int count = 0;

			// Lock the list.
			this.sites.Lock();
			try
			{
				// Update the sites list.
				foreach (PlSite site in this.sites)
				{
					// If the filter is not null or empty.
					if (!string.IsNullOrEmpty(this.filterSite))
					{
						// If the site name does not match the filter, continue.
						if (!string.IsNullOrEmpty(site.Name))
						{
							if (!site.Name.ToLower().Contains(this.filterSite.ToLower())) continue;
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
				this.sites.Unlock();
			}
			// Update the status.
			this.labelStatus.Text = "Showing {0} of {1} PlanetLab slices.".FormatWith(count, this.sites.Count);
		}

		/// <summary>
		/// Updates the list of PlanetLab nodes.
		/// </summary>
		private void OnUpdateNodes()
		{
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
			this.OnSiteProperties(sender, e);
		}

		/// <summary>
		/// Sets the status message for the specified state.
		/// </summary>
		/// <param name="text">The text.</param>
		/// <param name="state">The state.</param>
		private void OnSetStatus(string text, State state)
		{
			// Set the status for the specified state.
			this.status[(int)state] = text;
			// If the current state equals with state.
			if (this.state == state)
			{
				// Update the label.
				this.labelStatus.Text = text;
			}
		}

		/// <summary>
		/// An event handler called before a new tab is selected.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnTabSelecting(object sender, TabControlCancelEventArgs e)
		{
			// Get the new state.
			State state = (State)e.TabPageIndex;

			// Check the user can switch to the new state.
			if ((state == State.Nodes) && (this.listViewSites.SelectedItems.Count == 0))
			{
				MessageBox.Show(this, "You must first select a PlanetLab site.", "Add Node to Slice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				e.Cancel = true;
			}
			else
			{
				this.state = state;
			}

			// Update the buttons state.
			switch (this.state)
			{
				case State.Sites:
					this.buttonBack.Enabled = false;
					this.buttonNext.Enabled = this.listViewSites.SelectedItems.Count > 0;
					this.buttonNext.Text = "&Next";
					break;
				case State.Nodes:
					this.buttonBack.Enabled = true;
					this.buttonNext.Enabled = this.listViewNodes.SelectedItems.Count > 0;
					this.buttonNext.Text = "&Select";
					break;
			}

			// Update the status message.
			this.labelStatus.Text = this.status[(int)this.state];
		}
	}
}
