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
	/// A control that displays the information of a PlanetLab PCU.
	/// </summary>
	public partial class ControlPlanetLabPcuProperties : ControlPlanetLab
	{
		private static string notAvailable = "(not available)";

		private PlPcu pcu = null;

		private PlRequest request = new PlRequest(PlRequest.RequestMethod.GetPcus);

		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlPlanetLabPcuProperties()
		{
			InitializeComponent();
		}

		// Public properties.

		/// <summary>
		/// Gets or sets the PlanetLab PCU.
		/// </summary>
		public PlPcu PlanetLabPcu
		{
			get { return this.pcu; }
			set
			{
				// Save the old pcu.
				PlPcu oldPcu = this.pcu;
				// Change the pcu.
				this.pcu = value;
				// Call the event handler.
				this.OnPcuSet(oldPcu, value);
			}
		}

		// Public methods.

		/// <summary>
		/// Updates the PlanetLab pcu information with the specified pcu identifier.
		/// </summary>
		/// <param name="id">The pcu identifier.</param>
		public void UpdatePcu(int id)
		{
			// Hide the current information.
			this.pictureBox.Image = Resources.GlobeClock_32;
			this.labelTitle.Text = "Updating PCU information...";
			this.tabControl.Visible = false;

			try
			{
				// Begin a new pcus request for the specified pcu.
				this.BeginRequest(this.request, CrawlerStatic.PlanetLabUserName, CrawlerStatic.PlanetLabPassword, PlPcu.GetFilter(PlPcu.Fields.PcuId, id));
			}
			catch
			{
				// Catch all exceptions.
				this.pictureBox.Image = Resources.GlobeError_32;
				this.labelTitle.Text = "PCU information not found";
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
				// Create a PlanetLab PCUs list for the given response.
				PlPcus pcus = PlPcus.Create(response.Value as XmlRpcArray);
				// If the PCUs count is greater than zero.
				if (pcus.Count > 0)
				{
					// Display the information for the first PCU.
					this.PlanetLabPcu = pcus[0];
				}
				else
				{
					// Set the PCU to null.
					this.PlanetLabPcu = null;
				}
			}
		}

		/// <summary>
		/// An event handler called when a new PCU has been set.
		/// </summary>
		/// <param name="oldPcu">The old PlanetLab PCU.</param>
		/// <param name="newPcu">The new PlanetLab PCU.</param>
		protected virtual void OnPcuSet(PlPcu oldPcu, PlPcu newPcu)
		{
			// Change the display information for the new PCU.
			if (null == newPcu)
			{
				this.labelTitle.Text = "PCU information not found";
				this.pictureBox.Image = Resources.GlobeWarning_32;
				this.tabControl.Visible = false;
			}
			else
			{
				// General.

				this.labelTitle.Text = newPcu.Hostname;
				this.pictureBox.Image = Resources.GlobePower_32;

				this.textBoxHostname.Text = newPcu.Hostname;
				this.textBoxModel.Text = newPcu.Model;

				this.textBoxUsername.Text = newPcu.Username;
				this.textBoxPassword.Text = newPcu.Password;

				this.textBoxLastUpdated.Text = newPcu.LastUpdated.HasValue ? newPcu.LastUpdated.Value.ToString() : ControlPlanetLabPcuProperties.notAvailable;

				this.textBoxProtocol.Text = newPcu.Protocol;
				this.textBoxIp.Text = newPcu.Ip;

				this.textBoxNotes.Text = newPcu.Notes;

				// Identifiers.

				this.textBoxPcuId.Text = newPcu.PcuId.HasValue ? newPcu.PcuId.Value.ToString() : ControlPlanetLabPcuProperties.notAvailable;
				this.textBoxSiteId.Text = newPcu.SiteId.HasValue ? newPcu.SiteId.Value.ToString() : ControlPlanetLabPcuProperties.notAvailable;

				// Ports.
				this.listBoxPorts.Items.Clear();
				foreach (int id in newPcu.Ports)
				{
					this.listBoxPorts.Items.Add(id);
				}

				// Nodes.
				this.listViewNodes.Items.Clear();
				foreach (int id in newPcu.NodeIds)
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
			// TO DO
		}
	}
}
