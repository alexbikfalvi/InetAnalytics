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
using System.Windows.Forms;
using DotNetApi;
using DotNetApi.Web;
using DotNetApi.Web.XmlRpc;
using DotNetApi.Windows.Controls;
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
	/// A control class for PlanetLab slices.
	/// </summary>
	public sealed partial class ControlSlices : ControlRequest
	{
		private static readonly string logSource = "PlanetLab";
		
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

		/// <summary>
		/// A structure representing the slice information.
		/// </summary>
		private struct SliceInfo
		{
			/// <summary>
			/// Creates a new slice information variable.
			/// </summary>
			/// <param name="slice">The PlanetLab slice.</param>
			/// <param name="node">The tree node.</param>
			/// <param name="control">The control.</param>
			public SliceInfo(PlSlice slice, TreeNode node, Control control)
				: this()
			{
				this.Slice = slice;
				this.Node = node;
				this.Control = control;
			}

			/// <summary>
			/// Gets the PlanetLab slice.
			/// </summary>
			public PlSlice Slice { get; private set; }
			/// <summary>
			/// Gets the tree node.
			/// </summary>
			public TreeNode Node { get; private set; }
			/// <summary>
			/// Gets the control.
			/// </summary>
			public Control Control { get; private set; }
		}

		// Private variables.

		private Crawler crawler = null;
		private StatusHandler status = null;

		private TreeNode treeNode = null;
		private Control.ControlCollection controls = null;
		private ImageList treeImageList = null;

		private PlRequest requestGetSlices = new PlRequest(PlRequest.RequestMethod.GetSlices);
		private PlRequest requestAddSliceToNodes = new PlRequest(PlRequest.RequestMethod.AddSliceToNodes);
		private PlRequest requestRemoveSliceFromNodes = new PlRequest(PlRequest.RequestMethod.DeleteSliceFromNodes);

		private FormObjectProperties<ControlSliceProperties> formSliceProperties = new FormObjectProperties<ControlSliceProperties>();
		private FormAddSlice formAddSlice = new FormAddSlice();
		private FormAddSliceToNodesLocation formAddSliceToNodesLocation = new FormAddSliceToNodesLocation();
		private FormAddSliceToNodesState formAddSliceToNodesState = new FormAddSliceToNodesState();
		private FormAddSliceToNodesSlice formAddSliceToNodesSlice = new FormAddSliceToNodesSlice();
		private FormRemoveSliceFromNodes formRemoveSliceFromNodes = new FormRemoveSliceFromNodes();

		private RequestState requestStateGetSlices;

		// Public declarations

		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlSlices()
		{
			// Initialize component.
			InitializeComponent();

			// Set the default control properties.
			this.Visible = false;
			this.Dock = DockStyle.Fill;

			// Create the request states.
			this.requestStateGetSlices = new RequestState(
				null, this.OnRefreshSlicesRequestResult, this.OnRefreshSlicesRequestCanceled, this.OnRefreshSlicesRequestException, null);
		}

		/// <summary>
		/// Initializes the control with a crawler object.
		/// </summary>
		/// <param name="crawler">The crawler object.</param>
		/// <param name="treeNode">The root tree node for the database servers.</param>
		/// <param name="controls">The panel where to add the server control.</param>
		/// <param name="imageList">The image list.</param>
		public void Initialize(Crawler crawler, TreeNode treeNode, Control.ControlCollection controls, ImageList imageList)
		{
			// Save the parameters.
			this.crawler = crawler;

			// Get the status handler.
			this.status = this.crawler.Status.GetHandler(this);

			// Set the tree node.
			this.treeNode = treeNode;

			// Set the control collection.
			this.controls = controls;

			// Set the tree image list.
			this.treeImageList = imageList;
		
			// Enable the control.
			this.Enabled = true;

			// Update the list of PlanetLab slices.
			this.OnUpdateSlices();
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
			this.buttonAddSlice.Enabled = false;
			this.buttonRemoveSlice.Enabled = false;
			this.buttonAddToNodes.Enabled = false;
			this.buttonRemoveFromNodes.Enabled = false;
			this.menuItemProperties.Enabled = false;
			this.menuItemAddToNodes.Enabled = false;
			this.menuItemRemoveFromNodes.Enabled = false;
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
			this.buttonAddSlice.Enabled = true;
			// Call the base class method.
			base.OnRequestFinished(state);
		}

		// Private methods.

		/// <summary>
		/// An event handler called when a slice has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSliceChanged(object sender, PlEventArgs e)
		{
			// Get the slice.
			PlSlice slice = e.Object as PlSlice;
			// Find the list view item corresponding to the slice.
			ListViewItem item = this.listViewSlices.Items.FirstOrDefault((ListViewItem it) =>
			{
				// Get the slice info.
				SliceInfo info = (SliceInfo)it.Tag;
				// Return true if the item corresponds to the same slice.
				return object.ReferenceEquals(slice, info.Slice);
			});
			// If the item is not null.
			if (null != item)
			{
				// Update the item.
				item.SubItems[0].Text = slice.Id.HasValue ? slice.Id.Value.ToString() : string.Empty;
				item.SubItems[1].Text = slice.Name;
				item.SubItems[2].Text = slice.Created.ToString();
				item.SubItems[3].Text = slice.Expires.ToString();
				item.SubItems[4].Text = slice.NodeIds != null ? slice.NodeIds.Length.ToString() : "0";
				item.SubItems[5].Text = slice.MaxNodes.ToString();
			}
		}

		/// <summary>
		/// Clears the current list of slices.
		/// </summary>
		private void OnClearSlices()
		{
			// For all items.
			foreach (ListViewItem item in this.listViewSlices.Items)
			{
				// Get the slice info.
				SliceInfo info = (SliceInfo) item.Tag;
				// Remove the slice changed event handler.
				info.Slice.Changed -= this.OnSliceChanged;
				// Remove the tree node.
				this.treeNode.Nodes.Remove(info.Node);
				// Remove the control.
				// *** this.controls.Remove(info.Control);
				// Dispose the control.
				// *** info.Control.Dispose();
			}
			// Clear the list view.
			this.listViewSlices.Items.Clear();
		}

		/// <summary>
		/// Adds a slice to the current control.
		/// </summary>
		/// <param name="slice">The slice.</param>
		private void OnAddSlice(PlSlice slice)
		{
			// Create a new tree node.
			TreeNode node = new TreeNode(slice.Name);
			node.ImageKey = "GlobeObject";
			node.SelectedImageKey = "GlobeObject";
			this.treeNode.Nodes.Add(node);
			
			// Create a new control.
			Control control = null;

			// Create the list view item.
			ListViewItem item = new ListViewItem(new string[] {
						slice.Id.HasValue ? slice.Id.Value.ToString() : string.Empty,
						slice.Name,
						slice.Created.ToString(),
						slice.Expires.ToString(),
						slice.NodeIds != null ? slice.NodeIds.Length.ToString() : "0",
						slice.MaxNodes.ToString()
					}, 0);
			item.Tag = new SliceInfo(slice, node, control);

			// Add the item to the list view.
			this.listViewSlices.Items.Add(item);

			// Add the slice changed event handler.
			slice.Changed += this.OnSliceChanged;
		}

		/// <summary>
		/// An event handler called when the user refreshes the list of PlanetLab slices.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnRefresh(object sender, EventArgs e)
		{
			// If there is no validated PlanetLab person account, show a message and return.
			if (-1 == CrawlerStatic.PlanetLabPersonId)
			{
				MessageBox.Show(this, "You must set and validate a PlanetLab account in the settings page before configuring the PlanetLab slices.", "PlanetLab Account Not Configured", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			// Warn the user about the refresh.
			if (MessageBox.Show(
				this,
				"You will now refresh the list with the slices to which you have access with your PlanetLab account. This will remove the configuration of slices that are no longer available. Click Yes to continue.",
				"Refresh PlanetLab Slices",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Question,
				MessageBoxDefaultButton.Button2) == DialogResult.No)
			{
				return;
			}

			// Clear the current list of slices.
			this.OnClearSlices();

			// Update the status.
			this.status.Send("Refreshing the list of PlanetLab slices...", Resources.GlobeClock_16);

			// Log
			this.controlLog.Add(this.crawler.Log.Add(
				LogEventLevel.Verbose,
				LogEventType.Information,
				ControlSlices.logSource,
				"Refreshing the list of PlanetLab slices."));

			// Begin an asynchronous PlanetLab request.
			this.BeginRequest(
				this.requestGetSlices,
				this.crawler.Config.PlanetLab.Username,
				this.crawler.Config.PlanetLab.Password,
				null,
				this.requestStateGetSlices);
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
		/// A method called when receiving the response to a slices refresh request.
		/// </summary>
		/// <param name="response">The response.</param>
		/// <param name="state">The request state.</param>
		private void OnRefreshSlicesRequestResult(XmlRpcResponse response, RequestState state)
		{
			// If the request has not failed.
			if ((null == response.Fault) && (null != response.Value))
			{
				// Get the slices array.
				XmlRpcArray slices = response.Value as XmlRpcArray;

				// Update the list of PlanetLab local slices, filtering by the current person account.
				this.crawler.Config.PlanetLab.LocalSlices.Update(slices.Where((XmlRpcValue value) =>
					{
						XmlRpcStruct str = value.Value as XmlRpcStruct;
						if (null == str) return false;

						XmlRpcMember member = str[PlSlice.Fields.PersonIds.GetName()];
						if (null == member) return false;

						XmlRpcArray array = member.Value.Value as XmlRpcArray;
						if (null == array) return false;

						return array.Contains(CrawlerStatic.PlanetLabPersonId);
					}));

				// Update the list of slices.
				this.OnUpdateSlices();

				// Log
				this.controlLog.Add(this.crawler.Log.Add(
					LogEventLevel.Verbose,
					LogEventType.Success,
					ControlSlices.logSource,
					"Refreshing the list of PlanetLab slices completed successfully."));
			}
			else
			{
				// Update the status.
				this.status.Send("Refreshing the list of PlanetLab slices failed.", Resources.GlobeError_16);
				if (null == response.Fault)
				{
					// Log
					this.controlLog.Add(this.crawler.Log.Add(
						LogEventLevel.Important,
						LogEventType.Error,
						ControlSlices.logSource,
						"Refreshing the list of PlanetLab slices failed."));
				}
				else
				{
					// Log
					this.controlLog.Add(this.crawler.Log.Add(
						LogEventLevel.Important,
						LogEventType.Error,
						ControlSlices.logSource,
						"Refreshing the list of PlanetLab slices failed with code {0} ({1}).",
						new object[] { response.Fault.FaultCode, response.Fault.FaultString }));
				}
			}
		}

		/// <summary>
		/// A method called when the get slices request has been canceled.
		/// </summary>
		/// <param name="state">The request state.</param>
		private void OnRefreshSlicesRequestCanceled(RequestState state)
		{
			// Update the status.
			this.status.Send("Refreshing the list of PlanetLab slices was canceled.", Resources.GlobeCanceled_16);
			// Log
			this.controlLog.Add(this.crawler.Log.Add(
				LogEventLevel.Verbose,
				LogEventType.Canceled,
				ControlSlices.logSource,
				"Refreshing the list of PlanetLab slices was canceled."));
		}

		/// <summary>
		/// A method called when the get slices request returned an exception.
		/// </summary>
		/// <param name="exception">The exception.</param>
		/// <param name="state">The request state.</param>
		private void OnRefreshSlicesRequestException(Exception exception, RequestState state)
		{
			// Update the status.
			this.status.Send("Refreshing the list of PlanetLab slices failed.", Resources.GlobeError_16);
			// Log
			this.controlLog.Add(this.crawler.Log.Add(
				LogEventLevel.Important,
				LogEventType.Error,
				ControlSlices.logSource,
				"Refreshing the list of PlanetLab slices failed. {1}",
				new object[] { exception.Message },
				exception));
		}

		/// <summary>
		/// Updates the list of PlanetLab slices.
		/// </summary>
		private void OnUpdateSlices()
		{
			// Clear the current slices.
			this.OnClearSlices();

			// Lock the slices list.
			this.crawler.Config.PlanetLab.LocalSlices.Lock();
			try
			{
				// Add the list view items.
				foreach (PlSlice slice in this.crawler.Config.PlanetLab.LocalSlices)
				{
					this.OnAddSlice(slice);
				}
			}
			finally
			{
				this.crawler.Config.PlanetLab.LocalSlices.Unlock();
			}

			// Update the label.
			this.status.Send("Showing {0} PlanetLab slices.".FormatWith(this.crawler.Config.PlanetLab.LocalSlices.Count), Resources.GlobeLab_16);
		}

		/// <summary>
		/// An event handler called when the slice selection has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSelectionChanged(object sender, EventArgs e)
		{
			if (this.listViewSlices.SelectedItems.Count > 0)
			{
				this.buttonProperties.Enabled = true;
				this.buttonRemoveSlice.Enabled = true;
				this.buttonAddToNodes.Enabled = true;
				this.buttonRemoveFromNodes.Enabled = true;
				this.menuItemProperties.Enabled = true;
				this.menuItemAddToNodes.Enabled = true;
				this.menuItemRemoveFromNodes.Enabled = true;
			}
			else
			{
				this.buttonProperties.Enabled = false;
				this.buttonRemoveSlice.Enabled = false;
				this.buttonAddToNodes.Enabled = false;
				this.buttonRemoveFromNodes.Enabled = false;
				this.menuItemProperties.Enabled = false;
				this.menuItemAddToNodes.Enabled = false;
				this.menuItemRemoveFromNodes.Enabled = false;
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
			if (this.listViewSlices.SelectedItems.Count == 0) return;

			// Get the slice info for this item.
			SliceInfo info = (SliceInfo)this.listViewSlices.SelectedItems[0].Tag;

			// Show the site properties.
			this.formSliceProperties.ShowDialog(this, "Slice", info.Slice);
		}

		/// <summary>
		/// An event handler called when the user adds a new slice.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnAddSlice(object sender, EventArgs e)
		{
			// Show the add slice dialog.
			if (this.formAddSlice.ShowDialog(this, this.crawler.Config) == DialogResult.OK)
			{
				// Add the slice to the slices list.
				this.crawler.Config.PlanetLab.LocalSlices.Add(this.formAddSlice.Result);
				// Add the slice.
				this.OnAddSlice(this.formAddSlice.Result);
			}
		}

		/// <summary>
		/// An event handler called when the user removes an existing slice.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnRemoveSlice(object sender, EventArgs e)
		{
			// If there are no selected slices, do nothing.
			if (this.listViewSlices.SelectedItems.Count == 0) return;
			// Get the selected item.
			ListViewItem item = this.listViewSlices.SelectedItems[0];
			// Get the slice info.
			SliceInfo info = (SliceInfo)item.Tag;
			// Else, ask user confirmation.
			if (MessageBox.Show(
				this,
				"You are removing the slice \'{0}\' from your slices list. Do you want to continue?".FormatWith(info.Slice.Name),
				"Remove Slice",
				MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
			{
				// Remove the slice.
				this.crawler.Config.PlanetLab.LocalSlices.Remove(info.Slice);
				// Remove the slice changed event handler.
				info.Slice.Changed -= this.OnSliceChanged;
				// Remove the list view item.
				this.listViewSlices.Items.Remove(item);
				// Remove the tree node.
				this.treeNode.Nodes.Remove(info.Node);
				// Remove the control.
				// *** this.controls.Remove(info.Control);
				// Dispose the control.
				// *** info.Control.Dispose();
			}
		}

		/// <summary>
		/// An event handler called when the user adds a slice to nodes selected by location.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnAddToNodesLocation(object sender, EventArgs e)
		{
			// If there is no validated PlanetLab person account, show a message and return.
			if (-1 == CrawlerStatic.PlanetLabPersonId)
			{
				MessageBox.Show(this, "You must set and validate a PlanetLab account in the settings page before configuring the PlanetLab slices.", "PlanetLab Account Not Configured", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			// If there is no selected slice, do nothing.
			if (this.listViewSlices.SelectedItems.Count == 0) return;

			// Get the slice info.
			SliceInfo info = (SliceInfo)this.listViewSlices.SelectedItems[0].Tag;

			// Show the add slice to nodes by location dialog.
			if (this.formAddSliceToNodesLocation.ShowDialog(this, this.crawler.Config) == DialogResult.OK)
			{
				// Add the slice to nodes.
				this.OnAddSliceToNodes(info.Slice, this.formAddSliceToNodesLocation.Result);
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
			if (-1 == CrawlerStatic.PlanetLabPersonId)
			{
				MessageBox.Show(this, "You must set and validate a PlanetLab account in the settings page before configuring the PlanetLab slices.", "PlanetLab Account Not Configured", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			// If there is no selected slice, do nothing.
			if (this.listViewSlices.SelectedItems.Count == 0) return;

			// Get the slice.
			SliceInfo info = (SliceInfo)this.listViewSlices.SelectedItems[0].Tag;

			// Show the add slice to nodes by state dialog.
			if (this.formAddSliceToNodesState.ShowDialog(this, this.crawler.Config) == DialogResult.OK)
			{
				// Add the slice to nodes.
				this.OnAddSliceToNodes(info.Slice, this.formAddSliceToNodesState.Result);
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
			if (-1 == CrawlerStatic.PlanetLabPersonId)
			{
				MessageBox.Show(this, "You must set and validate a PlanetLab account in the settings page before configuring the PlanetLab slices.", "PlanetLab Account Not Configured", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			// If there is no selected slice, do nothing.
			if (this.listViewSlices.SelectedItems.Count == 0) return;

			// Get the slice.
			SliceInfo info = (SliceInfo)this.listViewSlices.SelectedItems[0].Tag;

			// Show the add slice to nodes by state dialog.
			if (this.formAddSliceToNodesSlice.ShowDialog(this, this.crawler.Config) == DialogResult.OK)
			{
				// Add the slice to nodes.
				this.OnAddSliceToNodes(info.Slice, this.formAddSliceToNodesSlice.Result);
			}
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

			// Log
			this.controlLog.Add(this.crawler.Log.Add(
				LogEventLevel.Verbose,
				LogEventType.Information,
				ControlSlices.logSource,
				"Adding slice {0} to {1} PlanetLab node{2}.",
				new object[] { slice.Id, ids.Length, ids.Length == 1 ? string.Empty : "s" }));

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
			// Disable the slices list.
			this.listViewSlices.Enabled = false;
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
					// Log
					this.controlLog.Add(this.crawler.Log.Add(
						LogEventLevel.Verbose,
						LogEventType.Success,
						ControlSlices.logSource,
						"Adding slice {0} to {1} PlanetLab node{2} completed successfully.",
						new object[] { requestState.Slice.Id, requestState.Ids.Length, requestState.Ids.Length == 1 ? string.Empty : "s" }));

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
					// Log
					this.controlLog.Add(this.crawler.Log.Add(
						LogEventLevel.Important,
						LogEventType.Error,
						ControlSlices.logSource,
						"Adding slice {0} to {1} PlanetLab node{2} failed.",
						new object[] { requestState.Slice.Id, requestState.Ids.Length, requestState.Ids.Length == 1 ? string.Empty : "s" }));
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
				if (null == response.Fault)
				{
					// Log
					this.controlLog.Add(this.crawler.Log.Add(
						LogEventLevel.Important,
						LogEventType.Error,
						ControlSlices.logSource,
						"Adding slice {0} to {1} PlanetLab node{2} failed.",
						new object[] { requestState.Slice.Id, requestState.Ids.Length, requestState.Ids.Length == 1 ? string.Empty : "s" }));
				}
				else
				{
					// Log
					this.controlLog.Add(this.crawler.Log.Add(
						LogEventLevel.Important,
						LogEventType.Error,
						ControlSlices.logSource,
						"Adding slice {0} to {1} PlanetLab node{2} failed with code {3} ({4}).",
						new object[] { requestState.Slice.Id, requestState.Ids.Length, requestState.Ids.Length == 1 ? string.Empty : "s", response.Fault.FaultCode, response.Fault.FaultString }));
				}
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
			// Log
			this.controlLog.Add(this.crawler.Log.Add(
				LogEventLevel.Verbose,
				LogEventType.Canceled,
				ControlSlices.logSource,
				"Adding the slice {0} to {1} PlanetLab node{2} was canceled.",
				new object[] { requestState.Slice.Id, requestState.Ids.Length, requestState.Ids.Length == 1 ? string.Empty : "s" }));
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
			// Log
			this.controlLog.Add(this.crawler.Log.Add(
				LogEventLevel.Important,
				LogEventType.Error,
				ControlSlices.logSource,
				"Adding the slice {0} to {1} PlanetLab node{2} failed. {3}",
				new object[] { requestState.Slice.Id, requestState.Ids.Length, requestState.Ids.Length == 1 ? string.Empty : "s", exception.Message },
				exception));
		}

		/// <summary>
		/// A method called when the add slice to nodes request has finished.
		/// </summary>
		/// <param name="state">The request state.</param>
		private void OnAddSliceToNodesRequestFinished(RequestState state)
		{
			// Enable the slices list.
			this.listViewSlices.Enabled = true;
			// Refresh the list selection.
			this.OnSelectionChanged(this, EventArgs.Empty);

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
			// Disable the slices list.
			this.listViewSlices.Enabled = false;
		}

		/// <summary>
		/// A method called when receiving the response to a refresh slice request.
		/// </summary>
		/// <param name="response">The response.</param>
		/// <param name="state">The request state.</param>
		private void OnRefreshSliceRequestResult(XmlRpcResponse response, RequestState state)
		{
			// Convert the request state.
			SliceRequestState requestState = state as SliceRequestState;
			// Get the slice.
			PlSlice slice = requestState.Slice;
			// If the request has not failed.
			if ((null == response.Fault) && (null != response.Value))
			{
				// Get the slices list.
				XmlRpcArray slices = response.Value as XmlRpcArray;

				// If the response list has one element.
				if (null != slices ? slices.Values.Length == 1 : false)
				{
					// Update the slice.
					slice.Parse(slices.Values[0].Value as XmlRpcStruct);
				}
			}
		}

		/// <summary>
		/// A method called when the refresh slice request has finished.
		/// </summary>
		/// <param name="state">The request state.</param>
		private void OnRefreshSliceRequestFinished(RequestState state)
		{
			// Enable the slices list.
			this.listViewSlices.Enabled = true;
			// Refresh the list selection.
			this.OnSelectionChanged(this, EventArgs.Empty);
		}

		/// <summary>
		/// An event handler called when the user removes a slice from nodes.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnRemoveFromNodes(object sender, EventArgs e)
		{
			// If there is no validated PlanetLab person account, show a message and return.
			if (-1 == CrawlerStatic.PlanetLabPersonId)
			{
				MessageBox.Show(this, "You must set and validate a PlanetLab account in the settings page before configuring the PlanetLab slices.", "PlanetLab Account Not Configured", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			// If there is no selected slice, do nothing.
			if (this.listViewSlices.SelectedItems.Count == 0) return;

			// Get the slice.
			SliceInfo info = (SliceInfo)this.listViewSlices.SelectedItems[0].Tag;

			// If the slice does not have an ID, show an error message and return.
			if (!info.Slice.Id.HasValue)
			{
				MessageBox.Show(this, "The selected slice does not have an identifier.", "Remove Slice to Nodes", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			// Show the remove slice from node dialog.
			if (this.formRemoveSliceFromNodes.ShowDialog(this, info.Slice) == DialogResult.OK)
			{
				// Get the PlanetLab node IDs.
				int[] ids = this.formRemoveSliceFromNodes.Result;

				// Update the status.
				this.status.Send(
					"Showing {0} PlanetLab slices.".FormatWith(this.crawler.Config.PlanetLab.LocalSlices.Count),
					"Removing slice {0} from {1} PlanetLab node{2}...".FormatWith(info.Slice.Id, ids.Length, ids.Length == 1 ? string.Empty : "s"),
					Resources.GlobeLab_16,
					Resources.GlobeClock_16);
				// Log
				this.controlLog.Add(this.crawler.Log.Add(
					LogEventLevel.Verbose,
					LogEventType.Information,
					ControlSlices.logSource,
					"Removing slice {0} from {1} PlanetLab node{2}.",
					new object[] { info.Slice.Id, ids.Length, ids.Length == 1 ? string.Empty : "s" }));

				// Create the request state.
				SliceIdsRequestState requestState = new SliceIdsRequestState(
					this.OnRemoveSliceFromNodesRequestStarted,
					this.OnRemoveSliceFromNodesRequestResult,
					this.OnRemoveSliceFromNodesRequestCanceled,
					this.OnRemoveSliceFromNodesRequestException,
					this.OnRemoveSliceFromNodesRequestFinished,
					info.Slice,
					ids);

				// Begin an asynchronous PlanetLab request.
				this.BeginRequest(
					this.requestRemoveSliceFromNodes,
					this.crawler.Config.PlanetLab.Username,
					this.crawler.Config.PlanetLab.Password,
					new object[] { info.Slice.Id.Value, ids },
					requestState);
			}
		}

		/// <summary>
		/// A method called when the add slice to nodes request started.
		/// </summary>
		/// <param name="state">The request state.</param>
		private void OnRemoveSliceFromNodesRequestStarted(RequestState state)
		{
			// Disable the slices list.
			this.listViewSlices.Enabled = false;
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

					// Log
					this.controlLog.Add(this.crawler.Log.Add(
						LogEventLevel.Verbose,
						LogEventType.Success,
						ControlSlices.logSource,
						"Removing slice {0} from {1} PlanetLab node{2} completed successfully.",
						new object[] { requestState.Slice.Id, requestState.Ids.Length, requestState.Ids.Length == 1 ? string.Empty : "s" }));

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
				if (null == response.Fault)
				{
					// Log
					this.controlLog.Add(this.crawler.Log.Add(
						LogEventLevel.Important,
						LogEventType.Error,
						ControlSlices.logSource,
						"Removing slice {0} from {1} PlanetLab node{2} failed.",
						new object[] { requestState.Slice.Id, requestState.Ids.Length, requestState.Ids.Length == 1 ? string.Empty : "s" }));
				}
				else
				{
					// Log
					this.controlLog.Add(this.crawler.Log.Add(
						LogEventLevel.Important,
						LogEventType.Error,
						ControlSlices.logSource,
						"Removing slice {0} from {1} PlanetLab node{2} failed with code {3} ({4}).",
						new object[] { requestState.Slice.Id, requestState.Ids.Length, requestState.Ids.Length == 1 ? string.Empty : "s", response.Fault.FaultCode, response.Fault.FaultString }));
				}
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
			// Log
			this.controlLog.Add(this.crawler.Log.Add(
				LogEventLevel.Verbose,
				LogEventType.Canceled,
				ControlSlices.logSource,
				"Removing the slice {0} from {1} PlanetLab node{2} was canceled.",
				new object[] { requestState.Slice.Id, requestState.Ids.Length, requestState.Ids.Length == 1 ? string.Empty : "s" }));
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
			// Log
			this.controlLog.Add(this.crawler.Log.Add(
				LogEventLevel.Important,
				LogEventType.Error,
				ControlSlices.logSource,
				"Removing the slice {0} from {1} PlanetLab node{2} failed. {3}",
				new object[] { requestState.Slice.Id, requestState.Ids.Length, requestState.Ids.Length == 1 ? string.Empty : "s", exception.Message },
				exception));
		}

		/// <summary>
		/// A method called when the add slice to nodes request has finished.
		/// </summary>
		/// <param name="state">The request state.</param>
		private void OnRemoveSliceFromNodesRequestFinished(RequestState state)
		{
			// Enable the slices list.
			this.listViewSlices.Enabled = true;
			// Refresh the list selection.
			this.OnSelectionChanged(this, EventArgs.Empty);

			// If the request is successful.
			if (state.Success)
			{
				// Get the request state.
				SliceRequestState requestState = state as SliceRequestState;

				// Refresh the slice information.
				this.OnRefreshSlice(requestState.Slice);
			}
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
				if (this.listViewSlices.FocusedItem != null)
				{
					if (this.listViewSlices.FocusedItem.Bounds.Contains(e.Location))
					{
						this.contextMenu.Show(this.listViewSlices, e.Location);
					}
				}
			}
		}
	}
}
