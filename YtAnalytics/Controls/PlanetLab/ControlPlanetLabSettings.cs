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
		private PlList<PlPerson> validatedAccounts = null;
		private PlPerson validatedAccount = null;

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
		protected override void OnCompleteRequest(XmlRpcResponse response)
		{
			// Call the base class method.
			base.OnCompleteRequest(response);
			// Enable the validation button.
			this.OnChanged(this, EventArgs.Empty);
			// If the request has not failed.
			if ((null == response.Fault) && (null != response.Value))
			{
				// Create a PlanetLab nodes list for the given response.
				this.validatedAccounts = PlList<PlPerson>.Create(response.Value as XmlRpcArray);

				// Populate the accounts list.
				foreach (PlPerson account in this.validatedAccounts)
				{
					if (account.Id.HasValue)
					{
						ListViewItem item = new ListViewItem(new string[] {
							account.Id.Value.ToString(),
							account.FirstName,
							account.LastName
						});
						item.ImageIndex = 0;
						item.Checked = false;
						this.listView.Items.Add(item);
					}
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

			this.textBoxUsername.Text = CrawlerStatic.PlanetLabUsername;
			this.textBoxPassword.SecureText = CrawlerStatic.PlanetLabPassword;
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
			// Clear the accounts list view.
			this.listView.Items.Clear();

			// Try and validate the user account.
			try
			{
				// Begin a new nodes request for the specified person.
				this.BeginRequest(this.request, CrawlerStatic.PlanetLabUsername, CrawlerStatic.PlanetLabPassword, PlPerson.GetFilter(PlPerson.Fields.Email, this.textBoxUsername.Text));
			}
			catch
			{
				// Enable the validation button.
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
		/// Saves the current configuration.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSave(object sender, EventArgs e)
		{
			// Save the configuration.
			this.crawler.Config.PlanetLabConfig.Username = this.textBoxUsername.Text;
			this.crawler.Config.PlanetLabConfig.Password = this.textBoxPassword.SecureText;
		}

		/// <summary>
		/// An event handler called when the selected account has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnAccountChanged(object sender, ItemCheckEventArgs e)
		{
		}
	}
}
