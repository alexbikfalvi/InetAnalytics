﻿/* 
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
using System.Security;
using DotNetApi;
using DotNetApi.Security;
using DotNetApi.Windows;

namespace YtCrawler.Testing
{
	/// <summary>
	/// A class that stores the testing SSH request parameters.
	/// </summary>
	public sealed class TestingSshRequest
	{
		private string key;

		/// <summary>
		/// Creates a new testing SSH request instance.
		/// </summary>
		/// <param name="key">The registry key.</param>
		public TestingSshRequest(string key)
		{
			// Set the registry key.
			this.key = key;
		}

		// Public properties.

		/// <summary>
		/// Gets or sets the SSH server.
		/// </summary>
		public string Server
		{
			get { return Registry.GetString(this.key, "Server", string.Empty); }
			set { Registry.SetString(this.key, "Server", value); }
		}

		/// <summary>
		/// Gets or sets whether using password authentication.
		/// </summary>
		public bool AuthenticationPassword
		{
			get { return Registry.GetBoolean(this.key, "AuthenticationPassword", true); }
			set { Registry.SetBoolean(this.key, "AuthenticationPassword", value); }
		}

		/// <summary>
		/// Gets or sets whether using private key authentication.
		/// </summary>
		public bool AuthenticationKey
		{
			get { return Registry.GetBoolean(this.key, "AuthenticationKey", false); }
			set { Registry.SetBoolean(this.key, "AuthenticationKey", value); }
		}

		/// <summary>
		/// Gets or sets the username.
		/// </summary>
		public string Username
		{
			get { return Registry.GetString(this.key, "Username", string.Empty); }
			set { Registry.SetString(this.key, "Username", value); }
		}

		/// <summary>
		/// Gets or sets the password.
		/// </summary>
		public SecureString Password
		{
			get { return Registry.GetSecureString(this.key, "Password", SecureStringExtensions.Empty, CrawlerConfig.cryptoKey, CrawlerConfig.cryptoIV); }
			set { Registry.SetSecureString(this.key, "Password", value, CrawlerConfig.cryptoKey, CrawlerConfig.cryptoIV); }
		}

		/// <summary>
		/// Gets or sets the key.
		/// </summary>
		public SecureString Key
		{
			get { return Registry.GetSecureString(this.key, "Key", SecureStringExtensions.Empty, CrawlerConfig.cryptoKey, CrawlerConfig.cryptoIV); }
			set { Registry.SetSecureString(this.key, "Key", value, CrawlerConfig.cryptoKey, CrawlerConfig.cryptoIV); }
		}
	}
}
