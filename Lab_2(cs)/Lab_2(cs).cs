using System;
using System.Collections.Generic;
using System.Diagnostics;

class Lab_2
{
    public static Dictionary<char, int> alphabet = new Dictionary<char, int>();
    public static void fillDict(ref Dictionary<char, int> dict)
    {
        int x = 0;
        for (char c = 'a'; c <= 'z'; c++)
        {
            dict[c] = x++;
        }
    }
    public static void rotateArray(ref List<int> list)
    {
        int lastElement = list[list.Count - 1];
        list.RemoveAt(list.Count - 1);
        list.Insert(0, lastElement);
        Console.WriteLine("Rotated array: ");
        foreach (int el in list)
        {
            Console.Write(el + " ");
        }
        Console.WriteLine();
    }
    public static List<int> sumOfArrays(List<List<int>> listOfLists)
    {
        List<int> result = new List<int>();
        int lenght = listOfLists[0].Count;
        for (int i = 0; i < lenght; i++)
        {
            int sum = 0;
            foreach (List<int> list in listOfLists)
            {
                sum += list[i];
            }
            result.Add(sum);
        }
        return result;
    }
    public static void fillArrayRand(ref List<int> list)
    {
        Random rand = new Random();
        for (int i = 0; i < list.Count; i++)
        {
            list[i] = rand.Next(0, 10);
        }
    }
    public static bool isPrime(int num)
    {
        if (num <= 1) return false;
        for (int i = 2; i <= Math.Sqrt(num); i++)
        {
            if (num % i == 0) return false;
        }
        return true;
    }
    static int CompareLex(List<char> a, List<char> b)
    {
        int minLength = Math.Min(a.Count, b.Count);

        for (int i = 0; i < minLength; i++)
        {
            if (a[i] != b[i])
            {
                return a[i] - b[i]; // < 0 → a < b, > 0 → a > b
            }
        }

        // Якщо всі символи однакові → дивимось на довжину
        return a.Count - b.Count;
    }
    
