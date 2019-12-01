using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace AesCryptographyLibrary
{
	public static class Decryption
	{
		public static string DecryptCypherText(string cypherText)
		{
			const string encryptionKey = "123g2910a3qw34b1986rf9k8n63y3d1i";
			var cipherBytes = Convert.FromBase64String(cypherText);

			using (var encryptor = Aes.Create())
			{
				var pdb = new Rfc2898DeriveBytes(encryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
				encryptor.Key = pdb.GetBytes(32);
				encryptor.IV = pdb.GetBytes(16);

				using (var ms = new MemoryStream())
				{
					using (var cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
					{
						cs.Write(cipherBytes, 0, cipherBytes.Length);
						cs.Close();
					}

					cypherText = Encoding.Unicode.GetString(ms.ToArray());
				} // end using

				pdb.Dispose();
			} // end using

			return cypherText;
		} // end DecryptCypherText
	} // end class
} // end namespace
