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
using System.Drawing;
using System.Security;
using System.Windows.Forms;
using DotNetApi;
using DotNetApi.Web.XmlRpc;
using DotNetApi.Windows.Controls;
using PlanetLab;
using PlanetLab.Api;
using PlanetLab.Requests;
using YtAnalytics.Forms.PlanetLab;
using YtCrawler;

namespace YtAnalytics.Controls.PlanetLab
{
	/// <summary>
	/// A control that displays the information of a PlanetLab slice.
	/// </summary>
	public partial class ControlSliceProperties : ControlObjectProperties
	{
		private readonly PlRequest request = new PlRequest(PlRequest.RequestMethod.GetSlices);

		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlSliceProperties()
		{
			InitializeComponent();
		}

		// Protected methods.

		/// <summary>
		/// An event handler called when a new PlanetLab object is set.
		/// </summary>
		/// <param name="obj">The PlanetLab object.</param>
		protected override void OnObjectSet(PlObject obj)
		{
			// Get the slice.
			PlSlice slice = obj as PlSlice;

			// Change the display information for the new slice.
			if (null == slice)
			{
				this.Title = "Slice unknown";
				this.Message = "The slice information is not available.";
				this.Icon = Resources.GlobeWarning_32;
				this.tabControl.Visible = false;
			}
			else
			{
				// General.

				this.Title = slice.Name;
				this.Message = string.Empty;
				this.Icon = Resources.GlobeObject_32;

				this.textBoxName.Text = slice.Name;
				this.textBoxDescription.Text = slice.Description;
				this.textBoxInstantiation.Text = slice.Instantiation;
				this.textBoxUrl.Text = slice.Url;

				this.textBoxCreated.Text = slice.Created.HasValue ? slice.Created.Value.ToString() : ControlObjectProperties.notAvailable;
				this.textBoxExpires.Text = slice.Expires.HasValue ? slice.Expires.Value.ToString() : ControlObjectProperties.notAvailable;

				this.textBoxMaxNodes.Text = slice.MaxNodes.HasValue ? slice.MaxNodes.Value.ToString() : ControlObjectProperties.notAvailable;

				// Identifiers.

				this.textBoxSliceId.Text = slice.SliceId.HasValue ? slice.SliceId.Value.ToString() : ControlObjectProperties.notAvailable;
				this.textBoxSiteId.Text = slice.SiteId.HasValue ? slice.SiteId.Value.ToString() : ControlObjectProperties.notAvailable;
				this.textBoxPeerId.Text = slice.PeerId.HasValue ? slice.PeerId.Value.ToString() : ControlObjectProperties.notAvailable;
				this.textBoxPeerSliceId.Text = slice.PeerSliceId.HasValue ? slice.PeerSliceId.Value.ToString() : ControlObjectProperties.notAvailable;
				this.textBoxCreatorPersonId.Text = slice.CreatorPersonId.HasValue ? slice.CreatorPersonId.Value.ToString() : ControlObjectProperties.notAvailable;

				// Nodes.
				this.listViewNodes.Items.Clear();
				foreach (int id in slice.NodeIds)
				{
					ListViewItem item = new ListViewItem(id.ToString(), 0);
					item.Tag = id;
					this.listViewNodes.Items.Add(item);
				}

				// Persons.
				this.listViewPersons.Items.Clear();
				foreach (int id in slice.PersonIds)
				{
					ListViewItem item = new ListViewItem(id.ToString(), 0);
					item.Tag = id;
					this.listViewPersons.Items.Add(item);
				}

				// Disable the buttons.
				this.buttonNode.Enabled = false;
				this.buttonPerson.Enabled = false;

				this.tabControl.Visible = true;
			}

			this.tabControl.SelectedTab = this.tabPageGeneral;
			if (this.Focused)
			{
				this.textBoxName.Select();
				this.textBoxName.SelectionStart = 0;
				this.textBoxName.SelectionLength = 0;
			}
		}

		/// <summary>
		/// An event handler called when updating the control with a PlanetLab object of the specified identifier.
		/// </summary>
		/// <param name="id">The identifier.</param>
		protected override void OnUpdate(int id)
		{
			// Hide the current information.
			this.Icon = Resources.GlobeClock_32;
			this.Title = "Updating...";
			this.Message = "Updating the information for slice {0}...".FormatWith(id);
			this.tabControl.Visible = false;

			// Begin a new nodes request for the specified slice.
			this.BeginRequest(this.request, CrawlerStatic.PlanetLabUsername, CrawlerStatic.PlanetLabPassword, PlSlice.GetFilter(PlSlice.Fields.SliceId, id));
		}

		/// <summary>
		/// An event handler called when the request completes.
		/// </summary>
		/// <param name="response">The XML-RPC response.</param>
		/// <param name="state">The request state.</param>
		protected override void OnRequestResult(XmlRpcResponse response, RequestState state)
		{
			// Call the base class method.
			base.OnRequestResult(response, state);
			// If the request has not failed.
			if ((null == response.Fault) && (null != response.Value))
			{
				PlList<PlSlice> slices = null;
				// Create a PlanetLab nodes list for the given response.
				try { slices = PlList<PlSlice>.Create(response.Value as XmlRpcArray); }
				catch { }
				// If the nodes count is greater than zero.
				if ((null != slices) && (slices.Count > 0))
				{
					// Display the information for the first slice.
					this.Object = slices[0];
				}
				else
				{
					// Set the slice to null.
					this.Object = null;
				}
			}
		}

		/// <summary>
		/// An event handler called when the current request throws an exception.
		/// </summary>
		/// <param name="exception">The exception.</param>
		/// <param name="state">The request state.</param>
		protected override void OnRequestException(Exception exception, RequestState state)
		{
			// Catch all exceptions.
			this.Icon = Resources.GlobeError_32;
			this.Title = "Slice unknown";
			this.Message = "An error occurred while requesting the slice information. {0}{1}{2}".FormatWith(
				Environment.NewLine,
				Environment.NewLine,
				exception.Message);
		}

		// Private methods.

		/// <summary>
		/// An event handler called when the node selection has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnNodeSelectionChanged(object sender, EventArgs e)
		{
			this.buttonNode.Enabled = this.listViewNodes.SelectedItems.Count > 0;
		}

		/// <summary>
		/// An event handler called when the person selection has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnPersonSelectionChanged(object sender, EventArgs e)
		{
			this.buttonPerson.Enabled = this.listViewPersons.SelectedItems.Count > 0;
		}

		/// <summary>
		/// An event handler called when the user selects the properties of a node.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnNodeProperties(object sender, EventArgs e)
		{
			// If there are no selected nodes, do nothing.
			if (this.listViewNodes.SelectedItems.Count == 0) return;
			// Get the selected node ID.
			int id = (int)this.listViewNodes.SelectedItems[0].Tag;
			using (FormObjectProperties<ControlNodeProperties> form = new FormObjectProperties<ControlNodeProperties>())
			{
				form.ShowDialog(this, "Node", id);
			}
		}

		/// <summary>
		/// An event handler called when the user selects the properies of a person.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnPersonProperties(object sender, EventArgs e)
		{
			// If there are no selected persons, do nothing.
			if (this.listViewPersons.SelectedItems.Count == 0) return;
			// Get the selected person ID.
			int id = (int)this.listViewPersons.SelectedItems[0].Tag;
			using (FormObjectProperties<ControlPersonProperties> form = new FormObjectProperties<ControlPersonProperties>())
			{
				form.ShowDialog(this, "Person", id);
			}
		}
	}
}
