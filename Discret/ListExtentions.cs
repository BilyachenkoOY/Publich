using System;
using System.Linq;
using System.Collections.Generic;

namespace Discret
{
    public static class ListExtentions
    {
        public static IList<Boolean> And(this IList<Boolean> x, IList<Boolean> y){
            if (x.Count != y.Count) throw new ArgumentException("diff lenght");
            var res = new List<Boolean>(x.Count);
            for (Int16 i = 0; i < x.Count; i++)
            {
                res.Add(x[i] && y[i]);
            }
            return res;
        }

        public static IList<Boolean> Or(this IList<Boolean> x, IList<Boolean> y)
        {
            if (x.Count != y.Count) throw new ArgumentException("diff lenght");
            var res = new List<Boolean>(x.Count);
            for (Int16 i = 0; i < x.Count; i++)
            {
                res.Add(x[i] || y[i]);
            }
            return res;
        }

        public static IList<Boolean> Not(this IList<Boolean> x)
        {
            var res = new List<Boolean>(x.Count);
            for (Int16 i = 0; i < x.Count; i++)
            {
                res.Add(!x[i]);
            }
            return res;
        }

        public static int FirstIndex<T>(this IList<T> list, Func<T, bool> predicate)
        {
            var i = 0;
            foreach (var t in list)
            {
                if (predicate(t))
                    return i;
                i++;
            }
            return -1;
        }

        public static int LastIndex<T>(this IList<T> list, Func<T, bool> predicate)
        {
            var i = list.Count-1;
            foreach (var t in list.Reverse())
            {
                if (predicate(t))
                    return i;
                i--;
            }
            return -1;
        }

        public static IList<T> Clone<T>(this ICollection<T> source)
        {
            return new List<T>(source);
        }
    }
}
