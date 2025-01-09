using Security_Cryptography;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Enter string to encrypt:");
        string str = Console.ReadLine();

        // RSA
        //string encString = RSA.EncryptByRSA(str);
        //Console.WriteLine($"Encrypted string: {encString}");
        //string decString = RSA.DecryptByRSA(encString);
        //Console.WriteLine($"Decrypted string: {decString}");


        // DES
        //string encString = DESDemo.EncryptByDES(str);
        //Console.WriteLine($"Encrypted string: {encString}");
        //string decString = DESDemo.DecryptByDES(encString);
        //Console.WriteLine($"Decrypted string: {decString}");


        // AES
        //string encString = AESDemo.EncryptByAES(str);
        //Console.WriteLine($"Encrypted string: {encString}");
        //string decString = AESDemo.DecryptByAES(encString);
        //Console.WriteLine($"Decrypted string: {decString}")


        // Rijndael
        string encString = RijndaelDemo.EncryptByRijndael(str);
        Console.WriteLine($"Encrypted string: {encString}");
        string decString = RijndaelDemo.DecryptByRijndael(encString);
        Console.WriteLine($"Decrypted string: {decString}");

        Console.WriteLine("End of main program.");
    }
}