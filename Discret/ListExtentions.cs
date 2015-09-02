using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discret
{
    public static class ListExtentions
    {
        public static List<Boolean> And(this List<Boolean> x, List<Boolean> y){
            if (x.Count != y.Count) throw new ArgumentException("diff lenght");
            var res = new List<Boolean>(x.Count);
            for (Int16 i = 0; i < x.Count; i++)
            {
                res.Add(x[i] && y[i]);
            }
            return res;
        }

        public static List<Boolean> Or(this List<Boolean> x, List<Boolean> y)
        {
            if (x.Count != y.Count) throw new ArgumentException("diff lenght");
            var res = new List<Boolean>(x.Count);
            for (Int16 i = 0; i < x.Count; i++)
            {
                res.Add(x[i] || y[i]);
            }
            return res;
        }

        public static List<Boolean> Not(this List<Boolean> x)
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
