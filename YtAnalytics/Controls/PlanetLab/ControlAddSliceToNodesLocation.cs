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
using PlanetLab;
using PlanetLab.Api;
using PlanetLab.Database;
using PlanetLab.Requests;

namespace YtAnalytics.Controls.PlanetLab
{
	/// <summary>
	/// A control that receives user input data to add a new node to a PlanetLab slice by location.
	/// </summary>
	public sealed partial class ControlAddSliceToNodesLocation : ControlRequest
	{
		public static readonly string[] nodeImageKeys = new string[]
		{
			"NodeUnknown", "NodeBoot", "NodeSafeBoot", "NodeDisabled", "NodeReinstall"
		};

		private readonly PlRequest requestSites = new PlRequest(PlRequest.RequestMethod.GetSites);
		private readonly PlRequest requestNodes = new PlRequest(PlRequest.RequestMethod.GetNodes);
		
		private PlDatabaseList<PlSite> sites = null;
		private readonly PlList<PlNode> nodes = new PlList<PlNode>();

		private readonly HashSet<int> selectedNodes = new HashSet<int>();

		private string filterSite = string.Empty;
		private string filterNode = string.Empty;

		private readonly FormObjectProperties<ControlSiteProperties> formSiteProperties = new FormObjectProperties<ControlSiteProperties>();
		private readonly FormObjectProperties<ControlNodeProperties> formNodeProperties = new FormObjectProperties<ControlNodeProperties>();

		private MapMarker marker = null;

		private RequestState requestStateSites;
		private RequestState requestStateNodes;

		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlAddSliceToNodesLocation()
		{
			// Initialize the component.
			this.InitializeComponent();

			// Load the map.
			this.mapControl.LoadMap("Ne110mAdmin0Countries");

			// Create the request states.
			this.requestStateSites = new RequestState(null, this.OnSitesRequestResult, null, null, null);
			this.requestStateNodes = new RequestState(null, this.OnNodesRequestResult, null, null, null);
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
		public event ArrayEventHandler<int> Selected;
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
			this.sites = config.PlanetLab.Sites;
			// Clear the list view.
			this.listViewSites.Items.Clear();
			this.listViewNodes.Items.Clear();
			// Clear the map markers.
			this.mapControl.Markers.Clear();
			// Reset the filters.
			this.textBoxFilterSite.Clear();
			this.textBoxFilterNode.Clear();
			// Clear the lists.
			this.nodes.Clear();
			this.selectedNodes.Clear();
			// Reset the wizard.
			this.wizard.SelectedIndex = 0;
			this.wizardPageSite.NextEnabled = false;
			// Update the sites.
			this.OnUpdateSites();
		}

		// Protected methods.

		/// <summary>
		/// An event handler called when the current request begins, and the notification box is displayed.
		/// </summary>
		/// <param name="state">The request state.</param>
		protected override void OnRequestStarted(RequestState state)
		{
			// Disable the buttons.
			this.buttonRefresh.Enabled = false;
			this.buttonCancel.Enabled = true;
			this.wizard.SelectedPage.NextEnabled = false;
			this.wizard.SelectedPage.BackEnabled = false;
			this.buttonClose.Enabled = false;

			// Raise the PlanetLab request started event.
			if (this.RequestStarted != null) this.RequestStarted(this, EventArgs.Empty);
		}

		/// <summary>
		/// An event handler called when an asynchronous request for a PlanetLab resource was canceled.
		/// </summary>
		/// <param name="state">The request state.</param>
		protected override void OnRequestCanceled(RequestState state)
		{
			// Update the status.
			switch (this.wizard.SelectedIndex)
			{
				case 0:
					this.wizardPageSite.Status = "Refreshing the PlanetLab sites was canceled.";
					break;
				case 1:
					this.wizardPageNode.Status = "Refreshing the PlanetLab nodes was canceled.";
					break;
			}
		}

