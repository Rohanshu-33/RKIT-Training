using CSharp_Basics;
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Main Program file.");
        //Intro.Introduction();
        //TypeCasting.TypeCastingMethod();
        //Operators.OperatorMethod();
        //Statements.StatementsMethod();
        //ArraysDemo.ArraysMethod();
        //MethodsDemo.GetAllMethods();
        //Enumeratorss.EnumsDemo();
        //ReferencesToAssemblies.ReferencesDemo();
        //DataTableDemo.DataTableMethod();
        //ExceptionDemo.ExceptionMethod();
        //StringClassDemo.StringClassMethods();
        //DateTimeClassDemo.DateTimeClassMethods();
        //FileHandlingDemo.FileMethods();
        //FileHandlingDemo2.FileMethods();


        // swap 2 numbers using all ways, code that automatically
        int a = 3, b = 4;
        (a, b) = (b, a); // tuple -> deconstructs(separates) tuple into a, b
        Console.WriteLine(a + " " + b);

        //[a, b] = [b, a]; // not possible bcoz no deconstruction property

        // gets removed during deployment time
        // -> #if DEBUG ... #endif

        // "dynamic" datatype -->

        //var Aa = 5;
        //Aa = "hi";

        //dynamic Aa = 5;
        //Aa = "hi";

        // working of C# code
        // .net framework project

        string str1 = null;
        string str2 = str1 ?? "Default";

        Console.ReadKey();
    }
}