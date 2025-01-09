using System;
using System.Security.Cryptography;
using System.Text;

namespace Security_Cryptography
{
    internal class RijndaelDemo
    {
        private static RijndaelManaged _rijndael = new RijndaelManaged();
        private static string key = "12345678901234567890123456789012";
        private static string iv = "1234567890123456";
        public static string EncryptByRijndael(string data)
        {
            byte[] keybytes = Encoding.UTF8.GetBytes(key);
            byte[] ivbytes = Encoding.UTF8.GetBytes(iv);

            _rijndael.Key = keybytes;
            _rijndael.IV = ivbytes;

            ICryptoTransform encryptor = _rijndael.CreateEncryptor(_rijndael.Key, _rijndael.IV);
            byte[] encBytes;
            using (MemoryStream ms = new MemoryStream())   // stores encrypted or decrypted data in memory
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))   // links memory stream with encryptor
                {
                    using (StreamWriter sw = new StreamWriter(cs))  // writes text data to cryptostream
                    {
                        sw.Write(data);
                    }
                }
                encBytes = ms.ToArray();
            }
            return Convert.ToBase64String(encBytes);
        }

        public static string DecryptByRijndael(string ciphertext)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] ivBytes = Encoding.UTF8.GetBytes(iv);

            _rijndael.Key = keyBytes;
            _rijndael.IV = ivBytes;

            ICryptoTransform decryptor = _rijndael.CreateDecryptor(_rijndael.Key, _rijndael.IV);

            byte[] encBytes = Convert.FromBase64String(ciphertext);
            string decText;

            using (MemoryStream ms = new MemoryStream(encBytes))   // stores encrypted or decrypted data in memory
            {
                using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))   // links memory stream with decryptor
                {
                    using (StreamReader sr = new StreamReader(cs))   // reads text data from cryptostream
                    {
                        decText = sr.ReadToEnd();
                    }
                }
            }

            return decText;
        }

    }
}
