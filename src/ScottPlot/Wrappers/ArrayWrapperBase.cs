using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScottPlot.Wrappers
{
    public abstract class ArrayWrapperBase<T> : IEnumerable<T>
    {
        public abstract int Length { get; }
        public abstract T this[int i] { get; set; }
        public abstract T[] ToArray();
        public bool IsNull = false;

        public IEnumerator<T> GetEnumerator()
        {
            return new ArrayWrapperEnumerator<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public static implicit operator ArrayWrapperBase<T>(T[] array) => new ArrayWrapper<T>(array);
        public static implicit operator ArrayWrapperBase<T>(Memory<T> memory) => new MemoryWrapper<T>(memory);
        public static implicit operator T[](ArrayWrapperBase<T> arrayWrapper) => arrayWrapper.ToArray();


        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return IsNull;
            }
            return base.Equals(obj);
        }
    }

    public class ArrayWrapperEnumerator<T> : IEnumerator<T>
    {
        private int position = -1;
        private ArrayWrapperBase<T> collection;

        public ArrayWrapperEnumerator(ArrayWrapperBase<T> collection)
        {
            this.collection = collection;
        }

        public T Current()
        {
            try
            {
                return collection[position];
            }
            catch (IndexOutOfRangeException)
            {
                throw new InvalidOperationException();
            }
        }

        T IEnumerator<T>.Current => Current();

        object IEnumerator.Current => Current();

        public bool MoveNext()
        {
            position++;
            return !collection.IsNull && position < collection.Length;
        }

        public void Reset()
        {
            position = -1;
        }

        public void Dispose()
        {
            // noop
        }
    }
}
