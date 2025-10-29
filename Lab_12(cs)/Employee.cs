using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab_12_cs_
{
    internal abstract class Employee
    {
        public string Name { get; set; }
        public int WorkHours { get; set; }
        public Employee(string name) 
        {
            Name = name;
        }
    }
    internal class  StandardEmployee : Employee
    {
        public StandardEmployee(string name) : base(name)
        {
            WorkHours = 40;
        }
    }
    internal class PTEmployee : Employee
    {
        public PTEmployee(string name) : base(name)
        {
            WorkHours = 20;
        }
    }
    internal delegate void WorkDoneEventHandler(Job job);

    internal class Job
    {
        public string JobName { get; set; }
        public int HoursRequired { get; set; }
        public Employee AssignedEmployee { get; set; }
        public event WorkDoneEventHandler WorkDone;
        public Job(string jobName, int hoursRequired, Employee assignedEmployee)
        {
            JobName = jobName;
            HoursRequired = hoursRequired;
            AssignedEmployee = assignedEmployee;
        }
        public void UpdateHours()
        {
            HoursRequired -= AssignedEmployee.WorkHours;
            if (HoursRequired <= 0)
            {
                Console.WriteLine($"Job {JobName} done!");
                WorkDone?.Invoke(this);
            }
        }
        public void PrintStatus()
        {
            Console.WriteLine($"Job: {JobName} Hours remained: {HoursRequired}");
        }
    }
}
