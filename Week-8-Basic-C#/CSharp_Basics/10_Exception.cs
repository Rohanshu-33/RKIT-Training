using System;

namespace CSharp_Basics
{
    internal class ExceptionDemo
    {
        internal static void ExceptionMethod()
        {
            try
            {
                Console.WriteLine("Enter a number: ");
                int num1 = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter another number: ");
                int num2 = int.Parse(Console.ReadLine());

                // Perform division
                int result = num1 / num2;
                Console.WriteLine($"Result: {result}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (DivideByZeroException ex)
            {
               Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Execution completed.");
            }
        }
    }
}
