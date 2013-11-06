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
using System.Security;
using Microsoft.Win32;
using DotNetApi;
using DotNetApi.Security;
using PlanetLab;
using PlanetLab.Api;
using PlanetLab.Database;

namespace InetCrawler.PlanetLab
{
	/// <summary>
	/// A class representing the PlanetLab configuration.
	/// </summary>
	public sealed class PlConfig : IDisposable
	{
		private RegistryKey key;
		private RegistryKey keySlices;

		private string root;

		private readonly PlDatabase<PlSite> dbSites = new PlDatabase<PlSite>();
		private readonly PlDatabase<PlNode> dbNodes = new PlDatabase<PlNode>();
		private readonly PlDatabase<PlPerson> dbPersons = new PlDatabase<PlPerson>();
		private readonly PlDatabase<PlSlice> dbSlices = new PlDatabase<PlSlice>();

		private readonly PlDatabaseList<PlSite> listSites;
		private readonly PlDatabaseList<PlNode> listNodes;
		private readonly PlDatabaseList<PlSlice> listSlices;
		private readonly PlDatabaseList<PlPerson> listLocalPersons;
		private readonly PlDatabaseList<PlSlice> listLocalSlices;

		private readonly Dictionary<int, PlConfigSlice> configSlices = new Dictionary<int, PlConfigSlice>();

		/// <summary>
		/// Creates a PlanetLab configuration instance at the specified registry key.
		/// </summary>
		/// <param name="rootKey">The root registry key.</param>
		/// <param name="path">The registry key.</param>
		public PlConfig(RegistryKey rootKey, string path)
		{
			// Open the PlanetLab configuration key.
			if (null == (this.key = rootKey.OpenSubKey(path, RegistryKeyPermissionCheck.ReadWriteSubTree)))
			{
				this.key = rootKey.CreateSubKey(path, RegistryKeyPermissionCheck.ReadWriteSubTree);
			}
			// Open the PlanetLab slices configuration key.
			if (null == (this.keySlices = this.key.OpenSubKey("Slices", RegistryKeyPermissionCheck.ReadWriteSubTree)))
			{
				this.keySlices = this.key.CreateSubKey("Slices", RegistryKeyPermissionCheck.ReadWriteSubTree);
			}

			// Set the root path.
			this.root = @"{0}\{1}".FormatWith(rootKey.Name, path);

			// Create the PlanetLab lists.
			this.listSites = new PlDatabaseList<PlSite>(this.dbSites);
			this.listNodes = new PlDatabaseList<PlNode>(this.dbNodes);
			this.listSlices = new PlDatabaseList<PlSlice>(this.dbSlices);
			this.listLocalPersons = new PlDatabaseList<PlPerson>(this.dbPersons);
			this.listLocalSlices = new PlDatabaseList<PlSlice>(this.dbSlices);

			// Set the lists event handlers.
			this.listLocalSlices.Cleared += this.OnSlicesCleared;
			this.listLocalSlices.Updated += this.OnSlicesUpdated;
			this.listLocalSlices.Added += this.OnSlicesAdded;
			this.listLocalSlices.Removed += this.OnSlicesRemoved;

			// Load the PlanetLab sites configuration.
			try { this.listSites.LoadFromFile(this.SitesFileName); }
			catch { }

			// Load the PlanetLab nodes configuration.
			try { this.listNodes.LoadFromFile(this.NodesFileName); }
			catch { }

			// Load the PlanetLab slices configuration.
			try { this.listSlices.LoadFromFile(this.SlicesFileName); }
			catch { }

			// Load the PlanetLab local persons configuration.
			try { this.listLocalPersons.LoadFromFile(this.LocalPersonsFileName); }
			catch { }

			// Load the PlanetLab local slices configuration.
			try { this.listLocalSlices.LoadFromFile(this.LocalSlicesFileName); }
			catch { }

			// Initialize the static configuration.
			CrawlerConfig.Static.PlanetLabUsername = this.Username;
			CrawlerConfig.Static.PlanetLabPassword = this.Password;
			CrawlerConfig.Static.PlanetLabPersonId = this.PersonId;
			CrawlerConfig.Static.PlanetLabSitesFileName = this.SitesFileName;
			CrawlerConfig.Static.PlanetLabNodesFileName = this.NodesFileName;
			CrawlerConfig.Static.PlanetLabLocalPersonsFileName = this.LocalPersonsFileName;
			CrawlerConfig.Static.PlanetLabLocalSlicesFileName = this.LocalSlicesFileName;
		}

		// Public properties.

