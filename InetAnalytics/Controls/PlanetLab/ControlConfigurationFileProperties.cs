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
	/// A control that displays the information of a PlanetLab configuration file.
	/// </summary>
	public partial class ControlConfigurationFileProperties : ControlObjectProperties
	{
		private readonly PlRequest request = new PlRequest(PlRequest.RequestMethod.GetConfigurationFiles);

		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlConfigurationFileProperties()
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
			PlConfigurationFile file = obj as PlConfigurationFile;

			// Change the display information for the new node.
			if (null == file)
			{
				this.ObjectTitle = "Configuration file unknown";
				this.Message = "The configuration file information is not available.";
				this.Icon = Resources.GlobeWarning_32;
				this.tabControl.Visible = false;
			}
			else
			{
				// General.

				this.ObjectTitle = "Configuration file {0}".FormatWith(file.Id);
				this.Message = string.Empty;
				this.Icon = Resources.GlobeObject_32;

				this.textBoxSource.Text = file.Source;
				this.textBoxDestination.Text = file.Destination;

				this.textBoxPermissions.Text = file.FilePermissions;
				this.textBoxGroup.Text = file.FileGroup;
				this.textBoxOwner.Text = file.FileOwner;

				this.checkBoxEnabled.CheckState = file.Enabled.HasValue ? file.Enabled.Value ? CheckState.Checked : CheckState.Unchecked : CheckState.Indeterminate;
				this.checkBoxAlwaysUpdate.CheckState = file.AlwaysUpdate.HasValue ? file.AlwaysUpdate.Value ? CheckState.Checked : CheckState.Unchecked : CheckState.Indeterminate;
				this.checkBoxIgnoreCommandErrors.CheckState = file.IgnoreCommandErrors.HasValue ? file.IgnoreCommandErrors.Value ? CheckState.Checked : CheckState.Unchecked : CheckState.Indeterminate;

				// Identifiers.

				this.textBoxConfigurationFileId.Text = file.ConfigurationFileId.HasValue ? file.ConfigurationFileId.Value.ToString() : ControlObjectProperties.notAvailable;

				// Commands.

				this.textBoxPreinstall.Text = file.PreinstallCommand;
				this.textBoxPostinstall.Text = file.PostinstallCommand;
				this.textBoxError.Text = file.ErrorCommand;

				// Nodes.
				this.listViewNodes.Items.Clear();
				foreach (int id in file.NodeIds)
				{
					ListViewItem item = new ListViewItem(id.ToString(), 0);
					item.Tag = id;
					this.listViewNodes.Items.Add(item);
				}

				// Node groups.
				this.listViewNodeGroups.Items.Clear();
				foreach (int id in file.NodeGroupIds)
				{
					ListViewItem item = new ListViewItem(id.ToString(), 0);
					item.Tag = id;
					this.listViewNodeGroups.Items.Add(item);
				}

				// Disable the buttons.
				this.buttonNode.Enabled = false;
				this.buttonNodeGroup.Enabled = false;

				this.tabControl.Visible = true;
			}

			this.tabControl.SelectedTab = this.tabPageGeneral;
			if (this.Focused)
			{
				this.textBoxSource.Select();
				this.textBoxSource.SelectionStart = 0;
				this.textBoxSource.SelectionLength = 0;
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
			this.ObjectTitle = "Updating...";
			this.Message = "Updating the information for configuration file {0}...".FormatWith(id);
			this.tabControl.Visible = false;

			// Begin a new nodes request for the specified node.
			this.BeginRequest(this.request, CrawlerConfig.Static.PlanetLabUsername, CrawlerConfig.Static.PlanetLabPassword, PlConfigurationFile.GetFilter(PlConfigurationFile.Fields.ConfigurationFileId, id));
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
				PlList<PlConfigurationFile> files = null;
				// Create a PlanetLab files list for the given response.
				try { files = PlList<PlConfigurationFile>.Create(response.Value as XmlRpcArray); }
				catch { }
				// If the files count is greater than zero.
				if ((null != files) && (files.Count > 0))
				{
					// Display the information for the first configuration file.
					this.Object = files[0];
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
			this.ObjectTitle = "Configuration file unknown";
			this.Message = "An error occurred while requesting the configuration file information. {0}{1}{2}".FormatWith(
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
		/// An event handler called when the node group selection has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnNodeGroupSelectionChanged(object sender, EventArgs e)
		{
			this.buttonNodeGroup.Enabled = this.listViewNodeGroups.SelectedItems.Count > 0;
		}

		/// <summary>
		/// An event handler called when the user selects the properties of a PCU.
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
	}
}
