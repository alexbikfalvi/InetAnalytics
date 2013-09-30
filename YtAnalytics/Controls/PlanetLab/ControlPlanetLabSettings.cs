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
using System.Security;
using System.Windows.Forms;
using YtAnalytics.Forms.PlanetLab;
using YtCrawler;
using DotNetApi.Security;
using DotNetApi.Web.XmlRpc;
using PlanetLab.Api;
using PlanetLab.Requests;

namespace YtAnalytics.Controls.PlanetLab
{
	/// <summary>
	/// A control representing the PlanetLab settings.
	/// </summary>
	public sealed partial class ControlPlanetLabSettings : ControlRequest
	{
		private Crawler crawler;

		private PlRequest request = new PlRequest(PlRequest.RequestMethod.GetPersons);

		private string validatedUsername = null;
		private SecureString validatedPassword = null;
		private PlList<PlPerson> validatedPersons = new PlList<PlPerson>();
		private int validatedPerson = -1;

		private FormObjectProperties<ControlPersonProperties> formPersonProperties = new FormObjectProperties<ControlPersonProperties>();

		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlPlanetLabSettings()
		{
			InitializeComponent();
		}

		// Public properties.

		/// <summary>
		/// Gets or sets the crawler object.
		/// </summary>
		public Crawler Crawler
		{
			get { return this.crawler; }
			set
			{
				// Set the crawler object.
				this.crawler = value;
				// Load the configuration.
				this.OnLoad();
			}
		}

		// Protected methods.

		/// <summary>
		/// A methods called when completing a PlanetLab request.
		/// </summary>
		/// <param name="response">The response.</param>
		/// <param name="state">The request state.</param>
		protected override void OnRequestResult(XmlRpcResponse response, RequestState state)
		{
			// Enable the validation button.
			this.OnChanged(this, EventArgs.Empty);
			// If the request has not failed.
			if ((null == response.Fault) && (null != response.Value))
			{
				// Set the validated account.
				this.validatedUsername = this.textBoxUsername.Text;
				this.validatedPassword = this.textBoxPassword.SecureText;

				// Update the list of PlanetLab persons for the given response.
				this.validatedPersons.Update(response.Value as XmlRpcArray);
				this.validatedPerson = -1;

				// Lock the list.
				this.validatedPersons.Lock();
				try
				{
					// Populate the accounts list.
					foreach (PlPerson person in this.validatedPersons)
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
							item.ImageKey = "User";
							item.Tag = person;
							this.listView.Items.Add(item);
						}
					}
				}
				finally
				{
					this.validatedPersons.Unlock();
				}
			}
		}

		// Private methods.

		/// <summary>
		/// An event handler called to update the configuration.
		/// </summary>
		private void OnLoad()
		{
			if (null == this.crawler) return;

			// Load the configuration.
			this.validatedUsername = CrawlerStatic.PlanetLabUsername;
			this.validatedPassword = CrawlerStatic.PlanetLabPassword;
			this.validatedPersons = this.crawler.Config.PlanetLab.LocalPersons;
			this.validatedPerson = CrawlerStatic.PlanetLabPersonId;

			// Set the username.
			this.textBoxUsername.Text = this.validatedUsername;
			// Set the password.
			this.textBoxPassword.SecureText = this.validatedPassword;
			// Set the list of persons.
			this.validatedPersons.Lock();
			try
			{
				foreach (PlPerson person in this.validatedPersons)
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
						item.ImageKey = person.Id == this.validatedPerson ? "UserStar" : "User";
						item.Tag = person;
						this.listView.Items.Add(item);
					}
				}
			}
			finally
			{
				this.validatedPersons.Unlock();
			}
		}

		/// <summary>
		/// Validates the current configuration.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnValidate(object sender, EventArgs e)
		{
			if (null == this.crawler) return;

			// Disable the validation and save buttons.
			this.buttonValidate.Enabled = false;
			this.buttonSave.Enabled = false;
			this.buttonProperties.Enabled = false;
			// Clear the accounts list view.
			this.listView.Items.Clear();
			// Clear the list of validated person and persons.
			this.validatedPersons.Clear();
			this.validatedPerson = -1;

			// Try and validate the user account.
			try
			{
				// Begin a new nodes request for the specified person.
				this.BeginRequest(this.request, this.textBoxUsername.Text, this.textBoxPassword.SecureText, PlPerson.GetFilter(PlPerson.Fields.Email, this.textBoxUsername.Text));
			}
			catch
			{
				// Change the state of the validation button.
				this.OnChanged(this, EventArgs.Empty);
			}
		}

		/// <summary>
		/// An event handler called when configuration changes.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnChanged(object sender, EventArgs e)
		{
			this.buttonValidate.Enabled =
				(!string.IsNullOrWhiteSpace(this.textBoxUsername.Text)) &&
				(!this.textBoxPassword.SecureText.IsEmpty());
		}

		/// <summary>
		/// An event handler called when the account selection has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnAccountSelectionChanged(object sender, EventArgs e)
		{
			// If there is a selected item.
			if (this.listView.SelectedItems.Count > 0)
			{
				// Get the selected person.
				PlPerson person = this.listView.SelectedItems[0].Tag as PlPerson;

				this.buttonSave.Enabled = person.Id != this.validatedPerson;
				this.buttonProperties.Enabled = true;
			}
			else
			{
				this.buttonSave.Enabled = false;
				this.buttonProperties.Enabled = false;
			}
		}

		/// <summary>
		/// Saves the current configuration.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSave(object sender, EventArgs e)
		{
			// If there is no account selected, show a message and return.
			if (this.listView.SelectedItems.Count == 0)
			{
				MessageBox.Show(this, "You must select a default PlanetLab account.", "Cannot Save Credentials", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			// If there exists a validated person.
			if (this.validatedPerson != -1)
			{
				// Clear the default selection for the corresponding item.
				foreach (ListViewItem oldItem in this.listView.Items)
				{
					if (oldItem.Tag.Equals(this.validatedPerson))
					{
						oldItem.ImageKey = "User";
					}
				}
			}

			// Get the selected item.
			ListViewItem newItem = this.listView.SelectedItems[0];
			newItem.ImageKey = "UserStar";
			
			// Get the selected person.
			PlPerson person = newItem.Tag as PlPerson;

			// Set the selected person ID.
			this.validatedPerson = person.Id.HasValue ? person.Id.Value : -1;

			// Save the PlanetLab credentials.
			this.crawler.Config.PlanetLab.SaveCredentials(
				this.validatedUsername,
				this.validatedPassword,
				this.validatedPersons,
				this.validatedPerson);

			// Disable the save button.
			this.buttonSave.Enabled = false;
		}

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
	}
}
