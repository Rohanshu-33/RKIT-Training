using System;
using System.Collections.Immutable;

namespace CollectionsApp
{
    internal class ImmutableArraysDemo
    {
        internal static void ImmutableArraysMethods()
        {
            ImmutableArray<int> immutableArray = ImmutableArray.Create(1, 2, 3, 4, 5);
            Console.WriteLine("Immutable Array contents:");
            foreach (var item in immutableArray)
            {
                Console.Write(item + " ");
            }

            // Add a new element (creates a new array)
            ImmutableArray<int> newArray = immutableArray.Add(6);
            Console.WriteLine("\nAfter adding 6, New Array:");
            foreach (var item in newArray)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("\nAfter adding 6, Old Array:");
            foreach (var item in immutableArray)
            {
                Console.Write(item + " ");
            }

            // Remove an element (creates a new array)
            var removedArray = newArray.Remove(3);
            Console.WriteLine("\nAfter removing 3:");
            foreach (var item in removedArray)
            {
                Console.Write(item + " ");
            }

            // Replace an element (creates a new array)
            var replacedArray = removedArray.Replace(4, 10); // 1st occurence
            Console.WriteLine("\nAfter replacing 4 with 10:");
            foreach (var item in replacedArray)
            {
                Console.Write(item + " ");
            }

            // Insert an element at a specific position (creates a new array)
            var insertedArray = replacedArray.Insert(2, 7);
            Console.WriteLine("\nAfter inserting 7 at index 2:");
            foreach (var item in insertedArray)
            {
                Console.Write(item + " ");
            }

            // Access elements by index
            Console.WriteLine($"\nElement at index 1: {immutableArray[1]}");

            // Get the length of the ImmutableArray
            Console.WriteLine($"Length of the ImmutableArray: {immutableArray.Length}");
        }
    }
}
