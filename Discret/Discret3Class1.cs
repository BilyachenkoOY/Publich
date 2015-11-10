using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discret
{
    public partial class Set
    {
        public static Set operator ++(Set operand)
        {
            var result = new Set(operand);
            for (var i = 0; i < result.Count; i++)
            {
                result[i] = !result[i];
                if (result[i])
                    break;
            }
            return result;
        }

        public static Set operator --(Set operand)
        {
            var result = new Set(operand);
            for (var i = 0; i < result.Count; i++)
            {
                result[i] = !result[i];
                if (!result[i])
                    break;
            }
            return result;
        }

        public IList<int> ToList( )
        {
            var result = new List<int>(current.Count);
            for (var i = 0; i < current.Count; i++)
                if (current[i])
                    result.Add(parrent[i]);
            return result;
        }

        public IList<Set> SubSets(bool useParrent = false)
        {
            Set t = Copy(useParrent);
            int count = 2 << (t.Count-1);
            var result = new List<Set>(count);
            for(var i = 0; i < count; i++)
                result.Add(t++);
            return result;
        }

        public IList<Set> SubSetsGray(bool useParrent = false)
        {
            Set t = Copy(useParrent);
            int position;
            var result = new List<Set>(2 << (t.Count-1));
            do{
                result.Add(t.Clone());
                position = 0;
                for (var j = result.Count; j % 2 == 0; j /= 2)
                    position++;
                if (position < t.Count)
                    t[position] = !t[position];
            }while(position<t.Count);
            return result;
        }

        #region SubSets lex
        public IList<Set> SubSets(int k, bool useParrent = false)
        {
            Set tmp = Copy(useParrent);
            if (k > tmp.Count)
                throw new ArgumentOutOfRangeException("k");
            var result = new List<Set>();
            int i;
            for (i = 0; i < k; i++)
                tmp[i] = true;

            for (i = 0; tmp.current.FindIndex(b => b) < tmp.Count - k; i++)
            {
                IterateLast(tmp, result);

                IterateSubsets(tmp);
            }

            result.Add(tmp);
            return result;
        }

        protected static void IterateLast(Set tmp, List<Set> result)
        {
            for (var index = tmp.current.FindLastIndex(b => b); index < tmp.Count; index++)
            {
                tmp[index] = true;
                result.Add(tmp.Clone());
                tmp[index] = false;
            }
        }

        protected static void IterateSubsets(Set tmp)
        {
            for (var j = 0; j < tmp.Count; j++)
            {
                if (tmp[j] && !tmp[j + 1])
                {
                    if (j + 2 < tmp.Count)
                    {
                        tmp[j] = false;
                        tmp[j + 1] = true;
                        break;
                    }
                    else
                    {
                        for (j--; j > 0; j++)
                            if (tmp[j] && !tmp[j + 1])
                            {
                                tmp[j] = false;
                                tmp[j + 1] = true;
                                tmp[j + 2] = true;
                                break;
                            }
                        break;
                    }
                }
            }
            tmp[tmp.current.LastIndexOf(true) + 1] = true;
        }
        #endregion

        protected Set Clone( )
        {
            return new Set(this.current, this.parrent);
        }

        protected Set Copy(bool useParrent)
        {
            Set t;
            if (useParrent)
                t = new Set(new int[0], this.parrent);
            else
                t = new Set(new int[0], this.ToList());
            return t;
        }
    }
}
