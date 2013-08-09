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
	/// A control that displays the information of a PlanetLab node.
	/// </summary>
	public partial class ControlPlanetLabNodeProperties : ControlPlanetLabProperties
	{
		private static string notAvailable = "(not available)";

		private PlNode node = null;

		private PlRequest request = new PlRequest(PlRequest.RequestMethod.GetNodes);

		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlPlanetLabNodeProperties()
		{
			InitializeComponent();
		}

		// Public properties.

		/// <summary>
		/// Gets or sets the PlanetLab node.
		/// </summary>
		public PlNode PlanetLabNode
		{
			get { return this.node; }
			set
			{
				// Save the old node.
				PlNode oldNode = this.node;
				// Change the node.
				this.node = value;
				// Call the event handler.
				this.OnNodeSet(oldNode, value);
			}
		}

		// Public methods.

		/// <summary>
		/// Updates the PlanetLab node information with the specified node identifier.
		/// </summary>
		/// <param name="id">The node identifier.</param>
		public void UpdateNode(int id)
		{
			// Hide the current information.
			this.Icon = Resources.GlobeClock_32;
			this.Title = "Updating node information...";
			this.tabControl.Visible = false;

			try
			{
				// Begin a new nodes request for the specified node.
				this.BeginRequest(this.request, CrawlerStatic.PlanetLabUserName, CrawlerStatic.PlanetLabPassword, PlNode.GetFilter(PlNode.Fields.NodeId, id));
			}
			catch
			{
				// Catch all exceptions.
				this.Icon = Resources.GlobeError_32;
				this.Title = "Node information not found";
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
				PlNodes nodes = PlNodes.Create(response.Value as XmlRpcArray);
				// If the nodes count is greater than zero.
				if (nodes.Count > 0)
				{
					// Display the information for the first node.
					this.PlanetLabNode = nodes[0];
				}
				else
				{
					// Set the node to null.
					this.PlanetLabNode = null;
				}
			}
		}

		/// <summary>
		/// An event handler called when a new node has been set.
		/// </summary>
		/// <param name="oldNode">The old PlanetLab node.</param>
		/// <param name="newNode">The new PlanetLab node.</param>
		protected virtual void OnNodeSet(PlNode oldNode, PlNode newNode)
		{
			// Change the display information for the new node.
			if (null == newNode)
			{
				this.Title = "Node information not found";
				this.Icon = Resources.GlobeWarning_32;
				this.tabControl.Visible = false;
			}
			else
			{
				// General.

				this.Title = newNode.Hostname;
				this.Icon = Resources.GlobeObject_32;

				this.textBoxHostname.Text = newNode.Hostname;
				this.textBoxVersion.Text = newNode.Version;
				this.textBoxModel.Text = newNode.Model;

				this.textBoxDateCreated.Text = newNode.DateCreated.HasValue ? newNode.DateCreated.Value.ToString() : ControlPlanetLabNodeProperties.notAvailable;
				this.textBoxLastUpdated.Text = newNode.LastUpdated.HasValue ? newNode.LastUpdated.Value.ToString() : ControlPlanetLabNodeProperties.notAvailable;

				this.textBoxBootState.Text = newNode.BootState;
				this.textBoxNodeType.Text = newNode.NodeType;
				this.textBoxRunLevel.Text = newNode.RunLevel;
				this.textBoxSshKey.Text = newNode.SshRsaKey;

				this.checkBoxVerified.CheckState = newNode.Verified.HasValue ? newNode.Verified.Value ? CheckState.Checked : CheckState.Unchecked : CheckState.Indeterminate;

				// Identifiers.

				this.textBoxNodeId.Text = newNode.NodeId.HasValue ? newNode.NodeId.Value.ToString() : ControlPlanetLabNodeProperties.notAvailable;
				this.textBoxSiteId.Text = newNode.SiteId.HasValue ? newNode.SiteId.Value.ToString() : ControlPlanetLabNodeProperties.notAvailable;
				this.textBoxPeerId.Text = newNode.PeerId.HasValue ? newNode.PeerId.Value.ToString() : ControlPlanetLabNodeProperties.notAvailable;
				this.textBoxPeerNodeId.Text = newNode.PeerNodeId.HasValue ? newNode.PeerNodeId.Value.ToString() : ControlPlanetLabNodeProperties.notAvailable;

				// Status.

				this.textBoxLastBoot.Text = newNode.LastBoot.HasValue ? newNode.LastBoot.Value.ToString() : ControlPlanetLabNodeProperties.notAvailable;
				this.textBoxLastPcuReboot.Text = newNode.LastPcuReboot.HasValue ? newNode.LastPcuReboot.Value.ToString() : ControlPlanetLabNodeProperties.notAvailable;
				this.textBoxLastContact.Text = newNode.LastContact.HasValue ? newNode.LastContact.Value.ToString() : ControlPlanetLabNodeProperties.notAvailable;
				this.textBoxLastPcuConfirmation.Text = newNode.LastPcuConfirmation.HasValue ? newNode.LastPcuConfirmation.Value.ToString() : ControlPlanetLabNodeProperties.notAvailable;
				this.textBoxLastDownload.Text = newNode.LastDownload.HasValue ? newNode.LastDownload.Value.ToString() : ControlPlanetLabNodeProperties.notAvailable;

				this.textBoxLastTimeSpentOnline.Text = newNode.LastTimeSpentOnline.HasValue ? newNode.LastTimeSpentOnline.Value.ToString("d' day(s) 'hh' hour(s) 'mm' minute(s)'") : ControlPlanetLabNodeProperties.notAvailable;
				this.textBoxLastTimeSpentOffline.Text = newNode.LastTimeSpentOffline.HasValue ? newNode.LastTimeSpentOffline.Value.ToString("d' day(s) 'hh' hour(s) 'mm' minute(s)'") : ControlPlanetLabNodeProperties.notAvailable;

				// Ports.
				this.listBoxPorts.Items.Clear();
				foreach (int id in newNode.Ports)
				{
					this.listBoxPorts.Items.Add(id);
				}

				// PCUs.
				this.listViewPcus.Items.Clear();
				foreach (int id in newNode.PcuIds)
				{
					ListViewItem item = new ListViewItem(id.ToString(), 0);
					item.Tag = id;
					this.listViewPcus.Items.Add(item);
				}

				// Interfaces.
				this.listViewInterfaces.Items.Clear();
				foreach (int id in newNode.InterfaceIds)
				{
					ListViewItem item = new ListViewItem(id.ToString(), 0);
					item.Tag = id;
					this.listViewInterfaces.Items.Add(item);
				}

				// Slices.
				this.listViewSlices.Items.Clear();
				foreach (int id in newNode.SliceIds)
				{
					ListViewItem item = new ListViewItem(id.ToString(), 0);
					item.Tag = id;
					this.listViewSlices.Items.Add(item);
				}

				// Node tags.
				this.listViewNodeTags.Items.Clear();
				foreach (int id in newNode.NodeTagIds)
				{
					ListViewItem item = new ListViewItem(id.ToString(), 0);
					item.Tag = id;
					this.listViewNodeTags.Items.Add(item);
				}

				// Node groups.
				this.listViewNodeGroups.Items.Clear();
				foreach (int id in newNode.NodeGroupIds)
				{
					ListViewItem item = new ListViewItem(id.ToString(), 0);
					item.Tag = id;
					this.listViewNodeGroups.Items.Add(item);
				}

				// Slice whitelist.
				this.listViewSliceWhitelist.Items.Clear();
				foreach (int id in newNode.SliceIdsWhitelist)
				{
					ListViewItem item = new ListViewItem(id.ToString(), 0);
					item.Tag = id;
					this.listViewSliceWhitelist.Items.Add(item);
				}

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
		/// An event handler called when the node selection has changed.
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
		/// An event handler called when the user selects the properties of a node tag.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnNodeTagProperties(object sender, EventArgs e)
		{
			// TO DO
		}

		/// <summary>
		/// An event handler called when the user selects the properties of a node group.
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
