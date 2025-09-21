using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3_cs_
{
    internal class Family
    {
        List<Person> membersOfFamily = new List<Person>();
        public void AddMember(Person person)
        {
            membersOfFamily.Add(person);
        }
        public void showMembers()
        {
            foreach (var member in membersOfFamily)
            {
                Console.WriteLine($"{member.Name} {member.Age}");
            }
        }
        public Person GetOldestMember()
        {
            return membersOfFamily.OrderByDescending(x => x.Age).First();
        }
        public void PrintOldestMember()
        {
            var oldest = membersOfFamily.OrderByDescending(x => x.Age).First();
            Console.WriteLine($"{oldest.Name} {oldest.Age}");
        }
    }
}
