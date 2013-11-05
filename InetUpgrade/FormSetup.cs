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
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using DotNetApi;
using DotNetApi.Windows;
using DotNetApi.Windows.Forms;
using InetUpgrade.Actions;

namespace InetUpgrade
{
	/// <summary>
	/// A form used to upgrade the registry data.
	/// </summary>
	public partial class FormSetup : ThreadSafeForm
	{
		private readonly List<UpgradeAction> actions;
		private bool canClose = false;

		/// <summary>
		/// Creates a new form instance.
		/// </summary>
		public FormSetup(List<UpgradeAction> actions)
		{
			// Validate the arguments.
			if (null == actions) throw new ArgumentNullException("actions");
			
			// Initialize the component.
			this.InitializeComponent();

			// Set the action.
			this.actions = actions;
			foreach (UpgradeAction action in this.actions)
			{
				action.Progress += this.OnActionProgress;
			}
			
			// Set the window font.
			Window.SetFont(this);
		}

		// Public properties.

		/// <summary>
		/// Gets or sets whether the window can close.
		/// </summary>
		public bool CanClose
		{
			get { return this.canClose; }
			set { this.canClose = value; }
		}

		// Protected methods.

		/// <summary>
		/// An event handler called when the form is loaded.
		/// </summary>
		/// <param name="e">The event arguments.</param>
		protected override void OnLoad(EventArgs e)
		{
			// Call the base class method.
			base.OnLoad(e);
			// Execute the upgrade on the thread pool.
			ThreadPool.QueueUserWorkItem((object state) =>
				{
					foreach (UpgradeAction action in this.actions)
					{
						try
						{
							// Execute the upgrade action.
							action.Execute();
						}
						catch (Exception exception)
						{
							// If an exception occurrs, show the error.
							this.Invoke(() =>
								{
									this.labelInfo.Text = "Upgrade action failed. ".FormatWith(exception.Message);
								});
						}
						// Wait for three seconds.
						Thread.Sleep(TimeSpan.FromSeconds(2.0));
					}
					// Close the form.
					this.Invoke(() =>
						{
							// Set the close flag.
							this.canClose = true;
							// Close the form.
							this.Close();
						});
				});
		}

		/// <summary>
		/// An event handler called when the form is closing.
		/// </summary>
		/// <param name="e">The event arguments.</param>
		protected override void OnClosing(CancelEventArgs e)
		{
			// Call the base class method.
			base.OnClosing(e);
			// If the form can close.
			if (this.canClose)
			{
				// Remove the action event handler.
				foreach (UpgradeAction action in this.actions)
				{
					action.Progress -= this.OnActionProgress;
				}
			}
			else
			{
				// Cancel the closing event.
				e.Cancel = true;
			}
		}

		// Private methods.

		/// <summary>
		/// An event handler called when the action progersses.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The event arguments.</param>
		private void OnActionProgress(object sender, UpgradeActionEventArgs e)
		{
			// Set the progress message on the UI thread.
			this.Invoke(() =>
				{
					this.labelInfo.Text = e.Message;
				});
		}
	}
}
