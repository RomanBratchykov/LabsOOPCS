using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_7
{
    internal class Robot : IEnterable, IShowable
    {
        string id;
        string model;
        public string Id { get { return id; } set { id = value; } }

        public string Model { get { return model; } set { model = value; } }

        public Robot(string model, string id)
        {
            Id = id;
            Model = model;
        }
        public void Show()
        {
            Console.WriteLine($"Robot {Id}, {Model}");
        }
    }
}
