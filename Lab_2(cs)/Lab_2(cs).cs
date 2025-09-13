using System;
using System.Collections.Generic;


class Lab_2
{
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
                    
                }
            break;
        }
       
    }
}