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
	/// A control that displays the information of a PlanetLab address.
	/// </summary>
	public partial class ControlAddressProperties : ControlObjectProperties
	{
		private PlRequest request = new PlRequest(PlRequest.RequestMethod.GetAddresses);

		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlAddressProperties()
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
			// Get the address.
			PlAddress address = obj as PlAddress;

			// Change the display information for the new address.
			if (null == address)
			{
				this.Title = "Node information not available";
				this.Icon = Resources.GlobeWarning_32;
				this.tabControl.Visible = false;
			}
			else
			{
				// General.

				this.Title = string.Format("Address {0}", address.AddressId);
				this.Icon = Resources.GlobeEnvelope_32;

				this.textBoxAddress.Text = "{0}{1}{2}{3}{4}".FormatWith(address.Line1, Environment.NewLine, address.Line2, Environment.NewLine, address.Line3);
				this.textBoxPostalCode.Text = address.PostalCode;
				this.textBoxCity.Text = address.City;
				this.textBoxState.Text = address.State;
				this.textBoxCountry.Text = address.Country;

				// Identifiers.

				this.textBoxAddressId.Text = address.AddressId.HasValue ? address.AddressId.Value.ToString() : ControlObjectProperties.notAvailable;

				// Types.
				this.listViewTypes.Items.Clear();
				for (int index = 0; (index < address.AddressTypeIds.Length) && (index < address.AddressTypes.Length); index++)
				{
					ListViewItem item = new ListViewItem(new string[] {
						address.AddressTypeIds[index].ToString(),
						address.AddressTypes[index] }, 0);
					item.Tag = address.AddressTypeIds[index];
					this.listViewTypes.Items.Add(item);
				}

				// Disable the buttons.
				this.buttonType.Enabled = false;

				this.tabControl.Visible = true;
			}

			this.tabControl.SelectedTab = this.tabPageGeneral;
			if (this.Focused)
			{
				this.textBoxAddress.Select();
				this.textBoxAddress.SelectionStart = 0;
				this.textBoxAddress.SelectionLength = 0;
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
			this.Title = "Updating address information...";
			this.tabControl.Visible = false;

			try
			{
				// Begin a new addresses request for the specified address.
				this.BeginRequest(this.request, CrawlerStatic.PlanetLabUsername, CrawlerStatic.PlanetLabPassword, PlAddress.GetFilter(PlAddress.Fields.AddressId, id));
			}
			catch
			{
				// Catch all exceptions.
				this.Icon = Resources.GlobeError_32;
				this.Title = "Address information not available";
			}
		}

		/// <summary>
		/// An event handler called when the request completes.
		/// </summary>
		/// <param name="response">The XML-RPC response.</param>
		/// <param name="state">The request state.</param>
		protected override void OnCompleteRequest(XmlRpcResponse response, object state)
		{
			// If the request has not failed.
			if ((null == response.Fault) && (null != response.Value))
			{
				// Create a PlanetLab addresses list for the given response.
				PlList<PlAddress> addresses = PlList<PlAddress>.Create(response.Value as XmlRpcArray);
				// If the addresses count is greater than zero.
				if (addresses.Count > 0)
				{
					// Display the information for the first address.
					this.Object = addresses[0];
				}
				else
				{
					// Set the address to null.
					this.Object = null;
				}
			}
		}

		/// <summary>
		/// An event handler called when the address type selection has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnTypeSelectionChanged(object sender, EventArgs e)
		{
			this.buttonType.Enabled = this.listViewTypes.SelectedItems.Count > 0;
		}

		/// <summary>
		/// An event handler called when the user selects the properties of an address type.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnTypeProperties(object sender, EventArgs e)
		{
			// If there are no selected types, do nothing.
			if (this.listViewTypes.SelectedItems.Count == 0) return;
			// Get the selected type ID.
			int id = (int)this.listViewTypes.SelectedItems[0].Tag;
			using (FormObjectProperties<ControlAddressTypeProperties> form = new FormObjectProperties<ControlAddressTypeProperties>())
			{
				form.ShowDialog(this, "Address Type", id);
			}
		}
	}
}
