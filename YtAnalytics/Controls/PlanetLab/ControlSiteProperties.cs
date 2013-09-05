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
using MapApi;
using PlanetLab.Api;
using PlanetLab.Requests;
using YtAnalytics.Forms.PlanetLab;
using YtCrawler;

namespace YtAnalytics.Controls.PlanetLab
{
	/// <summary>
	/// A control that displays the information of a PlanetLab site.
	/// </summary>
	public partial class ControlSiteProperties : ControlObjectProperties
	{
		private MapBulletMarker marker = new MapBulletMarker();

		private PlRequest request = new PlRequest(PlRequest.RequestMethod.GetSites);

		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlSiteProperties()
		{
			InitializeComponent();

			// Load the map.
			this.mapControl.LoadMap("Ne110mAdmin0Countries");
			// Add the marker to the world map.
			this.mapControl.Markers.Add(this.marker);
		}

		// Protected methods.

		/// <summary>
		/// An event handler called when a new PlanetLab object is set.
		/// </summary>
		/// <param name="obj">The PlanetLab object.</param>
		protected override void OnObjectSet(PlObject obj)
		{
			// Get the site.
			PlSite site = obj as PlSite;

			// Change the display information for the new site.
			if (null == site)
			{
				this.Title = "Site information not available";
				this.Icon = Resources.GlobeWarning_32;
				this.tabControl.Visible = false;
			}
			else
			{
				// General.

				this.Title = site.Name;
				this.Icon = Resources.GlobeSchema_32;

				this.textBoxName.Text = site.Name;
				this.textBoxAbbreviatedName.Text = site.AbbreviatedName;
				this.textBoxUrl.Text = site.Url;
				this.textBoxLoginBase.Text = site.LoginBase;

				this.textBoxDateCreated.Text = site.DateCreated.HasValue ? site.DateCreated.Value.ToString() : ControlObjectProperties.notAvailable;
				this.textBoxLastUpdated.Text = site.LastUpdated.HasValue ? site.LastUpdated.Value.ToString() : ControlObjectProperties.notAvailable;

				this.textBoxMaxSlices.Text = site.MaxSlices.HasValue ? site.MaxSlices.Value.ToString() : ControlObjectProperties.notAvailable;
				this.textBoxMaxSlivers.Text = site.MaxSlivers.HasValue ? site.MaxSlivers.Value.ToString() : ControlObjectProperties.notAvailable;

				this.checkBoxIsEnabled.CheckState = site.IsEnabled.HasValue ? site.IsEnabled.Value ? CheckState.Checked : CheckState.Unchecked : CheckState.Indeterminate;
				this.checkBoxIsPublic.CheckState = site.IsPublic.HasValue ? site.IsPublic.Value ? CheckState.Checked : CheckState.Unchecked : CheckState.Indeterminate;

				// Identifiers.

				this.textBoxSiteId.Text = site.SiteId.HasValue ? site.SiteId.Value.ToString() : ControlObjectProperties.notAvailable;
				this.textBoxPeerId.Text = site.PeerId.HasValue ? site.PeerId.Value.ToString() : ControlObjectProperties.notAvailable;
				this.textBoxExtConsortiumId.Text = site.ExtConsortiumId.HasValue ? site.ExtConsortiumId.Value.ToString() : ControlObjectProperties.notAvailable;
				this.textBoxPeerSiteId.Text = site.PeerSiteId.HasValue ? site.PeerSiteId.Value.ToString() : ControlObjectProperties.notAvailable;

				// Location.

				this.textBoxLatitude.Text = site.Latitude.HasValue ? site.Latitude.Value.LatitudeToString() : ControlObjectProperties.notAvailable;
				this.textBoxLongitude.Text = site.Longitude.HasValue ? site.Longitude.Value.LongitudeToString() : ControlObjectProperties.notAvailable;

				if (site.Latitude.HasValue && site.Longitude.HasValue)
				{
					this.marker.Location = new MapPoint((float)site.Longitude.Value, (float)site.Latitude.Value);
					this.marker.Name = site.Name;
					this.marker.Emphasized = true;
					this.mapControl.ShowMarkers = true;
				}
				else this.mapControl.ShowMarkers = false;

				// Nodes.
				this.listViewNodes.Items.Clear();
				foreach (int node in site.NodeIds)
				{
					ListViewItem item = new ListViewItem(node.ToString(), 0);
					item.Tag = node;
					this.listViewNodes.Items.Add(item);
				}

				// PCUs.
				this.listViewPcus.Items.Clear();
				foreach (int pcu in site.PcuIds)
				{
					ListViewItem item = new ListViewItem(pcu.ToString(), 0);
					item.Tag = pcu;
					this.listViewPcus.Items.Add(item);
				}

				// Persons.
				this.listViewPersons.Items.Clear();
				foreach (int person in site.PersonIds)
				{
					ListViewItem item = new ListViewItem(person.ToString(), 0);
					item.Tag = person;
					this.listViewPersons.Items.Add(item);
				}

				// Slices.
				this.listViewSlices.Items.Clear();
				foreach (int slice in site.SliceIds)
				{
					ListViewItem item = new ListViewItem(slice.ToString(), 0);
					item.Tag = slice;
					this.listViewSlices.Items.Add(item);
				}

				// Addresses.
				this.listViewAddresses.Items.Clear();
				foreach (int address in site.AddressIds)
				{
					ListViewItem item = new ListViewItem(address.ToString(), 0);
					item.Tag = address;
					this.listViewAddresses.Items.Add(item);
				}

				// Tags.
				this.listViewTags.Items.Clear();
				foreach (int tag in site.SiteTagIds)
				{
					ListViewItem item = new ListViewItem(tag.ToString(), 0);
					item.Tag = tag;
					this.listViewTags.Items.Add(item);
				}

				// Disable the buttons.
				this.buttonNode.Enabled = false;
				this.buttonPcu.Enabled = false;
				this.buttonPerson.Enabled = false;
				this.buttonSlice.Enabled = false;
				this.buttonAddress.Enabled = false;
				this.buttonTag.Enabled = false;

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
			this.Title = "Updating site information...";
			this.tabControl.Visible = false;

			try
			{
				// Begin a new sites request for the specified site.
				this.BeginRequest(this.request, CrawlerStatic.PlanetLabUserName, CrawlerStatic.PlanetLabPassword, PlSite.GetFilter(PlSite.Fields.SiteId, id));
			}
			catch
			{
				// Catch all exceptions.
				this.Icon = Resources.GlobeError_32;
				this.Title = "Site information not available";
			}
		}

		/// <summary>
		/// An event handler called when the request completes.
		/// </summary>
		/// <param name="response">The XML-RPC response.</param>
		protected override void OnCompleteRequest(XmlRpcResponse response)
		{
			// Call the base class method.
			base.OnCompleteRequest(response);
			// If the request has not failed.
			if ((null == response.Fault) && (null != response.Value))
			{
				// Create a PlanetLab sites list for the given response.
				PlList<PlSite> sites = PlList<PlSite>.Create(response.Value as XmlRpcArray);
				// If the sites count is greater than zero.
				if (sites.Count > 0)
				{
					// Display the information for the first site.
					this.Object = sites[0];
				}
				else
				{
					// Set the site to null.
					this.Object = null;
				}
			}
		}

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
		/// An event handler called when the PCU selection has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnPcuSelectionChanged(object sender, EventArgs e)
		{
			this.buttonPcu.Enabled = this.listViewPcus.SelectedItems.Count > 0;
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
		/// An event handler called when the slice selection has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSliceSelectionChanged(object sender, EventArgs e)
		{
			this.buttonSlice.Enabled = this.listViewSlices.SelectedItems.Count > 0;
		}

		/// <summary>
		/// An event handler called when the address selection has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnAddressSelectionChanged(object sender, EventArgs e)
		{
			this.buttonAddress.Enabled = this.listViewAddresses.SelectedItems.Count > 0;
		}

		/// <summary>
		/// An event handler called when the tag selection has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments,</param>
		private void OnTagSelectionChanged(object sender, EventArgs e)
		{
			this.buttonTag.Enabled = this.listViewTags.SelectedItems.Count > 0;
		}

		/// <summary>
		/// An event handler called when the user selects the properies of a node.
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
		/// An event handler called when the user selects the properties of a PCU.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnPcuProperties(object sender, EventArgs e)
		{
			// If there are no selected PCUs, do nothing.
			if (this.listViewPcus.SelectedItems.Count == 0) return;
			// Get the selected PCU ID.
			int id = (int)this.listViewPcus.SelectedItems[0].Tag;
			using (FormObjectProperties<ControlPcuProperties> form = new FormObjectProperties<ControlPcuProperties>())
			{
				form.ShowDialog(this, "PCU", id);
			}
		}

		/// <summary>
		/// An event handler called when the user selects the properties of a person.
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

		/// <summary>
		/// An event handler called when the user selects the properties of a slice.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSliceProperties(object sender, EventArgs e)
		{
			// If there are no selected slices, do nothing.
			if (this.listViewSlices.SelectedItems.Count == 0) return;
			// Get the selected slice ID.
			int id = (int)this.listViewSlices.SelectedItems[0].Tag;
			using (FormObjectProperties<ControlSliceProperties> form = new FormObjectProperties<ControlSliceProperties>())
			{
				form.ShowDialog(this, "Slice", id);
			}
		}

		/// <summary>
		/// An event handler called when the user selects the properties of an address.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnAddressProperties(object sender, EventArgs e)
		{
			// If there are no selected addresses, do nothing.
			if (this.listViewAddresses.SelectedItems.Count == 0) return;
			// Get the selected address ID.
			int id = (int)this.listViewAddresses.SelectedItems[0].Tag;
			using (FormObjectProperties<ControlAddressProperties> form = new FormObjectProperties<ControlAddressProperties>())
			{
				form.ShowDialog(this, "Address", id);
			}
		}

		/// <summary>
		/// An event handler called when the user selects the properties of a tag.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnTagProperties(object sender, EventArgs e)
		{
			// If there are no selected tag, do nothing.
			if (this.listViewTags.SelectedItems.Count == 0) return;
			// Get the selected tag ID.
			int id = (int)this.listViewTags.SelectedItems[0].Tag;
			using (FormObjectProperties<ControlSiteTagProperties> form = new FormObjectProperties<ControlSiteTagProperties>())
			{
				form.ShowDialog(this, "Site Tag", id);
			}
		}
	}
}
