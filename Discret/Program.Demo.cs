using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discret
{
    public static partial class Program
    {
        private static void Second( )
        {
            var a = new Set(new int[] { 5, 11, 3, 7, 9, 8, 10 });
            var b = new Set(new int[] { 1, 2, 4, 3, 5, 11 });
            var c = new Set(new int[] { 4, 3, 7, 9, 6 });

            Console.WriteLine("A: {0}", a);
            Console.WriteLine("~B: {0}", ~b);
            Console.WriteLine("C: {0}", c);

            Console.WriteLine("A&~B&C: {0}", a & ~b & c);
            Console.WriteLine("{0}", ( ~( a & ~b & c | a & ~( b & c ) ) | ( ~( a & b ) & c & c ) ) & a & ~b);
        }

        private static void Third( )
        {
            var set = new Set(new int[] { 1, 2, 3, 4, 5 });

            //WriteLine(set.SubSets().Select(i => i.ToBoleanString()));
            WriteLine(set.SubSets());
            //WriteLine(set.SubSetsGray().Select(i => i.ToBoleanString()));
            WriteLine(set.SubSetsGray());
            Console.WriteLine();

            var countOn = set.CountOn();
            for (var i = 0; i < countOn; i++)
            {
                //WriteLine(set.SubSets(i).Select(s => s.ToBoleanString()));
                WriteLine(set.SubSets(i));
            }
        }

        private static void Fourth( )
        {
            var arr = new int[] { 1, 2, 3, 4 };
            var lex = arr.AntiLex();
            foreach (var list in lex)
            {
                Write(list, " ");
            }

            Console.WriteLine();

            var antilex = arr.AntiLex();
            foreach (var list in antilex)
            {
                Write(list, " ");
            }
        }

        private static void Fiveth( )
        {

        }

        private static void Sixth( )
        {
            var set1 = new MultiSet<char>("abcde".ToCharArray());
            foreach (var list in set1.MultiVectors(3))
            {
                Write(list, " ");
            }

            Console.ReadKey();
            Console.WriteLine("\n");

            var set2 = new MultiSet<char>("abcdef".ToCharArray());
            foreach (var list in set2.MultiSets(4))
            {
                Write(list, " ");
            }
        }
    }
}
