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
                Console.Write("Enter doctor ID: ");
                int doctorId = int.Parse(Console.ReadLine());
                Console.Write("Enter visitation date (yyyy-MM-dd): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Enter comments: ");
                string comments = Console.ReadLine();
                var visitation = new Visitation
                {
                    PatientId = patientId,
                    Date = date,
                    Comments = comments,
                    DoctorId = doctorId
                };
                context.Visitations.Add(visitation);
                context.SaveChanges();
                Console.WriteLine("Visitation added successfully!");
            }
        }
        public static void AddVisitationDoctor(int doctorId)
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
                    Comments = comments,
                    DoctorId = doctorId
                };
                context.Visitations.Add(visitation);
                context.SaveChanges();
                Console.WriteLine("Visitation added successfully!");
            }
        }
        public static void ListVisitationsDoctor(int doctorId)
        {
            using (var context = new HospitalContext())
            {
                var visitations = context.Visitations
                    .Where(p => p.DoctorId == doctorId)
                    .Select(p => new
                    {
                        p.PatientId,
                        p.Date,
                        p.Comments
                    })
                    .ToList();
                Console.WriteLine("Visitations:");
                foreach (var v in visitations)
                {
                    Console.WriteLine($"ID: {v.PatientId}, Date: {v.Date}, Comments: {v.Comments}");
                }
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
                context.Patients.Add(patient);
                context.SaveChanges();
                Console.WriteLine("Patient added successfully!");
            }
        }
        public static void AddDoctor()
        {
            using (var context = new HospitalContext())
            {
                Console.Write("Enter name: ");
                string name = Console.ReadLine();
                Console.Write("Enter specialty: ");
                string specialty = Console.ReadLine();
                var doctor = new Doctor
                {
                    Name = name,
                    Specialty = specialty,
                };
                context.Doctors.Add(doctor);
                context.SaveChanges();
                Console.WriteLine("Doctor added successfully!");
            }
        }
        public static void ListPatients()
        {
            using (var context = new HospitalContext())
            {
                var patients = context.Patients.Select(p => new
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
                var visitations = context.Visitations.Select(p => new
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
        public static void ListDoctors()
        {
            using (var context = new HospitalContext())
            {
                var doctors = context.Doctors.Select(d => new
                {
                    d.DoctorId,
                    d.Name,
                    d.Specialty
                }).ToList();
                Console.WriteLine("Doctors:");
                foreach (var doctor in doctors)
                {
                    Console.WriteLine($"ID: {doctor.DoctorId}, Name: {doctor.Name}, Specialty: {doctor.Specialty}");
                }
            }
        }

        static void Main(string[] args)
        {
            using (var context = new HospitalContext())
            {
                context.Database.Migrate();
                Console.WriteLine("Database created");
            }
            while (true) {
                Console.Clear();
            Console.WriteLine("Select number of task 1-5, 0 to exit");
            int num = int.Parse(Console.ReadLine()!);
                if (num == '0')
                {
                    return;
                }
                switch (num)
                {
                    case 1:
                        {
                            while (true)
                            {
                                Console.Clear();
                                Console.WriteLine("--- menu ---");
                                Console.WriteLine("1. Add new patient");
                                Console.WriteLine("2. Show all patients");
                                Console.WriteLine("3. Add new visitation");
                                Console.WriteLine("4. Show all visitations");
                                Console.WriteLine("5. Add doctor");
                                Console.WriteLine("6. Show all doctors");
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
                                    case "5":
                                        AddDoctor();
                                        Console.ReadLine();
                                        break;
                                    case "6":
                                        ListDoctors();
                                        Console.ReadLine();
                                        break;
                                    case "0":
                                        break;
                                    default:
                                        Console.WriteLine("Wrong choice.");
                                        break;
                                }
                            }
                        }
                        break;
                    case 2:
                        {
                            Console.WriteLine("Enter doctor ID and password");
                            Console.Write("Doctor ID: ");
                            int doctorId = int.Parse(Console.ReadLine());
                            Console.Write("Password: ");
                            string password = Console.ReadLine();
                            // Authentication logic would go here
                            { }
                             
                            while (true)
                            {
                                Console.Clear();
                                Console.WriteLine($"--- doctor {doctorId} menu ---");
                                Console.WriteLine("1. Add new visitation");
                                Console.WriteLine("2. Show all visitations");
                                Console.WriteLine("0. Exit");
                                Console.WriteLine("------------");
                                Console.Write("Choose option: ");

                                var choice = Console.ReadLine();
                                if (choice == "0")
                                {
                                    break;
                                }
                                switch (choice)
                                {
                                    case "1":
                                        AddVisitationDoctor(doctorId);
                                        Console.ReadLine();
                                        break;
                                    case "2":
                                        ListVisitationsDoctor(doctorId);
                                        Console.ReadLine();
                                        break;
                                    default:
                                        Console.WriteLine("Wrong choice.");
                                        break;
                                }
                            }
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