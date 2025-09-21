using Lab_3_cs_;
using System;
using System.Collections.Generic;

class Lab_3
{
    Person person1 = new Person("Pesho", 20);
    Person person2 = new Person("Gosho", 18);
    Person person3 = new Person("Stamat", 43);
    Person person4 = new Person();
    Person person5 = new Person()
    {
        Name = "Ivan",
        Age = 19
    };
    static void Main()
    {
        Console.WriteLine("Choose task 3-6");
        int task = int.Parse(Console.ReadLine());
        switch (task)
        {
            case 0:
                return;
            case 3:
                {
                    Family family = new Family();
                    Console.WriteLine("Enter number of members:");
                    int num = int.Parse(Console.ReadLine());
                    for (int i = 0; i < num; i++)
                    {
                        Console.WriteLine("Enter name and age:");
                        string[] input = Console.ReadLine().Split();
                        string name = input[0];
                        int age = int.Parse(input[1]);
                        Person person = new Person(name, age);
                        family.AddMember(person);
                    }
                    family.PrintOldestMember();
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
            default:
                {
                    Console.WriteLine("Invalid task number");
                }
                break;
        }
    }
}
