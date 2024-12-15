using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Basics
{
    internal class FileHandlingDemo2
    {
        internal static void FileMethods()
        {
            string filePath = "file2.txt";

            // 1. Writing to file using StreamWriter
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine("Line 1");
                writer.WriteLine("Line 2");
                writer.WriteLine("Line 3");
                writer.Flush(); // Ensure data is written to the file
            }
            Console.WriteLine("Data written to file successfully.\n");

            // 2. Reading from file using StreamReader
            using (StreamReader reader = new StreamReader(filePath))
            {
                Console.WriteLine("Reading line by line:");
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    Console.WriteLine(line);
                }
            }

            // 3. Reading entire file content using StreamReader
            Console.WriteLine("Reading all together:");
            using (StreamReader reader = new StreamReader(filePath))
            {
                string content = reader.ReadToEnd();
                Console.WriteLine(content);
            }

            // 4. Appending new data to file
            using (StreamWriter writer = new StreamWriter(filePath, append: true))
            {
                writer.WriteLine("Line 4");
            }
            Console.WriteLine("New data appended successfully.\n");

            // 5. Displaying Updated File Content
            Console.WriteLine("Displaying updated file content:");
            using (StreamReader reader = new StreamReader(filePath))
            {
                string content = reader.ReadToEnd();
                Console.WriteLine(content);
            }
        }
    }
}
