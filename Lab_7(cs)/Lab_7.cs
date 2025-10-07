using System;

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
                    throw new NotImplementedException();
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