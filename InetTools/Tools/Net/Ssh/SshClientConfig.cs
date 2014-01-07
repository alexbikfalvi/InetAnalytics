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
using System.Security;
using DotNetApi.Security;
using DotNetApi.Windows;
using InetCrawler.Tools;

namespace InetTools.Tools.Net.Ssh
{
	/// <summary>
	/// A class representing the configuration for the SSH client tool.
	/// </summary>
	public sealed class SshClientConfig
	{
		/// <summary>
		/// An enumeration representing the authentication types.
		/// </summary>
		public enum AuthenticationType
		{
			Password = 0,
			Key = 1
		}

		private readonly IToolApi api;

		private static readonly byte[] defaultKey = new byte[0];

		private static readonly byte[] cryptoKey = { 0xE8, 0xE2, 0x3A, 0x45, 0x7D, 0x70, 0xB3, 0x82, 0x8C, 0x71, 0x57, 0xFE, 0x88, 0x84, 0xE9, 0x8D, 0xE0, 0xF3, 0x7F, 0x2A, 0x78, 0x8D, 0xE2, 0x4E, 0x82, 0xC0, 0x4D, 0x89, 0xC6, 0x76, 0x33, 0xDF };
		private static readonly byte[] cryptoIV = { 0xC7, 0x2B, 0xBA, 0x24, 0x1A, 0x83, 0xC8, 0xF6, 0x3B, 0x1B, 0x71, 0x37, 0x4C, 0x8A, 0x8F, 0x2B };

		/// <summary>
		/// Creates a new SSH client configuration instance.
		/// </summary>
		/// <param name="api">The tools API.</param>
		public SshClientConfig(IToolApi api)
		{
			this.api = api;
		}

		// Public properties.

		/// <summary>
		/// Gets the tool API.
		/// </summary>
		public IToolApi Api { get { return this.api; } }

		/// <summary>
		/// Gets or sets the SSH server.
		/// </summary>
		public string Server
		{
			get { return this.api.Key.GetString("Server", string.Empty); }
			set { this.api.Key.SetString("Server", value); }
		}

		/// <summary>
		/// Gets or sets the authentication type.
		/// </summary>
		public AuthenticationType Authentication
		{
			get { return (AuthenticationType)this.api.Key.GetInteger("Authentication", 0); }
			set { this.api.Key.SetInteger("Authentication", (int)value); }
		}

		/// <summary>
		/// Gets or sets the username.
		/// </summary>
		public string Username
		{
			get { return this.api.Key.GetString("Username", string.Empty); }
			set { this.api.Key.SetString("Username", value); }
		}

		/// <summary>
		/// Gets or sets the password.
		/// </summary>
		public SecureString Password
		{
			get { return this.api.Key.GetSecureString("Password", SecureStringExtensions.Empty, SshClientConfig.cryptoKey, SshClientConfig.cryptoIV); }
			set { this.api.Key.SetSecureString("Password", value, SshClientConfig.cryptoKey, SshClientConfig.cryptoIV); }
		}

		/// <summary>
		/// Gets or sets the key.
		/// </summary>
		public byte[] Key
		{
			get { return this.api.Key.GetSecureByteArray("Key", SshClientConfig.defaultKey, SshClientConfig.cryptoKey, SshClientConfig.cryptoIV); }
			set { this.api.Key.SetSecureByteArray("Key", value, SshClientConfig.cryptoKey, SshClientConfig.cryptoIV); }
		}
	}
}
