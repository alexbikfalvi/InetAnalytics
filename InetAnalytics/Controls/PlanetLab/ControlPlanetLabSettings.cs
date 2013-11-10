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
using System.Drawing;
using System.Security;
using System.Windows.Forms;
using InetAnalytics.Forms.PlanetLab;
using InetCrawler;
using InetCrawler.Log;
using DotNetApi.Security;
using DotNetApi.Web.XmlRpc;
using PlanetLab.Api;
using PlanetLab.Requests;

namespace InetAnalytics.Controls.PlanetLab
{
	/// <summary>
	/// A control representing the PlanetLab settings.
	/// </summary>
	public sealed partial class ControlPlanetLabSettings : ControlRequest
	{
		/// <summary>
		/// An enumeration representing the user selection state.
		/// </summary>
		private enum UserState
		{
			Unknown = 0,
			Success = 1,
			Failed = 2,
			NotSelected = 3
		}
		
		private static readonly string logSource = "PlanetLab";
		private static readonly Image[] personIcons = {
														  Resources.UserQuestion_48,
														  Resources.UserSuccess_48,
														  Resources.UserError_48,
														  Resources.UserWarning_48
													  };
		private static readonly string[] personMessage = {
															 "There is no current PlanelLab account.",
															 "The PlanetLab credentials correspond to the following account.",
															 "There is no PlanetLab account for the specified credentials.",
															 "There are multiple accounts corresponding to the specified credentials."
														 };

		private Crawler crawler;

		private readonly PlRequest request = new PlRequest(PlRequest.RequestMethod.GetPersons);

		private readonly FormObjectProperties<ControlPersonProperties> formPersonProperties = new FormObjectProperties<ControlPersonProperties>();
		private readonly FormPlanetLabPersons formSelectPerson = new FormPlanetLabPersons();

		private PlPerson person = null;

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
		/// A method called when starting a PlanetLab request.
		/// </summary>
		/// <param name="state">The request state.</param>
		protected override void OnRequestStarted(RequestState state)
		{
			// Disable the controls.
			this.buttonSave.Enabled = false;
			this.textBoxUsername.Enabled = false;
			this.textBoxPassword.Enabled = false;
			// Clear the person.
			this.OnSetPerson(UserState.Unknown);
			// Call the base class method.
			base.OnRequestStarted(state);
		}

		/// <summary>
		/// A method called when completing a PlanetLab request.
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
				try
				{
					// Create a new persons list.
					PlList<PlPerson> persons = new PlList<PlPerson>();
					// Get the list of PlanetLab persons for the given response.
					persons.Update(response.Value as XmlRpcArray);
					
					// Check the number of persons returned in the response.
					if (persons.Count == 1)
					{
						// If the number of persons is one, set it as the current person.
						this.OnSetPerson(persons[0]);
						// Save the credentials.
						this.OnSaveCredentials(persons, persons[0]);
					}
					else if (persons.Count > 1)
					{
						// Show the select person dialog.
						if (this.formSelectPerson.ShowDialog(this, this.textBoxUsername.Text, persons) == DialogResult.OK)
						{
							// Set the selected person as the current person.
							this.OnSetPerson(this.formSelectPerson.Result);
							// Save the credentials.
							this.OnSaveCredentials(persons, this.formSelectPerson.Result);
						}
						else
						{
							// If a list was not selected, clear the selection.
							this.OnSetPerson(UserState.NotSelected);
						}
					}
					else
					{
						// If no results were returned, clear the selection.
						this.OnSetPerson(UserState.Failed);
					}
				}
				catch
				{
					// If an error ocurred, clear the selection.
					this.OnSetPerson(UserState.Failed);
				}
			}
			// Call the base class method.
			base.OnRequestResult(response, state);
		}

		/// <summary>
		/// A method called when the request has finished.
		/// </summary>
		/// <param name="state"></param>
		protected override void OnRequestFinished(RequestState state)
		{
			// Enable the controls.
			this.buttonSave.Enabled = true;
			this.textBoxUsername.Enabled = true;
			this.textBoxPassword.Enabled = true;
			// Call the base class method.
			base.OnRequestFinished(state);
		}

		// Private methods.

		/// <summary>
		/// An event handler called to update the configuration.
		/// </summary>
		private void OnLoad()
		{
			// If the crawler is not set, do nothing.
			if (null == this.crawler) return;

			// Set the username.
			this.textBoxUsername.Text = CrawlerConfig.Static.PlanetLabUsername;
			// Set the password.
			this.textBoxPassword.SecureText = CrawlerConfig.Static.PlanetLabPassword;
			
			// Get the account.
			PlPerson person = this.crawler.Config.PlanetLab.DbPersons.Find(this.crawler.Config.PlanetLab.PersonId);

			// If there exists a person.
			if (null != person)
			{
				// Set the person.
				this.OnSetPerson(person);
			}
			else
			{
				// Clear the person.
				this.OnSetPerson(UserState.Unknown);
			}
		}

		/// <summary>
		/// Validates the current configuration.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSave(object sender, EventArgs e)
		{
			if (null == this.crawler) return;

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
			this.buttonSave.Enabled =
				(!string.IsNullOrWhiteSpace(this.textBoxUsername.Text)) &&
				(!this.textBoxPassword.SecureText.IsEmpty());
		}

		/// <summary>
		/// Shows the properties of the selected PlanetLab account.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnProperties(object sender, EventArgs e)
		{
			// If there exists a current account.
			if (null != this.person)
			{
				// Open a new dialog with the PlanetLab properties.
				this.formPersonProperties.ShowDialog(this, "Person", this.person);
			}
		}

		/// <summary>
		/// Updates the control with the information of the specified person.
		/// </summary>
		/// <param name="person">The selected person.</param>
		private void OnSetPerson(PlPerson person)
		{
			// Set the current person.
			this.person = person;
			// Show the panel.
			this.panelPerson.Visible = true;
			// Set the panel information.
			this.textBoxFirstName.Text = person.FirstName;
			this.textBoxLastName.Text = person.LastName;
			this.textBoxTitle.Text = person.Title;
			this.textBoxPhone.Text = person.Phone;
			this.textBoxEmail.Text = person.Email;
			this.textBoxUrl.Text = person.Url;
			// Enable the properties button.
			this.buttonProperties.Enabled = true;
			// Set the user icon.
			this.pictureUser.Image = ControlPlanetLabSettings.personIcons[(int)UserState.Success];
			// Set the text.
			this.labelPerson.Text = ControlPlanetLabSettings.personMessage[(int)UserState.Success];
		}

		/// <summary>
		/// Updates the control with the information of the specified person.
		/// </summary>
		/// <param name="state">The user state.</param>
		private void OnSetPerson(UserState state)
		{
			// Clear the current person.
			this.person = null;
			// Hide the panel.
			this.panelPerson.Visible = false;
			// Disable the properties button.
			this.buttonProperties.Enabled = false;
			// Set the user icon.
			this.pictureUser.Image = ControlPlanetLabSettings.personIcons[(int)state];
			// Set the text.
			this.labelPerson.Text = ControlPlanetLabSettings.personMessage[(int)state];
		}

		/// <summary>
		/// Saves the current credentials.
		/// </summary>
		/// <param name="persons">The list of persons corresponding to the current credentials.</param>
		/// <param name="person">The selected person.</param>
		private void OnSaveCredentials(PlList<PlPerson> persons, PlPerson person)
		{
			// Save the credentials.
			this.crawler.Config.PlanetLab.SaveCredentials(
				this.textBoxUsername.Text,
				this.textBoxPassword.SecureText,
				persons,
				person.Id ?? -1
				);
		}
	}
}
