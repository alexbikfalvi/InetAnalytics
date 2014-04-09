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
using System.Globalization;

namespace InetApi.Net.Core.Dns
{
	/// <summary>
	/// <para>Location information</para> <para>Defined in <see cref="http://tools.ietf.org/html/rfc1876">RFC 1876</see>.</para>
	/// </summary>
	public class LocRecord : DnsRecordBase
	{
		/// <summary>
		/// Represents a geopgraphical degree.
		/// </summary>
		public class Degree
		{
			/// <summary>
			/// Is negative value.
			/// </summary>
			public bool IsNegative { get; private set; }
			/// <summary>
			/// Number of full degrees.
			/// </summary>
			public int Degrees { get; private set; }
			/// <summary>
			/// Number of minutes.
			/// </summary>
			public int Minutes { get; private set; }
			/// <summary>
			/// Number of seconds.
			/// </summary>
			public int Seconds { get; private set; }
			/// <summary>
			/// Number of milliseconds.
			/// </summary>
			public int Milliseconds { get; private set; }
			/// <summary>
			/// Returns the decimal representation of the degree instance.
			/// </summary>
			public double DecimalDegrees
			{
				get { return (this.IsNegative ? -1d : 1d) * (this.Degrees + (double) this.Minutes / 6000 * 100 + (this.Seconds + (double) this.Milliseconds / 1000) / 360000 * 100); }
			}

			/// <summary>
			/// Creates a new instance of the Degree class.
			/// </summary>
			/// <param name="isNegative">Is negative value.</param>
			/// <param name="degrees">Number of full degrees.</param>
			/// <param name="minutes">Number of minutes.</param>
			/// <param name="seconds">Number of seconds.</param>
			/// <param name="milliseconds">Number of milliseconds.</param>
			public Degree(bool isNegative, int degrees, int minutes, int seconds, int milliseconds)
			{
				this.IsNegative = isNegative;
				this.Degrees = degrees;
				this.Minutes = minutes;
				this.Seconds = seconds;
				this.Milliseconds = milliseconds;
			}

			/// <summary>
			/// Creates a new instance of the Degree class
			/// </summary>
			/// <param name="decimalDegrees">Decimal representation of the degree.</param>
			public Degree(double decimalDegrees)
			{
				if (decimalDegrees < 0)
				{
					this.IsNegative = true;
					decimalDegrees = -decimalDegrees;
				}

				this.Degrees = (int)decimalDegrees;
				decimalDegrees -= Degrees;
				decimalDegrees *= 60;
				this.Minutes = (int)decimalDegrees;
				decimalDegrees -= Minutes;
				decimalDegrees *= 60;
				this.Seconds = (int)decimalDegrees;
				decimalDegrees -= Seconds;
				decimalDegrees *= 1000;
				this.Milliseconds = (int)decimalDegrees;
			}
		}

		/// <summary>
		/// Internal constructor.
		/// </summary>
		internal LocRecord() { }

		/// <summary>
		/// Creates a new instance of the LocRecord class.
		/// </summary>
		/// <param name="name">Name of the record.</param>
		/// <param name="timeToLive">Seconds the record should be cached at most.</param>
		/// <param name="version">Version number of representation.</param>
		/// <param name="size">Size of location in centimeters.</param>
		/// <param name="horizontalPrecision">Horizontal precision in centimeters.</param>
		/// <param name="verticalPrecision">Vertical precision in centimeters.</param>
		/// <param name="latitude">Latitude of the geographical position.</param>
		/// <param name="longitude">Longitude of the geographical position.</param>
		/// <param name="altitude">Altitude of the geographical position.</param>
		public LocRecord(string name, int timeToLive, byte version, double size, double horizontalPrecision, double verticalPrecision, Degree latitude, Degree longitude, double altitude)
			: base(name, RecordType.Loc, RecordClass.INet, timeToLive)
		{
			this.Version = version;
			this.Size = size;
			this.HorizontalPrecision = horizontalPrecision;
			this.VerticalPrecision = verticalPrecision;
			this.Latitude = latitude;
			this.Longitude = longitude;
			this.Altitude = altitude;
		}

		/// <summary>
		/// Version number of representation.
		/// </summary>
		public byte Version { get; private set; }
		/// <summary>
		/// Size of location in centimeters.
		/// </summary>
		public double Size { get; private set; }
		/// <summary>
		/// Horizontal precision in centimeters.
		/// </summary>
		public double HorizontalPrecision { get; private set; }
		/// <summary>
		/// Vertical precision in centimeters.
		/// </summary>
		public double VerticalPrecision { get; private set; }
		/// <summary>
		/// Latitude of the geographical position.
		/// </summary>
		public Degree Latitude { get; private set; }
		/// <summary>
		/// Longitude of the geographical position.
		/// </summary>
		public Degree Longitude { get; private set; }
		/// <summary>
		/// Altitude of the geographical position.
		/// </summary>
		public double Altitude { get; private set; }

		// Protected properties.

		/// <summary>
		/// Gets the maximum record data length.
		/// </summary>
		protected internal override int MaximumRecordDataLength
		{
			get { return 16; }
		}

		// Internal methods.

		/// <summary>
		/// Parses the record data.
		/// </summary>
		/// <param name="resultData">The result data.</param>
		/// <param name="startPosition">The start position.</param>
		/// <param name="length">The length.</param>
		internal override void ParseRecordData(byte[] resultData, int currentPosition, int length)
		{
			this.Version = resultData[currentPosition++];
			this.Size = ConvertPrecision(resultData[currentPosition++]);
			this.HorizontalPrecision = ConvertPrecision(resultData[currentPosition++]);
			this.VerticalPrecision = ConvertPrecision(resultData[currentPosition++]);
			this.Latitude = ConvertDegree(DnsMessageBase.ParseInt(resultData, ref currentPosition));
			this.Longitude = ConvertDegree(DnsMessageBase.ParseInt(resultData, ref currentPosition));
			this.Altitude = ConvertAltitude(DnsMessageBase.ParseInt(resultData, ref currentPosition));
		}

