using System;

namespace CSharpBasics
{
    class Intro
    {
        public static void Introduction()
        {
            const int x = 4;
            char y = 'A';
            string z = "rohanshu";
            double a = 3.456234D;
            float b = 4.444F;

            // Single line comments

            /* Multi-line 
             comments */

            Console.WriteLine("Hello World!");
            Console.WriteLine("x is : " + x);
            Console.WriteLine("y is : " + y);
            Console.WriteLine("z is : " + z);
            Console.WriteLine("a is : " + a);
            Console.WriteLine("b is : " + b);
            Console.ReadKey();
        }
    }
}