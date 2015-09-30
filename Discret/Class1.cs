using System;
using System.Collections.Generic;
using System.Text;

namespace Discret
{
    public partial class Class1
    {
        public const int Start = 1;
        public const int End = 14;

        static Class1(){
            baseParrent = new List<int>(End-Start);
            for (int i = Start; i <= End; i++)
                baseParrent.Add(i);
        }

        public Class1(ICollection<int> Values):this(Values, baseParrent)
        {
        }
        public Class1( ):this(new int[0])
        {
        }
        public Class1(Class1 o):this(o.current, o.parrent)
        {
        }

        public Class1(ICollection<int> Values, IList<int> Parrent)
        {
            parrent = Parrent;
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
                    builder.AppendFormat("{0} ", parrent[i]);
            return builder.Length == 0 ? string.Empty : builder.ToString(0, builder.Length - 1);
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

        private Class1(IList<Boolean> Values):this(Values, baseParrent)
        {
        }

        private Class1(IList<Boolean> Values, IList<int> Parrent)
        {
            if (Values.Count != Parrent.Count)
                throw new ArgumentException("diff length", "Values");
            current = new List<bool>(Values);
            parrent = Parrent;
        }

        static readonly List<int> baseParrent;
        private readonly IList<int> parrent;
        private List<Boolean> current;
    }
}
