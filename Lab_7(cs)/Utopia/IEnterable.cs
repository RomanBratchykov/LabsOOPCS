using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_7
{
    internal interface IEnterable
    {
       public string Id { get; set; }
        
    }
    internal interface IShowable
    {
        public virtual void Show() { }
    }
    internal interface IBirthable
    {
        public DateTime BirthDate { get; set; }
    }
}
