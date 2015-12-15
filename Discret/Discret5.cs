using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discret
{
    public partial class Set
    {
        public IList<IList<int>> SubPermutations(int k)
        {
            var result = new List<IList<int>>();
            foreach (var sub in this.SubSets(k))
            {
                var antilex = sub.ToList().AntiLex();
                result.AddRange(antilex);
            }
            return result;
        }
    }
}
