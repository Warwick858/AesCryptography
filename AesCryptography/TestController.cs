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