		/// <summary>
		/// Converts the record data to a string.
		/// </summary>
		/// <returns>The record data string.</returns>
		internal override string RecordDataToString()
		{
			return this.Latitude.Degrees
				   + (((this.Latitude.Minutes != 0) || (this.Latitude.Seconds != 0) || (this.Latitude.Milliseconds != 0)) ? " " + this.Latitude.Minutes : "")
				   + (((this.Latitude.Seconds != 0) || (this.Latitude.Milliseconds != 0)) ? " " + this.Latitude.Seconds : "")
				   + ((this.Latitude.Milliseconds != 0) ? "." + this.Latitude.Milliseconds : "")
				   + " " + (this.Latitude.IsNegative ? "S" : "N")
				   + " " + this.Longitude.Degrees
				   + (((this.Longitude.Minutes != 0) || (this.Longitude.Seconds != 0) || (this.Longitude.Milliseconds != 0)) ? " " + this.Longitude.Minutes : "")
				   + (((this.Longitude.Seconds != 0) || (this.Longitude.Milliseconds != 0)) ? " " + this.Longitude.Seconds : "")
				   + ((this.Longitude.Milliseconds != 0) ? "." + this.Longitude.Milliseconds : "")
				   + " " + (this.Longitude.IsNegative ? "W" : "E")
				   + " " + this.Altitude.ToString(CultureInfo.InvariantCulture) + "m"
				   + (((this.Size != 1) || (this.HorizontalPrecision != 10000) || (this.VerticalPrecision != 10)) ? " " + this.Size + "m" : "")
				   + (((this.HorizontalPrecision != 10000) || (this.VerticalPrecision != 10)) ? " " + this.HorizontalPrecision + "m" : "")
				   + ((this.VerticalPrecision != 10) ? " " + this.VerticalPrecision + "m" : "");
		}

		// Protected methods.

		/// <summary>
		/// Encodes the data for this record.
		/// </summary>
		/// <param name="messageData">The message data.</param>
		/// <param name="offset">The offset.</param>
		/// <param name="currentPosition">The current position.</param>
		/// <param name="domainNames">The domain names.</param>
		protected internal override void EncodeRecordData(byte[] messageData, int offset, ref int currentPosition, Dictionary<string, ushort> domainNames)
		{
			messageData[currentPosition++] = this.Version;
			messageData[currentPosition++] = ConvertPrecision(this.Size);
			messageData[currentPosition++] = ConvertPrecision(this.HorizontalPrecision);
			messageData[currentPosition++] = ConvertPrecision(this.VerticalPrecision);
			DnsMessageBase.EncodeInt(messageData, ref currentPosition, ConvertDegree(this.Latitude));
			DnsMessageBase.EncodeInt(messageData, ref currentPosition, ConvertDegree(this.Longitude));
			DnsMessageBase.EncodeInt(messageData, ref currentPosition, ConvertAltitude(this.Altitude));
		}

		// Private methods.

		#region Convert Precision
		private static readonly int[] _POWER_OFTEN = new int[] { 1, 10, 100, 1000, 10000, 100000, 1000000, 10000000, 100000000, 1000000000 };

		private static double ConvertPrecision(byte precision)
		{
			int mantissa = ((precision >> 4) & 0x0f) % 10;
			int exponent = (precision & 0x0f) % 10;
			return mantissa * (double) _POWER_OFTEN[exponent] / 100;
		}

		private static byte ConvertPrecision(double precision)
		{
			double centimeters = (precision * 100);

			int exponent;
			for (exponent = 0; exponent < 9; exponent++)
			{
				if (centimeters < _POWER_OFTEN[exponent + 1])
					break;
			}

			int mantissa = (int) (centimeters / _POWER_OFTEN[exponent]);
			if (mantissa > 9)
				mantissa = 9;

			return (byte) ((mantissa << 4) | exponent);
		}
		#endregion

		#region Convert Degree
		private static Degree ConvertDegree(int degrees)
		{
			degrees -= (1 << 31);

			bool isNegative;
			if (degrees < 0)
			{
				isNegative = true;
				degrees = -degrees;
			}
			else
			{
				isNegative = false;
			}

			int milliseconds = degrees % 1000;
			degrees /= 1000;
			int seconds = degrees % 60;
			degrees /= 60;
			int minutes = degrees % 60;
			degrees /= 60;

			return new Degree(isNegative, degrees, minutes, seconds, milliseconds);
		}

		private static int ConvertDegree(Degree degrees)
		{
			int res = degrees.Degrees * 3600000 + degrees.Minutes * 60000 + degrees.Seconds * 1000 + degrees.Milliseconds;

			if (degrees.IsNegative)
				res = -res;

			return res + (1 << 31);
		}
		#endregion

		#region Convert Altitude
		private const int _ALTITUDE_REFERENCE = 10000000;

		private static double ConvertAltitude(int altitude)
		{
			return ((altitude < _ALTITUDE_REFERENCE) ? ((_ALTITUDE_REFERENCE - altitude) * -1) : (altitude - _ALTITUDE_REFERENCE)) / 100d;
		}

		private static int ConvertAltitude(double altitude)
		{
			int centimeter = (int) (altitude * 100);
			return ((centimeter > 0) ? (_ALTITUDE_REFERENCE + centimeter) : (centimeter + _ALTITUDE_REFERENCE));
		}
		#endregion
	}
}