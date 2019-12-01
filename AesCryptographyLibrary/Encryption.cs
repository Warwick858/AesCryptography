// ******************************************************************************************************************
//  This file is part of AesCryptography.
//
//  AesCryptography - Simple AES encrypt and decrypt example.
//  Copyright(C)  2019  James LoForti
//  Contact Info: jamesloforti@gmail.com
//
//  AesCryptography is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see<https://www.gnu.org/licenses/>.
//									     ____.           .____             _____  _______   
//									    |    |           |    |    ____   /  |  | \   _  \  
//									    |    |   ______  |    |   /  _ \ /   |  |_/  /_\  \ 
//									/\__|    |  /_____/  |    |__(  <_> )    ^   /\  \_/   \
//									\________|           |_______ \____/\____   |  \_____  /
//									                             \/          |__|        \/ 
//
// ******************************************************************************************************************
//
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace AesCryptographyLibrary
{
	public static class Encryption
	{
		public static string EncryptCypherText(string plainText)
		{
			const string encryptionKey = "123g2910a3qw34b1986rf9k8n63y3d1i";
			var plainBytes = Encoding.Unicode.GetBytes(plainText);

			using (var encryptor = Aes.Create())
			{
				var pdb = new Rfc2898DeriveBytes(encryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
				encryptor.Key = pdb.GetBytes(32);
				encryptor.IV = pdb.GetBytes(16);

				using (var ms = new MemoryStream())
				{
					using (var cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
					{
						cs.Write(plainBytes, 0, plainBytes.Length);
						cs.Close();
					}

					plainText = Convert.ToBase64String(ms.ToArray());
				} // end using

				pdb.Dispose();
			} // end using

			return plainText;
		} // end DecryptCypherText
	} // end class
} // end namespace
