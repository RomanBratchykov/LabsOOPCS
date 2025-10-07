
using System;
using System.Transactions;

namespace Lab_7;
internal class Lab_7
{
    private static void Main(string[] args)
    {
        
        while (true)
        {
            Console.WriteLine("Enter number of task 1-3, 0 for exit");
            int input = int.Parse(Console.ReadLine());
            if (input == 0) break;
            switch (input)
            {
                case 0:
                    return;
                case 1:
                    {
                        Console.WriteLine("Enter model of mobile phone");
                        string model = Console.ReadLine();
                        MobileProduction mobile = new MobileProduction(model);
                        Console.WriteLine("Enter phone numbers to call");
                        List<ICallable> callables = new List<ICallable>();
                        string inputNum = Console.ReadLine();
                        string[] phoneNumbers = inputNum.Split(' ');
                        foreach (var number in phoneNumbers)
                        {
                            try
                            {
                                mobile.Call(number);
                            }
                            catch (ArgumentException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        Console.WriteLine("Enter URLs to watch");
                        List<IWatchable> watchables = new List<IWatchable>();
                        string inputUrl = Console.ReadLine();
                        string[] urls = inputUrl.Split(' ');
                        foreach (var url in urls)
                        {
                            try
                            {
                                mobile.Watch(url);
                            }
                            catch (ArgumentException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                    }
                    break;
                case 2:
                    
                    {
                        Console.WriteLine("Enter number of subtask 1-3, 0 for exit");
                        int subtask = int.Parse(Console.ReadLine());
                        if (subtask == 0) break;
                        switch (subtask)
                        {
                            case 1:
                                {
                                    Console.WriteLine("Enter citizens and robots([name, age, id] or [model, id]), end to stop");
                                    List<IEnterable> enterables = new List<IEnterable>();
                                    while (true)
                                    {
                                        string inputStr = Console.ReadLine();
                                        if (inputStr.ToLower() == "end") break;
                                        string[] parts = inputStr.Split(' ');
                                        if (parts.Length == 3)
                                        {
                                            Citizen citizen = new Citizen(parts[0], parts[1], parts[2]);
                                            enterables.Add(citizen);
                                        }
                                        else if (parts.Length == 2)
                                        {
                                            Robot robot = new Robot(parts[0], parts[1]);
                                            enterables.Add(robot);
                                        }
                                    }
                                    foreach (var enterable in enterables)
                                    {
                                        if (enterable is Citizen citizen)
                                        {
                                            citizen.Show();
                                        }
                                        else if (enterable is Robot robot)
                                        {
                                            robot.Show();
                                        }
                                    }
                                    Console.WriteLine("Enter last digits to check");
                                    string lastDigits = Console.ReadLine();
                                    Console.WriteLine("Result:");
                                    foreach (var enterable in enterables)
                                    {
                                        if (enterable.Id.EndsWith(lastDigits))
                                        {
                                            Console.WriteLine(enterable.Id);
                                        }
                                    }
                                }
                                break;
                            case 2:
                                {
                                    Console.WriteLine("Enter citizens, robots or pets([citizen name, age, id, birth date],[robot model, id], [pet name, birthdate]), end to stop(birthdate format 12/12/1990)");
                                    List<IShowable> entities = new List<IShowable>();
                                    while (true)
                                    {
                                        string inputStr = Console.ReadLine();
                                        if (inputStr.ToLower() == "end") break;
                                        string[] parts = inputStr.Split(' ');
                                        if (parts[0].ToLower() == "citizen")
                                        {
                                            DateTime birthDate;
                                            if (DateTime.TryParse(parts[4], out birthDate))
                                            {
                                                Citizen citizen = new Citizen(parts[1], parts[2], parts[3], birthDate);
                                                entities.Add(citizen);
                                            }
                                            else
                                            {
                                                Console.WriteLine("Invalid date format");
                                            }
                                        }
                                        else if (parts[0].ToLower() == "robot")
                                        {
                                            Robot robot = new Robot(parts[1], parts[2]);
                                            entities.Add(robot);
                                        }
                                        else if (parts[0].ToLower() == "pet")
                                        {
                                            DateTime birthDate;
                                            if (DateTime.TryParse(parts[2], out birthDate))
                                            {
                                                Pet pet = new Pet(parts[1], birthDate);
                                                entities.Add(pet);
                                            }
                                            else
                                            {
                                                Console.WriteLine("Invalid date format");
                                            }
                                        }

                                    }
                                    Console.WriteLine("Enter year to check");
                                    int year = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Result:");
                                    foreach (var entity in entities)
                                    {
                                        if (entity is IBirthable birthable)
                                        {
                                            if (birthable.BirthDate.Year == year)
                                            {
                                                Console.WriteLine(birthable.BirthDate.ToShortDateString());
                                            }
                                        }
                                    }
                                }
                                break;
                            case 3:
                                {
                                }
                                break;
                            default:
                                Console.WriteLine("Invalid input");
                                break;
                        }
                    }
                    break;
                case 3:
                    throw new NotImplementedException();
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
        }
    }
}