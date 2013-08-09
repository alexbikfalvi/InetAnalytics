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
	/// A control that displays the information of a PlanetLab site.
	/// </summary>
	public partial class ControlPlanetLabSiteProperties : ControlPlanetLabProperties
	{
		private static string notAvailable = "(not available)";

		private static Color colorMarkerLine = Color.FromArgb(153, 51, 51);
		private static Color colorMarkerFill = Color.FromArgb(255, 51, 51);

		private PlSite site = null;
		private GeoMarkerCircle marker = new GeoMarkerCircle(new PointF());

		private PlRequest request = new PlRequest(PlRequest.RequestMethod.GetSites);

		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlPlanetLabSiteProperties()
		{
			InitializeComponent();

			// Set the marker colors.
			this.marker.ColorLine = ControlPlanetLabSiteProperties.colorMarkerLine;
			this.marker.ColorFill = ControlPlanetLabSiteProperties.colorMarkerFill;
			// Add the marker to the world map.
			this.worldMap.Markers.Add(this.marker);
		}

		// Public properties.

		/// <summary>
		/// Gets or sets the PlanetLab site.
		/// </summary>
		public PlSite PlanetLabSite
		{
			get { return this.site; }
			set
			{
				// Save the old site.
				PlSite oldSite = this.site;
				// Change the site.
				this.site = value;
				// Call the event handler.
				this.OnSiteSet(oldSite, value);
			}
		}

		// Public methods.

		/// <summary>
		/// Updates the PlanetLab site information with the specified site identifier.
		/// </summary>
		/// <param name="id">The site identifier.</param>
		public void UpdateSite(int id)
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
				this.Title = "Site information not found";
			}
		}

		// Protected methods.

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
				PlSites sites = PlSites.Create(response.Value as XmlRpcArray);
				// If the sites count is greater than zero.
				if (sites.Count > 0)
				{
					// Display the information for the first site.
					this.PlanetLabSite = sites[0];
				}
				else
				{
					// Set the site to null.
					this.PlanetLabSite = null;
				}
			}
		}

		/// <summary>
		/// An event handler called when a new site has been set.
		/// </summary>
		/// <param name="oldSite">The old PlanetLab site.</param>
		/// <param name="newSite">The new PlanetLab site.</param>
		protected virtual void OnSiteSet(PlSite oldSite, PlSite newSite)
		{
			// Change the display information for the new site.
			if (null == newSite)
			{
				this.Title = "Site information not found";
				this.Icon = Resources.GlobeWarning_32;
				this.tabControl.Visible = false;
			}
			else
			{
				// General.

				this.Title = newSite.Name;
				this.Icon = Resources.GlobeSchema_32;

				this.textBoxName.Text = newSite.Name;
				this.textBoxAbbreviatedName.Text = newSite.AbbreviatedName;
				this.textBoxUrl.Text = newSite.Url;
				this.textBoxLoginBase.Text = newSite.LoginBase;

				this.textBoxDateCreated.Text = newSite.DateCreated.HasValue ? newSite.DateCreated.Value.ToString() : ControlPlanetLabSiteProperties.notAvailable;
				this.textBoxLastUpdated.Text = newSite.LastUpdated.HasValue ? newSite.LastUpdated.Value.ToString() : ControlPlanetLabSiteProperties.notAvailable;

				this.textBoxMaxSlices.Text = newSite.MaxSlices.HasValue ? newSite.MaxSlices.Value.ToString() : ControlPlanetLabSiteProperties.notAvailable;
				this.textBoxMaxSlivers.Text = newSite.MaxSlivers.HasValue ? newSite.MaxSlivers.Value.ToString() : ControlPlanetLabSiteProperties.notAvailable;

				this.checkBoxIsEnabled.CheckState = newSite.IsEnabled.HasValue ? newSite.IsEnabled.Value ? CheckState.Checked : CheckState.Unchecked : CheckState.Indeterminate;
				this.checkBoxIsPublic.CheckState = newSite.IsPublic.HasValue ? newSite.IsPublic.Value ? CheckState.Checked : CheckState.Unchecked : CheckState.Indeterminate;

				// Identifiers.

				this.textBoxSiteId.Text = newSite.SiteId.HasValue ? newSite.SiteId.Value.ToString() : ControlPlanetLabSiteProperties.notAvailable;
				this.textBoxPeerId.Text = newSite.PeerId.HasValue ? newSite.PeerId.Value.ToString() : ControlPlanetLabSiteProperties.notAvailable;
				this.textBoxExtConsortiumId.Text = newSite.ExtConsortiumId.HasValue ? newSite.ExtConsortiumId.Value.ToString() : ControlPlanetLabSiteProperties.notAvailable;
				this.textBoxPeerSiteId.Text = newSite.PeerSiteId.HasValue ? newSite.PeerSiteId.Value.ToString() : ControlPlanetLabSiteProperties.notAvailable;

				// Location.

				this.textBoxLatitude.Text = newSite.Latitude.HasValue ? newSite.Latitude.Value.LatitudeToString() : ControlPlanetLabSiteProperties.notAvailable;
				this.textBoxLongitude.Text = newSite.Longitude.HasValue ? newSite.Longitude.Value.LongitudeToString() : ControlPlanetLabSiteProperties.notAvailable;

				if (newSite.Latitude.HasValue && newSite.Longitude.HasValue)
				{
					this.marker.Coordinates = new PointF((float)newSite.Longitude.Value, (float)newSite.Latitude.Value);
					this.worldMap.ShowMarkers = true;
				}
				else this.worldMap.ShowMarkers = false;

				// Nodes.
				this.listViewNodes.Items.Clear();
				foreach (int node in newSite.NodeIds)
				{
					ListViewItem item = new ListViewItem(node.ToString(), 0);
					item.Tag = node;
					this.listViewNodes.Items.Add(item);
				}

				// PCUs.
				this.listViewPcus.Items.Clear();
				foreach (int pcu in newSite.PcuIds)
				{
					ListViewItem item = new ListViewItem(pcu.ToString(), 0);
					item.Tag = pcu;
					this.listViewPcus.Items.Add(item);
				}

				// Persons.
				this.listViewPersons.Items.Clear();
				foreach (int person in newSite.PersonIds)
				{
					ListViewItem item = new ListViewItem(person.ToString(), 0);
					item.Tag = person;
					this.listViewPersons.Items.Add(item);
				}

				// Slices.
				this.listViewSlices.Items.Clear();
				foreach (int slice in newSite.SliceIds)
				{
					ListViewItem item = new ListViewItem(slice.ToString(), 0);
					item.Tag = slice;
					this.listViewSlices.Items.Add(item);
				}

				// Addresses.
				this.listViewAddresses.Items.Clear();
				foreach (int address in newSite.AddressIds)
				{
					ListViewItem item = new ListViewItem(address.ToString(), 0);
					item.Tag = address;
					this.listViewAddresses.Items.Add(item);
				}

				// Tags.
				this.listViewTags.Items.Clear();
				foreach (int tag in newSite.SiteTagIds)
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
			using (FormNodeProperties form = new FormNodeProperties())
			{
				form.ShowDialog(this, id);
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
			using (FormPcuProperties form = new FormPcuProperties())
			{
				form.ShowDialog(this, id);
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
			using (FormPersonProperties form = new FormPersonProperties())
			{
				form.ShowDialog(this, id);
			}
		}

		/// <summary>
		/// An event handler called when the user selects the properties of a slice.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSliceProperties(object sender, EventArgs e)
		{
			// TO DO
		}

		/// <summary>
		/// An event handler called when the user selects the properties of an address.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnAddressProperties(object sender, EventArgs e)
		{
			// TO DO
		}

		/// <summary>
		/// An event handler called when the user selects the properties of a tag.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnTagProperties(object sender, EventArgs e)
		{
			// TO DO
		}
	}
}
