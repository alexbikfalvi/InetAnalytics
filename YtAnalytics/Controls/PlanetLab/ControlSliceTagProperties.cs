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
using YtCrawler;

namespace YtAnalytics.Controls.PlanetLab
{
	/// <summary>
	/// A control that displays the information of a PlanetLab tag.
	/// </summary>
	public partial class ControlSliceTagProperties : ControlObjectProperties
	{
		private PlRequest request = new PlRequest(PlRequest.RequestMethod.GetSliceTags);

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
		/// <param name="obj"></param>
		protected override void OnObjectSet(PlObject obj)
		{
			this.OnTagSet(obj as PlSliceTag);
		}

		/// <summary>
		/// An event handler called when updating the control with a PlanetLab object of the specified identifier.
		/// </summary>
		/// <param name="id">The identifier.</param>
		protected override void OnUpdate(int id)
		{
			// Hide the current information.
			this.Icon = Resources.GlobeClock_32;
			this.Title = "Updating tag information...";
			this.tabControl.Visible = false;

			try
			{
				// Begin a new tags request for the specified tag.
				this.BeginRequest(this.request, CrawlerStatic.PlanetLabUserName, CrawlerStatic.PlanetLabPassword, PlSliceTag.GetFilter(PlSliceTag.Fields.SliceTagId, id));
			}
			catch
			{
				// Catch all exceptions.
				this.Icon = Resources.GlobeError_32;
				this.Title = "Tag information not found";
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
				// Create a PlanetLab tags list for the given response.
				PlList<PlSliceTag> tags = PlList<PlSliceTag>.Create(response.Value as XmlRpcArray);
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
		/// An event handler called when a new tag has been set.
		/// </summary>
		/// <param name="tag">The new PlanetLab tag.</param>
		protected virtual void OnTagSet(PlSliceTag tag)
		{
			// Change the display information for the new tag.
			if (null == tag)
			{
				this.Title = "Tag information not found";
				this.Icon = Resources.GlobeWarning_32;
				this.tabControl.Visible = false;
			}
			else
			{
				// General.

				this.Title = tag.TagName;
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
	}
}
