using System;
using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data;
using P01_StudentSystem.Data.Models;
using P03_FootballBetting.Data;

namespace Program
{
    public static class Program
    {
        internal static void Seed(StudentSystemContext context)
        {

            Console.WriteLine("Seeding database...");

            var student1 = new Student
            {
                Name = "Oleksandr Petrenko",
                PhoneNumber = "0991234567",
                RegisteredOn = new DateOnly(2024, 11, 13),
                Birthday = new DateOnly(2000, 11, 11)
            };

            var student2 = new Student
            {
                Name = "Maria Kovalenko",
                PhoneNumber = "0977654321",
                RegisteredOn = new DateOnly(2024, 04, 12),
                Birthday = new DateOnly(2001, 11, 11)
            };

            var student3 = new Student
            {
                Name = "Ivan Sydorov", 
                RegisteredOn = new DateOnly(2025, 11, 29)
            };

            context.Students.AddRange(student1, student2, student3);

            var course1 = new Course
            {
                Name = "C# Advanced",
                Description = "Deep dive into .NET",
                StartDate = new DateOnly(2025, 09, 12),
                EndDate = new DateOnly(2025, 11, 15),
                Price = 150.00m
            };

            var course2 = new Course
            {
                Name = "Entity Framework Core",
                Description = "Database management",
                StartDate = new DateOnly(2025, 11, 29), 
                EndDate = new DateOnly(2025, 01, 29),
                Price = 200.00m
            };

            context.Courses.AddRange(course1, course2);

            var resource1 = new Resource
            {
                Name = "C# Introduction Video",
                Url = "https://youtube.com/example1",
                ResourceType = ResourceType.Video,
                Course = course1
            };
                
            var resource2 = new Resource
            {
                Name = "EF Core Documentation",
                Url = "https://learn.microsoft.com",
                ResourceType = ResourceType.Document,
                Course = course2
            };

            context.Resources.AddRange(resource1, resource2);

            var hw1 = new HomeworkSubmissions
            {
                Content = "my_solution.zip",
                ContentType = ContentType.ZIP,
                SubmissionTime = DateTime.Now.AddDays(-2),
                Student = student1,
                Course = course1
            };

            var hw2 = new HomeworkSubmissions
            {
                Content = "essay.pdf",
                ContentType = ContentType.PDF,
                SubmissionTime = DateTime.Now.AddHours(-5),
                Student = student2,
                Course = course1
            };

            context.HomeworkSubmissons.AddRange(hw1, hw2);

            context.StudentCourses.Add(new StudentCourses { Student = student1, Course = course1 });
            context.StudentCourses.Add(new StudentCourses { Student = student1, Course = course2 });

            context.StudentCourses.Add(new StudentCourses { Student = student2, Course = course1 });

            context.StudentCourses.Add(new StudentCourses { Student = student3, Course = course2 });

            context.SaveChanges();
            Console.WriteLine("Database seeded successfully!");
        }
        private static void PrintAllDatabaseData(StudentSystemContext context)
        {
            Console.WriteLine("========== FULL DATABASE REPORT ==========\n");

            PrintStudents(context);
            PrintCourses(context);
            PrintResources(context);
            PrintHomeworks(context);
        }

        private static void PrintStudents(StudentSystemContext context)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("--- TABLE: STUDENTS ---");
            Console.ResetColor();

            var students = context.Students
                .Include(s => s.HomeworkSubmissions)
                .ToList();

            if (!students.Any())
            {
                Console.WriteLine("No students found.");
                return;
            }

            foreach (var s in students)
            {
                var birthday = s.Birthday?.ToShortDateString() ?? "Not set";
                Console.WriteLine($"ID: {s.StudentId} | Name: {s.Name} | Phone: {s.PhoneNumber ?? "N/A"}");
                Console.WriteLine($"   -> Birthday: {birthday}");
                Console.WriteLine($"   -> Registered: {s.RegisteredOn.ToShortDateString()}");
                Console.WriteLine($"   -> Homeworks submitted: {s.HomeworkSubmissions.Count}");
                Console.WriteLine(new string('-', 20));
            }
            Console.WriteLine();
        }

        private static void PrintCourses(StudentSystemContext context)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("--- TABLE: COURSES ---");
            Console.ResetColor();

            var courses = context.Courses
                .Include(c => c.Resources)
                .ToList();

            if (!courses.Any())
            {
                Console.WriteLine("No courses found.");
                return;
            }

            foreach (var c in courses)
            {
                Console.WriteLine($"ID: {c.CourseId} | Name: {c.Name} | Price: {c.Price}$");
                Console.WriteLine($"   -> Duration: {c.StartDate.ToShortDateString()} - {c.EndDate.ToShortDateString()}");
                Console.WriteLine($"   -> Description: {c.Description ?? "None"}");
                Console.WriteLine($"   -> Resources count: {c.Resources.Count}");
                Console.WriteLine(new string('-', 20));
            }
            Console.WriteLine();
        }

        private static void PrintResources(StudentSystemContext context)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--- TABLE: RESOURCES ---");
            Console.ResetColor();

            var resources = context.Resources
                .Include(r => r.Course)
                .ToList();

            if (!resources.Any())
            {
                Console.WriteLine("No resources found.");
                return;
            }

            foreach (var r in resources)
            {
                Console.WriteLine($"ID: {r.ResourceId} | Name: {r.Name} ([{r.ResourceType}])");
                Console.WriteLine($"   -> Url: {r.Url}");
                Console.WriteLine($"   -> Linked to Course: {r.Course.Name}");
            }
            Console.WriteLine();
        }

        private static void PrintHomeworks(StudentSystemContext context)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("--- TABLE: HOMEWORKS ---");
            Console.ResetColor();

            var homeworks = context.HomeworkSubmissons
                .Include(h => h.Student)
                .Include(h => h.Course)
                .ToList();

            if (!homeworks.Any())
            {
                Console.WriteLine("No homework submissions found.");
                return;
            }

            foreach (var h in homeworks)
            {
                Console.WriteLine($"ID: {h.HomeworkId} | Type: {h.ContentType}");
                Console.WriteLine($"   -> Content: {h.Content}");
                Console.WriteLine($"   -> Submitted: {h.SubmissionTime}");
                Console.WriteLine($"   -> Student: {h.Student.Name}");
                Console.WriteLine($"   -> Course: {h.Course.Name}");
                Console.WriteLine(new string('-', 20));
            }
            Console.WriteLine();
        }
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Select task 1-2, 0 for exit");
                var task = Console.ReadLine();
                if (task == "0")
                {
                    return;
                }
                switch (task)
                {   
                    case "1":
                        {
                            using (var context = new StudentSystemContext())
                            {
                                context.Database.Migrate();
                                Seed(context);
                                PrintAllDatabaseData(context);
                            }
                            
                        }
                        break;
                    case "2":
                        {
                            using (var context = new FootballSystemContext())
                            {
                                context.Database.EnsureCreated();
                                Console.WriteLine("Database created");
                            }
                        }
                        break;
                    default:
                        Console.WriteLine("Wrong choice");
                        break;
                }
            }
            

        }
    }
}