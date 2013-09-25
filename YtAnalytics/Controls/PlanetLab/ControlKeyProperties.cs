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
using MapApi;
using PlanetLab.Api;
using PlanetLab.Requests;
using YtAnalytics.Forms.PlanetLab;
using YtCrawler;

namespace YtAnalytics.Controls.PlanetLab
{
	/// <summary>
	/// A control that displays the information of a PlanetLab key.
	/// </summary>
	public partial class ControlKeyProperties : ControlObjectProperties
	{
		private MapBulletMarker marker = new MapBulletMarker();

		private PlRequest request = new PlRequest(PlRequest.RequestMethod.GetKeys);

		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlKeyProperties()
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
			// Get the site.
			PlKey key = obj as PlKey;

			// Change the display information for the new site.
			if (null == key)
			{
				this.Title = "Key unknown";
				this.Message = "The key information is not available.";
				this.Icon = Resources.GlobeWarning_32;
				this.tabControl.Visible = false;
			}
			else
			{
				// General.

				this.Title = "Key {0}".FormatWith(key.Id);
				this.Message = string.Empty;
				this.Icon = Resources.GlobeObject_32;

				this.textBoxKey.Text = key.Key;
				this.textBoxKeyType.Text = key.KeyType;

				// Identifiers.

				this.textBoxKeyId.Text = key.KeyId.HasValue ? key.KeyId.Value.ToString() : ControlObjectProperties.notAvailable;
				this.textBoxPeerId.Text = key.PeerId.HasValue ? key.PeerId.Value.ToString() : ControlObjectProperties.notAvailable;
				this.textBoxPersonId.Text = key.PersonId.HasValue ? key.PersonId.Value.ToString() : ControlObjectProperties.notAvailable;
				this.textBoxPeerKeyId.Text = key.PeerKeyId.HasValue ? key.PeerKeyId.Value.ToString() : ControlObjectProperties.notAvailable;

				this.tabControl.Visible = true;
			}

			this.tabControl.SelectedTab = this.tabPageGeneral;
			if (this.Focused)
			{
				this.textBoxKey.Select();
				this.textBoxKey.SelectionStart = 0;
				this.textBoxKey.SelectionLength = 0;
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
			this.Message = "Updating the information for key {0}...".FormatWith(id);
			this.tabControl.Visible = false;

			// Begin a new sites request for the specified site.
			this.BeginRequest(this.request, CrawlerStatic.PlanetLabUsername, CrawlerStatic.PlanetLabPassword, PlKey.GetFilter(PlKey.Fields.KeyId, id));
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
				// Create a PlanetLab keys list for the given response.
				PlList<PlKey> keys = PlList<PlKey>.Create(response.Value as XmlRpcArray);
				// If the keys count is greater than zero.
				if (keys.Count > 0)
				{
					// Display the information for the first key.
					this.Object = keys[0];
				}
				else
				{
					// Set the site to null.
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
			this.Title = "Key unknown";
			this.Message = "An error occurred while requesting the key information. {0}{1}{2}".FormatWith(
				Environment.NewLine,
				Environment.NewLine,
				exception.Message);
		}
	}
}
