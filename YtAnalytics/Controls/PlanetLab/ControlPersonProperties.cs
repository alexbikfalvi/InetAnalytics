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
	/// A control that displays the information of a PlanetLab person.
	/// </summary>
	public partial class ControlPersonProperties : ControlObjectProperties
	{
		private readonly PlRequest request = new PlRequest(PlRequest.RequestMethod.GetPersons);

		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlPersonProperties()
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
			// Get the person.
			PlPerson person = obj as PlPerson;

			// Change the display information for the new person.
			if (null == person)
			{
				this.Title = "Person unknown";
				this.Message = "The person information is not available.";
				this.Icon = Resources.GlobeWarning_32;
				this.tabControl.Visible = false;
			}
			else
			{
				// General.

				this.Title = "{0} {1}".FormatWith(person.FirstName, person.LastName);
				this.Message = string.Empty;
				this.Icon = Resources.GlobeUser_32;

				this.textBoxFirstName.Text = person.FirstName;
				this.textBoxLastName.Text = person.LastName;
				this.textBoxTitle.Text = person.Title;
				this.textBoxPhone.Text = person.Phone;
				this.textBoxEmail.Text = person.Email;
				this.textBoxUrl.Text = person.Url;
				this.textBoxBio.Text = person.Bio;

				this.checkBoxEnabled.CheckState = person.IsEnabled.HasValue ? person.IsEnabled.Value ? CheckState.Checked : CheckState.Unchecked : CheckState.Indeterminate;

				// Identifiers.

				this.textBoxPersonId.Text = person.PersonId.HasValue ? person.PersonId.Value.ToString() : ControlObjectProperties.notAvailable;
				this.textBoxPeerId.Text = person.PeerId.HasValue ? person.PeerId.Value.ToString() : ControlObjectProperties.notAvailable;
				this.textBoxPeerPersonId.Text = person.PeerPersonId.HasValue ? person.PeerPersonId.Value.ToString() : ControlObjectProperties.notAvailable;

				// Roles.
				this.listViewRoles.Items.Clear();
				for (int index = 0; (index < person.RoleIds.Length) && (index < person.Roles.Length); index++)
				{
					ListViewItem item = new ListViewItem(new string[] { person.RoleIds[index].ToString(), person.Roles[index] }, 0);
					item.Tag = person.RoleIds[index];
					this.listViewRoles.Items.Add(item);
				}

				// Keys.
				this.listViewKeys.Items.Clear();
				foreach (int id in person.KeyIds)
				{
					ListViewItem item = new ListViewItem(id.ToString(), 0);
					item.Tag = id;
					this.listViewKeys.Items.Add(item);
				}

				// Slices.
				this.listViewSlices.Items.Clear();
				foreach (int id in person.SliceIds)
				{
					ListViewItem item = new ListViewItem(id.ToString(), 0);
					item.Tag = id;
					this.listViewSlices.Items.Add(item);
				}

				// Sites.
				this.listViewSites.Items.Clear();
				foreach (int id in person.SiteIds)
				{
					ListViewItem item = new ListViewItem(id.ToString(), 0);
					item.Tag = id;
					this.listViewSites.Items.Add(item);
				}

				// Tags.
				this.listViewTags.Items.Clear();
				foreach (int id in person.PersonTagIds)
				{
					ListViewItem item = new ListViewItem(id.ToString(), 0);
					item.Tag = id;
					this.listViewTags.Items.Add(item);
				}

				// Disable the buttons.
				this.buttonKey.Enabled = false;
				this.buttonSite.Enabled = false;
				this.buttonTag.Enabled = false;

				this.tabControl.Visible = true;
			}

			this.tabControl.SelectedTab = this.tabPageGeneral;
			if (this.Focused)
			{
				this.textBoxFirstName.Select();
				this.textBoxFirstName.SelectionStart = 0;
				this.textBoxFirstName.SelectionLength = 0;
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
			this.Message = "Updating the information for person {0}...".FormatWith(id);
			this.tabControl.Visible = false;

			// Begin a new nodes request for the specified person.
			this.BeginRequest(this.request, CrawlerStatic.PlanetLabUsername, CrawlerStatic.PlanetLabPassword, PlPerson.GetFilter(PlPerson.Fields.PersonId, id));
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
				// Create a PlanetLab nodes list for the given response.
				PlList<PlPerson> persons = PlList<PlPerson>.Create(response.Value as XmlRpcArray);
				// If the nodes count is greater than zero.
				if (persons.Count > 0)
				{
					// Display the information for the first person.
					this.Object = persons[0];
				}
				else
				{
					// Set the person to null.
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
			this.Title = "Person unknown";
			this.Message = "An error occurred while requesting the person information. {0}{1}{2}".FormatWith(
				Environment.NewLine,
				Environment.NewLine,
				exception.Message);
		}

		// Private methods.

		/// <summary>
		/// An event handler called when the key selection has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnKeySelectionChanged(object sender, EventArgs e)
		{
			this.buttonKey.Enabled = this.listViewKeys.SelectedItems.Count > 0;
		}

		/// <summary>
		/// An event handler called when the slice selection has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSliceSelectionChanged(object sender, EventArgs e)
		{
			this.buttonSlice.Enabled = this.listViewSlices.SelectedItems.Count > 0;
		}

		/// <summary>
		/// An event handler called when the site selection has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSiteSelectionChanged(object sender, EventArgs e)
		{
			this.buttonSite.Enabled = this.listViewSites.SelectedItems.Count > 0;
		}

		/// <summary>
		/// An event handler called when the person tag selection has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnTagSelectionChanged(object sender, EventArgs e)
		{
			this.buttonTag.Enabled = this.listViewTags.SelectedItems.Count > 0;
		}

		/// <summary>
		/// An event handler called when the user selects the properies of a key.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnKeyProperties(object sender, EventArgs e)
		{
			// If there are no selected keys, do nothing.
			if (this.listViewKeys.SelectedItems.Count == 0) return;
			// Get the selected key ID.
			int id = (int)this.listViewKeys.SelectedItems[0].Tag;
			using (FormObjectProperties<ControlKeyProperties> form = new FormObjectProperties<ControlKeyProperties>())
			{
				form.ShowDialog(this, "Key", id);
			}
		}

		/// <summary>
		/// An event handler called when the user selects the properties of a slice.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSliceProperties(object sender, EventArgs e)
		{
			// If there are no selected slices, do nothing.
			if (this.listViewSlices.SelectedItems.Count == 0) return;
			// Get the selected slice ID.
			int id = (int)this.listViewSlices.SelectedItems[0].Tag;
			using (FormObjectProperties<ControlSliceProperties> form = new FormObjectProperties<ControlSliceProperties>())
			{
				form.ShowDialog(this, "Slice", id);
			}
		}

		/// <summary>
		/// An event handler called when the user selects the properties of a site.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSiteProperties(object sender, EventArgs e)
		{
			// If there are no selected sites, do nothing.
			if (this.listViewSites.SelectedItems.Count == 0) return;
			// Get the selected site ID.
			int id = (int)this.listViewSites.SelectedItems[0].Tag;
			using (FormObjectProperties<ControlSiteProperties> form = new FormObjectProperties<ControlSiteProperties>())
			{
				form.ShowDialog(this, "Site", id);
			}
		}

		/// <summary>
		/// An event handler called when the user selects the properties of a person tag.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnTagProperties(object sender, EventArgs e)
		{
			// If there are no selected tag, do nothing.
			if (this.listViewTags.SelectedItems.Count == 0) return;
			// Get the selected tag ID.
			int id = (int)this.listViewTags.SelectedItems[0].Tag;
			using (FormObjectProperties<ControlPersonTagProperties> form = new FormObjectProperties<ControlPersonTagProperties>())
			{
				form.ShowDialog(this, "Person Tag", id);
			}
		}
	}
}
