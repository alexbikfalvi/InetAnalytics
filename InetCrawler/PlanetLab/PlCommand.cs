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

		public static readonly string regexParamGood = @"{\d+}";
		public static readonly string regexParamBad = @"{.*?(}|$)";

		private CommandStatus status = CommandStatus.Warning;
		
		private string command = string.Empty;
		
		private object[,] parameters = null;

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
			set { this.command = value; }
		}
		/// <summary>
		/// Gets the parameters count.
		/// </summary>
		public int ParametersCount
		{
			get { return null != this.parameters ? this.parameters.GetLength(0) : 0; }
		}
		/// <summary>
		/// Gets the sets count.
		/// </summary>
		public int SetsCount
		{
			get { return null != this.parameters ? this.parameters.GetLength(1) : 0; }
		}
		/// <summary>
		/// Gets the parameters at the specified parametera and set indices.
		/// </summary>
		/// <param name="parameter">The parameter index.</param>
		/// <param name="set">The set index.</param>
		/// <returns>The parameter value or <b>null</b> if the parameter does not exist or is empty.</returns>
		public object this[int parameter, int set]
		{
			get
			{
				if ((parameter < 0) || (parameter >= this.parameters.GetLength(0))) return null;
				if ((set < 0) || (set >= this.parameters.GetLength(1))) return null;
				return this.parameters[parameter, set];
			}
			set
			{
				if ((parameter < 0) || (parameter >= this.parameters.GetLength(0))) return;
				if ((set < 0) || (set >= this.parameters.GetLength(1))) return;
				this.parameters[parameter, set] = value;
			}
		}

		// Public methods.

		/// <summary>
		/// Resizes the command parameters to match the specified number of parameters and sets.
		/// </summary>
		/// <param name="parameters">The number of parameters.</param>
		/// <param name="sets">The number of sets.</param>
		public void ResizeParameters(int parameters, int sets)
		{
			this.parameters = new object[parameters, sets];
		}
	}
}
