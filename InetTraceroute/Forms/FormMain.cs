/* 
 * Copyright (C) 2014 Alex Bikfalvi
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
using DotNetApi.Windows;
using DotNetApi.Windows.Forms;
using DotNetApi.Windows.Themes;
using InetCommon.Status;

namespace InetTraceroute.Forms
{
	/// <summary>
	/// A class representing the main form.
	/// </summary>
	public partial class FormMain : ThreadSafeForm
	{
		// Theme.
		private readonly ThemeSettings themeSettings;

		// Status.
		private readonly ApplicationStatus status = new ApplicationStatus();

		/// <summary>
		/// Creates a new form instance.
		/// </summary>
		public FormMain()
		{
			// Initialize the component.
			this.InitializeComponent();

			// Get the theme settings.
			this.themeSettings = ToolStripManager.Renderer is ThemeRenderer ? (ToolStripManager.Renderer as ThemeRenderer).Settings : ThemeSettings.Default;

			// Set the event handlers.
			this.status.MessageChanged += this.OnStatusMessageChanged;

			// Set the font.
			Window.SetFont(this);
		}

		#region Private methods

		/// <summary>
		/// An event handler called when changing the status message.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnStatusMessageChanged(object sender, ApplicationStatusMessageEventArgs e)
		{
			// Call the code on the UI thread.
			this.Invoke(() =>
			{
				if (e.Message.HasValue)
				{
					// If the status type has changed.
					if (e.Message.Value.Type != this.status.Status)
					{
						// Update the status.
						switch (e.Message.Value.Type)
						{
							case ApplicationStatus.StatusType.Ready:
								this.statusStrip.BackColor = this.themeSettings.ColorTable.StatusStripReadyBackground;
								this.statusLabelLeft.ForeColor = this.themeSettings.ColorTable.StatusStripReadyText;
								this.statusLabelRight.ForeColor = this.themeSettings.ColorTable.StatusStripReadyText;
								this.statusLabelConnection.ForeColor = this.themeSettings.ColorTable.StatusStripReadyText;
								this.statusLabelRun.ForeColor = this.themeSettings.ColorTable.StatusStripReadyText;
								break;
							case ApplicationStatus.StatusType.Normal:
								this.statusStrip.BackColor = this.themeSettings.ColorTable.StatusStripNormalBackground;
								this.statusLabelLeft.ForeColor = this.themeSettings.ColorTable.StatusStripNormalText;
								this.statusLabelRight.ForeColor = this.themeSettings.ColorTable.StatusStripNormalText;
								this.statusLabelConnection.ForeColor = this.themeSettings.ColorTable.StatusStripNormalText;
								this.statusLabelRun.ForeColor = this.themeSettings.ColorTable.StatusStripNormalText;
								break;
							case ApplicationStatus.StatusType.Busy:
								this.statusStrip.BackColor = this.themeSettings.ColorTable.StatusStripBusyBackground;
								this.statusLabelLeft.ForeColor = this.themeSettings.ColorTable.StatusStripBusyText;
								this.statusLabelRight.ForeColor = this.themeSettings.ColorTable.StatusStripBusyText;
								this.statusLabelConnection.ForeColor = this.themeSettings.ColorTable.StatusStripBusyText;
								this.statusLabelRun.ForeColor = this.themeSettings.ColorTable.StatusStripBusyText;
								break;
						}
						// Set the new status.
						this.status.Status = e.Message.Value.Type;
					}
					this.statusLabelLeft.Image = e.Message.Value.LeftImage;
					this.statusLabelLeft.Text = e.Message.Value.LeftText;
					this.statusLabelRight.Image = e.Message.Value.RightImage;
					this.statusLabelRight.Text = e.Message.Value.RightText;
				}
				else
				{
					this.statusStrip.BackColor = this.themeSettings.ColorTable.StatusStripReadyBackground;
					this.statusLabelLeft.ForeColor = this.themeSettings.ColorTable.StatusStripReadyText;
					this.statusLabelRight.ForeColor = this.themeSettings.ColorTable.StatusStripReadyText;
					this.statusLabelConnection.ForeColor = this.themeSettings.ColorTable.StatusStripReadyText;
					this.statusLabelRun.ForeColor = this.themeSettings.ColorTable.StatusStripReadyText;
					this.statusLabelLeft.Image = Resources.Information_16;
					this.statusLabelLeft.Text = "Ready.";
					this.statusLabelRight.Image = null;
					this.statusLabelRight.Text = null;
					this.status.Status = ApplicationStatus.StatusType.Ready;
				}
			});
		}

		private void OnTabChanged(object sender, EventArgs e)
		{
			this.status.Activate(this.tabControl.TabPages[this.tabControl.SelectedIndex]);
		}

		#endregion
	}
}
