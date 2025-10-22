using P01_HarvestingFields;
using System;
using System.Reflection;

public class Lab11
{
    public static void Main(string[] args)
    { 
        while (true)
        { 
            Console.WriteLine("Enter number of task 1-5, 0 to exit");
            int task = int.Parse(Console.ReadLine());
            if (task == 0) { return; }
            switch (task)
            {
                case 1:
                    {
                        Console.WriteLine("Enter commands to print fields: private/pritected/public/all, harvest to stop");
                        while (true)
                        {
                            string input = Console.ReadLine();
                            if (input.ToLower() == "harvest")
                            {
                                break;
                            }
                            switch (input.ToLower())
                            {
                                case "private":
                                    foreach (var field in typeof(HarvestingFields).GetFields(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic))
                                    {
                                        if (field.IsPrivate)
                                        {
                                            Console.WriteLine($"{field.Attributes.ToString().ToLower().Replace("family", "private")} {field.FieldType.Name} {field.Name}");
                                        }
                                    }
                                    break;
                                case "protected":
                                    foreach (var field in typeof(HarvestingFields).GetFields(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic))
                                    {
                                        if (field.IsFamily)
                                        {
                                            Console.WriteLine($"{field.Attributes.ToString().ToLower().Replace("family", "protected")} {field.FieldType.Name} {field.Name}");
                                        }
                                    }
                                    break;
                                case "public":
                                    foreach (var field in typeof(HarvestingFields).GetFields(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public))
                                    {
                                        if (field.IsPublic)
                                        {
                                            Console.WriteLine($"{field.Attributes.ToString().ToLower().Replace("family", "protected")} {field.FieldType.Name} {field.Name}");
                                        }
                                    }
                                    break;
                                case "all":
                                    foreach (var field in typeof(HarvestingFields).GetFields(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic))
                                    {
                                        Console.WriteLine($"{field.Attributes.ToString().ToLower().Replace("family", "protected")} {field.FieldType.Name} {field.Name}");
                                    }
                                    break;
                                                                    default:
                                    Console.WriteLine("wrong input");
                                    break;


                            }
                        }
                        
                    }
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                    default:
                    Console.WriteLine("Wrong number of task");
                    break;
            }
        }
    }
}