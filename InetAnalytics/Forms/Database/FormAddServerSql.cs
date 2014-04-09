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
using System.Security;
using System.Windows.Forms;
using InetAnalytics.Controls;
using InetCommon.Database;
using DotNetApi.Security;
using DotNetApi.Windows;
using DotNetApi.Windows.Forms;

namespace InetAnalytics.Forms.Database
{
	/// <summary>
	/// A form dialog displaying an exception.
	/// </summary>
	public partial class FormAddServerSql : ThreadSafeForm
	{
		/// <summary>
		/// Creates a new form instance.
		/// </summary>
		public FormAddServerSql()
		{
			// Initialize the component.
			this.InitializeComponent();

			// Set the font.
			Window.SetFont(this);
		}

		// Public properties.

		/// <summary>
		/// Gets the database server type.
		/// </summary>
		public DbServerSql.DbType Type { get { return this.control.Type; } }

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
		public SecureString Password { get { return this.control.Password; } }

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
		/// An event handler called when the user input has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnInputChanged(object sender, EventArgs e)
		{
			this.buttonAdd.Enabled =
				!string.IsNullOrWhiteSpace(this.control.ServerName) &&
				!string.IsNullOrWhiteSpace(this.control.DataSource) &&
				!string.IsNullOrWhiteSpace(this.control.Username) &&
				!this.control.Password.IsEmpty();
		}
	}
}
