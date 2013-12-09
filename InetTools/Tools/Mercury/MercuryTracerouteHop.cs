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
	/// A class representing a traceroute hop.
	/// </summary>
	public struct MercuryTracerouteHop
	{
		private static readonly char[] separatorLine = { ' ', '\n' };
		private static readonly char[] separatorAddress = { '(', ')' };
		private static readonly char[] separatorAs = { '[', ']', '/', '*' };
		private static readonly char[] separatorAsNumber = { 'A', 'S' };

		/// <summary>
		/// Creates a new traceroute hop instance.
		/// </summary>
		/// <param name="data">The traceroute data line.</param>
		public MercuryTracerouteHop(string data)
			: this()
		{
			// Parse the data string.
			this.Parse(data);
		}

		// Public fields.

		/// <summary>
		/// The hop TTL.
		/// </summary>
		public int Ttl { get; private set; }
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
		public TimeSpan?[] Rtt { get; private set; }

		// Private methods.

		/// <summary>
		/// Parses the data string into a traceroute hop structure.
		/// </summary>
		/// <param name="data">The data string.</param>
		private void Parse(string data)
		{
			// Validate the arguments.
			if (null == data) throw new ArgumentNullException(data);

			// Split the data string into tokens.
			string[] tokens = data.Split(MercuryTracerouteHop.separatorLine, StringSplitOptions.RemoveEmptyEntries);

			// If the tokens list is empty, throw an exception.
			if (tokens.Length == 0) throw new FormatException("The specified string is not a traceroute hop data ({0}).".FormatWith(data));

			// The first token is always the hop TTL.
			this.Ttl =  int.Parse(tokens[0]);

			// A flag indicating whether the hop information has been parsed.
			bool found = false;

			// The RTT list.
			List<TimeSpan?> rtt = new List<TimeSpan?>();

			// Parse the remaining tokens.
			for (int index = 0; index < tokens.Length; )
			{
				// If the token is equal to a star.
				if (tokens[index++] == "*")
				{
					// The current RTT is unknown.
					rtt.Add(null);
					// Continue to the next token.
					continue;
				}
				else if (!found)
				{
					// Parse the hop information.
					this.ParseHop(ref tokens, ref index);

					// Set the found token to true.
					found = true;
				}
				else
				{
					// Parse the RTT information.
					this.ParseRtt(ref tokens, ref index, ref rtt);
				}
			}
		}

		private void ParseHop(ref string[] tokens, ref int index)
		{
			// If the next token matches round brackets.
			if (MercuryTracerouteHop.IsMatch(ref tokens, index + 1, @"\(.+\)"))
			{
				// The current token represents the hostname.
				this.Hostname = tokens[index++];
				// The next token represents the IP address.
				this.Address = IPAddress.Parse(tokens[index++].Split(MercuryTracerouteHop.separatorAddress, StringSplitOptions.RemoveEmptyEntries).First());
			}
			else
			{
				// The current token represents the IP address.
				this.Address = IPAddress.Parse(tokens[index++]);
			}

			// If the next token matches square brackets.
			if (MercuryTracerouteHop.IsMatch(ref tokens, index, @"\[.+\]"))
			{
				// Parse the next token for information on the AS numbers.
				this.ParseAs(tokens[index++].Split(MercuryTracerouteHop.separatorAs));
			}
		}

		private void ParseAs(string[] tokens)
		{
			List<int> asNumbers = new List<int>();

			// For all tokens corresponding to an AS number.
			foreach (string token in tokens)
			{
				// Check the token corresponds to an AS number.
				if (MercuryTracerouteHop.IsMatch(token, "AS[0-9]+"))
				{
					asNumbers.Add(int.Parse(token.Split(MercuryTracerouteHop.separatorAsNumber, StringSplitOptions.RemoveEmptyEntries).First()));
				}
			}
		}

		private void ParseRtt(ref string[] tokens, ref int index, ref List<TimeSpan?> rtt)
		{

		}

		private static bool IsMatch(string token, string pattern)
		{
			// Else use the regular expressions to match the token.
			return Regex.Match(token, pattern, RegexOptions.CultureInvariant).Length == token.Length;
		}

		/// <summary>
		/// Checks whether the token at the specified index matches the regular expression.
		/// </summary>
		/// <param name="tokens">The list of tokens.</param>
		/// <param name="index">The index</param>
		/// <param name="pattern">The regular expression pattern.</param>
		/// <returns><b>True</b> if the token matches, <b>false</b> otherwise or if the token does not exist.</returns>
		private static bool IsMatch(ref string[] tokens, int index, string pattern)
		{
			// If the index is outside the list of tokens, return false.
			if (index >= tokens.Length) return false;
			// Else use the regular expressions to match the token.
			return MercuryTracerouteHop.IsMatch(tokens[index], pattern);
		}
	}
}
