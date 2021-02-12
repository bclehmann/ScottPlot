using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScottPlot.Wrappers
{
    public class MemoryWrapper<T> : ArrayWrapperBase<T>
    {
        private Memory<T> memory;

        public MemoryWrapper(Memory<T> memory)
        {
            this.memory = memory;
            IsNull = memory.IsEmpty; // To remain compatible with empty arrays
        }

        public static implicit operator MemoryWrapper<T>(Memory<T> memory) => new MemoryWrapper<T>(memory);

        public override T this[int i] { get => memory.Span[i]; set => memory.Span[i] = value; }

        public override int Length => memory.Length;

        public override bool WrapSameObject(ArrayWrapperBase<T> other)
        {
            if (other is MemoryWrapper<T> tmp)
            {
                return memory.Equals(tmp);
            }

            return false;
        }

        public override T[] ToArray()
        {
            return memory.ToArray();
        }

        public override int GetHashCode()
        {
            return memory.GetHashCode();
        }
    }
}
