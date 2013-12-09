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
using DotNetApi.Security;
using DotNetApi.Windows.Controls;
using InetCrawler;

namespace InetAnalytics.Controls
{
	/// <summary>
	/// A control displaying the current configuration settings.
	/// </summary>
	public partial class ControlSettings : ThemeControl
	{
		private Crawler crawler;

		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlSettings()
		{
			InitializeComponent();
			this.Dock = DockStyle.Fill;
			this.Visible = false;
		}

		/// <summary>
		/// Initializes the control.
		/// </summary>
		/// <param name="crawler">A crawler object.</param>
		public void Initialize(Crawler crawler)
		{
			this.crawler = crawler;
			this.Enabled = true;
			this.LoadSettings();
			this.buttonSave.Enabled = false;
			this.buttonUndo.Enabled = false;
		}

		/// <summary>
		/// Loads the configuration.
		/// </summary>
		private void LoadSettings()
		{
			this.numericMessageCloseDelay.Value = (decimal)this.crawler.Config.ConsoleMessageCloseDelay.TotalMilliseconds;
			this.textBoxYtUserName.Text = this.crawler.Config.YouTubeUsername;
			this.textBoxYtPassword.SecureText = this.crawler.Config.YouTubePassword;
			this.textBoxYt2Key.SecureText = this.crawler.Config.YouTubeV2ApiKey;
			this.textBoxYtCategories.Text = this.crawler.Config.YouTubeCategoriesFileName;
			this.textBoxLogFile.Text = this.crawler.Config.LogFileName;
			this.textBoxDatabaseLogFile.Text = this.crawler.Config.DatabaseLogFileName;
			this.textBoxVideoCommentsFile.Text = this.crawler.Config.CommentsVideosFileName;
			this.textBoxUserCommentsFile.Text = this.crawler.Config.CommentsUsersFileName;
			this.textBoxPlaylistCommentsFile.Text = this.crawler.Config.CommentsPlaylistsFileName;
			this.textBoxPlanetLabSlicesFolder.Text = this.crawler.PlanetLab.SlicesFolder;
			this.textBoxPlanetLabSlicesLogFile.Text = this.crawler.PlanetLab.SlicesLogFileName;
			this.textBoxPlanetLabCommandsFolder.Text = this.crawler.PlanetLab.CommandsFolder;
		}

		/// <summary>
		/// Saves the configuration.
		/// </summary>
		private void SaveSettings()
		{
			this.crawler.Config.ConsoleMessageCloseDelay = TimeSpan.FromMilliseconds((double)this.numericMessageCloseDelay.Value);
			this.crawler.Config.YouTubeUsername = this.textBoxYtUserName.Text;
			this.crawler.Config.YouTubePassword = this.textBoxYtPassword.SecureText;
			this.crawler.Config.YouTubeV2ApiKey = this.textBoxYt2Key.SecureText;
			this.crawler.Config.YouTubeCategoriesFileName = this.textBoxYtCategories.Text;
			this.crawler.Config.LogFileName = this.textBoxLogFile.Text;
			this.crawler.Config.DatabaseLogFileName = this.textBoxDatabaseLogFile.Text;
			this.crawler.Config.CommentsVideosFileName = this.textBoxVideoCommentsFile.Text;
			this.crawler.Config.CommentsUsersFileName = this.textBoxUserCommentsFile.Text;
			this.crawler.Config.CommentsPlaylistsFileName = this.textBoxPlaylistCommentsFile.Text;
			this.crawler.PlanetLab.SlicesFolder = this.textBoxPlanetLabSlicesFolder.Text;
			this.crawler.PlanetLab.SlicesLogFileName = this.textBoxPlanetLabSlicesLogFile.Text;
			this.crawler.PlanetLab.CommandsFolder = this.textBoxPlanetLabCommandsFolder.Text;
		}

		/// <summary>
		/// An event handler called when the settings have changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSettingsChanged(object sender, EventArgs e)
		{
			this.buttonSave.Enabled = true;
			this.buttonUndo.Enabled = true;
		}

		/// <summary>
		/// An event handler called when user saves the configuration.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSave(object sender, EventArgs e)
		{
			this.SaveSettings();
			this.buttonSave.Enabled = false;
			this.buttonUndo.Enabled = false;
		}

		/// <summary>
		/// An event handler called when user undoes the configuration.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnUndo(object sender, EventArgs e)
		{
			this.LoadSettings();
			this.buttonSave.Enabled = false;
			this.buttonUndo.Enabled = false;
		}
	}
}
