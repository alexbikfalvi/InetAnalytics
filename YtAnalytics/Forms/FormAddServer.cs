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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YtAnalytics.Controls;
using YtCrawler.Database;
using DotNetApi.Windows;

namespace YtAnalytics.Forms
{
	/// <summary>
	/// A form dialog displaying an exception.
	/// </summary>
	public partial class FormAddServer : Form
	{
		// UI formatter.
		private Formatting formatting = new Formatting();

		/// <summary>
		/// Creates a new form instance.
		/// </summary>
		public FormAddServer()
		{
			InitializeComponent();

			// Set the font.
			this.formatting.SetFont(this);
		}

		// Public events.

		/// <summary>
		/// An event raised when a new comment was added.
		/// </summary>
		public event EventHandler ServerAdded;

		// Public properties.

		/// <summary>
		/// Gets the database server type.
		/// </summary>
		public DbServers.DbServerType Type { get { return this.control.Type; } }

		/// <summary>
		/// Gets the database server name.
		/// </summary>
		public string ServerName { get { return this.control.ServerName; } }

		/// <summary>
		/// Gets the database data source.
		/// </summary>
		public string DataSource { get { return this.control.DataSource; } }

		/// <summary>
		/// Gets the user name.
		/// </summary>
		public string Username { get { return this.control.Username; } }

		/// <summary>
		/// Gets the password.
		/// </summary>
		public string Password { get { return this.control.Password; } }

		/// <summary>
		/// Indicates whether this server should be primary.
		/// </summary>
		public bool IsPrimary { get { return this.control.MakePrimary; } }

		// Public methods.

		/// <summary>
		/// Shows the add server dialog.
		/// </summary>
		/// <param name="owner">The owner window.</param>
		/// <param name="primary">The state of the primary check box.</param>
		/// <param name="primaryEnabled">The enabled state of the primary check box.</param>
		/// <returns>The dialog result.</returns>
		public DialogResult ShowDialog(IWin32Window owner, bool primary, bool primaryEnabled)
		{
			// Clear the control settings.
			this.control.Clear();
			// Set the primary check box.
			this.control.MakePrimary = primary;
			this.control.MakePrimaryEnabled = primaryEnabled;
			// Select the control.
			this.control.Select();
			// Show the dialog.
			return base.ShowDialog(owner);
		}

		// Private methods.

		/// <summary>
		/// An event handler called when the user clicks on the add button.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnAddClick(object sender, EventArgs e)
		{
			// Raise the add event.
			if (this.ServerAdded != null) this.ServerAdded(sender, e);
			// Close the dialog.
			this.Close();
		}

		/// <summary>
		/// An event handler called when the user input has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnInputChanged(object sender, EventArgs e)
		{
			this.buttonAdd.Enabled =
				(this.control.ServerName != string.Empty) &&
				(this.control.DataSource != string.Empty) &&
				(this.control.Username != string.Empty) &&
				(this.control.Password != string.Empty);
		}
	}
}
