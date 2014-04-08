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
using System.Windows.Forms;
using DotNetApi;

namespace InetCommon.Controls
{
	/// <summary>
	/// A user control representing a command line interface console.
	/// </summary>
	public sealed partial class ControlConsole : UserControl
	{
		private bool command = false;

		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlConsole()
		{
			// Initialize the component.
			this.InitializeComponent();
		}

		// Public properties.

		/// <summary>
		/// Gets the current command text.
		/// </summary>
		public string Command { get { return this.textBox.Text; } }
		/// <summary>
		/// Gets or sets the button image.
		/// </summary>
		public Image ButtonImage
		{
			get { return this.button.Image; }
			set { this.button.Image = value; }
		}

		// Public events.

		/// <summary>
		/// An event called when presses the Enter key after typing a command or clicks the execute button.
		/// </summary>
		public event EventHandler Execute;
		/// <summary>
		/// An event called when the user cancels the current command.
		/// </summary>
		public event EventHandler Cancel;

		// Public methods.

		/// <summary>
		/// Clears the current console output.
		/// </summary>
		public void Clear()
		{
			this.textArea.Clear();
		}

		/// <summary>
		/// Copies the current console text to clipboard.
		/// </summary>
		public void Copy()
		{
			Clipboard.SetText(this.textArea.Text);
		}

		/// <summary>
		/// Appends the specified text to the console text area using the default color.
		/// </summary>
		/// <param name="text">The text.</param>
		public void AppendText(string text)
		{
			this.AppendText(text, this.textArea.ForeColor);
		}

		/// <summary>
		/// Appends the specified text to the console text area using the given color.
		/// </summary>
		/// <param name="text">The text.</param>
		/// <param name="color">The color.</param>
		public void AppendText(string text, Color color)
		{
			// Save the start position.
			int start = this.textArea.TextLength;
			// Append the text.
			this.textArea.AppendText(text);
			// Select the text.
			this.textArea.Select(start, text.Length);
			// Set the color.
			this.textArea.SelectionColor = color;
			// Clear the selection.
			this.textArea.Select(this.textArea.TextLength, 0);
		}

		/// <summary>
		/// Appends the specified formatted text to the console text area using the default color.
		/// </summary>
		/// <param name="format">The text format.</param>
		/// <param name="args">The arguments.</param>
		public void AppendText(string format, params object[] args)
		{
			this.AppendText(format.FormatWith(args), this.textArea.ForeColor);
		}

		/// <summary>
		/// Enables the console controls.
		/// </summary>
		/// <param name="prompt">The console prompt.</param>
		public void Enable(string prompt)
		{
			// Set the prompt.
			this.label.Text = prompt;
			this.textBox.Enabled = true;
			this.textBox.Select();
			this.command = false;
		}

		/// <summary>
		/// Disables the console controls.
		/// </summary>
		public void Disable()
		{
			this.textArea.Clear();
			this.textBox.Clear();
			this.textBox.Enabled = false;
			this.label.Text = ">";
			this.command = false;
		}

		/// <summary>
		/// Sets the console status when beginning a command.
		/// </summary>
		/// <param name="command">The command.</param>
		public void BeginCommand(string command)
		{
			// Set the begin command to true.
			this.command = true;
			// Change the execute button image.
			this.button.Image = Resources.PlayStop_16;
			this.button.Enabled = true;
			// Delete and disable the command text box.
			this.textBox.Clear();
			this.textBox.Enabled = false;
			this.textArea.Select();
			// Add the command to the text area.
			this.AppendText("{0} {1}{2}", this.label.Text, command, Environment.NewLine);
		}

		/// <summary>
		/// Sets the console status when ending a command.
		/// </summary>
		public void EndCommand()
		{
			this.button.Image = Resources.PlayStart_16;
			this.button.Enabled = false;
			this.textBox.Enabled = true;
			this.textBox.Select();
			this.command = false;
		}

		// Private methods.

		/// <summary>
		/// An event handler called when the user clicks the execute button.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnClick(object sender, EventArgs e)
		{
			// Disable the button.
			this.button.Enabled = false;
			// If the console processes a command.
			if (this.command)
			{
				// Raise the cancel event.
				if (null != this.Cancel) this.Cancel(sender, e);
			}
			else
			{
				// Raise the execute event.
				if (null != this.Execute) this.Execute(sender, e);
			}
		}

		/// <summary>
		/// An event handler called when the typed command has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnCommandChanged(object sender, EventArgs e)
		{
			// If there is no executing command.
			if (!this.command)
			{
				// Update the button enabled state.
				this.button.Enabled = !string.IsNullOrWhiteSpace(this.textBox.Text);
			}
		}

		/// <summary>
		/// An event handler called when the user enters an SSH command.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnCommandKeyDown(object sender, KeyEventArgs e)
		{
			// Process the command only when the enter key is pressed.
			if ((e.KeyCode == Keys.Enter) && (!string.IsNullOrWhiteSpace(this.textBox.Text)) && (!this.command))
			{
				// Execute the command.
				if (null != this.Execute) this.Execute(sender, e);
			}
		}

		/// <summary>
		/// An event handler called when the users presses a key in the console.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnConsoleKeyDown(object sender, KeyEventArgs e)
		{
			// If the Control+C keys were pressed.
			if (e.Control && (e.KeyCode == Keys.C) && this.command)
			{
				// Disable the button.
				this.button.Enabled = false;
				// Raise the cancel event.
				if (null != this.Cancel) this.Cancel(sender, e);
			}
		}

		/// <summary>
		/// An event handler called when the user focuses on the console text area.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnConsoleEnter(object sender, EventArgs e)
		{
			// If the console is not during a command.
			if (!this.command)
			{
				// Select the text box.
				this.textBox.Select();
			}
		}
	}
}
