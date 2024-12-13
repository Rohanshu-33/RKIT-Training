using ClassesAndObjects;
using System;

class Program
{
    int var1 = 3;
    private string var2 = "rohanshu";
    static void Main(string[] args)
    {
        Console.WriteLine("Main Program\n");

        //Program p1 = new Program();
        //Program p2 = new Program();
        //p2.var2 = "abc";   // possible bcoz in same class
        //Console.WriteLine(p2.var2);




        //Car c1 = new Car("Maruti", 750000);

        //c1.Price = 1200000;    // As the data member is made read-only,
        //we cannot update it's value even though it is public
        //c1.name = "Ford";   // It is public so we can update and read too.

        //Console.WriteLine(c1.Price);
        //c1.ShowDetails();




        //Employee e1 = new Employee("Rohanshu", 21, "24emp101", 125000.55F);
        //e1.Display();

        
        


        // Error - Cannot create an instance of abstract type
        //Animal a  = new Animal();

        //Dog d = new Dog();
        //d.MakeSound();





        //Sparrow s1 = new Sparrow();
        //Owl o1 = new Owl();

        //Bird b = new Bird();
        //Bird b1 = new Owl();
        //Bird b2 = new Sparrow();

        //b.Speak();
        //b1.Speak();
        //b2.Speak();
        
    }
}