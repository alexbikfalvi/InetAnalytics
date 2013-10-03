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
using YtAnalytics.Events;
using YtAnalytics.Forms.PlanetLab;
using YtCrawler;
using PlanetLab;
using PlanetLab.Api;
using PlanetLab.Requests;
using DotNetApi;
using DotNetApi.Web.XmlRpc;

namespace YtAnalytics.Controls.PlanetLab
{
	/// <summary>
	/// A control that receives user input data to add a slice to PlanetLab nodes.
	/// </summary>
	public sealed partial class ControlAddSliceToNodesState : ControlRequest
	{
		public static readonly string[] nodeImageKeys = new string[]
		{
			"NodeUnknown", "NodeBoot", "NodeSafeBoot", "NodeDisabled", "NodeReinstall"
		};

		private readonly PlRequest request = new PlRequest(PlRequest.RequestMethod.GetNodes);
		private PlList<PlNode> nodes = null;
		private string filterHostname = string.Empty;
		private readonly HashSet<int> selected = new HashSet<int>();

		private readonly FormObjectProperties<ControlNodeProperties> formProperties = new FormObjectProperties<ControlNodeProperties>();

		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlAddSliceToNodesState()
		{
			// Initialize the component.
			this.InitializeComponent();
			// Set the filter list items.
			foreach (PlBootState state in Enum.GetValues(typeof(PlBootState)))
			{
				this.stateFilter.AddItem(state, state.GetDisplayName(), CheckState.Checked);
			}
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
		/// An event raised when a PlanetLab node was selected.
		/// </summary>
		public event ArrayEventHandler<int> Selected;
		/// <summary>
		/// An event raised when user closes the selection.
		/// </summary>
		public event EventHandler Closed;

		// Public methods.

		/// <summary>
		/// Refreshes the list of PlanetLab nodes.
		/// </summary>
		/// <param name="config">The crawler config.</param>
		public void Refresh(CrawlerConfig config)
		{
			// Set the nodes.
			this.nodes = config.PlanetLab.Nodes;
			// Clear the filter.
			this.textBoxFilter.Clear();
			this.stateFilter.CheckAll();
			// Clear the button state.
			this.buttonRefresh.Enabled = true;
			this.buttonCancel.Enabled = false;
			this.buttonSelect.Enabled = false;
			this.buttonClose.Enabled = true;
			// Clear the selected nodes.
			this.selected.Clear();
			// If the nodes list is empty.
			if (this.nodes.Count == 0)
			{
				// Begin refreshing the nodes list.
				this.OnRefreshStarted(this, EventArgs.Empty);
			}
			else
			{
				// Update the list view.
				this.OnUpdateList();
			}
		}

		// Protected methods.

		/// <summary>
		/// An event handler called when the current request starts, and the notification box is displayed.
		/// </summary>
		/// <param name="state">The request state.</param>
		protected override void OnRequestStarted(RequestState state)
		{
			// Disable the buttons.
			this.buttonRefresh.Enabled = false;
			this.buttonCancel.Enabled = true;
			this.buttonSelect.Enabled = false;
			this.buttonClose.Enabled = false;
			// Update the label.
			this.labelStatus.Text = "Refreshing...";

			// Raise the PlanetLab request started event.
			if (this.RequestStarted != null) this.RequestStarted(this, EventArgs.Empty);
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
				// Update the list of PlanetLab slices list for the given response.
				this.nodes.Update(response.Value as XmlRpcArray);
				// Update the list view.
				this.OnUpdateList();
			}
			else
			{
				// Update the status.
				this.labelStatus.Text = "Refresh failed. {0}".FormatWith(response.Fault);
			}
		}

		/// <summary>
		/// An event handler called when an asynchronous request for a PlanetLab resource was canceled.
		/// </summary>
		/// <param name="state">The request state.</param>
		protected override void OnRequestCanceled(RequestState state)
		{
			// Update the status.
			this.labelStatus.Text = "Refresh canceled.";
		}

		/// <summary>
		/// An event handler called when the current request throws an exception.
		/// </summary>
		/// <param name="exception">The exception.</param>
		/// <param name="state">The request state.</param>
		protected override void OnRequestException(Exception exception, RequestState state)
		{
			// Update the status.
			this.labelStatus.Text = "Refresh failed.";
		}

		/// <summary>
		/// An event handler called when the current request ends, and the notification box is hidden.
		/// </summary>
		/// <param name="state">The request state.</param>
		protected override void OnRequestFinished(RequestState state)
		{
			// Enable the buttons.
			this.buttonRefresh.Enabled = true;
			this.buttonCancel.Enabled = false;
			this.buttonSelect.Enabled = this.listView.Items.Count > 0;
			this.buttonClose.Enabled = true;
			// Raise the PlanetLab request finished event.
			if (this.RequestFinished != null) this.RequestFinished(this, EventArgs.Empty);
		}

		// Private methods.

