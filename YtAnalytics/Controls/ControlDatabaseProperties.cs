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
using YtCrawler.Database;

namespace YtAnalytics.Controls
{
	/// <summary>
	/// Displays the information of a log event.
	/// </summary>
	public partial class ControlDatabaseProperties : UserControl
	{
		private DbDatabase database;

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
		public DbDatabase Database
		{
			get { return this.database; }
			set
			{
				this.database = value;
				if (value == null)
				{
					this.labelTitle.Text = string.Empty;
					this.tabControl.Visible = false;
				}
				else
				{
					this.labelTitle.Text = value.Name;
					this.textBoxName.Text = value.Name;
					this.textBoxId.Text = value.Id.ToString();
					this.textBoxDateCreated.Text = value.DateCreate.ToString();
					this.checkBoxSelected.Enabled = false;
					this.pictureBox.Image = Resources.Database_32;
					this.tabControl.Visible = true;
				}
				this.tabControl.SelectedTab = this.tabPageGeneral;
				this.textBoxName.Select();
				this.textBoxName.SelectionStart = 0;
				this.textBoxName.SelectionLength = 0;
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
	}
}
