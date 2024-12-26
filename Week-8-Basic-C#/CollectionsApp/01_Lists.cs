using System;
using System.Collections;
using System.Globalization;
using System.Runtime.Intrinsics.X86;

namespace CollectionsApp
{
    internal class ListsDemo
    {
        internal static void ListsMethods()
        {
            List<int> numbers = new List<int>();
            numbers.Add(1);
            numbers.Add(2);
            numbers.Add(3);
            numbers.Add(4);

            //int ele = numbers.FirstOrDefault(e => e==20, 100);
            //Console.WriteLine(ele);

            //numbers.Remove(3); // returns T/F and removes the element
            //Console.WriteLine(string.Join(", ", numbers));

            //numbers.Clear();  // removes all elements.

            //numbers.Capacity = 10;  // set max size before resizing
            //int x = numbers.Capacity;  // get max size
            //Console.WriteLine(x);

            //numbers.AddRange(numbers); // add at last
            //Console.WriteLine(string.Join(", ", numbers));

            // checks condition on every element
            //bool ans = numbers.All(x => x > 0);
            // time complexity for the above (compare with foreach)

            //List<string> tmp = new List<string>();
            //tmp.Add("a");
            //double avg = tmp.Average();
            //Console.WriteLine("Average : " + avg);

            numbers.Contains(2);   // bool return T/F

            //int count = numbers.Count();
            //Console.WriteLine("Count : " + count);

            //int ele = numbers.ElementAt(0);

            //int ele = numbers.ElementAtOrDefault(10);  // default value '0'

            //numbers.Exists(x => x > 0); // True if atleast 1 is True

            //int ind = numbers.IndexOf(2);  // -1 if not found

            //numbers.Insert(0, 10);
            //Console.WriteLine(string.Join(", ", numbers));

            //int max = numbers.Max();

            //List<int> sortedAsc = numbers.Order().ToList();
            //Console.WriteLine(string.Join(", ", sortedAsc));

            //numbers.RemoveAt(0);

            //var slicedList = numbers.Slice(1, 3);  // start index, length of sliced list

            //numbers.Sort();

            //int[] arrList = numbers.ToArray();
            // by ref and value, deep copy
            // mindmap

        }
    }
}
