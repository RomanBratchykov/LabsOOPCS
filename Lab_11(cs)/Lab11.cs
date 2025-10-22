using P01_HarvestingFields;
using System;
using System.Reflection;
using P02_BlackBoxInteger;
using System.Diagnostics;
using Lab_11_cs_.InfernoInfinity;
using Lab_11_cs_;

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
                    {
                        Console.WriteLine("Write starter colors of traffic light (Red Green Yellow, etc)");
                        List<string> light = Console.ReadLine().Split(' ').ToList();
                        Console.WriteLine("Enter number of times to switch");
                        int times = int.Parse(Console.ReadLine());
                        for (int i = 0; i < times; i++)
                        {
                            string currentLight = light[2];
                            light.RemoveAt(2);
                            light.Insert(0, currentLight);
                            foreach (var color in light)
                            {
                                Console.Write(color + " ");
                            }
                            Console.WriteLine();
                        }

                    }
                    break;
                case 4:
                    {
                        Console.WriteLine("Create your weapon, add gemstones and remove them\nWrite 'help' to get info, end to stop");
                        List<Weapon> weapons = new List<Weapon>();
                        while (true){
                            string input = Console.ReadLine();  
                            if(input.ToLower() == "end"){
                                break;
                            }
                            if(input.ToLower() == "help"){
                                Console.WriteLine("To create weapon write: Create;{weaponRarity} {weaponType};{weaponName}\n" +
                                "To add gem write: Add;{weapon name};{socketIndex};{gemType} {gemClarity}\n" +
                                "To remove gem write: Remove;{weapon name};{socketIndex}\n" +
                                "To print weapon write: Print;{weapon name}");
                                continue;
                            }
                            string[] commandParts = input.Split(";");
                            string command = commandParts[0];
                            switch (command.ToLower())
                            {
                                case "create":
                                    {
                                        if (commandParts.Length != 3)
                                        {
                                            Console.WriteLine("Wrong input for create command");
                                            continue;
                                        }
                                        string weaponInfo = commandParts[1];
                                        string weaponName = commandParts[2];
                                        try
                                        {
                                            Weapon weapon = new Weapon(weaponInfo, weaponName);
                                            weapons.Add(weapon);
                                        }
                                        catch (ArgumentException ae)
                                        {
                                            Console.WriteLine(ae.Message);
                                        }
                                    }
                                    break;
                                case "add":
                                    {
                                        if (commandParts.Length != 4)
                                        {
                                            Console.WriteLine("Wrong input for add command");
                                            continue;
                                        }
                                        string weaponName = commandParts[1];
                                        Weapon currentWeapon;
                                        bool hasFound = false;
                                        foreach (var w in weapons)
                                        {
                                            if (w.Name == weaponName)
                                            {
                                                currentWeapon = w;
                                                int socketIndex = int.Parse(commandParts[2]);
                                                hasFound = true;
                                                string gemInput = commandParts[3];
                                                try
                                                {
                                                    currentWeapon.AddGem(socketIndex, gemInput);
                                                }
                                                catch (ArgumentException ae)
                                                {
                                                    Console.WriteLine(ae.Message);
                                                }
                                                break;
                                            }
                                        }
                                        if (!hasFound)
                                        {
                                            Console.WriteLine("Weapon not found");
                                        }
                                    }
                                    break;
                                case "remove":
                                    {
                                        if (commandParts.Length != 3)
                                        {
                                            Console.WriteLine("Wrong input for remove command");
                                            continue;
                                        }
                                        string weaponName = commandParts[1];
                                        Weapon currentWeapon;
                                        bool hasFound = false;
                                        foreach (var w in weapons)
                                        {
                                            if (w.Name == weaponName)
                                            {
                                                currentWeapon = w;
                                                hasFound = true;
                                                int socketIndex = int.Parse(commandParts[2]);
                                                try
                                                {
                                                    currentWeapon.RemoveGem(socketIndex);
                                                }
                                                catch (ArgumentException ae)
                                                {
                                                    Console.WriteLine(ae.Message);
                                                }
                                                break;
                                            }
                                        }
                                        if (!hasFound)
                                        {
                                            Console.WriteLine("Weapon not found");
                                        }
                                        
                                    }
                                    break;
                                case "print":
                                    {
                                        if (commandParts.Length != 2)
                                        {
                                            Console.WriteLine("Wrong input for remove command");
                                            continue;
                                        }
                                        string weaponName = commandParts[1];
                                        Weapon currentWeapon;
                                        bool hasFound = false;
                                        foreach (var w in weapons)
                                        {
                                            if (w.Name == weaponName)
                                            {
                                                hasFound = true;
                                                Console.WriteLine(w.ToString());
                                            }
                                        }
                                        if (!hasFound)
                                        {
                                            Console.WriteLine("Weapon not found");
                                        }
                                    }
                                    break;
                                default:
                                    Console.WriteLine("Wrong command");
                                    break;
                            }

                        }
                    }
                    break;
                case 5:
                    {
                       Console.WriteLine("Enter commands author/revision/description/reviewers, end to stop");
                        Type weaponType = typeof(Weapon);
                        CustomAttribute attr = (CustomAttribute)Attribute.GetCustomAttribute(weaponType, typeof(CustomAttribute));

                        string input;
                        while ((input = Console.ReadLine()) != null)
                        {
                            if (input.ToLower() == "end")
                                break;

                            switch (input.ToLower())
                            {
                                case "author":
                                    Console.WriteLine($"Author: {attr.Author}");
                                    break;
                                case "revision":
                                    Console.WriteLine($"Revision: {attr.Revision}");
                                    break;
                                case "description":
                                    Console.WriteLine($"Class description: {attr.Description}");
                                    break;
                                case "reviewers":
                                    Console.WriteLine($"Reviewers: {string.Join(", ", attr.Reviewers)}");
                                    break;
                                default:
                                    {
                                        Console.WriteLine("Wrong command");
                                    }
                                    break;
                            }
                        }

                    }
                    break;
                    default:
                    Console.WriteLine("Wrong number of task");
                    break;
            }
        }
    }
}