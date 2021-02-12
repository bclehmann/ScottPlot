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

        public override T this[int i] { get => array[i]; set => array[i] = value; }
        public override T[] ToArray() => array;
        public override int Length => array.Length;
    }
}
