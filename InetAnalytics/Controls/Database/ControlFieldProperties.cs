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
using InetCommon.Database;

namespace InetAnalytics.Controls.Database
{
	/// <summary>
	/// Displays the information of a database table field.
	/// </summary>
	public partial class ControlFieldProperties : ThreadSafeControl
	{
		private DbField field = null;

		/// <summary>
		/// Creates a new log event control instance.
		/// </summary>
		public ControlFieldProperties()
		{
			InitializeComponent();
		}

		// Public properties.

		/// <summary>
		/// Gets or sets the current database field.
		/// </summary>
		public DbField Field
		{
			get { return this.field; }
			set
			{
				// Save the old field.
				DbField old = this.field;
				// Set the new value.
				this.field = value;
				// Call the event handler.
				this.OnFieldSet(old, value);
			}
		}

		// Protected methods.

		/// <summary>
		/// An event handler called when a new field has been set.
		/// </summary>
		/// <param name="oldField">The old field.</param>
		/// <param name="newField">The new field.</param>
		protected virtual void OnFieldSet(DbField oldField, DbField newField)
		{
			// If the field has not changed, do nothing.
			if (oldField == newField) return;

			if (null != newField)
			{
				this.labelTitle.Text = "No field selected";
				this.tabControl.Visible = false;
			}
			else
			{
				this.labelTitle.Text = newField.DisplayName;
				this.textBoxNameLocal.Text = newField.LocalName;
				this.textBoxNameDatabase.Text = newField.HasName ? newField.GetDatabaseName() : string.Empty;
				this.textBoxNameDisplay.Text = newField.DisplayName;
				this.textBoxTypeLocal.Text = newField.LocalType;
				this.textBoxTypeDatabase.Text = newField.DatabaseType;
				this.textBoxDescription.Text = newField.Description;
				this.checkBoxNullable.Checked = newField.IsNullable;
				this.checkBoxConfigured.Checked = newField.HasName;
				this.pictureBox.Image = newField.HasName ? Resources.FieldSuccess_32 : Resources.FieldWarning_32;
				this.tabControl.Visible = true;
			}

			this.tabControl.SelectedTab = this.tabPageGeneral;
			if (this.Focused)
			{
				this.textBoxNameLocal.Select();
				this.textBoxNameLocal.SelectionStart = 0;
				this.textBoxNameLocal.SelectionLength = 0;
			}
		}
	}
}
