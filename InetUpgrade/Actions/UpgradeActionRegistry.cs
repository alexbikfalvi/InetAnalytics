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
using DotNetApi;
using DotNetApi.Windows;

namespace InetUpgrade.Actions
{
	/// <summary>
	/// A class representing the registry upgrade action.
	/// </summary>
	public sealed class UpgradeActionRegistry : UpgradeAction
	{
		private readonly string oldPath;
		private readonly string newPath;

		/// <summary>
		/// Creates a new registry upgrade action instance.
		/// </summary>
		/// <param name="oldPath">The old path.</param>
		/// <param name="newPath">The new path.</param>
		public UpgradeActionRegistry(string oldPath, string newPath)
		{
			this.oldPath = oldPath;
			this.newPath = newPath;
		}

		/// <summary>
		/// Executes the action.
		/// </summary>
		public override void Execute()
		{
			// Set a message.
			this.OnProgress(@"Upgrading registry path...{0}From: '{1}'{2}To: '{3}'".FormatWith(
				Environment.NewLine,
				oldPath,
				Environment.NewLine,
				newPath
				));

			// Move the registry key.
			Registry.MoveKey(Registry.CurrentUser, oldPath, Registry.CurrentUser, newPath);
		}
	}
}
