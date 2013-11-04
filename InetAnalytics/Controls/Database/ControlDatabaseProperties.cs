/* 
 * Copyright (C) 2012 Alex Bikfalvi
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
using InetCrawler.Database;
using InetCrawler.Database.Data;

namespace InetAnalytics.Controls.Database
{
	/// <summary>
	/// Displays the information of a database.
	/// </summary>
	public partial class ControlDatabaseProperties : ThreadSafeControl
	{
		private DbObjectDatabase database;

		/// <summary>
		/// Creates a new log event control instance.
		/// </summary>
		public ControlDatabaseProperties()
		{
			InitializeComponent();
		}

		// Public properties.

		/// <summary>
		/// Gets or sets the current database.
		/// </summary>
		public DbObjectDatabase Database
		{
			get { return this.database; }
			set
			{
				// Save the old value.
				DbObjectDatabase old = this.database;
				// Set the new value.
				this.database = value;
				// Call the event handler.
				this.OnDatabaseSet(old, value);
			}
		}

		/// <summary>
		/// Gets or sets whether this is the primary database server.
		/// </summary>
		public bool IsSelected
		{
			get { return this.checkBoxSelected.Checked; }
			set
			{
				this.checkBoxSelected.Checked = value;
				this.pictureBox.Image = value ? Resources.DatabaseStar_32 : Resources.Database_32;
			}
		}

		// Protected methods.

		/// <summary>
		/// An event handler called when a new database has been set.
		/// </summary>
		/// <param name="oldDatabase">The old database.</param>
		/// <param name="newDatabase">The new database.</param>
		protected virtual void OnDatabaseSet(DbObjectDatabase oldDatabase, DbObjectDatabase newDatabase)
		{
			// If the database has not changed, do nothing.
			if (oldDatabase == newDatabase) return;

			if (newDatabase == null)
			{
				this.labelTitle.Text = "No database selected";
				this.tabControl.Visible = false;
			}
			else
			{
				this.labelTitle.Text = newDatabase.Name;
				this.textBoxName.Text = newDatabase.Name;
				this.textBoxId.Text = newDatabase.DatabaseId.ToString();
				this.textBoxDateCreated.Text = newDatabase.CreateDate.ToString();
				this.checkBoxSelected.Enabled = false;
				this.pictureBox.Image = Resources.Database_32;
				this.propertyGrid.SelectedObject = newDatabase;
				this.tabControl.Visible = true;
			}
			this.tabControl.SelectedTab = this.tabPageGeneral;
			if (this.Focused)
			{
				this.textBoxName.Select();
				this.textBoxName.SelectionStart = 0;
				this.textBoxName.SelectionLength = 0;
			}
		}
	}
}
