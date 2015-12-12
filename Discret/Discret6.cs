using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discret
{
    public class MultiSet<T>
    {
        protected IList<T> parrent;
        protected IList<int> list;

        public MultiSet(IList<T> source, IList<T> parrent)
        {
            Reset(source, parrent);
        }

        public MultiSet(IList<T> parrent):this(new T[]{}, parrent)
        {
        }

        public void Reset(IList<T> source, IList<T> parrent = null)
        {
            if (source == null)
                throw new ArgumentException("source");
            if (parrent == null)
                parrent = source;
            else if (source.Count > parrent.Count)
                throw new ArgumentException("source", "Source > parrent");

            this.parrent = new List<T>(parrent);
            this.list = new List<int>(this.parrent.Count);

            foreach (var p in this.parrent)
            {
                if (source.Contains(p))
                    this.list.Add(1);
                else
                    this.list.Add(0);
            }
        }

        public IList<IList<T>> MultiVectors(int k, bool useParrent = true)
        {
            var temp = useParrent ? new MultiSet<T>(this.parrent) : new MultiSet<T>(this.ToList());

            return temp.MultiVectorsCore(k);
        }

        private IList<IList<T>> MultiVectorsCore(int k)
        {
            var maxCount = (int)Math.Pow(Count, k);
            var result = new List<IList<T>>(maxCount);

            var tmp = CloneItem(parrent.First(), k);
            var tmpNo = CloneItem(0, k);

            result.Add(tmp.Clone());

            while (result.Count != maxCount)
            {

                var i = tmpNo.Count - 1;
                while (true)
                {
                    if (tmpNo[i] != parrent.Count - 1)
                    {
                        tmp[i] = parrent[++tmpNo[i]];
                        result.Add(tmp.Clone());
                    }
                    else
                    {
                        var j = tmpNo.LastIndex(x => x != parrent.Count - 1);
                        if (j > -1)
                        {
                            tmp[j] = parrent[++tmpNo[j]];
                            for (j++; j < tmpNo.Count; j++)
                            {
                                tmpNo[j] = 0;
                                tmp[j] = parrent.First();
                            }
                            result.Add(tmp.Clone());
                        }
                        break;
                    }
                    
                }
            }

            return result;
        }

        public IList<IList<T>> MultiSets(int k, bool useParrent = true)
        {
            var temp = useParrent ? new MultiSet<T>(this.parrent) : new MultiSet<T>(this.ToList());

            return temp.MultiSetsCore(k);
        }

        private List<IList<T>> MultiSetsCore(int k)
        {
            list[0] = k;

            var result = new List<IList<T>>();

            while (list.Last() != k)
            {
                var start = list.FirstIndex(x => x > 0);
                for (var i = start; i < list.Count; i++)
                {
                    result.Add(this.ToList());
                    list[i]--;
                    if (i + 1 < list.Count)
                        list[i + 1]++;
                    else
                        list[start + 1]++;
                }
            }
            return result;
        }

        public int Count { get { return parrent.Count; } }

        public List<T> ToList( )
        {
            var result = new List<T>();
            int i = 0;
            foreach(var t in this.parrent){
                var count = this.list[i];
                if(count > 0)
                    result.AddRange(CloneItem(t, count));
                i++;
            }
            return result;
        }

        protected IList<TItem> CloneItem<TItem>(TItem item, int count)
        {
            var result = new List<TItem>(count);
            while (count > 0)
            {
                result.Add(item);
                count--;
            }
            return result;
        }

        protected Dictionary<int, T> CreateDictionary(ICollection<int> keys, ICollection<T> values)
        {
            var dictionary = new Dictionary<int, T>(keys.Count);
            var i = 0;
            foreach (var val in values)
            {
                dictionary.Add(keys.ElementAt(i++), val);
            }
            return dictionary;
        }
    }
}
