using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discret
{
    public partial class Class1
    {
        public static Class1 operator ++(Class1 operand)
        {
            var result = new Class1(operand);
            for (var i = 0; i < result.current.Count; i++)
            {
                result.current[i] = !result.current[i];
                if (result.current[i])
                    break;
            }
            return result;
        }

        public static Class1 operator --(Class1 operand)
        {
            var result = new Class1(operand);
            for (var i = 0; i < result.current.Count; i++)
            {
                result.current[i] = !result.current[i];
                if (!result.current[i])
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

        public IList<Class1> Generate(bool useParrent = false)
        {
            var t = new Class1(new int[0], this.ToList());
            int count = 2 << (t.current.Count-1);
            var result = new List<Class1>(count);
            for(var i = 0; i < count; i++)
                result.Add(t++);
            return result;
        }
    }
}
