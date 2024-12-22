using System;
using System.Collections;

namespace CollectionsApp
{
    internal class HashTableDemo
    {
        internal static void HTableMethods()
        {
            Hashtable htable = new Hashtable();
            htable.Add("name", "Rohanshu");
            htable.Add(2, 101);
            int[] arr = [1, 2, 3];
            htable.Add(arr, "array");
            //htable.Add("name", "Rohan");  // raises exception

            //Console.WriteLine(htable[2]);

            //htable.Remove("name");
            //Console.WriteLine(htable["name"]);  // prints blank



            // returns an object, need to typecast back to hashtable
            //var clonedTable = (Hashtable)htable.Clone();  
            //Console.WriteLine(clonedTable["name"]);

            // accessing elements of hashtable
            //foreach (DictionaryEntry entry in htable)
            //{
            //    Console.WriteLine(entry.Key + ": " + entry.Value);
            //}

            //htable.ContainsKey(2);
            //htable.ContainsValue("Rohanshu");

            //int x = htable.Count;  // no. of key-val pairs
            //Console.WriteLine(x);

            //htable.Remove("name");

            //var any = htable.Values;
            //foreach (var item in any)
            //{
            //    Console.WriteLine(item);
            //}
        }
    }
}
