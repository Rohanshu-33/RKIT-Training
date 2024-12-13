using System;

namespace ClassesAndObjects
{
    internal class Car
    {
        public int Price { get;}   // property
        public string name;

        public Car(string name, int price)
        {
            this.name = name;
            Price = price;
        }

        public void ShowDetails()
        {
            Console.WriteLine("Name : " + name + " Price : " + Price);
        }
    }
}
