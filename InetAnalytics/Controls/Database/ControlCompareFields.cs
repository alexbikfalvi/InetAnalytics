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
	/// A control that compares a current database tale field with a database column.
	/// </summary>
	public partial class ControlCompareFields : ThreadSafeControl
	{
		DataGridViewRow rowName = new DataGridViewRow();
		DataGridViewRow rowTypeLocal = new DataGridViewRow();
		DataGridViewRow rowTypeDatabase = new DataGridViewRow();
		DataGridViewRow rowLength = new DataGridViewRow();
		DataGridViewRow rowPrecision = new DataGridViewRow();
		DataGridViewRow rowScale = new DataGridViewRow();
		DataGridViewRow rowNullable = new DataGridViewRow();

		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlCompareFields()
		{
			InitializeComponent();

			// Initialize the rows.
			this.rowName.HeaderCell.Value = "Name";
			this.rowTypeLocal.HeaderCell.Value = "Local type";
			this.rowTypeDatabase.HeaderCell.Value = "Database type";
			this.rowLength.HeaderCell.Value = "Length";
			this.rowPrecision.HeaderCell.Value = "Precision";
			this.rowScale.HeaderCell.Value = "Scale";
			this.rowNullable.HeaderCell.Value = "Nullable";

			// Add rows to the data grid.
			this.dataGrid.Rows.AddRange(new DataGridViewRow[] {
				this.rowName,
				this.rowTypeLocal,
				this.rowTypeDatabase,
				this.rowLength,
				this.rowPrecision,
				this.rowScale,
				this.rowNullable
			});
		}

		/// <summary>
		/// Compares a database field with the information received from a database server.
		/// </summary>
		/// <param name="field">The database field.</param>
		/// <param name="name">The field name.</param>
		/// <param name="type">The field type.</param>
		/// <param name="length">The field length.</param>
		/// <param name="precision">The field precision.</param>
		/// <param name="scale">The field scale.</param>
		/// <param name="nullable">The field is nullable.</param>
		public void Compare(
			DbField field,
			string name,
			string type,
			int length,
			int precision,
			int scale,
			bool? nullable)
		{
			this.rowName.Cells[0].Value = field.DisplayName;
			this.rowName.Cells[1].Value = name;
			this.rowTypeLocal.Cells[0].Value = field.LocalType;
			this.rowTypeDatabase.Cells[0].Value = field.DatabaseType;
			this.rowTypeDatabase.Cells[1].Value = type;
			this.rowLength.Cells[1].Value = length;
			this.rowPrecision.Cells[1].Value = precision;
			this.rowScale.Cells[1].Value = scale;
			this.rowNullable.Cells[0].Value = field.IsNullable ? "Yes" : "No";
			this.rowNullable.Cells[1].Value = nullable.HasValue ? nullable.Value ? "Yes" : "No" : "(unknown)";
		}

		private void OnFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			// Format database values.
			if (e.ColumnIndex == 1)
			{
				e.CellStyle.ForeColor = Color.Red;
				e.CellStyle.SelectionForeColor = Color.Red;
			}
		}
	}
}
