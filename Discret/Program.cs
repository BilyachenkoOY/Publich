using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discret
{
    class Program
    {
        static List<Char> Read( )
        {
            List<Char> list = new List<char>(10);
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
                if (key.KeyChar != '0')
                {
                    if (key.KeyChar >= Class1.start && key.KeyChar <= Class1.end)
                    {
                        if (!list.Contains(key.KeyChar))
                        {
                            Console.Write("{0} ", key.KeyChar);
                            list.Add(key.KeyChar);
                        }
                    }
                }
                else break;
            } while (true);
            Console.WriteLine();
            return list;
        }
        static void Main(string[] args)
        {
            do
            {
                var a = new Class1(Read());
                var b = new Class1(Read());
                Console.WriteLine("Sub: {0}", a & b);
                Console.WriteLine("Union: {0}", a | b);
                Console.WriteLine("Additional A: {0}", ~a);
                Console.WriteLine("Additional B: {0}", ~b);
                Console.WriteLine();
            } while (Console.ReadKey(true).KeyChar != '0');
        }
    }
}
