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
using YtCrawler;

namespace YtAnalytics.Controls.PlanetLab
{
	/// <summary>
	/// A control that displays the information of a PlanetLab slice.
	/// </summary>
	public partial class ControlPlanetLabSliceProperties : ControlPlanetLabProperties
	{
		private static string notAvailable = "(not available)";

		private PlSlice slice = null;

		private PlRequest request = new PlRequest(PlRequest.RequestMethod.GetSlices);

		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlPlanetLabSliceProperties()
		{
			InitializeComponent();
		}

		// Public properties.

		/// <summary>
		/// Gets or sets the PlanetLab slice.
		/// </summary>
		public PlSlice PlanetLabSlice
		{
			get { return this.slice; }
			set
			{
				// Save the old slice.
				PlSlice oldSlice = this.slice;
				// Change the slice.
				this.slice = value;
				// Call the event handler.
				this.OnSliceSet(oldSlice, value);
			}
		}

		// Public methods.

		/// <summary>
		/// Updates the PlanetLab slice information with the specified slice identifier.
		/// </summary>
		/// <param name="id">The slice identifier.</param>
		public void UpdateNode(int id)
		{
			// Hide the current information.
			this.Icon = Resources.GlobeClock_32;
			this.Title = "Updating slice information...";
			this.tabControl.Visible = false;

			try
			{
				// Begin a new nodes request for the specified slice.
				this.BeginRequest(this.request, CrawlerStatic.PlanetLabUserName, CrawlerStatic.PlanetLabPassword, PlSlice.GetFilter(PlSlice.Fields.SliceId, id));
			}
			catch
			{
				// Catch all exceptions.
				this.Icon = Resources.GlobeError_32;
				this.Title = "Slice information not found";
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
				// Create a PlanetLab nodes list for the given response.
				PlSlices slices = PlSlices.Create(response.Value as XmlRpcArray);
				// If the nodes count is greater than zero.
				if (slices.Count > 0)
				{
					// Display the information for the first slice.
					this.PlanetLabSlice = slices[0];
				}
				else
				{
					// Set the slice to null.
					this.PlanetLabSlice = null;
				}
			}
		}

