using System;
using System.Collections.Generic;
using System.Text;

namespace Discret
{
    public partial class Set : BaseSet<int>
    {
        #region ctors
        static Set( )
        {
            baseParrent = new List<int>(End-Start);
            for (int i = Start; i <= End; i++)
                baseParrent.Add(i);
        }

        public Set( ) : this(new int[0])
        {
        }

        public Set(ICollection<int> Values):base(Values, baseParrent)
        {
        }
        public Set(Set o):base(o.current, o.parrent)
        {
        }
       
        public Set(ICollection<int> Values, IList<int> Parrent)
            : base(Values, Parrent)
        {
        }

        private Set(IList<Boolean> Values)
            : this(Values, baseParrent)
        {
        }

        private Set(IList<Boolean> Values, IList<int> Parrent)
            : base(Values, Parrent)
        {
        }
        #endregion

        public static Set operator |(Set first, Set second)
        {
            return new Set(first.current.Or(second.current));
        }

        public static Set operator &(Set first, Set second)
        {
            return new Set(first.current.And(second.current));
        }

        public static Set operator ~(Set operand)
        {
            return new Set(operand.current.Not());
        }

        protected static readonly List<int> baseParrent;
    }
}
