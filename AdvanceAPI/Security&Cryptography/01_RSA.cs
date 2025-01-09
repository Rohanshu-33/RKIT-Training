using System;
using System.Security.Cryptography;
using System.Text;

namespace Security_Cryptography
{
    internal class RSA
    {
        private static RSACryptoServiceProvider _rsa = new RSACryptoServiceProvider(1024);
        public static string EncryptByRSA(string originalData)
        {
            byte[] originalBytes = Encoding.UTF8.GetBytes(originalData);  // because RSA operates on byte arrays, not on strings
            byte[] encryptedBytes = _rsa.Encrypt(originalBytes, true);  // true for adding padding to match block size
            return Convert.ToBase64String(encryptedBytes);
        }

        public static string DecryptByRSA(string encryptedData)
        {
            byte[] encryptedBytes = Convert.FromBase64String(encryptedData);
            byte[] originalBytes = _rsa.Decrypt(encryptedBytes, true);  // true for adding padding to match block size
            return Encoding.UTF8.GetString(originalBytes);
        }
    }
}
