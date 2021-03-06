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
using System.Windows.Forms;
using DotNetApi;
using DotNetApi.Windows;
using DotNetApi.Windows.Forms;
using InetCommon.Database;

namespace InetAnalytics.Forms.Database
{
	/// <summary>
	/// A form dialog displaying the properties of a database server.
	/// </summary>
	public partial class FormServerProperties : ThreadSafeForm
	{
		/// <summary>
		/// Creates a new form instance.
		/// </summary>
		public FormServerProperties()
		{
			// Initialize the component.
			this.InitializeComponent();

			// Set the font.
			Window.SetFont(this);
		}

		/// <summary>
		/// Shows the form as a dialog and the specified database server.
		/// </summary>
		/// <param name="owner">The owner window.</param>
		/// <param name="server">The database server.</param>
		/// <param name="isPrimary">Indicates if the database server is primary.</param>
		/// <returns>The dialog result.</returns>
		public DialogResult ShowDialog(IWin32Window owner, DbServerSql server, bool isPrimary)
		{
			// If the server is null, do nothing.
			if (null == server) return DialogResult.Abort;

			// Set the server.
			this.control.Server = server;
			this.control.IsPrimary = isPrimary;
			// Set the title.
			this.Text = "{0} Server Properties".FormatWith(server.Name);
			// Disable the apply button.
			this.buttonApply.Enabled = false;
			// Set an event handler for the server state.
			server.StateChanged += this.OnServerStateChanged;
			// Open the dialog.
			return base.ShowDialog(owner);
		}

		// Private methods.

		/// <summary>
		/// Shows the form.
		/// </summary>
		private new void Show()
		{
			base.Show();
		}

		/// <summary>
		/// Shows the form.
		/// </summary>
		/// <param name="owner">The owner.</param>
		private new void Show(IWin32Window owner)
		{
			base.Show(owner);
		}

		/// <summary>
		/// Shows the dialog.
		/// </summary>
		/// <returns>The dialog result.</returns>
		private new DialogResult ShowDialog()
		{
			return base.ShowDialog();
		}

		/// <summary>
		/// Shows the dialog.
		/// </summary>
		/// <param name="owner">The owner.</param>
		/// <returns>The dialog result.</returns>
		private new DialogResult ShowDialog(IWin32Window owner)
		{
			return base.ShowDialog(owner);
		}

		/// <summary>
		/// An event handler called when the configuration has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnConfigurationChanged(object sender, EventArgs e)
		{
			this.Text = this.control.ServerName;
			this.buttonApply.Enabled = 
				(this.control.ServerName != this.control.Server.Name) ||
				(this.control.DataSource != this.control.Server.DataSource) ||
				(this.control.Username != this.control.Server.Username) ||
				(this.control.Password != this.control.Server.Password);
		}

		/// <summary>
		/// An event handler called when the user clicks on the OK button.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnOk(object sender, EventArgs e)
		{
			// Save the configuration and exit.
			this.OnApply(sender, e);
		}

		/// <summary>
		/// An event handler called when the user clicks on the Apply button.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnApply(object sender, EventArgs e)
		{
			// Save the configuration and disable the button.
			this.buttonApply.Enabled = false;
			this.control.Server.Name = this.control.ServerName;
			this.control.Server.DataSource = this.control.DataSource;
			this.control.Server.Username = this.control.Username;
			this.control.Server.Password = this.control.Password;
			this.control.Server.SaveConfiguration();
		}

		/// <summary>
		/// An event handler called when the user is closing the dialog.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnFormClosing(object sender, FormClosingEventArgs e)
		{
			// Remove the event handler of the state change method.
			this.control.Server.StateChanged -= this.OnServerStateChanged;
		}

		/// <summary>
		/// An event handler called when the server state has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnServerStateChanged(object sender, DbServerStateEventArgs e)
		{
			// Update the control state.
			this.control.StateChanged(e.Server);
		}
	}
}
