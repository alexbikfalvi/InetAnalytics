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
	public partial class ControlSlices : NotificationControl
	{
		// Private variables.

		private Crawler crawler = null;
		private StatusHandler status = null;

		private PlRequest request = new PlRequest(PlRequest.RequestMethod.GetSlices);

		private Action delegateUpdateSlices = null;

		private FormObjectProperties<ControlSliceProperties> formSliceProperties = new FormObjectProperties<ControlSliceProperties>();
		private FormAddSlice formAddSlice = new FormAddSlice();
		private FormAddNodeLocation formAddNodeLocation = new FormAddNodeLocation();

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

			// Initialize the delegates.
			this.delegateUpdateSlices = new Action(this.OnUpdateSlices);
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

			// Set the button enabled state.
			this.buttonRefresh.Enabled = false;
			this.buttonCancel.Enabled = true;

			// Clear the list.
			this.listViewSlices.Items.Clear();

			// Show the notification box.
			this.ShowMessage(Resources.GlobeClock_48, "Refreshing PlanetLab", "Refreshing the list of PlanetLab slices...");

			// Begin an asynchrnoys PlanetLab request.
			try
			{
				// Begin the request.
				this.request.Begin(
					this.crawler.Config.PlanetLab.Username,
					this.crawler.Config.PlanetLab.Password,
					this.OnCallback);
			}
			catch (Exception exception)
			{
				// Show an error message.
				this.ShowMessage(
					Resources.GlobeError_48,
					"PlanetLab Error",
					"An error occured while refreshing the PlanetLab slices. {0}".FormatWith(exception.Message),
					false,
					(int)CrawlerStatic.ConsoleMessageCloseDelay.TotalMilliseconds,
					this.OnComplete);
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
		}

		/// <summary>
		/// An event handler called when the asynchronous request has completed.
		/// </summary>
		/// <param name="result">The result of the asynchronous operation.</param>
		private void OnCallback(AsyncWebResult result)
		{
			try
			{
				// Complete the request.
				AsyncWebResult asyncResult;
				
				// Get the XML RPC response.
				XmlRpcResponse rpcResponse = this.request.End(result, out asyncResult);

				// If a fault occurred during the XML-RPC request.
				if (rpcResponse.Fault != null)
				{
					// Show an error message.
					this.ShowMessage(
						Resources.GlobeWarning_48,
						"PlanetLab Error",
						"Refreshing the PlanetLab slices has failed (RPC code {0} {1})".FormatWith(rpcResponse.Fault.FaultCode, rpcResponse.Fault.FaultString),
						false,
						(int)CrawlerStatic.ConsoleMessageCloseDelay.TotalMilliseconds,
						this.OnComplete);
				}
				else
				{
					// Get the slices array.
					XmlRpcArray slices = rpcResponse.Value as XmlRpcArray;

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

					// Show a success message.
					this.ShowMessage(
						Resources.GlobeSuccess_48,
						"PlanetLab Success",
						"Refreshing the PlanetLab slices has completed successfuly.",
						false,
						(int)CrawlerStatic.ConsoleMessageCloseDelay.TotalMilliseconds,
						this.OnComplete);

					// Update the list of slices.
					this.OnUpdateSlices();
				}
			}
			catch (Exception exception)
			{
				// Show an error message.
				this.ShowMessage(
					Resources.GlobeError_48,
					"PlanetLab Error",
					"An error occured while refreshing the PlanetLab slices. {0}".FormatWith(exception.Message),
					false, (int)CrawlerStatic.ConsoleMessageCloseDelay.TotalMilliseconds,
					this.OnComplete);
			}
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
		}

		/// <summary>
		/// Updates the list of PlanetLab slices.
		/// </summary>
		private void OnUpdateSlices()
		{
			// Execute this method on the UI thread.
			if (this.InvokeRequired)
			{
				this.Invoke(this.delegateUpdateSlices);
				return;
			}

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
