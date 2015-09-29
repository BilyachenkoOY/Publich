using System;
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

    }
}
