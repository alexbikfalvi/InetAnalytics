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
using YtAnalytics.Forms;
using YtAnalytics.Forms.PlanetLab;
using YtCrawler;
using YtCrawler.PlanetLab;
using YtCrawler.Status;
using MapApi;

namespace YtAnalytics.Controls.PlanetLab
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
		/// A class representing the a slice request state.
		/// </summary>
		private class SliceRequestState : RequestState
		{
			/// <summary>
			/// Creates a new request state instance.
			/// </summary>
			/// <param name="actionRequestStarted">The request started action.</param>
			/// <param name="actionRequestResult">The request result action.</param>
			/// <param name="actionRequestCanceled">The request canceled action.</param>
			/// <param name="actionRequestException">The request exception action.</param>
			/// <param name="actionRequestFinished">The request finished action.</param>
			/// <param name="slice">The slice.</param>
			public SliceRequestState(
				Action<RequestState> actionRequestStarted,
				Action<XmlRpcResponse, RequestState> actionRequestResult,
				Action<RequestState> actionRequestCanceled,
				Action<Exception, RequestState> actionRequestException,
				Action<RequestState> actionRequestFinished,
				PlSlice slice
				)
				: base(actionRequestStarted, actionRequestResult, actionRequestCanceled, actionRequestException, actionRequestFinished)
			{
				this.Slice = slice;
			}

			/// <summary>
			/// Gets the PlanetLab slice corresponding to this request.
			/// </summary>
			public PlSlice Slice { get; private set; }
		}

		/// <summary>
		/// A class representing the slice-node request state.
		/// </summary>
		private class SliceIdsRequestState : SliceRequestState
		{
			/// <summary>
			/// Creates a new request state instance.
			/// </summary>
			/// <param name="actionRequestStarted">The request started action.</param>
			/// <param name="actionRequestResult">The request result action.</param>
			/// <param name="actionRequestCanceled">The request canceled action.</param>
			/// <param name="actionRequestException">The request exception action.</param>
			/// <param name="actionRequestFinished">The request finished action.</param>
			/// <param name="slice">The slice.</param>
			/// <param name="ids">The IDs.</param>
			public SliceIdsRequestState(
				Action<RequestState> actionRequestStarted,
				Action<XmlRpcResponse, RequestState> actionRequestResult,
				Action<RequestState> actionRequestCanceled,
				Action<Exception, RequestState> actionRequestException,
				Action<RequestState> actionRequestFinished,
				PlSlice slice,
				int[] ids
				)
				: base(actionRequestStarted, actionRequestResult, actionRequestCanceled, actionRequestException, actionRequestFinished, slice)
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
		private StatusHandler status = null;

		private PlSlice slice = null;
		private PlConfigSlice config = null;

		private MapMarker marker = null;

		private PlRequest requestGetSlices = new PlRequest(PlRequest.RequestMethod.GetSlices);
		private PlRequest requestGetNodes = new PlRequest(PlRequest.RequestMethod.GetNodes);
		private PlRequest requestGetSites = new PlRequest(PlRequest.RequestMethod.GetSites);
		private PlRequest requestAddSliceToNodes = new PlRequest(PlRequest.RequestMethod.AddSliceToNodes);
		private PlRequest requestRemoveSliceFromNodes = new PlRequest(PlRequest.RequestMethod.DeleteSliceFromNodes);

		private FormText formText = new FormText();


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
		}

		/// <summary>
		/// Initializes the control with a crawler object.
		/// </summary>
		/// <param name="crawler">The crawler object.</param>
		/// <param name="slice">The slice.</param>
		public void Initialize(Crawler crawler, PlSlice slice)
		{
			// Save the parameters.
			this.crawler = crawler;

			// Get the status handler.
			this.status = this.crawler.Status.GetHandler(this);

			// Set the slice.
			this.slice = slice;
			this.slice.Changed += this.OnSliceChanged;

			// Set the slice configuration.
			this.config = this.crawler.Config.PlanetLab.GetSliceConfiguration(this.slice);

			// Enable the control.
			this.Enabled = true;

			// Update the information of the PlanetLab slice.
			this.OnUpdateSlice();
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

			// Set the buttons enabled state.
			this.buttonRemoveFromNodes.Enabled = this.slice.NodeIds.Length > 0;

			// Update the list of nodes.
			this.OnUpdateNodes();

			// Update the label.
			this.status.Send(@"Slice '{0}'.".FormatWith(this.slice.Name), Resources.GlobeLab_16);
		}

		/// <summary>
		/// Updates the list of slice nodes.
		/// </summary>
		private void OnUpdateNodes()
		{
			// Clear the current nodes.
			this.OnClearNodes();

			// Add the list of nodes.
			foreach (int id in this.slice.NodeIds)
			{
				// Get the node.
				PlNode node = this.crawler.Config.PlanetLab.DbNodes.Find(id);
				// If the node is null.
				if (null == node)
				{
					// Refresh the nodes.
					return;
				}

				// The node site.
				PlSite site = null;
				if (node.SiteId.HasValue)
				{
					// Get the site from the database.
					site = this.crawler.Config.PlanetLab.DbSites.Find(node.SiteId.Value);
					// If the site is null.
					if (null == site)
					{
						// Refresh the sites.
						return;
					}
				}

				// Add a node event handler.
				node.Changed += this.OnNodeChanged;

				// Get the node boot state.
				PlBootState state = node.GetBootState();

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

				// Create a list item.
				ListViewItem item = new ListViewItem(new string[] { node.Id.Value.ToString(), node.Hostname });
				item.ImageKey = ControlSlice.nodeImageKeys[(int)state];
				item.Tag = new Triple<PlNode, PlSite, MapMarker>(node, site, marker);

				// Add the list item.
				this.listViewNodes.Items.Add(item);
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
					// Get the item tag.
					Triple<PlNode, PlSite, MapMarker> tag = (Triple<PlNode, PlSite, MapMarker>)it.Tag;
					// Check the tag node equals the current node.
					return object.ReferenceEquals(tag.First, node);
				});
			// Update the node information.
			if (null != item)
			{
				// Get the node boot state.
				PlBootState state = node.GetBootState();

				// Set the item information.
				item.SubItems[0].Text = node.Id.Value.ToString();
				item.SubItems[1].Text = node.Hostname;
				item.ImageKey = ControlSlice.nodeImageKeys[(int)state];
			}
		}

		/// <summary>
		/// An event handler called when clearing the list of nodes.
		/// </summary>
		private void OnClearNodes()
		{
			// For all node items.
			foreach (ListViewItem item in this.listViewNodes.Items)
			{
				// Get the tag.
				Triple<PlNode, PlSite, MapMarker> tag = (Triple<PlNode, PlSite, MapMarker>)item.Tag;
				// Remove the node event handler.
				tag.First.Changed -= this.OnNodeChanged;
				// Dispose the map marker.
				tag.Third.Dispose();
			}

			// Clear the list.
			this.listViewNodes.Items.Clear();
			// Clear the map markers.
			this.mapControl.Markers.Clear();
		}

		/// <summary>
		/// An event handler called when disposing the list of nodes.
		/// </summary>
		private void OnDisposeNodes()
		{
			// For all node items.
			foreach (ListViewItem item in this.listViewNodes.Items)
			{
				// Get the tag.
				Triple<PlNode, PlSite, MapMarker> tag = (Triple<PlNode, PlSite, MapMarker>)item.Tag;
				// Remove the node event handler.
				tag.First.Changed -= this.OnNodeChanged;
				// Dispose the map marker.
				tag.Third.Dispose();
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
				// Change the properties button enabled state.
				//this.buttonProperties.Enabled = false;
				//this.menuItemProperties.Enabled = false;
			}
			else
			{
				// Change the properties button enabled state.
				//this.buttonProperties.Enabled = true;
				//this.menuItemProperties.Enabled = true;
				// Get the tag for this item.
				Triple<PlNode, PlSite, MapMarker> tag = (Triple<PlNode, PlSite, MapMarker>)this.listViewNodes.SelectedItems[0].Tag;
				// If the marker is not null, emphasize the marker.
				if (tag.Third != null)
				{
					this.marker = tag.Third;
					this.marker.Emphasized = true;
				}
			}
		}

		/// <summary>
		/// An event handler called when the user refreshes the list of PlanetLab slices.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnRefresh(object sender, EventArgs e)
		{
			//// If there is no validated PlanetLab person account, show a message and return.
			//if (-1 == CrawlerStatic.PlanetLabPersonId)
			//{
			//	MessageBox.Show(this, "You must set and validate a PlanetLab account in the settings page before configuring the PlanetLab slices.", "PlanetLab Account Not Configured", MessageBoxButtons.OK, MessageBoxIcon.Error);
			//	return;
			//}

			//// Warn the user about the refresh.
			//if (MessageBox.Show(
			//	this,
			//	"You will now refresh the list with the slices to which you have access with your PlanetLab account. This will remove the configuration of slices that are no longer available. Click Yes to continue.",
			//	"Refresh PlanetLab Slices",
			//	MessageBoxButtons.YesNo,
			//	MessageBoxIcon.Question,
			//	MessageBoxDefaultButton.Button2) == DialogResult.No)
			//{
			//	return;
			//}

			//// Clear the current list of slices.
			////this.OnClearSlices();

			//// Update the status.
			//this.status.Send("Refreshing the list of PlanetLab slices...", Resources.GlobeClock_16);

			//// Begin an asynchronous PlanetLab request.
			//this.BeginRequest(
			//	this.requestGetSlices,
			//	this.crawler.Config.PlanetLab.Username,
			//	this.crawler.Config.PlanetLab.Password,
			//	null,
			//	this.requestStateGetSlices);
		}

		/// <summary>
		/// An event handler called when the user cancels the refresh of PlanetLab slices.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnCancel(object sender, EventArgs e)
		{
			//// Disable the cancel button.
			//this.buttonCancel.Enabled = false;
			//// Cancel the request.
			//this.CancelRequest();
		}

		/// <summary>
		/// A method called when receiving the response to a slices refresh request.
		/// </summary>
		/// <param name="response">The response.</param>
		/// <param name="state">The request state.</param>
		private void OnRefreshSlicesRequestResult(XmlRpcResponse response, RequestState state)
		{
			//// If the request has not failed.
			//if ((null == response.Fault) && (null != response.Value))
			//{
			//	// Get the slices array.
			//	XmlRpcArray slices = response.Value as XmlRpcArray;

			//	// Update the list of PlanetLab local slices, filtering by the current person account.
			//	this.crawler.Config.PlanetLab.LocalSlices.Update(slices.Where((XmlRpcValue value) =>
			//		{
			//			XmlRpcStruct str = value.Value as XmlRpcStruct;
			//			if (null == str) return false;

			//			XmlRpcMember member = str[PlSlice.Fields.PersonIds.GetName()];
			//			if (null == member) return false;

			//			XmlRpcArray array = member.Value.Value as XmlRpcArray;
			//			if (null == array) return false;

			//			return array.Contains(CrawlerStatic.PlanetLabPersonId);
			//		}));

			//	// Update the list of slices.
			//	this.OnUpdateSlices();
			//}
			//else
			//{
			//	// Update the status.
			//	this.status.Send("Refreshing the list of PlanetLab slices failed.", Resources.GlobeError_16);
			//}
		}

		/// <summary>
		/// A method called when the get slices request has been canceled.
		/// </summary>
		/// <param name="state">The request state.</param>
		private void OnRefreshSlicesRequestCanceled(RequestState state)
		{
			//// Update the status.
			//this.status.Send("Refreshing the list of PlanetLab slices was canceled.", Resources.GlobeCanceled_16);
		}

		/// <summary>
		/// A method called when the get slices request returned an exception.
		/// </summary>
		/// <param name="exception">The exception.</param>
		/// <param name="state">The request state.</param>
		private void OnRefreshSlicesRequestException(Exception exception, RequestState state)
		{
			//// Update the status.
			//this.status.Send("Refreshing the list of PlanetLab slices failed.", Resources.GlobeError_16);
		}

		/// <summary>
		/// An event handler called when the user adds a slice to nodes selected by location.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnAddToNodesLocation(object sender, EventArgs e)
		{
			//// If there is no validated PlanetLab person account, show a message and return.
			//if (-1 == CrawlerStatic.PlanetLabPersonId)
			//{
			//	MessageBox.Show(this, "You must set and validate a PlanetLab account in the settings page before configuring the PlanetLab slices.", "PlanetLab Account Not Configured", MessageBoxButtons.OK, MessageBoxIcon.Error);
			//	return;
			//}

			//// If there is no selected slice, do nothing.
			//if (this.listViewSlices.SelectedItems.Count == 0) return;

			//// Get the slice info.
			//SliceInfo info = (SliceInfo)this.listViewSlices.SelectedItems[0].Tag;

			//// Show the add slice to nodes by location dialog.
			//if (this.formAddSliceToNodesLocation.ShowDialog(this, this.crawler.Config) == DialogResult.OK)
			//{
			//	// Add the slice to nodes.
			//	this.OnAddSliceToNodes(info.Slice, this.formAddSliceToNodesLocation.Result);
			//}
		}

		/// <summary>
		/// An event handler called when the user adds a slice to nodes selected by state.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnAddToNodesState(object sender, EventArgs e)
		{
			//// If there is no validated PlanetLab person account, show a message and return.
			//if (-1 == CrawlerStatic.PlanetLabPersonId)
			//{
			//	MessageBox.Show(this, "You must set and validate a PlanetLab account in the settings page before configuring the PlanetLab slices.", "PlanetLab Account Not Configured", MessageBoxButtons.OK, MessageBoxIcon.Error);
			//	return;
			//}

			//// If there is no selected slice, do nothing.
			//if (this.listViewSlices.SelectedItems.Count == 0) return;

			//// Get the slice.
			//SliceInfo info = (SliceInfo)this.listViewSlices.SelectedItems[0].Tag;

			//// Show the add slice to nodes by state dialog.
			//if (this.formAddSliceToNodesState.ShowDialog(this, this.crawler.Config) == DialogResult.OK)
			//{
			//	// Add the slice to nodes.
			//	this.OnAddSliceToNodes(info.Slice, this.formAddSliceToNodesState.Result);
			//}
		}

		/// <summary>
		/// An event handler called when the user adds a slice to nodes selected by slice.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnAddToNodesSlice(object sender, EventArgs e)
		{

		}


		/// <summary>
		/// An event handler called when adding a slice to PlanetLab nodes.
		/// </summary>
		/// <param name="slice">The slice.</param>
		/// <param name="ids">The list of node IDs.</param>
		private void OnAddSliceToNodes(PlSlice slice, int[] ids)
		{
			// If the slice does not have an ID, show an error message and return.
			if (!slice.Id.HasValue)
			{
				MessageBox.Show(this, "The selected slice does not have an identifier.", "Add Slice to Nodes", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			// Update the status.
			this.status.Send(
				"Showing {0} PlanetLab slices.".FormatWith(this.crawler.Config.PlanetLab.LocalSlices.Count),
				"Adding slice {0} to {1} PlanetLab node{2}...".FormatWith(slice.Id, ids.Length, ids.Length == 1 ? string.Empty : "s"),
				Resources.GlobeLab_16,
				Resources.GlobeClock_16);

			// Create the request state.
			SliceIdsRequestState requestState = new SliceIdsRequestState(
				this.OnAddSliceToNodesRequestStarted,
				this.OnAddSliceToNodesRequestResult,
				this.OnAddSliceToNodesRequestCanceled,
				this.OnAddSliceToNodesRequestException,
				this.OnAddSliceToNodesRequestFinished,
				slice,
				ids);

			// Begin an asynchronous PlanetLab request.
			this.BeginRequest(
				this.requestAddSliceToNodes,
				this.crawler.Config.PlanetLab.Username,
				this.crawler.Config.PlanetLab.Password,
				new object[] { slice.Id.Value, ids },
				requestState);
		}

		/// <summary>
		/// A method called when the add slice to nodes request started.
		/// </summary>
		/// <param name="state">The request state.</param>
		private void OnAddSliceToNodesRequestStarted(RequestState state)
		{
			//// Disable the slices list.
			//this.listViewSlices.Enabled = false;
		}

		/// <summary>
		/// A method called when receiving the response to an add slice to nodes request.
		/// </summary>
		/// <param name="response">The response.</param>
		/// <param name="state">The request state.</param>
		private void OnAddSliceToNodesRequestResult(XmlRpcResponse response, RequestState state)
		{
			// Convert the request state.
			SliceIdsRequestState requestState = state as SliceIdsRequestState;
			// If the request has not failed.
			if ((null == response.Fault) && (null != response.Value))
			{
				// Get the response value.
				int? code = response.Value.AsInt;
				if (code.HasValue ? 1 == code.Value : false)
				{
					// Update the status.
					this.status.Send(
						"Showing {0} PlanetLab slices.".FormatWith(this.crawler.Config.PlanetLab.LocalSlices.Count),
						"Adding slice {0} to {1} PlanetLab node{2} succeeded.".FormatWith(requestState.Slice.Id, requestState.Ids.Length, requestState.Ids.Length == 1 ? string.Empty : "s"),
						Resources.GlobeLab_16,
						Resources.GlobeSuccess_16);

					// Set the request as successful.
					requestState.Success = true;
				}
				else
				{
					// Show a dialog.
					MessageBox.Show(this,
						"Cannot add the slice {0} to {1} PlanetLab node{2}. The PlanetLab server responded, however the operation was not successful.".FormatWith(requestState.Slice.Id, requestState.Ids.Length, requestState.Ids.Length == 1 ? string.Empty : "s"),
						"Add Slice to Node",
						MessageBoxButtons.OK,
						MessageBoxIcon.Warning);
					// Update the status.
					this.status.Send(
						"Showing {0} PlanetLab slices.".FormatWith(this.crawler.Config.PlanetLab.LocalSlices.Count),
						"Adding slice {0} to {1} PlanetLab node{2} failed.".FormatWith(requestState.Slice.Id, requestState.Ids.Length, requestState.Ids.Length == 1 ? string.Empty : "s"),
						Resources.GlobeLab_16,
						Resources.GlobeWarning_16);
				}
			}
			else
			{
				// Update the status.
				this.status.Send(
					"Showing {0} PlanetLab slices.".FormatWith(this.crawler.Config.PlanetLab.LocalSlices.Count),
					"Adding slice {0} to {1} PlanetLab node{2} failed.".FormatWith(requestState.Slice.Id, requestState.Ids.Length, requestState.Ids.Length == 1 ? string.Empty : "s"),
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
			SliceIdsRequestState requestState = state as SliceIdsRequestState;
			// Update the status.
			this.status.Send(
				"Showing {0} PlanetLab slices.".FormatWith(this.crawler.Config.PlanetLab.LocalSlices.Count),
				"Adding the slice {0} to {1} PlanetLab node{2} was canceled.".FormatWith(requestState.Slice.Id, requestState.Ids.Length, requestState.Ids.Length == 1 ? string.Empty : "s"),
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
			SliceIdsRequestState requestState = state as SliceIdsRequestState;
			// Update the status.
			this.status.Send(
				"Showing {0} PlanetLab slices.".FormatWith(this.crawler.Config.PlanetLab.LocalSlices.Count),
				"Adding the slice {0} to {1} PlanetLab node{2} failed.".FormatWith(requestState.Slice.Id, requestState.Ids.Length, requestState.Ids.Length == 1 ? string.Empty : "s"),
				Resources.GlobeLab_16,
				Resources.GlobeError_16);
		}

		/// <summary>
		/// A method called when the add slice to nodes request has finished.
		/// </summary>
		/// <param name="state">The request state.</param>
		private void OnAddSliceToNodesRequestFinished(RequestState state)
		{
			//// Enable the slices list.
			//this.listViewSlices.Enabled = true;
			//// Refresh the list selection.
			//this.OnSelectionChanged(this, EventArgs.Empty);

			// If the request is successful.
			if (state.Success)
			{
				// Get the request state.
				SliceIdsRequestState requestState = state as SliceIdsRequestState;

				// Refresh the slice information.
				this.OnRefreshSlice(requestState.Slice);
			}
		}

		/// <summary>
		/// Refreshes the information of the specified slice.
		/// </summary>
		/// <param name="slice">The slice.</param>
		private void OnRefreshSlice(PlSlice slice)
		{
			// Create the request state.
			SliceRequestState requestState = new SliceRequestState(
				this.OnRefreshSliceRequestStarted,
				this.OnRefreshSliceRequestResult,
				null,
				null,
				this.OnRefreshSliceRequestFinished,
				slice);

			// Begin an asynchronous PlanetLab request.
			this.BeginRequest(
				this.requestGetSlices,
				this.crawler.Config.PlanetLab.Username,
				this.crawler.Config.PlanetLab.Password,
				PlSlice.GetFilter(PlSlice.Fields.SliceId, slice.Id),
				requestState);
		}

		/// <summary>
		/// A method called when the refresh slice request started.
		/// </summary>
		/// <param name="state">The request state.</param>
		private void OnRefreshSliceRequestStarted(RequestState state)
		{
			//// Disable the slices list.
			//this.listViewSlices.Enabled = false;
		}

		/// <summary>
		/// A method called when receiving the response to a refresh slice request.
		/// </summary>
		/// <param name="response">The response.</param>
		/// <param name="state">The request state.</param>
		private void OnRefreshSliceRequestResult(XmlRpcResponse response, RequestState state)
		{
			//// Convert the request state.
			//SliceRequestState requestState = state as SliceRequestState;
			//// Get the slice.
			//PlSlice slice = requestState.Slice;
			//// If the request has not failed.
			//if ((null == response.Fault) && (null != response.Value))
			//{
			//	// Get the slices list.
			//	XmlRpcArray slices = response.Value as XmlRpcArray;

			//	// If the response list has one element.
			//	if (null != slices ? slices.Values.Length == 1 : false)
			//	{
			//		// Update the slice.
			//		slice.Parse(slices.Values[0].Value as XmlRpcStruct);
			//		// Find the list view item corresponding to the slice.
			//		ListViewItem item = this.listViewSlices.Items.FirstOrDefault((ListViewItem it) =>
			//			{
			//				// Get the slice info.
			//				SliceInfo info = (SliceInfo)it.Tag;
			//				// Return true if the item corresponds to the same slice.
			//				return object.ReferenceEquals(slice, info.Slice);
			//			});
			//		// If the item is not null.
			//		if (null != item)
			//		{
			//			// Update the item.
			//			item.SubItems[0].Text = slice.Id.HasValue ? slice.Id.Value.ToString() : string.Empty;
			//			item.SubItems[1].Text = slice.Name;
			//			item.SubItems[2].Text = slice.Created.ToString();
			//			item.SubItems[3].Text = slice.Expires.ToString();
			//			item.SubItems[4].Text = slice.NodeIds != null ? slice.NodeIds.Length.ToString() : "0";
			//			item.SubItems[5].Text = slice.MaxNodes.ToString();
			//		}
			//	}
			//}
		}

		/// <summary>
		/// A method called when the refresh slice request has finished.
		/// </summary>
		/// <param name="state">The request state.</param>
		private void OnRefreshSliceRequestFinished(RequestState state)
		{
			//// Enable the slices list.
			//this.listViewSlices.Enabled = true;
			//// Refresh the list selection.
			//this.OnSelectionChanged(this, EventArgs.Empty);
		}

		/// <summary>
		/// An event handler called when the user removes a slice from nodes.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnRemoveFromNodes(object sender, EventArgs e)
		{
			//// If there is no validated PlanetLab person account, show a message and return.
			//if (-1 == CrawlerStatic.PlanetLabPersonId)
			//{
			//	MessageBox.Show(this, "You must set and validate a PlanetLab account in the settings page before configuring the PlanetLab slices.", "PlanetLab Account Not Configured", MessageBoxButtons.OK, MessageBoxIcon.Error);
			//	return;
			//}

			//// If there is no selected slice, do nothing.
			//if (this.listViewSlices.SelectedItems.Count == 0) return;

			//// Get the slice.
			//SliceInfo info = (SliceInfo)this.listViewSlices.SelectedItems[0].Tag;

			//// If the slice does not have an ID, show an error message and return.
			//if (!info.Slice.Id.HasValue)
			//{
			//	MessageBox.Show(this, "The selected slice does not have an identifier.", "Remove Slice to Nodes", MessageBoxButtons.OK, MessageBoxIcon.Error);
			//	return;
			//}

			//// Show the remove slice from node dialog.
			//if (this.formRemoveSliceFromNodes.ShowDialog(this, info.Slice) == DialogResult.OK)
			//{
			//	// Get the PlanetLab node IDs.
			//	int[] ids = this.formRemoveSliceFromNodes.Result;

			//	// Update the status.
			//	this.status.Send(
			//		"Showing {0} PlanetLab slices.".FormatWith(this.crawler.Config.PlanetLab.LocalSlices.Count),
			//		"Removing slice {0} from the PlanetLab nodes...",
			//		Resources.GlobeLab_16,
			//		Resources.GlobeClock_16);

			//	// Create the request state.
			//	SliceIdsRequestState requestState = new SliceIdsRequestState(
			//		this.OnRemoveSliceFromNodesRequestStarted,
			//		this.OnRemoveSliceFromNodesRequestResult,
			//		this.OnRemoveSliceFromNodesRequestCanceled,
			//		this.OnRemoveSliceFromNodesRequestException,
			//		this.OnRemoveSliceFromNodesRequestFinished,
			//		info.Slice,
			//		ids);

			//	// Begin an asynchronous PlanetLab request.
			//	this.BeginRequest(
			//		this.requestRemoveSliceFromNodes,
			//		this.crawler.Config.PlanetLab.Username,
			//		this.crawler.Config.PlanetLab.Password,
			//		new object[] { info.Slice.Id.Value, ids },
			//		requestState);
			//}
		}

		/// <summary>
		/// A method called when the add slice to nodes request started.
		/// </summary>
		/// <param name="state">The request state.</param>
		private void OnRemoveSliceFromNodesRequestStarted(RequestState state)
		{
			//// Disable the slices list.
			//this.listViewSlices.Enabled = false;
		}

		/// <summary>
		/// A method called when receiving the response to a remove slice to nodes request.
		/// </summary>
		/// <param name="response">The response.</param>
		/// <param name="state">The request state.</param>
		private void OnRemoveSliceFromNodesRequestResult(XmlRpcResponse response, RequestState state)
		{
			// Convert the request state.
			SliceIdsRequestState requestState = state as SliceIdsRequestState;
			// If the request has not failed.
			if ((null == response.Fault) && (null != response.Value))
			{
				// Get the response value.
				int? code = response.Value.AsInt;
				if (code.HasValue ? 1 == code.Value : false)
				{
					// Update the status.
					this.status.Send(
						"Showing {0} PlanetLab slices.".FormatWith(this.crawler.Config.PlanetLab.LocalSlices.Count),
						"Removing slice {0} from {1} PlanetLab node{2} succeeded.".FormatWith(requestState.Slice.Id, requestState.Ids.Length, requestState.Ids.Length == 1 ? string.Empty : "s"),
						Resources.GlobeLab_16,
						Resources.GlobeSuccess_16);

					// Set the request as successful.
					requestState.Success = true;
				}
				else
				{
					// Show a dialog.
					MessageBox.Show(this,
						"Cannot remove the slice {0} from {1} PlanetLab node{2}. The PlanetLab server responded, however the operation was not successful.".FormatWith(requestState.Slice.Id, requestState.Ids.Length, requestState.Ids.Length == 1 ? string.Empty : "s"),
						"Remove Slice from Node",
						MessageBoxButtons.OK,
						MessageBoxIcon.Warning);
					// Update the status.
					this.status.Send(
						"Showing {0} PlanetLab slices.".FormatWith(this.crawler.Config.PlanetLab.LocalSlices.Count),
						"Removing slice {0} from {1} PlanetLab node{2} failed.".FormatWith(requestState.Slice.Id, requestState.Ids.Length, requestState.Ids.Length == 1 ? string.Empty : "s"),
						Resources.GlobeLab_16,
						Resources.GlobeWarning_16);
				}
			}
			else
			{
				// Update the status.
				this.status.Send(
					"Showing {0} PlanetLab slices.".FormatWith(this.crawler.Config.PlanetLab.LocalSlices.Count),
					"Removing slice {0} from {1} PlanetLab node{2} failed.".FormatWith(requestState.Slice.Id, requestState.Ids.Length, requestState.Ids.Length == 1 ? string.Empty : "s"),
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
			SliceIdsRequestState requestState = state as SliceIdsRequestState;
			// Update the status.
			this.status.Send(
				"Showing {0} PlanetLab slices.".FormatWith(this.crawler.Config.PlanetLab.LocalSlices.Count),
				"Removing the slice {0} from {1} PlanetLab node{2} was canceled.".FormatWith(requestState.Slice.Id, requestState.Ids.Length, requestState.Ids.Length == 1 ? string.Empty : "s"),
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
			SliceIdsRequestState requestState = state as SliceIdsRequestState;
			// Update the status.
			this.status.Send(
				"Showing {0} PlanetLab slices.".FormatWith(this.crawler.Config.PlanetLab.LocalSlices.Count),
				"Removing the slice {0} from {1} PlanetLab node{2} failed.".FormatWith(requestState.Slice.Id, requestState.Ids.Length, requestState.Ids.Length == 1 ? string.Empty : "s"),
				Resources.GlobeLab_16,
				Resources.GlobeError_16);
		}

		/// <summary>
		/// A method called when the add slice to nodes request has finished.
		/// </summary>
		/// <param name="state">The request state.</param>
		private void OnRemoveSliceFromNodesRequestFinished(RequestState state)
		{
			//// Enable the slices list.
			//this.listViewSlices.Enabled = true;
			//// Refresh the list selection.
			//this.OnSelectionChanged(this, EventArgs.Empty);

			//// If the request is successful.
			//if (state.Success)
			//{
			//	// Get the request state.
			//	SliceRequestState requestState = state as SliceRequestState;

			//	// Refresh the slice information.
			//	this.OnRefreshSlice(requestState.Slice);
			//}
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
			this.formText.ShowDialog(this, "Slice Private Key", this.config.Key != null ? Encoding.UTF8.GetString(this.config.Key).Replace("\n", Environment.NewLine) : string.Empty);
		}
	}
}
