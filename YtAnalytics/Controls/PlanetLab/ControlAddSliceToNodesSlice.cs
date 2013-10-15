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
	/// A control that receives user input data to add a new node to a PlanetLab slice by slice.
	/// </summary>
	public sealed partial class ControlAddSliceToNodesSlice : ControlRequest
	{
		public static readonly string[] nodeImageKeys = new string[]
		{
			"NodeUnknown", "NodeBoot", "NodeSafeBoot", "NodeDisabled", "NodeReinstall"
		};

		private readonly PlRequest requestSlices = new PlRequest(PlRequest.RequestMethod.GetSlices);
		private readonly PlRequest requestNodes = new PlRequest(PlRequest.RequestMethod.GetNodes);
		
		private PlDatabaseList<PlSlice> slices = null;
		private readonly PlList<PlNode> nodes = new PlList<PlNode>();

		private readonly HashSet<int> selectedNodes = new HashSet<int>();

		private string filterSlice = string.Empty;
		private string filterNode = string.Empty;

		private readonly FormObjectProperties<ControlSliceProperties> formSliceProperties = new FormObjectProperties<ControlSliceProperties>();
		private readonly FormObjectProperties<ControlNodeProperties> formNodeProperties = new FormObjectProperties<ControlNodeProperties>();

		private RequestState requestStateSlices;
		private RequestState requestStateNodes;

		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlAddSliceToNodesSlice()
		{
			// Initialize the component.
			this.InitializeComponent();

			// Create the request states.
			this.requestStateSlices = new RequestState(null, this.OnSitesRequestResult, null, null, null);
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
			this.slices = config.PlanetLab.Slices;
			// Clear the list view.
			this.listViewSlices.Items.Clear();
			this.listViewNodes.Items.Clear();
			// Reset the filters.
			this.textBoxFilterSlice.Clear();
			this.textBoxFilterNode.Clear();
			// Reset the wizard.
			this.wizard.SelectedIndex = 0;
			this.wizardPageSlice.NextEnabled = false;
			// Clear the lists.
			this.nodes.Clear();
			this.selectedNodes.Clear();
			// Update the sites.
			this.OnUpdateSlices();
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
					this.wizardPageSlice.Status = "Refreshing the PlanetLab slices was canceled.";
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
					this.wizardPageSlice.Status = "Refreshing the PlanetLab slices failed.";
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
		/// Refreshes the list of PlanetLab slices.
		/// </summary>
		public void OnRefreshListSlices()
		{
			// Clear the list view.
			this.listViewSlices.Items.Clear();
			this.listViewNodes.Items.Clear();
			// Reset the filters.
			this.textBoxFilterSlice.Clear();
			this.textBoxFilterNode.Clear();
			// Clear the lists.
			this.slices.Clear();
			this.nodes.Clear();
			this.selectedNodes.Clear();
			// Disable the selection buttons.
			this.buttonSelectAll.Enabled = false;
			this.buttonClearAll.Enabled = false;
			// Update the status.
			this.wizardPageSlice.Status = "Refreshing the PlanetLab slices...";

			// Begin the PlanetLab sites request.
			this.BeginRequest(
				this.requestSlices,
				CrawlerStatic.PlanetLabUsername,
				CrawlerStatic.PlanetLabPassword,
				null,
				this.requestStateSlices);
		}

		/// <summary>
		/// Refreshes the list of PlanetLab nodes for the selected slice.
		/// </summary>
		public void OnRefreshListNodes()
		{
			// If there is no selected site item, do nothing.
			if (this.listViewSlices.SelectedItems.Count == 0) return;

			// Get the slice for this item.
			PlSlice slice = this.listViewSlices.SelectedItems[0].Tag as PlSlice;

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
				PlNode.GetFilter(PlNode.Fields.NodeId, slice.NodeIds),
				this.requestStateNodes);
		}

		/// <summary>
		/// An event handler called when the control completes an asynchronous request for the list of PlanetLab slices.
		/// </summary>
		/// <param name="response">The XML-RPC response.</param>
		/// <param name="state">The request state.</param>
		private void OnSitesRequestResult(XmlRpcResponse response, RequestState state)
		{
			// If the request has not failed.
			if ((null == response.Fault) && (null != response.Value))
			{
				try
				{
					// Update the list of PlanetLab sites list for the given response.
					this.slices.CopyFrom(response.Value as XmlRpcArray);
					// Update the slices list.
					this.OnUpdateSlices();
				}
				catch
				{
					// Update the status.
					this.wizardPageSlice.Status = "Refreshing the PlanetLab slices failed.";
				}
			}
			else
			{
				// Update the status.
				this.wizardPageSlice.Status = "Refreshing the PlanetLab slices failed. {0}".FormatWith(response.Fault);
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
				try
				{
					// Update the list of PlanetLab nodes list for the given response.
					this.nodes.Update(response.Value as XmlRpcArray);
					// Update the nodes list.
					this.OnUpdateNodes();
				}
				catch
				{
					// Update the status.
					this.wizardPageNode.Status = "Refreshing the PlanetLab nodes failed.";
				}
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
					this.OnRefreshListSlices();
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
		/// An event handler called when the slice selection has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSliceSelectionChanged(object sender, EventArgs e)
		{
			// Update the next button.
			this.wizardPageSlice.NextEnabled = this.listViewSlices.SelectedItems.Count > 0;
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
		/// An event handler called when the user selects to view the slice properties.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSliceProperties(object sender, EventArgs e)
		{
			// If there is no selected slice item, do nothing.
			if (this.listViewSlices.SelectedItems.Count == 0) return;

			// Get the slice for this item.
			PlSlice slice = this.listViewSlices.SelectedItems[0].Tag as PlSlice;

			// Show the site properties.
			this.formSliceProperties.ShowDialog(this, "Slice", slice);
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
		/// An event handler called when the slice filter text has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSliceFilterTextChanged(object sender, EventArgs e)
		{
			// If the filter has changed.
			if (this.filterSlice != this.textBoxFilterSlice.Text.Trim())
			{
				// Update the list.
				this.OnUpdateSlices();
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
		/// Updates the list of PlanetLab slices.
		/// </summary>
		private void OnUpdateSlices()
		{
			// Clear the list view.
			this.listViewSlices.Items.Clear();
			this.listViewNodes.Items.Clear();
			// Disable the button.
			this.wizardPageSlice.NextEnabled = false;

			// Update the filter.
			this.filterSlice = this.textBoxFilterSlice.Text.Trim();

			// Lock the list.
			this.slices.Lock();
			try
			{
				// Update the slices list.
				foreach (PlSlice slice in this.slices)
				{
					// If the filter is not null or empty.
					if (!string.IsNullOrEmpty(this.filterSlice))
					{
						// If the site name does not match the filter, continue.
						if (!string.IsNullOrEmpty(slice.Name))
						{
							if (!slice.Name.ToLower().Contains(this.filterSlice.ToLower())) continue;
						}
					}

					// Create the list view item.
					ListViewItem item = new ListViewItem(new string[] {
						slice.SiteId.HasValue ? slice.SiteId.Value.ToString() : string.Empty,
						slice.Name,
						slice.Description,
						slice.Url,
						slice.Created.HasValue ? slice.Created.Value.ToString() : string.Empty,
						slice.Expires.HasValue ? slice.Expires.Value.ToString() : string.Empty,
						slice.NodeIds != null ? slice.NodeIds.Length.ToString() : "0",
						slice.MaxNodes.HasValue ? slice.MaxNodes.Value.ToString() : "0"
					});
					item.Tag = slice;
					item.ImageKey = "Slice";
					this.listViewSlices.Items.Add(item);
				}
			}
			finally
			{
				this.slices.Unlock();
			}
			// Update the status.
			this.wizardPageSlice.Status = "Showing {0} of {1} PlanetLab slices.".FormatWith(this.listViewSlices.Items.Count, this.slices.Count);
		}

		/// <summary>
		/// Updates the list of PlanetLab nodes.
		/// </summary>
		private void OnUpdateNodes()
		{
			// Clear the list view.
			this.listViewNodes.Items.Clear();

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
					item.Checked = this.selectedNodes.Contains(node.NodeId ?? -1);
					item.Tag = node;
					item.ImageKey = ControlAddSliceToNodesSlice.nodeImageKeys[(int)node.GetBootState()];
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
