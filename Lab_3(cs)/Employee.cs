using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3_cs_
{
    internal class Employee
    {
        string name;
        decimal salary;
        string position;
        string department;
        string email;
        int age;
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public Employee(string name, decimal salary, string position, string department)
        {
            this.Name = name;
            this.Salary = salary;
            this.Position = position;
            this.Department = department;
            this.Email = "n/a";
            this.Age = -1;
        }
        public Employee(string name, decimal salary, string position, string department, string email) : this(name, salary, position, department)
        {
            this.Email = email;
        }
        public Employee(string name, decimal salary, string position, string department, int age) : this(name, salary, position, department)
        {
            this.Age = age;
        }
        public Employee(string name, decimal salary, string position, string department, int age, string email) : this(name, salary, position, department, email)
        {
            this.Age = age;
        }
        public string printEmployee()
        {
            return $"{this.Name}, {this.Salary:F2}, {this.Email}, {this.Age}";
        }
    }
}
