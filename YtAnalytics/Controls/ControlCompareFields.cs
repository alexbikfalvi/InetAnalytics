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
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DotNetApi.Windows.Controls;
using YtCrawler.Database;

namespace YtAnalytics.Controls
{
	/// <summary>
	/// A control that compares a current database tale field with a database column.
	/// </summary>
	public partial class ControlCompareFields : ThreadSafeControl
	{
		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlCompareFields()
		{
			InitializeComponent();

			// Populate the server types.
			this.comboBoxType.Items.AddRange(DbServers.ServerTypeNames);
			this.comboBoxType.SelectedIndex = 0;
		}

		/// <summary>
		/// An event raised when the input has changed.
		/// </summary>
		public event EventHandler InputChanged;

		/// <summary>
		/// Returns the database server type.
		/// </summary>
		public DbServers.DbServerType Type { get { return (DbServers.DbServerType)this.comboBoxType.SelectedIndex; } }

		/// <summary>
		/// Gets the server name.
		/// </summary>
		public string ServerName { get { return this.textBoxName.Text; } }

		/// <summary>
		/// Gets the server data source.
		/// </summary>
		public string DataSource { get { return this.textBoxDataSource.Text; } }

		/// <summary>
		/// Gets the server username.
		/// </summary>
		public string Username { get { return this.textBoxUsername.Text; } }

		/// <summary>
		/// Gets the server password.
		/// </summary>
		public string Password { get { return this.textBoxPassword.Text; } }

		/// <summary>
		/// Gets or sets whether this is the main primary database server.
		/// </summary>
		public bool MakePrimary
		{
			get { return this.checkBoxPrimary.Checked; }
			set { this.checkBoxPrimary.Checked = value; }
		}

		/// <summary>
		/// Gets or sets whether the make primary check box is enabled.
		/// </summary>
		public bool MakePrimaryEnabled
		{
			get { return this.checkBoxPrimary.Enabled; }
			set { this.checkBoxPrimary.Enabled = value; }
		}

		/// <summary>
		/// Clears the current settings.
		/// </summary>
		public void Clear()
		{
			this.comboBoxType.SelectedIndex = 0;
			this.textBoxName.Text = string.Empty;
			this.textBoxDataSource.Text = string.Empty;
			this.textBoxUsername.Text = string.Empty;
			this.textBoxPassword.Text = string.Empty;
			this.checkBoxPrimary.Checked = false;
			this.checkBoxPrimary.Enabled = true;
		}

		/// <summary>
		/// Selects the current control.
		/// </summary>
		public new void Select()
		{
			base.Select();
			this.textBoxName.Select();
			this.textBoxName.SelectionStart = 0;
			this.textBoxName.SelectionLength = 0;
		}

		/// <summary>
		/// An event handler called when the input has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnInputChanged(object sender, EventArgs e)
		{
			if (this.InputChanged != null) this.InputChanged(sender, e);
		}
	}
}
