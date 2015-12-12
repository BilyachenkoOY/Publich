using System;
using System.Linq;
using System.Collections.Generic;

namespace Discret
{
    public static partial class Program
    {
        static void Main(string[] args)
        {
            //Second();
            //Third();
            //Fourth();

            Sixth();

            Console.ReadKey();
        }

        public static void Write<T>(IEnumerable<T> list, string delim = ",")
        {
            foreach (var it in list)
            {
                Console.Write("{0}{1}", it, delim);
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
