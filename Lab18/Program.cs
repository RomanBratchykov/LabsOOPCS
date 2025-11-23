using System;
using Microsoft.EntityFrameworkCore;

namespace Program
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Select task 1-2, 0 for exit");
                var task = Console.ReadLine();
                if (task == "0")
                {
                    return;
                }
                switch (task)
                {
                    case "1":
                        {

                        }
                        break;
                    case "2":
                        {

                        }
                        break;
                    default:
                        Console.WriteLine("Wrong choice");
                        break;
                }
            }
            

        }
    }
}