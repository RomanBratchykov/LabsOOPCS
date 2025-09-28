using System;

namespace Lab_5;

public class Lab_5
{
    public static void Main(string[] args)
    {
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Choose task 2-3, 0 for exit");
        int task = int.Parse(Console.ReadLine());
        switch (task)
        {
            case 2:
                {

                }
                break;
            case 3:
                { 
                }
                break;
            case 0:
                break;
            default:
                Console.WriteLine("Wrong task number");
                break;
        }

    }
}