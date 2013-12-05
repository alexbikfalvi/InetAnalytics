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
using InetAnalytics.Forms.PlanetLab;
using InetCrawler;
using InetCrawler.Log;
using InetCrawler.Status;

namespace InetAnalytics.Controls.PlanetLab
{
	/// <summary>
	/// A control class for PlanetLab nodes.
	/// </summary>
	public sealed partial class ControlNodes : ControlRequest
	{
		public static readonly string[] nodeImageKeys = new string[]
		{
			"NodeUnknown", "NodeBoot", "NodeSafeBoot", "NodeDisabled", "NodeReinstall"
		};

		private static readonly string logSource = "PlanetLab";

		// Private variables.

		private Crawler crawler = null;
		private CrawlerStatusHandler status = null;

		private readonly PlRequest request = new PlRequest(PlRequest.RequestMethod.GetNodes);
		
		private string filter = string.Empty;

		private readonly FormObjectProperties<ControlNodeProperties> formNodeProperties = new FormObjectProperties<ControlNodeProperties>();
		private readonly FormExport formExport = new FormExport();
		private readonly FormExportNodes formExportNodes = new FormExportNodes();

		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlNodes()
		{
			// Initialize component.
			InitializeComponent();

			// Set the default control properties.
			this.Visible = false;
			this.Dock = DockStyle.Fill;

			// Set the filter list items.
			foreach (PlBootState state in Enum.GetValues(typeof(PlBootState)))
			{
				this.stateFilter.AddItem(state, state.GetDisplayName(), CheckState.Checked);
			}
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

			// Set the node list event handler.
			this.crawler.PlanetLab.Nodes.Cleared += this.OnNodesCleared;
			this.crawler.PlanetLab.Nodes.Updated += this.OnNodesUpdated;
			this.crawler.PlanetLab.Nodes.Added += this.OnNodesAdded;
			this.crawler.PlanetLab.Nodes.Removed += this.OnNodesRemoved;

			// Get the status handler.
			this.status = this.crawler.Status.GetHandler(this);
		
			// Enable the control.
			this.Enabled = true;

			// Update the list of PlanetLab nodes.
			this.OnNodesUpdated(this, EventArgs.Empty);
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
					// Update the list of PlanetLab nodes.
					this.crawler.PlanetLab.Nodes.CopyFrom(response.Value as XmlRpcArray);

					// Log
					this.crawler.Log.Add(
						LogEventLevel.Verbose,
						LogEventType.Success,
						ControlNodes.logSource,
						"Refreshing the list of PlanetLab nodes completed successfully.");
				}
				catch
				{
					// Log
					this.crawler.Log.Add(
						LogEventLevel.Important,
						LogEventType.Error,
						ControlNodes.logSource,
						"Refreshing the list of PlanetLab nodes failed.");
				}
			}
			else
			{
				// Update the status.
				this.status.Send(CrawlerStatus.StatusType.Normal, "Refreshing the list of PlanetLab nodes failed.", Resources.GlobeError_16);
				if (null == response.Fault)
				{
					// Log
					this.crawler.Log.Add(
						LogEventLevel.Important,
						LogEventType.Error,
						ControlNodes.logSource,
						"Refreshing the list of PlanetLab nodes failed.");
				}
				else
				{
					// Log
					this.crawler.Log.Add(
						LogEventLevel.Important,
						LogEventType.Error,
						ControlNodes.logSource,
						"Refreshing the list of PlanetLab nodes failed with code {0} ({1}).",
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
			this.status.Send(CrawlerStatus.StatusType.Normal, "Refreshing the list of PlanetLab nodes was canceled.", Resources.GlobeCanceled_16);
			// Log
			this.crawler.Log.Add(
				LogEventLevel.Verbose,
				LogEventType.Canceled,
				ControlNodes.logSource,
				"Refreshing the list of PlanetLab nodes was canceled.");
		}

		/// <summary>
		/// An event handler called when the current request throws an exception.
		/// </summary>
		/// <param name="exception">The exception.</param>
		/// <param name="state">The request state.</param>
		protected override void OnRequestException(Exception exception, RequestState state)
		{
			// Update the status.
			this.status.Send(CrawlerStatus.StatusType.Normal, "Refreshing the list of PlanetLab nodes failed.", Resources.GlobeError_16);
			// Log
			this.crawler.Log.Add(
				LogEventLevel.Important,
				LogEventType.Error,
				ControlNodes.logSource,
				"Refreshing the list of PlanetLab nodes failed. {0}",
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
		/// An event handler called when the node has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnNodeChanged(object sender, PlObjectEventArgs e)
		{
			// Get the node.
			PlNode node = e.Object as PlNode;
			// Find the list view item corresponding to the node.
			ListViewItem item = this.listViewNodes.Items.FirstOrDefault((ListViewItem it) =>
			{
				// Return true if the item corresponds to the same node.
				return object.ReferenceEquals(node, it.Tag);
			});
			// If the item is not null.
			if (null != item)
			{
				// Update the item.
				item.SubItems[0].Text = node.Id.HasValue ? node.Id.Value.ToString() : string.Empty;
				item.SubItems[1].Text = node.Hostname;
				item.SubItems[2].Text = node.BootState;
				item.SubItems[3].Text = node.Model;
				item.SubItems[4].Text = node.Version;
				item.SubItems[5].Text = node.DateCreated.HasValue ? node.DateCreated.Value.ToString() : string.Empty;
				item.SubItems[6].Text = node.LastUpdated.HasValue ? node.LastUpdated.Value.ToString() : string.Empty;
				item.SubItems[7].Text = node.NodeType;
				item.ImageKey = ControlNodes.nodeImageKeys[(int)node.GetBootState()];
			}
		}

		/// <summary>
		/// An event handler called when the list of PlanetLab nodes has been cleared.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnNodesCleared(object sender, EventArgs e)
		{
			// For all items.
			foreach (ListViewItem item in this.listViewNodes.Items)
			{
				// Get the node.
				PlNode node = item.Tag as PlNode;
				// Remove the node changed event handler.
				node.Changed -= this.OnNodeChanged;
			}
			// Clear the list view.
			this.listViewNodes.Items.Clear();

			// Update the label.
			this.status.Send(CrawlerStatus.StatusType.Normal,
				"Showing {0} of {1} PlanetLab node{2}.".FormatWith(
				this.listViewNodes.Items.Count,
				this.crawler.PlanetLab.Nodes.Count,
				this.crawler.PlanetLab.Nodes.Count.PluralSuffix()), Resources.GlobeLab_16);
		}

		/// <summary>
		/// An event handler called when the list of PlanetLab nodes has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnNodesUpdated(object sender, EventArgs e)
		{
			// Lock the nodes.
			this.crawler.PlanetLab.Nodes.Lock();
			try
			{
				// Add the list view items.
				foreach (PlNode node in this.crawler.PlanetLab.Nodes)
				{
					// If the filter is not null or empty.
					if (!string.IsNullOrEmpty(this.filter))
					{
						// If the node name does not match the filter, continue.
						if (!string.IsNullOrEmpty(node.Hostname))
						{
							if (this.menuItemInvertFilter.Checked ^ (!node.Hostname.ToLower().Contains(this.filter.ToLower()))) continue;
						}
					}

					// If the filter for the node state is checked.
					if (this.stateFilter[(int)node.GetBootState()].State == CheckState.Checked)
					{
						// Add a node.
						this.OnAddNode(node);
					}
				}
			}
			finally
			{
				this.crawler.PlanetLab.Nodes.Unlock();
			}

			// Update the label.
			this.status.Send(
				CrawlerStatus.StatusType.Normal,
				"Showing {0} of {1} PlanetLab node{2}.".FormatWith(
				this.listViewNodes.Items.Count,
				this.crawler.PlanetLab.Nodes.Count,
				this.crawler.PlanetLab.Nodes.Count.PluralSuffix()),
				Resources.GlobeLab_16);
		}

		/// <summary>
		/// An event handler called when a new node has been added.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnNodesAdded(object sender, PlObjectEventArgs<PlNode> e)
		{
			// The filter flag.
			bool filterFlag = false;

			// If the filter is not null or empty.
			if (!string.IsNullOrEmpty(this.filter))
			{
				// If the node name does not match the filter, return.
				if (!string.IsNullOrEmpty(e.Object.Hostname))
				{
					filterFlag = !e.Object.Hostname.ToLower().Contains(this.filter.ToLower());
				}
			}

			// If the node is not filtered.
			if (!filterFlag)
			{
				// Add the node.
				this.OnAddNode(e.Object);
			}

			// Update the label.
			this.status.Send(
				CrawlerStatus.StatusType.Normal,
				"Showing {0} of {1} PlanetLab node{2}.".FormatWith(
				this.listViewNodes.Items.Count,
				this.crawler.PlanetLab.Nodes.Count,
				this.crawler.PlanetLab.Nodes.Count.PluralSuffix()), Resources.GlobeLab_16);
		}

		/// <summary>
		/// An event handler called when a node has been removed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnNodesRemoved(object sender, PlObjectEventArgs<PlNode> e)
		{
			// Get the list view item containing the node.
			ListViewItem item = this.listViewNodes.Items.FirstOrDefault((ListViewItem it) =>
				{
					// Get the item tag.
					Pair<PlNode, MapMarker> tag = (Pair<PlNode, MapMarker>)it.Tag;
					// Return true if the tag node matches the current node.
					return object.ReferenceEquals(tag.First, e.Object);
				});
			// If the item is not null.
			if (null != item)
			{
				// Get the node.
				PlNode node = item.Tag as PlNode;
				// Remove the node changed event handler.
				node.Changed -= this.OnNodeChanged;
				// Remove the item.
				this.listViewNodes.Items.Remove(item);
			}
		}

		/// <summary>
		/// An event handler called when disposing the list of nodes.
		/// </summary>
		private void OnDisposeNodes()
		{
			// For all items.
			foreach (ListViewItem item in this.listViewNodes.Items)
			{
				// Get the node.
				PlNode node = item.Tag as PlNode;
				// Remove the node changed event handler.
				node.Changed -= this.OnNodeChanged;
			}
		}

		/// <summary>
		/// Adds a node to the node list.
		/// </summary>
		/// <param name="node">The node.</param>
		private void OnAddNode(PlNode node)
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
			item.ImageKey = ControlNodes.nodeImageKeys[(int)node.GetBootState()];
			item.Tag = node;
			this.listViewNodes.Items.Add(item);

			// Add the node event handler.
			node.Changed += this.OnNodeChanged;
		}

		/// <summary>
		/// An event handler called when the user refreshes the list of PlanetLab nodes.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnRefresh(object sender, EventArgs e)
		{
			// Clear the current list of nodes.
			this.crawler.PlanetLab.Nodes.Clear();

			// Update the status.
			this.status.Send(CrawlerStatus.StatusType.Busy, "Refreshing the list of PlanetLab nodes...", Resources.GlobeClock_16);
			// Log
			this.crawler.Log.Add(
				LogEventLevel.Verbose,
				LogEventType.Information,
				ControlNodes.logSource,
				"Refreshing the list of PlanetLab nodes.");

			// Begin an asynchronous PlanetLab request.
			this.BeginRequest(
				this.request,
				this.crawler.PlanetLab.Username,
				this.crawler.PlanetLab.Password);
		}

		/// <summary>
		/// An event handler called when the user cancels the refresh of PlanetLab nodes.
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
		/// An event handler called when the node selection has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSelectionChanged(object sender, EventArgs e)
		{
			// If no node is selected.
			if (this.listViewNodes.SelectedItems.Count == 0)
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
			}
		}

		/// <summary>
		/// An event handler called when the user selects to view the node properties.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnProperties(object sender, EventArgs e)
		{
			// If there is no selected node item, do nothing.
			if (this.listViewNodes.SelectedItems.Count == 0) return;
	
			// Show the node properties.
			this.formNodeProperties.ShowDialog(this, "Node", this.listViewNodes.SelectedItems[0].Tag as PlNode);
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
				// Clear the nodes.
				this.OnNodesCleared(sender, e);
				// Update the nodes.
				this.OnNodesUpdated(sender, e);
			}
		}

		/// <summary>
		/// An event handler called when the filter has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnFilterChanged(object sender, EventArgs e)
		{
			// Clear the nodes.
			this.OnNodesCleared(sender, e);
			// Update the nodes.
			this.OnNodesUpdated(sender, e);
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
		/// An event handler called when the user clicks on the list view.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnMouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				if (this.listViewNodes.FocusedItem != null)
				{
					if (this.listViewNodes.FocusedItem.Bounds.Contains(e.Location))
					{
						this.contextMenu.Show(this.listViewNodes, e.Location);
					}
				}
			}
		}

