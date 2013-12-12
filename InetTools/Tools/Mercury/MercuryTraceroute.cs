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
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using DotNetApi;

namespace InetTools.Tools.Mercury
{
	/// <summary>
	/// A class that represents a Mercury traceroute.
	/// </summary>
	public sealed class MercuryTraceroute
	{
		private static readonly string regexHeaderLinux = @"traceroute to .+ \([0-9]+\.[0-9]+\.[0-9]+\.[0-9]+\), [0-9]+ hops max, [0-9]+ byte packets";
		private static readonly string regexHeaderLinuxHostname = @"traceroute to .+? ";
		private static readonly string regexHeaderLinuxMaxHops = @"[0-9]+ hops max";
		private static readonly string regexHeaderLinuxPacketSize = @"[0-9]+ byte packets";
		private static readonly string regexIpBrackets = @"\([0-9]+\.[0-9]+\.[0-9]+\.[0-9]+\)";

		private static readonly string[] separatorLine = { "\n", "\r\n" };
		private static readonly char[] separatorRoundBrackets = { '(', ')' };
		private static readonly char[] separatorSpace = { ' ' };

		public readonly Guid id;
		public readonly string sourceHostname;
		public readonly IPAddress sourceIp;
		public string destinationHostname;
		public IPAddress destinationIp;
		public int? maxHops;
		public int? packetSize;
		public readonly List<MercuryTracerouteHop> hops = new List<MercuryTracerouteHop>();

		/// <summary>
		/// Creates a new traceroute instance by parsing the specified data.
		/// </summary>
		/// <param name="id">The traceroute identifier.</param>
		/// <param name="sourceHostname">The source hostname.</param>
		/// <param name="sourceIp">The source IP address.</param>
		/// <param name="data">The traceroute data.</param>
		public MercuryTraceroute(Guid id, string sourceHostname, IPAddress sourceIp, string data)
		{
			// Set the source information.
			this.id = id;
			this.sourceHostname = sourceHostname;
			this.sourceIp = sourceIp;

			// Check whether the this is a Linux traceroute.
			if (Regex.IsMatch(data, MercuryTraceroute.regexHeaderLinux))
			{
				// Parse a Linux traceroute.
				this.ParseLinux(data);
			}
			else throw new FormatException("The data string is not a traceroute.");
		}

		// Public methods.

		/// <summary>
		/// Gets the traceroute identifier.
		/// </summary>
		public Guid Id { get { return this.id; } }
		/// <summary>
		/// Gets the source IP address.
		/// </summary>
		public IPAddress SourceIp { get { return this.sourceIp; } }
		/// <summary>
		/// Gets the destination IP address.
		/// </summary>
		public IPAddress DestinationIp { get { return this.destinationIp; } }
		/// <summary>
		/// Gets the source hostname.
		/// </summary>
		public string SourceHostname { get { return this.sourceHostname; } }
		/// <summary>
		/// Gets the destination hostname.
		/// </summary>
		public string DestinationHostname { get { return this.destinationHostname; } }
		/// <summary>
		/// Gets the maximum number of hops.
		/// </summary>
		public int? MaximumHops { get { return this.maxHops; } }
		/// <summary>
		/// Gets the packet size.
		/// </summary>
		public int? PacketSize { get { return this.packetSize; } }
		/// <summary>
		/// Gets the list of hops for this trace.
		/// </summary>
		public IEnumerable<MercuryTracerouteHop> Hops { get { return this.hops; } }

		// Private methods.

		/// <summary>
		/// Parses a Linux traceroute.
		/// </summary>
		/// <param name="data">The traceroute data.</param>
		private void ParseLinux(string data)
		{
			// Get the traceroute data lines.
			string[] lines = data.Split(MercuryTraceroute.separatorLine, StringSplitOptions.RemoveEmptyEntries);

			// Check the number of lines.
			if (lines.Length == 0) throw new FormatException("The traceroute data string must have at least one non-empty line.");

			// Parse the traceroute header.
			this.ParseLinuxHeader(lines[0]);

			// Parse the remaining lines into traceroute hops.
			for (int index = 1; index < lines.Length; index++)
			{
				// Parse and add to the list of hops.
				this.hops.Add(MercuryTracerouteHop.ParseLinux(lines[index]));
			}
		}

