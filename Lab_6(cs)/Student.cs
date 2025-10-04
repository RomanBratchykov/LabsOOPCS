using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6;

internal class Student : Human
{
    private string facultyNumber = string.Empty;
    public string FacultyNumber
    {
        get { return facultyNumber; }
        set
        {
            if (value.Length < 5 || value.Length > 10 || !value.All(char.IsLetterOrDigit))
            {
                throw new ArgumentException("Invalid faculty number!");
            }
            facultyNumber = value;
        }
    }
    public Student(string name, string surname, string facultyNumber) : base(name, surname)
    {
        this.FacultyNumber = facultyNumber;
    }
    public override string ToString()
    {
        return $"First Name: {this.Name}\nLast Name: {this.Surname}\nFaculty number: {this.FacultyNumber}";
    }
}

