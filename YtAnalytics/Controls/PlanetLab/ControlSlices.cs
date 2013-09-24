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
using YtCrawler.Status;

namespace YtAnalytics.Controls.PlanetLab
{
	/// <summary>
	/// A control class for PlanetLab slices.
	/// </summary>
	public partial class ControlSlices : ControlRequest
	{
		// Private variables.

		private Crawler crawler = null;
		private StatusHandler status = null;

		private PlRequest requestGetSlices = new PlRequest(PlRequest.RequestMethod.GetSlices);

		private FormObjectProperties<ControlSliceProperties> formSliceProperties = new FormObjectProperties<ControlSliceProperties>();
		private FormAddSlice formAddSlice = new FormAddSlice();
		private FormAddNodeLocation formAddNodeLocation = new FormAddNodeLocation();

		private Action<XmlRpcResponse> actionCompleteSlicesRequest;
		private Action<XmlRpcResponse> actionCompleteAddNodeRequest;

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

			// Create the delegates.
			this.actionCompleteSlicesRequest = new Action<XmlRpcResponse>(this.OnCompleteSlicesRequest);
			this.actionCompleteAddNodeRequest = new Action<XmlRpcResponse>(this.OnCompleteAddNodeRequest);
		}

		/// <summary>
		/// Initializes the control with a crawler object.
		/// </summary>
		/// <param name="crawler">The crawler object.</param>
		public void Initialize(Crawler crawler)
		{
			// Save the parameters.
			this.crawler = crawler;

			// Get the status handler.
			this.status = this.crawler.Status.GetHandler(this);
		
			// Enable the control.
			this.Enabled = true;

			// Update the list of PlanetLab slices.
			this.OnUpdateSlices();
		}

		// Protected methods.

		/// <summary>
		/// An event handler called when the current request begins, and the notification box is displayed.
		/// </summary>
		/// <param name="parameters">The task parameters.</param>
		protected override void OnBeginRequest(object[] parameters = null)
		{
			// Set the button enabled state.
			this.buttonRefresh.Enabled = false;
			this.buttonCancel.Enabled = true;
			this.buttonProperties.Enabled = false;
			this.buttonAddSlice.Enabled = false;
			this.buttonRemoveSlice.Enabled = false;
			this.buttonAddNode.Enabled = false;
			this.buttonRemoveNode.Enabled = false;
		}

		/// <summary>
		/// An event handler called when the control completes an asynchronous request for a PlanetLab resource.
		/// </summary>
		/// <param name="response">The XML-RPC response.</param>
		/// <param name="state">The request state.</param>
		protected override void OnCompleteRequest(XmlRpcResponse response, object state)
		{
			// Get the action delegate from the user state.
			Action<XmlRpcResponse> action = state as Action<XmlRpcResponse>;
			// If the action delegate is not null.
			if (null != action)
			{
				// Call the delegate with the current response.
				action(response);
			}
		}

		/// <summary>
		/// An event handler called when an asynchronous request for a PlanetLab resource was canceled.
		/// </summary>
		protected override void OnCancelRequest()
		{
			// Set the button enabled state.
			this.buttonCancel.Enabled = false;
			// Update the status.
			this.status.Send("Refreshing the list of PlanetLab slices canceled.", Resources.GlobeCanceled_16);
		}

		/// <summary>
		/// An event handler called when the current request ends, and the notification box is hidden.
		/// </summary>
		/// <param name="parameters">The task parameters.</param>
		protected override void OnEndRequest(object[] parameters = null)
		{
			// Set the button enabled state.
			this.buttonRefresh.Enabled = true;
			this.buttonCancel.Enabled = false;
			this.buttonAddSlice.Enabled = true;
		}

		// Private methods.

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

			// Clear the list.
			this.listViewSlices.Items.Clear();

			// Update the status.
			this.status.Send("Refreshing the list of PlanetLab slices...", Resources.GlobeClock_16);