		/// <summary>
		/// Parses the header of a Linux traceroute.
		/// </summary>
		/// <param name="data">The traceroute data.</param>
		private void ParseLinuxHeader(string data)
		{
			// Get the destination IP address.
			this.destinationIp = MercuryTraceroute.ParseBracketIp(data);
			// Try parse the destination hostname.
			MercuryTraceroute.TryParseLinuxDestination(data, out this.destinationHostname);
			// Try parse the maximum hops.
			MercuryTraceroute.TryParseLinuxMaximumHops(data, out this.maxHops);
			// Try parse the packet size.
			MercuryTraceroute.TryParseLinuxPacketSize(data, out this.packetSize);
		}

		/// <summary>
		/// Parses a bracketed IP address in the specified data string.
		/// </summary>
		/// <param name="data">The data string.</param>
		/// <returns>The IP address.</returns>
		private static IPAddress ParseBracketIp(string data)
		{
			// Get the matching IP address.
			Match match = Regex.Match(data, MercuryTraceroute.regexIpBrackets);
			
			// If the match was not successfull, throw a format exception.
			if (!match.Success) throw new FormatException("The data string \'{0}\' does not contain a bracketed IP address.".FormatWith(data));

			// Parse the IP address.
			return IPAddress.Parse(match.Value.Split(MercuryTraceroute.separatorRoundBrackets, StringSplitOptions.RemoveEmptyEntries).First());
		}

		/// <summary>
		/// Tries to parse the destination from a Linux traceroute.
		/// </summary>
		/// <param name="data">The data string.</param>
		/// <param name="destination">The destination.</param>
		/// <returns><b>True</b> if the parse was successful, <b>false</b> otherwise.</returns>
		private static bool TryParseLinuxDestination(string data, out string destination)
		{
			// Get the destination hostname.
			Match matchDestination = Regex.Match(data, MercuryTraceroute.regexHeaderLinuxHostname);

			// If the destination is matched.
			if (matchDestination.Success)
			{
				// Get the tokens.
				string[] tokens = matchDestination.Value.Split(MercuryTraceroute.separatorSpace, StringSplitOptions.RemoveEmptyEntries);

				// Check the number of tokens is three.
				if (tokens.Length == 3)
				{
					// The destination is the third token.
					destination = tokens[2];
					// Return true.
					return true;
				}
			}
			// Set the destination to null.
			destination = null;
			// Return false.
			return false;
		}

		/// <summary>
		/// Tries to parse the maximum number of hops from a Linux traceroute.
		/// </summary>
		/// <param name="data">The data string.</param>
		/// <param name="maxHops">The maximum number of hops.</param>
		/// <returns><b>True</b> if the parse was successful, <b>false</b> otherwise.</returns>
		private static bool TryParseLinuxMaximumHops(string data, out int? maxHops)
		{
			// Get the destination hostname.
			Match matchDestination = Regex.Match(data, MercuryTraceroute.regexHeaderLinuxMaxHops);

			// If the destination is matched.
			if (matchDestination.Success)
			{
				// Get the tokens.
				string[] tokens = matchDestination.Value.Split(MercuryTraceroute.separatorSpace, StringSplitOptions.RemoveEmptyEntries);

				// Check the number of tokens is three.
				if (tokens.Length == 3)
				{
					// The result.
					int result;
					// Parse the first token.
					if (int.TryParse(tokens[0], out result))
					{
						// Set the maximum hops.
						maxHops = result;
						// Return true.
						return true;
					}
				}
			}
			// Set the maximum hops.
			maxHops = null;
			// Return false.
			return false;
		}

		/// <summary>
		/// Tries to parse the packet size from a Linux traceroute.
		/// </summary>
		/// <param name="data">The data string.</param>
		/// <param name="packetSize">The traceroute packet size.</param>
		/// <returns><b>True</b> if the parse was successful, <b>false</b> otherwise.</returns>
		private static bool TryParseLinuxPacketSize(string data, out int? packetSize)
		{
			// Get the destination hostname.
			Match matchDestination = Regex.Match(data, MercuryTraceroute.regexHeaderLinuxPacketSize);

			// If the destination is matched.
			if (matchDestination.Success)
			{
				// Get the tokens.
				string[] tokens = matchDestination.Value.Split(MercuryTraceroute.separatorSpace, StringSplitOptions.RemoveEmptyEntries);

				// Check the number of tokens is three.
				if (tokens.Length == 3)
				{
					// The result.
					int result;
					// Parse the first token.
					if (int.TryParse(tokens[0], out result))
					{
						// Set the packet size.
						packetSize = result;
						// Return true.
						return true;
					}
				}
			}
			// Set the packet size to null.
			packetSize = null;
			// Return false.
			return false;
		}
	}
}
