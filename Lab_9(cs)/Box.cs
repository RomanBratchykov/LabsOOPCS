using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_9_cs_
{
    internal class Box<T> where T : IComparable<T>
    {
        T value;
        public T Value { get; set; }

        public Box(T value)
        {
            this.Value = value;
        }
        public int CompareTo(Box<T> other)
        {
            return Value.CompareTo(other.Value);
        }

        public override string ToString()
        {
            return $"{Value.GetType().FullName}: {Value}";
        }
    }
}
