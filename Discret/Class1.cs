using System;
using System.Collections.Generic;
using System.Text;

namespace Discret
{
    public class Class1
    {
        public const int Start = 1;
        public const int End = 14;

        static Class1(){
            parrent = new List<int>(End-Start);
            for (int i = Start; i <= End; i++)
                parrent.Add(i);
        }

        public Class1(ICollection<int> Values)
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

        public static Class1 operator |(Class1 first, Class1 second)
        {
            return new Class1(first.current.Or(second.current));
        }

        public static Class1 operator &(Class1 first, Class1 second)
        {
            return new Class1(first.current.And(second.current));
        }

        public static Class1 operator ~(Class1 operand)
        {
            return new Class1(operand.current.Not());
        }

        private Class1(IList<Boolean> Values)
        {
            current = new List<bool>(Values);
        }

        static readonly List<int> parrent;
        private List<Boolean> current;
    }
}
