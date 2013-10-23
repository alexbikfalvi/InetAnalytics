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
using YtAnalytics.Events;
using YtAnalytics.Forms.PlanetLab;
using YtCrawler;
using PlanetLab;
using PlanetLab.Api;
using PlanetLab.Database;
using PlanetLab.Requests;
using DotNetApi;
using DotNetApi.Web.XmlRpc;

namespace YtAnalytics.Controls.PlanetLab
{
	/// <summary>
	/// A control that receives user input data to add a new PlanetLab slice.
	/// </summary>
	public sealed partial class ControlAddSlice : ControlRequest
	{
		private readonly PlRequest request = new PlRequest(PlRequest.RequestMethod.GetSlices);
		
		private string filter = string.Empty;
		private PlDatabaseList<PlSlice> slices = null;

		private readonly FormObjectProperties<ControlSliceProperties> formProperties = new FormObjectProperties<ControlSliceProperties>();

		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlAddSlice()
		{
			// Initialize the component.
			this.InitializeComponent();
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
		public event PlObjectEventHandler<PlSlice> Selected;
		/// <summary>
		/// An event raised when user closes the selection.
		/// </summary>
		public event EventHandler Closed;

		// Public methods.

		/// <summary>
		/// Refreshes the list of PlanetLab slices.
		/// </summary>
		/// <param name="config">The crawler configuration.</param>
		public void Refresh(CrawlerConfig config)
		{
			// Set the slices.
			this.slices = config.PlanetLab.Slices;
			// Clear the filter.
			this.textBoxFilter.Clear();
			// Clear the buttons state.
			this.buttonRefresh.Enabled = true;
			this.buttonCancel.Enabled = false;
			this.buttonSelect.Enabled = false;
			this.buttonClose.Enabled = true;
			// If the slices list is empty.
			if (this.slices.Count == 0)
			{
				// Begin refreshing the slices list.
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
				try
				{
					// Update the list of PlanetLab slices list for the given response.
					this.slices.CopyFrom(response.Value as XmlRpcArray);
					// Update the list view.
					this.OnUpdateList();
				}
				catch
				{
					// Update the status.
					this.labelStatus.Text = "Refresh failed.";
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
			this.BeginRequest(this.request, CrawlerConfig.Static.PlanetLabUsername, CrawlerConfig.Static.PlanetLabPassword);
		}

		/// <summary>
		/// An event handler called when the user chooses an item.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSelect(object sender, EventArgs e)
		{
			// If there is no selected PlanetLab object, do nothing.
			if (this.listView.SelectedItems.Count == 0) return;
			// Else, get the PlanetLab object.
			PlSlice result = this.listView.SelectedItems[0].Tag as PlSlice;
			// Raise the event.
			if (this.Selected != null) this.Selected(this, new PlObjectEventArgs<PlSlice>(result));
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
		/// An event handler called when the object selection has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSelectionChanged(object sender, EventArgs e)
		{
			// Set the select button enabled state.
			this.buttonSelect.Enabled = this.listView.SelectedItems.Count > 0;
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
			this.formProperties.ShowDialog(this, "Slice", this.listView.SelectedItems[0].Tag as PlSlice);
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
		/// An event handler called when the filter text has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnFilterTextChanged(object sender, EventArgs e)
		{
			// If the filter has changed.
			if (this.filter != this.textBoxFilter.Text.Trim())
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
			this.filter = this.textBoxFilter.Text.Trim();
			// The number of displayed sites.
			int count = 0;

			// Lock the list.
			this.slices.Lock();
			try
			{
				// Update the slices list.
				foreach (PlSlice slice in this.slices)
				{
					// If the filter is not null or empty.
					if (!string.IsNullOrEmpty(this.filter))
					{
						// If the site name does not match the filter, continue.
						if (!string.IsNullOrEmpty(slice.Name))
						{
							if (!slice.Name.ToLower().Contains(this.filter.ToLower())) continue;
						}
					}

					// Increment the number of displayed slices.
					count++;

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
					this.listView.Items.Add(item);
				}
			}
			finally
			{
				this.slices.Unlock();
			}
			// Update the status.
			this.labelStatus.Text = "Showing {0} of {1} PlanetLab slices.".FormatWith(count, this.slices.Count);
		}
	}
}
