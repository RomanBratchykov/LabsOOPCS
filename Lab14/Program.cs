using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Введіть номер завдання (1-12):");
        int taskNumber;
        if (int.TryParse(Console.ReadLine(), out taskNumber))
        {
            switch (taskNumber)
            {
                case 1:
                    {
                        string[] names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                        Action<string> printName = name => Console.WriteLine(name);
                        foreach (var name in names)
                        {
                            printName(name);
                        }
                    }
                    break;
                case 2:
                    {
                        string[] names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                        Action<string> printKnight = name => Console.WriteLine($"Sir {name}");
                        foreach (var name in names)
                        {
                            printKnight(name);
                        }
                    }
                    break;
                case 3:
                    {
                        int[] numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                        Func<int[], int> getMin = nums =>
                        {
                            int min = int.MaxValue;
                            foreach (var num in nums)
                            {
                                if (num < min) min = num;
                            }
                            return min;
                        };
                        Console.WriteLine(getMin(numbers));
                    }
                    break;
                case 4:
                    {
                        string[] bounds = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                        int start = int.Parse(bounds[0]);
                        int end = int.Parse(bounds[1]);
                        string type = Console.ReadLine().Trim();
                        Predicate<int> isOdd = num => num % 2 != 0;
                        Predicate<int> isEven = num => num % 2 == 0;
                        Predicate<int> filter = type == "odd" ? isOdd : isEven;
                        List<int> result = new List<int>();
                        for (int i = start; i <= end; i++)
                        {
                            if (filter(i)) result.Add(i);
                        }
                        Console.WriteLine(string.Join(" ", result));
                    }
                    break;
                case 5:
                    {

                        List<int> numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
                        Func<List<int>, List<int>> add = list => list.Select(x => x + 1).ToList();
                        Func<List<int>, List<int>> multiply = list => list.Select(x => x * 2).ToList();
                        Func<List<int>, List<int>> subtract = list => list.Select(x => x - 1).ToList();
                        Action<List<int>> print = list => Console.WriteLine(string.Join(" ", list));

                        string command;
                        while ((command = Console.ReadLine().Trim()) != "end")
                        {
                            switch (command)
                            {
                                case "add":
                                    numbers = add(numbers);
                                    break;
                                case "multiply":
                                    numbers = multiply(numbers);
                                    break;
                                case "subtract":
                                    numbers = subtract(numbers);
                                    break;
                                case "print":
                                    print(numbers);
                                    break;
                            }
                        }
                    }
                    break;
                case 6:
                    {
                        List<int> numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
                        int n = int.Parse(Console.ReadLine());
                        numbers.Reverse();
                        Predicate<int> divisibleByN = x => x % n == 0;
                        numbers.RemoveAll(divisibleByN);
                        Console.WriteLine(string.Join(" ", numbers));
                    }
                    break;
                case 7:
                    {
                        int n = int.Parse(Console.ReadLine());
                        string[] names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                        Predicate<string> lengthCheck = name => name.Length <= n;
                        foreach (var name in names)
                        {
                            if (lengthCheck(name)) Console.WriteLine(name);
                        }
                    }
                    break;
                case 8:
                    {
                        int[] numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                        Comparison<int> customComparator = (a, b) =>
                        {
                            if (a % 2 == 0 && b % 2 != 0) return -1; // a even, b odd -> a first
                            if (a % 2 != 0 && b % 2 == 0) return 1;  // a odd, b even -> b first
                            return a.CompareTo(b); // same parity, compare values
                        };
                        Array.Sort(numbers, customComparator);
                        Console.WriteLine(string.Join(" ", numbers));
                    }
                    break;
                case 9:
                    {
                        int n = int.Parse(Console.ReadLine());
                        int[] divisors = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).Distinct().ToArray();
                        List<Predicate<int>> predicates = new List<Predicate<int>>();
                        foreach (var div in divisors)
                        {
                            predicates.Add(num => num % div == 0);
                        }
                        List<int> result = new List<int>();
                        for (int i = 1; i <= n; i++)
                        {
                            bool divisibleByAll = true;
                            foreach (var pred in predicates)
                            {
                                if (!pred(i))
                                {
                                    divisibleByAll = false;
                                    break;
                                }
                            }
                            if (divisibleByAll) result.Add(i);
                        }
                        Console.WriteLine(string.Join(" ", result));
                    }
                    break;
                case 10:
                    {
                        List<string> people = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
                        string command;
                        while ((command = Console.ReadLine().Trim()) != "Party!")
                        {
                            string[] parts = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                            string action = parts[0];
                            string criteria = parts[1];
                            string param = parts[2];
                            Predicate<string> predicate = null;
                            switch (criteria)
                            {
                                case "StartsWith":
                                    predicate = name => name.StartsWith(param);
                                    break;
                                case "EndsWith":
                                    predicate = name => name.EndsWith(param);
                                    break;
                                case "Length":
                                    int len = int.Parse(param);
                                    predicate = name => name.Length == len;
                                    break;
                            }
                            if (predicate != null)
                            {
                                for (int i = people.Count - 1; i >= 0; i--)
                                {
                                    if (predicate(people[i]))
                                    {
                                        if (action == "Remove")
                                        {
                                            people.RemoveAt(i);
                                        }
                                        else if (action == "Double")
                                        {
                                            people.Insert(i, people[i]);
                                            i--; // skip the newly inserted to avoid infinite loop
                                        }
                                    }
                                }
                            }
                        }
                        if (people.Count > 0)
                        {
                            Console.WriteLine($"{string.Join(", ", people)} are going to the party!");
                        }
                        else
                        {
                            Console.WriteLine("Nobody is going to the party!");
                        }
                    }
                    break;
                case 11:
                    {
                        List<string> invitations = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
                        List<Predicate<string>> filters = new List<Predicate<string>>();
                        string command;
                        while ((command = Console.ReadLine().Trim()) != "Print")
                        {
                            string[] parts = command.Split(';', StringSplitOptions.RemoveEmptyEntries);
                            string action = parts[0].Trim();
                            string filterType = parts[1].Trim();
                            string param = parts[2].Trim();
                            Predicate<string> predicate = null;
                            switch (filterType)
                            {
                                case "Starts with":
                                    predicate = name => name.StartsWith(param);
                                    break;
                                case "Ends with":
                                    predicate = name => name.EndsWith(param);
                                    break;
                                case "Length":
                                    int len = int.Parse(param);
                                    predicate = name => name.Length == len;
                                    break;
                                case "Contains":
                                    predicate = name => name.Contains(param);
                                    break;
                            }
                            if (predicate != null)
                            {
                                if (action == "Add filter")
                                {
                                    filters.Add(predicate);
                                }
                                else if (action == "Remove filter")
                                {
                                    filters.RemoveAll(p => p.Method == predicate.Method); // Remove matching predicate
                                }
                            }
                        }
                        List<string> remaining = invitations.Where(name => !filters.Any(filter => filter(name))).ToList();
                        Console.WriteLine(string.Join(" ", remaining));
                    }
                    break;
                case 12:
                    {
                        int[] gems = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                        List<(string Type, int Param)> activeExcludes = new List<(string, int)>();
                        string command;
                        while ((command = Console.ReadLine().Trim()) != "Forge")
                        {
                            string[] parts = command.Split(';', StringSplitOptions.RemoveEmptyEntries);
                            string action = parts[0].Trim();
                            string filterType = parts[1].Trim();
                            int param = int.Parse(parts[2].Trim());
                            var key = (filterType, param);
                            if (action == "Exclude")
                            {
                                activeExcludes.Add(key);
                            }
                            else if (action == "Reverse")
                            {
                                activeExcludes.Remove(key);
                            }
                        }
                        List<int> remaining = new List<int>();
                        for (int i = 0; i < gems.Length; i++)
                        {
                            bool exclude = false;
                            foreach (var (type, param) in activeExcludes)
                            {
                                int left = i > 0 ? gems[i - 1] : 0;
                                int right = i < gems.Length - 1 ? gems[i + 1] : 0;
                                int self = gems[i];
                                bool match = false;
                                switch (type)
                                {
                                    case "Sum Left":
                                        match = left + self == param;
                                        break;
                                    case "Sum Right":
                                        match = self + right == param;
                                        break;
                                    case "Sum Left Right":
                                        match = left + self + right == param;
                                        break;
                                }
                                if (match)
                                {
                                    exclude = true;
                                    break;
                                }
                            }
                            if (!exclude) remaining.Add(gems[i]);
                        }
                        Console.WriteLine(string.Join(" ", remaining));
                    }
                    break;
                default:
                    Console.WriteLine("Невірний номер завдання.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Невірне введення номера завдання.");
        }
    }
}