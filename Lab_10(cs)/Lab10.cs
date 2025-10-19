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
                throw new NotImplementedException();
                break;
            case 4:
                throw new NotImplementedException();
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