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
using System.Windows.Forms;
using InetCrawler.PlanetLab;

namespace InetAnalytics.Controls.PlanetLab.Commands
{
	/// <summary>
	/// A control displaying the results for a PlanetLab command.
	/// </summary>
	public partial class ControlCommandResult : UserControl
	{
		private PlManagerHistorySubcommand result = null;

		/// <summary>
		/// Creates a new result instance.
		/// </summary>
		public ControlCommandResult()
		{
			// Initialize the components.
			this.InitializeComponent();
			// Clear the control.
			this.Clear();
		}

		// Public properties.

		/// <summary>
		/// Gets or sets the result for a PlanetLab subcommand.
		/// </summary>
		public PlManagerHistorySubcommand Result
		{
			get { return this.result; }
			set { this.OnSetResult(value); }
		}

		// Public methods.

		/// <summary>
		/// Clears the result information.
		/// </summary>
		public void Clear()
		{
			this.Result = null;
		}

		// Private methods.

		/// <summary>
		/// Sets the current result.
		/// </summary>
		/// <param name="result">The result.</param>
		private void OnSetResult(PlManagerHistorySubcommand result)
		{
			// Else, if the result is not null.
			if (null != result)
			{
				this.pictureBox.Image = result.Exception == null ? result.ExitStatus == 0 ?
					Resources.ScriptSuccess_48 : Resources.ScriptWarning_48 : Resources.ScriptError_48;
				this.textBoxCommand.Text = result.Command;
				this.textBoxDuration.Text = result.Duration.ToString();
				this.textBoxExitStatus.Text = result.ExitStatus.ToString();
				this.textBoxException.Text = result.Exception != null ? result.Exception : "(none)";
				this.textBoxError.Text = result.Error;
				this.textBoxResult.Text = result.Result;
				this.textBoxRetries.Text = result.Retries.ToString();
				this.textBoxTimeout.Text = result.Timeout.Ticks >= 0 ? result.Timeout.ToString() : "(infinite)";
			}
			else
			{
				this.pictureBox.Image = Resources.Question_48;
				this.textBoxCommand.Clear();
				this.textBoxDuration.Clear();
				this.textBoxExitStatus.Clear();
				this.textBoxException.Clear();
				this.textBoxError.Clear();
				this.textBoxResult.Clear();
				this.textBoxRetries.Clear();
				this.textBoxTimeout.Clear();
			}
		}
	}
}
