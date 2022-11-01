using System;

namespace ComplexNumbers
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var c1 = new ComplexNumber(1, 1);
            var c2 = new ComplexNumber(1, 2);
     
            var plus = c1.Plus(c2);
            var minus = c1.Minus(c2);

            Console.WriteLine(plus);
            Console.WriteLine(minus);
        }
    }
}