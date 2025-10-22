using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_11_cs_
{
    [AttributeUsage(AttributeTargets.Class)]
    internal class CustomAttribute : Attribute
    {
        public string Author { get; }
        public int Revision { get; }
        public string Description { get; }
        public string[] Reviewers { get; }

        public CustomAttribute(string author, int revision, string description, string[] reviewers)
        {
            Author = author;
            Revision = revision;
            Description = description;
            Reviewers = reviewers;
        }
    }
}
