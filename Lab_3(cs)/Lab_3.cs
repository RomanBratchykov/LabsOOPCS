using Lab_3_cs_;
using System;
using System.Collections.Generic;

class Lab_3
{
    static Engine getEngine(string input, List<Engine> engines)
    {
        foreach (var engine in engines)
        {
            if (engine.Model == input)
            {
                return engine;
            }
        }
        return null;
    }
    static string getDepartment(List<Employee> employees)
    {
        Dictionary<string, List<Employee>> departments = new Dictionary<string, List<Employee>>();
        foreach (var employee in employees)
        {
            if (!departments.ContainsKey(employee.Department))
            {
                departments[employee.Department] = new List<Employee>();
            }
            departments[employee.Department].Add(employee);
        }
        string bestDepartment = "";
        decimal highestAverageSalary = 0;
        foreach (var department in departments)
        {
            decimal averageSalary = 0;
            foreach (var employee in department.Value)
            {
                averageSalary += employee.Salary;
            }
            averageSalary /= department.Value.Count;
            if (averageSalary > highestAverageSalary)
            {
                highestAverageSalary = averageSalary;
                bestDepartment = department.Key;
            }
        }
        return bestDepartment;
    }
    Person person1 = new Person("Pesho", 20);
    Person person2 = new Person("Gosho", 18);
    Person person3 = new Person("Stamat", 43);
    Person person4 = new Person();
    Person person5 = new Person()
    {
        Name = "Ivan",
        Age = 19
    };
    static void Main()
    {
        Console.WriteLine("Choose task 3-6");
        int task = int.Parse(Console.ReadLine());
        switch (task)
        {
            case 0:
                return;
            case 3:
                {
                    Family family = new Family();
                    Console.WriteLine("Enter number of members:");
                    int num = int.Parse(Console.ReadLine());
                    for (int i = 0; i < num; i++)
                    {
                        Console.WriteLine("Enter name and age:");
                        string[] input = Console.ReadLine().Split();
                        if (input is null || input.Length <= 0)
                        {
                            Console.WriteLine("Invalid input");
                            return;
                        }
                        string name = input[0];
                        int age = int.Parse(input[1]);
                        Person person = new Person(name, age);
                        family.AddMember(person);
                    }
                    family.PrintOldestMember();
                }
                break;
            case 4:
                {
                    List<Employee> employeesList = new List<Employee>();
                    Console.WriteLine("Enter number of employees:");
                    int n = int.Parse(Console.ReadLine());
                    for (int i = 0; i < n; i++)
                    {
                        string[] input = Console.ReadLine().Split();
                        if (input is null || input.Length < 4)
                        {
                            Console.WriteLine("Invalid input");
                            return;
                        }
                        string name = input[0];
                        decimal salary = decimal.Parse(input[1]);
                        string position = input[2];
                        string department = input[3];
                        if (input.Length == 4)
                        {
                            Employee employee = new Employee(name, salary, position, department);
                            employeesList.Add(employee);
                        }
                        else if (input.Length == 5)
                        {
                            if (int.TryParse(input[4], out int age))
                            {
                                Employee employee = new Employee(name, salary, position, department, age);
                                employeesList.Add(employee);
                            }
                            else
                            {
                                string email = input[4];
                                Employee employee = new Employee(name, salary, position, department, email);
                                employeesList.Add(employee);
                            }
                        }
                        else if (input.Length == 6)
                        {
                            string email = input[4];
                            int age = int.Parse(input[5]);
                            Employee employee = new Employee(name, salary, position, department,age, email);
                            employeesList.Add(employee);
                        }
                    }
                    string bestDepartment = getDepartment(employeesList);
                    Console.WriteLine($"Highest Average Salary: {bestDepartment}");
                    foreach (var employee in employeesList)
                    {
                        if (employee.Department == bestDepartment)
                        {
                            Console.WriteLine(employee.printEmployee());
                        }
                    }
                }
                break;
             case 5:
                {
                    Console.WriteLine("Enter number of cars:");
                    int num = int.Parse(Console.ReadLine());
                    List<Car> cars = new List<Car>();
                    for (int i = 0; i < num; i++)
                    {
                        Console.WriteLine("Enter car " + (i + 1) + " (example AudiA4(model) 23(fuelAmount) 0.3(usage of fuel per km) )" );
                        cars.Add(new Car());
                        string[] input = Console.ReadLine().Split();
                        if (input is null || input.Length <= 0)
                        {
                            Console.WriteLine("Invalid input");
                            return;
                        }
                        foreach (var car in cars)
                        {
                            if (car.Model == input[0])
                            {
                                Console.WriteLine("Car already exists");
                                i--;
                                continue;
                            }
                        }
                        cars[i].Model = input[0];
                        cars[i].FuelAmount = decimal.Parse(input[1]);
                        cars[i].FuelConsumptionPerKm = decimal.Parse(input[2]);
                    }
                    Console.WriteLine("Enter commands (Drive {carModel} {amountOfKm}) or End to stop:");
                    while (true)
                    {
                        string[] command = Console.ReadLine().Split();
                        if (command is null || command.Length <= 0)
                        {
                            Console.WriteLine("Invalid input");
                            return;
                        }
                        if (command[0] == "End")
                        {
                            foreach (var car in cars)
                            {
                                car.showCar();
                            }
                            break;
                        }
                        string model = command[1];
                        decimal distance = decimal.Parse(command[2]);
                        bool found = false;
                        foreach (var car in cars)
                        {
                            if (car.Model == model)
                            {
                                found = true;
                                if (!car.canDrive(distance))
                                {
                                    Console.WriteLine("Insufficient fuel for the drive");
                                }
                                break;
                            }
                        }
                        if (!found)
                            {
                                Console.WriteLine("Car not found");
                            }
                        }
                    }
                break;
              case 6:
                {
                    Console.WriteLine("Enter number of engines:");
                    int n = int.Parse(Console.ReadLine());
                    List<Engine> engines = new List<Engine>();
                    for (int i = 0; i < n; i++)
                    {
                        Console.WriteLine("Enter engine " + (i + 1) + " (example V8-101 220 )");
                        string[] input = Console.ReadLine().Split();
                        if (input is null || input.Length < 2 || input.Length > 4)
                        {
                            Console.WriteLine("Invalid input");
                            return;
                        }
                        string model = input[0];
                        int power = int.Parse(input[1]);
                        if (input.Length == 2)
                        {
                            Engine engine = new Engine(model, power);
                            engines.Add(engine);
                        }
                        else if (input.Length == 3)
                        {
                            if (int.TryParse(input[2], out int displacement))
                            {
                                Engine engine = new Engine(model, power, displacement);
                                engines.Add(engine);
                            }
                            else
                            {
                                string efficiency = input[2];
                                Engine engine = new Engine(model, power, efficiency);
                                engines.Add(engine);
                            }
                        }
                        else if (input.Length == 4)
                        {
                            int displacement = int.Parse(input[2]);
                            string efficiency = input[3];
                            Engine engine = new Engine(model, power, displacement, efficiency);
                            engines.Add(engine);
                        }
                    }
                    Console.WriteLine("Enter number of cars:");
                    n = int.Parse(Console.ReadLine());
                    List<Automobile> cars = new List<Automobile>();
                    for (int i = 0; i < n; i++)
                    {
                        Console.WriteLine("Enter car " + (i + 1) + " using engines from above (example FordFocus V4-33 1300 Silver )");
                        string[] input = Console.ReadLine().Split();
                        if (input is null || input.Length < 2 || input.Length > 4)
                        {
                            Console.WriteLine("Invalid input");
                            return;
                        }
                        string model = input[0];
                        foreach (var car in cars)
                        {
                            if (car.Model == model)
                            {
                                Console.WriteLine("Car already exists");
                                i--;
                                continue;
                            }
                        }
                        Engine engine = getEngine(input[1], engines);
                        if (input.Length == 2)
                        {
                            Automobile automobile = new Automobile(model, engine);
                            cars.Add(automobile);
                        }
                        else if (input.Length == 3)
                        {
                            if (int.TryParse(input[2], out int weight))
                            {
                                Automobile automobile = new Automobile(model, engine, weight, "n/a");
                                cars.Add(automobile);
                            }
                            else
                            {
                                string color = input[2];
                                Automobile automobile = new Automobile(model, engine, 0, color);
                                cars.Add(automobile);
                            }
                        }
                        else if (input.Length == 4)
                        {
                            int weight = int.Parse(input[2]);
                            string color = input[3];
                            Automobile automobile = new Automobile(model, engine, weight, color);
                            cars.Add(automobile);
                        }
                    }
                    foreach (var car in cars)
                    {
                        car.showAutomobile();
                    }
                }
                break;
            default:
                {
                    Console.WriteLine("Invalid task number");
                }
                break;
        }
    }
}
