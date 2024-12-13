using System;

namespace Interfaces
{
    internal interface IInterface1
    {
        void Display()
        {
            Console.WriteLine("Default");
        }

    }

    internal class Class1 : IInterface1
    {
        public void Display()
        {
            Console.WriteLine("Hello from Class1");
        }
    }

    internal class Class2 : IInterface1
    {
        //public void Display()
        //{
        //    Console.WriteLine("Hello from Class2");
        //}
    }

    // Empty body Methods, Methods with definition and
    // properties are allowed in an interface whereas
    // fields (data members) and constructors are not allowed.
}
