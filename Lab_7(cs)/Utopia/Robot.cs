using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_7
{
    internal class Robot : IEnterable
    {
        string id;
        string model;
        public string Id { get { return id; }; set { id = value; } }

        public string Model { get { return model; } set { model = value; } }

        public Robot(string id, string model)
        {
            Id = id;
            Model = model;
        }
    }
}
