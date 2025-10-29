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
                    // Task2(); // Implement Task2 if needed
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