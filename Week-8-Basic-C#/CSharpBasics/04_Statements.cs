using System;

namespace CSharpBasics
{
    class Statements
    {
        public static void StatementsMethod()
        {
            Console.Write("Enter value for x: ");
            int x = Convert.ToInt32(Console.ReadLine());

            // if-else

            Console.WriteLine("\nIf-else statement:\n");
            if (x > 5)
            {
                Console.WriteLine("value above 5.");
            }
            else if (x >= 0 && x<=5)
            {
                Console.WriteLine("value between 0 and 5.");
            }
            else
            {
                Console.WriteLine("value less than 0.");
            }

            // switch

            Console.WriteLine("\nSwitch case:\n");
            switch (x)
            {
                case 0:
                    Console.WriteLine("x is 0.");
                    break;
                case 5:
                    Console.WriteLine("x is 5.");
                    break;
                default:
                    Console.WriteLine("x neither 0, nor 5.");
                    break;
            }

            // for

            Console.WriteLine("\nFor loop:\n");
            for (int j=0; j<3; j++)
            {
                Console.WriteLine("i is : " + j);
            }

            // while

            Console.WriteLine("\nWhile loop:\n");
            int i = 3;
            while (i > 0)
            {
                Console.WriteLine("i is : " + i);
                i--;
            }

            // do-while

            Console.WriteLine("\nDo-while loop:\n");
            do
            {
                Console.WriteLine("i is : " + i);
                i++;
            }
            while (i < 3);

        }
    }
}