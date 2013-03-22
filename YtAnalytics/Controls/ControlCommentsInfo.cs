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

namespace YtAnalytics.Controls
{
	/// <summary>
	/// A control that displays the feed types available in the YouTube API version 2.
	/// </summary>
	public partial class ControlCommentsInfo : ThreadSafeControl
	{
		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlCommentsInfo()
		{
			// Initialize component.
			InitializeComponent();
			// Set the default control properties.
			this.Visible = false;
			this.Dock = DockStyle.Fill;
		}

		/// <summary>
		/// An event raised when the user selects the video statistics.
		/// </summary>
		public event EventHandler ClickVideos;
		/// <summary>
		/// An event raised when the user selects the users statistics.
		/// </summary>
		public event EventHandler ClickUsers;
		/// <summary>
		/// An event raised when the user selects the playlists statistics.
		/// </summary>
		public event EventHandler ClickPlaylists;

		/// <summary>
		/// An event handler called when the user selects the videos link.
		/// </summary>
		/// <param name="sender">The sender control.</param>
		/// <param name="e">The event arguments.</param>
		private void OnVideosClick(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (null != this.ClickVideos) this.ClickVideos(this, e);
		}

		/// <summary>
		/// An event handler called when the user selects the users link.
		/// </summary>
		/// <param name="sender">The sender control.</param>
		/// <param name="e">The event arguments.</param>
		private void OnUsersClick(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (null != this.ClickUsers) this.ClickUsers(this, e);
		}

		/// <summary>
		/// An event handler called when the user selects the playlists link.
		/// </summary>
		/// <param name="sender">The sender control.</param>
		/// <param name="e">The event arguments.</param>
		private void OnPlaylistsClick(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (null != this.ClickPlaylists) this.ClickPlaylists(this, e);
		}
	}
}
