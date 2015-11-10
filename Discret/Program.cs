using System;
using System.Linq;
using System.Collections.Generic;

namespace Discret
{
    public static class Program
    {
        private const Boolean intercept = true;
        
        static void Main(string[] args)
        {
            var a = new Set(new int[] {5, 11, 3, 7, 9, 8, 10});
            var b = new Set(new int[] {1, 2, 4, 3, 5, 11});
            var c = new Set(new int[] {4, 3, 7, 9, 6});
            var d = new Set(new int[] { 1, 2, 3, 4, 5});

            //WriteLine(d.SubSets().Select(i => i.ToBoleanString()));
            WriteLine(d.SubSets());
            //WriteLine(d.SubSetsGray().Select(i => i.ToBoleanString()));
            WriteLine(d.SubSetsGray());
            //WriteLine(d.SubSets(3).Select(i => i.ToBoleanString()));
            WriteLine(d.SubSets(3));

            /*second
            Console.WriteLine("A: {0}", a);
            Console.WriteLine("~B: {0}", ~b);
            Console.WriteLine("C: {0}", c);
            
            Console.WriteLine("A&~B&C: {0}", a & ~b & c);
            Console.WriteLine("{0}", ( ~( a & ~b & c | a & ~( b & c ) ) | ( ~( a & b ) & c & c ) ) & a & ~b);
             */
            Console.ReadKey();
        }

        public static void Write<T>(IEnumerable<T> list)
        {
            foreach (var it in list)
            {
                Console.Write("{0},", it);
            }
            Console.WriteLine("\b ");
        }

        public static void WriteLine<T>(IEnumerable<T> list)
        {
            foreach (var it in list)
            {
                Console.WriteLine("{0},", it);
            }
            Console.WriteLine();
        }
    }
}
