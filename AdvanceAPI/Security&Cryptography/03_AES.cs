using System;
using System.Security.Cryptography;
using System.Text;

namespace Security_Cryptography
{
    internal class AESDemo
    {
        private static Aes _aes = Aes.Create();

        public static string EncryptByAES(string data)
        {
            byte[] originalBytes = Encoding.UTF8.GetBytes(data);

            // Generate a random key and IV for AES encryption
            _aes.Key = GenerateKey();  // Generate a AES key
            _aes.IV = GenerateIV();    // Generate a AES initialization vector (IV)

            ICryptoTransform encryptor = _aes.CreateEncryptor(_aes.Key, _aes.IV);
            
            byte[] encryptedBytes = encryptor.TransformFinalBlock(originalBytes, 0, originalBytes.Length);

            // Return the encrypted data as a base64 string
            return Convert.ToBase64String(encryptedBytes);
        }

        public static string DecryptByAES(string encData)
        {
            byte[] encBytes = Convert.FromBase64String(encData);
            
            ICryptoTransform decryptor = _aes.CreateDecryptor(_aes.Key, _aes.IV);

            byte[] origData = decryptor.TransformFinalBlock(encBytes, 0, encBytes.Length);
            return Encoding.UTF8.GetString(origData);
        }

        // Generate a random AES key
        private static byte[] GenerateKey()
        {
            _aes.GenerateKey();  // Generates a random key for AES
            return _aes.Key;
        }

        // Generate a random AES IV (Initialization Vector)
        private static byte[] GenerateIV()
        {
            _aes.GenerateIV();  // Generates a random IV for AES
            return _aes.IV;
        }
    }
}
