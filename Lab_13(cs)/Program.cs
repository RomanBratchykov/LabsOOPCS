using System;

class Program
{
    class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public int Age { get; set; }

        public int Group { get; set; }

        public string Email { get; set; }
        public string Phone { get; set; }

        public string Faculty { get; set; }
        public int[] Marks { get; set; }
        public Student(string firstName, string lastName, int age, int group, string email, string phone, int[] marks, string faculty)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Group = group;
            Email = email;
            Phone = phone;
            Marks = marks;
            Faculty = faculty;
        }
        public void PrintMarks()
        {
            Console.WriteLine(string.Join(", ", Marks));
        }
    }
    public class Person
    {
        public string Name { get; set; } = string.Empty;
        public int Group { get; set; }

        public Person(string name, int group)
        {
            Name = name;
            Group = group;
        }
    }
    static void Main(string[] args)
    {
        List<Student> students = new List<Student>();

        students.Add(new Student("Sara", "Mills", 24, 1, "smills@gmail.com", "02435521", [6, 6, 6, 5], "554214"));
        students.Add(new Student("Andrew", "Gibson", 21, 2, "agibson@abv.bg", "0895223344", [3, 4, 5, 6], "653215"));
        students.Add(new Student("Craig", "Ellis", 19, 1, "cellis@cs.edu.gov", "+3592667710", [4, 2, 3, 4], "156212"));
        students.Add(new Student("Steven", "Cole", 35, 2, "themachine@abv.bg", "3242133312", [5, 6, 5, 5], "324413"));
        students.Add(new Student("Andrew", "Carter", 15, 2, "ac147@gmail.com", "+001234532", [5, 3, 4, 2], "134014"));
        var task1 = students.Where(s => s.Group == 2).OrderBy(s => s.FirstName);
        Console.WriteLine("Task 1:");
        foreach (var student in task1)
        {
            Console.WriteLine($"{student.FirstName} {student.LastName}");
        }
        Console.WriteLine("Task 2:");
        var task2 = students.Where(s => s.FirstName.CompareTo(s.LastName) < 0);
        foreach (var student in task2)
        {
            Console.WriteLine($"{student.FirstName} {student.LastName}");
        }
        Console.WriteLine("Task 3:");
        var task3 = students.Where(s => s.Age >= 18 && s.Age <= 24);
        foreach (var student in task3)
        {
            Console.WriteLine($"{student.FirstName} {student.LastName} {student.Age}");
        }
        Console.WriteLine("Task 4:");
        var task4 = students.OrderBy(s => s.LastName).ThenByDescending(s => s.FirstName);
        foreach (var student in task4)
        {
            Console.WriteLine($"{student.FirstName} {student.LastName}");
        }
        Console.WriteLine("Task 5:");
        var task5 = students.Where(s => s.Email.EndsWith("@gmail.com"));
        foreach (var student in task5)
        {
            Console.WriteLine($"{student.FirstName} {student.LastName}");
        }
        Console.WriteLine("Task 6:");
        var task6 = students.Where(s => s.Phone.StartsWith("02") || s.Phone.StartsWith("+3592"));
        foreach (var student in task6)
        {
            Console.WriteLine($"{student.FirstName} {student.LastName}");
        }
        Console.WriteLine("Task 7:");
        var task7 = students.Where(s => s.Marks.Contains(6));
        foreach (var student in task7)
        {
            Console.WriteLine($"{student.FirstName} {student.LastName}");
        }
        Console.WriteLine("Task 8:");
        var task8 = students.Where(s => s.Marks.Count(m => m <= 3) >= 2);
        foreach (var student in task8)
        {
            Console.WriteLine($"{student.FirstName} {student.LastName}");
        }
        Console.WriteLine("Task 9:");
        var task9 = students.Where(s => s.Faculty.EndsWith("14") || s.Faculty.EndsWith("15"));
        foreach (var student in task9)
        {
            student.PrintMarks();
        }
        List<Person> people = new List<Person>();
        people.Add(new Person("Ivaylo Petrov", 10));
        people.Add(new Person("Stanimir Svilianov", 3));
        people.Add(new Person("Indje Kromidov", 3));
        people.Add(new Person("Irina Balabanova", 4));
        var task10 = people.GroupBy(p => p.Group);
        Console.WriteLine("Task 10:");
        foreach (var group in task10)
        {
            Console.WriteLine($"Group {group.Key}:");
            foreach (var person in group)
            {
                Console.WriteLine(person.Name);
            }
        }

    }
}