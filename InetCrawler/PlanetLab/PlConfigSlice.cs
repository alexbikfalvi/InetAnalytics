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
using Microsoft.Win32;
using DotNetApi;
using DotNetApi.Windows;
using InetCrawler.Log;
using PlanetLab;
using PlanetLab.Api;

namespace InetCrawler.PlanetLab
{
	/// <summary>
	/// A class representing the configuration for a PlanetLab slice.
	/// </summary>
	public sealed class PlConfigSlice : IDisposable
	{
		private readonly PlSlice slice;
		private readonly RegistryKey key;

		private readonly Logger log;

		private readonly PlConfigSliceCommands commands;

		/// <summary>
		/// Creates a new configuration slice instance.
		/// </summary>
		/// <param name="slice">The slice.</param>
		/// <param name="rootKey">The root registry key.</param>
		public PlConfigSlice(PlSlice slice, RegistryKey rootKey)
		{
			// Check the arguments.
			if (null == slice) throw new ArgumentNullException("slice");

			// Set the slice.
			this.slice = slice;

			// Set the slice event handler.
			this.slice.Changed += this.OnSliceChanged;

			// Open or create the subkey for the current slice.
			if (null == (this.key = rootKey.OpenSubKey(this.slice.Id.Value.ToString(), RegistryKeyPermissionCheck.ReadWriteSubTree)))
			{
				// If the key does not exist, create the key.
				this.key = rootKey.CreateSubKey(this.slice.Id.Value.ToString());
			}

			// Check the commands directory exists.
			if (!Directory.Exists(CrawlerConfig.Static.PlanetLabSlicesFolder))
			{
				// If the directory does not exist, create it.
				Directory.CreateDirectory(CrawlerConfig.Static.PlanetLabSlicesFolder);
			}

			// Create the slice log.
			this.log = new Logger(CrawlerConfig.Static.PlanetLabSlicesLogFileName.FormatWith(this.slice.Id, "{0}", "{1}", "{2}"));

			// Create the slice commands configuration.
			this.commands = new PlConfigSliceCommands(this.key, this.slice.Id.Value);
		}

		// Public event.

		/// <summary>
		/// An event raised when the current slice configuration has changed.
		/// </summary>
		public event EventHandler Changed;
		/// <summary>
		/// An event raised when the current slice configuration is being disposed.
		/// </summary>
		public event EventHandler Disposed;

		// Public properties.

		/// <summary>
		/// Gets the slice name.
		/// </summary>
		public string Name
		{
			get { return this.slice.Name; }
		}
		/// <summary>
		/// Gets the slice log.
		/// </summary>
		public Logger Log
		{
			get { return this.log; }
		}
		/// <summary>
		/// Gets the PlanetLab slice commands.
		/// </summary>
		public PlConfigSliceCommands Commands
		{
			get { return this.commands; }
		}
		/// <summary>
		/// Gets or sets the PlanetLab slice private key.
		/// </summary>
		public byte[] Key
		{
			get
			{
				return this.key.GetSecureByteArray("Key", null, CrawlerConfig.cryptoKey, CrawlerConfig.cryptoIV);
			}
			set
			{
				// Set the key.
				this.key.SetSecureByteArray("Key", value, CrawlerConfig.cryptoKey, CrawlerConfig.cryptoIV);
				// Call the changed event handler.
				this.OnChanged();
			}
		}
		/// <summary>
		/// Gets or sets whether the nodes status is updated before running a PlanetLab command.
		/// </summary>
		public bool UpdateNodesBeforeRun
		{
			get	{ return this.key.GetBoolean("UpdateNodesBeforeRun", true); }
			set { this.key.SetBoolean("UpdateNodesBeforeRun", value); }
		}
		/// <summary>
		/// Gets or sets whether PlanetLab commands will only run on boot nodes.
		/// </summary>
		public bool OnlyRunOnBootNodes
		{
			get { return this.key.GetBoolean("OnlyRunOnBootNodes", true); }
			set { this.key.SetBoolean("OnlyRunOnBootNodes", value); }
		}
		/// <summary>
		/// Gets or sets whether PlanetLab commands will run on a single node per site.
		/// </summary>
		public bool OnlyRunOneNodePerSite
		{
			get { return this.key.GetBoolean("OnlyRunOneNodePerSite", true); }
			set { this.key.SetBoolean("OnlyRunOneNodePerSite", value); }
		}
		/// <summary>
		/// Gets or sets the number of PlanetLab nodes on which the commands will be run in parallel.
		/// </summary>
		public int RunParallelNodes
		{
			get { return this.key.GetInteger("RunParallelNodes", 1); }
			set { this.key.SetInteger("RunParallelNodes", value); }
		}
		/// <summary>
		/// Gets or sets the number of retries for a PlanetLab command.
		/// </summary>
		public int CommandRetries
		{
			get { return this.key.GetInteger("CommandRetries", 3); }
			set { this.key.SetInteger("CommandRetries", value); }
		}

		// Public methods.

		/// <summary>
		/// Deletes the configuration registry key corresponding to the given slice.
		/// </summary>
		/// <param name="config">The slice configuration.</param>
		/// <param name="rootKey">The root registry key.</param>
		public static void Delete(PlConfigSlice config, RegistryKey rootKey)
		{
			// Check the arguments.
			if (null == config) throw new ArgumentNullException("config");

			// Delete the registry key.
			rootKey.DeleteSubKeyTree(config.slice.Id.Value.ToString(), false);
		}

		/// <summary>
		/// Disposes the current object.
		/// </summary>
		public void Dispose()
		{
			// Call the disposed event handler.
			this.OnDisposed();
			// Remove the slice event handler.
			this.slice.Changed -= this.OnSliceChanged;
			// Close the log.
			this.log.Dispose();
			// Dispose the slice commands.
			this.commands.Dispose();
			// Close the current key.
			this.key.Close();
			// Suppress the finalizer.
			GC.SuppressFinalize(this);
		}

		/// <summary>
		/// An event handler called when the current slice configuration has changed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSliceChanged(object sender, PlObjectEventArgs e)
		{
			// Call the changed event handler.
			this.OnChanged();
		}

		/// <summary>
		/// An event handler called when the current slice configuration has changed.
		/// </summary>
		private void OnChanged()
		{
			// Raise the event.
			if (null != this.Changed) this.Changed(this, EventArgs.Empty);
		}

		/// <summary>
		/// An event handler called when the current slice configuration is being disposed.
		/// </summary>
		private void OnDisposed()
		{
			// Raise the event.
			if (null != this.Disposed) this.Disposed(this, EventArgs.Empty);
		}
	}
}
