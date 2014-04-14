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
using System.ComponentModel;
using System.Windows.Forms;
using DotNetApi;
using DotNetApi.Windows;
using DotNetApi.Windows.Forms;
using DotNetApi.Windows.Themes;
using InetCommon.Net;
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

		// Application.
		private readonly TracerouteApplication application;

		// Forms.
		private readonly FormAbout formAbout = new FormAbout();

		/// <summary>
		/// Creates a new form instance.
		/// </summary>
		/// <param name="application">The traceroute application.</param>
		public FormMain(TracerouteApplication application)
		{
			// Set the application.
			this.application = application;

			// Initialize the component.
			this.InitializeComponent();

			// Get the theme settings.
			this.themeSettings = ToolStripManager.Renderer is ThemeRenderer ? (ToolStripManager.Renderer as ThemeRenderer).Settings : ThemeSettings.Default;

			// Intialize the controls.
			this.controlAddresses.Initialize(this.application);
			this.controlDns.Initialize(this.application);
			this.controlLog.Initialize(this.application);

			// Set the event handlers.
			this.application.Status.MessageChanged += this.OnStatusMessageChanged;

			// Call the tab changed event handler to initialize the application status.
			this.OnTabChanged(this, EventArgs.Empty);

			// Set the font.
			Window.SetFont(this);
		}

		#region Protected methods

		/// <summary>
		/// An event handler called when the form is being closed.
		/// </summary>
		/// <param name="e">The event arguments.</param>
		protected override void OnClosing(CancelEventArgs e)
		{
			// Check the status is locked.
			if (this.application.Status.IsLocked)
			{
				// Show a message.
				MessageBox.Show(
					this,
					"The Internet Tracerooute is running one or more background operations. You must stop them before closing the program.",
					"Internet Analytics Background",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning);
				// Cancel the closing request.
				e.Cancel = true;
				// Return.
				return;
			}
			// Call the base class event handler.
			base.OnClosing(e);
		}

		#endregion

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
					if (e.Message.Value.Type != this.application.Status.Status)
					{
						// Update the status.
						switch (e.Message.Value.Type)
						{
							case ApplicationStatus.StatusType.Ready:
								this.statusStrip.BackColor = this.themeSettings.ColorTable.StatusStripReadyBackground;
								this.statusLabelLeft.ForeColor = this.themeSettings.ColorTable.StatusStripReadyText;
								this.statusLabelRight.ForeColor = this.themeSettings.ColorTable.StatusStripReadyText;
								this.statusLabelRun.ForeColor = this.themeSettings.ColorTable.StatusStripReadyText;
								break;
							case ApplicationStatus.StatusType.Normal:
								this.statusStrip.BackColor = this.themeSettings.ColorTable.StatusStripNormalBackground;
								this.statusLabelLeft.ForeColor = this.themeSettings.ColorTable.StatusStripNormalText;
								this.statusLabelRight.ForeColor = this.themeSettings.ColorTable.StatusStripNormalText;
								this.statusLabelRun.ForeColor = this.themeSettings.ColorTable.StatusStripNormalText;
								break;
							case ApplicationStatus.StatusType.Busy:
								this.statusStrip.BackColor = this.themeSettings.ColorTable.StatusStripBusyBackground;
								this.statusLabelLeft.ForeColor = this.themeSettings.ColorTable.StatusStripBusyText;
								this.statusLabelRight.ForeColor = this.themeSettings.ColorTable.StatusStripBusyText;
								this.statusLabelRun.ForeColor = this.themeSettings.ColorTable.StatusStripBusyText;
								break;
						}
						// Set the new status.
						this.application.Status.Status = e.Message.Value.Type;
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
					this.statusLabelRun.ForeColor = this.themeSettings.ColorTable.StatusStripReadyText;
					this.statusLabelLeft.Image = Resources.Information_16;
					this.statusLabelLeft.Text = "Ready.";
					this.statusLabelRight.Image = null;
					this.statusLabelRight.Text = null;
					this.application.Status.Status = ApplicationStatus.StatusType.Ready;
				}
			});
		}

		/// <summary>
		/// An event handler called when the status lock has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnStatusLockChanged(object sender, EventArgs e)
		{
			this.Invoke(() =>
			{
				// Get the number of locks.
				int count = this.application.Status.LockCount;
				// Update the lock information.
				if (count > 0)
				{
					this.statusLabelRun.Text = "{0} background task{1}".FormatWith(count, count.PluralSuffix());
					this.statusLabelRun.Image = Resources.RunConcurrentStart_16;
				}
				else
				{
					this.statusLabelRun.Text = "No background tasks";
					this.statusLabelRun.Image = Resources.RunConcurrentStop_16;
				}
			});
		}

		/// <summary>
		/// An event handler called when the user selects the exit menu item.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnExit(object sender, EventArgs e)
		{
			// Close the main window.
			this.Close();
		}

		/// <summary>
		/// An event handler called when the selected tab has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnTabChanged(object sender, EventArgs e)
		{
			this.application.Status.Activate(this.tabControl.TabPages[this.tabControl.SelectedIndex].Controls.Count > 0 ? this.tabControl.TabPages[this.tabControl.SelectedIndex].Controls[0] : this);
		}

		/// <summary>
		/// An event handler called when the user selects the About menu.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnAbout(object sender, EventArgs e)
		{
			this.formAbout.ShowDialog(this);
		}

		#endregion
	}
}