		/// <summary>
		/// An event handler called when the current request throws an exception.
		/// </summary>
		/// <param name="exception">The exception.</param>
		/// <param name="state">The request state.</param>
		protected override void OnRequestException(Exception exception, RequestState state)
		{
			// Update the status.
			switch (this.wizard.SelectedIndex)
			{
				case 0:
					this.wizardPageSite.Status = "Refreshing the PlanetLab sites failed.";
					break;
				case 1:
					this.wizardPageNode.Status = "Refreshing the PlanetLab nodes failed.";
					break;
			}
		}

		/// <summary>
		/// An event handler called when the current request finishes, and the notification box is hidden.
		/// </summary>
		/// <param name="state">The request state.</param>
		protected override void OnRequestFinished(RequestState state)
		{
			// Enable the buttons.
			this.buttonRefresh.Enabled = true;
			this.buttonCancel.Enabled = false;
			this.wizard.SelectedPage.BackEnabled = true;
			this.buttonClose.Enabled = true;
			// Raise the PlanetLab request finished event.
			if (this.RequestFinished != null) this.RequestFinished(this, EventArgs.Empty);
		}

		// Private methods.

		/// <summary>
		/// Refreshes the list of PlanetLab sites.
		/// </summary>
		public void OnRefreshListSites()
		{
			// Clear the list view.
			this.listViewSites.Items.Clear();
			this.listViewNodes.Items.Clear();
			// Clear the map markers.
			this.mapControl.Markers.Clear();
			// Reset the filters.
			this.textBoxFilterSite.Clear();
			this.textBoxFilterNode.Clear();
			// Clear the lists.
			this.sites.Clear();
			this.nodes.Clear();
			this.selectedNodes.Clear();
			// Disable the selection buttons.
			this.buttonSelectAll.Enabled = false;
			this.buttonClearAll.Enabled = false;
			// Update the status.
			this.wizardPageSite.Status = "Refreshing the PlanetLab sites...";

			// Begin the PlanetLab sites request.
			this.BeginRequest(
				this.requestSites,
				CrawlerStatic.PlanetLabUsername,
				CrawlerStatic.PlanetLabPassword,
				null,
				this.requestStateSites);
		}

		/// <summary>
		/// Refreshes the list of PlanetLab nodes for the selected site.
		/// </summary>
		public void OnRefreshListNodes()
		{
			// If there is no selected site item, do nothing.
			if (this.listViewSites.SelectedItems.Count == 0) return;

			// Get the site-marker for this item.
			Pair<PlSite, MapMarker> tag = (Pair<PlSite, MapMarker>)this.listViewSites.SelectedItems[0].Tag;

			// Clear the list view.
			this.listViewNodes.Items.Clear();
			// Reset the filters.
			this.textBoxFilterNode.Clear();
			// Clear the lists.
			this.nodes.Clear();
			this.selectedNodes.Clear();
			// Disable the selection buttons.
			this.buttonSelectAll.Enabled = false;
			this.buttonClearAll.Enabled = false;
			// Update the status.
			this.wizardPageNode.Status = "Refreshing the PlanetLab nodes...";

			// Begin the PlanetLab nodes request.
			this.BeginRequest(
				this.requestNodes,
				CrawlerStatic.PlanetLabUsername,
				CrawlerStatic.PlanetLabPassword,
				PlNode.GetFilter(PlNode.Fields.SiteId, tag.First.Id),
				this.requestStateNodes);
		}

		/// <summary>
		/// An event handler called when the control completes an asynchronous request for the list of PlanetLab sites.
		/// </summary>
		/// <param name="response">The XML-RPC response.</param>
		/// <param name="state">The request state.</param>
		private void OnSitesRequestResult(XmlRpcResponse response, RequestState state)
		{
			// If the request has not failed.
			if ((null == response.Fault) && (null != response.Value))
			{
				// Update the list of PlanetLab sites list for the given response.
				this.sites.CopyFrom(response.Value as XmlRpcArray);
				// Update the sites list.
				this.OnUpdateSites();
			}
			else
			{
				// Update the status.
				this.wizardPageSite.Status = "Refreshing the PlanetLab sites failed. {0}".FormatWith(response.Fault);
			}
		}

