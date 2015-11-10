using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discret
{
    public abstract class BaseSet
    {
        public const int Start = 1;
        public const int End = 14;

        static BaseSet( )
        {
            baseParrent = new List<int>(End-Start);
            for (int i = Start; i <= End; i++)
                baseParrent.Add(i);
        }

        public BaseSet(ICollection<int> Values, IList<int> Parrent)
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

        public string ToBoleanString( )
        {
            var sb = new StringBuilder(this.Count * 2 + 5);
            foreach (var b in this.current)
                sb.AppendFormat("{0} ", b ? 1 : 0);
            return sb.Append("\b").ToString();
        }

        public int Count { get { return current.Count; } }

        protected BaseSet(IList<Boolean> Values, IList<int> Parrent)
        {
            if (Values.Count != Parrent.Count)
                throw new ArgumentException("diff length", "Values");
            current = new List<bool>(Values);
            parrent = Parrent;
        }

        protected bool this[int index]
        {
            get
            {
                return current[index];
            }
            set
            {
                current[index] = value;
            }
        }

        protected static readonly List<int> baseParrent;
        protected readonly IList<int> parrent;
        protected List<Boolean> current;
    }
}
