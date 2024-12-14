using System;
using MathAssemblyDemo;

namespace CSharp_Basics
{
    internal class ReferencesToAssemblies
    {
        public static void ReferencesDemo()
        {
            MathOperations myMath = new MathOperations();
            Console.WriteLine(myMath.Add(2,3));
            Console.WriteLine(myMath.Add(2.5F, 3.5F));
            Console.WriteLine(myMath.Multiply(1,2, 3,4,5));

            
        }
    }
}
