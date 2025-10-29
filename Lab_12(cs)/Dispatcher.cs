using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab_12_cs_
{
    public delegate void NameChangeEventHandler(object o, NameChangeEventArgs eventHandler);

    public class NameChangeEventArgs : EventArgs
    {
        public  string Name { get; private set; }
        public  NameChangeEventArgs(string name)
        {
            Name = name;
        }
    }

    internal class Dispatcher
    {
        private string name;

        public event NameChangeEventHandler NameChange;
        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    OnNameChange(new NameChangeEventArgs(value));
                    name = value;
                }
            }
        }
        public virtual void OnNameChange(NameChangeEventArgs args)
        {
            NameChange.Invoke(this, args);
        }
    }
    public class Handler
    {
        public void OnNameChange(object o, NameChangeEventArgs args)
        {
            Console.WriteLine($"Name changed to: {args.Name}");
        }
    }
}
