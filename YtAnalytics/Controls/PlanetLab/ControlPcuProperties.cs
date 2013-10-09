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
	/// A control that displays the information of a PlanetLab PCU.
	/// </summary>
	public partial class ControlPcuProperties : ControlObjectProperties
	{
		private readonly PlRequest request = new PlRequest(PlRequest.RequestMethod.GetPcus);

		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlPcuProperties()
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
			// Get the PCU.
			PlPcu pcu = obj as PlPcu;

			// Change the display information for the new PCU.
			if (null == pcu)
			{
				this.Title = "PCU unknown";
				this.Message = "The PCU information is not available.";
				this.Icon = Resources.GlobeWarning_32;
				this.tabControl.Visible = false;
			}
			else
			{
				// General.

				this.Title = pcu.Hostname;
				this.Message = string.Empty;
				this.Icon = Resources.GlobePower_32;

				this.textBoxHostname.Text = pcu.Hostname;
				this.textBoxModel.Text = pcu.Model;

				this.textBoxUsername.Text = pcu.Username;
				this.textBoxPassword.Text = pcu.Password;

				this.textBoxLastUpdated.Text = pcu.LastUpdated.HasValue ? pcu.LastUpdated.Value.ToString() : ControlObjectProperties.notAvailable;

				this.textBoxProtocol.Text = pcu.Protocol;
				this.textBoxIp.Text = pcu.Ip;

				this.textBoxNotes.Text = pcu.Notes;

				// Identifiers.

				this.textBoxPcuId.Text = pcu.PcuId.HasValue ? pcu.PcuId.Value.ToString() : ControlObjectProperties.notAvailable;
				this.textBoxSiteId.Text = pcu.SiteId.HasValue ? pcu.SiteId.Value.ToString() : ControlObjectProperties.notAvailable;

				// Ports.
				this.listBoxPorts.Items.Clear();
				foreach (int id in pcu.Ports)
				{
					this.listBoxPorts.Items.Add(id);
				}

				// Nodes.
				this.listViewNodes.Items.Clear();
				foreach (int id in pcu.NodeIds)
				{
					ListViewItem item = new ListViewItem(id.ToString(), 0);
					item.Tag = id;
					this.listViewNodes.Items.Add(item);
				}

				// Disable the buttons.
				this.buttonNode.Enabled = false;

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
			this.Message = "Updating the information for PCU {0}...".FormatWith(id);
			this.tabControl.Visible = false;

			// Begin a new pcus request for the specified pcu.
			this.BeginRequest(this.request, CrawlerStatic.PlanetLabUsername, CrawlerStatic.PlanetLabPassword, PlPcu.GetFilter(PlPcu.Fields.PcuId, id));
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
				// Create a PlanetLab PCUs list for the given response.
				PlList<PlPcu> pcus = PlList<PlPcu>.Create(response.Value as XmlRpcArray);
				// If the PCUs count is greater than zero.
				if (pcus.Count > 0)
				{
					// Display the information for the first PCU.
					this.Object = pcus[0];
				}
				else
				{
					// Set the PCU to null.
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
			this.Title = "PCU unknown";
			this.Message = "An error occurred while requesting the PCU information. {0}{1}{2}".FormatWith(
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
		private void OnNodeSelectionChanged(object sender, EventArgs e)
		{
			this.buttonNode.Enabled = this.listViewNodes.SelectedItems.Count > 0;
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
	}
}
