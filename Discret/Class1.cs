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

        public Class1(IList<Boolean> Values)
        {
            if (Values.Count != parrent.Count) throw new ArgumentException("diff lenght");
            
            current = new List<bool>(Values);
        }

        public Class1(IList<Char> Values)
        {
            current = new List<Boolean>(parrent.Count);
            foreach (var it in parrent)
            {
                current.Add(Values.Contains(it));
            }
        }

        public override String ToString( )
        {
            var capacity = parrent.Count * 2 + 10;
            // Ex: "a " x 10 + \n
            var builder = new StringBuilder(capacity);
            for (Int16 i = 0; i < parrent.Count; i++)
                if (current[i]) 
                    builder.AppendFormat("{0}  ", parrent[i]);
            builder.AppendLine();
            return builder.ToString();
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
