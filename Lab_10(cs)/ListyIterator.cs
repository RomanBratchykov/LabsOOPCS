using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_10_cs_
{
    internal class ListyIterator<T> : IEnumerable<T>
    {
        List<T> collection;
        int currentIndex;
        public int CurrentIndex { get { return currentIndex; } }
        public ListyIterator(List<T> items)
        {
            collection = items;
            currentIndex = 0;
        }
        public ListyIterator()
        {
            collection = new List<T>();
            currentIndex = 0;
        }
        public bool Move()
        {
            if (currentIndex < collection.Count - 1)
            {
                currentIndex++;
                return true;
            }
            return false;
        }
        public bool HasNext()
        {
            return currentIndex < collection.Count - 1;
        }
        public void Print()
        {
            if (collection.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
            Console.WriteLine(collection[currentIndex]);
        }
        public void PrintAll()
        {
            if (collection.Count == 0)
            {
                throw new InvalidOperationException("Collection is empty!");
            }
            foreach (var item in collection)
            {
                Console.WriteLine(item );
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < collection.Count; i++)
            {
                yield return collection[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
