
using System;
using System.Collections.Generic;

namespace CollectionsApp
{
    internal class DictionaryDemo
    {
        internal static void DictionaryMethods()
        {
            // Initialize a dictionary
            Dictionary<int, string> dictionary = new Dictionary<int, string>
            {
                { 1, "Apple" },
                { 2, "Banana" },
                { 3, "Mango" }
            };

            // Add key-value pairs
            dictionary.Add(4, "Peach");
            dictionary.Add(5, "Kiwi");

            // Display all key-value pairs
            Console.WriteLine("Dictionary contents:");
            foreach (var entry in dictionary)
            {
                Console.WriteLine($"Key: {entry.Key}, Value: {entry.Value}");
            }

            // Access a value by its key
            if (dictionary.TryGetValue(2, out string value))
            {
                Console.WriteLine($"\nValue for key 2: {value}");
            }
            else
            {
                Console.WriteLine("\nKey 2 not found.");
            }

            // Update a value
            dictionary[3] = "Coconut";
            Console.WriteLine("\nUpdated value for key 3: " + dictionary[3]);

            // Check if a key or value exists
            bool hasKey = dictionary.ContainsKey(4);
            bool hasValue = dictionary.ContainsValue("Banana");
            Console.WriteLine($"\nContains key 4: {hasKey}");
            Console.WriteLine($"Contains value 'Banana': {hasValue}");

            // Remove an entry by key
            dictionary.Remove(5);
            Console.WriteLine("\nRemoved key 5. Current contents:");
            foreach (var entry in dictionary)
            {
                Console.WriteLine($"Key: {entry.Key}, Value: {entry.Value}");
            }

            // Get the count of key-value pairs
            Console.WriteLine("\nTotal items in the dictionary: " + dictionary.Count);

            // Iterate only keys or values
            Console.WriteLine("\nKeys:");
            foreach (var key in dictionary.Keys)
            {
                Console.WriteLine(key);
            }

            Console.WriteLine("\nValues:");
            foreach (var val in dictionary.Values)
            {
                Console.WriteLine(val);
            }

            // Clear the dictionary
            dictionary.Clear();
            Console.WriteLine("\nDictionary cleared. Count: " + dictionary.Count);
        }
    }
}