		/// <summary>
		/// An event handler called when the user checks an item in the boot state filter list.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnStateFilterCheck(object sender, ItemCheckEventArgs e)
		{
			// If the crawler has not been initialized, do nothing.
			if (null == this.crawler) return;
			// Clear the nodes.
			this.OnNodesCleared(sender, e);
			// Update the nodes.
			this.OnNodesUpdated(sender, e);
		}

		/// <summary>
		/// An event handler called when exporting the nodes list as a CSV file.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnExportListCsv(object sender, EventArgs e)
		{
			// Lock the nodes.
			this.crawler.PlanetLab.Nodes.Lock();
			try
			{
				// Show the export dialog.
				this.formExport.ShowDialog<PlNode>(this, typeof(PlNode.Fields), this.crawler.PlanetLab.Nodes);
			}
			finally
			{
				// Unlock the nodes.
				this.crawler.PlanetLab.Nodes.Unlock();
			}
		}

		/// <summary>
		/// An event handler called when exporting the list of nodes IP addresses.
		/// </summary>
		/// <param name="sender">The sender objects.</param>
		/// <param name="e">The event arguments.</param>
		private void OnExportListIp(object sender, EventArgs e)
		{
			// Lock the nodes.
			this.crawler.PlanetLab.Nodes.Lock();
			try
			{
				// Show the export dialog.
				this.formExportNodes.ShowDialog(this, this.crawler.PlanetLab.Nodes);
			}
			finally
			{
				// Unlock the nodes.
				this.crawler.PlanetLab.Nodes.Unlock();
			}
		}
	}
}
