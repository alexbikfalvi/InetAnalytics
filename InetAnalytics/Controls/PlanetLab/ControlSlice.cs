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
using System.IO;
using System.Text;
using System.Windows.Forms;
using DotNetApi;
using DotNetApi.IO;
using DotNetApi.Web;
using DotNetApi.Web.XmlRpc;
using DotNetApi.Windows.Controls;
using PlanetLab;
using PlanetLab.Api;
using PlanetLab.Requests;
using InetAnalytics.Controls.Net.Ssh;
using InetAnalytics.Events;
using InetAnalytics.Forms;
using InetAnalytics.Forms.PlanetLab;
using InetCrawler;
using InetCrawler.PlanetLab;
using InetCrawler.Status;
using MapApi;

namespace InetAnalytics.Controls.PlanetLab
{
	/// <summary>
	/// A control class for PlanetLab slice.
	/// </summary>
	public sealed partial class ControlSlice : ControlRequest
	{
		public static readonly string[] nodeImageKeys = new string[]
		{
			"NodeUnknown", "NodeBoot", "NodeSafeBoot", "NodeDisabled", "NodeReinstall"
		};

		/// <summary>
		/// A class representing the node information.
		/// </summary>
		private sealed class NodeInfo
		{
			/// <summary>
			/// Creates a new node info instance for the specified node.
			/// </summary>
			/// <param name="nodeId">The node identifier.</param>
			/// <param name="siteId">The site identifier.</param>
			/// <param name="node">The PlanetLab node.</param>
			/// <param name="site">The PlanetLab site.</param>
			/// <param name="marker">The map marker.</param>
			public NodeInfo(int nodeId, int? siteId, PlNode node, PlSite site, MapMarker marker)
			{
				this.NodeId = nodeId;
				this.SiteId = siteId;
				this.Node = node;
				this.Site = site;
				this.Marker = marker;
			}

			// Public fields.

			/// <summary>
			/// The node identifier.
			/// </summary>
			public readonly int NodeId;
			/// <summary>
			/// The site identifier.
			/// </summary>
			public int? SiteId;
			/// <summary>
			/// A field representing the PlanetLab node.
			/// </summary>
			public PlNode Node = null;
			/// <summary>
			/// A field representing the PlanetLab site.
			/// </summary>
			public PlSite Site = null;
			/// <summary>
			/// A field representing the map marker.
			/// </summary>
			public MapMarker Marker = null;
			/// <summary>
			/// A field representing the console tree node, if any.
			/// </summary>
			public TreeNode ConsoleNode = null;
			/// <summary>
			/// A field representing the console control, if any.
			/// </summary>
			public ControlSession ConsoleControl = null;
		}

		/// <summary>
		/// A class representing the identifiers request state.
		/// </summary>
		private class IdsRequestState : RequestState
		{
			/// <summary>
			/// Creates a new request state instance.
			/// </summary>
			/// <param name="actionRequestStarted">The request started action.</param>
			/// <param name="actionRequestResult">The request result action.</param>
			/// <param name="actionRequestCanceled">The request canceled action.</param>
			/// <param name="actionRequestException">The request exception action.</param>
			/// <param name="actionRequestFinished">The request finished action.</param>
			/// <param name="ids">The IDs.</param>
			public IdsRequestState(
				Action<RequestState> actionRequestStarted,
				Action<XmlRpcResponse, RequestState> actionRequestResult,
				Action<RequestState> actionRequestCanceled,
				Action<Exception, RequestState> actionRequestException,
				Action<RequestState> actionRequestFinished,
				int[] ids
				)
				: base(actionRequestStarted, actionRequestResult, actionRequestCanceled, actionRequestException, actionRequestFinished)
			{
				this.Ids = ids;
			}

			/// <summary>
			/// Gets the PlanetLab Ids corresponding to this request.
			/// </summary>
			public int[] Ids { get; private set; }
		}

		// Private variables.

		private Crawler crawler = null;
		private CrawlerStatusHandler status = null;

		private PlSlice slice = null;
		private PlConfigSlice config = null;

		private MapMarker marker = null;

		private Control.ControlCollection controls = null;

		private TreeNode treeNodeSlice = null;
		private TreeNode treeNodeTasks = null;

		private readonly object pendingSync = new object();
		private readonly List<int> pendingNodes = new List<int>();
		private readonly List<int> pendingSites = new List<int>();

		private readonly PlRequest requestGetSlices = new PlRequest(PlRequest.RequestMethod.GetSlices);
		private readonly PlRequest requestGetNodes = new PlRequest(PlRequest.RequestMethod.GetNodes);
		private readonly PlRequest requestGetSites = new PlRequest(PlRequest.RequestMethod.GetSites);
		private readonly PlRequest requestAddSliceToNodes = new PlRequest(PlRequest.RequestMethod.AddSliceToNodes);
		private readonly PlRequest requestRemoveSliceFromNodes = new PlRequest(PlRequest.RequestMethod.DeleteSliceFromNodes);

		private readonly FormText formText = new FormText();
		private readonly FormObjectProperties<ControlNodeProperties> formNodeProperties = new FormObjectProperties<ControlNodeProperties>();
		private readonly FormObjectProperties<ControlSiteProperties> formSiteProperties = new FormObjectProperties<ControlSiteProperties>();

		private readonly FormAddSliceToNodesLocation formAddSliceToNodesLocation = new FormAddSliceToNodesLocation();
		private readonly FormAddSliceToNodesState formAddSliceToNodesState = new FormAddSliceToNodesState();
		private readonly FormAddSliceToNodesSlice formAddSliceToNodesSlice = new FormAddSliceToNodesSlice();
		private readonly FormRenewSlice formRenewSlice = new FormRenewSlice();

		private readonly RequestState requestStateGetSlice;

		// Public declarations

		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlSlice()
		{
			// Initialize component.
			InitializeComponent();

			// Set the default control properties.
			this.Visible = false;
			this.Dock = DockStyle.Fill;

			// Load the map.
			this.mapControl.LoadMap("Ne110mAdmin0Countries");

			// Create the get slices request state.
			this.requestStateGetSlice = new RequestState(
				null,
				this.OnRefreshSliceRequestResult,
				this.OnRefreshSliceRequestCanceled,
				this.OnRefreshSliceRequestException,
				null);
		}

		// Public events.

		/// <summary>
		/// An event raised when a console is selected.
		/// </summary>
		//public event PageSelectionEventHandler ConsoleSelected;

		// Public methods.

		/// <summary>
		/// Initializes the control with a crawler object.
		/// </summary>
		/// <param name="crawler">The crawler object.</param>
		/// <param name="slice">The slice.</param>
		/// <param name="controls">The controls collection.</param>
		/// <param name="treeNode">The tree node corresponding to this control.</param>
		public void Initialize(Crawler crawler, PlSlice slice, Control.ControlCollection controls, TreeNode treeNode)
		{
			// Save the parameters.
			this.crawler = crawler;

			// Get the status handler.
			this.status = this.crawler.Status.GetHandler(this);

			// Set the slice.
			this.slice = slice;
			this.slice.Changed += this.OnSliceChanged;

			// Set the controls.
			this.controls = controls;

			// Set the tree node.
			this.treeNodeSlice = treeNode;

			// Set the slice configuration.
			this.config = this.crawler.PlanetLab.GetSliceConfiguration(this.slice);

			// Set the title.
			this.panelSlice.Title = "PlanetLab Slice ({0})".FormatWith(this.slice.Name);

			// Enable the control.
			this.Enabled = true;

			// Update the information of the PlanetLab slice.
			this.OnUpdateSlice();

			// Create the tasks.
			this.OnCreateTasks();
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
			this.buttonAddToNodes.Enabled = false;
			this.buttonRemoveFromNodes.Enabled = false;
			this.buttonSetKey.Enabled = false;
			this.buttonConnect.Enabled = false;
			this.buttonDisconnect.Enabled = false;
			this.buttonProperties.Enabled = false;
			this.menuItemConnect.Enabled = false;
			this.menuItemDisconnect.Enabled = false;
			this.menuItemNodeProperties.Enabled = false;
			this.menuItemSiteProperties.Enabled = false;
			// Disable the nodes list view.
			this.listViewNodes.Enabled = false;
			// Call the base class method.
			base.OnRequestStarted(state);
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
			this.buttonAddToNodes.Enabled = true;
			this.buttonSetKey.Enabled = true;
			// Call the node selection changed event handler.
			this.OnNodeSelectionChanged(this, EventArgs.Empty);
			// Enable the nodes list view.
			this.listViewNodes.Enabled = true;
			// Call the base class method.
			base.OnRequestFinished(state);
		}

