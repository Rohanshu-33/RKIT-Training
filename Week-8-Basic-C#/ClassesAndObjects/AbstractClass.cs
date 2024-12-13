using System;

namespace ClassesAndObjects
{
    abstract class Animal
    {
        public void Eat()
        {
            Console.WriteLine("Eating...");
        }

        public abstract void MakeSound();  // Abstract method 
        // If definition is given, it will result in compilation error
    }

    class Dog : Animal
    {
        public override void MakeSound()  // Must implement abstract method
        {
            Console.WriteLine("Barking...");
        }
    }
}
