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
using Microsoft.Win32;
using DotNetApi;
using DotNetApi.Windows;

namespace InetUpgrade.Actions
{
	/// <summary>
	/// A class representing the tools upgrade action.
	/// </summary>
	public sealed class UpgradeActionTools : UpgradeAction
	{
		private readonly string path;

		/// <summary>
		/// Creates a new tools upgrade action instance.
		/// </summary>
		/// <param name="path">The tools registry path.</param>
		public UpgradeActionTools(string path)
		{
			this.path = path;
		}

		/// <summary>
		/// Executes the action.
		/// </summary>
		public override void Execute()
		{
			// Set a message.
			this.OnProgress(@"Upgrading the tools configuration.");

			// Open the registry key.
			using (RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(this.path, RegistryKeyPermissionCheck.ReadWriteSubTree))
			{
				// If the key is null, return.
				if (null == key) return;

				// Get the tools value.
				string[] tools = key.GetMultiString("Tools", null);

				// If the tools is null, return.
				if (null == tools) return;

				// Else, for each tool.
				foreach (string tool in tools)
				{
					// Create a registry key.
					using (key.CreateSubKey(tool)) { }
				}

				// Delete the tools value.
				key.DeleteValue("Tools");
			}
		}
	}
}
