/* 
 * Copyright (C) 2013 Alex Bikfalvi
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
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using DotNetApi;
using DotNetApi.Windows;
using DotNetApi.Windows.Controls;

namespace YtAnalytics.Forms.PlanetLab
{
	/// <summary>
	/// A form dialog that allows exporting a PlanetLab map.
	/// </summary>
	public partial class FormExportMap : Form
	{
		private readonly MapControl.ExportProperties properties = new MapControl.ExportProperties();

		private MapControl map = null;

		/// <summary>
		/// Creates a new form instance.
		/// </summary>
		public FormExportMap()
		{
			// Initialize the component.
			this.InitializeComponent();

			// Set the properties.
			this.propertyGrid.SelectedObject = this.properties;

			// Set the font.
			Window.SetFont(this);
		}

		// Public methods.

		/// <summary>
		/// Shows the form as a dialog to export the specified list of PlanetLab objects.
		/// </summary>
		/// <param name="owner">The owner window.</param>
		/// <param name="map">The map control to export.</param>
		/// <returns>The dialog result.</returns>
		public DialogResult ShowDialog(IWin32Window owner, MapControl map)
		{
			// Reset the properties.
			this.properties.Reset();
			// Set the map control.
			this.map = map;

			return base.ShowDialog(owner);
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
				// Compute the image format.
				ImageFormat format;
				
				// BMP image (*.bmp)|*.bmp|PNG image (*.png)|*.png|JPEG image (*.jpg)|*.jpg|TIFF image (*.tiff)|*.tiff|Enhanced meta-file image (*.emf)|*.emf|Windows meta-file image (*.wmf)|*.wmf
				string extension = Path.GetExtension(this.saveFileDialog.FileName).ToLowerInvariant();
				switch (extension)
				{
					case ".bmp": format = ImageFormat.Bmp; break;
					case ".png": format = ImageFormat.Png; break;
					case ".jpg": format = ImageFormat.Jpeg; break;
					case ".tiff": format = ImageFormat.Tiff; break;
					case ".emf": format = ImageFormat.Emf; break;
					case ".wmf": format = ImageFormat.Wmf; break;
					default:
						MessageBox.Show(this, "Unrecognized image format.", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
				}

				try
				{
					// Save the map to an image.
					this.map.SaveMap(this.saveFileDialog.FileName, this.properties, format);
					// Set the dialog result.
					this.DialogResult = DialogResult.OK;
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
	}
}
