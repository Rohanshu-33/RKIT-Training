using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using Microsoft.CSharp;

namespace ConsoleApp1_PC
{
    internal class BaseClassLibraries
    {
        internal static void BaseClassLibrariesDemo()
        {
            Console.WriteLine("System namespace: Hello, World!");

            // Example of System.Collections and System.Linq namespace
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
            var evenNumbers = numbers.Where(n => n % 2 == 0).ToList();
            Console.WriteLine("Even numbers: " + string.Join(", ", evenNumbers));

            // Example of System.Data namespace  --> used for connecting with database and performing operations.
            // also includes datatable, dataset, datarow, datacolumn, etc.
            DataTable table = new DataTable();
            table.Columns.Add("Name");
            table.Rows.Add("Rohanshu");
            table.Rows.Add("Rohan");
            Console.WriteLine("DataTable first row: " + table.Rows[0]["Name"]);

            // Example of System.Globalization namespace  --> datetime, language, country, currency, calendars, etc.
            DateTime currentDate = DateTime.Now;
            Console.WriteLine("Formatted Date (Culture Info): " + currentDate.ToString("D", CultureInfo.InvariantCulture));

            // Example of System.IO namespace
            string filePath = "sample.txt";
            File.WriteAllText(filePath, "Hello, File IO!");
            Console.WriteLine("File written to: " + filePath);

            // Example of System.Net namespace  -> enables network based communication.
            WebClient webClient = new WebClient();
            string googleHomepage = webClient.DownloadString("https://www.google.com");
            Console.WriteLine("Google Homepage (first 100 chars): " + googleHomepage.Substring(0, 100));

            // Microsoft.CSharp provides support for compilation and code generation, including dynamic.
        }
    }
}
