using System;
using System.Security.Cryptography.X509Certificates;
using System.Transactions;

namespace Lab_6;

public class Lab_6
{
    public static void Main()
    {
        Console.WriteLine("Choose task 1-4, 0 for exit");
        int task = int.Parse(Console.ReadLine());
        switch (task)
        {
            case 1:
                {
                    try
                    {
                        Console.WriteLine("Enter author, title and price");
                        string author = Console.ReadLine();
                        string title = Console.ReadLine();
                        decimal price = decimal.Parse(Console.ReadLine());
                        Book book = new Book(author, title, price);
                        GoldenEditionBook goldenEditionBook = new GoldenEditionBook(author, title, price);
                        book.showBook();
                        goldenEditionBook.showBook();
                    }
                    catch (ArgumentException ae)
                    {
                        Console.WriteLine(ae.Message);

                    }
                }
                break;
            case 2:
                {
                    Console.WriteLine("Enter student name, surname and faculty(example: john doe 894838), end to stop");
                    List<Student> students = new List<Student>();
                    string input = string.Empty;
                    while(true)
                    {
                        input = Console.ReadLine();
                        if (input.ToLower() == "end") break;
                        string[] parts = input.Split(' ');
                        if (parts.Length != 3)
                        {
                            Console.WriteLine("Invalid input format. Please enter in the format: name surname facultyNumber");
                            continue;
                        }
                        try
                        {
                            Student student = new Student(parts[0], parts[1], parts[2]);
                            students.Add(student);
                        }
                        catch (ArgumentException ae)
                        {
                            Console.WriteLine(ae.Message);
                        }
                    }
                    Console.WriteLine("Enter worker name, surname, salary per week, and work hours, end to stop");
                    List<Worker> workers = new List<Worker>();
                    while (true)
                    {
                        input = Console.ReadLine();
                        if (input.ToLower() == "end") break;
                        string[] parts = input.Split(' ');
                        if (parts.Length != 4)
                        {
                            Console.WriteLine("Invalid input format. Please enter in the format: name surname salaryPerWeek workHoursPerDay");
                            continue;
                        }
                        try
                        {
                            Worker worker = new Worker(parts[0], parts[1], decimal.Parse(parts[2]), int.Parse(parts[3]));
                            workers.Add(worker);
                        }
                        catch (ArgumentException ae)
                        {
                            Console.WriteLine(ae.Message);
                        }
                    }
                    Console.WriteLine("Students:");
                    foreach (var student in students.OrderBy(s => s.FacultyNumber))
                    {
                        Console.WriteLine(student);
                        Console.WriteLine();
                    }
                    Console.WriteLine("Workers:");
                    foreach (var worker in workers)
                    {
                        Console.WriteLine(worker);
                        Console.WriteLine();
                    }
                }
                break;
            case 3:
                throw new NotImplementedException();
                break;
            case 4:
                throw new NotImplementedException();
                break;
            case 0:
                return;
            default:
                Console.WriteLine("Invalid task number");
                break;
        }
    }
}

