using System;
using System.Collections.Generic;

namespace Discret
{
    class Program
    {
        private const Boolean intercept = true;
        
        static void Main(string[] args)
        {
            var a = new Class1(new int[] {5, 11, 3, 7, 9, 8, 10});
            var b = new Class1(new int[] {1, 2, 4, 3, 5, 11});
            var c = new Class1(new int[] {4, 3, 7, 9, 6});
            var d = new Class1(new int[] { 1, 2, 3, 4});
            //Console.WriteLine("{0}, {1}, {2}, {3}", ++d, ++d, ++d, --d);
            foreach (var it in d.Generate())
            {
                Console.WriteLine("{0},", it);
            }
            Console.WriteLine();
            Console.WriteLine("A: {0}", a);
            Console.WriteLine("~B: {0}", ~b);
            Console.WriteLine("C: {0}", c);
            
            Console.WriteLine("A&~B&C: {0}", a & ~b & c);
            Console.WriteLine("{0}", ( ~( a & ~b & c | a & ~( b & c ) ) | ( ~( a & b ) & c & c ) ) & a & ~b);
            Console.ReadKey();
        }
    }
}
