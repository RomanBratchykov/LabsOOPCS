using System;

class Program
{
    class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public int Age { get; set; }

        public int Group { get; set; }
        public Student(string firstName, string lastName, int age, int group)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Group = group;
        }
    }
    static void Main(string[] args)
    {
        List<Student> students = new List<Student>();

        students.Add(new Student("John", "Doe", 20, 101));
        students.Add(new Student("Jane", "Smith", 22, 102));
        students.Add(new Student("Alice", "Johnson", 19, 101));
        students.Add(new Student("Bob", "Brown", 21, 103));
        students.Add(new Student("Victor", "Moore", 20, 101));
        students.Add(new Student("Mike", "Smither", 22, 102));
        students.Add(new Student("Paul", "Nile", 19, 101));
        students.Add(new Student("Sara", "Nickolson", 21, 103));
        var task1 = students.Where(s => s.Group == 102).OrderBy(s => s.FirstName);
        foreach (var student in task1)
        {
            Console.WriteLine($"{student.FirstName} {student.LastName}");
        }
        var task2 = students.Where(s => s.FirstName.CompareTo(s.LastName) < 0);
        foreach (var student in task2)
        {
            Console.WriteLine($"{student.FirstName} {student.LastName}");
        }
        var task3 = students.Where(s => s.Age >= 18 && s.Age <= 24);
        foreach (var student in task3)
        {
            Console.WriteLine($"{student.FirstName} {student.LastName} {student.Age}");
        }
        var task4 = students.OrderBy(s => s.LastName).ThenByDescending(s => s.FirstName);
        foreach (var student in task4)
        {
            Console.WriteLine($"{student.FirstName} {student.LastName}");
        }
        var task5 = 
    }
}