		/// <summary>
		/// An event handler called when the control completes an asynchronous request for the list of PlanetLab nodes.
		/// </summary>
		/// <param name="response">The XML-RPC response.</param>
		/// <param name="state">The request state.</param>
		private void OnNodesRequestResult(XmlRpcResponse response, RequestState state)
		{
			// If the request has not failed.
			if ((null == response.Fault) && (null != response.Value))
			{
				// Update the list of PlanetLab nodes list for the given response.
				this.nodes.Update(response.Value as XmlRpcArray);
				// Update the nodes list.
				this.OnUpdateNodes();
			}
			else
			{
				// Update the status.
				this.wizardPageNode.Status = "Refreshing the PlanetLab nodes failed. {0}".FormatWith(response.Fault);
			}
		}

		/// <summary>
		/// An event handler called when the user refreshes the list of items.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnRefresh(object sender, EventArgs e)
		{
			// Refresh the list according to the selected index.
			switch (this.wizard.SelectedIndex)
			{
				case 0:
					this.OnRefreshListSites();
					break;
				case 1:
					this.OnRefreshListNodes();
					break;
			}
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
				Pair<PlSite, MapMarker> tag = (Pair<PlSite, MapMarker>)this.listViewSites.SelectedItems[0].Tag;
				// If the marker is not null, emphasize the marker.
				if (tag.Second != null)
				{
					this.marker = tag.Second;
					this.marker.Emphasized = true;
				}
			}
			// Update the next button.
			this.wizardPageSite.NextEnabled = this.listViewSites.SelectedItems.Count > 0;
			// Reset the nodes controls.
			this.listViewNodes.Items.Clear();
			this.textBoxFilterNode.Clear();
			// Clear the lists.
			this.nodes.Clear();
			this.selectedNodes.Clear();
		}

		/// <summary>
		/// An event handler called when the user selects all items.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSelectAll(object sender, EventArgs e)
		{
			// Change the items selection state.
			foreach (ListViewItem item in this.listViewNodes.Items)
			{
				item.Checked = true;
			}
		}

		/// <summary>
		/// An event handler called when the user clears all items.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnClearAll(object sender, EventArgs e)
		{
			// Change the items selection state.
			foreach (ListViewItem item in this.listViewNodes.Items)
			{
				item.Checked = false;
			}
		}

		/// <summary>
		/// An event handler called when a node has been checked.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnNodeChecked(object sender, ItemCheckedEventArgs e)
		{
			// Get the selected node.
			PlNode node = e.Item.Tag as PlNode;
			// If the node does not have an ID, do nothing.
			if (!node.Id.HasValue) return;
			// If the node has been checked.
			if (e.Item.Checked)
			{
				// Add the node ID to the selected nodes.
				this.selectedNodes.Add(node.Id.Value);
			}
			else
			{
				// Else, remove the node ID from the selected nodes.
				this.selectedNodes.Remove(node.Id.Value);
			}
			// Compute the number of selected items.
			int count = this.listViewNodes.CheckedItems.Count;
			// Set the enabled state of the selection buttons.
			this.buttonSelectAll.Enabled = count < this.listViewNodes.Items.Count;
			this.buttonClearAll.Enabled = count > 0;
			// Set the select button enabled state.
			this.wizardPageNode.NextEnabled = this.selectedNodes.Count > 0;
			// Update the status.
			this.labelStatus.Text = "Showing {0} of {1} PlanetLab nodes. {2} node{3} selected.".FormatWith(this.listViewNodes.Items.Count, this.nodes.Count, this.selectedNodes.Count, this.selectedNodes.Count.PluralSuffix());
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
			Pair<PlSite, MapMarker> tag = (Pair<PlSite, MapMarker>)this.listViewSites.SelectedItems[0].Tag;

			// Show the site properties.
			this.formSiteProperties.ShowDialog(this, "Site", tag.First);
		}

