using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_9_cs_
{
    internal class CustomList<T> where T : IComparable<T>
    {
        private List<T> items = new List<T> { };

        public void Add(T item)
        {
            items.Add(item);
        }
        public T Remove(int index)
        {
            if (index < 0 && index > items.Count - 1)
            {
                throw new ArgumentOutOfRangeException("Index out of range");
            }
           T item = items[index];
            items.RemoveAt(index);
            return item;
        }
        public bool Contains(T item)
        {
            return items.Contains(item);
        }
        public void Swap(int index1, int index2)
        {
            if (index1 < 0 || index1 >= items.Count) throw new ArgumentOutOfRangeException(nameof(index1));
            if (index2 < 0 || index2 >= items.Count) throw new ArgumentOutOfRangeException(nameof(index2));
            T temp = items[index1];
            items[index1] = items[index2];
            items[index2] = temp;
        }
        public int CountGreaterThan(T element)
        {
            int count = 0;
            foreach (var item in items)
            {
                if (item.CompareTo(element) > 0)
                    count++;
            }
            return count;
        }
        public T Max()
        {
            return items.Max();
        }
        public T Min()
        {
            return items.Min();
        }
        public void Print()
        {
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }
        internal List<T> Items => items;
    }
}
