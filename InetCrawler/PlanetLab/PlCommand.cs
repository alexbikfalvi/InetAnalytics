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
using System.Xml.Linq;
using DotNetApi;

namespace InetCrawler.PlanetLab
{
	/// <summary>
	/// A class representing a PlanetLab command.
	/// </summary>
	public sealed class PlCommand
	{
		public static readonly string regexParamGood = @"{\d+}";
		public static readonly string regexParamBad = @"{.*?(}|$)";

		private static readonly string xmlRoot = "PlCommand";
		private static readonly string xmlId = "Id";
		private static readonly string xmlCommand = "Command";
		private static readonly string xmlParameters = "Parameters";
		private static readonly string xmlSetsCount = "SetsCount";
		private static readonly string xmlParametersCount = "ParametersCount";
		private static readonly string xmlSet = "Set";
		private static readonly string xmlParameter = "Parameter";

		private Guid id;

		private string command = string.Empty;

		private object[,] parameters = null;

		/// <summary>
		/// Creates a new empty command instance.
		/// </summary>
		public PlCommand()
		{
			// Set the command identifier.
			this.id = Guid.NewGuid();
		}

		/// <summary>
		/// Creates a new command from the specified file.
		/// </summary>
		/// <param name="fileName">The file name.</param>
		public PlCommand(string fileName)
		{
			// Open the command from the file.
			this.Load(fileName);
		}

		// Public events.

		/// <summary>
		/// An event raised when the command has changed.
		/// </summary>
		public event PlCommandEventHandler Changed;

		// Public properties.

		/// <summary>
		/// Gets the command identifier.
		/// </summary>
		public Guid Id
		{
			get { return this.id; }
		}
		/// <summary>
		/// Gets or sets the command text.
		/// </summary>
		public string Command
		{
			get { return this.command; }
			set { this.OnSetCommand(value); }
		}
		/// <summary>
		/// Indicates whether the command has parameteres.
		/// </summary>
		public bool HasParameters
		{
			get { return this.parameters != null; }
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
				this.OnSetParameter(parameter, set, value);
			}
		}
		/// <summary>
		/// Gets whether the command is enabled.
		/// </summary>
		public bool Enabled
		{
			get { return true; }
		}

		// Public methods.

		/// <summary>
		/// Resizes the command parameters to match the specified number of parameters and sets.
		/// </summary>
		/// <param name="parameters">The number of parameters.</param>
		/// <param name="sets">The number of sets.</param>
		public void ResizeParameters(int parameters, int sets)
		{
			// Resize the parameters array.
			this.parameters = (parameters > 0) && (sets > 0) ? new object[parameters, sets] : null;
			// Raise the command changed event.
			if (null != this.Changed) this.Changed(this, new PlCommandEventArgs(this));
		}

		/// <summary>
		/// Saves the command to the specified file.
		/// </summary>
		/// <param name="fileName">The file name.</param>
		public void Save(string fileName)
		{
			// Create the parameters XML element.
			XElement parameters = new XElement(PlCommand.xmlParameters,
				new XAttribute(PlCommand.xmlParametersCount, this.ParametersCount),
				new XAttribute(PlCommand.xmlSetsCount, this.SetsCount));
			
			// If the parameters set is not null.
			if (null != this.parameters)
			{
				// Add the parameters.
				for (int indexParam = 0; indexParam < this.parameters.GetLength(0); indexParam++)
				{
					XElement parameter = new XElement(PlCommand.xmlParameter);

					for (int indexSet = 0; indexSet < this.parameters.GetLength(1); indexSet++)
					{
						parameter.Add(new XElement(PlCommand.xmlSet, this.parameters[indexParam, indexSet]));
					}

					parameters.Add(parameter);
				}
			}

			// Create the root XML element.
			XElement root = new XElement(PlCommand.xmlRoot,
				new XAttribute(PlCommand.xmlId, this.id.ToString()),
				new XElement(PlCommand.xmlCommand, this.command),
				parameters);

			// Create the document.
			XDocument document = new XDocument(root);

			// Save the document to the file.
			document.Save(fileName);
		}

		/// <summary>
		/// Loads the command configuration from the specified file.
		/// </summary>
		/// <param name="fileName">The file name.</param>
		public void Load(string fileName)
		{
			// Open the XML document at the specified file.
			XDocument document = XDocument.Load(fileName);

			// Set the command configuration.
			this.id = Guid.Parse(document.Root.Attribute(PlCommand.xmlId).Value);
			this.command = document.Root.Element(PlCommand.xmlCommand).Value;

			// Get the parameters element.
			XElement parameters = document.Root.Element(PlCommand.xmlParameters);

			// Set the parameters configuration.
			int parametersCount = int.Parse(parameters.Attribute(PlCommand.xmlParametersCount).Value);
			int setsCount = int.Parse(parameters.Attribute(PlCommand.xmlSetsCount).Value);

			// If the parameters are not zero, create the parameteres.
			if ((parametersCount > 0) && (setsCount > 0))
			{
				// Resize the parameters
				this.ResizeParameters(parametersCount, setsCount);

				// Parse the parameters.
				int indexParam = 0;
				foreach (XElement parameter in parameters.Elements(PlCommand.xmlParameter))
				{
					int indexSet = 0;
					foreach (XElement set in parameter.Elements(PlCommand.xmlSet))
					{
						this.parameters[indexParam, indexSet++] = set.Value;
					}
					indexParam++;
				}
			}
			else this.parameters = null;
		}

		/// <summary>
		/// Gets the command formatted with the specified parameter set.
		/// </summary>
		/// <param name="set">The parameter set.</param>
		/// <returns>The formatted command.</returns>
		public string GetCommand(int set)
		{
			// Create the list of parameters.
			object[] param = new object[this.ParametersCount];
			// Add the parameters.
			for (int index = 0; index < this.ParametersCount; index++)
			{
				param[index] = this.parameters[index, set];
			}
			// Return the formatted command.
			return this.command.FormatWith(param);
		}

		// Private methods.

		/// <summary>
		/// Sets the current command text.
		/// </summary>
		/// <param name="value">The command.</param>
		private void OnSetCommand(string value)
		{
			// Set the command.
			this.command = value;
			// Raise the command changed event.
			if (null != this.Changed) this.Changed(this, new PlCommandEventArgs(this));
		}

		/// <summary>
		/// Sets the parameter at the specified indices.
		/// </summary>
		/// <param name="parameter">The parameter index.</param>
		/// <param name="set">The set index.</param>
		/// <param name="value">The parameter value.</param>
		private void OnSetParameter(int parameter, int set, object value)
		{
			// If the indices are outside the bounds of the current parameter set, do nothing.
			if ((parameter < 0) || (parameter >= this.parameters.GetLength(0))) return;
			if ((set < 0) || (set >= this.parameters.GetLength(1))) return;
			// Set the parameter value.
			this.parameters[parameter, set] = value;
			// Raise the command changed event.
			if (null != this.Changed) this.Changed(this, new PlCommandEventArgs(this));
		}
	}
}
