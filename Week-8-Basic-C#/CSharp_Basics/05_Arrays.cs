using System;

namespace CSharp_Basics
{
    class ArraysDemo
    {
        public static void ArraysMethod()
        {
            Console.WriteLine("\nArrays:\n");

            // declaration
            int[] arr;
            arr = new int[2];
            arr[0] = 0;
            arr[1] = 1;

            // Other ways to create arrays

            // Create an array of four elements, and add values later
            //string[] cars = new string[4];

            // Create an array of four elements and add values right away 
            //string[] cars = new string[4] { "Volvo", "BMW", "Ford", "Mazda" };

            // Create an array of four elements without specifying the size 
            //string[] cars = new string[] { "Volvo", "BMW", "Ford", "Mazda" };

            // Create an array of four elements, omitting the new keyword, and without specifying the size
            //string[] cars = { "Volvo", "BMW", "Ford", "Mazda" };


            // accessing
            //Console.WriteLine(arr);  // System.Int32[]
            
            //Console.WriteLine(arr[0]);

            //for(int i=0; i<2; i++)
            //{
            //    Console.Write(arr[i] + " ");
            //}

            //Console.WriteLine();

            //int len = arr.Length;   // '2'


            // array methods

            //foreach (int ele in arr)
            //{
            //    Console.Write(ele + " ");
            //}
            
            //Console.WriteLine();

            string []names = { "rohanshu", "meet", "navneet" };
            int []numbers = { 21, 26, 22, 23, 25, 28 };

            //Array.Sort(numbers);   // ascending sort
            //Array.Sort(names);   // alphabetical sort

            //foreach (int i in numbers)
            //{
            //    Console.WriteLine(i);
            //}




            //Array.Reverse(numbers);

            //foreach (int i in numbers)
            //{
            //    Console.WriteLine(i);
            //}




            //int ans = Array.BinarySearch(numbers, 50);   // minus of length of array+1.
            //Console.WriteLine(ans);




            //Array.Clear(numbers);   // reset all values to 0.




            // source, destination, length of source to copy

            //Array.Copy(arr, numbers, 2);   // overwrite in destination

            //foreach (int i in numbers)
            //{
            //    Console.WriteLine(i);
            //}




            //int[] n1 = { 1, 2 };
            //int[] n2 = n1;   // reference to n1
            //n2[1] = 100;

            //bool flg = Array.Equals(n1, n2);   // True
            //Console.WriteLine(flg + " " + n1[1]);



            // Checks if any element exists with given condition
            //bool flg = Array.Exists(numbers, e => e > 222);
            //Console.WriteLine(flg);



            //Array.Fill(numbers, 100);

            //foreach (int i in numbers)
            //{
            //    Console.WriteLine(i);
            //}




            // Finds first element that matches the given condition
            //int index = Array.Find(numbers, e => e>22);
            //Console.WriteLine(index);



            // Checks the given condition for all present elements
            //int[] nums = { 1, 2, 3, 4 };
            //bool allGreaterThanZero = Array.TrueForAll(nums, element => element > 0);

            //if (allGreaterThanZero)
            //{
            //    Console.WriteLine("All elements are greater than 0.");
            //}
            //else
            //{
            //    Console.WriteLine("Not all elements are greater than 0.");
            //}



            int[] a1 = { 1111, 2, 3, 4, 5 };
            //Console.WriteLine(a1.ElementAt(0));   // argument = index

            //Console.WriteLine( a1.GetLength(0));   // argument = dimension

            //Console.WriteLine(a1.Sum());

        }
    }
}