using System;

namespace CSharp_Basics
{
    class Intro
    {
        public static void Introduction()
        {
            /*
             C# execution:
            - compiler converts .cs file to an intermediate language (IL or MSIL)
            - this IL is stored in form of .dll (library) or .exe
            - Common Lannguage Runtime(CLR) converts IL to machine code
              using JIT-Compiler specific to os and hardware.
            - CLR invokes Main method to start execution.
            - After execution CLR releases occupied resources (like memory)

            This way, C# programs are cross-platform.
             */
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

            /*
            Datatypes in C#:
            Value type:
            byte, sbyte, short, ushort, int, uint, long, ulong, 
            float, double, decimal, char, bool, enum

            Reference type:
            string, object, array

            Nullable type:
            int?, double?, etc.

            Pointer type:
            int*, char*, etc. (unsafe code only)

            Custom type:
            class, struct, interface, enum  
              */
            Console.ReadKey();
        }
    }
}