
using Lab_7_cs_.Military;
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
            int inputTask = int.Parse(Console.ReadLine());
            if (inputTask == 0) break;
            switch (inputTask)
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
                                    Console.WriteLine("Enter number of people");
                                    int n = int.Parse(Console.ReadLine());
                                    Dictionary<string, IBuyer> people = new Dictionary<string, IBuyer>();
                                    Console.WriteLine("Enter citizen or rebel([name, age, id, birthdate] or [name, age group])");
                                    for (int i = 0; i < n; i++)
                                    {
                                        string[] parts = Console.ReadLine().Split(' ');

                                        if (parts.Length == 4) 
                                        {
                                            DateTime birthDate;
                                            if (DateTime.TryParse(parts[3], out birthDate))
                                            {
                                                DateTime birthdate;
                                                string name = parts[0];
                                                string age = parts[1];
                                                string id = parts[2];
                                                people[name] = new Citizen(name, age, id, birthDate);
                                            }
                                            else
                                            {
                                                Console.WriteLine("Invalid date format");
                                            }
                                        }
                                        else if (parts.Length == 3)
                                        {
                                            string name = parts[0];
                                            int age = int.Parse(parts[1]);
                                            string group = parts[2];
                                            people[name] = new Rebel(name, age, group);
                                        }
                                    }
                                    Console.WriteLine("Enter who is buying food");
                                    while (true)
                                    {
                                        string name = Console.ReadLine();
                                        if (name.ToLower() == "end") break;

                                        if (people.ContainsKey(name))
                                        {
                                            people[name].BuyFood();
                                        }
                                    }

                                    int totalFood = 0;
                                    foreach (var person in people.Values)
                                    {
                                        totalFood += person.Food;
                                    }

                                    Console.WriteLine(totalFood);
                                }
                                break;
                            default:
                                Console.WriteLine("Invalid input");
                                break;
                        }
                    }
                    break;
                case 3:
                    {
                        Console.WriteLine("Enter soldiers, help to get info, end to stop");
                        var soldiers = new Dictionary<int, ISoldier>();
                        string input;

                        while ((input = Console.ReadLine()) != "end")
                        {
                            var parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                            string type;
                            int id = 0;
                            string firstName = string.Empty;
                            string lastName = string.Empty;
                            if (parts.Length == 1)
                            {
                                type = parts[0];
                            }
                            else
                            {
                                type = parts[0];
                                id = int.Parse(parts[1]);
                                firstName = parts[2];
                                lastName = parts[3];

                            }
                                

                            try
                            {
                                switch (type)
                                {
                                    case "Private":
                                        {
                                            decimal salary = decimal.Parse(parts[4]);
                                            soldiers[id] = new Private(id, firstName, lastName, salary);
                                        }
                                        break;

                                    case "LeutenantGeneral":
                                        {
                                            decimal salary = decimal.Parse(parts[4]);
                                            var general = new LeutenantGeneral(id, firstName, lastName, salary);
                                            foreach (var pid in parts.Skip(5).Select(int.Parse))
                                                if (soldiers.ContainsKey(pid) && soldiers[pid] is IPrivate p)
                                                    general.AddPrivate(p);
                                            soldiers[id] = general;
                                        }
                                        break;

                                    case "Engineer":
                                        {
                                            decimal salary = decimal.Parse(parts[4]);
                                            string corps = parts[5];
                                            var engineer = new Engineer(id, firstName, lastName, salary, corps);

                                            for (int i = 6; i < parts.Length - 1; i += 2)
                                            {
                                                string part = parts[i];
                                                int hours = int.Parse(parts[i + 1]);
                                                engineer.AddRepair(new Repair(part, hours));
                                            }

                                            soldiers[id] = engineer;
                                        }
                                        break;

                                    case "Commando":
                                        {
                                            decimal salary = decimal.Parse(parts[4]);
                                            string corps = parts[5];
                                            var commando = new Commando(id, firstName, lastName, salary, corps);

                                            for (int i = 6; i < parts.Length - 1; i += 2)
                                            {
                                                string code = parts[i];
                                                string state = parts[i + 1];
                                                try { commando.AddMission(new Mission(code, state)); }
                                                catch { continue; }
                                            }

                                            soldiers[id] = commando;
                                        }
                                        break;

                                    case "Spy":
                                        {
                                            int codeNumber = int.Parse(parts[4]);
                                            soldiers[id] = new Spy(id, firstName, lastName, codeNumber);
                                        }
                                        break;
                                    case "help":
                                        {
                                            Console.WriteLine("Private: “Private <id> <firstName> <lastName> <salary>”\r\n• LeutenantGeneral: “LeutenantGeneral <id> <firstName> <lastName> <salary>\r\n<private1Id> <private2Id> … <privateNId>”\r\n• Engineer: “Engineer <id> <firstName> <lastName> <salary> <corps>\r\n<repair1Part> <repair1Hours> … <repairNPart> <repairNHours>”.\r\n• Commando: “Commando <id> <firstName> <lastName> <salary> <corps>\r\n<mission1CodeName> <mission1state> … <missionNCodeName> <missionNstate>”.\r\nSpy: “Spy <id> <firstName> <lastName> <codeNumber>”");
                                            Console.WriteLine("Enter soldiers, help to get info, end to stop");
                                        }
                                        break;
                                }
                            }
                            catch
                            {
                                continue;
                            }
                        }

                        foreach (var s in soldiers.Values)
                            Console.WriteLine(s.ToString());
                    }
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
        }
    }
}