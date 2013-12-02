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
using System.Text.RegularExpressions;

namespace InetCrawler.PlanetLab
{
	/// <summary>
	/// A class representing a PlanetLab command.
	/// </summary>
	public sealed class PlCommand
	{
		public enum CommandStatus
		{
			Success = 0,
			Warning = 1,
			Error = 2
		}

		private CommandStatus status = CommandStatus.Warning;
		
		private string command = string.Empty;
		
		private int parametersCount = 0;
		private int setsCount = 0;

		/// <summary>
		/// Creates a new empty command instance.
		/// </summary>
		public PlCommand()
		{

		}

		// Public events.

		/// <summary>
		/// An event raised when the command changes.
		/// </summary>
		public event EventHandler Changed;

		// Public properties.

		/// <summary>
		/// Gets the command status.
		/// </summary>
		public CommandStatus Status
		{
			get { return this.status; }
		}
		/// <summary>
		/// Gets or sets the command text.
		/// </summary>
		public string Command
		{
			get { return this.command; }
		}
		/// <summary>
		/// Gets the parameters count.
		/// </summary>
		public int ParametersCount
		{
			get { return this.parametersCount; }
		}
		/// <summary>
		/// Gets the sets count.
		/// </summary>
		public int SetsCount
		{
			get { return this.setsCount; }
		}

		// Public methods.

		/// <summary>
		/// Returns the number of parameters found in the specified string.
		/// </summary>
		/// <param name="command"></param>
		/// <returns></returns>
		//public static int GetParametersCount(string command)
		//{

		//}

		/// <summary>
		/// Gets the parameter at the specified set.
		/// </summary>
		/// <param name="parameter"></param>
		/// <param name="set"></param>
		/// <returns></returns>
		public string GetParameter(int parameter, int set)
		{
			return string.Empty;
		}

	}
}
