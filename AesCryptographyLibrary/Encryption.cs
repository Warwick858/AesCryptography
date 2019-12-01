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
