using System;
using System.Security.Cryptography;
using System.Text;

namespace Security_Cryptography
{
    internal class DESDemo
    {
        private static DES _des = DES.Create();  // Create an instance using the factory method
        // DESCryptoServieProvider is obsolete. it is recommended to use AESCryptoServiceProvider
        // Encrypt the data using DES
        public static string EncryptByDES(string originalData)
        {
            byte[] originalBytes = Encoding.UTF8.GetBytes(originalData);

            // Generate a random key and IV for DES encryption
            _des.Key = GenerateKey();  // Generate a DES key
            _des.IV = GenerateIV();    // Generate a DES initialization vector (IV)

            ICryptoTransform encryptor = _des.CreateEncryptor(_des.Key, _des.IV);

            byte[] encryptedBytes = encryptor.TransformFinalBlock(originalBytes, 0, originalBytes.Length);

            // Return the encrypted data as a base64 string
            return Convert.ToBase64String(encryptedBytes);
        }

        // Decrypt the data using DES
        public static string DecryptByDES(string encryptedData)
        {
            byte[] encryptedBytes = Convert.FromBase64String(encryptedData);

            ICryptoTransform decryptor = _des.CreateDecryptor(_des.Key, _des.IV);

            byte[] originalBytes = decryptor.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);

            return Encoding.UTF8.GetString(originalBytes);
        }

        // Generate a random DES key
        private static byte[] GenerateKey()
        {
            _des.GenerateKey();  // Generates a random key for DES
            return _des.Key;
        }

        // Generate a random DES IV (Initialization Vector)
        private static byte[] GenerateIV()
        {
            _des.GenerateIV();  // Generates a random IV for DES
            return _des.IV;
        }
    }
}
