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
using System.Drawing;
using System.Text.RegularExpressions;
using DotNetApi;
using DotNetApi.Windows.Controls;
using InetCrawler.PlanetLab;

namespace InetAnalytics.Controls.PlanetLab
{
	/// <summary>
	/// A class representing the control to configure a PlanetLab comamnd.
	/// </summary>
	public partial class ControlCommand : ThreadSafeControl
	{
		private PlCommand command = null;

		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlCommand()
		{
			// Initialize the components
			this.InitializeComponent();

			// Set the status information.
			this.OnSetStatus("Ready.", Resources.Warning_16);

			// Disable the control.
			this.Disable();
		}

		// Public properties.

		/// <summary>
		/// Gets or sets the current command.
		/// </summary>
		public PlCommand Command
		{
			get { return this.command; }
			set { this.OnSetCommand(value); }
		}

		// Private methods.

		/// <summary>
		/// Enables the control.
		/// </summary>
		private void Enable()
		{
			this.toolStrip.Enabled = true;
			this.textBox.Enabled = true;
		}

		/// <summary>
		/// Disables the control.
		/// </summary>
		private void Disable()
		{
			this.toolStrip.Enabled = false;
			this.textBox.Enabled = false;
		}

		/// <summary>
		/// Sets the current PlanetLab command.
		/// </summary>
		/// <param name="command">The command,</param>
		private void OnSetCommand(PlCommand command)
		{
			// Set the command.
			this.command = command;

			// Disable the buttons.
			this.buttonSave.Enabled = false;
			this.buttonUndo.Enabled = false;
			this.buttonAddParameters.Enabled = false;
			this.buttonRemoveParameter.Enabled = false;

			// Clear the command parameters.
			this.dataParemeters.Rows.Clear();
			this.dataParemeters.Columns.Clear();

			// If the command is not null.
			if (null != this.command)
			{
				// Enable the control.
				this.Enable();

				// Enable the add parameters button.
				this.buttonAddParameters.Enabled = command.ParametersCount > 0;

				// Update the command information.
				this.textBox.Text = this.command.Command;

				// Update the command parameters.
				for (int index = 0; index < command.ParametersCount; index++)
				{
					this.dataParemeters.Columns.Add("Parameter{{{0}}}".FormatWith(index), "{{{0}}}".FormatWith(index));
				}

				// Set the status.
				if (string.IsNullOrWhiteSpace(this.command.Command))
				{
					this.OnSetStatus("The command is empty.", Resources.Warning_16);
				}
			}
			else
			{
				// Disable the control.
				this.Disable();

				// Clear the command text.
				this.textBox.Clear();

				// Set the status.
				this.OnSetStatus("No PlanetLab command selected.", Resources.Warning_16);
			}
		}

		/// <summary>
		/// An event handler called when saving the command changes.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSave(object sender, EventArgs e)
		{

		}

		/// <summary>
		/// An event handler called when undoing the command changes.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnUndo(object sender, EventArgs e)
		{

		}

		/// <summary>
		/// An event handler called when adding a set of command parameters.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnAddParameter(object sender, EventArgs e)
		{

		}

		/// <summary>
		/// An event handler called when removing a set of command prameters.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnRemoveParameters(object sender, EventArgs e)
		{

		}

		/// <summary>
		/// Sets the status information.
		/// </summary>
		/// <param name="statusText">The status text.</param>
		/// <param name="statusImage">The status image.</param>
		/// <param name="infoText">The info text.</param>
		/// <param name="infoImage">The info image.</param>
		private void OnSetStatus(string statusText, Image statusImage, string infoText = null, Image infoImage = null)
		{
			this.labelStatus.Text = statusText;
			this.labelStatus.Image = statusImage;
			this.labelInfo.Text = infoText;
			this.labelInfo.Image = infoImage;
		}

		/// <summary>
		/// An event handler called when the command text has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnCommandChanged(object sender, EventArgs e)
		{
			// Find the command parameters within the command text.
			MatchCollection matches = Regex.Matches(this.textBox.Text, "{[0-9]+}", RegexOptions.CultureInvariant);

			// For all command matches.
			foreach (Match match in matches)
			{
				// Set the command text color.
			}
		}
	}
}
