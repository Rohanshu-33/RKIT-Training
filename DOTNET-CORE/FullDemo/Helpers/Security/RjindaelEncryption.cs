using System;
using System.Security.Cryptography;
using System.Text;

namespace FullDemo.Helpers.Security
{
    public class RjindaelEncryption
    {

        private static RijndaelManaged _rijndael = new RijndaelManaged();
        private static string key = "12345678901234567890123456789012";
        private static string iv = "1234567890123456";


        ///<summary>
        ///Encryption module to get encrypted string.
        ///</summary>
        public static string Encrypt(string data)
        {
            byte[] keybytes = Encoding.UTF8.GetBytes(key);
            byte[] ivbytes = Encoding.UTF8.GetBytes(iv);

            _rijndael.Key = keybytes;
            _rijndael.IV = ivbytes;

            ICryptoTransform encryptor = _rijndael.CreateEncryptor(_rijndael.Key, _rijndael.IV);
            byte[] encryptedBytes;
            using (MemoryStream ms = new MemoryStream())   // stores encrypted or decrypted data in memory
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))   // links memory stream with encryptor
                {
                    using (StreamWriter sw = new StreamWriter(cs))  // writes text data to cryptostream
                    {
                        sw.Write(data);
                    }
                }
                encryptedBytes = ms.ToArray();
            }
            return Convert.ToBase64String(encryptedBytes);
        }

        ///<summary>
        ///Decryption module to get back original data.
        ///</summary>

        public static string Decrypt(string encryptedString)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] ivBytes = Encoding.UTF8.GetBytes(iv);

            _rijndael.Key = keyBytes;
            _rijndael.IV = ivBytes;

            ICryptoTransform decryptor = _rijndael.CreateDecryptor(_rijndael.Key, _rijndael.IV);

            byte[] encBytes = Convert.FromBase64String(encryptedString);
            string decryptedText;

            using (MemoryStream ms = new MemoryStream(encBytes))   // stores encrypted or decrypted data in memory
            {
                using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))   // links memory stream with decryptor
                {
                    using (StreamReader sr = new StreamReader(cs))   // reads text data from cryptostream
                    {
                        decryptedText = sr.ReadToEnd();
                    }
                }
            }

            return decryptedText;
        }
    }
}