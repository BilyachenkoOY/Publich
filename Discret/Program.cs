using System;
using System.Collections.Generic;

namespace Discret
{
    class Program
    {
        private const Boolean intercept = true;
        static List<Char> Read( )
        {
            List<Char> list = new List<char>(Class1.End - Class1.Start);
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(intercept);
                if (key.KeyChar == '0' || key.Key == ConsoleKey.Enter)
                    break;
                if (key.KeyChar >= Class1.Start && key.KeyChar <= Class1.End)
                {
                    if (!list.Contains(key.KeyChar))
                    {
                        Console.Write("{0} ", key.KeyChar);
                        list.Add(key.KeyChar);
                    }
                }
            } while (true);
            Console.WriteLine();
            return list;
        }
        
        static void Main(string[] args)
        {
            ConsoleKeyInfo key;
            do
            {
                var a = new Class1(Read());
                var b = new Class1(Read());

                Console.WriteLine("Sub: {0}", a & b);
                Console.WriteLine("Union: {0}", a | b);
                Console.WriteLine("Additional A: {0}", ~a);
                Console.WriteLine("Additional B: {0}", ~b);
                Console.WriteLine();

                key = Console.ReadKey(true);
            } while (key.KeyChar != '0');
        }
    }
}