		// Private methods.

		/// <summary>
		/// Updates the information of the current PlanetLab slice.
		/// </summary>
		private void OnUpdateSlice()
		{
			// Set the slice information.
			this.textBoxName.Text = this.slice.Name;
			this.textBoxDescription.Text = this.slice.Description;
			this.textBoxUrl.Text = this.slice.Url;

			this.textBoxCreated.Text = this.slice.Created.HasValue ? this.slice.Created.Value.ToString() : string.Empty;
			this.textBoxExpires.Text = this.slice.Expires.HasValue ? this.slice.Expires.Value.ToString() : string.Empty;
			this.textBoxMaxNodes.Text = this.slice.MaxNodes.HasValue ? this.slice.MaxNodes.Value.ToString() : string.Empty;

			// Update the list of nodes.
			this.OnUpdateNodes();

			// Update the label.
			this.status.Send(CrawlerStatus.StatusType.Normal, @"Slice '{0}' has {1} node{2}.".FormatWith(this.slice.Name, this.slice.NodeIds.Length, this.slice.NodeIds.Length.PluralSuffix()), Resources.GlobeLab_16);
		}

		/// <summary>
		/// Updates the list of slice nodes.
		/// </summary>
		private void OnUpdateNodes()
		{
			// Clear the current nodes.
			this.OnClearNodes();

			// Synchronize access to the pending lists.
			lock (this.pendingSync)
			{
				// Clear the list of pending nodes.
				this.pendingNodes.Clear();
				this.pendingSites.Clear();

				// Add the list of nodes.
				foreach (int nodeId in this.slice.NodeIds)
				{
					// The node.
					PlNode node = this.crawler.PlanetLab.DbNodes.Find(nodeId);
					// The site identifier.
					int? siteId = null;
					// The site.
					PlSite site = null;

					// If the node is not null.
					if (null != node)
					{
						// Get the site identifier.
						siteId = node.SiteId;
						// Add a node event handler.
						node.Changed += this.OnNodeChanged;

						// If the node has a site identifier.
						if (node.SiteId.HasValue)
						{
							// Get the site from the database.
							site = this.crawler.PlanetLab.DbSites.Find(node.SiteId.Value);
							// If the site is not null.
							if (null != site)
							{
								// Add a site event handler.
								site.Changed += this.OnSiteChanged;
							}
							else
							{
								// Add the site to the pending sites.
								this.pendingSites.Add(node.SiteId.Value);
							}
						}
					}
					else
					{
						// Add the node ID to the pending list.
						this.pendingNodes.Add(nodeId);
					}

					// Create a new geo marker for this site.
					MapMarker marker = null;
					if (null != site)
					{
						// If the site has coordinates.
						if (site.Latitude.HasValue && site.Longitude.HasValue)
						{
							// Create a circular marker.
							marker = new MapBulletMarker(new MapPoint(site.Longitude.Value, site.Latitude.Value));
							marker.Name = "{0}{1}{2}".FormatWith(node.Hostname, Environment.NewLine, site.Name);
							// Add the marker to the map.
							this.mapControl.Markers.Add(marker);
						}
					}

					// Create the node information.
					NodeInfo info = new NodeInfo(nodeId, siteId, node, site, marker);

					// Create a list item.
					ListViewItem item = new ListViewItem(new string[] {
						nodeId.ToString(),
						node != null ? node.Hostname : string.Empty,
						ControlSsh.ClientState.Disconnected.ToString()
					});
					item.ImageKey = node != null ? ControlSlice.nodeImageKeys[(int)node.GetBootState()] : ControlSlice.nodeImageKeys[0];
					item.Tag = info;

					// Add the list item.
					this.listViewNodes.Items.Add(item);

					// If the marker is not null, set the marker tag.
					if (null != marker)
					{
						marker.Tag = item;
					}
				}

				// Refresh the pending nodes and sites.
				if (this.pendingNodes.Count > 0)
				{
					this.OnRefreshNodes();
				}
				else if (this.pendingSites.Count > 0)
				{
					this.OnRefreshSites();
				}
			}
		}

		/// <summary>
		/// An event handler called when the current slice has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSliceChanged(object sender, PlObjectEventArgs e)
		{
			// Update the slice information.
			this.OnUpdateSlice();
		}

		/// <summary>
		/// An event handler called when a PlanetLab node has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnNodeChanged(object sender, PlObjectEventArgs e)
		{
			// Get the node.
			PlNode node = e.Object as PlNode;
			// Get the list item corresponding to the selected node.
			ListViewItem item = this.listViewNodes.Items.FirstOrDefault((ListViewItem it) =>
				{
					// Get the node info.
					NodeInfo info = it.Tag as NodeInfo;
					// Check the tag node equals the current node.
					return info.NodeId == node.Id;
				});
			// Update the item information.
			if (null != item)
			{
				// Get the node information.
				NodeInfo info = item.Tag as NodeInfo;

				// Set the item information.
				item.SubItems[0].Text = node.Id.Value.ToString();
				item.SubItems[1].Text = node.Hostname;
				item.ImageKey = ControlSlice.nodeImageKeys[(int)node.GetBootState()];
			}
		}

		/// <summary>
		/// An event handler called when a PlanetLab site has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSiteChanged(object sender, PlObjectEventArgs e)
		{
			// Get the site.
			PlSite site = e.Object as PlSite;
			// Get the list item corresponding to the selected node.
			ListViewItem item = this.listViewNodes.Items.FirstOrDefault((ListViewItem it) =>
			{
				// Get the node info.
				NodeInfo info = it.Tag as NodeInfo;
				// Check the tag node equals the current node.
				return object.ReferenceEquals(info.Site, site);
			});
			// Update the item information.
			if (null != item)
			{
				// Get the node information.
				NodeInfo info = item.Tag as NodeInfo;

				// If the marker is not null.
				if (null != info.Marker)
				{
					// Update the marker location.
					info.Marker.Location = new MapPoint(site.Longitude.Value, site.Latitude.Value);
				}
				else
				{
					// If the site has coordinates.
					if (site.Latitude.HasValue && site.Longitude.HasValue)
					{
						// Create a circular marker.
						info.Marker = new MapBulletMarker(new MapPoint(site.Longitude.Value, site.Latitude.Value));
						info.Marker.Name = "{0}{1}{2}".FormatWith(info.Node.Hostname, Environment.NewLine, site.Name);
						// Add the marker to the map.
						this.mapControl.Markers.Add(marker);
					}
				}
			}
		}

