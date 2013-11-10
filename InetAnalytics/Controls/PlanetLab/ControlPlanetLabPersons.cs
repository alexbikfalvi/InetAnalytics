/* 
 * Copyright (C) 2013 Alex Bikfalvi
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
using System.Windows.Forms;
using DotNetApi.Windows.Controls;
using PlanetLab;
using PlanetLab.Api;
using InetAnalytics.Forms.PlanetLab;

namespace InetAnalytics.Controls.PlanetLab
{
	/// <summary>
	/// A control allowing the selection of a PlanetLab person account.
	/// </summary>
	public sealed partial class ControlPlanetLabPersons : ThreadSafeControl
	{
		private readonly FormObjectProperties<ControlPersonProperties> formPersonProperties = new FormObjectProperties<ControlPersonProperties>();

		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlPlanetLabPersons()
		{
			InitializeComponent();
		}

		// Public events.

		/// <summary>
		/// An event raised when the user selects a person.
		/// </summary>
		public event PlObjectEventHandler<PlPerson> Selected;
		/// <summary>
		/// An event raised when the user cancels the person selection.
		/// </summary>
		public event EventHandler Canceled;

		// Public methods.

		/// <summary>
		/// Refreshes the control with the specified list of PlanetLab persons.
		/// </summary>
		/// <param name="username">The account username.</param>
		/// <param name="persons">The persons list.</param>
		public void Refresh(string username, PlList<PlPerson> persons)
		{
			// Set the control default state.
			this.buttonSelect.Enabled = false;
			this.buttonProperties.Enabled = false;

			// Set the username.
			this.textBoxUsername.Text = username;

			// Clear the persons list.
			this.listView.Items.Clear();

			// Set the list of persons.
			persons.Lock();
			try
			{
				foreach (PlPerson person in persons)
				{
					if (person.Id.HasValue)
					{
						ListViewItem item = new ListViewItem(new string[] {
								person.Id.Value.ToString(),
								person.FirstName,
								person.LastName,
								person.IsEnabled.HasValue ? person.IsEnabled.Value ? "Yes" : "No" : "Unknown",
								person.Phone,
								person.Email,
								person.Url
							});
						item.ImageIndex = 0;
						item.Tag = person;
						this.listView.Items.Add(item);
					}
				}
			}
			finally
			{
				persons.Unlock();
			}
		}

		// Private methods.

		/// <summary>
		/// Shows the properties of the selected PlanetLab account.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnProperties(object sender, EventArgs e)
		{
			// If there is no account selected, do nothing.
			if (this.listView.SelectedItems.Count == 0) return;

			// Get the person.
			PlPerson person = this.listView.SelectedItems[0].Tag as PlPerson;

			// Open a new dialog with the PlanetLab properties.
			this.formPersonProperties.ShowDialog(this, "Person", person);
		}

		/// <summary>
		/// An event handler called when user user clicks the list view.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnMouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				if (this.listView.FocusedItem != null)
				{
					if (this.listView.FocusedItem.Bounds.Contains(e.Location))
					{
						this.contextMenu.Show(this.listView, e.Location);
					}
				}
			}
		}

		/// <summary>
		/// An event handler called when the selection has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSelectionChanged(object sender, EventArgs e)
		{
			// If there are selected items.
			if (this.listView.SelectedItems.Count > 0)
			{
				this.buttonSelect.Enabled = true;
				this.buttonProperties.Enabled = true;
			}
			else
			{
				this.buttonSelect.Enabled = false;
				this.buttonProperties.Enabled = false;
			}
		}

		/// <summary>
		/// An event handler called when the user clicks on the select button.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSelect(object sender, EventArgs e)
		{
			// If there are no selected persons, do nothing.
			if (this.listView.SelectedItems.Count == 0) return;

			// Get the selected person.
			PlPerson person = this.listView.SelectedItems[0].Tag as PlPerson;

			// Raise the selected event.
			if (null != this.Selected) this.Selected(this, new PlObjectEventArgs<PlPerson>(person));
		}

		/// <summary>
		/// An event handler called when the user clicks on the cancel button.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnCancel(object sender, EventArgs e)
		{
			// Raise the canceled event.
			if (null != this.Canceled) this.Canceled(this, e);
		}
	}
}
