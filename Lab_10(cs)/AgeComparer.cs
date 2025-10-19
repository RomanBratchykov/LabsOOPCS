using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_10_cs_
{
    internal class AgeComparer : IComparer<PersonSecond>
    {
        public int Compare(PersonSecond? x, PersonSecond? y)
        {
            if (x == null || y == null)
            {
                throw new ArgumentException("One or both objects are not of type PersonSecond");
            }
            return x.Age.CompareTo(y.Age);
        }
    }
}
