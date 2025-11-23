using System;

using P01_HospitalDatabase.Data; 

using P01_HospitalDatabase.Data.Models;
using P03_SalesDatabase.Data.Models;
using P03_SalesDatabase.Data;
using Microsoft.EntityFrameworkCore;

namespace Program
{
   
    internal class Program
    {
        static string[] names = { "Butter", "Milk", "Cheese", "Yogurt", "Bread", "Eggs", "Juice", "Cereal", "Apples", "Bananas" };
        static string[] storeNames = { "FreshMart", "GroceryHub", "DailyNeeds", "SuperSaver", "FoodBazaar", "MarketPlace", "ShopEasy", "ValueMart", "QuickBuy", "UrbanGrocer" };
        static string[] customerNames = { "Alice", "Bob", "Charlie", "David", "Eva", "Frank", "Grace", "Hannah", "Ian", "Judy" };
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

        public static void Seed(int numOfRecords)
        {
            using (var context = new SalesContext())
            {
                var random = new Random();
                for (int i = 0; i < numOfRecords; i++)
                {
                    var name = names[random.Next(names.Length)];
                    var product = new Product
                    {
                        Name = name,
                        Price = (decimal)(random.Next(100, 10000) / 100.0),
                        Quantity = random.Next(1, 101),
                        Description = $"{name} description"
                    };
                    context.Products.Add(product);
                    var storeName = storeNames[random.Next(storeNames.Length)];
                    var store = new Store
                    {
                        Name = storeName
                    };
                    context.Stores.Add(store);
                    var customerName = customerNames[random.Next(customerNames.Length)];
                    var customer = new Customer
                    {
                        Name = customerName,
                        Email = $"{customerName.ToLower()}@example.com",
                        CreditCardNumber = random.Next(1000_0000, 9999_9999).ToString() + random.Next(1000_0000, 9999_9999).ToString()
                    };
                    context.Customers.Add(customer);
                }
                context.SaveChanges();
                    var products = context.Products.ToList();
                    var customers = context.Customers.ToList();
                    var stores = context.Stores.ToList();
                for (int i = 0; i < numOfRecords; i++)
                {
                    context.Sales.Add(new Sale
                    {
                        ProductId = products[random.Next(products.Count)].ProductId,
                        CustomerId = customers[random.Next(customers.Count)].CustomerId,
                        StoreId = stores[random.Next(stores.Count)].StoreId
                    });
                }
                context.SaveChanges();
            }
        }
        static void PrintAllTables() {
            using (var context = new SalesContext())
            {
                var products = context.Products.ToList();
                Console.WriteLine("Products:");
                foreach (var product in products)
                {
                    Console.WriteLine($"ID: {product.ProductId}, Name: {product.Name}, Price: {product.Price}, Quantity: {product.Quantity}, Description: {product.Description}"); //, Description: {product.Description}
                }
                var customers = context.Customers.ToList();
                Console.WriteLine("Customers:");
                foreach (var customer in customers)
                {
                    Console.WriteLine($"ID: {customer.CustomerId}, Name: {customer.Name}, Email: {customer.Email}, Credit Card: {customer.CreditCardNumber}");
                }
                var stores = context.Stores.ToList();
                Console.WriteLine("Stores:");
                foreach (var store in stores)
                {
                    Console.WriteLine($"ID: {store.StoreId}, Name: {store.Name}");
                }
                var sales = context.Sales
                    .Include(s => s.Product)
                    .Include(s => s.Customer)
                    .Include(s => s.Store)
                    .ToList();
                Console.WriteLine("Sales:");
                foreach (var sale in sales)
                {
                    Console.WriteLine($"ID: {sale.SaleId}, Product: {sale.Product.Name}, Customer: {sale.Customer.Name}, Store: {sale.Store.Name}, Date: {sale.Date}");
                }
                Console.WriteLine(
                    "----------------------------------------");

            }
        }

        static void Main(string[] args)
        {
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
                            using (var context = new HospitalContext())
                            {
                                context.Database.Migrate();
                                Console.WriteLine("Database created");
                            }
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
                            using (var context = new HospitalContext())
                            {
                                context.Database.Migrate();
                                Console.WriteLine("Database created");
                            }
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
                            using (var context = new SalesContext())
                            {
                                context.Database.EnsureCreated();
                                Console.WriteLine("Sales Database created");
                            }
                            Console.WriteLine("Seeding Sales Database with 5 records...");
                            Seed(5);
                            Console.WriteLine("Seeding completed.");
                            PrintAllTables();
                            Console.ReadLine();
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