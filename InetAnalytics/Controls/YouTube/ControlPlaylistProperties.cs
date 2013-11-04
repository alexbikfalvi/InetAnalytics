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
using System.Windows.Forms;
using DotNetApi.Windows.Controls;
using InetApi.YouTube.Api.V2.Data;

namespace InetAnalytics.Controls.YouTube
{
	/// <summary>
	/// A control that displays a user playlist.
	/// </summary>
	public partial class ControlPlaylistProperties : ThreadSafeControl
	{
		private Playlist playlist;

		// Creates a new control instance.
		public ControlPlaylistProperties()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Gets or sets the current playlist.
		/// </summary>
		public Playlist Playlist
		{
			get { return this.playlist; }
			set
			{
				// Save the old value.
				Playlist old = this.playlist;
				// Set the new playlist.
				this.playlist = value;
				// Call the event handler.
				this.OnPlaylistSet(old, value);
			}
		}

		// Protected methods.

		/// <summary>
		/// An event handler called when a new playlist has been set.
		/// </summary>
		/// <param name="oldPlaylist">The old playlist.</param>
		/// <param name="newPlaylist">The new playlist.</param>
		protected virtual void OnPlaylistSet(Playlist oldPlaylist, Playlist newPlaylist)
		{
			// If the playlist has not changed, do nothing
			if (oldPlaylist == newPlaylist) return;

			if (null == newPlaylist)
			{
				this.labelTitle.Text = "No playlist selected";
				this.tabControl.Visible = false;
			}
			else
			{
				this.labelTitle.Text = newPlaylist.Title;
				this.textBoxId.Text = newPlaylist.Id;
				this.textBoxPublished.Text = newPlaylist.Published != null ? newPlaylist.Published.ToString() : string.Empty;
				this.textBoxUpdated.Text = newPlaylist.Updated.ToString();
				this.textBoxAuthor.Text = newPlaylist.Author != null ? newPlaylist.Author.UserId : string.Empty;
				this.textBoxSummary.Text = newPlaylist.Summary != null ? newPlaylist.Summary : string.Empty;
				this.textBoxCount.Text = newPlaylist.CountHint.ToString();
				this.tabControl.Visible = true;
			}

			this.tabControl.SelectedTab = this.tabPageGeneral;
			if (this.Focused)
			{
				this.textBoxId.Select();
				this.textBoxId.SelectionStart = 0;
				this.textBoxId.SelectionLength = 0;
			}
		}
	}
}
