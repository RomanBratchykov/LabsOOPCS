using System;
using System.Collections.Generic;

class Lab_2
{
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
                    result2.AddRange(array.GetRange((3*n) - 1, n));
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
                }
                break;
            case 5:
                {
                }
                break;
            case 6:
                {
                }
                break;

            case 7:
                {
                }
                break;
                case 8:
                {
                }
                break;
            case 9:
                {
                }
                break;
            case 10:
                {
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