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
using System.Windows.Forms;
using InetUpgrade.Actions;

namespace InetUpgrade
{
	/// <summary>
	/// A delegate used to send a progress action.
	/// </summary>
	/// <param name="text">The progress text.</param>
	public delegate void ActionProgress(string text);
	/// <summary>
	/// A delegate used to perform an upgrade action.
	/// </summary>
	/// <param name="progress"></param>
	public delegate void ActionUpgrade(ActionProgress progress);

	/// <summary>
	/// A program used for upgrading the Internet Analytics installation.
	/// </summary>
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		public static void Main()
		{
			// The upgrade actions list.
			List<UpgradeAction> actions = new List<UpgradeAction>();

			// Get the current program arguments.
			string[] arguments = Environment.GetCommandLineArgs();
			// For each argument.
			for (int index = 0; index < arguments.Length; index++)
			{
				switch (arguments[index].ToLowerInvariant())
				{
					case "/registry":
						// Registry upgrade action.
						if (index + 2 < arguments.Length)
						{
							actions.Add(new UpgradeActionRegistry(arguments[++index], arguments[++index]));
						}
						break;
					case "/files":
						// Files upgrade action.
						if (index + 2 < arguments.Length)
						{
							actions.Add(new UpgradeActionFiles(arguments[++index], arguments[++index]));
						}
						break;
					case "/tools":
						// Tools upgrade action.
						if (index + 1 < arguments.Length)
						{
							actions.Add(new UpgradeActionTools(arguments[++index]));
						}
						break;
				}
			}

			// If the there are no actions, exit.
			if (0 == actions.Count) return;

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new FormSetup(actions));
		}
	}
}