		/// <summary>
		/// An event handler called when clearing the list of nodes.
		/// </summary>
		private void OnClearNodes()
		{
			// Disable the node buttons.
			this.buttonConnect.Enabled = false;
			this.buttonDisconnect.Enabled = false;
			this.buttonProperties.Enabled = false;
			this.menuItemConnect.Enabled = false;
			this.menuItemDisconnect.Enabled = false;
			this.menuItemNodeProperties.Enabled = false;
			this.menuItemSiteProperties.Enabled = false;

			// Clear the map markers.
			this.mapControl.Markers.Clear();

			// For all node items.
			foreach (ListViewItem item in this.listViewNodes.Items)
			{
				// Get the node info.
				NodeInfo info = item.Tag as NodeInfo;
				// Remove the event handlers.
				if (info.Node != null)
				{
					info.Node.Changed -= this.OnNodeChanged;
				}
				if (info.Site != null)
				{
					info.Site.Changed -= this.OnSiteChanged;
				}
				// Dispose the map marker.
				if (info.Marker != null)
				{
					info.Marker.Dispose();
				}
				// Close the control.
				if (info.ConsoleControl != null)
				{
					// Get the console control.
					ControlSession control = info.ConsoleControl;
					// Close the control.
					this.OnConsoleClose(item);
				}
			}

			// Clear the list.
			this.listViewNodes.Items.Clear();
		}

		/// <summary>
		/// An event handler called when disposing the list of nodes.
		/// </summary>
		private void OnDisposeNodes()
		{
			// For all node items.
			foreach (ListViewItem item in this.listViewNodes.Items)
			{
				// Get the node info.
				NodeInfo info = item.Tag as NodeInfo;
				// Remove the event handlers.
				if (info.Node != null)
				{
					info.Node.Changed -= this.OnNodeChanged;
				}
				if (info.Site != null)
				{
					info.Site.Changed -= this.OnSiteChanged;
				}
				// Dispose the map marker.
				if (info.Marker != null)
				{
					info.Marker.Dispose();
				}
				// Close the control.
				if (info.ConsoleControl != null)
				{
					// Get the console control.
					ControlSession control = info.ConsoleControl;
					// Close the control.
					this.OnConsoleClose(item);
				}
			}
		}

		/// <summary>
		/// An event handler called when the site selection has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnNodeSelectionChanged(object sender, EventArgs e)
		{
			// If there exists an emphasized marker, de-emphasize it.
			if (this.marker != null)
			{
				this.marker.Emphasized = false;
				this.marker = null;
			}
			// If no site is selected.
			if (this.listViewNodes.SelectedItems.Count == 0)
			{
				// Change the buttons enabled state.
				this.buttonRemoveFromNodes.Enabled = false;
				this.buttonConnect.Enabled = false;
				this.buttonDisconnect.Enabled = false;
				this.buttonProperties.Enabled = false;
				this.menuItemConnect.Enabled = false;
				this.menuItemDisconnect.Enabled = false;
				this.menuItemNodeProperties.Enabled = false;
				this.menuItemSiteProperties.Enabled = false;
			}
			else
			{
				// Get the node info for this item.
				NodeInfo info = this.listViewNodes.SelectedItems[0].Tag as NodeInfo;
				// If the node has a control.
				if (null != info.ConsoleControl)
				{
					// Change the button enabled state.
					this.buttonConnect.Enabled = info.ConsoleControl.State == ControlSsh.ClientState.Disconnected;
					this.buttonDisconnect.Enabled = info.ConsoleControl.State == ControlSsh.ClientState.Connected;
					this.menuItemConnect.Enabled = info.ConsoleControl.State == ControlSsh.ClientState.Disconnected;
					this.menuItemDisconnect.Enabled = info.ConsoleControl.State == ControlSsh.ClientState.Connected;
				}
				else
				{
					// Change the button enabled state.
					this.buttonConnect.Enabled = true;
					this.buttonDisconnect.Enabled = false;
					this.menuItemConnect.Enabled = true;
					this.menuItemDisconnect.Enabled = false;
				}
				this.buttonRemoveFromNodes.Enabled = true;
				this.buttonProperties.Enabled = true;
				this.buttonNodeProperties.Enabled = true;
				this.buttonSiteProperties.Enabled = info.Node != null;
				this.menuItemNodeProperties.Enabled = true;
				this.menuItemSiteProperties.Enabled = info.Node != null;

				// If the marker is not null, emphasize the marker.
				if (null != info.Marker)
				{
					this.marker = info.Marker;
					this.marker.Emphasized = true;
				}
			}
		}

