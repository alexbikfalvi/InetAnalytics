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
using System.Security;
using Microsoft.Win32;
using DotNetApi;
using DotNetApi.Security;
using PlanetLab.Api;

namespace YtCrawler.PlanetLab
{
	/// <summary>
	/// A class representing the PlanetLab configuration.
	/// </summary>
	public sealed class PlConfig : IDisposable
	{
		private RegistryKey key;
		private string root;

		private PlList<PlSite> sites = new PlList<PlSite>();
		private PlList<PlNode> nodes = new PlList<PlNode>();
		private PlList<PlSlice> slices = new PlList<PlSlice>();
		private PlList<PlPerson> localPersons = new PlList<PlPerson>();
		private PlList<PlSlice> localSlices = new PlList<PlSlice>();

		/// <summary>
		/// Creates a PlanetLab configuration instance at the specified registry key.
		/// </summary>
		/// <param name="rootKey">The root registry key.</param>
		/// <param name="path">The registry key.</param>
		public PlConfig(RegistryKey rootKey, string path)
		{
			// Open the database configuration key.
			if (null == (this.key = rootKey.OpenSubKey(path, RegistryKeyPermissionCheck.ReadWriteSubTree)))
			{
				this.key = rootKey.CreateSubKey(path, RegistryKeyPermissionCheck.ReadWriteSubTree);
			}
			// Set the root path.
			this.root = @"{0}\{1}".FormatWith(rootKey.Name, path);

			// Load the PlanetLab sites configuration.
			try { this.sites.LoadFromFile(this.SitesFileName); }
			catch { }

			// Load the PlanetLab nodes configuration.
			try { this.nodes.LoadFromFile(this.NodesFileName); }
			catch { }

			// Load the PlanetLab slices configuration.
			try { this.slices.LoadFromFile(this.SlicesFileName); }
			catch { }

			// Load the PlanetLab local persons configuration.
			try { this.localPersons.LoadFromFile(this.LocalPersonsFileName); }
			catch { }

			// Load the PlanetLab local slices configuration.
			try { this.localSlices.LoadFromFile(this.LocalSlicesFileName); }
			catch { }

			// Initialize the static configuration.
			CrawlerStatic.PlanetLabUsername = this.Username;
			CrawlerStatic.PlanetLabPassword = this.Password;
			CrawlerStatic.PlanetLabPersonId = this.PersonId;
			CrawlerStatic.PlanetLabSitesFileName = this.SitesFileName;
			CrawlerStatic.PlanetLabNodesFileName = this.NodesFileName;
			CrawlerStatic.PlanetLabLocalPersonsFileName = this.LocalPersonsFileName;
			CrawlerStatic.PlanetLabLocalSlicesFileName = this.LocalSlicesFileName;
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
				return DotNetApi.Windows.Registry.GetString(this.root, "SitesFileName", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Alex Bikfalvi\YouTube Analytics\PlanetLab\Sites.xml");
			}
			set
			{
				DotNetApi.Windows.Registry.SetString(this.root, "SitesFileName", value);
				CrawlerStatic.PlanetLabSitesFileName = value;
			}
		}
		/// <summary>
		/// Gets or sets the PlanetLab nodes file name.
		/// </summary>
		public string NodesFileName
		{
			get
			{
				return DotNetApi.Windows.Registry.GetString(this.root, "NodesFileName", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Alex Bikfalvi\YouTube Analytics\PlanetLab\Nodes.xml");
			}
			set
			{
				DotNetApi.Windows.Registry.SetString(this.root, "NodesFileName", value);
				CrawlerStatic.PlanetLabNodesFileName = value;
			}
		}
		/// <summary>
		/// Gets or sets the PlanetLab slices file name.
		/// </summary>
		public string SlicesFileName
		{
			get
			{
				return DotNetApi.Windows.Registry.GetString(this.root, "SlicesFileName", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Alex Bikfalvi\YouTube Analytics\PlanetLab\Slices.xml");
			}
			set
			{
				DotNetApi.Windows.Registry.SetString(this.root, "SlicesFileName", value);
				CrawlerStatic.PlanetLabSlicesFileName = value;
			}
		}
		/// <summary>
		/// Gets or sets the local PlanetLab persons file name.
		/// </summary>
		public string LocalPersonsFileName
		{
			get
			{
				return DotNetApi.Windows.Registry.GetString(this.root, "LocalPersonsFileName", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Alex Bikfalvi\YouTube Analytics\PlanetLab\LocalPersons.xml");
			}
			set
			{
				DotNetApi.Windows.Registry.SetString(this.root, "LocalPersonsFileName", value);
				CrawlerStatic.PlanetLabLocalPersonsFileName = value;
			}
		}
		/// <summary>
		/// Gets or sets the local PlanetLab slices file name.
		/// </summary>
		public string LocalSlicesFileName
		{
			get
			{
				return DotNetApi.Windows.Registry.GetString(this.root, "LocalSlicesFileName", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Alex Bikfalvi\YouTube Analytics\PlanetLab\LocalSlices.xml");
			}
			set
			{
				DotNetApi.Windows.Registry.SetString(this.root, "LocalSlicesFileName", value);
				CrawlerStatic.PlanetLabLocalSlicesFileName = value;
			}
		}
		/// <summary>
		/// Gets the collection of PlanetLab sites.
		/// </summary>
		public PlList<PlSite> Sites { get { return this.sites; } }
		/// <summary>
		/// Gets the collection of PlanetLab nodes.
		/// </summary>
		public PlList<PlNode> Nodes { get { return this.nodes; } }
		/// <summary>
		/// Gets the collection of PlanetLab slices.
		/// </summary>
		public PlList<PlSlice> Slices { get { return this.slices; } }
		/// <summary>
		/// Gets the collection of PlanetLab persons.
		/// </summary>
		public PlList<PlPerson> LocalPersons { get { return this.localPersons; } }
		/// <summary>
		/// Gets the collection of PlanetLab slices.
		/// </summary>
		public PlList<PlSlice> LocalSlices { get { return this.localSlices; } }

		// Public methods.

		/// <summary>
		/// Disposes the current object.
		/// </summary>
		public void Dispose()
		{
			// Save the PlanetLab sites.
			try { this.Sites.SaveToFile(this.SitesFileName); }
			catch { }
			// Save the PlanetLab nodes.
			try { this.Nodes.SaveToFile(this.NodesFileName); }
			catch { }
			// Save the PlanetLab slices.
			try { this.Slices.SaveToFile(this.SlicesFileName); }
			catch { }
			// Save the PlanetLab local slices.
			try { this.LocalSlices.SaveToFile(this.LocalSlicesFileName); }
			catch { }
			// Close the registry key.
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
			CrawlerStatic.PlanetLabUsername = username;
			// Save the password.
			DotNetApi.Windows.Registry.SetSecureString(this.root, "Password", password, CrawlerConfig.cryptoKey, CrawlerConfig.cryptoIV);
			CrawlerStatic.PlanetLabPassword = password;
			// Save the persons.
			this.LocalPersons.CopyFrom(persons);
			try { this.LocalPersons.SaveToFile(this.LocalPersonsFileName); }
			catch { }
			// Save the person.
			DotNetApi.Windows.Registry.SetInteger(this.root, "PersonId", person);
			CrawlerStatic.PlanetLabPersonId = person;
		}
	}
}
