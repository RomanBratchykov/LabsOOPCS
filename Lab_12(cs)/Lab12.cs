using System;
using System.Xml.Linq;
using King2;
namespace Lab_12_cs_
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number of task 1-3, 0 for exit");
            int input = int.Parse(Console.ReadLine());
            switch (input)
            {
                case 1:
                    {
                        Dispatcher dispatcher = new Dispatcher();
                        Handler handler = new Handler();
                        dispatcher.NameChange += handler.OnNameChange;
                        while (true)
                        {
                            Console.Write("Enter a new name (or 'end' to quit): ");
                            string name = Console.ReadLine();
                            if (name.ToLower() == "end")
                                break;
                            dispatcher.Name = name;
                        }

                    }
                    break;
                case 2:
                    {
                        Console.WriteLine("Enter king name");
                        string kingName = Console.ReadLine();
                        List<Unit> units = new List<Unit>();
                        if (kingName is null)
                        {
                            Console.WriteLine("King name cannot be null!");
                            return;
                        }
                        King king = new King(kingName);
                        units.Add(king);
                        Console.WriteLine("Enter royal guards names with space separator");
                        string[] royalGuardsNames = Console.ReadLine().Split(' ');
                        foreach (var name in royalGuardsNames)
                        {

                        }
                        foreach (var rgName in royalGuardsNames)
                        {
                            RoyalGuard rg = new RoyalGuard(rgName);
                            if (units.Contains(rg))
                            {
                                Console.WriteLine($"Duplicate royal guard name: {rgName}. Each royal guard must have a unique name.");
                                return;
                            }
                            units.Add(rg);
                            king.KingAttacked += rg.RespondToAttack;
                        }
                        if (units.Count == 0)
                        {
                            Console.WriteLine("There should be at least one royal guard!");
                            return;
                        }
                        Console.WriteLine("Enter footman names with space separator");
                        string[] footmanNames = Console.ReadLine().Split(' ');
                        if (footmanNames.Length == 0)
                        {
                            Console.WriteLine("There should be at least one footman!");
                            return;
                        }
                        foreach (var fmName in footmanNames)
                        {
                            Footman fm = new Footman(fmName);
                            if (units.Contains(fm))
                            {
                                Console.WriteLine($"Duplicate royal guard name: {fmName}. Each royal guard must have a unique name.");
                                return;
                            }
                            units.Add(fm);
                            king.KingAttacked += fm.RespondToAttack;
                        }
                        Console.WriteLine("Enter commands: attack king/ kill [name of unit]/end");
                        while (true)
                        {
                            string command = Console.ReadLine();
                            if (command.ToLower() == "end")
                                break;
                            else if (command.ToLower() == "attack king")
                            {
                                king.BeAttacked();
                            }
                            else if (command.ToLower().StartsWith("kill "))
                            {
                                string unitNameToKill = command.Substring(5);
                                Unit unitToKill = units.FirstOrDefault(u => u.Name == unitNameToKill && u.IsAlive);
                                if (unitToKill != null)
                                {
                                    unitToKill.Die();
                                    king.KingAttacked -= unitToKill.RespondToAttack;
                                    units.Remove(unitToKill);
                                }
                                else
                                {
                                    Console.WriteLine($"No alive unit found with the name {unitNameToKill}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid command");
                            }
                        }
                    }
                    break;
                case 3:
                    Console.WriteLine("Enter commands: (Job [jobName] [WorkHours] [Employee name]/StandardEmployee [name]/PTEmployee [name]/ PassWeek/Status), end to stop");
                    List<Job> jobs = new List<Job>();
                    List<Employee> employees = new List<Employee>();
                    while (true)
                    {
                        string command = Console.ReadLine();
                        if (command.ToLower() == "end")
                            break;
                        string[] parts = command.Split(' ');
                        if (parts[0].ToLower() == "job" && parts.Length == 4)
                        {
                            string jobName = parts[1];
                            int hoursRequired = int.Parse(parts[2]);
                            string employeeName = parts[3];
                            Employee employee = employees.FirstOrDefault(e => e.Name == employeeName);
                            if (employee == null)
                            {
                                Console.WriteLine($"No employee found with the name {employeeName}");
                                continue;
                            }
                            Job job = new Job(jobName, hoursRequired, employee);
                            job.WorkDone += (j) => jobs.Remove(j);
                            jobs.Add(job);
                        }
                        else if (parts[0].ToLower() == "standardemployee" && parts.Length == 2)
                        {
                            string name = parts[1];
                            Employee employee = new StandardEmployee(name);
                            employees.Add(employee);
                            Console.WriteLine($"Added standard employee {name}");
                        }
                        else if (parts[0].ToLower() == "ptemployee" && parts.Length == 2)
                        {
                            string name = parts[1];
                            Employee employee = new PTEmployee(name);
                            employees.Add(employee);
                            Console.WriteLine($"Added part time employee {name}");
                        }
                        else if (parts[0].ToLower() == "passweek")
                        {
                            foreach (var job in jobs.ToList())
                            {
                                job.UpdateHours();
                            }
                        }
                        else if (parts[0].ToLower() == "status")
                        {
                            foreach (var job in jobs)
                            {
                                job.PrintStatus();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid command");
                        }
                    }
                        break;
                case 4:
                    {
                        Console.WriteLine("Enter king name");
                        string kingName = Console.ReadLine();
                        List<King4.Unit> units = new List<King4.Unit>();
                        if (kingName is null)
                        {
                            Console.WriteLine("King name cannot be null!");
                            return;
                        }
                        King4.King king = new King4.King(kingName);
                        units.Add(king);
                        Console.WriteLine("Enter royal guards names with space separator");
                        string[] royalGuardsNames = Console.ReadLine().Split(' ');
                        foreach (var name in royalGuardsNames)
                        {

                        }
                        foreach (var rgName in royalGuardsNames)
                        {
                            King4.RoyalGuard rg = new King4.RoyalGuard(rgName);
                            if (units.Contains(rg))
                            {
                                Console.WriteLine($"Duplicate royal guard name: {rgName}. Each royal guard must have a unique name.");
                                return;
                            }
                            units.Add(rg);
                            king.KingAttacked += rg.RespondToAttack;
                        }
                        if (units.Count == 0)
                        {
                            Console.WriteLine("There should be at least one royal guard!");
                            return;
                        }
                        Console.WriteLine("Enter footman names with space separator");
                        string[] footmanNames = Console.ReadLine().Split(' ');
                        if (footmanNames.Length == 0)
                        {
                            Console.WriteLine("There should be at least one footman!");
                            return;
                        }
                        foreach (var fmName in footmanNames)
                        {
                            King4.Footman fm = new King4.Footman(fmName);
                            if (units.Contains(fm))
                            {
                                Console.WriteLine($"Duplicate royal guard name: {fmName}. Each royal guard must have a unique name.");
                                return;
                            }
                            units.Add(fm);
                            king.KingAttacked += fm.RespondToAttack;
                        }
                        Console.WriteLine("Enter commands: attack king/ kill [name of unit]/end");
                        while (true)
                        {
                            string command = Console.ReadLine();
                            if (command.ToLower() == "end")
                                break;
                            else if (command.ToLower() == "attack king")
                            {
                                king.BeAttacked();
                            }
                            else if (command.ToLower().StartsWith("kill "))
                            {
                                string unitNameToKill = command.Substring(5);
                                var unitToKill = units.FirstOrDefault(u => u.Name == unitNameToKill && u.IsAlive);
                                if (unitToKill != null && unitToKill != king)
                                {
                                    unitToKill.Die();
                                    if (!unitToKill.IsAlive)
                                    {
                                        king.KingAttacked -= unitToKill.RespondToAttack;
                                        units.Remove(unitToKill);
                                    }
                                        
                                }
                                else
                                {
                                    Console.WriteLine($"No alive unit found with the name {unitNameToKill}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid command");
                            }
                        }

                    }
                    break;
                case 0:
                    return;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
        }
    }
}