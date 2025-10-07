using Lab_7.Utopia;
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
                                    Console.WriteLine("Enter citizens and robots, end to stop");
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
                                    Console.WriteLine("Enter last digits to check");
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