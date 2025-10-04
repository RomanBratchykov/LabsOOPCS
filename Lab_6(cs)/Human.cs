using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6;

internal abstract class Human
{
    private string name = string.Empty; 
    private string surname = string.Empty; 

    public string Name
    {
        get { return name; }
        set
        {
            if (!char.IsUpper(value[0]))
            {
                throw new ArgumentException("Expected upper case letter! Argument: firstName");
            }
            if (value.Length <= 3)
            {
                throw new ArgumentException("Expected length at least 4 symbols! Argument: firstName");
            }
            this.name = value;
        }
    }

    public string Surname
    {
        get { return surname; }
        set
        {
            if (!char.IsUpper(value[0]))
            {
                throw new ArgumentException("Expected upper case letter! Argument: lastName");
            }
            if (value.Length <= 2)
            {
                throw new ArgumentException("Expected length at least 3 symbols! Argument: lastName");
            }
            this.surname = value;
        }
    }

    public Human(string name, string surname)
    {
        this.Name = name;
        this.Surname = surname;
    }
    public virtual void toString()
    {
        Console.WriteLine($"First Name: {this.Name}");
        Console.WriteLine($"Last Name: {this.Surname}");
    }
}
