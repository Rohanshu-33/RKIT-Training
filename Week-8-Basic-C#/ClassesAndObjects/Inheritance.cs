using System;

namespace ClassesAndObjects
{
    internal class Person
    {
        public string name;
        public int age;

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
    }

    internal class Employee : Person
    {
        public string empId;
        float salary;

        public Employee(string name, int age, string empId, float salary)
            : base(name, age)
        {
            this.empId = empId;
            this.salary = salary;
        }

        public void Display()
        {
            Console.WriteLine($"{name} of age {age} years having" +
                $" employee id of {empId} has a salary of {salary} rupees.");
        }
    }

    // Single, Hierarchical and Multi-level inheritance are possible but
    // Multiple inheritance is not possible. For that, use Interfaces.

    // Abstract classes are also possible.
}
