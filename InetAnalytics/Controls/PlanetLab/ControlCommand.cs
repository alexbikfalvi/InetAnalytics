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
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DotNetApi;
using DotNetApi.Windows.Controls;
using DotNetApi.Windows.Themes.Code;
using InetAnalytics.Forms.PlanetLab;
using InetCrawler.PlanetLab;

namespace InetAnalytics.Controls.PlanetLab
{
	/// <summary>
	/// A class representing the control to configure a PlanetLab comamnd.
	/// </summary>
	public partial class ControlCommand : ThreadSafeControl
	{
		private PlCommand command = null;

		private bool hideSave = false;
		private bool isValid = false;

		private readonly FormImportParameters formImportParameters = new FormImportParameters();

		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlCommand()
		{
			// Initialize the components
			this.InitializeComponent();

			// Set the status information.
			this.OnSetStatus("Ready.", Resources.Warning_16);

			// Create the code color collection.
			LinuxCodeColorCollection colorCollection = new LinuxCodeColorCollection();
			colorCollection.Add(new CodeColorCollection.Token { Regex = PlCommand.regexParamBad , ForegroundColor = Color.White, BackgroundColor = Color.Red, Enforce = true });
			colorCollection.Add(new CodeColorCollection.Token { Regex = PlCommand.regexParamGood, ForegroundColor = Color.White, BackgroundColor = Color.Green, Enforce = true });

			// Set the code text box color collection.
			this.textBox.ColorCollection = colorCollection;

			// Disable the control.
			this.Disable();
		}

		// Public events.

		/// <summary>
		/// An event raised when the command input has changed. The event is raised when the user input changes and not when the command object has changed.
		/// The command object only changes when the command is saved.
		/// </summary>
		public event EventHandler InputChanged;
		/// <summary>
		/// An event raised when the command has been saved, either through the Save button or by calling the Save method.
		/// </summary>
		public event EventHandler CommandSaved;

		// Public properties.

		/// <summary>
		/// Gets or sets the current command.
		/// </summary>
		public PlCommand Command
		{
			get { return this.command; }
			set { this.OnSetCommand(value); }
		}
		/// <summary>
		/// Gets or sets whether the command hides the save button.
		/// </summary>
		public bool HideSave
		{
			get { return this.hideSave; }
			set { this.OnSetHideSave(value); }
		}
		/// <summary>
		/// Gets whether the command format is valid and has at least one parameter set.
		/// </summary>
		public bool IsValid
		{
			get { return this.isValid && ((this.dataParameters.Columns.Count > 0) ? this.dataParameters.Rows.Count > 0 : true); }
		}
		/// <summary>
		/// Gets whether the current command has changed.
		/// </summary>
		public bool HasChanged
		{
			get { return this.buttonSave.Enabled; }
		}

		// Public methods.

