using P01_HarvestingFields;
using System;
using System.Reflection;
using P02_BlackBoxInteger;

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
                        Console.WriteLine("Enter commands to print fields: private/protected/public/all, harvest to stop");
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
                    {
                        Type type = typeof(BlackBoxInteger);
                        ConstructorInfo ctor = type.GetConstructor(
                        BindingFlags.NonPublic | BindingFlags.Instance,
                        null,
                        new Type[] { typeof(int) },
                        null
                        );
                        BlackBoxInteger blackBox = (BlackBoxInteger)ctor.Invoke(new object[] { 0});
                        FieldInfo field = type.GetField("innerValue", BindingFlags.NonPublic | BindingFlags.Instance);

                        Console.WriteLine("Enter commands to do operations: add//subtract/multiply/divide/leftShift/rightShift, end to stop");
                        while (true)
                        {
                            string[] input = Console.ReadLine().Split('_');
                            if (input[0].ToLower() == "end")
                            {
                                break;
                            }
                            int number = int.Parse(input[1]);
                            MethodInfo method = null;
                            foreach (MethodInfo candidate in type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance))
                            {
                                if (candidate.Name.Equals(input[0], StringComparison.OrdinalIgnoreCase) &&
                                    candidate.GetParameters().Length == 1 &&
                                    candidate.GetParameters()[0].ParameterType == typeof(int))
                                {
                                    method = candidate;
                                    break;
                                }
                            }

                            if (method == null)
                            {
                                Console.WriteLine("This command doesn`t exist");
                                continue;
                            }
                            method.Invoke(blackBox, new object[] { number });
                            Console.WriteLine(field.GetValue(blackBox));

                        }
                    }
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