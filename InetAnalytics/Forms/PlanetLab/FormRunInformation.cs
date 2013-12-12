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
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using PlanetLab;
using PlanetLab.Api;
using DotNetApi;
using DotNetApi.Windows;
using DotNetApi.Windows.Forms;

namespace InetAnalytics.Forms.PlanetLab
{
	/// <summary>
	/// A form dialog that collects information on a PlanetLab run session.
	/// </summary>
	public partial class FormRunInformation : ThreadSafeForm
	{
		/// <summary>
		/// Creates a new form instance.
		/// </summary>
		public FormRunInformation()
		{
			// Initialize the component.
			this.InitializeComponent();

			// Set the font.
			Window.SetFont(this);
		}

		// Public properties.

		/// <summary>
		/// Gets the session identifier.
		/// </summary>
		public Guid Id
		{
			get
			{
				Guid id;
				Guid.TryParse(this.textBoxId.Text, out id);
				return id;
			}
		}
		/// <summary>
		/// Gets the session author.
		/// </summary>
		public string Author
		{
			get { return this.textBoxAuthor.Text; }
		}
		/// <summary>
		/// Gets the session description.
		/// </summary>
		public string Description
		{
			get { return this.textBoxDescription.Text; }
		}

		// Public methods.

		/// <summary>
		/// Shows the form as a dialog to select the author and description of a PlanetLab experiment.
		/// </summary>
		/// <param name="owner">The owner window.</param>
		/// <returns>The dialog result.</returns>
		public new DialogResult ShowDialog(IWin32Window owner)
		{
			// Clear the dialog.
			this.buttonContinue.Enabled = false;
			this.textBoxId.Text = Guid.NewGuid().ToString();
			this.textBoxAuthor.Text = Environment.UserName;
			this.textBoxDescription.Clear();

			// Call the input changed event handler.
			this.OnInputChanged(this, EventArgs.Empty);

			// Call the base class method.
			return base.ShowDialog(owner);
		}

		// Private methods.

		/// <summary>
		/// Shows the form.
		/// </summary>
		private new void Show()
		{
			base.Show();
		}

		/// <summary>
		/// Shows the form.
		/// </summary>
		/// <param name="owner">The owner.</param>
		private new void Show(IWin32Window owner)
		{
			base.Show(owner);
		}

		/// <summary>
		/// Shows the dialog.
		/// </summary>
		/// <returns>The dialog result.</returns>
		private new DialogResult ShowDialog()
		{
			return base.ShowDialog();
		}

		/// <summary>
		/// An event handler called when the input has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnInputChanged(object sender, EventArgs e)
		{
			Guid id;
			// Update the enabled state of the continue button.
			this.buttonContinue.Enabled =
				Guid.TryParse(this.textBoxId.Text, out id) &&
				(!string.IsNullOrWhiteSpace(this.textBoxAuthor.Text)) &&
				(!string.IsNullOrWhiteSpace(this.textBoxDescription.Text));
		}
	}
}
