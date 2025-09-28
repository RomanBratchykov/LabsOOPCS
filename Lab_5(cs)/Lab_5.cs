using System;

namespace Lab_5;

public class Lab_5
{
    public static void Main(string[] args)
    {
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Choose task 2-3, 0 for exit");
        int task = int.Parse(Console.ReadLine());
        switch (task)
        {
            case 2:
                {
                    Console.WriteLine("Enter clients and their money, example [person=[value of money], to stop write end]");
                    string input = string.Empty;
                    List<Person> persons = new List<Person>();
                    while (input.ToLower() != "end")
                    {
                        input = Console.ReadLine();
                        if (input == null) break;
                        string[] personData = input.Split("=");
                        if (personData.Length == 2)
                        {
                            try
                            {
                                persons.Add(new Person(personData[0], decimal.Parse(personData[1])));
                            }
                            catch (ArgumentException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        else if (input.ToLower() != "end")
                        {
                            Console.WriteLine("Wrong input");
                        }
                    }
                    Console.WriteLine("Enter products and their cost, example [product=[cost], to stop write end]");
                    input = string.Empty;
                    List<Product> products = new List<Product>();
                    while (input.ToLower() != "end")
                    {
                        input = Console.ReadLine();
                        if (input == null) break;
                        string[] productData = input.Split("=");
                        if (productData.Length == 2)
                        {
                            try
                            {
                                products.Add(new Product(productData[0], decimal.Parse(productData[1])));
                            }
                            catch (ArgumentException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        else if (input.ToLower() != "end")
                        {
                            Console.WriteLine("Wrong input");
                        }
                    }
                    Console.WriteLine("Enter person and product you want to add");
                    input = string.Empty;
                    while (input.ToLower() != "end")
                    {
                        input = Console.ReadLine();
                        if (input == null) break;
                        string[] buyData = input.Split(" ");
                        if (buyData.Length == 2)
                        {
                            Person? person = persons.Find(p => p.Name == buyData[0]);
                            Product? product = products.Find(p => p.Name == buyData[1]);
                            if (person != null && product != null)
                            {
                                person.buyProduct(product);
                            }
                            else
                            {
                                Console.WriteLine("Wrong input");
                            }
                        }
                        else if (input.ToLower() != "end")
                        {
                            Console.WriteLine("Wrong input");
                        }
                    }
                    foreach (Person person in persons)
                    {
                        person.showProducts();
                    }
                }
                break;
            case 3:
                { 
                }
                break;
            case 0:
                break;
            default:
                Console.WriteLine("Wrong task number");
                break;
        }

    }
}