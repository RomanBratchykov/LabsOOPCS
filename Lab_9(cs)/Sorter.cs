using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_9_cs_
{
    internal static class Sorter
    {
        public static void Sort<T>(CustomList<T> list) where T : IComparable<T>
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list), "The list cannot be null.");
            list.Items.Sort();
        }
    }
}