			// Begin an asynchronous PlanetLab request.
			try
			{
				// Begin the request.
				this.BeginRequest(
					this.requestGetSlices,
					this.crawler.Config.PlanetLab.Username,
					this.crawler.Config.PlanetLab.Password,
					null,
					this.actionCompleteSlicesRequest);
			}
			catch
			{
				// Update the status.
				this.status.Send("Refreshing the list of PlanetLab slices failed.", Resources.GlobeError_16);
			}
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
		private void OnCompleteSlicesRequest(XmlRpcResponse response)
		{
			// If the request has not failed.
			if ((null == response.Fault) && (null != response.Value))
			{
				// Get the slices array.
				XmlRpcArray slices = response.Value as XmlRpcArray;

				// Update the list of PlanetLab slices, filtering by the current person account.
				this.crawler.Config.PlanetLab.Slices.Update(slices.Where((XmlRpcValue value) =>
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
			}
			else
			{
				// Update the status.
				this.status.Send("Refreshing the list of PlanetLab slices failed.", Resources.GlobeError_16);
			}
		}

		/// <summary>
		/// A method called when receiving the response to an add node request.
		/// </summary>
		/// <param name="response">The response.</param>
		private void OnCompleteAddNodeRequest(XmlRpcResponse response)
		{
		}

		/// <summary>
		/// Updates the list of PlanetLab slices.
		/// </summary>
		private void OnUpdateSlices()
		{
			// Clear the list view.
			this.listViewSlices.Items.Clear();

			// Lock the slices list.
			this.crawler.Config.PlanetLab.Slices.Lock();
			try
			{
				// Add the list view items.
				foreach (PlSlice slice in this.crawler.Config.PlanetLab.Slices)
				{
					// Create the list view item.
					ListViewItem item = new ListViewItem(new string[] {
						slice.Id.HasValue ? slice.Id.Value.ToString() : string.Empty,
						slice.Name,
						slice.Created.ToString(),
						slice.Expires.ToString(),
						slice.NodeIds != null ? slice.NodeIds.Length.ToString() : "0",
						slice.MaxNodes.ToString()
					}, 0);
					item.Tag = slice;
					this.listViewSlices.Items.Add(item);
				}
			}
			finally
			{
				this.crawler.Config.PlanetLab.Slices.Unlock();
			}

			// Update the label.
			this.status.Send("Showing {0} PlanetLab slices.".FormatWith(this.crawler.Config.PlanetLab.Slices.Count), Resources.GlobeLab_16);
		}

		/// <summary>
		/// An event handler called when the site selection has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSelectionChanged(object sender, EventArgs e)
		{
			if (this.listViewSlices.SelectedItems.Count > 0)
			{
				this.buttonProperties.Enabled = true;
				this.buttonRemoveSlice.Enabled = true;
				this.buttonAddNode.Enabled = true;
				this.buttonRemoveNode.Enabled = true;
			}
			else
			{
				this.buttonProperties.Enabled = false;
				this.buttonRemoveSlice.Enabled = false;
				this.buttonAddNode.Enabled = false;
				this.buttonRemoveNode.Enabled = false;
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

			// Get the slice for this item.
			PlSlice slice = this.listViewSlices.SelectedItems[0].Tag as PlSlice;

			// Show the site properties.
			this.formSliceProperties.ShowDialog(this, "Slice", slice);
		}

		/// <summary>
		/// An event handler called when the user adds a new slice.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnAddSlice(object sender, EventArgs e)
		{
			// Show the add slice dialog.
			if (this.formAddSlice.ShowDialog(this) == DialogResult.OK)
			{
				// Add the slice to the slices list.
				this.crawler.Config.PlanetLab.Slices.Add(this.formAddSlice.Result);
				// Add a new list item.
				ListViewItem item = new ListViewItem(new string[] {
						this.formAddSlice.Result.Id.HasValue ? this.formAddSlice.Result.Id.Value.ToString() : string.Empty,
						this.formAddSlice.Result.Name,
						this.formAddSlice.Result.Created.ToString(),
						this.formAddSlice.Result.Expires.ToString(),
						this.formAddSlice.Result.NodeIds != null ? this.formAddSlice.Result.NodeIds.Length.ToString() : "0",
						this.formAddSlice.Result.MaxNodes.ToString()
					}, 0);
				item.Tag = this.formAddSlice.Result;
				this.listViewSlices.Items.Add(item);
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
			// Get the slice.
			PlSlice slice = item.Tag as PlSlice;
			// Else, ask user confirmation.
			if (MessageBox.Show(
				this,
				"You are removing the slice \'{0}\' from your slices list. Do you want to continue?".FormatWith(slice.Name),
				"Remove Slice",
				MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
			{
				// Remove the slice.
				this.crawler.Config.PlanetLab.Slices.Remove(slice);
				// Remove the list view item.
				this.listViewSlices.Items.Remove(item);
			}
		}

		/// <summary>
		/// An event handler called when the user adds a node to a slice based on site location.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnAddNodeLocation(object sender, EventArgs e)
		{
			// Show the add node by location dialog.
			if (this.formAddNodeLocation.ShowDialog(this, this.crawler.Config) == DialogResult.OK)
			{
			}
		}

		/// <summary>
		/// An event handler called when the user adds a node to a slice based on node state.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnAddNodeState(object sender, EventArgs e)
		{

		}

		/// <summary>
		/// An event handler called when the user adds a node to a slice based on slice.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnAddNodeSlice(object sender, EventArgs e)
		{

		}

		/// <summary>
		/// An event handler called when the user removes a node from a slice.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnRemoveNode(object sender, EventArgs e)
		{

		}
	}
}
