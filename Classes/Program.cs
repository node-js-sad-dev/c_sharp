using System;

namespace Classes
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Car car = new Car("Volvo");

            Console.WriteLine(car.Brand);

            car.Brand = "Mercedes";

            Console.WriteLine(car.Brand);
        }
    }
}