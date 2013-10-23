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
	public partial class ControlSliceTagProperties : ControlObjectProperties
	{
		private readonly PlRequest request = new PlRequest(PlRequest.RequestMethod.GetSliceTags);

		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlSliceTagProperties()
		{
			InitializeComponent();
		}

		// Protected methods.

		/// <summary>
		/// An event handler called when a new PlanetLab object is set.
		/// </summary>
		/// <param name="obj">Tha PlanetLab object.</param>
		protected override void OnObjectSet(PlObject obj)
		{
			// The PlanetLab object.
			PlSliceTag tag = obj as PlSliceTag;

			// Change the display information for the new tag.
			if (null == tag)
			{
				this.Title = "Slice tag unknown";
				this.Message = "The slice tag information is not available.";
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

				this.textBoxSliceName.Text = tag.Name;

				// Identifiers.

				this.textBoxTagId.Text = tag.SliceTagId.HasValue ? tag.SliceTagId.Value.ToString() : ControlObjectProperties.notAvailable;
				this.textBoxSliceId.Text = tag.NodeId.HasValue ? tag.NodeId.Value.ToString() : ControlObjectProperties.notAvailable;
				this.textBoxTypeId.Text = tag.TagTypeId.HasValue ? tag.TagTypeId.Value.ToString() : ControlObjectProperties.notAvailable;

				this.textBoxNodeId.Text = tag.NodeId.HasValue ? tag.NodeId.Value.ToString() : ControlObjectProperties.notAvailable;
				this.textBoxNodeGroupId.Text = tag.NodeGroupId.HasValue ? tag.NodeGroupId.Value.ToString() : ControlObjectProperties.notAvailable;

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
			this.Message = "Updating the information for slice tag {0}...".FormatWith(id);
			this.tabControl.Visible = false;

			// Begin a new tags request for the specified tag.
			this.BeginRequest(this.request, CrawlerConfig.Static.PlanetLabUsername, CrawlerConfig.Static.PlanetLabPassword, PlSliceTag.GetFilter(PlSliceTag.Fields.SliceTagId, id));
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
				PlList<PlSliceTag> tags = null;
				// Create a PlanetLab tags list for the given response.
				try { tags = PlList<PlSliceTag>.Create(response.Value as XmlRpcArray); }
				catch { }
				// If the tags count is greater than zero.
				if ((null != tags) && (tags.Count > 0))
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
			this.Title = "Slice tag unknown";
			this.Message = "An error occurred while requesting the slice tag information. {0}{1}{2}".FormatWith(
				Environment.NewLine,
				Environment.NewLine,
				exception.Message);
		}
	}
}
