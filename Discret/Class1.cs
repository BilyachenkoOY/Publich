using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discret
{
    public class Class1
    {
        static readonly List<Char> parrent;

        public const Char start = 'a';
        public const Char end = 'g';

        static Class1(){
            parrent = new List<char>(30);
            for (char i = start; i < end; i++)
                parrent.Add(i);
        }

        private List<Boolean> current;

        public Class1(List<Boolean> Values)
        {
            if (Values.Count != parrent.Count) throw new ArgumentException("diff lenght");
            
            current = new List<bool>(Values.Count);
            foreach (var it in Values)
                current.Add(it);
        }

        public Class1(List<Char> Values)
        {
            current = new List<Boolean>(parrent.Count);
            foreach (var it in parrent)
            {
                if(Values.Contains(it))
                    current.Add(true);
                else current.Add(false);
            }
        }

        public void Print( )
        {
            for (Int16 i = 0; i < parrent.Count; i++)
                if (current[i]) Console.Write("{0}  ", parrent[i]);
            Console.WriteLine();
        }

        public static Class1 operator |(Class1 a, Class1 b)
        {
            return new Class1(a.current.Or(b.current));
        }

        public static Class1 operator &(Class1 a, Class1 b)
        {
            return new Class1(a.current.And(b.current));
        }

        public static Class1 operator ~(Class1 a)
        {
            return new Class1(a.current.Not());
        }
    }
}
