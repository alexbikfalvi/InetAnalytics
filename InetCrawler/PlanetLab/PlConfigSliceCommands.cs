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
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Microsoft.Win32;
using DotNetApi;
using DotNetApi.Windows;

namespace InetCrawler.PlanetLab
{
	/// <summary>
	/// A class representing the slice commands configuration
	/// </summary>
	public sealed class PlConfigSliceCommands : IDisposable, IEnumerable<PlCommand>
	{
		private readonly RegistryKey key;
		private readonly int slice;

		private readonly Dictionary<Guid, PlCommand> commands = new Dictionary<Guid, PlCommand>();

		private readonly object sync = new object();

		/// <summary>
		/// Creates a new PlanetLab slice commands configuration instance.
		/// </summary>
		/// <param name="rootKey">The root registry key.</param>
		/// <param name="sliceId">The slice identifier.</param>
		public PlConfigSliceCommands(RegistryKey rootKey, int slice)
		{
			// Set the slice identifier.
			this.slice = slice;

			// Open or create the subkey for the current slice commands.
			if (null == (this.key = rootKey.OpenSubKey("Commands", RegistryKeyPermissionCheck.ReadWriteSubTree)))
			{
				// If the key does not exist, create the key.
				this.key = rootKey.CreateSubKey("Commands");
			}

			// Load the commands for the slice configuration.
			foreach (string id in this.key.GetValueNames())
			{
				// Load the command.
				this.LoadCommand(id);
			}
		}

		// Public events.

		/// <summary>
		/// An event raised when a command was added.
		/// </summary>
		public event PlCommandEventHandler CommandAdded;
		/// <summary>
		/// An event raised when a command was removed.
		/// </summary>
		public event PlCommandEventHandler CommandRemoved;

		// Public methods.

		/// <summary>
		/// Disposes the current object.
		/// </summary>
		public void Dispose()
		{
			// Close the registry key.
			this.key.Close();
			// Suppress the finalizer.
			GC.SuppressFinalize(this);
		}

		/// <summary>
		/// Returns the enumerator for the current commands.
		/// </summary>
		/// <returns>The enumerator.</returns>
		public IEnumerator<PlCommand> GetEnumerator()
		{
			return this.commands.Values.GetEnumerator();
		}

		/// <summary>
		/// Returns the enumerator for the current commands.
		/// </summary>
		/// <returns>The enumerator.</returns>
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		/// <summary>
		/// Adds a new command to the current slice configuration. If the command already exists, the method does nothing.
		/// </summary>
		/// <param name="command">The command.</param>
		public void Add(PlCommand command)
		{
			lock (this.sync)
			{
				// If the command already exists, return.
				if (this.commands.ContainsKey(command.Id)) return;
				// Add the command.
				this.commands.Add(command.Id, command);
				// Add the command event handlers.
				command.Changed += this.OnCommandChanged;
				// Save the command.
				this.SaveCommand(command);
				// Raise the add command event.
				if (null != this.CommandAdded) this.CommandAdded(this, new PlCommandEventArgs(command));
			}
		}

		/// <summary>
		/// Removes a command from the current slice configuration. If the command does not exist, the method does nothing.
		/// </summary>
		/// <param name="command">The command.</param>
		public void Remove(PlCommand command)
		{
			lock (this.sync)
			{
				// Remove the command.
				if (this.commands.Remove(command.Id))
				{
					// Remove the command event handler.
					command.Changed -= this.OnCommandChanged;
					// If the command was successfully removed, delete the command configuration.
					this.DeleteCommand(command);
					// Raise the remove command event.
					if (null != this.CommandRemoved) this.CommandRemoved(this, new PlCommandEventArgs(command));
				}
			}
		}

		// Private methods.

		/// <summary>
		/// Saves the command.
		/// </summary>
		/// <param name="command">The command.</param>
		private void SaveCommand(PlCommand command)
		{
			// Check the commands directory exists.
			if (!Directory.Exists(CrawlerConfig.Static.PlanetLabCommandsFolder))
			{
				// If the directory does not exist, create it.
				Directory.CreateDirectory(CrawlerConfig.Static.PlanetLabCommandsFolder);
			}

			// Create the command file name.
			string fileName = Path.Combine(CrawlerConfig.Static.PlanetLabCommandsFolder, "{0}-{1}.xml".FormatWith(this.slice, command.Id.ToString()));

			// Save the command to the specified file.
			command.Save(fileName);

			// Create a registry value for the command.
			key.SetString(command.Id.ToString(), fileName);
		}

		/// <summary>
		/// Deletes a command.
		/// </summary>
		/// <param name="command">The command.</param>
		private void DeleteCommand(PlCommand command)
		{
			// Get the file name from the command registry value.
			string fileName = key.GetString(command.Id.ToString(), null);

			// If the file name is null, do nothing.
			if (fileName == null) return;

			// Delete the registry value.
			key.DeleteValue(command.Id.ToString());

			// Delete the file.
			try { File.Delete(fileName); }
			catch { }
		}

		/// <summary>
		/// Loads the command with the specified identifier.
		/// </summary>
		/// <param name="id">The identifier.</param>
		private void LoadCommand(string id)
		{
			// Get the file name from the command registry value.
			string fileName = key.GetString(id, null);

			// If the file name is null, do nothing.
			if (fileName == null) return;

			try
			{
				// Create the command from the specified file.
				PlCommand command = new PlCommand(fileName);

				lock (this.sync)
				{
					// If the command already exists, return.
					if (this.commands.ContainsKey(command.Id)) return;
					// Add the command.
					this.commands.Add(command.Id, command);
					// Add the command event handlers.
					command.Changed += this.OnCommandChanged;
					// Raise the add command event.
					if (null != this.CommandAdded) this.CommandAdded(this, new PlCommandEventArgs(command));
				}
			}
			catch
			{
				// If any exception occurs, remove the registry value.
				this.key.DeleteValue(id);
			}
		}

		/// <summary>
		/// An event handler called when the command changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnCommandChanged(object sender, PlCommandEventArgs e)
		{
			// Save the command.
			this.SaveCommand(e.Command);
		}
	}
}