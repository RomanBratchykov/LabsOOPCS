using System;

namespace Lab_12_cs_
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number of task 1-4, 0 for exit");
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
                        King king = new King(kingName);
                        Console.WriteLine("Enter royal guards names with space separator");
                        string[] royalGuardsNames = Console.ReadLine().Split(' ');
                        List<Unit> units = new List<Unit>();
                        foreach (var rgName in royalGuardsNames)
                        {
                            RoyalGuard rg = new RoyalGuard(rgName);
                            units.Add(rg);
                            king.KingAttacked += rg.RespondToAttack;
                        }
                        Console.WriteLine("Enter footman names with space separator");
                        string[] footmanNames = Console.ReadLine().Split(' ');
                        foreach (var fmName in footmanNames)
                        {
                            Footman fm = new Footman(fmName);
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
                    // Task3(); // Implement Task3 if needed
                    break;
                case 4:
                    // Task4(); // Implement Task4 if needed
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