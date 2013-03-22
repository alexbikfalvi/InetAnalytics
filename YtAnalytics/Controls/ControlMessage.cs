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
	public delegate void ShowMessageEventHandler(Image image, string text, bool progress, int duration);
	public delegate void HideMessageEventHandler();

	/// <summary>
	/// A control that displays an information message to the user.
	/// </summary>
	public partial class ControlMessage : ThreadSafeControl
	{
		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlMessage()
		{
			InitializeComponent();
			// Default state.
			this.Visible = false;
		}

		/// <summary>
		/// Shows the message control. The method is thread-safe.
		/// </summary>
		/// <param name="image">The image.</param>
		/// <param name="text">The text.</param>
		/// <param name="progress">The visibility of the progress bar.</param>
		/// <param name="duration">The duration of the message in milliseconds. If negative, the message will be displayed indefinitely.</param>
		public void Show(Image image, string text, bool progress, int duration = -1)
		{
			this.pictureBox.Image = image;
			this.label.Text = text;
			this.Left = (this.Parent.Width - this.Width) / 2;
			this.Top = (this.Parent.Height - this.Height) / 2;
			this.progressBar.Visible = progress;

			// If the duration is positive
			if (duration > 0)
			{
				// Set the timer interval.
				this.timer.Interval = duration;
				// Enable the timer.
				this.timer.Enabled = true;
			}

			this.Show();
		}

		/// <summary>
		/// Gets or sets the message control icon.
		/// </summary>
		public Image Image
		{
			get { return this.pictureBox.Image; }
			set { this.pictureBox.Image = value; }
		}

		/// <summary>
		/// Gets or sets the message control text.
		/// </summary>
		public override string Text
		{
			get { return this.label.Text; }
			set { this.label.Text = value; }
		}

		/// <summary>
		/// Gets or sets the visibility of the progress bar.
		/// </summary>
		public bool Progress
		{
			get { return this.progressBar.Visible; }
			set { this.progressBar.Visible = value; }
		}

		// Private methods.

		/// <summary>
		/// An event handler called when the timer expires.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnTick(object sender, EventArgs e)
		{
			// Disable the timer.
			this.timer.Enabled = false;
			// Hide the control.
			this.Hide();
		}
	}
}
