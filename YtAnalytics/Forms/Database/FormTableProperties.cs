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
using System.Windows.Forms;
using YtCrawler.Database;
using DotNetApi.Windows;

namespace YtAnalytics.Forms.Database
{
	/// <summary>
	/// A form dialog displaying a database table.
	/// </summary>
	public partial class FormTableProperties : Form
	{
		// UI formatter.
		private Formatting formatting = new Formatting();

		private bool canClose = true;

		/// <summary>
		/// Creates a new form instance.
		/// </summary>
		public FormTableProperties()
		{
			InitializeComponent();

			// Set the font.
			this.formatting.SetFont(this);
		}

		/// <summary>
		/// Shows the form as a dialog with the specified database table.
		/// </summary>
		/// <param name="owner">The owner window.</param>
		/// <param name="server">The database server.</param>
		/// <param name="table">The database table.</param>
		/// <returns>The dialog result.</returns>
		public DialogResult ShowDialog(IWin32Window owner, DbServer server, ITable table)
		{
			// If the table is null, do nothing.
			if (null == table) return DialogResult.Abort;

			// Select the server an table.
			this.control.Select(server, table);
			// Set the title.
			this.Text = string.Format("{0} Table Properties", table.LocalName);
			// Disable the apply button.
			this.buttonApply.Enabled = false;
			// Open the dialog.
			return base.ShowDialog(owner);
		}

		/// <summary>
		/// An event handler called when the configuration has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnConfigurationChanged(object sender, EventArgs e)
		{
			this.buttonApply.Enabled = true;
		}

		/// <summary>
		/// An event handler called when the user clicks on the OK button.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnOk(object sender, EventArgs e)
		{
			// Save the configuration and exit.
			if (this.buttonApply.Enabled)
			{
				this.OnApply(sender, e);
			}
			this.Close();
		}

		/// <summary>
		/// An event handler called when the user clicks on the Cancel button.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnCancel(object sender, EventArgs e)
		{
			// Discard the changes and exit.
			this.Close();
		}

		/// <summary>
		/// An event handler called when the user clicks on the Apply button.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnApply(object sender, EventArgs e)
		{
			// Save the configuration and disable the button.
			this.control.SaveConfiguration();
		}

		/// <summary>
		/// An event handler called when a database operation has started.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnDatabaseOperationStarted(object sender, EventArgs e)
		{
			this.canClose = false;
			this.buttonOk.Enabled = false;
			this.buttonCancel.Enabled = false;
			this.buttonApply.Enabled = false;
		}

		/// <summary>
		/// An event handler called when a database operation has finished.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnDatabaseOperationFinished(object sender, EventArgs e)
		{
			this.canClose = true;
			this.buttonOk.Enabled = true;
			this.buttonCancel.Enabled = true;
			this.buttonApply.Enabled = true;
		}

		/// <summary>
		/// An event handler called when the form is closing.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnFormClosing(object sender, FormClosingEventArgs e)
		{
			// If the form cannot be closed, cancel the event.
			if (!this.canClose) e.Cancel = true;
		}

		/// <summary>
		/// An event handler called when the table configuration was saved.
		/// </summary>
		/// <param name="sender">The sender control.</param>
		/// <param name="e">The event arguments.</param>
		private void OnConfigurationSaved(object sender, EventArgs e)
		{
			this.buttonApply.Enabled = false;
		}
	}
}
