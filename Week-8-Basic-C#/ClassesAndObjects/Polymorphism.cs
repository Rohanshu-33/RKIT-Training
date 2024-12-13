using System;

namespace ClassesAndObjects
{
    class Bird
    {
        // Base class method marked as virtual to allow overriding in derived classes
        // A  method must be virtual, abstract or override to be overridden.
        public virtual void Speak()
        {
            Console.WriteLine("Bird makes a sound");
        }
    }

    class Sparrow : Bird
    {
        public override void Speak()
        {
            //base.Speak();
            Console.WriteLine("Sparrow chirps");
        }
    }

    class Owl : Bird
    {
        public override void Speak()
        {
            Console.WriteLine("Owl hoots");
        }
    }
}
