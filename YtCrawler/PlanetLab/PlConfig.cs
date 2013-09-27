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
		private PlList<PlPerson> persons = new PlList<PlPerson>();
		private PlList<PlSlice> slices = new PlList<PlSlice>();
		private PlList<PlNode> nodes = new PlList<PlNode>();

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

			// Load the PlanetLab persons configuration.
			try { this.persons.LoadFromFile(this.PersonsFileName); }
			catch { }

			// Load the PlanetLab slices configuration.
			try { this.slices.LoadFromFile(this.SlicesFileName); }
			catch { }

			// Initialize the static configuration.
			CrawlerStatic.PlanetLabUsername = this.Username;
			CrawlerStatic.PlanetLabPassword = this.Password;
			CrawlerStatic.PlanetLabPersonId = this.PersonId;
			CrawlerStatic.PlanetLabSitesFileName = this.SitesFileName;
			CrawlerStatic.PlanetLabPersonsFileName = this.PersonsFileName;
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
		/// Gets or sets the PlanetLab persons file name.
		/// </summary>
		public string PersonsFileName
		{
			get
			{
				return DotNetApi.Windows.Registry.GetString(this.root, "PersonsFileName", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Alex Bikfalvi\YouTube Analytics\PlanetLab\Persons.xml");
			}
			set
			{
				DotNetApi.Windows.Registry.SetString(this.root, "PersonsFileName", value);
				CrawlerStatic.PlanetLabPersonsFileName = value;
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
		/// Gets the collection of PlanetLab sites.
		/// </summary>
		public PlList<PlSite> Sites { get { return this.sites; } }
		/// <summary>
		/// Gets the collection of PlanetLab persons.
		/// </summary>
		public PlList<PlPerson> Persons { get { return this.persons; } }
		/// <summary>
		/// Gets the collection of PlanetLab slices.
		/// </summary>
		public PlList<PlSlice> Slices { get { return this.slices; } }

		// Public methods.

		/// <summary>
		/// Disposes the current object.
		/// </summary>
		public void Dispose()
		{
			// Save the PlanetLab sites.
			try { this.Sites.SaveToFile(this.SitesFileName); }
			catch { }
			// Save the PlanetLab slices.
			try { this.Slices.SaveToFile(this.SlicesFileName); }
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
			this.persons.CopyFrom(persons);
			try { this.persons.SaveToFile(this.PersonsFileName); }
			catch { }
			// Save the person.
			DotNetApi.Windows.Registry.SetInteger(this.root, "PersonId", person);
			CrawlerStatic.PlanetLabPersonId = person;
		}
	}
}