		/// <summary>
		/// An event handler called when the user views the properties of the PlanetLab node.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnNodeProperties(object sender, EventArgs e)
		{
			// If there is no selected node item, do nothing.
			if (this.listViewNodes.SelectedItems.Count == 0) return;

			// Get the node for this item.
			PlNode node = this.listViewNodes.SelectedItems[0].Tag as PlNode;

			// Show the node properties.
			this.formNodeProperties.ShowDialog(this, "Node", node);
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
			// If the filter has changed.
			if (this.filterNode != this.textBoxFilterNode.Text.Trim())
			{
				// Update the list.
				this.OnUpdateNodes();
			}
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
			// Disable the button.
			this.wizardPageSite.NextEnabled = false;

			// Update the filter.
			this.filterSite = this.textBoxFilterSite.Text.Trim();

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
						site.SiteId.HasValue ? site.SiteId.Value.ToString() : string.Empty,
						site.Name,
						site.Url,
						site.DateCreated.ToString(),
						site.LastUpdated.ToString(),
						site.Latitude.HasValue ? site.Latitude.Value.LatitudeToString() : string.Empty,
						site.Longitude.HasValue ? site.Longitude.Value.LongitudeToString() : string.Empty
					});
					item.Tag = new Pair<PlSite, MapMarker>(site, marker);
					item.ImageKey = "Site";
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
			this.wizardPageSite.Status = "Showing {0} of {1} PlanetLab sites.".FormatWith(this.listViewNodes.Items.Count, this.sites.Count);
		}

		/// <summary>
		/// Updates the list of PlanetLab nodes.
		/// </summary>
		private void OnUpdateNodes()
		{
			// Clear the list view.
			this.listViewNodes.Items.Clear();
			// Disable the button.
			this.wizardPageNode.NextEnabled = false;

			// Update the filter.
			this.filterNode = this.textBoxFilterNode.Text.Trim();

			// Lock the list.
			this.nodes.Lock();
			try
			{
				// Update the sites list.
				foreach (PlNode node in this.nodes)
				{
					// If the filter is not null or empty.
					if (!string.IsNullOrEmpty(this.filterNode))
					{
						// If the site name does not match the filter, continue.
						if (!string.IsNullOrEmpty(node.Hostname))
						{
							if (!node.Hostname.ToLower().Contains(this.filterNode.ToLower())) continue;
						}
					}

					// Create the list view item.
					ListViewItem item = new ListViewItem(new string[] {
						node.NodeId.HasValue ? node.NodeId.Value.ToString() : string.Empty,
						node.Hostname,
						node.BootState,
						node.Model,
						node.Version,
						node.DateCreated.HasValue ? node.DateCreated.Value.ToString() : string.Empty,
						node.LastUpdated.HasValue ? node.LastUpdated.Value.ToString() : string.Empty,
						node.NodeType
					});
					item.Tag = node;
					item.ImageKey = ControlAddSliceToNodesLocation.nodeImageKeys[(int)node.GetBootState()];
					item.Checked = this.selectedNodes.Contains(node.Id ?? -1);
					this.listViewNodes.Items.Add(item);
				}
			}
			finally
			{
				this.nodes.Unlock();
			}
			// Get the number of checked items.
			int count = this.listViewNodes.CheckedItems.Count;
			// Set the enabled state of the selection buttons.
			this.buttonSelectAll.Enabled = (this.listViewNodes.Items.Count > 0) && (count < this.listViewNodes.Items.Count);
			this.buttonClearAll.Enabled = count > 0;
			// Update the status.
			this.wizardPageNode.Status = "Showing {0} of {1} PlanetLab nodes. {2} node{3} selected.".FormatWith(this.listViewNodes.Items.Count, this.nodes.Count, this.selectedNodes.Count, this.selectedNodes.Count.PluralSuffix());
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
		/// An event handler called when the wizard tab has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnWizardPageChanged(object sender, EventArgs e)
		{
			switch (this.wizard.SelectedIndex)
			{
				case 0:
					// Do nothing.
					break;
				case 1:
					// Refresh the list of PlanetLab nodes.
					this.OnRefreshListNodes();
					break;
			}
		}

		/// <summary>
		/// An event handler called when the wizard has finished.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnWizardFinished(object sender, EventArgs e)
		{
			// If there are no selected nodes, do nothing.
			if (this.selectedNodes.Count == 0) return;
			// Else, get the list of node IDs.
			int[] result = new int[this.selectedNodes.Count];
			this.selectedNodes.CopyTo(result);
			// Raise the event.
			if (this.Selected != null) this.Selected(this, new ArrayEventArgs<int>(result));
		}
	}
}
