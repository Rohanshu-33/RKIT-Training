using System;

namespace Interfaces
{
    internal interface II1
    {
        int var1 { get; set; }
        int var2 { get; set; }
    }

    internal interface II2
    {
        int var1 { get; set; }
    }

    public class MyClass : II1, II2
    {
        // Backing fields for var1 and var2
        private int _var1; // For both II1.var1 and II2.var1
        private int _var2; // For II1.var2

        // Explicit interface implementation for II1.var1
        int II1.var1
        {
            get { return _var1; }   // Return value from _var1 for II1.var1
            set { _var1 = value; }  // Store value in _var1 for II1.var1
        }

        // Explicit interface implementation for II2.var1
        int II2.var1
        {
            get { return _var1; }   // Return value from _var1 for II2.var1
            set { _var1 = value; }  // Store value in _var1 for II2.var1
        }

        // Implementation of var2 from II1
        public int var2
        {
            get { return _var2; }   // Return value from _var2
            set { _var2 = value; }  // Store value in _var2
        }

        // Constructor to initialize values
        public MyClass(int var1, int var2)
        {
            _var1 = var1;  // Initialize _var1 for both II1.var1 and II2.var1
            _var2 = var2;  // Initialize _var2 for II1.var2
        }

        // Method to display the values of the properties
        public void ShowValues()
        {
            // casting done for var1 bcoz both interface had same member-name
            Console.WriteLine($"II1.var1: {((II1)this).var1}, II2.var1: {((II2)this).var1}, var2: {var2}");
        }
    }
}
