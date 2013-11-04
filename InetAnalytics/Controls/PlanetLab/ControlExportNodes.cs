/* 
 * Copyright (C) 2012-2013 Alex Bikfalvi
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
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DotNetApi;
using DotNetApi.Windows.Controls;
using PlanetLab.Api;
using PlanetLab.Database;

namespace InetAnalytics.Controls.PlanetLab
{
	/// <summary>
	/// A control used to export the PlanetLab nodes information.
	/// </summary>
	public partial class ControlExportNodes : ThreadSafeControl
	{
		private readonly object sync = new object();
		private bool saving = false;
		private bool cancel = false;

		/// <summary>
		/// Creates a new control instance.
		/// </summary>
		public ControlExportNodes()
		{
			// Initialize the component.
			this.InitializeComponent();
		}

		// Public events.

		/// <summary>
		/// An event raised when the user closes the dialog.
		/// </summary>
		public event EventHandler Closed;

		// Public properties.

		/// <summary>
		/// Gets the list of PlanetLab nodes.
		/// </summary>
		public PlDatabaseList<PlNode> Nodes { get; private set; }
		/// <summary>
		/// Gets the dialog result.
		/// </summary>
		public DialogResult Result { get; private set; }

		// Public methods.

		public void Initialize(PlDatabaseList<PlNode> nodes)
		{
			// Set the nodes.
			this.Nodes = nodes;

			// Reset the controls.
			this.progressBar.Minimum = 0;
			this.progressBar.Maximum = nodes.Count;
			this.progressBar.Value = 0;

			this.buttonClose.Enabled = true;

			this.labelProgress.Text = string.Empty;

			// Set the dialog result.
			this.Result = DialogResult.Cancel;

			// Save the list.
			this.OnSave();
		}

		// Private methods.

		/// <summary>
		/// An event handler called when the user clicks on the save button.
		/// </summary>
		private void OnSave()
		{
			// If the list of nodes is null, do nothing.
			if (null == this.Nodes) return;

			// If the dialog is already saving a file, do nothing.
			lock (this.sync) { if (this.saving) return; }

			// Show the save file dialog.
			if (this.saveFileDialog.ShowDialog(this) == DialogResult.OK)
			{
				// Get the file name.
				string fileName = this.saveFileDialog.FileName;

				// Save the nodes on the thread pool.
				ThreadPool.QueueUserWorkItem((object state) =>
					{
						// Change the saving state to true.
						lock (this.sync)
						{
							this.saving = true;
							this.cancel = false;
						}

						// Change the controls state.
						this.Invoke(() =>
							{
								this.buttonClose.Text = "&Cancel";
								this.labelProgress.Text = "Saving...";
							});

						int countTotal = 0;
						int countError = 0;

						try
						{
							// Create the CSV file.
							using (FileStream file = new FileStream(fileName, FileMode.Create))
							{
								// Create a stream text writer.
								using (StreamWriter writer = new StreamWriter(file, Encoding.UTF8))
								{
									// Lock the database list.
									this.Nodes.Lock();
									try
									{
										// For each node in the list.
										foreach (PlNode node in this.Nodes)
										{
											// The node address.
											string address = string.Empty;
											try
											{
												// Get the node IP address.
												IPAddress[] addresses = Dns.GetHostEntry(node.Hostname).AddressList;
												// Get the address string.
												address = addresses.Length > 0 ? addresses[0].ToString() : string.Empty;
											}
											catch
											{
												// Increment the error count.
												countError++;
											}
											// Increment the total count.
											countTotal++;

											// Write the node to the file.
											writer.WriteLine("{0},{1},{2},{3}", node.Id, node.SiteId, node.Hostname, address);

											// Update the progress.
											this.Invoke(() =>
												{
													this.progressBar.Value = countTotal;
													this.labelProgress.Text = "{0} of {1} completed ({2} error{3})".FormatWith(
														countTotal, this.Nodes.Count, countError, countError.PluralSuffix());
												});
											
											// Check the cancel flag.
											lock (this.sync)
											{
												if (this.cancel) break;
											}
										}
									}
									finally
									{
										// Unlock the database list.
										this.Nodes.Unlock();
									}
								}
							}
						}
						catch (Exception exception)
						{
							this.Invoke(() =>
								{
									// If an exception occurs, show an error message.
									MessageBox.Show(this, "Exporting the data failed. {0}".FormatWith(exception.Message), "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
								});
						}

						// Change the controls state.
						this.Invoke(() =>
							{
								this.buttonClose.Enabled = true;
								this.buttonClose.Text = "&Close";
								this.Result = DialogResult.OK;
								// Raise the closed event.
								if (null != this.Closed) this.Closed(this, EventArgs.Empty);
							});

						// Change the saving state to false.
						lock (this.sync)
						{
							this.saving = false;
							this.cancel = false;
						}
					});
			}
		}

		/// <summary>
		/// An event handler called when the user clicks on the close button.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnClose(object sender, EventArgs e)
		{
			lock (this.sync)
			{
				// If the dialog is saving.
				if (saving)
				{
					// Set the cancel flag.
					this.cancel = true;
					// Disable the cancel button.
					this.buttonClose.Enabled = false;
					// Return.
					return;
				}
			}

			// Else, raise the closed event.
			if (null != this.Closed) this.Closed(this, EventArgs.Empty);
		}
	}
}
