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
using DotNetApi.IO;

namespace InetUpgrade.Actions
{
	/// <summary>
	/// A class representing the files upgrade action.
	/// </summary>
	public sealed class UpgradeActionFiles : UpgradeAction
	{
		private readonly string oldPath;
		private readonly string newPath;

		/// <summary>
		/// Creates a new files upgrade action instance.
		/// </summary>
		/// <param name="oldPath">The old path.</param>
		/// <param name="newPath">The new path.</param>
		public UpgradeActionFiles(string oldPath, string newPath)
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
			this.OnProgress(@"Upgrading user files...{0}{1}From: '{2}'{3}{4}To: '{5}'".FormatWith(
				Environment.NewLine,
				Environment.NewLine,
				oldPath,
				Environment.NewLine,
				Environment.NewLine,
				newPath
				));

			// Move the files.
			Directory.Move(oldPath, newPath, Operations.DontOverwriteIgnoreErrors, (string srcPath, string dstPath) =>
				{
					// Set a message.
					this.OnProgress(@"Upgrading user files...{0}{1}From: '{2}'{3}{4}To: '{5}'".FormatWith(
						Environment.NewLine,
						Environment.NewLine,
						oldPath,
						Environment.NewLine,
						Environment.NewLine,
						newPath
						));
				});
		}
	}
}