		/// <summary>
		/// An event handler called when a new slice has been set.
		/// </summary>
		/// <param name="oldSlice">The old PlanetLab slice.</param>
		/// <param name="newSlice">The new PlanetLab slice.</param>
		protected virtual void OnSliceSet(PlSlice oldSlice, PlSlice newSlice)
		{
			// Change the display information for the new slice.
			if (null == newSlice)
			{
				this.Title = "Slice information not found";
				this.Icon = Resources.GlobeWarning_32;
				this.tabControl.Visible = false;
			}
			else
			{
				// General.

				/*
				this.Title = newSlice.Hostname;
				this.Icon = Resources.GlobeNode_32;

				this.textBoxHostname.Text = newSlice.Hostname;
				this.textBoxVersion.Text = newSlice.Version;
				this.textBoxModel.Text = newSlice.Model;

				this.textBoxDateCreated.Text = newSlice.DateCreated.HasValue ? newSlice.DateCreated.Value.ToString() : ControlPlanetLabSliceProperties.notAvailable;
				this.textBoxLastUpdated.Text = newSlice.LastUpdated.HasValue ? newSlice.LastUpdated.Value.ToString() : ControlPlanetLabSliceProperties.notAvailable;

				this.textBoxBootState.Text = newSlice.BootState;
				this.textBoxNodeType.Text = newSlice.NodeType;
				this.textBoxRunLevel.Text = newSlice.RunLevel;
				this.textBoxSshKey.Text = newSlice.SshRsaKey;

				this.checkBoxVerified.CheckState = newSlice.Verified.HasValue ? newSlice.Verified.Value ? CheckState.Checked : CheckState.Unchecked : CheckState.Indeterminate;

				// Identifiers.

				this.textBoxNodeId.Text = newSlice.NodeId.HasValue ? newSlice.NodeId.Value.ToString() : ControlPlanetLabSliceProperties.notAvailable;
				this.textBoxSiteId.Text = newSlice.SiteId.HasValue ? newSlice.SiteId.Value.ToString() : ControlPlanetLabSliceProperties.notAvailable;
				this.textBoxPeerId.Text = newSlice.PeerId.HasValue ? newSlice.PeerId.Value.ToString() : ControlPlanetLabSliceProperties.notAvailable;
				this.textBoxPeerNodeId.Text = newSlice.PeerNodeId.HasValue ? newSlice.PeerNodeId.Value.ToString() : ControlPlanetLabSliceProperties.notAvailable;

				// Status.

				this.textBoxLastBoot.Text = newSlice.LastBoot.HasValue ? newSlice.LastBoot.Value.ToString() : ControlPlanetLabSliceProperties.notAvailable;
				this.textBoxLastPcuReboot.Text = newSlice.LastPcuReboot.HasValue ? newSlice.LastPcuReboot.Value.ToString() : ControlPlanetLabSliceProperties.notAvailable;
				this.textBoxLastContact.Text = newSlice.LastContact.HasValue ? newSlice.LastContact.Value.ToString() : ControlPlanetLabSliceProperties.notAvailable;
				this.textBoxLastPcuConfirmation.Text = newSlice.LastPcuConfirmation.HasValue ? newSlice.LastPcuConfirmation.Value.ToString() : ControlPlanetLabSliceProperties.notAvailable;
				this.textBoxLastDownload.Text = newSlice.LastDownload.HasValue ? newSlice.LastDownload.Value.ToString() : ControlPlanetLabSliceProperties.notAvailable;

				this.textBoxLastTimeSpentOnline.Text = newSlice.LastTimeSpentOnline.HasValue ? newSlice.LastTimeSpentOnline.Value.ToString() : ControlPlanetLabSliceProperties.notAvailable;
				this.textBoxLastTimeSpentOffline.Text = newSlice.LastTimeSpentOffline.HasValue ? newSlice.LastTimeSpentOffline.Value.ToString() : ControlPlanetLabSliceProperties.notAvailable;

				// Ports.
				this.listBoxPorts.Items.Clear();
				foreach (int id in newSlice.Ports)
				{
					this.listBoxPorts.Items.Add(id);
				}

				// PCUs.
				this.listViewPcus.Items.Clear();
				foreach (int id in newSlice.PcuIds)
				{
					ListViewItem item = new ListViewItem(id.ToString(), 0);
					item.Tag = id;
					this.listViewPcus.Items.Add(item);
				}

				// Interfaces.
				this.listViewInterfaces.Items.Clear();
				foreach (int id in newSlice.InterfaceIds)
				{
					ListViewItem item = new ListViewItem(id.ToString(), 0);
					item.Tag = id;
					this.listViewInterfaces.Items.Add(item);
				}

				// Slices.
				this.listViewSlices.Items.Clear();
				foreach (int id in newSlice.SliceIds)
				{
					ListViewItem item = new ListViewItem(id.ToString(), 0);
					item.Tag = id;
					this.listViewSlices.Items.Add(item);
				}

				// Node tags.
				this.listViewNodeTags.Items.Clear();
				foreach (int id in newSlice.NodeTagIds)
				{
					ListViewItem item = new ListViewItem(id.ToString(), 0);
					item.Tag = id;
					this.listViewNodeTags.Items.Add(item);
				}

				// Node groups.
				this.listViewNodeGroups.Items.Clear();
				foreach (int id in newSlice.NodeGroupIds)
				{
					ListViewItem item = new ListViewItem(id.ToString(), 0);
					item.Tag = id;
					this.listViewNodeGroups.Items.Add(item);
				}

				// Slice whitelist.
				this.listViewSliceWhitelist.Items.Clear();
				foreach (int id in newSlice.SliceIdsWhitelist)
				{
					ListViewItem item = new ListViewItem(id.ToString(), 0);
					item.Tag = id;
					this.listViewSliceWhitelist.Items.Add(item);
				}
				 * */

				// Disable the buttons.
				this.buttonInterface.Enabled = false;
				this.buttonPcu.Enabled = false;
				this.buttonNodeTag.Enabled = false;
				this.buttonSlice.Enabled = false;
				this.buttonNodeGroup.Enabled = false;
				this.buttonSliceWhitelist.Enabled = false;

				this.tabControl.Visible = true;
			}

			this.tabControl.SelectedTab = this.tabPageGeneral;
			if (this.Focused)
			{
				this.textBoxHostname.Select();
				this.textBoxHostname.SelectionStart = 0;
				this.textBoxHostname.SelectionLength = 0;
			}
		}

		/// <summary>
		/// An event handler called when the slice selection has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnNodeSelectionChanged(object sender, EventArgs e)
		{
			this.buttonInterface.Enabled = this.listViewInterfaces.SelectedItems.Count > 0;
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
			this.buttonNodeTag.Enabled = this.listViewNodeTags.SelectedItems.Count > 0;
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
			this.buttonNodeGroup.Enabled = this.listViewNodeGroups.SelectedItems.Count > 0;
		}

		/// <summary>
		/// An event handler called when the tag selection has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments,</param>
		private void OnTagSelectionChanged(object sender, EventArgs e)
		{
			this.buttonSliceWhitelist.Enabled = this.listViewSliceWhitelist.SelectedItems.Count > 0;
		}

		/// <summary>
		/// An event handler called when the user selects the properties of a PCU.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnPcuProperties(object sender, EventArgs e)
		{
			// TO DO
		}

		/// <summary>
		/// An event handler called when the user selects the properies of a interface.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnInterfaceProperties(object sender, EventArgs e)
		{
			// TO DO
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
		/// An event handler called when the user selects the properties of a slice tag.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnNodeTagProperties(object sender, EventArgs e)
		{
			// TO DO
		}

		/// <summary>
		/// An event handler called when the user selects the properties of a slice group.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnNodeGroupProperties(object sender, EventArgs e)
		{
			// TO DO
		}

		/// <summary>
		/// An event handler called when the user selects the properties of a whitelisted site.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSliceWhitelistProperties(object sender, EventArgs e)
		{
			// TO DO
		}

		/// <summary>
		/// An event handler called when the user selects the properties of a configuration file.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnConfigurationFileProperties(object sender, EventArgs e)
		{
			// TO DO
		}
	}
}
