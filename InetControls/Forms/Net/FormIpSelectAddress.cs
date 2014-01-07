/* 
 * Copyright (C) 2013-2014 Alex Bikfalvi
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
using System.Net;
using System.Windows.Forms;
using DotNetApi.Windows;
using DotNetApi.Windows.Forms;

namespace InetAnalytics.Forms.Net
{
	/// <summary>
	/// A form dialog that allows the selection of one IP address.
	/// </summary>
	public partial class FormIpSelectAddress : ThreadSafeForm
	{
		/// <summary>
		/// Creates a new form instance.
		/// </summary>
		public FormIpSelectAddress()
		{
			// Initialize the component.
			this.InitializeComponent();

			// Set the font.
			Window.SetFont(this);
		}

		// Public properties.

		/// <summary>
		/// Gets the selected IP address.
		/// </summary>
		public IPAddress Address { get; private set; }

		// Public methods.

		/// <summary>
		/// Shows the form as a dialog to allow the selection of one IP address.
		/// </summary>
		/// <param name="owner">The owner window.</param>
		/// <param name="addresses">The map control to export.</param>
		/// <returns>The dialog result.</returns>
		public DialogResult ShowDialog(IWin32Window owner, IPAddress[] addresses)
		{
			// Reset the control.
			this.listViewAddress.Items.Clear();

			// Set the IP addresses.
			foreach (IPAddress address in addresses)
			{
				ListViewItem item = new ListViewItem(new string[] { address.ToString(), address.AddressFamily.ToString() });
				item.Tag = address;
				this.listViewAddress.Items.Add(item);
			}

			// Call the selection changed event handler.
			this.OnSelectionChanged(this, EventArgs.Empty);

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
		/// Shows the dialog.
		/// </summary>
		/// <param name="owner">The owner.</param>
		/// <returns>The dialog result.</returns>
		private new DialogResult ShowDialog(IWin32Window owner)
		{
			return base.ShowDialog(owner);
		}

		/// <summary>
		/// An event handler called when the address selection has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSelectionChanged(object sender, EventArgs e)
		{
			if (this.listViewAddress.SelectedItems.Count > 0)
			{
				this.buttonSelect.Enabled = true;
				this.Address = this.listViewAddress.SelectedItems[0].Tag as IPAddress;
			}
			else
			{
				this.buttonSelect.Enabled = false;
				this.Address = null;
			}
		}
	}
}
