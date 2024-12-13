using System;

namespace CSharp_Basics
    {
	    public class MethodsDemo
	    {

            public static void GetAllMethods()
            {
                //string name = Console.ReadLine();
                //GreetUser(name);

                int a = 3;
                int b = 4;
                Console.WriteLine("a : " + a + " b : " + b);
                Swap(ref a, ref b);
                Console.WriteLine("a : " + a + " b : " + b);

                int x, y;
                int ans = Sum(out x, out y);
                Console.WriteLine("Sum of " + x + " and " + y + " is : " + ans);
                
                ans = Sum(1,2,3,4,5,6,7,8,9);
                Console.WriteLine("Sum is : " + ans);
            }

            static void GreetUser(string name)
            {
                Console.WriteLine("Hello! " + name);
            }

            // use of ref keyword (call by reference)
            static void Swap(ref int a, ref int b)
            {
                int tmp = a;
                a = b;
                b = tmp;
            }

            // use of out keyword (similar to call by reference
            // but no need to have the argument initialised.)
            static int Sum(out int a, out int b)
            {
                a = 7;
                b = 11;
                return a + b;
            }

            // use of params (variable number of arguments)
            // and function overloading (same function name
            // but different types and number of arguments.).
            static int Sum(params int[] numbers)
            {
                int sum = 0;
                foreach (int ele in numbers)
                {
                    sum += ele;    
                }
                return sum;
            }
        }
    }
