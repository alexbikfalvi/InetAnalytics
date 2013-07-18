/* 
 * Copyright (C) 2012 Alex Bikfalvi
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
using System.Security;
using DotNetApi.Security;

namespace YtCrawler
{
	/// <summary>
	/// A class used to encrypt and decrypt security-sensitive configuration data.
	/// </summary>
	public static class CrawlerCrypto
	{
		private static byte[] cryptoKey = {155, 181, 197, 167, 41, 252, 217, 150, 25, 158, 203, 88, 187, 162, 110, 28, 215, 36, 26, 6, 146, 170, 29, 221, 182, 144, 72, 69, 2, 91, 132, 31};
		private static byte[] cryptoIV = {61, 135, 168, 42, 118, 126, 73, 70, 125, 92, 153, 57, 60, 201, 77, 131};

		/// <summary>
		/// Encrypts the specified string into a byte array.
		/// </summary>
		/// <param name="value">The string to encrypt.</param>
		/// <returns>The encrypted string as a byte array.</returns>
		public static byte[] EncryptString(this SecureString value)
		{
			return value.EncryptSecureStringAes(CrawlerCrypto.cryptoKey, CrawlerCrypto.cryptoIV);
		}

		/// <summary>
		/// Decrypts the specified byte array buffer into a string.
		/// </summary>
		/// <param name="value">The byte array to decrypt.</param>
		/// <returns>The descrypted data as a string.</returns>
		public static SecureString DecryptString(this byte[] value)
		{
			return value.DecryptSecureStringAes(CrawlerCrypto.cryptoKey, CrawlerCrypto.cryptoIV);
		}
	}
}
