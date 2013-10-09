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
using YtCrawler;

namespace YtAnalytics.Controls.PlanetLab
{
	/// <summary>
	/// A control that displays the information of a PlanetLab tag.
	/// </summary>
	public partial class ControlSiteTagProperties : ControlObjectProperties
	{
		private readonly PlRequest request = new PlRequest(PlRequest.RequestMethod.GetSiteTags);

		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlSiteTagProperties()
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
			// Get the tag.
			PlSiteTag tag = obj as PlSiteTag;

			// Change the display information for the new tag.
			if (null == tag)
			{
				this.Title = "Site tag unknown";
				this.Message = "The site tag information is not available.";
				this.Icon = Resources.GlobeWarning_32;
				this.tabControl.Visible = false;
			}
			else
			{
				// General.

				this.Title = tag.TagName;
				this.Message = string.Empty;
				this.Icon = Resources.GlobeTag_32;

				this.textBoxTagName.Text = tag.TagName;
				this.textBoxDescription.Text = tag.Description;
				this.textBoxCategory.Text = tag.Category;
				this.textBoxValue.Text = tag.Value;

				this.textBoxLoginBase.Text = tag.LoginBase;

				// Identifiers.

				this.textBoxTagId.Text = tag.SiteTagId.HasValue ? tag.SiteTagId.Value.ToString() : ControlObjectProperties.notAvailable;
				this.textBoxSiteId.Text = tag.SiteId.HasValue ? tag.SiteId.Value.ToString() : ControlObjectProperties.notAvailable;
				this.textBoxTypeId.Text = tag.TagTypeId.HasValue ? tag.TagTypeId.Value.ToString() : ControlObjectProperties.notAvailable;

				this.tabControl.Visible = true;
			}

			this.tabControl.SelectedTab = this.tabPageGeneral;
			if (this.Focused)
			{
				this.textBoxTagName.Select();
				this.textBoxTagName.SelectionStart = 0;
				this.textBoxTagName.SelectionLength = 0;
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
			this.Message = "Updating the information for site tag {0}...".FormatWith(id);
			this.tabControl.Visible = false;

			// Begin a new tags request for the specified tag.
			this.BeginRequest(this.request, CrawlerStatic.PlanetLabUsername, CrawlerStatic.PlanetLabPassword, PlSiteTag.GetFilter(PlSiteTag.Fields.SiteTagId, id));
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
				// Create a PlanetLab tags list for the given response.
				PlList<PlSiteTag> tags = PlList<PlSiteTag>.Create(response.Value as XmlRpcArray);
				// If the tags count is greater than zero.
				if (tags.Count > 0)
				{
					// Display the information for the first tag.
					this.Object = tags[0];
				}
				else
				{
					// Set the tag to null.
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
			this.Title = "Site tag unknown";
			this.Message = "An error occurred while requesting the site tag information. {0}{1}{2}".FormatWith(
				Environment.NewLine,
				Environment.NewLine,
				exception.Message);
		}
	}
}
