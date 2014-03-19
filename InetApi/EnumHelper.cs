/* 
 * Copyright (C) 2010-2012 Alexander Reinert
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * 
 *   http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Collections.Generic;

namespace ARSoft.Tools.Net
{
	/// <summary>
	/// A helper class for an enumeration type.
	/// </summary>
	/// <typeparam name="T">The enumeration type.</typeparam>
	internal static class EnumHelper<T> where T : struct
	{
		private static readonly Dictionary<T, string> names;
		private static readonly Dictionary<string, T> values;

		/// <summary>
		/// Static constructor.
		/// </summary>
		static EnumHelper()
		{
			string[] names = Enum.GetNames(typeof (T));
			T[] values = (T[]) Enum.GetValues(typeof (T));

			EnumHelper<T>.names = new Dictionary<T, string>(names.Length);
			EnumHelper<T>.values = new Dictionary<string, T>(names.Length * 2);

			for (int i = 0; i < names.Length; i++)
			{
				EnumHelper<T>.names[values[i]] = names[i];
				EnumHelper<T>.values[names[i]] = values[i];
				EnumHelper<T>.values[names[i].ToLower()] = values[i];
			}
		}

		#region Public properties

		/// <summary>
		/// Gets the names of the enumeration values.
		/// </summary>
		public static Dictionary<T, string> Names
		{
			get { return EnumHelper<T>.names; }
		}

		#endregion

		#region Public methods

		/// <summary>
		/// Tries to parse a string for an enumeration value.
		/// </summary>
		/// <param name="s">The string.</param>
		/// <param name="ignoreCase">If <b>true</b> the parsing ignores the case.</param>
		/// <param name="value">The enumeration value.</param>
		/// <returns><b>True</b> if the corresponding enumeration value was found, <b>false</b> otherwise.</returns>
		public static bool TryParse(string s, bool ignoreCase, out T value)
		{
			if (String.IsNullOrEmpty(s))
			{
				value = default(T);
				return false;
			}

			return EnumHelper<T>.values.TryGetValue((ignoreCase ? s.ToLower() : s), out value);
		}

		/// <summary>
		/// Converts the enumeration value to a string.
		/// </summary>
		/// <param name="value">The enumeration value.</param>
		/// <returns>The string.</returns>
		public static string ToString(T value)
		{
			string res;
			return EnumHelper<T>.names.TryGetValue(value, out res) ? res : Convert.ToInt64(value).ToString();
		}

		#endregion

		#region Internal methods

		/// <summary>
		/// Parses a string to an enumeration value.
		/// </summary>
		/// <param name="s">The string.</param>
		/// <param name="ignoreCase">If <b>true</b> the parsing ignores the case.</param>
		/// <param name="defaultValue">The default value to return if the string is not found.</param>
		/// <returns>The enumeration value.</returns>
		internal static T Parse(string s, bool ignoreCase, T defaultValue)
		{
			T res;
			return TryParse(s, ignoreCase, out res) ? res : defaultValue;
		}

		#endregion
	}
}