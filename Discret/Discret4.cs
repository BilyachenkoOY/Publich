using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System;

namespace Discret
{
    public static class Discret4
    {
        public static IList<IList<T>> Lex<T>(this ICollection<T> source)
        {
            if (source == null)
                return null;
            var result = new List<IList<T>>();

            if (source.Count <= 1)
            {
                result.Add(new List<T>(source));
                return result;
            }

            foreach (var t in source)
            {
                var suf = Lex(source.Where(x => !x.Equals(t)).ToList());
                foreach (var s in suf)
                {
                    s.Insert(0, t);
                    result.Add(new List<T>(s));
                }

            }

            return result;
        }

        public static IList<IList<T>> AntiLex<T>(this ICollection<T> source)
        {
            /*
            if (source == null)
                return null;
            var result = new List<IList<T>>();

            if (source.Count <= 1)
            {
                result.Add(new List<T>(source));
                return result;
            }

            var i = source.Count-1;
            foreach (var t in source.Reverse())
            {
                var suf = AntiLex(source.Where((x, index) => index != i).ToList());
                foreach (var s in suf)
                {
                    s.Add(t);
                    result.Add(new List<T>(s));
                }
                i--;
            }

            return result;
            */
            ArrayList.Adapter((IList)source).Sort();

            return new AntiLexCore<T>(source).Results;
            /* */
        }

        private class AntiLexCore<T>
        {
            private IList<T> list;

            public IList<IList<T>> Results { get; private set; }

            public AntiLexCore(ICollection<T> source)
            {
                if (source == null)
                    return;

                list = new List<T>(source);
                Results = new List<IList<T>>();

                if (source.Count <= 1)
                {
                    Results.Add(source.Clone());
                    return;
                }

                Execute(list.Count);
            }

            private void Execute(int position)
            {
                if (position == 0)
                {
                    Results.Add(list.Clone());
                    return;
                }

                for (var i = 0; i < position; i++)
                {
                    Execute(position - 1);
                    if (i < position - 1)
                    {
                        var t = list[i];
                        list[i] = list[position - 1];
                        list[position - 1] = t;
                        var newList = list.Take(position - 1).Reverse().ToList();
                        newList.AddRange(list.Skip(position - 1));
                        list = newList;
                    }
                }
            }
        }
    }
}
