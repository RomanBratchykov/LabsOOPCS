using System;

using P01_HospitalDatabase.Data; 
using P01_HospitalDatabase.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace P01_HospitalDatabase
{
    
    internal class Program
    {
        public static void AddVisitation()
        {
            using (var context = new HospitalContext())
            {
                Console.Write("Enter patient ID: ");
                int patientId = int.Parse(Console.ReadLine());
                Console.Write("Enter visitation date (yyyy-MM-dd): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Enter comments: ");
                string comments = Console.ReadLine();
                var visitation = new Visitation
                {
                    PatientId = patientId,
                    Date = date,
                    Comments = comments
                };
                context.visitations.Add(visitation);
                context.SaveChanges();
                Console.WriteLine("Visitation added successfully!");
            }
        }
       public static void AddPatient()
        {
            using (var context = new HospitalContext())
            {
                Console.Write("Enter first name: ");
                string firstName = Console.ReadLine();
                Console.Write("Enter last name: ");
                string lastName = Console.ReadLine();
                Console.Write("Enter address: ");
                string address = Console.ReadLine();
                Console.Write("Enter email: ");
                string email = Console.ReadLine();
                Console.Write("Has insurance (true/false): ");
                bool hasInsurance = bool.Parse(Console.ReadLine().ToLower());
                var patient = new Patient
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Address = address,
                    Email = email,
                    HasInsurance = hasInsurance
                };
                context.patients.Add(patient);
                context.SaveChanges();
                Console.WriteLine("Patient added successfully!");
                Console.ReadLine();
            }
        }
        public static void ListPatients()
        {
            using (var context = new HospitalContext())
            {
                var patients = context.patients.Select(p => new
                {
                    p.PatientId,
                    p.FirstName,
                    p.LastName,
                    p.Email,
                    Insured = p.HasInsurance ? "Yes" : "No"
                }).ToList();
                Console.WriteLine("Patients:");
                foreach (var patient in patients)
                {
                    Console.WriteLine($"ID: {patient.PatientId}, Name: {patient.FirstName} {patient.LastName}, Email: {patient.Email}, Ensurance: {patient.Insured}");
                }
            }
        }
        public static void ListVisitations()
        {
            using (var context = new HospitalContext())
            {
                var visitations = context.visitations.Select(p => new
                {
                    p.PatientId,
                    p.Date,
                    p.Comments
                }).ToList();
                Console.WriteLine("Visitations:");
                foreach (var v in visitations)
                {
                    Console.WriteLine($"ID: {v.PatientId}, Date: {v.Date}, Comments: {v.Comments}");
                }
            }
        }

        static void Main(string[] args)
        {
            while (true) { 
            Console.WriteLine("Select number of task 1-5, 0 to exit");
            int num = int.Parse(Console.ReadLine()!);
                switch (num)
                {
                    case 0:
                        return;
                    case 1:
                        {
                            using (var context = new HospitalContext())
                            {
                                context.Database.EnsureCreated();
                                Console.WriteLine("Database created");
                            }

                            while (true)
                            {
                                Console.Clear();
                                Console.WriteLine("--- menu ---");
                                Console.WriteLine("1. Add new patient");
                                Console.WriteLine("2. Show all patients");
                                Console.WriteLine("3. Add new visitation");
                                Console.WriteLine("4. show all visitations");
                                Console.WriteLine("0. Exit");
                                Console.WriteLine("------------");
                                Console.Write("Choose option: ");

                                var choice = Console.ReadLine();

                                switch (choice)
                                {
                                    case "1":
                                        AddPatient();
                                        Console.ReadLine();
                                        break;
                                    case "2":
                                        ListPatients();
                                        Console.ReadLine();
                                        break;
                                    case "3":
                                        AddVisitation();
                                        Console.ReadLine();
                                        break;
                                    case "4":
                                        ListVisitations();
                                        Console.ReadLine();
                                        break;
                                    case "0":
                                        return;
                                    default:
                                        Console.WriteLine("Wrong choice.");
                                        break;
                                }
                            }
                        }
                        break;
                    case 2:
                        {

                        }
                        break;
                    case 3:
                        {

                        }
                        break;
                    case 4:
                        {

                        }
                        break;
                    case 5:
                        {
                        }
                        break;
                    default:
                        {
                            Console.WriteLine("Invalid input");
                        }
                        break;
                }
            }
        }
    }
}