		/// <summary>
		/// An event handler called when the user refreshes the list of items.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnRefreshStarted(object sender, EventArgs e)
		{
			// Clear the slices list.
			this.listView.Items.Clear();
			// Begin the PlanetLab request.
			this.BeginRequest(this.request, CrawlerStatic.PlanetLabUsername, CrawlerStatic.PlanetLabPassword);
		}

		/// <summary>
		/// An event handler called when the user chooses an item.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSelect(object sender, EventArgs e)
		{
			// If there is no selected PlanetLab object, do nothing.
			if (this.selected.Count == 0) return;
			// Else, get the list of node IDs.
			int[] result = new int[this.selected.Count];
			this.selected.CopyTo(result);
			// Raise the event.
			if (this.Selected != null) this.Selected(this, new ArrayEventArgs<int>(result));
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
		/// An event handler called when the user views the properties of the PlanetLab object.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnProperties(object sender, EventArgs e)
		{
			// If there is no selected PlanetLab object, do nothing.
			if (this.listView.SelectedItems.Count == 0) return;
			// Show the properties dialog.
			this.formProperties.ShowDialog(this, "Node", this.listView.SelectedItems[0].Tag as PlNode);
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
		/// An event handler called when the hostname filter text has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnHostnameFilterChanged(object sender, EventArgs e)
		{
			// If the filter has changed.
			if (this.filterHostname != this.textBoxFilter.Text.Trim())
			{
				// Update the list.
				this.OnUpdateList();
			}
		}

		/// <summary>
		/// Updates the list of PlanetLab objects.
		/// </summary>
		private void OnUpdateList()
		{
			// Clear the list view.
			this.listView.Items.Clear();

			// Update the filter.
			this.filterHostname = this.textBoxFilter.Text.Trim();

			// Lock the list.
			this.nodes.Lock();
			try
			{
				// Update the nodes list.
				foreach (PlNode node in this.nodes)
				{
					// If the filter is not null or empty.
					if (!string.IsNullOrEmpty(this.filterHostname))
					{
						// If the site name does not match the filter, continue.
						if (!string.IsNullOrEmpty(node.Hostname))
						{
							if (!node.Hostname.ToLower().Contains(this.filterHostname.ToLower())) continue;
						}
					}

					// Get the node boot state.
					PlBootState state = node.GetBootState();

					// If the filter for the node state is checked.
					if (this.stateFilter[(int)state].State == CheckState.Checked)
					{
						// Create the list view item.
						ListViewItem item = new ListViewItem(new string[] {
								node.Id.HasValue ? node.Id.Value.ToString() : string.Empty,
								node.Hostname,
								node.BootState,
								node.Model,
								node.Version,
								node.DateCreated.HasValue ? node.DateCreated.Value.ToString() : string.Empty,
								node.LastUpdated.HasValue ? node.LastUpdated.Value.ToString() : string.Empty,
								node.NodeType
							});
						item.ImageKey = ControlAddSliceToNodesState.nodeImageKeys[(int)state];
						item.Tag = node;
						item.Checked = this.selected.Contains(node.Id ?? -1);

						this.listView.Items.Add(item);
					}
				}
			}
			finally
			{
				this.nodes.Unlock();
			}
			// Update the status.
			this.labelStatus.Text = "Showing {0} of {1} PlanetLab nodes. {2} node{3} selected.".FormatWith(this.listView.Items.Count, this.nodes.Count, this.selected.Count, this.selected.Count == 1 ? string.Empty : "s");
		}

		/// <summary>
		/// An event handler called when the user selected the filter by state context menu.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnFilterState(object sender, EventArgs e)
		{
			if (this.checkBoxFilter.Checked)
			{
				this.stateFilter.Show(this.checkBoxFilter, 0, this.checkBoxFilter.Height);
			}
		}

		/// <summary>
		/// An event handler called when the state filter list has been closed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnStateFilterClosed(object sender, ToolStripDropDownClosedEventArgs e)
		{
			this.checkBoxFilter.Checked = false;
		}

		/// <summary>
		/// An event handler called when the user checks an item in the boot state filter list.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnStateFilterCheck(object sender, ItemCheckEventArgs e)
		{
			// If the nodes list has not been initialized, do nothing.
			if (null == this.nodes) return;
			// Update the nodes list.
			this.OnUpdateList();
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
				this.selected.Add(node.Id.Value);
			}
			else
			{
				// Else, remove the node ID from the selected nodes.
				this.selected.Remove(node.Id.Value);
			}
			// Set the select button enabled state.
			this.buttonSelect.Enabled = this.selected.Count > 0;
			// Update the status.
			this.labelStatus.Text = "Showing {0} of {1} PlanetLab nodes. {2} node{3} selected.".FormatWith(this.listView.Items.Count, this.nodes.Count, this.selected.Count, this.selected.Count == 1 ? string.Empty : "s");
		}
	}
}
