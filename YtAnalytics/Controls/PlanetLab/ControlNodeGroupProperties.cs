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
	/// A control that displays the information of a PlanetLab node group.
	/// </summary>
	public partial class ControlNodeGroupProperties : ControlObjectProperties
	{
		private PlRequest request = new PlRequest(PlRequest.RequestMethod.GetNodeGroups);

		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlNodeGroupProperties()
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
			PlNodeGroup nodeGroup = obj as PlNodeGroup;

			// Change the display information for the new node group.
			if (null == nodeGroup)
			{
				this.Title = "Node group information not available";
				this.Icon = Resources.GlobeWarning_32;
				this.tabControl.Visible = false;
			}
			else
			{
				// General.

				this.Title = nodeGroup.GroupName;
				this.Icon = Resources.GlobeObject_32;

				this.textBoxGroupName.Text = nodeGroup.GroupName;
				this.textBoxValue.Text = nodeGroup.Value;
				this.textBoxTagName.Text = nodeGroup.TagName;

				// Identifiers.

				this.textBoxNodeGroupId.Text = nodeGroup.NodeGroupId.HasValue ? nodeGroup.NodeGroupId.Value.ToString() : ControlObjectProperties.notAvailable;
				this.textBoxTagTypeId.Text = nodeGroup.TagTypeId.HasValue ? nodeGroup.TagTypeId.Value.ToString() : ControlObjectProperties.notAvailable;

				// Nodes.
				this.listViewNodes.Items.Clear();
				foreach (int id in nodeGroup.NodeIds)
				{
					ListViewItem item = new ListViewItem(id.ToString(), 0);
					item.Tag = id;
					this.listViewNodes.Items.Add(item);
				}

				// Configuration files.
				this.listViewConfigurationFiles.Items.Clear();
				foreach (int id in nodeGroup.ConfigurationFileIds)
				{
					ListViewItem item = new ListViewItem(id.ToString(), 0);
					item.Tag = id;
					this.listViewConfigurationFiles.Items.Add(item);
				}

				// Disable the buttons.
				this.buttonNode.Enabled = false;
				this.buttonConfigurationFile.Enabled = false;

				this.tabControl.Visible = true;
			}

			this.tabControl.SelectedTab = this.tabPageGeneral;
			if (this.Focused)
			{
				this.textBoxGroupName.Select();
				this.textBoxGroupName.SelectionStart = 0;
				this.textBoxGroupName.SelectionLength = 0;
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
			this.Title = "Updating node group information...";
			this.tabControl.Visible = false;

			try
			{
				// Begin a new nodes request for the specified node.
				this.BeginRequest(this.request, CrawlerStatic.PlanetLabUsername, CrawlerStatic.PlanetLabPassword, PlNodeGroup.GetFilter(PlNodeGroup.Fields.NodeGroupId, id));
			}
			catch
			{
				// Catch all exceptions.
				this.Icon = Resources.GlobeError_32;
				this.Title = "Node group information not available";
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
				// Create a PlanetLab node groups list for the given response.
				PlList<PlNodeGroup> nodeGroups = PlList<PlNodeGroup>.Create(response.Value as XmlRpcArray);
				// If the node groups count is greater than zero.
				if (nodeGroups.Count > 0)
				{
					// Display the information for the first node group.
					this.Object = nodeGroups[0];
				}
				else
				{
					// Set the node to null.
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
		/// An event handler called when the configuration file selection has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnConfigurationFileSelectionChanged(object sender, EventArgs e)
		{
			this.buttonConfigurationFile.Enabled = this.listViewConfigurationFiles.SelectedItems.Count > 0;
		}

		/// <summary>
		/// An event handler called when the user selects the properties of a node.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnNodeProperties(object sender, EventArgs e)
		{
			// If there are no selected PCUs, do nothing.
			if (this.listViewNodes.SelectedItems.Count == 0) return;
			// Get the selected PCU ID.
			int id = (int)this.listViewNodes.SelectedItems[0].Tag;
			using (FormObjectProperties<ControlNodeProperties> form = new FormObjectProperties<ControlNodeProperties>())
			{
				form.ShowDialog(this, "Node", id);
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