    public static void Main()
    {
        Console.WriteLine("Lab 2. Enter number of task 1 - 10, 0 to exit");
        int task = int.Parse(Console.ReadLine());
        if (task == 0) return;
        switch (task)
        {
            case 1:
                {
                    Console.WriteLine("First task\nEnter the first array of strings (space-separated):");
                    List<string> firstArray = new List<string>();
                    string sentence1 = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(sentence1))
                    {
                        Console.WriteLine("Error: Input cannot be empty.");
                        return;
                    }
                    firstArray.AddRange(sentence1.Split(' ', StringSplitOptions.RemoveEmptyEntries));
                    Console.WriteLine("Enter the second array of strings (space-separated):");
                    List<string> secondArray = new List<string>();
                    string sentence2 = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(sentence2))
                    {
                        Console.WriteLine("Error: Input cannot be empty.");
                        return;
                    }
                    secondArray.AddRange(sentence2.Split(' ', StringSplitOptions.RemoveEmptyEntries));
                    List<string> resultArray = new List<string>();
                    bool isFirstLonger = firstArray.Count > secondArray.Count;
                    int shortest = !isFirstLonger ? firstArray.Count : secondArray.Count;
                    if (shortest <= 1)
                    {
                        Console.WriteLine("Error: Arrays must have at least 2 elements.");
                        return;
                    }
                    Console.WriteLine("Your arrays: ");
                    foreach (string element in firstArray)
                    {
                        Console.Write(element + " ");
                    }
                    Console.WriteLine();
                    foreach (string element in secondArray)
                    {
                        Console.Write(element + " ");
                    }
                    Console.WriteLine();
                    int numberOfElementsRight = 0;
                    int numberOfElementsLeft = 0;
                    for (int i = 0; i < shortest; i++)
                    {
                        if (firstArray[i] != secondArray[i])
                        {
                            break;
                        }
                        else
                        {
                            numberOfElementsLeft++;
                        }
                    }
                    int flen = firstArray.Count - 1;
                    int slen = secondArray.Count - 1;
                    for (int i = 0; i < shortest; i++)
                    {
                        if (firstArray[flen--] != secondArray[slen--])
                        {
                            break;
                        }
                        else
                        {
                            numberOfElementsRight++;
                        }
                    }
                    if (numberOfElementsLeft == 0 && numberOfElementsRight == 0)
                    {
                        Console.WriteLine("There are no same words from both ends");
                    }
                    else if (numberOfElementsLeft == numberOfElementsRight && numberOfElementsRight == shortest)
                    {
                        Console.WriteLine("Arrays all the same");
                    }
                    else if (numberOfElementsLeft > numberOfElementsRight)
                    {
                        Console.WriteLine("The most same words are on left: " + numberOfElementsLeft + "\n");
                        for (int i = 0; i < numberOfElementsLeft; i++)
                        {
                            resultArray.Add(firstArray[i]);
                            Console.Write(resultArray[i] + " ");
                        }
                    }
                    else
                    {
                        Console.WriteLine("The most same words are on right: " + numberOfElementsRight + "\n");
                        for (int i = shortest - numberOfElementsRight; i < shortest; i++)
                        {
                            resultArray.Add(firstArray[i]);
                            Console.Write(resultArray[i - (shortest - numberOfElementsRight)] + " ");
                        }
                    }
                }
            break;
            case 2:
                {
                    Console.WriteLine("Enter length of array");
                    int n = int.Parse(Console.ReadLine());
                    if (n <= 0)
                    {
                        Console.WriteLine("Error: Length must be a positive integer.");
                        return;
                    }
                    List<int> array = new List<int>();
                    Console.WriteLine("Enter array elements:");
                    for (int i = 0; i < n; i++)
                    {
                        array.Add(int.Parse(Console.ReadLine()));
                    }
                    Console.WriteLine("Your array: ");
                    foreach(int el in array)
                    {
                        Console.Write(el + " ");
                    }

                    Console.WriteLine("\nHow much times you want to rotate your array?");
                    int k = int.Parse(Console.ReadLine());
                    if (k < 0)
                    {
                        Console.WriteLine("Error: Number of rotations must be a non-negative integer.");
                        return;
                    }
                    List<List<int>> allRotations = new List<List<int>>();
                    for (int i = 0; i < k; i++)
                    {
                        List<int> temp = new List<int>(array);
                        rotateArray(ref temp);
                        allRotations.Add(new List<int>(temp));
                        array = new List<int>(temp);
                    }
                    List<int> result = sumOfArrays(allRotations);
                    Console.WriteLine("Result array after " + k + " rotations and summing:");
                    foreach (int el in result)
                    {
                        Console.Write(el + " ");
                    }

                }
            break;
            case 3:
                {
                    Console.WriteLine("Enter number of elements in array, in end you will get 4x elements(enter 7 get 42 elements)");
                    int n = int.Parse(Console.ReadLine());
                    if (n <= 0)
                    {
                        Console.WriteLine("Error: Length must be a positive integer.");
                        return;
                    }
                    List<int> array = new List<int>(new int[n * 4]);
                    fillArrayRand(ref array);
                    Console.WriteLine("Your array: ");
                    foreach (int el in array)
                    {
                        Console.Write(el + " ");
                    }
                    Console.WriteLine();
                    List<int> result1 = new List<int>();
                    result1.AddRange(array.GetRange(0, n));
                    result1.Reverse();
                    List<int> result2 = new List<int>();
                    result2.AddRange(array.GetRange((3*n), n));
                    result2.Reverse();
                    List<int> result = new List<int>();
                    result.AddRange(result1);
                    result.AddRange(result2);
                    array.RemoveRange(0, n);
                    array.RemoveRange(array.Count - n, n);
                    for (int i = 0; i < result.Count(); i++)
                    {
                        result[i] += array[i];
                    }
                    Console.WriteLine("Result array: ");
                    foreach (int el in result)
                    {
                        Console.Write(el + " ");
                    }
                    Console.WriteLine();
                }
                break;
            case 4:
                {
                    Console.WriteLine("Enter a positive integer to get all prime number behind it:");
                    int n = int.Parse(Console.ReadLine());
                    if (n < 2)
                    {
                        Console.WriteLine("Error: Number must be a higher than value you entered.");
                        return;
                    }
                    for (int i = 2; i < n; i++)
                    {
                        if (isPrime(i))
                        {
                            Console.Write(i + " ");
                        }
                    }
                }
                break;
            case 5:
                {
                    List<char> charList1 = new List<char>();
                    List<char> charList2 = new List<char>();
                    Console.WriteLine("Enter the first array of characters (space-separated):");
                    string sentence1 = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(sentence1))
                    {
                        Console.WriteLine("Error: Input cannot be empty.");
                        return;
                    }
                    charList1.AddRange(sentence1.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(s => s[0]));
                    Console.WriteLine("Enter the second array of characters (space-separated):");
                    string sentence2 = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(sentence2))
                    {
                        Console.WriteLine("Error: Input cannot be empty.");
                        return;
                    }
                    charList2.AddRange(sentence2.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(s => s[0]));
                    int res = CompareLex(charList1, charList2);
                    if (res < 0)
                    {
                        Console.WriteLine("The first array is lexicographically smaller than the second.");
                        Console.WriteLine(new string(charList1.ToArray()));
                        Console.WriteLine(new string(charList2.ToArray()));
                    }
                    
                    else if (res > 0)
                    {
                        Console.WriteLine("The first array is lexicographically greater than the second.");
                        Console.WriteLine(new string(charList2.ToArray()));
                        Console.WriteLine(new string(charList1.ToArray()));
                    }
                    else
                    {
                        Console.WriteLine("Both arrays are lexicographically equal.");
                        Console.WriteLine(new string(charList1.ToArray()));
                        Console.WriteLine(new string(charList2.ToArray()));
                    }

                }
                break;
            case 6:
                {
                    Console.WriteLine("Enter number sequence(space-separeted)");
                    List<int> nums = new List<int>();
                    string input = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(input))
                    {
                        Console.WriteLine("Error: Input cannot be empty.");
                        return;
                    }
                    nums.AddRange(input.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(s => int.Parse(s)));
                    int stIndex = 0, len = 1, bestIndex = 0, bestLen = 1;
                    for (int i = 1; i < nums.Count; i++)
                    {
                        if (nums[i] == nums[i - 1])
                        {
                            len++;
                        }
                        else
                        {
                           
                            stIndex = i;
                            len = 1;
                        }
                        if (len > bestLen)
                        {
                            bestLen = len;
                            bestIndex = stIndex;
                        }
                    }
                    Console.WriteLine("Result sequence: ");
                    for (int i = bestIndex; i < bestIndex + bestLen; i++)
                    {
                        Console.Write(nums[i] + " ");
                    }
                }
                break;
            case 7:
                {
                    Console.WriteLine("Enter number sequence(space-separeted)");
                    List<int> nums = new List<int>();
                    string input = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(input))
                    {
                        Console.WriteLine("Error: Input cannot be empty.");
                        return;
                    }
                    nums.AddRange(input.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(s => int.Parse(s)));
                    int stIndex = 0, len = 1, bestIndex = 0, bestLen = 1;
                    for (int i = 1; i < nums.Count; i++)
                    {
                        if (nums[i] > nums[i - 1])
                        {
                            len++;
                        }
                        else
                        {

                            stIndex = i;
                            len = 1;
                        }
                        if (len > bestLen)
                        {
                            bestLen = len;
                            bestIndex = stIndex;
                        }
                    }
                    Console.WriteLine("Result sequence: ");
                    for (int i = bestIndex; i < bestIndex + bestLen; i++)
                    {
                        Console.Write(nums[i] + " ");
                    }
                }
                break;
                case 8:
                {
                    Console.WriteLine("Enter number sequence(space-separeted)");
                    List<int> nums = new List<int>();
                    string input = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(input))
                    {
                        Console.WriteLine("Error: Input cannot be empty.");
                        return;
                    }
                    nums.AddRange(input.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(s => int.Parse(s)));
                    Dictionary<int, int> frequency = new Dictionary<int, int>();
                    int bestNum = nums[0];
                    int bestCount = 0;
                    foreach (int num in nums)
                    {
                        if (frequency.ContainsKey(num))
                        {
                            frequency[num]++;
                        }
                        else
                        {
                            frequency[num] = 1;
                        }
                        if (frequency[num] > bestCount)
                        {
                            bestCount = frequency[num];
                            bestNum = num;
                        }
                    }
                    Console.WriteLine("Most frequent number is " + bestNum + " with " + bestCount + " repetitions.");
                }
                break;
            case 9:
                {
                    fillDict(ref alphabet);
                    Console.WriteLine("Enter a string:");
                    string input = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(input))
                    {
                        Console.WriteLine("Error: Input cannot be empty.");
                        return;
                    }
                    
                    foreach(char el in input)
                    {
                        Console.WriteLine("Your word: " + input + "\n" + el + "->" + alphabet[el]);
                    }
                }
                break;
            case 10:
                {
                    Console.WriteLine("Enter number sequence(space-separeted)");
                    List<int> nums = new List<int>();
                    string input = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(input))
                    {
                        Console.WriteLine("Error: Input cannot be empty.");
                        return;
                    }
                    nums.AddRange(input.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(s => int.Parse(s)));
                   List<string> pairs = new List<string>();
                    Console.WriteLine("enter number which you want to be difference:");
                    int difference = int.Parse(Console.ReadLine());
                    for (int i = 0; i < nums.Count(); i++)
                    {
                        for (int j = i + 1; j < nums.Count(); j++)
                        {
                            if (Math.Abs(nums[i] - nums[j]) == difference)
                            {
                                int a = Math.Min(nums[i], nums[j]);
                                int b = Math.Max(nums[i], nums[j]);
                                pairs.Add($"{a},{b}");
                            }
                        }
                    }
                    if (pairs.Count == 0)
                    {
                        Console.WriteLine("No pairs found with the specified difference.");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Result pairs with difference " + difference + ": ");
                        foreach (string pair in pairs)
                        {
                            Console.WriteLine(pair);
                        }
                    }
                }
                break;
            default:
                {
                    Console.WriteLine("Error: Task number must be between 1 and 10.");
                }
            break;
        }
       
    }
}