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
using InetAnalytics.Forms.PlanetLab;
using InetCrawler;

namespace InetAnalytics.Controls.PlanetLab
{
	/// <summary>
	/// A control that displays the information of a PlanetLab node.
	/// </summary>
	public partial class ControlNodeProperties : ControlObjectProperties
	{
		private readonly PlRequest request = new PlRequest(PlRequest.RequestMethod.GetNodes);

		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlNodeProperties()
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
			// Get the node.
			PlNode node = obj as PlNode;

			// Change the display information for the new node.
			if (null == node)
			{
				this.Title = "Node unknown";
				this.Message = "The node information is not available.";
				this.Icon = Resources.GlobeWarning_32;
				this.tabControl.Visible = false;
			}
			else
			{
				// General.

				this.Title = node.Hostname;
				this.Message = string.Empty;
				this.Icon = Resources.GlobeNode_32;

				this.textBoxHostname.Text = node.Hostname;
				this.textBoxVersion.Text = node.Version;
				this.textBoxModel.Text = node.Model;

				this.textBoxDateCreated.Text = node.DateCreated.HasValue ? node.DateCreated.Value.ToString() : ControlObjectProperties.notAvailable;
				this.textBoxLastUpdated.Text = node.LastUpdated.HasValue ? node.LastUpdated.Value.ToString() : ControlObjectProperties.notAvailable;

				this.textBoxBootState.Text = node.BootState;
				this.textBoxNodeType.Text = node.NodeType;
				this.textBoxRunLevel.Text = node.RunLevel;
				this.textBoxSshKey.Text = node.SshRsaKey;

				this.checkBoxVerified.CheckState = node.Verified.HasValue ? node.Verified.Value ? CheckState.Checked : CheckState.Unchecked : CheckState.Indeterminate;

				// Identifiers.

				this.textBoxNodeId.Text = node.NodeId.HasValue ? node.NodeId.Value.ToString() : ControlObjectProperties.notAvailable;
				this.textBoxSiteId.Text = node.SiteId.HasValue ? node.SiteId.Value.ToString() : ControlObjectProperties.notAvailable;
				this.textBoxPeerId.Text = node.PeerId.HasValue ? node.PeerId.Value.ToString() : ControlObjectProperties.notAvailable;
				this.textBoxPeerNodeId.Text = node.PeerNodeId.HasValue ? node.PeerNodeId.Value.ToString() : ControlObjectProperties.notAvailable;

				// Status.

				this.textBoxLastBoot.Text = node.LastBoot.HasValue ? node.LastBoot.Value.ToString() : ControlObjectProperties.notAvailable;
				this.textBoxLastPcuReboot.Text = node.LastPcuReboot.HasValue ? node.LastPcuReboot.Value.ToString() : ControlObjectProperties.notAvailable;
				this.textBoxLastContact.Text = node.LastContact.HasValue ? node.LastContact.Value.ToString() : ControlObjectProperties.notAvailable;
				this.textBoxLastPcuConfirmation.Text = node.LastPcuConfirmation.HasValue ? node.LastPcuConfirmation.Value.ToString() : ControlObjectProperties.notAvailable;
				this.textBoxLastDownload.Text = node.LastDownload.HasValue ? node.LastDownload.Value.ToString() : ControlObjectProperties.notAvailable;

				this.textBoxLastTimeSpentOnline.Text = node.LastTimeSpentOnline.HasValue ? node.LastTimeSpentOnline.Value.ToString("d' day(s) 'hh' hour(s) 'mm' minute(s)'") : ControlObjectProperties.notAvailable;
				this.textBoxLastTimeSpentOffline.Text = node.LastTimeSpentOffline.HasValue ? node.LastTimeSpentOffline.Value.ToString("d' day(s) 'hh' hour(s) 'mm' minute(s)'") : ControlObjectProperties.notAvailable;

				// Ports.
				this.listBoxPorts.Items.Clear();
				foreach (int id in node.Ports)
				{
					this.listBoxPorts.Items.Add(id);
				}

				// PCUs.
				this.listViewPcus.Items.Clear();
				foreach (int id in node.PcuIds)
				{
					ListViewItem item = new ListViewItem(id.ToString(), 0);
					item.Tag = id;
					this.listViewPcus.Items.Add(item);
				}

				// Interfaces.
				this.listViewInterfaces.Items.Clear();
				foreach (int id in node.InterfaceIds)
				{
					ListViewItem item = new ListViewItem(id.ToString(), 0);
					item.Tag = id;
					this.listViewInterfaces.Items.Add(item);
				}

				// Slices.
				this.listViewSlices.Items.Clear();
				foreach (int id in node.SliceIds)
				{
					ListViewItem item = new ListViewItem(id.ToString(), 0);
					item.Tag = id;
					this.listViewSlices.Items.Add(item);
				}

				// Node tags.
				this.listViewNodeTags.Items.Clear();
				foreach (int id in node.NodeTagIds)
				{
					ListViewItem item = new ListViewItem(id.ToString(), 0);
					item.Tag = id;
					this.listViewNodeTags.Items.Add(item);
				}

				// Node groups.
				this.listViewNodeGroups.Items.Clear();
				foreach (int id in node.NodeGroupIds)
				{
					ListViewItem item = new ListViewItem(id.ToString(), 0);
					item.Tag = id;
					this.listViewNodeGroups.Items.Add(item);
				}

				// Slice whitelist.
				this.listViewSliceWhitelist.Items.Clear();
				foreach (int id in node.SliceIdsWhitelist)
				{
					ListViewItem item = new ListViewItem(id.ToString(), 0);
					item.Tag = id;
					this.listViewSliceWhitelist.Items.Add(item);
				}

				// Configuration files.
				this.listViewConfigurationFiles.Items.Clear();
				foreach (int id in node.ConfigurationFileIds)
				{
					ListViewItem item = new ListViewItem(id.ToString(), 0);
					item.Tag = id;
					this.listViewConfigurationFiles.Items.Add(item);
				}

				// Disable the buttons.
				this.buttonInterface.Enabled = false;
				this.buttonPcu.Enabled = false;
				this.buttonNodeTag.Enabled = false;
				this.buttonSlice.Enabled = false;
				this.buttonNodeGroup.Enabled = false;
				this.buttonSliceWhitelist.Enabled = false;
				this.buttonConfigurationFile.Enabled = false;

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
		/// An event handler called when updating the control with a PlanetLab object of the specified identifier.
		/// </summary>
		/// <param name="id">The identifier.</param>
		protected override void OnUpdate(int id)
		{
			// Hide the current information.
			this.Icon = Resources.GlobeClock_32;
			this.Title = "Updating...";
			this.Message = "Updating the information for node {0}...".FormatWith(id);
			this.tabControl.Visible = false;

			// Begin a new nodes request for the specified node.
			this.BeginRequest(this.request, CrawlerConfig.Static.PlanetLabUsername, CrawlerConfig.Static.PlanetLabPassword, PlNode.GetFilter(PlNode.Fields.NodeId, id));
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
				PlList<PlNode> nodes = null;
				// Create a PlanetLab nodes list for the given response.
				try { nodes = PlList<PlNode>.Create(response.Value as XmlRpcArray); }
				catch { }
				// If the nodes count is greater than zero.
				if ((null != nodes) && (nodes.Count > 0))
				{
					// Display the information for the first node.
					this.Object = nodes[0];
				}
				else
				{
					// Set the node to null.
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
			this.Title = "Node unknown";
			this.Message = "An error occurred while requesting the node information. {0}{1}{2}".FormatWith(
				Environment.NewLine,
				Environment.NewLine,
				exception.Message);
		}

		// Private methods.

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
		/// An event handler called when the interface selection has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnInterfaceSelectionChanged(object sender, EventArgs e)
		{
			this.buttonInterface.Enabled = this.listViewInterfaces.SelectedItems.Count > 0;
		}

		/// <summary>
		/// An event handler called when the node tag selection has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnNodeTagSelectionChanged(object sender, EventArgs e)
		{
			this.buttonNodeTag.Enabled = this.listViewNodeTags.SelectedItems.Count > 0;
		}

		/// <summary>
		/// An event handler called when the node group selection has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnNodeGroupSelectionChanged(object sender, EventArgs e)
		{
			this.buttonNodeGroup.Enabled = this.listViewNodeGroups.SelectedItems.Count > 0;
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
		/// An event handler called when the slice whitelist selection has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments,</param>
		private void OnSliceWhitelistSelectionChanged(object sender, EventArgs e)
		{
			this.buttonSliceWhitelist.Enabled = this.listViewSliceWhitelist.SelectedItems.Count > 0;
		}

		/// <summary>
		/// An event handler called when the configuration file selection has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnConfigurationFileSelectionChanged(object sender, EventArgs e)
		{
			this.buttonConfigurationFile.Enabled = this.listViewConfigurationFiles.SelectedItems.Count > 0;
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
		/// An event handler called when the user selects the properies of a interface.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnInterfaceProperties(object sender, EventArgs e)
		{
			// If there are no selected interfaces, do nothing.
			if (this.listViewInterfaces.SelectedItems.Count == 0) return;
			// Get the selected interface ID.
			int id = (int)this.listViewInterfaces.SelectedItems[0].Tag;
			using (FormObjectProperties<ControlInterfaceProperties> form = new FormObjectProperties<ControlInterfaceProperties>())
			{
				form.ShowDialog(this, "Interface", id);
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
		/// An event handler called when the user selects the properties of a node tag.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnNodeTagProperties(object sender, EventArgs e)
		{
			// If there are no selected tag, do nothing.
			if (this.listViewNodeTags.SelectedItems.Count == 0) return;
			// Get the selected tag.
			int id = (int)this.listViewNodeTags.SelectedItems[0].Tag;
			using (FormObjectProperties<ControlNodeTagProperties> form = new FormObjectProperties<ControlNodeTagProperties>())
			{
				form.ShowDialog(this, "Node Tag", id);
			}
		}

		/// <summary>
		/// An event handler called when the user selects the properties of a node group.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnNodeGroupProperties(object sender, EventArgs e)
		{
			// If there are no selected node group, do nothing.
			if (this.listViewNodeGroups.SelectedItems.Count == 0) return;
			// Get the selected node group.
			int id = (int)this.listViewNodeGroups.SelectedItems[0].Tag;
			using (FormObjectProperties<ControlNodeGroupProperties> form = new FormObjectProperties<ControlNodeGroupProperties>())
			{
				form.ShowDialog(this, "Node Group", id);
			}
		}

		/// <summary>
		/// An event handler called when the user selects the properties of a whitelisted site.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSliceWhitelistProperties(object sender, EventArgs e)
		{
			// If there are no selected slices, do nothing.
			if (this.listViewSlices.SelectedItems.Count == 0) return;
			// Get the selected slice ID.
			int id = (int)this.listViewSlices.SelectedItems[0].Tag;
			using (FormObjectProperties<ControlSliceProperties> form = new FormObjectProperties<ControlSliceProperties>())
			{
				form.ShowDialog(this, "Whitelisted Slice", id);
			}
		}

		/// <summary>
		/// An event handler called when the user selects the properties of a configuration file.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnConfigurationFileProperties(object sender, EventArgs e)
		{
			// If there are no selected configuration files, do nothing.
			if (this.listViewConfigurationFiles.SelectedItems.Count == 0) return;
			// Get the selected configuration file ID.
			int id = (int)this.listViewConfigurationFiles.SelectedItems[0].Tag;
			using (FormObjectProperties<ControlConfigurationFileProperties> form = new FormObjectProperties<ControlConfigurationFileProperties>())
			{
				form.ShowDialog(this, "Configuration File", id);
			}
		}
	}
}
