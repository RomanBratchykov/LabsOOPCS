using System;
using System.Transactions;
using System.Windows.Markup;
using System.Collections.Generic;
namespace Lab_9_cs_;
internal class Lab9
{
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
                    Console.WriteLine($"{element1.ToString()}\n {element2.ToString()}\n{element3.ToString()}");
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
                { }
                break;
            case 7:
                { }
                break;
            case 8:
                { }
                break;
            case 9:
                { }
                break;
            case 10:
                { }
                break;
            default:
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