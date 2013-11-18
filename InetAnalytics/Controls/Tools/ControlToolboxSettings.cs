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
using System.Windows.Forms;
using DotNetApi;
using DotNetApi.Windows.Controls;
using InetAnalytics.Forms.Tools;
using InetCrawler;
using InetCrawler.Tools;

namespace InetAnalytics.Controls.Tools
{
	/// <summary>
	/// A class representing the toolbox settings.
	/// </summary>
	public partial class ControlToolboxSettings : ThemeControl
	{
		private Crawler crawler;
		private readonly FormAddTool formAddTool = new FormAddTool();

		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlToolboxSettings()
		{
			InitializeComponent();
		}

		// Public methods.

		/// <summary>
		/// Initializes the control.
		/// </summary>
		/// <param name="crawler">The crawler.</param>
		public void Initialize(Crawler crawler)
		{
			// Set the crawler.
			this.crawler = crawler;
			// Enable the control.
			this.Enabled = true;

			// Load the tools.

		}

		// Private methods.

		/// <summary>
		/// An event handler called when adding a tool to the toolbox.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnAdd(object sender, EventArgs e)
		{
			// Show the load file dialog.
			if (this.openFileDialog.ShowDialog(this) == DialogResult.OK)
			{
				try
				{
					// If the user selects a file, load the toolset.
					Toolset toolset = Toolbox.Load(this.openFileDialog.FileName);

					// Show the add tool dialog with the loaded toolset.
					if (this.formAddTool.ShowDialog(this, toolset) == DialogResult.OK)
					{

					}
				}
				catch
				{
					// If an error occurs, show an error message.
					MessageBox.Show(this, "Cannot load a toolset from the specified file.", "Cannot Load Toolset", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		/// <summary>
		/// An event handler called when removing a tool from the toolbox.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnRemove(object sender, EventArgs e)
		{

		}

		/// <summary>
		/// An event handler called when viewing the properties of a tool.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnProperties(object sender, EventArgs e)
		{

		}
	}
}
