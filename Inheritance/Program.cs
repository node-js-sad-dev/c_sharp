using System;

namespace Inheritance
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var abstractDaughter = new AbstractDaughter(3, 4, 5);

            Console.WriteLine(abstractDaughter.Perimeter());

            var daughterClass = new DaughterClass(2, "Test");

            Console.WriteLine(daughterClass.Id);
        }
    }
}