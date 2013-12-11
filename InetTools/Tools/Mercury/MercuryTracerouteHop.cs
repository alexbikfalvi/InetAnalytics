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
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using DotNetApi;

namespace InetTools.Tools.Mercury
{
	/// <summary>
	/// A class representing a traceroute hop.
	/// </summary>
	public struct MercuryTracerouteHop
	{
		private static readonly string regexHop = @"[0-9]+  ";
		private static readonly string regexLinuxDestination = @"  .+? \([0-9]+\.[0-9]+\.[0-9]+\.[0-9]+\)";
		private static readonly string regexIp = @"[0-9]+\.[0-9]+\.[0-9]+\.[0-9]+";
		private static readonly string regexAs = @"\[AS.+\]";
		private static readonly string regexRtt = @"[0-9]+.[0-9]* ms";

		private static readonly char[] separatorSpace = { ' ' };
		private static readonly char[] separatorSpaceRoundBrackets = { ' ', '(', ')' };
		private static readonly char[] separatorAsNumbers = { 'A', 'S', '/', '[', ']' };
		private static readonly char[] separatorRtt = { ' ', 'm', 's' };

		// Public fields.

		/// <summary>
		/// The hop number.
		/// </summary>
		public int Number { get; private set; }
		/// <summary>
		/// The hop hostname.
		/// </summary>
		public string Hostname { get; private set; }
		/// <summary>
		/// The hop IP address.
		/// </summary>
		public IPAddress Address { get; private set; }
		/// <summary>
		/// The hop autonomous system number.
		/// </summary>
		public int[] AutonomousSystems { get; private set;}
		/// <summary>
		/// The hop RTT values.
		/// </summary>
		public double[] Rtt { get; private set; }

		// Public methods.

		/// <summary>
		/// Parses the data string from a Linux traceroute hop.
		/// </summary>
		/// <param name="data">The traceroute data.</param>
		/// <returns>A traceroute hop.</returns>
		public static MercuryTracerouteHop ParseLinux(string data)
		{
			// Create a traceroute hop.
			MercuryTracerouteHop hop = new MercuryTracerouteHop();

			// Parse the hop number.
			hop.Number = MercuryTracerouteHop.ParseLinuxHopNumber(data);
			// Parse the destination.
			hop.ParseDestination(data);
			// Parse the autonomous system numbers.
			hop.ParseAsNumbers(data);
			// Parse the round-trip time.
			hop.ParseRtt(data);

			// Return the hop.
			return hop;
		}

		// Private methods.

		/// <summary>
		/// Parses the destination hostname and IP address.
		/// </summary>
		/// <param name="data">The hop data string.</param>
		private void ParseDestination(string data)
		{
			// Get the matching IP address.
			Match match = Regex.Match(data, MercuryTracerouteHop.regexLinuxDestination);

			// If the hop string matches a destination.
			if (match.Success)
			{
				// Get the tokens.
				string[] tokens = match.Value.Split(MercuryTracerouteHop.separatorSpaceRoundBrackets, StringSplitOptions.RemoveEmptyEntries);
				// Check the match contains two tokens.
				if (tokens.Length < 2) throw new FormatException("The data string \'{0}\' does not contain a complete destination.".FormatWith(data));
				// Get the hostname from the first token.
				this.Hostname = tokens[tokens.Length - 2];
				// Get the IP address from the second token.
				this.Address = IPAddress.Parse(tokens[tokens.Length - 1]);
			}
			else
			{
				// The IP address.
				IPAddress address;
				// Parse the IP address.
				MercuryTracerouteHop.TryParseIp(data, out address);
				// Set the address.
				this.Address = address;
				// Set the hostname to null.
				this.Hostname = null;
			}
		}

		/// <summary>
		/// Parses the autonomous system numbers.
		/// </summary>
		/// <param name="data">The hop data string.</param>
		private void ParseAsNumbers(string data)
		{
			// Get the matching autonomous system numbers.
			Match match = Regex.Match(data, MercuryTracerouteHop.regexAs);

			// If the hop string matches the AS numbers.
			if (match.Success)
			{
				// Get the tokens.
				string[] tokens = match.Value.Split(MercuryTracerouteHop.separatorAsNumbers, StringSplitOptions.RemoveEmptyEntries);
				// Allocate the AS numbers array.
				this.AutonomousSystems = new int[tokens.Length];
				// Parse each token.
				for (int index = 0; index < tokens.Length; index++)
				{
					this.AutonomousSystems[index] = int.Parse(tokens[index]);
				}
			}
			else
			{
				// Set the AS numbers to null.
				this.AutonomousSystems = null;
			}
		}

		/// <summary>
		/// Parses the round-trip time.
		/// </summary>
		/// <param name="data">The hop data string.</param>
		private void ParseRtt(string data)
		{
			// Get the matches for the RTT information.
			MatchCollection matches = Regex.Matches(data, MercuryTracerouteHop.regexRtt);

			// If the number of matches is greater than zero.
			if (matches.Count > 0)
			{
				// Allocate the RTT array.
				this.Rtt = new double[matches.Count];

				// Parse each match.
				int index = 0;
				foreach (Match match in matches)
				{
					this.Rtt[index++] = double.Parse(match.Value.Split(MercuryTracerouteHop.separatorRtt, StringSplitOptions.RemoveEmptyEntries).First(), CultureInfo.InvariantCulture);
				}
			}
			else
			{
				// Set the RTT data to null.
				this.Rtt = null;
			}
		}

		/// <summary>
		/// Parses a bracketed IP address in the specified data string.
		/// </summary>
		/// <param name="data">The data string.</param>
		/// <param name="address">The IP address.</param>
		/// <returns><b>True</b> if the parsing was successful, <b>false</b> otherwise.</returns>
		private static bool TryParseIp(string data, out IPAddress address)
		{
			// Get the matching IP address.
			Match match = Regex.Match(data, MercuryTracerouteHop.regexIp);

			if (match.Success)
			{
				// Parse the IP address.
				return IPAddress.TryParse(match.Value, out address);
			}

			// Set the IP address to null.
			address = null;
			// Return false.
			return false;
		}

		/// <summary>
		/// Parses the hop number.
		/// </summary>
		/// <param name="data">The hop data string.</param>
		private static int ParseLinuxHopNumber(string data)
		{
			// Find the match for the hop number.
			Match match = Regex.Match(data, MercuryTracerouteHop.regexHop);

			// If the match is not successful, throw a format exception.
			if (!match.Success) throw new FormatException("The traceroute line \'{0}\' does not contain a hop number.".FormatWith(data));

			// Else, parse the first token.
			return int.Parse(match.Value.Split(MercuryTracerouteHop.separatorSpace, StringSplitOptions.RemoveEmptyEntries).First());
		}
	}
}
