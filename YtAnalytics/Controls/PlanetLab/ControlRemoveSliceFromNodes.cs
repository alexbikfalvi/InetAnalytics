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
using DotNetApi.Windows.Controls;

namespace YtAnalytics.Controls.PlanetLab
{
	/// <summary>
	/// A control that receives user input data to remove a slice from a PlanetLab node.
	/// </summary>
	public sealed partial class ControlRemoveSliceFromNodes : ControlRequest
	{
		public static readonly string[] nodeImageKeys = new string[]
		{
			"NodeUnknown", "NodeBoot", "NodeSafeBoot", "NodeDisabled", "NodeReinstall"
		};

		private PlRequest request = new PlRequest(PlRequest.RequestMethod.GetSlices);
		private PlSlice slice = null;

		private bool inhibitAutoCheck = false;

		private Dictionary<int, PlNode> nodes = new Dictionary<int, PlNode>();

		private FormObjectProperties<ControlNodeProperties> formProperties = new FormObjectProperties<ControlNodeProperties>();

		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlRemoveSliceFromNodes()
		{
			// Initialize the component.
			this.InitializeComponent();

			// Set the properties form event handler.
			this.formProperties.ObjectChanged += this.OnNodeUpdated;
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
		/// Refreshes the control using the specified PlanetLab slice.
		/// </summary>
		/// <param name="slice">The slice.</param>
		public void Refresh(PlSlice slice)
		{
			// Set the current slice.
			this.slice = slice;

			// Reset the buttons.
			this.buttonRefresh.Enabled = true;
			this.buttonCancel.Enabled = false;
			this.buttonSelect.Enabled = false;
			this.buttonClose.Enabled = true;

			// Clear the list of nodes.
			this.nodes.Clear();

			// Update the list of nodes.
			this.OnUpdateNodes();
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
				// Get the slices list.
				XmlRpcArray slices = response.Value as XmlRpcArray;

				// If the response list has one element.
				if (null != slices ? slices.Values.Length == 1 : false)
				{
					// Update the slice.
					this.slice.Parse(slices.Values[0].Value as XmlRpcStruct);

					// Update the slice nodes.
					this.OnUpdateNodes();
				}
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
			this.buttonSelect.Enabled = false;
			this.buttonClose.Enabled = true;
			// Raise the PlanetLab request finished event.
			if (this.RequestFinished != null) this.RequestFinished(this, EventArgs.Empty);
		}

		// Private methods.

		/// <summary>
		/// Updates the list of nodes for the current slice.
		/// </summary>
		private void OnUpdateNodes()
		{
			// Clear the slices list.
			this.listView.Items.Clear();
			// Set the select buttons state.
			this.buttonSelectAll.Enabled = this.slice.NodeIds.Length > 0;
			this.buttonClearAll.Enabled = false;

			// Update the list.
			foreach (int id in this.slice.NodeIds)
			{
				ListViewItem item;

				// If there exists a node in the set for the current ID.
				if (this.nodes.ContainsKey(id))
				{
					// Get the PlanetLab node.
					PlNode node = this.nodes[id];
					// Create the item.
					item = new ListViewItem(new string[] {
						id.ToString(),
						node.Hostname,
						node.Model,
						node.BootState,
						node.Version,
						node.DateCreated.HasValue ? node.DateCreated.ToString() : string.Empty,
						node.LastUpdated.HasValue ? node.LastUpdated.ToString() : string.Empty
					});
					item.ImageKey = ControlAddSliceToNodesLocation.nodeImageKeys[(int)node.GetBootState()];
				}
				else
				{
					// Create the item.
					item = new ListViewItem(new string[] { id.ToString(), string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty });
					item.ImageKey = "NodeUnknown";
				}

				// Set item information.
				item.Tag = id;
				item.Checked = false;
				// Add the item.
				this.listView.Items.Add(item);
			}

			// Set the status.
			this.labelStatus.Text = "Selected {0} out of {1} node{2}.".FormatWith(0, this.slice.NodeIds.Length, this.slice.NodeIds.Length == 1 ? string.Empty : "s");
		}

		/// <summary>
		/// An event handler called when the user refreshes the information of the current slice.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnRefresh(object sender, EventArgs e)
		{
			// Begin the PlanetLab request.
			this.BeginRequest(
				this.request,
				CrawlerStatic.PlanetLabUsername,
				CrawlerStatic.PlanetLabPassword,
				PlSlice.GetFilter(PlSlice.Fields.SliceId, this.slice.Id));
		}

		/// <summary>
		/// An event handler called when the user chooses an item.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSelect(object sender, EventArgs e)
		{
			// Get the list of checked list view items.
			IList<ListViewItem> checkedItems = this.listView.Items.Checked();
			// If there are no selected items, do nothing.
			if (checkedItems.Count == 0) return;
			// Create a new array with the node IDs.
			int[] result = new int[checkedItems.Count];
			// Update the IDs list.
			for (int index = 0; index < checkedItems.Count; index++)
			{
				if (checkedItems[index].Tag is int) result[index] = (int)checkedItems[index].Tag;
				else result[index] = -1;
			}
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
			// Get the selected item.
			ListViewItem item = this.listView.SelectedItems[0];
			// If the item tag is an integer.
			if (item.Tag is int)
			{
				// Show the properties dialog.
				this.formProperties.ShowDialog(this, "Node", (int)item.Tag);
			}
			else if (item.Tag is PlNode)
			{
				// Show the properties dialog.
				this.formProperties.ShowDialog(this, "Node", item.Tag as PlNode);
			}
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
		/// An event handler called when the user selects all items.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSelectAll(object sender, EventArgs e)
		{
			// Change the items selection state.
			foreach (ListViewItem item in this.listView.Items)
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
			foreach (ListViewItem item in this.listView.Items)
			{
				item.Checked = false;
			}
		}

		/// <summary>
		/// An event handler called before the checked state of an item has changed.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCheckChanged(object sender, ItemCheckEventArgs e)
		{
			// If autocheck is inhibited, reset the check state.
			if (this.inhibitAutoCheck)
			{
				e.NewValue = e.CurrentValue;
			}
		}

		/// <summary>
		/// An event handler called when the checked state of an item has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnCheckedChanged(object sender, ItemCheckedEventArgs e)
		{
			// Count the number of selected items.
			int count = this.listView.CheckedItems.Count;
			// Change the select buttons enabled state.
			this.buttonSelectAll.Enabled = count < slice.NodeIds.Length;
			this.buttonClearAll.Enabled = count > 0;
			this.buttonSelect.Enabled = count > 0;
			// Set the status.
			this.labelStatus.Text = "Selected {0} out of {1} node{2}.".FormatWith(count, slice.NodeIds.Length, this.slice.NodeIds.Length == 1 ? string.Empty : "s");
		}

		/// <summary>
		/// An event handler called when the mouse button is pressed on the list view.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnListMouseDown(object sender, MouseEventArgs e)
		{
			// Inhibit the autocheck.
			this.inhibitAutoCheck = true;
		}

		/// <summary>
		/// An event handler called when the mouse button is released on the list view.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnListMouseUp(object sender, MouseEventArgs e)
		{
			// Inhibit the autocheck.
			this.inhibitAutoCheck = false;
		}

		/// <summary>
		/// An event handler called when the information for a node is updated.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnNodeUpdated(object sender, EventArgs e)
		{
			// Get the updated node.
			PlNode node = this.formProperties.Object as PlNode;

			// If the updated object is null, do nothing.
			if (null == node) return;

			// Add the node to the nodes set.
			if (node.Id.HasValue)
			{
				this.nodes.Add(node.Id.Value, node);
			}

			// Get the list view item corresponding to the node.
			ListViewItem item = this.listView.Items.FirstOrDefault((ListViewItem it) =>
				{
					if (it.Tag is int) return ((int)it.Tag) == node.Id;
					else return false;
				});

			// If the item is null, do nothing.
			if (null == item) return;

			// Else, update the item.
			item.SubItems[1].Text = node.Hostname;
			item.SubItems[2].Text = node.Model;
			item.SubItems[3].Text = node.BootState;
			item.SubItems[4].Text = node.Version;
			item.SubItems[5].Text = node.DateCreated.HasValue ? node.DateCreated.ToString() : string.Empty;
			item.SubItems[6].Text = node.LastUpdated.HasValue ? node.LastUpdated.ToString() : string.Empty;
			item.ImageKey = ControlAddSliceToNodesLocation.nodeImageKeys[(int)node.GetBootState()];
		}
	}
}
