using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScottPlot.Wrappers
{
    public class ArrayWrapper<T> : ArrayWrapperBase<T>
    {
        private T[] array;
        public ArrayWrapper(T[] array)
        {
            this.array = array;
            this.IsNull = array == null;
        }

        public static implicit operator ArrayWrapper<T>(T[] array) => new ArrayWrapper<T>(array);

        public override T this[int i] { get => array[i]; set => array[i] = value; }
        public override T[] ToArray()
        {
            T[] tmp = new T[Length];
            Array.Copy(array, tmp, Length);
            return tmp;
        }

        public override bool WrapSameObject(ArrayWrapperBase<T> other)
        {
            if (other is ArrayWrapper<T> tmp)
            {
                return tmp.array == array;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return array.GetHashCode();
        }

        public override int Length => array.Length;
    }
}
