using System;
using System.Transactions;
using System.Windows.Markup;
using System.Collections.Generic;
namespace Lab_9_cs_;
internal class Lab9
{
    public static int CountGreaterThan<T>(List<Box<T>> list, Box<T> element)
       where T : IComparable<T>
    {
        int count = 0;
        foreach (var item in list)
        {
            if (item.CompareTo(element) > 0)
                count++;
        }
        return count;
    }
    internal static void Main()
    {
        Console.WriteLine("Enter number of task 1-10, 0 for exit");
        int task = int.Parse(Console.ReadLine());
        switch (task)
        {
            case 0:
                return;
            case 1: 
                {
                    Console.WriteLine("Enter 3 numbers");
                    Box<int> element1 = new Box<int>(int.Parse(Console.ReadLine()));
                    Box<double> element2 = new Box<double>(double.Parse(Console.ReadLine()));
                    Box<string> element3 = new Box<string>(Console.ReadLine());
                    Console.WriteLine($"{element1.ToString()}\n{element2.ToString()}\n{element3.ToString()}");
                }
                break;
            case 2:
                {
                    Console.WriteLine("Enter amount");
                    int n = int.Parse(Console.ReadLine());

                    for (int i = 0; i < n; i++)
                    {
                        string input = Console.ReadLine();

                        Box<string> box = new Box<string>(input);

                        Console.WriteLine(box.ToString());
                    }
                }
                break;
            case 3: 
                {
                    Console.WriteLine("Enter amount");
                    int n = int.Parse(Console.ReadLine());


                    for (int i = 0; i < n; i++)
                    {

                        int input;
                        if(int.TryParse(Console.ReadLine(), out input))
                        {
                             Box<int> box = new Box<int>(input);

                        Console.WriteLine(box.ToString());
                        }
                        else
                        {
                            Console.WriteLine("Not number");
                        }

                       
                    }
                }
                break;
            case 4:
                {
                    Console.WriteLine("Enter amount");
                    int n = int.Parse(Console.ReadLine());

                    List<Box<string>> listStr = new List<Box<string>>();
                    for (int i = 0; i < n; i++)
                    {
                        string input = Console.ReadLine();
                        listStr.Add(new Box<string>(input));
                    }
                    Console.WriteLine("your list:");
                    foreach (Box<string> box in listStr) { Console.WriteLine(box.ToString()); }
                    Console.WriteLine("Enter positions to swap");
                    int position1 = int.Parse(Console.ReadLine());
                    int position2 = int.Parse(Console.ReadLine());
                    listStr.Exchange(position1, position2);
                    Console.WriteLine("your swapped list:");
                    foreach (Box<string> box in listStr) { Console.WriteLine(box.ToString()); }
                }
                break;
            case 5:
                {
                    Console.WriteLine("Enter amount");
                    int n = int.Parse(Console.ReadLine());

                    List<Box<int>> listStr = new List<Box<int>>();
                    for (int i = 0; i < n; i++)
                    {
                        int input = int.Parse(Console.ReadLine());
                        listStr.Add(new Box<int>(input));
                    }
                    Console.WriteLine("your list:");
                    foreach (Box<int> box in listStr) { Console.WriteLine(box.ToString()); }
                    Console.WriteLine("Enter positions to swap");
                    int position1 = int.Parse(Console.ReadLine());
                    int position2 = int.Parse(Console.ReadLine());
                    listStr.Exchange(position1, position2);
                    Console.WriteLine("your swapped list:");
                    foreach (Box<int> box in listStr) { Console.WriteLine(box.ToString()); }
                }
                break;
            case 6:
                {
                    Console.WriteLine("Enter amount");
                    int n = int.Parse(Console.ReadLine());

                    List<Box<string>> listStr = new List<Box<string>>();
                    for (int i = 0; i < n; i++)
                    {
                        string input = Console.ReadLine();
                        listStr.Add(new Box<string>(input));
                    }
                    Console.WriteLine("Enter element to compare");
                    Box<string> box = new Box<string>(Console.ReadLine());
                    int count = CountGreaterThan(listStr, box);
                    Console.WriteLine(count);
                }
                break;
            case 7:
                {
                    Console.WriteLine("Enter amount");
                    int n = int.Parse(Console.ReadLine());

                    List<Box<double>> listStr = new List<Box<double>>();
                    for (double i = 0; i < n; i++)
                    {
                        double input = double.Parse(Console.ReadLine());
                        listStr.Add(new Box<double>(input));
                    }
                    Console.WriteLine("Enter element to compare");
                    Box<double> box = new Box<double>(double.Parse(Console.ReadLine()));
                    int count = CountGreaterThan(listStr, box);
                    Console.WriteLine(count);
                }
                break;
            case 8:
                { 
                    CustomList<string> list = new CustomList<string>();
                    Console.WriteLine("Write commands, help to get info, end to stop");
                    while (true)
                    {
                        
                        string command = Console.ReadLine();
                        if (command == "end") break;
                        else if (command == "help")
                        {
                            Console.WriteLine("Available commands:\nAdd <element>\nRemove <index>\nContains <element>\nSwap <index1> <index2>\nGreater <element>\nMax\nMin\nPrint");
                            continue;
                        }
                        string[] parts = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                        parts[0] = parts[0].ToLower();
                        switch (parts[0])
                        {
                            case "add":
                                list.Add(parts[1]);
                                break;
                            case "remove":
                                try
                                {
                                    string removed = list.Remove(int.Parse(parts[1]));
                                    Console.WriteLine($"Removed: {removed}");
                                }
                                catch (ArgumentOutOfRangeException e)
                                {
                                    Console.WriteLine(e.Message);
                                }
                                break;
                            case "contains":
                                Console.WriteLine(list.Contains(parts[1]));
                                break;
                            case "swap":
                                try
                                {
                                    list.Swap(int.Parse(parts[1]), int.Parse(parts[2]));
                                }
                                catch (ArgumentOutOfRangeException e)
                                {
                                    Console.WriteLine(e.Message);
                                }
                                break;
                            case "greater":
                                Console.WriteLine(list.CountGreaterThan(parts[1]));
                                break;
                            case "max":
                                try
                                {
                                    Console.WriteLine(list.Max());
                                }
                                catch (InvalidOperationException e)
                                {
                                    Console.WriteLine(e.Message);
                                }
                                break;
                            case "min":
                                try
                                {
                                    Console.WriteLine(list.Min());
                                }
                                catch (InvalidOperationException e)
                                {
                                    Console.WriteLine(e.Message);
                                }
                                break;
                            case "print":
                                list.Print();
                                break;
                            default:
                                Console.WriteLine("Unknown command");
                                break;
                        }
                    }
                }
                break;
            case 9:
                {
                    CustomList<string> list = new CustomList<string>();
                    Console.WriteLine("Write commands, help to get info, end to stop");
                    while (true)
                    {

                        string command = Console.ReadLine();
                        if (command == "end") break;
                        else if (command == "help")
                        {
                            Console.WriteLine("Available commands:\nAdd <element>\nRemove <index>\nContains <element>\nSwap <index1> <index2>\nGreater <element>\nMax\nMin\nPrint\nSort");
                            continue;
                        }
                        string[] parts = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                        parts[0] = parts[0].ToLower();
                        switch (parts[0])
                        {
                            case "add":
                                list.Add(parts[1]);
                                break;
                            case "remove":
                                try
                                {
                                    string removed = list.Remove(int.Parse(parts[1]));
                                    Console.WriteLine($"Removed: {removed}");
                                }
                                catch (ArgumentOutOfRangeException e)
                                {
                                    Console.WriteLine(e.Message);
                                }
                                break;
                            case "contains":
                                Console.WriteLine(list.Contains(parts[1]));
                                break;
                            case "swap":
                                try
                                {
                                    list.Swap(int.Parse(parts[1]), int.Parse(parts[2]));
                                }
                                catch (ArgumentOutOfRangeException e)
                                {
                                    Console.WriteLine(e.Message);
                                }
                                break;
                            case "greater":
                                Console.WriteLine(list.CountGreaterThan(parts[1]));
                                break;
                            case "max":
                                try
                                {
                                    Console.WriteLine(list.Max());
                                }
                                catch (InvalidOperationException e)
                                {
                                    Console.WriteLine(e.Message);
                                }
                                break;
                            case "min":
                                try
                                {
                                    Console.WriteLine(list.Min());
                                }
                                catch (InvalidOperationException e)
                                {
                                    Console.WriteLine(e.Message);
                                }
                                break;
                            case "print":
                                list.Print();
                                break;
                            case "sort":
                                {
                                    try
                                    {
                                        Sorter.Sort(list);
                                    }
                                    catch (InvalidOperationException e)
                                    {
                                        Console.WriteLine(e.Message);
                                    }
                                }
                                break;
                            default:
                                Console.WriteLine("Unknown command");
                                break;
                        }
                    }
                }
                break;
                break;
                {
                    Console.WriteLine("Wrong number of task");
                }
                break;
        }
    }
}

internal static class ListExtensions
{
    public static void Exchange<T>(this List<T> list, int index1, int index2)
    {
        if (list == null) throw new ArgumentNullException(nameof(list));
        if (index1 < 0 || index1 >= list.Count) throw new ArgumentOutOfRangeException(nameof(index1));
        if (index2 < 0 || index2 >= list.Count) throw new ArgumentOutOfRangeException(nameof(index2));
        if (index1 == index2) return;

        T temp = list[index1];
        list[index1] = list[index2];
        list[index2] = temp;
    }
}