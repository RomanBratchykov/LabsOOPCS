using System;
using System.Collections.Generic;

namespace Lab_10_cs_;
class Lab10
{
    static void Main()
    {
        Console.WriteLine("Enter number of task 1-5, 0 to exit");
        int task = int.Parse(Console.ReadLine());
        switch (task)
        {
            case 1:
                {
                    Console.WriteLine("Create list with command 'Create' and start enter elements\nAfter that enter commands Move/Print/HasNext(case insensitive), end to stop");
                    int counterOfCommands = 0;
                    ListyIterator<string> listyIterator = null;
                    while (true)
                    {
                        if (counterOfCommands > 100)
                        {
                            Console.WriteLine("Too many commands entered. Exiting.");
                        }
                        string input = Console.ReadLine();
                        List<string> parts = new List<string>(input.Split(' ', StringSplitOptions.RemoveEmptyEntries));
                        if (parts[0].ToLower() == "create" && counterOfCommands == 0)
                        {
                            if (parts.Count > 1)
                            {
                                parts.RemoveAt(0);
                                listyIterator = new ListyIterator<string>(parts);
                                counterOfCommands++;
                                continue;
                            }
                            else
                            {
                                listyIterator = new ListyIterator<string>();
                                counterOfCommands++;
                            }
                        }
                        else if (parts[0].ToLower() == "create" && counterOfCommands > 0)
                        {
                            Console.WriteLine("List is already created");
                            continue;
                        }
                        else if (counterOfCommands == 0 && parts[0].ToLower() != "create")
                        {
                            Console.WriteLine("Create the list first");
                            continue;
                        }
                        else if (parts[0].ToLower() == "end")
                        {
                            break;
                        }
                        else if (parts[0].ToLower() == "move")
                        {
                            Console.WriteLine(listyIterator.Move());
                        }
                        else if (parts[0].ToLower() == "print")
                        {
                            try
                            {
                                listyIterator.Print();
                            }
                            catch (InvalidOperationException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        else if (parts[0].ToLower() == "hasnext")
                        {
                            Console.WriteLine(listyIterator.HasNext());
                        }
                        counterOfCommands++;
                    }
                }
                break;
            case 2:
                {
                    Console.WriteLine("Create list with command 'Create' and start enter elements\nAfter that enter commands Move/Print/HasNext/PrintAll(case insensitive), end to stop");
                    int counterOfCommands = 0;
                    ListyIterator<string> listyIterator = null;
                    while (true)
                    {
                        if (counterOfCommands > 100)
                        {
                            Console.WriteLine("Too many commands entered. Exiting.");
                        }
                        string input = Console.ReadLine();
                        List<string> parts = new List<string>(input.Split(' ', StringSplitOptions.RemoveEmptyEntries));
                        if (parts[0].ToLower() == "create" && counterOfCommands == 0)
                        {
                            if (parts.Count > 1)
                            {
                                parts.RemoveAt(0);
                                listyIterator = new ListyIterator<string>(parts);
                                counterOfCommands++;
                                continue;
                            }
                            else
                            {
                                listyIterator = new ListyIterator<string>();
                                counterOfCommands++;
                            }
                        }
                        else if (parts[0].ToLower() == "create" && counterOfCommands > 0)
                        {
                            Console.WriteLine("List is already created");
                            continue;
                        }
                        else if (counterOfCommands == 0 && parts[0].ToLower() != "create")
                        {
                            Console.WriteLine("Create the list first");
                            continue;
                        }
                        else if (parts[0].ToLower() == "end")
                        {
                            break;
                        }
                        else if (parts[0].ToLower() == "move")
                        {
                            Console.WriteLine(listyIterator.Move());
                        }
                        else if (parts[0].ToLower() == "printall")
                        {
                            try
                            {
                                listyIterator.PrintAll();
                            }
                            catch (InvalidOperationException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        else if (parts[0].ToLower() == "print")
                        {
                            try
                            {
                                listyIterator.Print();
                            }
                            catch (InvalidOperationException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        else if (parts[0].ToLower() == "hasnext")
                        {
                            Console.WriteLine(listyIterator.HasNext());
                        }
                        counterOfCommands++;
                    }
                }
                break;
            case 3:
                {
                    Console.WriteLine("Enter persons by example John 23 Chernivtsi, end to stop");
                    List<Person> people = new List<Person>();
                    while (true)
                    {
                        string input = Console.ReadLine();
                        if (input.ToLower() == "end")
                        {
                            break;
                        }
                        List<string> parts = new List<string>(input.Split(' ', StringSplitOptions.RemoveEmptyEntries));
                        if (parts.Count != 3)
                        {
                            Console.WriteLine("Invalid input. Please enter in format: Name Age Town");
                            continue;
                        }
                        string name = parts[0];
                        if (!int.TryParse(parts[1], out int age))
                        {
                            Console.WriteLine("Invalid age. Please enter a valid integer for age.");
                            continue;
                        }
                        string town = parts[2];
                        Person person = new Person(name, age, town);
                        people.Add(person);
                    }
                    Console.WriteLine("Your list with indexes:");
                    for (int i = 0; i < people.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}.{people[i].Name} {people[i].Age} {people[i].Town}");
                    }
                    Console.WriteLine("Enter index of person to compare");
                    int index = int.Parse(Console.ReadLine()) - 1;
                    if (index < 0 || index >= people.Count)
                    {
                        Console.WriteLine("Invalid index.");
                        return;
                    }
                    Person personToCompare = people[index];
                    int equalCount = 0;
                    int notEqualCount = 0;
                    foreach (var person in people)
                    {
                        if (person.CompareTo(personToCompare) == 0)
                        {
                            equalCount++;
                        }
                        else
                            notEqualCount++;
                    }
                    if (equalCount == 1)
                    {
                        Console.WriteLine("No matches");
                    }
                    else
                    {
                        Console.WriteLine($"{equalCount} {notEqualCount} {people.Count}");
                    }
                }
                break;
            case 4:
                {
                    Console.WriteLine("Enter number of people:");
                    int numberOfPeople = int.Parse(Console.ReadLine());
                    if (numberOfPeople > 100 || numberOfPeople <= 0)
                    {
                        Console.WriteLine("Number of people must be between 1 and 100.");
                        return;
                    }
                    var nameSet = new SortedSet<PersonSecond>(new NameComparer());
                    var ageSet = new SortedSet<PersonSecond>(new AgeComparer());
                    for (int i = 0; i < numberOfPeople; i++)
                    {
                        try
                        {
                            string input = Console.ReadLine();
                            List<string> parts = new List<string>(input.Split(' ', StringSplitOptions.RemoveEmptyEntries));
                            if (parts.Count != 2)
                            {
                                Console.WriteLine("Invalid input. Please enter in format: Name Age");
                                i--;
                                continue;
                            }

                            string name = parts[0];
                            if (!int.TryParse(parts[1], out int age))
                            {
                                Console.WriteLine("Invalid age. Please enter a valid integer for age.");
                                i--;
                                continue;
                            }
                            PersonSecond person = new PersonSecond(name, age);
                            nameSet.Add(person);
                            ageSet.Add(person);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            i--;
                            continue;
                        }
                    }
                    Console.WriteLine("Sorted by name:");
                    foreach (var person in nameSet)
                    {
                        person.PrintPerson();
                    }
                    Console.WriteLine("Sorted by age:");
                    foreach (var person in ageSet)
                    {
                        person.PrintPerson();
                    }
                }
                break;
            case 5:
                throw new NotImplementedException();
                break;
            case 0:
                return;
            default:
                Console.WriteLine("Invalid task number.");
                break;
        }
    }
}