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
//  any later version.
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
using AesCryptographyLibrary;
using NUnit.Framework;

namespace AesCryptography
{
	[TestFixture]
	public class TestController
	{
		[Test]
		[TestCase("this is a test", "rUkSu2jMh86Snu4t5K4GB/BFRYeGpCHaRqUZsPpdIW4=")]
		public void EncryptCypherText_Test(string txtToEncrypt, string encryptedTxt)
		{
			var result = Encryption.EncryptCypherText(txtToEncrypt);
			Assert.AreEqual(result, encryptedTxt);
		}

		[Test]
		[TestCase("rUkSu2jMh86Snu4t5K4GB/BFRYeGpCHaRqUZsPpdIW4=", "this is a test")]
		public void DecrypttCypherText_Test(string txtToDecrypt, string decryptedTxt)
		{
			var result = Decryption.DecryptCypherText(txtToDecrypt);
			Assert.AreEqual(result, decryptedTxt);
		}
	}
}