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
using System.Drawing;
using System.Windows.Forms;
using DotNetApi.Windows.Controls;

namespace YtAnalytics.Controls
{
	/// <summary>
	/// A controls that displays the message box.
	/// </summary>
	public class ControlMessage : ThreadSafeControl
	{
		private ControlMessageBox message = new ControlMessageBox();

		private ShowMessageEventHandler delegateShowMessage;
		private HideMessageEventHandler delegateHideMessage;

		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlMessage()
		{
			// Add the message control.
			this.Controls.Add(this.message);
			// Create the delegates.
			this.delegateShowMessage = new ShowMessageEventHandler(this.ShowMessage);
			this.delegateHideMessage = new HideMessageEventHandler(this.HideMessage);
		}

		/// <summary>
		/// Shows an alerting message on top of the control.
		/// </summary>
		/// <param name="image">The message icon.</param>
		/// <param name="text">The message text.</param>
		/// <param name="progress">The visibility of the progress bar.</param>
		/// <param name="duration">The duration of the message in milliseconds. If negative, the message will be displayed indefinitely.</param>
		protected void ShowMessage(Image image, string text, bool progress = true, int duration = -1)
		{
			// Invoke the function on the UI thread.
			if (this.InvokeRequired)
				this.Invoke(this.delegateShowMessage, new object[] { image, text, progress, duration });
			else
			{
				// Set the message on top of all other controls.
				this.Controls.SetChildIndex(this.message, 0);
				// Show the message.
				this.message.Show(image, text, progress, duration);
			}
		}

		/// <summary>
		/// Hides the alerting message.
		/// </summary>
		protected void HideMessage()
		{
			// Invoke the function on the UI thread.
			if (this.InvokeRequired)
				this.Invoke(this.delegateHideMessage);
			else
			{
				// Hide the message.
				this.message.Hide();
			}
		}
	}
}
