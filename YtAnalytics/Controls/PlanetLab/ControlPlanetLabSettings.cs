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
using YtCrawler;

namespace YtAnalytics.Controls.PlanetLab
{
	/// <summary>
	/// A control representing the PlanetLab settings.
	/// </summary>
	public partial class ControlPlanetLabSettings : UserControl
	{
		private Crawler crawler;

		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlPlanetLabSettings()
		{
			InitializeComponent();
		}

		// Public properties.

		/// <summary>
		/// Gets or sets the crawler object.
		/// </summary>
		public Crawler Crawler
		{
			get { return this.crawler; }
			set
			{
				// Set the crawler object.
				this.crawler = value;
				// Load the configuration.
				this.OnLoad();
			}
		}

		// Private methods.

		/// <summary>
		/// An event handler called to update the configuration.
		/// </summary>
		private void OnLoad()
		{
			if (this.crawler != null)
			{
				this.textBoxUsername.Text = this.crawler.Config.PlanetLabUserName;
				this.textBoxPassword.Text = this.crawler.Config.PlanetLabPassword;
				this.buttonSave.Enabled = false;
			}
		}

		/// <summary>
		/// Saves the current configuration.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSave(object sender, EventArgs e)
		{
			if (this.crawler != null)
			{
				this.crawler.Config.PlanetLabUserName = this.textBoxUsername.Text;
				this.crawler.Config.PlanetLabPassword = this.textBoxPassword.Text;
				this.buttonSave.Enabled = false;
			}
		}

		/// <summary>
		/// An event handler called when configuration changes.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnChanged(object sender, EventArgs e)
		{
			this.buttonSave.Enabled =
				(this.textBoxUsername.Text != string.Empty) &&
				(this.textBoxPassword.Text != string.Empty);
		}
	}
}
