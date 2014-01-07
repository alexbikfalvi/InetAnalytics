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
using DotNetApi;
using DotNetApi.Windows.Controls;
using InetAnalytics;
using InetApi.Net.Core;
using InetCrawler;
using InetCrawler.Log;
using InetCrawler.Tools;
using InetCrawler.Status;
using InetTools.Tools.Net;

namespace InetTools.Controls.Net
{
	/// <summary>
	/// A class representing the control for the traceroute analytics tool.
	/// </summary>
	public partial class ControlTraceroute : NotificationControl
	{
		private readonly TracerouteConfig config;

		private readonly CrawlerStatusHandler status = null;

		private readonly TracerouteSettings settings;
		private readonly Traceroute traceroute;

		private bool configurationChanged = false;

		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		/// <param name="config">The tool configuration.</param>
		public ControlTraceroute(TracerouteConfig config)
		{
			// Initialize the component.
			this.InitializeComponent();
			
			// Set the configuration.
			this.config = config;

			// Create the traceroute settings.
			this.settings = new TracerouteSettings();
			// Create the traceroute instance.
			this.traceroute = new Traceroute(this.settings);

			// Load the configuration.
			this.OnLoadConfiguration();

			// Set the status.
			this.status = this.config.Api.Status.GetHandler(this);
			this.status.Send(CrawlerStatus.StatusType.Normal, "Ready.", Resources.Information_16);
		}

		// Private methods.

		/// <summary>
		/// Loads the tool configuration.
		/// </summary>
		private void OnLoadConfiguration()
		{
			// Load the configuration.
			this.textBoxDestination.Text = this.config.Destination;



			this.checkBoxAutomaticNameResolution.Checked = this.config.AutomaticNameResolution;

			// Disable the save and undo buttons.
			this.buttonSave.Enabled = false;
			this.buttonUndo.Enabled = false;
		}

		/// <summary>
		/// Saves the tool configuration.
		/// </summary>
		private void OnSaveConfiguration()
		{
			// Save the configuration.
			this.config.Destination = this.textBoxDestination.Text;

			// Disable the save and undo buttons.
			this.buttonSave.Enabled = false;
			this.buttonUndo.Enabled = false;
		}

		/// <summary>
		/// Sets the controls, except the request control buttons, to the disabled state.
		/// </summary>
		private void OnDisableControls()
		{
			// Save the enabled state.
			this.configurationChanged = this.buttonSave.Enabled;

			// Disable the controls.
			this.textBoxDestination.Enabled = false;

			this.buttonSave.Enabled = false;
			this.buttonUndo.Enabled = false;
		}

		/// <summary>
		/// Sets the controls, except the request control buttons, to the enabled state.
		/// </summary>
		private void OnEnableControls()
		{
			// Enable the controls.
			this.textBoxDestination.Enabled = true;

			this.buttonSave.Enabled = this.configurationChanged;
			this.buttonUndo.Enabled = this.configurationChanged;
		}

		/// <summary>
		/// An event handler called when the input has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnInputChanged(object sender, EventArgs e)
		{
			// Set the controls enabled state.
			this.buttonStart.Enabled = !string.IsNullOrWhiteSpace(this.textBoxDestination.Text);
			this.labelMaximumFailedHops.Enabled = this.checkBoxStopOnFail.Checked;
			this.numericUpDownMaximumFailedHops.Enabled = this.checkBoxStopOnFail.Checked;

			// Enable the save and undo buttons.
			this.buttonSave.Enabled = true;
			this.buttonUndo.Enabled = true;
		}

		/// <summary>
		/// An event handler called when the user clicks on the start button.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnStart(object sender, EventArgs e)
		{
			// Change the controls state.
			this.OnDisableControls();
			// Change the buttons state.
			this.buttonStart.Enabled = false;
			this.buttonStop.Enabled = true;

			// Clear the response headers.
			this.listViewRoute.Items.Clear();

			// Get the traceroute destination.
			string destination = this.textBoxDestination.Text;

			// Set the status.
			this.status.Send(CrawlerStatus.StatusType.Busy, "Running Internet traceroute to \'{0}\'...".FormatWith(destination), Resources.Busy_16);
			// Show a message.
			this.ShowMessage(
				Resources.GlobeClock_48,
				"Internet Traceroute",
				"Running Internet traceroute to \'{0}\' with a maximum of {1} hop{2} and up to {3} attempt{4} per hop.".FormatWith(destination, this.settings.MaximumHops, this.settings.MaximumHops.PluralSuffix(), this.settings.MaximumAttempts, this.settings.MaximumAttempts.PluralSuffix())
				);
			// Log
			this.log.Add(this.config.Api.Log(
				LogEventLevel.Verbose,
				LogEventType.Information,
				"Running Internet traceroute to \'{0}\' with a maximum of {1} hop(s) and up to {2} attempt(s) per hop.",
				new object[] { destination,  this.settings.MaximumHops, this.settings.MaximumAttempts }));

			try
			{


				// Begin a traceroute to the specified destination.
			}
			catch (Exception exception)
			{
				// Update the status label.
				this.status.Send(CrawlerStatus.StatusType.Normal, "Running Internet traceroute to \'{0}\' failed.".FormatWith(destination), Resources.Error_16);
				// Show a message.
				this.ShowMessage(
					Resources.GlobeError_48,
					"Internet Traceroute",
					"Running Internet traceroute to \'{0}\' failed. {1}".FormatWith(destination, exception.Message),
					false,
					(int)CrawlerConfig.Static.ConsoleMessageCloseDelay.TotalMilliseconds);
				// Log the result.
				this.log.Add(this.config.Api.Log(
					LogEventLevel.Important,
					LogEventType.Error,
					"Running Internet traceroute to \'{0}\' failed. {1}",
					new object[] { destination, exception.Message },
					exception));
				// Change the controls state.
				this.OnEnableControls();
				// Change the buttons state.
				this.buttonStart.Enabled = true;
				this.buttonStop.Enabled = false;
			}
		}

		/// <summary>
		/// An event handler called when the user clicks on the stop button.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnStop(object sender, EventArgs e)
		{
			// Disable the stop button.
			this.buttonStop.Enabled = false;
		}

		/// <summary>
		/// An event handler called when the user clicks on the save button.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSave(object sender, EventArgs e)
		{
			// Save the configuration.
			this.OnSaveConfiguration();
		}

		/// <summary>
		/// An event handler called when the user clicks on the undo button.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnUndo(object sender, EventArgs e)
		{
			// Load the configuration.
			this.OnLoadConfiguration();
		}
	}
}
