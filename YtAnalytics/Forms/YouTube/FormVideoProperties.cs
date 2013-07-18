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
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YtAnalytics.Controls.YouTube.Api2;
using YtApi.Api.V2.Data;
using DotNetApi.Windows;

namespace YtAnalytics.Forms
{
	/// <summary>
	/// A form dialog displaying a YouTube video.
	/// </summary>
	public partial class FormVideo : Form
	{
		// UI formatter.
		private Formatting formatting = new Formatting();

		/// <summary>
		/// Creates a new form instance.
		/// </summary>
		public FormVideo()
		{
			InitializeComponent();

			// Set the font.
			this.formatting.SetFont(this);
		}

		/// <summary>
		/// An event raised to view the user profile.
		/// </summary>
		public event ViewIdEventHandler ViewProfile;

		/// <summary>
		/// Shows the form as a dialog and the specified video.
		/// </summary>
		/// <param name="owner">The owner window.</param>
		/// <param name="video">The video.</param>
		/// <returns>The dialog result.</returns>
		public DialogResult ShowDialog(IWin32Window owner, Video video)
		{
			// If the event is null, do nothing.
			if (null == video) return DialogResult.Abort;

			// Set the event.
			this.video.Video = video;
			// Set the title.
			this.Text = video.Title;
			// Open the dialog.
			return base.ShowDialog(owner);
		}

		/// <summary>
		/// An event handler called to view the user profile.
		/// </summary>
		/// <param name="id">The profile ID.</param>
		private void OnViewProfile(string id)
		{
			if (this.ViewProfile != null)
			{
				// Close the dialog.
				this.Close();
				// Raise the event.
				this.ViewProfile(id);
			}
		}
	}
}
