using System;

namespace CSharpBasic
{
    public class Operators
    {
        public static void OperatorMethod()
        {
            // Arithmetic Operators
            int a = 3;
            int b = 4;

            Console.WriteLine("Arithmetic Operators:\na : " + a + " b : " + b + "\n");

            Console.WriteLine("a + b = " + (a + b));
            Console.WriteLine("a - b = " + (a - b));
            Console.WriteLine("a * b = " + (a * b));
            Console.WriteLine("a / b = " + (a / b));
            Console.WriteLine("a % b = " + (a % b));
            a++;
            Console.WriteLine("a++ = " + (a));
            Console.WriteLine("++a = " + (++a));
            a--;
            Console.WriteLine("a-- = " + (a));
            Console.WriteLine("--a = " + (--a));


            // Comparison Operators

            Console.WriteLine("\nComparison Operators:\na : " + a + " b : " + b + "\n");

            Console.WriteLine("a > b = " + (a > b));
            Console.WriteLine("a >= b = " + (a >= b));
            Console.WriteLine("a < b = " + (a < b));
            Console.WriteLine("a <= b = " + (a <= b));
            Console.WriteLine("a != b = " + (a != b));
            Console.WriteLine("a == b = " + (a == b));


            // Logical Operators

            Console.WriteLine("\nBitwise Logical Operators:\na : " + a + " b : " + b + "\n");

            Console.WriteLine("a & b = " + (a & b));
            Console.WriteLine("a | b = " + (a | b));
            Console.WriteLine("a >> 2 = " + (a >> 2));
            Console.WriteLine("b << 3 = " + (b << 3));

            int c = 4, d=5;
            Console.WriteLine("\nLogical Operators:\nc : " + c + " d : " + d + "\n");
            Console.WriteLine("c==4 && d==4 : " + (c==4 && d==4));
            Console.WriteLine("c==6 || d==5 : " + (c==6 || d==5));
            Console.WriteLine("!(c==4 && d==4) : " + !(c == 4 && d == 5));

        }
    }
}