		/// <summary>
		/// Gets or sets the PlanetLab account name.
		/// </summary>
		public string Username
		{
			get
			{
				return DotNetApi.Windows.Registry.GetString(this.root, "UserName", string.Empty);
			}
		}
		/// <summary>
		/// Gets or sets the PlanetLab account password.
		/// </summary>
		public SecureString Password
		{
			get
			{
				return DotNetApi.Windows.Registry.GetSecureString(this.root, "Password", SecureStringExtensions.Empty, CrawlerConfig.cryptoKey, CrawlerConfig.cryptoIV);
			}
		}
		/// <summary>
		/// Gets or sets the PlanetLab default person ID.
		/// </summary>
		public int PersonId
		{
			get
			{
				return DotNetApi.Windows.Registry.GetInteger(this.root, "PersonId", -1);
			}
		}
		/// <summary>
		/// Gets or sets the PlanetLab sites file name.
		/// </summary>
		public string SitesFileName
		{
			get
			{
				return DotNetApi.Windows.Registry.GetString(this.root, "SitesFileName", CrawlerConfig.Static.ApplicationFolder + @"\PlanetLab\Sites.xml");
			}
			set
			{
				DotNetApi.Windows.Registry.SetString(this.root, "SitesFileName", value);
				CrawlerConfig.Static.PlanetLabSitesFileName = value;
			}
		}
		/// <summary>
		/// Gets or sets the PlanetLab nodes file name.
		/// </summary>
		public string NodesFileName
		{
			get
			{
				return DotNetApi.Windows.Registry.GetString(this.root, "NodesFileName", CrawlerConfig.Static.ApplicationFolder + @"\PlanetLab\Nodes.xml");
			}
			set
			{
				DotNetApi.Windows.Registry.SetString(this.root, "NodesFileName", value);
				CrawlerConfig.Static.PlanetLabNodesFileName = value;
			}
		}
		/// <summary>
		/// Gets or sets the PlanetLab slices file name.
		/// </summary>
		public string SlicesFileName
		{
			get
			{
				return DotNetApi.Windows.Registry.GetString(this.root, "SlicesFileName", CrawlerConfig.Static.ApplicationFolder + @"\PlanetLab\Slices.xml");
			}
			set
			{
				DotNetApi.Windows.Registry.SetString(this.root, "SlicesFileName", value);
				CrawlerConfig.Static.PlanetLabSlicesFileName = value;
			}
		}
		/// <summary>
		/// Gets or sets the local PlanetLab persons file name.
		/// </summary>
		public string LocalPersonsFileName
		{
			get
			{
				return DotNetApi.Windows.Registry.GetString(this.root, "LocalPersonsFileName", CrawlerConfig.Static.ApplicationFolder + @"\PlanetLab\LocalPersons.xml");
			}
			set
			{
				DotNetApi.Windows.Registry.SetString(this.root, "LocalPersonsFileName", value);
				CrawlerConfig.Static.PlanetLabLocalPersonsFileName = value;
			}
		}
		/// <summary>
		/// Gets or sets the local PlanetLab slices file name.
		/// </summary>
		public string LocalSlicesFileName
		{
			get
			{
				return DotNetApi.Windows.Registry.GetString(this.root, "LocalSlicesFileName", CrawlerConfig.Static.ApplicationFolder + @"\PlanetLab\LocalSlices.xml");
			}
			set
			{
				DotNetApi.Windows.Registry.SetString(this.root, "LocalSlicesFileName", value);
				CrawlerConfig.Static.PlanetLabLocalSlicesFileName = value;
			}
		}
		/// <summary>
		/// Gets the sites database.
		/// </summary>
		public PlDatabase<PlSite> DbSites { get { return this.dbSites; } }
		/// <summary>
		/// Gets the nodes database.
		/// </summary>
		public PlDatabase<PlNode> DbNodes { get { return this.dbNodes; } }
		/// <summary>
		/// Gets the slices database.
		/// </summary>
		public PlDatabase<PlSlice> DbSlices { get { return this.dbSlices; } }
		/// <summary>
		/// Gets the persons database.
		/// </summary>
		public PlDatabase<PlPerson> DbPersons { get { return this.dbPersons; } }
		/// <summary>
		/// Gets the collection of PlanetLab sites.
		/// </summary>
		public PlDatabaseList<PlSite> Sites { get { return this.listSites; } }
		/// <summary>
		/// Gets the collection of PlanetLab nodes.
		/// </summary>
		public PlDatabaseList<PlNode> Nodes { get { return this.listNodes; } }
		/// <summary>
		/// Gets the collection of PlanetLab slices.
		/// </summary>
		public PlDatabaseList<PlSlice> Slices { get { return this.listSlices; } }
		/// <summary>
		/// Gets the collection of PlanetLab persons.
		/// </summary>
		public PlDatabaseList<PlPerson> LocalPersons { get { return this.listLocalPersons; } }
		/// <summary>
		/// Gets the collection of PlanetLab slices.
		/// </summary>
		public PlDatabaseList<PlSlice> LocalSlices { get { return this.listLocalSlices; } }

		// Public methods.

		/// <summary>
		/// Disposes the current object.
		/// </summary>
		public void Dispose()
		{
			// Save the PlanetLab sites.
			if (this.Sites.IsDirty)
			{
				try { this.Sites.SaveToFile(this.SitesFileName); }
				catch { }
			}
			// Save the PlanetLab nodes.
			if (this.Nodes.IsDirty)
			{
				try { this.Nodes.SaveToFile(this.NodesFileName); }
				catch { }
			}
			// Save the PlanetLab slices.
			if (this.Slices.IsDirty)
			{
				try { this.Slices.SaveToFile(this.SlicesFileName); }
				catch { }
			}
			// Save the PlanetLab local slices.
			if (this.LocalSlices.IsDirty)
			{
				try { this.LocalSlices.SaveToFile(this.LocalSlicesFileName); }
				catch { }
			}
			// Dispose the slices configuration.
			foreach (PlConfigSlice configSlice in this.configSlices.Values)
			{
				configSlice.Dispose();
			}
			// Close the registry key.
			this.keySlices.Close();
			this.key.Close();
			// Suppress the finalizer.
			GC.SuppressFinalize(this);
		}

