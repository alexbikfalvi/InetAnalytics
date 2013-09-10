﻿/* 
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
	/// A control that displays the information of a PlanetLab address type.
	/// </summary>
	public partial class ControlAddressTypeProperties : ControlObjectProperties
	{
		private PlRequest request = new PlRequest(PlRequest.RequestMethod.GetAddressTypes);

		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlAddressTypeProperties()
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
			// Get the address type.
			PlAddressType type = obj as PlAddressType;

			// Change the display information for the new address type.
			if (null == type)
			{
				this.Title = "Address type information not available";
				this.Icon = Resources.GlobeWarning_32;
				this.tabControl.Visible = false;
			}
			else
			{
				// General.

				this.Title = type.Name;
				this.Icon = Resources.GlobeObject_32;

				this.textBoxName.Text = type.Name;
				this.textBoxDescription.Text = type.Description;

				// Identifiers.

				this.textBoxAddressTypeId.Text = type.AddressTypeId.HasValue ? type.AddressTypeId.Value.ToString() : ControlObjectProperties.notAvailable;
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
			this.Title = "Updating address type information...";
			this.tabControl.Visible = false;

			try
			{
				// Begin a new nodes request for the specified node.
				this.BeginRequest(this.request, CrawlerStatic.PlanetLabUserName, CrawlerStatic.PlanetLabPassword, PlAddressType.GetFilter(PlAddressType.Fields.AddressTypeId, id));
			}
			catch
			{
				// Catch all exceptions.
				this.Icon = Resources.GlobeError_32;
				this.Title = "Address type information not available";
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
				// Create a PlanetLab address types list for the given response.
				PlList<PlAddressType> types = PlList<PlAddressType>.Create(response.Value as XmlRpcArray);
				// If the types count is greater than zero.
				if (types.Count > 0)
				{
					// Display the information for the first type.
					this.Object = types[0];
				}
				else
				{
					// Set the node to null.
					this.Object = null;
				}
			}
		}
	}
}