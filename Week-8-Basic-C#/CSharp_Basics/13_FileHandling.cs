using System;
using System.IO;

namespace CSharp_Basics
{
    internal class FileHandlingDemo
    {
        internal static void FileMethods()
        {
            string filePath = "file1.txt";

            // 1. Write multiple lines
            List<string> linesToWrite = new List<string>
        {
            "Line 1",
            "Line 2",
            "Line 3"
        };
            File.WriteAllLines(filePath, linesToWrite);
            Console.WriteLine($"File {filePath} created and written successfully.");

            // 2. Read multiple lines
            IEnumerable<string> readLines = File.ReadLines(filePath); // uses lazy loading
            foreach (string line in readLines)
            {
                Console.WriteLine(line);
            }

            // 3. Append line to file
            File.AppendAllText(filePath, "Line 4\n");
            Console.WriteLine("Line appended successfully.");

            // 4. Read all lines in once
            string[] allLines = File.ReadAllLines(filePath); // loads everything at once
            foreach (string line in allLines)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine($"File created at: {Path.GetFullPath(filePath)}");

            // 5. Delete file
            //File.Delete(filePath);
            //Console.WriteLine($"File {filePath} deleted successfully.");
        }
    }
}
