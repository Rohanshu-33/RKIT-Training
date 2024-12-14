using System;
using System.Collections;

namespace CollectionsApp
{
    internal class StackDemo
    {
        internal static void StackMethods()
        {
            Stack<int> stk = new Stack<int>();
            stk.Push(1);
            stk.Push(2);
            stk.Push(3);

            //int len = stk.Count;

            //int x = stk.Peek();
            //x = stk.Pop();

            //foreach (var item in stk)
            //{
            //    Console.WriteLine(item);
            //}

            //stk.Contains(2);

            //int sum = stk.Aggregate(0, (acc, item) => acc + item);
            //Console.WriteLine(sum);

            //List<int> any = stk.Append(4).ToList();
            //foreach (var item in any)
            //{
            //    Console.WriteLine(item);
            //}

            //bool ans = stk.Any();
            //Console.WriteLine(ans);

            //stk.Average();
            //stk.Clear();

            //int ans = stk.ElementAt(2);
            //Console.WriteLine(ans);

            //int ans = stk.First();
            //ans = stk.Last();
            //Console.WriteLine(ans);

            //stk.Max();

            //stk.Sum();

            //int[] arr = stk.ToArray();

            //stk.ToList();

            //Stack<object> stack = new Stack<object>();
            //stack.Push(1);
            //stack.Push("hello");
            //stack.Push(2);
            //stack.Push(3.5F);
            //stack.Push(4);

            //var integers = stack.OfType<int>();

            //foreach (var item in integers)
            //{
            //    Console.WriteLine(item); // Output: 1, 2, 4
            //}
        }
    }
}