		/// <summary>
		/// An event handler called when the user refreshes PlanetLab slice information.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnRefreshSlice(object sender, EventArgs e)
		{
			// If there is no validated PlanetLab person account, show a message and return.
			if (-1 == this.crawler.PlanetLab.PersonId)
			{
				MessageBox.Show(this, "You must set and validate a PlanetLab account in the settings page before configuring the PlanetLab slices.", "PlanetLab Account Not Configured", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			// Warn the user about the refresh.
			if (MessageBox.Show(
				this,
				@"You will now refresh the information for slice '{0}'. This will remove the slice configuration and disconnect all current sessions. Click Yes to continue.".FormatWith(this.slice.Name),
				"Refresh PlanetLab Slice",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Question,
				MessageBoxDefaultButton.Button2) == DialogResult.No)
			{
				return;
			}

			// Refresh the slice.
			this.OnRefreshSlice();
		}

		/// <summary>
		/// Refreshes the information of the current slice.
		/// </summary>
		private void OnRefreshSlice()
		{
			// Update the status.
			this.status.Send(CrawlerStatus.StatusType.Busy, "Refreshing the slice information...", Resources.GlobeClock_16);

			// Begin an asynchronous PlanetLab request.
			this.BeginRequest(
				this.requestGetSlices,
				this.crawler.PlanetLab.Username,
				this.crawler.PlanetLab.Password,
				PlSlice.GetFilter(PlSlice.Fields.SliceId, this.slice.SliceId),
				this.requestStateGetSlice);
		}

		/// <summary>
		/// An event handler called when the user cancels the update of PlanetLab slice.
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
		/// A method called when receiving the response to a slices refresh request.
		/// </summary>
		/// <param name="response">The response.</param>
		/// <param name="state">The request state.</param>
		private void OnRefreshSliceRequestResult(XmlRpcResponse response, RequestState state)
		{
			// If the request has not failed.
			if ((null == response.Fault) && (null != response.Value))
			{
				// Get the slices array.
				XmlRpcArray slices = response.Value as XmlRpcArray;

				// If the response array has one element.
				if ((null != slices) && (slices.Length == 1))
				{
					try
					{
						// Update the current slice.
						this.slice.Parse(slices.Values[0].Value as XmlRpcStruct);
						// Return.
						return;
					}
					catch { }
				}
			}
			// Update the status.
			this.status.Send(CrawlerStatus.StatusType.Normal, "Refreshing the slice information failed.", Resources.GlobeError_16);
		}

		/// <summary>
		/// A method called when the get slices request has been canceled.
		/// </summary>
		/// <param name="state">The request state.</param>
		private void OnRefreshSliceRequestCanceled(RequestState state)
		{
			// Update the status.
			this.status.Send(CrawlerStatus.StatusType.Normal, "Refreshing the slice information was canceled.", Resources.GlobeCanceled_16);
		}

		/// <summary>
		/// A method called when the get slices request returned an exception.
		/// </summary>
		/// <param name="exception">The exception.</param>
		/// <param name="state">The request state.</param>
		private void OnRefreshSliceRequestException(Exception exception, RequestState state)
		{
			// Update the status.
			this.status.Send(CrawlerStatus.StatusType.Normal, "Refreshing the slice information failed.", Resources.GlobeError_16);
		}

		/// <summary>
		/// An event handler called when the list of nodes is refreshed.
		/// </summary>
		private void OnRefreshNodes()
		{
			lock (this.pendingSync)
			{
				// If there are no nodes to refresh, do nothing.
				if (this.pendingNodes.Count == 0) return;

				// Update the status.
				this.status.Send(
					CrawlerStatus.StatusType.Busy,
					@"Slice '{0}' has {1} node{2}.".FormatWith(this.slice.Name, this.slice.NodeIds.Length, this.slice.NodeIds.Length.PluralSuffix()),
					"Refreshing the nodes information...",
					Resources.GlobeLab_16,
					Resources.GlobeClock_16);

				// Create the request state.
				IdsRequestState requestState = new IdsRequestState(
					null,
					this.OnRefreshNodesRequestResult,
					this.OnRefreshNodesRequestCanceled,
					this.OnRefreshNodesRequestException,
					this.OnRefreshNodesRequestFinished,
					this.pendingNodes.ToArray());

				// Begin an asynchronous PlanetLab request.
				this.BeginRequest(
					this.requestGetNodes,
					this.crawler.PlanetLab.Username,
					this.crawler.PlanetLab.Password,
					PlNode.GetFilter(PlNode.Fields.NodeId, requestState.Ids),
					requestState);

				// Clear the list of pending nodes.
				this.pendingNodes.Clear();
			}
		}

		/// <summary>
		/// A method called when receiving the response to a nodes refresh request.
		/// </summary>
		/// <param name="response">The response.</param>
		/// <param name="state">The request state.</param>
		private void OnRefreshNodesRequestResult(XmlRpcResponse response, RequestState state)
		{
			// Convert the request state.
			IdsRequestState requestState = state as IdsRequestState;
			// If the request has not failed.
			if ((null == response.Fault) && (null != response.Value))
			{
				// Get the response array.
				XmlRpcArray array = response.Value as XmlRpcArray;

				// Check the array is not null.
				if (null == array)
				{
					// Update the status.
					this.status.Send(
						CrawlerStatus.StatusType.Normal,
						@"Slice '{0}' has {1} node{2}.".FormatWith(this.slice.Name, this.slice.NodeIds.Length, this.slice.NodeIds.Length.PluralSuffix()),
						"Refreshing the nodes information failed.",
						Resources.GlobeLab_16,
						Resources.GlobeError_16);
					// Return.
					return;
				}

				// For each value in the response array.
				foreach (XmlRpcValue value in array.Values)
				{
					// The PlanetLab node.
					PlNode node = null;

					// Try parse the structure to a PlanetLab node and add it to the nodes list.
					try { node = this.crawler.PlanetLab.Nodes.Add(value.Value as XmlRpcStruct); }
					catch { }

					// If the object is null, continue.
					if (null == node) continue;

					// Find the list item corresponding to the node.
					ListViewItem item = this.listViewNodes.Items.FirstOrDefault((ListViewItem it) =>
						{
							// Get the node info.
							NodeInfo info = it.Tag as NodeInfo;
							// Check the node ID.
							return info.NodeId == node.Id;
						});

					// If the item is not null.
					if (null != item)
					{
						// Get the node info.
						NodeInfo info = item.Tag as NodeInfo;

						// If the node has not been set.
						if (info.Node == null)
						{
							// Add a node event handler.
							node.Changed += this.OnNodeChanged;
							// Set the node information.
							info.Node = node;
							info.SiteId = node.SiteId;
						}

						// If the site has not been set.
						if (null == info.Site)
						{
							// If the node has a site identifier.
							if (node.SiteId.HasValue)
							{
								// Get the site from the database.
								PlSite site = this.crawler.PlanetLab.DbSites.Find(node.SiteId.Value);
								// If the site is not null.
								if (null != site)
								{
									// Add a site event handler.
									site.Changed += this.OnSiteChanged;
									// Set the site.
									info.Site = site;
									// If the item does not have a marker and if the site has coordinates.
									if ((null == info.Marker) && site.Latitude.HasValue && site.Longitude.HasValue)
									{
										// Create a circular marker.
										marker = new MapBulletMarker(new MapPoint(site.Longitude.Value, site.Latitude.Value));
										marker.Name = "{0}{1}{2}".FormatWith(node.Hostname, Environment.NewLine, site.Name);
										// Add the marker to the map.
										this.mapControl.Markers.Add(marker);
										// Set the marker.
										info.Marker = marker;
									}
								}
								else
								{
									// Add the site to the pending sites.
									this.pendingSites.Add(node.SiteId.Value);
								}
							}
						}

						// Set the item information.
						item.SubItems[0].Text = node.Id.Value.ToString();
						item.SubItems[1].Text = node.Hostname;
						item.ImageKey = ControlSlice.nodeImageKeys[(int)node.GetBootState()];
					}
				}

				// Update the status.
				this.status.Send(
					CrawlerStatus.StatusType.Normal,
					@"Slice '{0}' has {1} node{2}.".FormatWith(this.slice.Name, this.slice.NodeIds.Length, this.slice.NodeIds.Length.PluralSuffix()),
					"Refreshing the nodes information completed successfully.",
					Resources.GlobeLab_16,
					Resources.GlobeSuccess_16);
			}
			else
			{
				// Update the status.
				this.status.Send(
					CrawlerStatus.StatusType.Normal,
					@"Slice '{0}' has {1} node{2}.".FormatWith(this.slice.Name, this.slice.NodeIds.Length, this.slice.NodeIds.Length.PluralSuffix()),
					"Refreshing the nodes information failed.",
					Resources.GlobeLab_16,
					Resources.GlobeError_16);
			}
		}

		/// <summary>
		/// A method called when a nodes refresh request has been canceled.
		/// </summary>
		/// <param name="state">The request state.</param>
		private void OnRefreshNodesRequestCanceled(RequestState state)
		{
			// Update the status.
			this.status.Send(
				CrawlerStatus.StatusType.Normal,
				@"Slice '{0}' has {1} node{2}.".FormatWith(this.slice.Name, this.slice.NodeIds.Length, this.slice.NodeIds.Length.PluralSuffix()),
				"Refreshing the nodes information was canceled.",
				Resources.GlobeLab_16,
				Resources.GlobeCanceled_16);
		}

		/// <summary>
		/// A method called when a nodes refresh request returned an exception.
		/// </summary>
		/// <param name="exception">The exception.</param>
		/// <param name="state">The request state.</param>
		private void OnRefreshNodesRequestException(Exception exception, RequestState state)
		{
			// Update the status.
			this.status.Send(
				CrawlerStatus.StatusType.Normal,
				@"Slice '{0}' has {1} node{2}.".FormatWith(this.slice.Name, this.slice.NodeIds.Length, this.slice.NodeIds.Length.PluralSuffix()),
				"Refreshing the nodes information failed.",
				Resources.GlobeLab_16,
				Resources.GlobeError_16);
		}

		/// <summary>
		/// A method called when a nodes refresh request has finished.
		/// </summary>
		/// <param name="state">The request state.</param>
		private void OnRefreshNodesRequestFinished(RequestState state)
		{
			// If there are pending sites, refresh the sites.
			lock (this.pendingSync)
			{
				if (this.pendingSites.Count > 0)
				{
					this.OnRefreshSites();
				}
			}
		}

		/// <summary>
		/// An event handler called when the list of sites is refreshed.
		/// </summary>
		private void OnRefreshSites()
		{
			lock (this.pendingSync)
			{
				// If there are no sites to refresh, do nothing.
				if (this.pendingSites.Count == 0) return;

				// Update the status.
				this.status.Send(
					CrawlerStatus.StatusType.Busy,
					@"Slice '{0}' has {1} node{2}.".FormatWith(this.slice.Name, this.slice.NodeIds.Length, this.slice.NodeIds.Length.PluralSuffix()),
					"Refreshing the sites information...",
					Resources.GlobeLab_16,
					Resources.GlobeClock_16);

				// Create the request state.
				IdsRequestState requestState = new IdsRequestState(
					null,
					this.OnRefreshSitesRequestResult,
					this.OnRefreshSitesRequestCanceled,
					this.OnRefreshSitesRequestException,
					null,
					this.pendingSites.ToArray());

				// Begin an asynchronous PlanetLab request.
				this.BeginRequest(
					this.requestGetSites,
					this.crawler.PlanetLab.Username,
					this.crawler.PlanetLab.Password,
					PlSite.GetFilter(PlSite.Fields.SiteId, requestState.Ids),
					requestState);

				// Clear the list of pending sites.
				this.pendingSites.Clear();
			}
		}

		/// <summary>
		/// A method called when receiving the response to a sites refresh request.
		/// </summary>
		/// <param name="response">The response.</param>
		/// <param name="state">The request state.</param>
		private void OnRefreshSitesRequestResult(XmlRpcResponse response, RequestState state)
		{
			// Convert the request state.
			IdsRequestState requestState = state as IdsRequestState;
			// If the request has not failed.
			if ((null == response.Fault) && (null != response.Value))
			{
				// Get the response array.
				XmlRpcArray array = response.Value as XmlRpcArray;

				// Check the array is not null.
				if (null == array)
				{
					// Update the status.
					this.status.Send(
						CrawlerStatus.StatusType.Normal,
						@"Slice '{0}' has {1} node{2}.".FormatWith(this.slice.Name, this.slice.NodeIds.Length, this.slice.NodeIds.Length.PluralSuffix()),
						"Refreshing the sites information failed.",
						Resources.GlobeLab_16,
						Resources.GlobeError_16);
					// Return.
					return;
				}

				// For each value in the response array.
				foreach (XmlRpcValue value in array.Values)
				{
					// The PlanetLab site.
					PlSite site = null;

					// Try parse the structure to a PlanetLab node and add it to the sites list.
					try { site = this.crawler.PlanetLab.Sites.Add(value.Value as XmlRpcStruct); }
					catch { }

					// If the object is null, continue.
					if (null == site) continue;

					// Find the list item corresponding to the node.
					ListViewItem item = this.listViewNodes.Items.FirstOrDefault((ListViewItem it) =>
					{
						// Get the node info.
						NodeInfo info = it.Tag as NodeInfo;
						// Check the site ID.
						return info.SiteId == site.Id;
					});

					// If the item is not null.
					if (null != item)
					{
						// Get the node info.
						NodeInfo info = item.Tag as NodeInfo;

						// If the site has not been set.
						if (info.Site == null)
						{
							// Add a node event handler.
							site.Changed += this.OnSiteChanged;
							// Set the site.
							info.Site = site;
							// If the item does not have a marker and if the site has coordinates.
							if ((null == info.Marker) && (null != info.Node) && site.Latitude.HasValue && site.Longitude.HasValue)
							{
								// Create a circular marker.
								marker = new MapBulletMarker(new MapPoint(site.Longitude.Value, site.Latitude.Value));
								marker.Name = "{0}{1}{2}".FormatWith(info.Node.Hostname, Environment.NewLine, site.Name);
								// Add the marker to the map.
								this.mapControl.Markers.Add(marker);
								// Set the marker.
								info.Marker = marker;
							}
						}
					}
				}

				// Update the status.
				this.status.Send(
					CrawlerStatus.StatusType.Normal,
					@"Slice '{0}' has {1} node{2}.".FormatWith(this.slice.Name, this.slice.NodeIds.Length, this.slice.NodeIds.Length.PluralSuffix()),
					"Refreshing the sites information completed successfully.",
					Resources.GlobeLab_16,
					Resources.GlobeSuccess_16);
			}
			else
			{
				// Update the status.
				this.status.Send(
					CrawlerStatus.StatusType.Normal,
					@"Slice '{0}' has {1} node{2}.".FormatWith(this.slice.Name, this.slice.NodeIds.Length, this.slice.NodeIds.Length.PluralSuffix()),
					"Refreshing the sites information failed.",
					Resources.GlobeLab_16,
					Resources.GlobeError_16);
			}
		}

		/// <summary>
		/// A method called when a sites refresh request has been canceled.
		/// </summary>
		/// <param name="state">The request state.</param>
		private void OnRefreshSitesRequestCanceled(RequestState state)
		{
			// Update the status.
			this.status.Send(
				CrawlerStatus.StatusType.Normal,
				@"Slice '{0}' has {1} node{2}.".FormatWith(this.slice.Name, this.slice.NodeIds.Length, this.slice.NodeIds.Length.PluralSuffix()),
				"Refreshing the sites information was canceled.",
				Resources.GlobeLab_16,
				Resources.GlobeCanceled_16);
		}

		/// <summary>
		/// A method called when a sites refresh request returned an exception.
		/// </summary>
		/// <param name="exception">The exception.</param>
		/// <param name="state">The request state.</param>
		private void OnRefreshSitesRequestException(Exception exception, RequestState state)
		{
			// Update the status.
			this.status.Send(
				CrawlerStatus.StatusType.Normal,
				@"Slice '{0}' has {1} node{2}.".FormatWith(this.slice.Name, this.slice.NodeIds.Length, this.slice.NodeIds.Length.PluralSuffix()),
				"Refreshing the sites information failed.",
				Resources.GlobeLab_16,
				Resources.GlobeError_16);
		}

		/// <summary>
		/// An event handler called when the user adds a slice to nodes selected by location.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnAddToNodesLocation(object sender, EventArgs e)
		{
			// If there is no validated PlanetLab person account, show a message and return.
			if (-1 == CrawlerConfig.Static.PlanetLabPersonId)
			{
				MessageBox.Show(this, "You must set and validate a PlanetLab account in the settings page before configuring the PlanetLab slices.", "PlanetLab Account Not Configured", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			// Show the add slice to nodes by location dialog.
			if (this.formAddSliceToNodesLocation.ShowDialog(this, this.crawler) == DialogResult.OK)
			{
				// Add the slice to nodes.
				this.OnAddSliceToNodes(this.formAddSliceToNodesLocation.Result);
			}
		}

		/// <summary>
		/// An event handler called when the user adds a slice to nodes selected by state.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnAddToNodesState(object sender, EventArgs e)
		{
			// If there is no validated PlanetLab person account, show a message and return.
			if (-1 == CrawlerConfig.Static.PlanetLabPersonId)
			{
				MessageBox.Show(this, "You must set and validate a PlanetLab account in the settings page before configuring the PlanetLab slices.", "PlanetLab Account Not Configured", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			// Show the add slice to nodes by state dialog.
			if (this.formAddSliceToNodesState.ShowDialog(this, this.crawler) == DialogResult.OK)
			{
				// Add the slice to nodes.
				this.OnAddSliceToNodes(this.formAddSliceToNodesState.Result);
			}
		}

		/// <summary>
		/// An event handler called when the user adds a slice to nodes selected by slice.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnAddToNodesSlice(object sender, EventArgs e)
		{
			// If there is no validated PlanetLab person account, show a message and return.
			if (-1 == CrawlerConfig.Static.PlanetLabPersonId)
			{
				MessageBox.Show(this, "You must set and validate a PlanetLab account in the settings page before configuring the PlanetLab slices.", "PlanetLab Account Not Configured", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			// Show the add slice to nodes by state dialog.
			if (this.formAddSliceToNodesSlice.ShowDialog(this, this.crawler) == DialogResult.OK)
			{
				// Add the slice to nodes.
				this.OnAddSliceToNodes(this.formAddSliceToNodesState.Result);
			}
		}

		/// <summary>
		/// An event handler called when adding the current slice to PlanetLab nodes.
		/// </summary>
		/// <param name="ids">The list of node IDs.</param>
		private void OnAddSliceToNodes(int[] ids)
		{
			// If the slice does not have an ID, show an error message and return.
			if (!slice.Id.HasValue)
			{
				MessageBox.Show(this, "The selected slice does not have an identifier.", "Add Slice to Nodes", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			// Update the status.
			this.status.Send(
				CrawlerStatus.StatusType.Busy,
				"Showing {0} PlanetLab slices.".FormatWith(this.crawler.PlanetLab.LocalSlices.Count),
				"Adding slice {0} to {1} PlanetLab node{2}...".FormatWith(slice.Id, ids.Length, ids.Length.PluralSuffix()),
				Resources.GlobeLab_16,
				Resources.GlobeClock_16);

			// Create the request state.
			IdsRequestState requestState = new IdsRequestState(
				null,
				this.OnAddSliceToNodesRequestResult,
				this.OnAddSliceToNodesRequestCanceled,
				this.OnAddSliceToNodesRequestException,
				this.OnAddSliceToNodesRequestFinished,
				ids);

			// Begin an asynchronous PlanetLab request.
			this.BeginRequest(
				this.requestAddSliceToNodes,
				this.crawler.PlanetLab.Username,
				this.crawler.PlanetLab.Password,
				new object[] { slice.Id.Value, ids },
				requestState);
		}

		/// <summary>
		/// A method called when receiving the response to an add slice to nodes request.
		/// </summary>
		/// <param name="response">The response.</param>
		/// <param name="state">The request state.</param>
		private void OnAddSliceToNodesRequestResult(XmlRpcResponse response, RequestState state)
		{
			// Convert the request state.
			IdsRequestState requestState = state as IdsRequestState;
			// If the request has not failed.
			if ((null == response.Fault) && (null != response.Value))
			{
				// Get the response value.
				int? code = response.Value.AsInt;
				if (code.HasValue ? 1 == code.Value : false)
				{
					// Update the status.
					this.status.Send(
						CrawlerStatus.StatusType.Normal,
						"Showing {0} PlanetLab slices.".FormatWith(this.crawler.PlanetLab.LocalSlices.Count),
						"Adding slice {0} to {1} PlanetLab node{2} succeeded.".FormatWith(this.slice.Id, requestState.Ids.Length, requestState.Ids.Length.PluralSuffix()),
						Resources.GlobeLab_16,
						Resources.GlobeSuccess_16);

					// Set the request as successful.
					requestState.Success = true;
				}
				else
				{
					// Show a dialog.
					MessageBox.Show(this,
						"Cannot add the slice {0} to {1} PlanetLab node{2}. The PlanetLab server responded, however the operation was not successful.".FormatWith(this.slice.Id, requestState.Ids.Length, requestState.Ids.Length.PluralSuffix()),
						"Add Slice to Node",
						MessageBoxButtons.OK,
						MessageBoxIcon.Warning);
					// Update the status.
					this.status.Send(
						CrawlerStatus.StatusType.Normal,
						"Showing {0} PlanetLab slices.".FormatWith(this.crawler.PlanetLab.LocalSlices.Count),
						"Adding slice {0} to {1} PlanetLab node{2} failed.".FormatWith(this.slice.Id, requestState.Ids.Length, requestState.Ids.Length.PluralSuffix()),
						Resources.GlobeLab_16,
						Resources.GlobeWarning_16);
				}
			}
			else
			{
				// Update the status.
				this.status.Send(
					CrawlerStatus.StatusType.Normal,
					"Showing {0} PlanetLab slices.".FormatWith(this.crawler.PlanetLab.LocalSlices.Count),
					"Adding slice {0} to {1} PlanetLab node{2} failed.".FormatWith(this.slice.Id, requestState.Ids.Length, requestState.Ids.Length.PluralSuffix()),
					Resources.GlobeLab_16,
					Resources.GlobeError_16);
			}
		}

		/// <summary>
		/// A method called when the add slice to nodes request has been canceled.
		/// </summary>
		/// <param name="state">The request state.</param>
		private void OnAddSliceToNodesRequestCanceled(RequestState state)
		{
			// Convert the request state.
			IdsRequestState requestState = state as IdsRequestState;
			// Update the status.
			this.status.Send(
				CrawlerStatus.StatusType.Normal,
				"Showing {0} PlanetLab slices.".FormatWith(this.crawler.PlanetLab.LocalSlices.Count),
				"Adding the slice {0} to {1} PlanetLab node{2} was canceled.".FormatWith(this.slice.Id, requestState.Ids.Length, requestState.Ids.Length.PluralSuffix()),
				Resources.GlobeLab_16,
				Resources.GlobeCanceled_16);
		}

		/// <summary>
		/// A method called when the get slices request returned an exception.
		/// </summary>
		/// <param name="exception">The exception.</param>
		/// <param name="state">The request state.</param>
		private void OnAddSliceToNodesRequestException(Exception exception, RequestState state)
		{
			// Convert the request state.
			IdsRequestState requestState = state as IdsRequestState;
			// Update the status.
			this.status.Send(
				CrawlerStatus.StatusType.Normal,
				"Showing {0} PlanetLab slices.".FormatWith(this.crawler.PlanetLab.LocalSlices.Count),
				"Adding the slice {0} to {1} PlanetLab node{2} failed.".FormatWith(this.slice.Id, requestState.Ids.Length, requestState.Ids.Length.PluralSuffix()),
				Resources.GlobeLab_16,
				Resources.GlobeError_16);
		}

		/// <summary>
		/// A method called when the add slice to nodes request has finished.
		/// </summary>
		/// <param name="state">The request state.</param>
		private void OnAddSliceToNodesRequestFinished(RequestState state)
		{
			// If the request is successful.
			if (state.Success)
			{
				// Get the request state.
				IdsRequestState requestState = state as IdsRequestState;

				// Refresh the slice information.
				this.OnRefreshSlice();
			}
		}

		/// <summary>
		/// An event handler called when the user removes a slice from nodes.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnRemoveFromNodes(object sender, EventArgs e)
		{
			// If there is no validated PlanetLab person account, show a message and return.
			if (-1 == CrawlerConfig.Static.PlanetLabPersonId)
			{
				MessageBox.Show(this, "You must set and validate a PlanetLab account in the settings page before configuring the PlanetLab slices.", "PlanetLab Account Not Configured", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			// If there is no node selected, do nothing.
			if (this.listViewNodes.SelectedItems.Count == 0) return;

			// Get the node information.
			NodeInfo info = (NodeInfo)this.listViewNodes.SelectedItems[0].Tag;

			// Confirm the removal.
			if (MessageBox.Show(
				this,
				"Remove the current slice from PlanetLab node {0}?".FormatWith(info.NodeId),
				"Remove Slice from Node",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Question,
				MessageBoxDefaultButton.Button2) == DialogResult.Yes)
			{
				// Create an identifiers array.
				int[] ids = new int[] { info.NodeId };

				// Update the status.
				this.status.Send(
					CrawlerStatus.StatusType.Busy,
					"Showing {0} PlanetLab slices.".FormatWith(this.crawler.PlanetLab.LocalSlices.Count),
					"Removing slice {0} from the PlanetLab nodes...",
					Resources.GlobeLab_16,
					Resources.GlobeClock_16);

				// Create the request state.
				IdsRequestState requestState = new IdsRequestState(
					null,
					this.OnRemoveSliceFromNodesRequestResult,
					this.OnRemoveSliceFromNodesRequestCanceled,
					this.OnRemoveSliceFromNodesRequestException,
					this.OnRemoveSliceFromNodesRequestFinished,
					ids);

				// Begin an asynchronous PlanetLab request.
				this.BeginRequest(
					this.requestRemoveSliceFromNodes,
					this.crawler.PlanetLab.Username,
					this.crawler.PlanetLab.Password,
					new object[] { this.slice.Id.Value, ids },
					requestState);
			}
		}

		/// <summary>
		/// A method called when receiving the response to a remove slice to nodes request.
		/// </summary>
		/// <param name="response">The response.</param>
		/// <param name="state">The request state.</param>
		private void OnRemoveSliceFromNodesRequestResult(XmlRpcResponse response, RequestState state)
		{
			// Convert the request state.
			IdsRequestState requestState = state as IdsRequestState;
			// If the request has not failed.
			if ((null == response.Fault) && (null != response.Value))
			{
				// Get the response value.
				int? code = response.Value.AsInt;
				if (code.HasValue ? 1 == code.Value : false)
				{
					// Update the status.
					this.status.Send(
						CrawlerStatus.StatusType.Normal,
						"Showing {0} PlanetLab slices.".FormatWith(this.crawler.PlanetLab.LocalSlices.Count),
						"Removing slice {0} from {1} PlanetLab node{2} succeeded.".FormatWith(this.slice.Id, requestState.Ids.Length, requestState.Ids.Length.PluralSuffix()),
						Resources.GlobeLab_16,
						Resources.GlobeSuccess_16);

					// Set the request as successful.
					requestState.Success = true;
				}
				else
				{
					// Show a dialog.
					MessageBox.Show(this,
						"Cannot remove the slice {0} from {1} PlanetLab node{2}. The PlanetLab server responded, however the operation was not successful.".FormatWith(this.slice.Id, requestState.Ids.Length, requestState.Ids.Length.PluralSuffix()),
						"Remove Slice from Node",
						MessageBoxButtons.OK,
						MessageBoxIcon.Warning);
					// Update the status.
					this.status.Send(
						CrawlerStatus.StatusType.Normal,
						"Showing {0} PlanetLab slices.".FormatWith(this.crawler.PlanetLab.LocalSlices.Count),
						"Removing slice {0} from {1} PlanetLab node{2} failed.".FormatWith(this.slice.Id, requestState.Ids.Length, requestState.Ids.Length.PluralSuffix()),
						Resources.GlobeLab_16,
						Resources.GlobeWarning_16);
				}
			}
			else
			{
				// Update the status.
				this.status.Send(
					CrawlerStatus.StatusType.Normal,
					"Showing {0} PlanetLab slices.".FormatWith(this.crawler.PlanetLab.LocalSlices.Count),
					"Removing slice {0} from {1} PlanetLab node{2} failed.".FormatWith(this.slice.Id, requestState.Ids.Length, requestState.Ids.Length.PluralSuffix()),
					Resources.GlobeLab_16,
					Resources.GlobeError_16);
			}
		}

		/// <summary>
		/// A method called when the add slice to nodes request has been canceled.
		/// </summary>
		/// <param name="state">The request state.</param>
		private void OnRemoveSliceFromNodesRequestCanceled(RequestState state)
		{
			// Convert the request state.
			IdsRequestState requestState = state as IdsRequestState;
			// Update the status.
			this.status.Send(
				CrawlerStatus.StatusType.Normal,
				"Showing {0} PlanetLab slices.".FormatWith(this.crawler.PlanetLab.LocalSlices.Count),
				"Removing the slice {0} from {1} PlanetLab node{2} was canceled.".FormatWith(this.slice.Id, requestState.Ids.Length, requestState.Ids.Length.PluralSuffix()),
				Resources.GlobeLab_16,
				Resources.GlobeCanceled_16);
		}

		/// <summary>
		/// A method called when the get slices request returned an exception.
		/// </summary>
		/// <param name="exception">The exception.</param>
		/// <param name="state">The request state.</param>
		private void OnRemoveSliceFromNodesRequestException(Exception exception, RequestState state)
		{
			// Convert the request state.
			IdsRequestState requestState = state as IdsRequestState;
			// Update the status.
			this.status.Send(
				CrawlerStatus.StatusType.Normal,
				"Showing {0} PlanetLab slices.".FormatWith(this.crawler.PlanetLab.LocalSlices.Count),
				"Removing the slice {0} from {1} PlanetLab node{2} failed.".FormatWith(this.slice.Id, requestState.Ids.Length, requestState.Ids.Length.PluralSuffix()),
				Resources.GlobeLab_16,
				Resources.GlobeError_16);
		}

		/// <summary>
		/// A method called when the add slice to nodes request has finished.
		/// </summary>
		/// <param name="state">The request state.</param>
		private void OnRemoveSliceFromNodesRequestFinished(RequestState state)
		{
			// If the request is successful.
			if (state.Success)
			{
				// Refresh the slice information.
				this.OnRefreshSlice();
			}
		}

		/// <summary>
		/// An event handler called when setting the key for a PlanetLab slice.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSetKey(object sender, EventArgs e)
		{
			// Open the dialog.
			if (this.openFileDialog.ShowDialog(this) == DialogResult.OK)
			{
				try
				{
					// Open the file.
					using (FileStream fileStream = new FileStream(this.openFileDialog.FileName, FileMode.Open))
					{
						// Set the key data.
						this.config.Key = fileStream.ReadToEnd();
					}
				}
				catch (Exception exception)
				{
					// Show an error dialog if an exception is thrown.
					MessageBox.Show("Could not open the RSA key file. {0}".FormatWith(exception.Message), "Cannot Open File", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		/// <summary>
		/// An event handler called when showing the slice key.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnShowKey(object sender, LinkLabelLinkClickedEventArgs e)
		{
			// Show the slice key.
			this.formText.ShowDialog(this, "Slice Private Key", this.config.Key != null ? Encoding.UTF8.GetString(this.config.Key).Replace("\n", Environment.NewLine) : string.Empty);
		}

		/// <summary>
		/// An event handler called when renewing the slice.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnRenew(object sender, EventArgs e)
		{
			// Show the slice renewal dialog.
			if (this.formRenewSlice.ShowDialog(this, this.crawler, this.slice) == DialogResult.OK)
			{
				// Refresh the slice information.
				this.OnRefreshSlice();
			}
		}

		/// <summary>
		/// An event handler called when the user clicks on the nodes list.
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
		/// An event handler called when the user selects the node properties.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnNodeProperties(object sender, EventArgs e)
		{
			// If there is no selected item, do nothing.
			if (this.listViewNodes.SelectedItems.Count == 0) return;
			
			// Get the node info for the selected item.
			NodeInfo info = this.listViewNodes.SelectedItems[0].Tag as NodeInfo;

			// If the node info does not have a node object.
			if (null == info.Node)
			{
				// Show the node properties using the identifier.
				this.formNodeProperties.ShowDialog(this, "Node", info.NodeId);
			}
			else
			{
				// Show the node properties using the node object.
				this.formNodeProperties.ShowDialog(this, "Node", info.Node);
			}
		}

		/// <summary>
		/// An event handler called when the user selects the site properties.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSiteProperties(object sender, EventArgs e)
		{
			// If there is no selected item, do nothing.
			if (this.listViewNodes.SelectedItems.Count == 0) return;

			// Get the node info for the selected item.
			NodeInfo info = this.listViewNodes.SelectedItems[0].Tag as NodeInfo;

			// If the node has a site object.
			if (null != info.Site)
			{
				// Show the site properties.
				this.formSiteProperties.ShowDialog(this, "Site", info.Site);
			}
			else if (info.SiteId.HasValue)
			{
				// Show the site properties.
				this.formSiteProperties.ShowDialog(this, "Site", info.SiteId.Value);
			}
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
			this.listViewNodes.SelectedItems.Clear();
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
			this.OnNodeProperties(sender, e);
		}

		/// <summary>
		/// An event handler called when connecting to a PlanetLab node.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnConnect(object sender, EventArgs e)
		{
			// If there is no node selected, do nothing.
			if (this.listViewNodes.SelectedItems.Count == 0) return;

			// Get the node information.
			NodeInfo info = this.listViewNodes.SelectedItems[0].Tag as NodeInfo;

			// If the PlanetLab node is null.
			if (null == info.Node)
			{
				MessageBox.Show(this, "The information for the PlanetLab node {0} is not available. Try refreshing the slice.".FormatWith(info.NodeId), "Cannot Connect", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			// If the node info already has a session.
			if (info.ConsoleControl != null)
			{
				MessageBox.Show(this, "The node {0} is already connected.".FormatWith(info.Node.Hostname), "Cannot Connect", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			// Create a new tree node.
			TreeNode node = new TreeNode(info.Node.Hostname);
			node.ImageKey = "GlobeConsole";
			node.SelectedImageKey = "GlobeConsole";
			this.treeNodeSlice.Nodes.Add(node);
			this.treeNodeSlice.ExpandAll();

			// Create a new session control.
			ControlSession control = new ControlSession();
			control.Initialize(this.crawler, this.config, info.Node);
			this.controls.Add(control);

			// Set the node tag.
			node.Tag = control;

			// Update the node information.
			info.ConsoleControl = control;
			info.ConsoleNode = node;

			// Set the control event handlers.
			control.Connecting += this.OnConsoleConnecting;
			control.ConnectSucceeded += this.OnConsoleConnectSucceeded;
			control.ConnectFailed += this.OnConsoleConnectFailed;
			control.Disconnecting += this.OnConsoleDisconnecting;
			control.Disconnected += this.OnControlDisconnected;

			// Switch to the specified node.
			this.crawler.Events.SelectPage(node);

			// Connect the session.
			control.Connect();
		}

		/// <summary>
		/// An event handler called when disconnecting from a PlanetLab node.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnDisconnect(object sender, EventArgs e)
		{
			// If there is no node selected, do nothing.
			if (this.listViewNodes.SelectedItems.Count == 0) return;

			// Get the node information.
			NodeInfo info = this.listViewNodes.SelectedItems[0].Tag as NodeInfo;

			// If the PlanetLab node is null.
			if (null == info.Node)
			{
				MessageBox.Show(this, "The information for the PlanetLab node {0} is not available. Try refreshing the slice.".FormatWith(info.NodeId), "Cannot Disconnect", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			// If the node info does not have a session.
			if (info.ConsoleControl == null)
			{
				MessageBox.Show(this, "The node {0} is not connected.".FormatWith(info.Node.Hostname), "Cannot Disconnect", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			// Disconnect the session.
			info.ConsoleControl.Disconnect();
		}

		/// <summary>
		/// A method called when the console state has changed.
		/// </summary>
		/// <param name="node">The PlanetLab node.</param>
		/// <return>The list view item corresponding to the event.</return>
		private ListViewItem OnConsoleStateChanged(PlNode node)
		{
			// Get the list view item corresponding to the node.
			ListViewItem item = this.listViewNodes.Items.FirstOrDefault((ListViewItem it) =>
				{
					// Get the node info.
					NodeInfo info = it.Tag as NodeInfo;
					// Return if the node info matches the node.
					return object.ReferenceEquals(info.Node, node);
				});

			// If the item is not null.
			if (item != null)
			{
				// Get the node info.
				NodeInfo info = item.Tag as NodeInfo;

				// If the info does not have a console control, do nothing.
				if (null == info.ConsoleControl) return null;

				// Update the item status.
				item.SubItems[2].Text = info.ConsoleControl.State.ToString();

				// If there are selected items and the item matches the selected item.
				if ((this.listViewNodes.SelectedItems.Count > 0) && (item == this.listViewNodes.SelectedItems[0]))
				{
					// Change the button enabled state.
					this.buttonConnect.Enabled = info.ConsoleControl.State == ControlSsh.ClientState.Disconnected;
					this.buttonDisconnect.Enabled = info.ConsoleControl.State == ControlSsh.ClientState.Connected;
					this.menuItemConnect.Enabled = info.ConsoleControl.State == ControlSsh.ClientState.Disconnected;
					this.menuItemDisconnect.Enabled = info.ConsoleControl.State == ControlSsh.ClientState.Connected;
				}
			}

			// Return the item.
			return item;
		}

		/// <summary>
		/// An event handler called when the console is connecting.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnConsoleConnecting(object sender, PlObjectEventArgs<PlNode> e)
		{
			ListViewItem item;

			// Call the state changed method.
			if ((item = this.OnConsoleStateChanged(e.Object)) != null)
			{
				// Do nothing.
			}
		}

		/// <summary>
		/// An event handler called when the console connected successfully.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnConsoleConnectSucceeded(object sender, PlObjectEventArgs<PlNode> e)
		{
			ListViewItem item;

			// Call the state changed method.
			if ((item = this.OnConsoleStateChanged(e.Object)) != null)
			{
				// Do nothing.
			}
		}

		/// <summary>
		/// An event handler called when the console connection failed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnConsoleConnectFailed(object sender, PlExceptionEventArgs<PlNode> e)
		{
			ListViewItem item;

			// Call the state changed method.
			if ((item = this.OnConsoleStateChanged(e.Object)) != null)
			{
				// Close the console.
				this.OnConsoleClose(item);
			}
		}

		/// <summary>
		/// An event handler called when the console is disconnecting.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnConsoleDisconnecting(object sender, PlObjectEventArgs<PlNode> e)
		{
			ListViewItem item;

			// Call the state changed method.
			if ((item = this.OnConsoleStateChanged(e.Object)) != null)
			{
				// Do nothing.
			}
		}

		/// <summary>
		/// An event handler called when the console has disconnected.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnControlDisconnected(object sender, PlObjectEventArgs<PlNode> e)
		{
			ListViewItem item;

			// Call the state changed method.
			if ((item = this.OnConsoleStateChanged(e.Object)) != null)
			{
				// Close the console.
				this.OnConsoleClose(item);
			}
		}

		/// <summary>
		/// A method called when the closing the console corresponding to the specified list view item.
		/// </summary>
		/// <param name="item">The item.</param>
		private void OnConsoleClose(ListViewItem item)
		{
			// Get the node info.
			NodeInfo info = item.Tag as NodeInfo;

			// Switch to the specified node.
			this.crawler.Events.SelectPage(this.treeNodeSlice);

			// Remove the control event handlers.
			info.ConsoleControl.Connecting -= this.OnConsoleConnecting;
			info.ConsoleControl.ConnectSucceeded -= this.OnConsoleConnectSucceeded;
			info.ConsoleControl.ConnectFailed -= this.OnConsoleConnectFailed;
			info.ConsoleControl.Disconnecting -= this.OnConsoleDisconnecting;
			info.ConsoleControl.Disconnected -= this.OnControlDisconnected;

			// Remove the control.
			this.controls.Remove(info.ConsoleControl);

			// Remove the tree node.
			this.treeNodeSlice.Nodes.Remove(info.ConsoleNode);

			// Dispose the control.
			info.ConsoleControl.Dispose();

			// Update the node information.
			info.ConsoleControl = null;
			info.ConsoleNode = null;
		}

		/// <summary>
		/// A method called when creating the tasks.
		/// </summary>
		private void OnCreateTasks()
		{
			// Create the tasks tree node.
			/*
			this.treeNodeTasks = new TreeNode("Tasks");
			this.treeNodeTasks.ImageKey = "GlobeTasks";
			this.treeNodeTasks.SelectedImageKey = "GlobeTasks";
			this.treeNodeSlice.Nodes.Add(this.treeNodeTasks);
			this.treeNodeSlice.ExpandAll();*/
		}

		/// <summary>
		/// A method called when disposing the tasks.
		/// </summary>
		private void OnDisposeTasks()
		{
			// Delete the tasks tree node.
			//this.treeNodeSlice.Nodes.Remove(this.treeNodeTasks);
		}
	}
}
