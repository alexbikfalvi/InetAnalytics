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
	/// A control that displays the information of a PlanetLab person.
	/// </summary>
	public partial class ControlPlanetLabPersonProperties : ControlPlanetLabProperties
	{
		private static string notAvailable = "(not available)";

		private PlPerson person = null;

		private PlRequest request = new PlRequest(PlRequest.RequestMethod.GetPersons);

		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlPlanetLabPersonProperties()
		{
			InitializeComponent();
		}

		// Public properties.

		/// <summary>
		/// Gets or sets the PlanetLab person.
		/// </summary>
		public PlPerson PlanetLabPerson
		{
			get { return this.person; }
			set
			{
				// Save the old person.
				PlPerson oldPerson = this.person;
				// Change the person.
				this.person = value;
				// Call the event handler.
				this.OnPersonSet(oldPerson, value);
			}
		}

		// Public methods.

		/// <summary>
		/// Updates the PlanetLab person information with the specified person identifier.
		/// </summary>
		/// <param name="id">The person identifier.</param>
		public void UpdatePerson(int id)
		{
			// Hide the current information.
			this.Icon = Resources.GlobeClock_32;
			this.Title = string.Format("Updating information for person {0}...", id);
			this.tabControl.Visible = false;

			try
			{
				// Begin a new nodes request for the specified person.
				this.BeginRequest(this.request, CrawlerStatic.PlanetLabUserName, CrawlerStatic.PlanetLabPassword, PlPerson.GetFilter(PlPerson.Fields.PersonId, id));
			}
			catch
			{
				// Catch all exceptions.
				this.Icon = Resources.GlobeError_32;
				this.Title = "Person information not found";
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
				// Create a PlanetLab nodes list for the given response.
				PlPersons persons = PlPersons.Create(response.Value as XmlRpcArray);
				// If the nodes count is greater than zero.
				if (persons.Count > 0)
				{
					// Display the information for the first person.
					this.PlanetLabPerson = persons[0];
				}
				else
				{
					// Set the person to null.
					this.PlanetLabPerson = null;
				}
			}
		}

		/// <summary>
		/// An event handler called when a new person has been set.
		/// </summary>
		/// <param name="oldNode">The old PlanetLab person.</param>
		/// <param name="newNode">The new PlanetLab person.</param>
		protected virtual void OnPersonSet(PlPerson oldPerson, PlPerson newPerson)
		{
			// Change the display information for the new person.
			if (null == newPerson)
			{
				this.Title = "Person information not found";
				this.Icon = Resources.GlobeWarning_32;
				this.tabControl.Visible = false;
			}
			else
			{
				// General.

				this.Title = string.Format("{0} {1}", newPerson.FirstName, newPerson.LastName);
				this.Icon = Resources.GlobeUser_32;

				this.textBoxFirstName.Text = newPerson.FirstName;
				this.textBoxLastName.Text = newPerson.LastName;
				this.textBoxTitle.Text = newPerson.Title;
				this.textBoxPhone.Text = newPerson.Phone;
				this.textBoxEmail.Text = newPerson.Email;
				this.textBoxUrl.Text = newPerson.Url;
				this.textBoxBio.Text = newPerson.Bio;

				this.checkBoxEnabled.CheckState = newPerson.IsEnabled.HasValue ? newPerson.IsEnabled.Value ? CheckState.Checked : CheckState.Unchecked : CheckState.Indeterminate;

				// Identifiers.

				this.textBoxPersonId.Text = newPerson.PersonId.HasValue ? newPerson.PersonId.Value.ToString() : ControlPlanetLabPersonProperties.notAvailable;
				this.textBoxPeerId.Text = newPerson.PeerId.HasValue ? newPerson.PeerId.Value.ToString() : ControlPlanetLabPersonProperties.notAvailable;
				this.textBoxPeerPersonId.Text = newPerson.PeerPersonId.HasValue ? newPerson.PeerPersonId.Value.ToString() : ControlPlanetLabPersonProperties.notAvailable;

				// Roles.
				this.listViewRoles.Items.Clear();
				for (int index = 0; (index < newPerson.RoleIds.Length) && (index < newPerson.Roles.Length); index++)
				{
					ListViewItem item = new ListViewItem(new string[] { newPerson.RoleIds[index].ToString(), newPerson.Roles[index] }, 0);
					item.Tag = newPerson.RoleIds[index];
					this.listViewRoles.Items.Add(item);
				}

				// Keys.
				this.listViewKeys.Items.Clear();
				foreach (int id in newPerson.KeyIds)
				{
					ListViewItem item = new ListViewItem(id.ToString(), 0);
					item.Tag = id;
					this.listViewKeys.Items.Add(item);
				}

				// Slices.
				this.listViewSlices.Items.Clear();
				foreach (int id in newPerson.SliceIds)
				{
					ListViewItem item = new ListViewItem(id.ToString(), 0);
					item.Tag = id;
					this.listViewSlices.Items.Add(item);
				}

				// Sites.
				this.listViewSites.Items.Clear();
				foreach (int id in newPerson.SiteIds)
				{
					ListViewItem item = new ListViewItem(id.ToString(), 0);
					item.Tag = id;
					this.listViewSites.Items.Add(item);
				}

				// Tags.
				this.listViewTags.Items.Clear();
				foreach (int id in newPerson.PersonTagIds)
				{
					ListViewItem item = new ListViewItem(id.ToString(), 0);
					item.Tag = id;
					this.listViewTags.Items.Add(item);
				}

				// Disable the buttons.
				this.buttonRole.Enabled = false;
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
		/// An event handler called when the role selection has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnRoleSelectionChanged(object sender, EventArgs e)
		{
			this.buttonRole.Enabled = this.listViewRoles.SelectedItems.Count > 0;
		}

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
		/// An event handler called when the user selects the properties of a role.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnRoleProperties(object sender, EventArgs e)
		{
			// TO DO
		}

		/// <summary>
		/// An event handler called when the user selects the properies of a key.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnKeyProperties(object sender, EventArgs e)
		{
			// TO DO
		}

		/// <summary>
		/// An event handler called when the user selects the properties of a slice.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSliceProperties(object sender, EventArgs e)
		{
			// TO DO
		}

		/// <summary>
		/// An event handler called when the user selects the properties of a site.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSiteProperties(object sender, EventArgs e)
		{
			// TO DO
		}

		/// <summary>
		/// An event handler called when the user selects the properties of a person tag.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnTagProperties(object sender, EventArgs e)
		{
			// TO DO
		}
	}
}