		/// <summary>
		/// Saves the current command.
		/// </summary>
		public void Save()
		{
			// If the command is null, do nothing.
			if (this.command == null) return;

			// If the command is not valid, do nothing.
			if (!this.IsValid)
			{
				MessageBox.Show(this, "The command is not valid or it has some parameters missing.", "Cannot Save Command", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			// Set the command.
			this.command.Command = this.textBox.Text;

			// Set the command parameters.
			this.command.ResizeParameters(this.dataParameters.Columns.Count, this.dataParameters.Rows.Count);

			// Copy the command parameters.
			for (int column = 0; column < this.dataParameters.Columns.Count; column++)
			{
				for (int row = 0; row < this.dataParameters.Rows.Count; row++)
				{
					this.command[column, row] = this.dataParameters[column, row].Value;
				}
			}

			// Disable the save and undo buttons.
			this.buttonSave.Enabled = false;
			this.buttonUndo.Enabled = false;

			// Raise the command saved event.
			if (null != this.CommandSaved) this.CommandSaved(this, EventArgs.Empty);
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
			this.buttonAddParameters.Enabled = false;
			this.buttonRemoveParameter.Enabled = false;

			// Clear the command parameters.
			this.dataParameters.Rows.Clear();
			this.dataParameters.Columns.Clear();

			// If the command is not null.
			if (null != this.command)
			{
				// Enable the control.
				this.Enable();

				// Update the command information.
				this.textBox.Text = this.command.Command;

				// Refresh the text box.
				this.textBox.Refresh();

				// Call the command changed.
				this.OnCommandChanged(this, EventArgs.Empty);

				// Update the number of parameter sets.
				this.dataParameters.Rows.Clear();
				// If the command has a positive number of parameters sets.
				if (this.command.SetsCount > 0)
				{
					this.dataParameters.Rows.Add(this.command.SetsCount);
				}

				// Load the command parameters.
				for (int column = 0; column < this.dataParameters.Columns.Count; column++)
				{
					for (int row = 0; row < this.dataParameters.Rows.Count; row++)
					{
						this.dataParameters[column, row].Value = this.command[column, row];
					}
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

			// Disable the save and undo buttons.
			this.buttonSave.Enabled = false;
			this.buttonUndo.Enabled = false;
		}

		/// <summary>
		/// Sets the auto-save value.
		/// </summary>
		/// <param name="value">The value.</param>
		private void OnSetHideSave(bool value)
		{
			// If the value has not changed, do nothing.
			if (value == this.hideSave) return;

			// Set the value.
			this.hideSave = value;

			// If hide-save is enabled.
			this.buttonSave.Visible = !this.hideSave;
		}

		/// <summary>
		/// An event handler called when saving the command changes.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSave(object sender, EventArgs e)
		{
			// Saves the command based on the current input.
			this.Save();
		}

		/// <summary>
		/// An event handler called when undoing the command changes.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnUndo(object sender, EventArgs e)
		{
			// Reset the command.
			this.OnSetCommand(this.command);
		}

		/// <summary>
		/// An event handler called when adding a set of command parameters.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnAddParameter(object sender, EventArgs e)
		{
			// Adds a new parameters set.
			this.dataParameters.Rows.Add();

			// Call the parameter changed event handler.
			this.OnParameterChanged(sender, e);
		}

		/// <summary>
		/// An event handler called when removing a set of command prameters.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnRemoveParameters(object sender, EventArgs e)
		{
			// If there are no selected cells, do nothing.
			if (this.dataParameters.SelectedCells.Count == 0) return;

			// Else, remove the selected row.
			this.dataParameters.Rows.RemoveAt(this.dataParameters.SelectedCells[0].RowIndex);

			// Call the parameter changed event handler.
			this.OnParameterChanged(sender, e);
		}

		/// <summary>
		/// Sets the status.
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
		/// Sets the info.
		/// </summary>
		/// <param name="infoText">The info text.</param>
		/// <param name="infoImage">The info image.</param>
		private void OnSetInfo(string infoText, Image infoImage = null)
		{
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
			int parametersCount = 0;
			this.isValid = false;

			// If the command is empty.
			if (string.IsNullOrWhiteSpace(this.textBox.Text))
			{
				// Set the status.
				this.OnSetStatus("The command is empty. Type the command and use numbers between braces ({0}, {1}, ...) to add parameters.", Resources.Information_16);
			}
			else
			{
				// Find the command parameters within the command text.
				MatchCollection matchesGood = Regex.Matches(this.textBox.Text, PlCommand.regexParamGood, RegexOptions.CultureInvariant);
				MatchCollection matchesBad = Regex.Matches(this.textBox.Text, PlCommand.regexParamBad, RegexOptions.CultureInvariant);

				// If there are bad macthes.
				if (matchesBad.Count > matchesGood.Count)
				{
					// Set the status.
					this.OnSetStatus("The command format is incorrect.", Resources.Error_16);
				}
				else
				{
					// For all the good matches.
					foreach (Match match in matchesGood)
					{
						// Compute the parameter index.
						int index;
						if (int.TryParse(match.Value.Substring(1, match.Value.Length - 2), out index) && (index + 1 > parametersCount))
						{
							parametersCount = index + 1;
						}
					}

					// Set the status.
					this.OnSetStatus("The command has {0} parameters.".FormatWith(parametersCount), Resources.Success_16);
					// Set the command as valid.
					this.isValid = true;
				}
			}

			// If the number of parameters has changed.
			if (parametersCount != this.dataParameters.Columns.Count)
			{
				// Clear the parameters.
				this.dataParameters.Rows.Clear();
				this.dataParameters.Columns.Clear();

				// Add columns for the specified parameters.
				for (int index = 0; index < parametersCount; index++)
				{
					this.dataParameters.Columns.Add("Column{0}".FormatWith(index), "{{{0}}}".FormatWith(index));
				}
			}

			// Enable the add parameters buttons.
			this.buttonAddParameters.Enabled = this.dataParameters.Columns.Count > 0;
			this.buttonImportParameters.Enabled = this.dataParameters.Columns.Count > 0;

			// Call the parameter selection changed.
			this.OnParameterChanged(sender, e);
		}

		/// <summary>
		/// An event handler called when a new parameters set was added.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnParameterChanged(object sender, EventArgs e)
		{
			// Enable the clear parameters button.
			this.buttonClearParameters.Enabled = this.dataParameters.Rows.Count > 0;
			this.buttonRemoveParameter.Enabled = this.dataParameters.SelectedCells.Count > 0;

			// Set the parameters information.
			this.OnSetInfo(this.dataParameters.Columns.Count > 0 ? "The command has {0} parameter sets.".FormatWith(this.dataParameters.Rows.Count) : string.Empty);

			// Enable the save and undo buttons.
			this.buttonSave.Enabled = this.IsValid;
			this.buttonUndo.Enabled = true;

			// Raise the command changed event.
			if (null != this.InputChanged) this.InputChanged(this, EventArgs.Empty);
		}

		/// <summary>
		/// An event handler called when importing parameters from a file.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnImportParameters(object sender, EventArgs e)
		{
			// Show the open file dialog.
			if (this.openFileDialog.ShowDialog(this) == DialogResult.OK)
			{
				// Check the selected filter.
				switch(this.openFileDialog.FilterIndex)
				{
					case 1:
						this.OnImportParametersText(this.openFileDialog.FileName);
						break;
				}
			}
		}

		/// <summary>
		/// Imports the command parameters from the specified text file.
		/// </summary>
		/// <param name="fileName">The text file.</param>
		private void OnImportParametersText(string fileName)
		{
			try
			{
				List<string> values = new List<string>();
				// Open the specified file.
				using (TextReader reader = File.OpenText(fileName))
				{
					// Read until the end of file.
					while (reader.Peek() >= 0)
					{
						// Read all data from the file.
						values.Add(reader.ReadLine());
					}
				}
				// Open the import parameters dialog.
				if (this.formImportParameters.ShowDialog(this, values.Count, this.dataParameters.Columns.Count) == DialogResult.OK)
				{
					// If the number of data values is greater than the number of parameter lines.
					if (values.Count > this.dataParameters.Rows.Count)
					{
						// Add the different in the number of rows.
						this.dataParameters.Rows.Add(values.Count - this.dataParameters.Rows.Count);
					}
					// For each selected parameter.
					foreach (int parameter in this.formImportParameters.Selection)
					{
						for (int index = 0; index < values.Count; index++)
						{
							this.dataParameters[parameter, index].Value = values[index];
						}
					}
				}
			}
			catch (Exception exception)
			{
				// Show an error message.
				MessageBox.Show(this, "An error occurred while importing the parameters from the file. {0}".FormatWith(exception), "Import Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		/// <summary>
		/// An event handler called when clearing the parameters.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnClearParameters(object sender, EventArgs e)
		{
			// Clear all rows.
			this.dataParameters.Rows.Clear();
			// Call the selection changed handler.
			this.OnParameterChanged(sender, e);
		}
	}
}
