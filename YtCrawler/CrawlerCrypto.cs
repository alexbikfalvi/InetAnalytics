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
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace YtCrawler
{
	public sealed class CrawlerCrypto
	{
		private static byte[] cryptoKey = {155, 181, 197, 167, 41, 252, 217, 150, 25, 158, 203, 88, 187, 162, 110, 28, 215, 36, 26, 6, 146, 170, 29, 221, 182, 144, 72, 69, 2, 91, 132, 31};
		private static byte[] cryptoIV = {61, 135, 168, 42, 118, 126, 73, 70, 125, 92, 153, 57, 60, 201, 77, 131};

		public static byte[] Encrypt(string value)
		{
			if (null == value) return null;

			UTF8Encoding utf8Encoder = new UTF8Encoding();
			byte[] bytes = utf8Encoder.GetBytes(value);
		
			AesCryptoServiceProvider aesProvider = new AesCryptoServiceProvider();
			ICryptoTransform cryptoTransform = aesProvider.CreateEncryptor(CrawlerCrypto.cryptoKey, CrawlerCrypto.cryptoIV);

			MemoryStream encryptedStream = new MemoryStream();
			CryptoStream cryptStream = new CryptoStream(encryptedStream, cryptoTransform, CryptoStreamMode.Write);

			cryptStream.Write(bytes, 0, bytes.Length);
			cryptStream.FlushFinalBlock();
			encryptedStream.Position = 0;

			byte[] result = new byte[encryptedStream.Length];
			encryptedStream.Read(result, 0, (int)encryptedStream.Length);

			cryptStream.Close();

			return result;
		}

		public static string Decrypt(byte[] value)
		{
			if (null == value) return null;

			UTF8Encoding utf8Encoding = new UTF8Encoding();
		
			AesCryptoServiceProvider aesProvider = new AesCryptoServiceProvider();

			//aesProvider.GenerateIV();
			//aesProvider.GenerateKey();

			ICryptoTransform cryptoTransform = aesProvider.CreateDecryptor(CrawlerCrypto.cryptoKey, CrawlerCrypto.cryptoIV);

			MemoryStream decryptedStream = new MemoryStream();
			CryptoStream cryptStream = new CryptoStream(decryptedStream, cryptoTransform, CryptoStreamMode.Write);

			cryptStream.Write(value, 0, value.Length);
			cryptStream.FlushFinalBlock();
			decryptedStream.Position = 0;

			byte[] result = new byte[decryptedStream.Length];
			decryptedStream.Read(result, 0, (int)decryptedStream.Length);

			cryptStream.Close();

			return utf8Encoding.GetString(result);
		}
	}
}