		/// <summary>
		/// Saves the PlanetLab credentials.
		/// </summary>
		/// <param name="username">The PlanetLab username.</param>
		/// <param name="password">The PlanetLab persons.</param>
		/// <param name="persons">The list of person accounts associated with the previous credentials.</param>
		/// <param name="person">The default person account ID.</param>
		public void SaveCredentials(string username, SecureString password, PlList<PlPerson> persons, int person)
		{
			// Save the username.
			DotNetApi.Windows.Registry.SetString(this.root, "UserName", username);
			CrawlerConfig.Static.PlanetLabUsername = username;
			// Save the password.
			DotNetApi.Windows.Registry.SetSecureString(this.root, "Password", password, CrawlerConfig.cryptoKey, CrawlerConfig.cryptoIV);
			CrawlerConfig.Static.PlanetLabPassword = password;
			// Save the persons.
			persons.Lock();
			try { this.LocalPersons.CopyFrom(persons); }
			catch { persons.Unlock(); }
			try { this.LocalPersons.SaveToFile(this.LocalPersonsFileName); }
			catch { }
			// Save the person.
			DotNetApi.Windows.Registry.SetInteger(this.root, "PersonId", person);
			CrawlerConfig.Static.PlanetLabPersonId = person;
		}

		/// <summary>
		/// Returns the configuration for the specified slice.
		/// </summary>
		/// <param name="slice">The slice.</param>
		/// <returns>The slice configuration.</returns>
		public PlConfigSlice GetSliceConfiguration(PlSlice slice)
		{
			// Validate the arguments.
			if (null == slice) throw new ArgumentNullException("slice");
			// If the slice does not have a valid identifier, throw an exception.
			if (!slice.Id.HasValue) throw new CrawlerException("The slice does not have a valid identifier.");


			// Return the configuration.
			PlConfigSlice configSlice;
			// Try and get the configuration.
			if (!this.configSlices.TryGetValue(slice.Id.Value, out configSlice))
			{
				// If the configuration does not exist, throw an exception.
				throw new CrawlerException("The specified slice does not have a configuration.");
			}

			return configSlice;
		}

		// Private methods.

		/// <summary>
		/// An event handler called when the list of slices is cleared.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSlicesCleared(object sender, EventArgs e)
		{
			// For all slices.
			foreach (PlConfigSlice configSlice in this.configSlices.Values)
			{
				// Dispose the configuration.
				configSlice.Dispose();
				// Delete the configuration key.
				PlConfigSlice.Delete(configSlice, this.keySlices);
			}
			// Clear the slices configurations.
			this.configSlices.Clear();
		}

		/// <summary>
		/// An event handler called when the list of slices is updated.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSlicesUpdated(object sender, EventArgs e)
		{
			// Lock the slices list.
			this.listLocalSlices.Lock();
			try
			{
				// For each slice.
				foreach (PlSlice slice in this.listLocalSlices)
				{
					// If the slice has a valid identifier.
					if (slice.Id.HasValue)
					{
						// Create a new slice configuration.
						PlConfigSlice configSlice = new PlConfigSlice(slice, this.keySlices);
						// Add the configuration to the dictionary.
						this.configSlices.Add(slice.Id.Value, configSlice);
					}
				}
			}
			finally
			{
				// Unlock the slices list.
				this.listLocalSlices.Unlock();
			}
		}

		/// <summary>
		/// An event handler called when a slice is added.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSlicesAdded(object sender, PlObjectEventArgs<PlSlice> e)
		{
			// If the slice has a valid identifier.
			if (e.Object.Id.HasValue)
			{
				// Create a new slice configuration.
				PlConfigSlice configSlice = new PlConfigSlice(e.Object, this.keySlices);
				// Add the configuration to the dictionary.
				this.configSlices.Add(e.Object.Id.Value, configSlice);
			}
		}

		/// <summary>
		/// An event handler called when a slice is removed.
		/// </summary>
		/// <param name="sender">The sender object.</param>
		/// <param name="e">The event arguments.</param>
		private void OnSlicesRemoved(object sender, PlObjectEventArgs<PlSlice> e)
		{
			// If the slice has a valid identifier.
			if (e.Object.Id.HasValue)
			{
				// Get the current configuration.
				PlConfigSlice configSlice;
				if (this.configSlices.TryGetValue(e.Object.Id.Value, out configSlice))
				{
					// Remove the configuration.
					this.configSlices.Remove(e.Object.Id.Value);
					// Dispose the configuration.
					configSlice.Dispose();
					// Delete the configuration.
					PlConfigSlice.Delete(configSlice, this.keySlices);
				}
			}
		}
	}
}
