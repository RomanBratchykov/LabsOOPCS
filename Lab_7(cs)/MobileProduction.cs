using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_7
{
    internal interface ICallable
    {
       public void Call(string number);
    }
    internal interface IWatchable
    {
       public void Watch(string video);
    }
    internal class MobileProduction : ICallable, IWatchable
    {
        string model = string.Empty;
        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        public MobileProduction(string model)
        {
            Model = model;
        }
        public void Call(string number)
        {
            foreach (char c in number)
            {
                if (!char.IsDigit(c))
                {
                    throw new ArgumentException("Invalid phone number");
                }
            }
            Console.WriteLine($"Calling {number}...");
        }
        public void Watch(string video)
        {
            foreach (var c in video)
            {
                if (char.IsDigit(c))
                {
                    throw new ArgumentException("Invalid URL");
                }
            }
            Console.WriteLine($"Watching {video}...");
        }

    }
}
