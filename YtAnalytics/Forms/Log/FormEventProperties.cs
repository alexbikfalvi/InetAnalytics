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
using YtCrawler.Log;
using DotNetApi;
using DotNetApi.Windows;

namespace YtAnalytics.Forms.Log
{
	/// <summary>
	/// A form dialog displaying a log event.
	/// </summary>
	public partial class FormEventProperties : Form
	{
		/// <summary>
		/// Creates a new form instance.
		/// </summary>
		public FormEventProperties()
		{
			InitializeComponent();

			// Set the font.
			Window.SetFont(this);
		}

		/// <summary>
		/// Shows the form as a dialog and the specified event.
		/// </summary>
		/// <param name="owner">The owner window.</param>
		/// <param name="evt">The event.</param>
		/// <returns>The dialog result.</returns>
		public DialogResult ShowDialog(IWin32Window owner, LogEvent evt)
		{
			// If the event is null, do nothing.
			if (null == evt) return DialogResult.Abort;

			// Set the event.
			this.logEvent.Event = evt;
			// Set the title.
			this.Text = "{0} Event at {1} Properties".FormatWith(LogEvent.GetDescription(evt.Type), evt.Timestamp.ToString());
			// Open the dialog.
			return base.ShowDialog(owner);
		}
	}
}
