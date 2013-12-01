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
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using PlanetLab;
using PlanetLab.Api;
using DotNetApi;
using DotNetApi.Windows;
using DotNetApi.Windows.Forms;

namespace InetAnalytics.Forms.PlanetLab
{
	/// <summary>
	/// A form dialog that allows exporting PlanetLab objects.
	/// </summary>
	public partial class FormExport : ThreadSafeForm
	{
		private IEnumerable<PlObject> list;

		/// <summary>
		/// Creates a new form instance.
		/// </summary>
		public FormExport()
		{
			// Initialize the component.
			this.InitializeComponent();

			// Set the font.
			Window.SetFont(this);
		}

		// Public methods.

		/// <summary>
		/// Shows the form as a dialog to export the specified list of PlanetLab objects.
		/// </summary>
		/// <typeparam name="T">The PlanetLab object type.</typeparam>
		/// <param name="owner">The owner window.</param>
		/// <param name="fields">The fields.</param>
		/// <param name="list">The list data.</param>
		/// <returns>The dialog result.</returns>
		public DialogResult ShowDialog<T>(IWin32Window owner, Type fields, IEnumerable<T> list) where T : PlObject
		{
			// Clear the dialog.
			this.listHeaders.Items.Clear();
			this.checkBoxHeaders.Checked = false;
			this.buttonSave.Enabled = false;

			// Set the list.
			this.list = list;

			// Get the public instance properties for this type.
			PropertyInfo[] properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
			
			// Populate the headers list.
			foreach (Enum field in Enum.GetValues(fields))
			{
				PropertyInfo property = properties.FirstOrDefault((PropertyInfo pr) =>
					{
						return pr.Name == field.ToString();
					});

				if (null != property)
				{
					// If the property type is an array, ignore.
					if (property.PropertyType.IsArray) continue;

					ListViewItem item = new ListViewItem(new string[] {
						field.GetDisplayName(),
						property.PropertyType.GetName() });

					item.Checked = false;
					item.Tag = property;

					this.listHeaders.Items.Add(item);
				}
			}

			// Set the select all and clear all enabled state.
			this.buttonSelectAll.Enabled = (this.listHeaders.Items.Count > 0) && (this.listHeaders.CheckedItems.Count < this.listHeaders.Items.Count);
			this.buttonClearAll.Enabled = this.listHeaders.CheckedItems.Count > 0;

			return base.ShowDialog(owner);
		}

		/// <summary>
		/// An event handler called when the headers check state has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnHeaderChecked(object sender, ItemCheckedEventArgs e)
		{
			this.buttonSave.Enabled = this.listHeaders.CheckedItems.Count > 0;
			this.buttonSelectAll.Enabled = (this.listHeaders.Items.Count > 0) && (this.listHeaders.CheckedItems.Count < this.listHeaders.Items.Count);
			this.buttonClearAll.Enabled = this.listHeaders.CheckedItems.Count > 0;
		}

		/// <summary>
		/// An event handler called when the user clicks on the save button.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSave(object sender, EventArgs e)
		{
			// Show the save file dialog.
			if (this.saveFileDialog.ShowDialog(this) == DialogResult.OK)
			{
				try
				{
					// Create the CSV file.
					using (FileStream file = new FileStream(this.saveFileDialog.FileName, FileMode.Create))
					{
						// Create a stream text writer.
						using (StreamWriter writer = new StreamWriter(file, Encoding.UTF8))
						{
							// If save the headers.
							if (this.checkBoxHeaders.Checked)
							{
								bool first = true;
								// For all headers.
								foreach (ListViewItem item in this.listHeaders.CheckedItems)
								{
									writer.Write("{0}{1}".FormatWith(first ? string.Empty : ",", (item.Tag as PropertyInfo).Name));
									// Set the first field to false.
									first = false;
								}
								writer.WriteLine();
							}
							// For all objects in the list.
							foreach (PlObject obj in this.list)
							{
								bool first = true;
								bool quote = false;
								// For all headers.
								foreach (ListViewItem item in this.listHeaders.CheckedItems)
								{
									// Get the property info.
									PropertyInfo property = item.Tag as PropertyInfo;
									// Get the property value.
									object value = property.GetValue(obj, null);
									// Get the value string.
									string str = null != value ? value.ToString().Replace("\"", "\"\"") : string.Empty;
									// Check whether the field must be quoted.
									quote = str.Contains('\"') || str.Contains(',') || str.Contains('\n');
									// Write the field.
									writer.Write("{0}{1}{2}{3}".FormatWith(
										first ? string.Empty : ",",
										quote ? "\"" : string.Empty,
										str,
										quote ? "\"" : string.Empty));
									// Set the first field to false.
									first = false;
								}
								writer.WriteLine();
							}
						}
					}
					// Close the dialog.
					this.Close();
				}
				catch (Exception exception)
				{
					// If an exception occurs, show an error message.
					MessageBox.Show(this, "Exporting the data failed. {0}".FormatWith(exception.Message), "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		/// <summary>
		/// An event handler called when the user selects all headers.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSelectAll(object sender, EventArgs e)
		{
			foreach (ListViewItem item in this.listHeaders.Items)
			{
				item.Checked = true;
			}
		}

		/// <summary>
		/// An event handler called when the user clears all headers.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnClearAll(object sender, EventArgs e)
		{
			foreach (ListViewItem item in this.listHeaders.Items)
			{
				item.Checked = false;
			}
		}
	}
}
