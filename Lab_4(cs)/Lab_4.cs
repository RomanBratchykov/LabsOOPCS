using System;
using System.Transactions;


namespace Lab_4_cs_;
static public class Lab_4
{
    static void AddItem(Dictionary<string, long> dict, string key, long value)
    {
        if (dict.ContainsKey(key))
            dict[key] += value;
        else
            dict[key] = value;
    }
    static public void Main()
    {
        Console.WriteLine("Choose your task 1-4, 0 for exit");
        int task = int.Parse(Console.ReadLine());
        switch (task)
        {
            case 1:
                {


                    Console.WriteLine("Enter coordinates (Example: 1 2 6 8)");
                    string[] input = Console.ReadLine().Split(' ');
                    int x1 = int.Parse(input[0]);
                    int y1 = int.Parse(input[1]);
                    Point topLeft = new Point(x1, y1);
                    int x2 = int.Parse(input[2]);
                    int y2 = int.Parse(input[3]);
                    Point bottomRight = new Point(x2, y2);
                    Rectangle rect = new Rectangle(topLeft, bottomRight);
                    Console.WriteLine("Enter number of points");
                    int numberOfPoints = int.Parse(Console.ReadLine());
                    for (int i = 0; i < numberOfPoints; i++)
                    {
                        Console.WriteLine("Enter coordinates of point (Example: 3 4)");
                        string[] pointInput = Console.ReadLine().Split(' ');
                        int px = int.Parse(pointInput[0]);
                        int py = int.Parse(pointInput[1]);
                        Point point = new Point(px, py);
                        if (rect.Contains(point))
                        {
                            Console.WriteLine("Point is inside the rectangle");
                        }
                        else
                        {
                            Console.WriteLine("Point is outside the rectangle");
                        }
                    }
                }
                break;
            case 2:
                {
                    Console.WriteLine("create booking(format <pricePerDay> <numberOfDays> <season> <discountType>(can be skipped))");
                    string[] input = Console.ReadLine().Split(' ');
                    if (input.Length < 3 && input.Length < 4)
                    {
                        Console.WriteLine("You entered wrong size;");
                        break;  
                    }
                    if (input.Length == 3)
                    {
                        decimal pricePerDay = decimal.Parse(input[0]);
                        if (pricePerDay < 0 && pricePerDay > 1000)
                        {
                            Console.WriteLine("Wrong input of price");
                            break;
                        }
                        int numberOfDays = int.Parse(input[1]);
                        if (numberOfDays < 0 && numberOfDays > 1000)
                        {
                            Console.WriteLine("Wrong input of days");
                            break;
                        }
                        string seasonInput = input[2];
                        Season season;
                        if (!Enum.TryParse(seasonInput, true, out season))
                        {
                            Console.WriteLine("Wrong input of season");
                            break;
                        }
                        PriceCalculator booking = new PriceCalculator(pricePerDay, numberOfDays, season);
                        Console.WriteLine($"Total price: {booking.CalculatePrice():F2}");
                    }
                    if (input.Length == 4)
                    {
                        decimal pricePerDay = decimal.Parse(input[0]);
                        if (pricePerDay < 0 && pricePerDay > 1000)
                        {
                            Console.WriteLine("Wrong input of price");
                            break;
                        }
                        int numberOfDays = int.Parse(input[1]);
                        if (numberOfDays < 0 && numberOfDays > 1000)
                        {
                            Console.WriteLine("Wrong input of days");
                            break;
                        }
                        string seasonInput = input[2];
                        Season season;
                        if (!Enum.TryParse(seasonInput, true, out season))
                        {
                            Console.WriteLine("Wrong input of season");
                            break;
                        }
                        string discountInput = input[3];
                        Discount discount;
                        if (!Enum.TryParse(discountInput, true, out discount))
                        {
                            Console.WriteLine("Wrong input of discount");
                            break;
                        }
                        PriceCalculator booking = new PriceCalculator(pricePerDay, numberOfDays, season, discount);
                        Console.WriteLine($"Total price: {booking.CalculatePrice():F2}");
                    }
                }
                break;
            case 3:
                {
                    Console.WriteLine("Enter department, doctor and patient name(Example: Therapy Mr.John Mr.Steve)");
                    var hospital = new Hospital();

                    string input;
                    while ((input = Console.ReadLine()) != "Output")
                    {
                        var parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                        if (parts.Length > 3 && parts.Length <= 0)
                        {
                            Console.WriteLine("Wrong input");
                            continue;
                        }
                        string department = parts[0];
                        DepartmentEnum department1;
                        if (!Enum.TryParse<DepartmentEnum>(department, true, out department1))
                        {
                            Console.WriteLine("Wrong department");
                            continue;
                        }
                        string doctor = parts[1];
                        string patient = parts[2];

                        hospital.AddPatient(department, doctor, patient);
                    }
                    Console.WriteLine("Enter commands: department [name of department], department patient [name of patient], doctor [name of doctor]");
                    while ((input = Console.ReadLine()) != "End")
                    {
                        var parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                        if (parts.Length == 2 && parts[0].ToLower() == "department")
                            hospital.PrintDepartment(parts[1]);
                        else if (parts.Length == 3 && int.TryParse(parts[1], out int room))
                            hospital.PrintRoom(parts[0], room);
                        else if (parts.Length == 2 && parts[0].ToLower() == "doctor" )
                            hospital.PrintDoctor(parts[1]);
                        else
                        {
                            Console.WriteLine("Wrong input");
                            break;
                        }
                    }
                }
                break;
            case 4:
                {
                    Console.WriteLine("Enter size of rucksack");
                    long capacity = long.Parse(Console.ReadLine());
                    Console.WriteLine("Enter your treasures");
                    string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    long currentCapacity = 0;
                    long totalGold = 0;
                    long totalGem = 0;
                    long totalCash = 0;

                    Dictionary<string, long> goldItems = new Dictionary<string, long>(StringComparer.OrdinalIgnoreCase);
                    Dictionary<string, long> gemItems = new Dictionary<string, long>(StringComparer.OrdinalIgnoreCase);
                    Dictionary<string, long> cashItems = new Dictionary<string, long>(StringComparer.OrdinalIgnoreCase);

                    for (int i = 0; i < input.Length; i += 2)
                    {
                        string name = input[i];
                        long amount = long.Parse(input[i + 1]);

                        string type = null;
                        if (name.Equals("Gold", StringComparison.OrdinalIgnoreCase))
                            type = "Gold";
                        else if (name.Length >= 4 && name.EndsWith("Gem", StringComparison.OrdinalIgnoreCase))
                            type = "Gem";
                        else if (name.Length == 3)
                            type = "Cash";

                        if (type == null)
                            continue;

                        if (currentCapacity + amount > capacity)
                            continue;

                        long newGold = totalGold;
                        long newGem = totalGem;
                        long newCash = totalCash;

                        if (type == "Gold") newGold += amount;
                        else if (type == "Gem") newGem += amount;
                        else if (type == "Cash") newCash += amount;

                        if (newGold < newGem)
                            continue; 
                        if (newGem < newCash)
                            continue; 


                        currentCapacity += amount;
                        if (type == "Gold") totalGold += amount;
                        else if (type == "Gem") totalGem += amount;
                        else if (type == "Cash") totalCash += amount;

                        if (type == "Gold")
                            AddItem(goldItems, name, amount);
                        else if (type == "Gem")
                            AddItem(gemItems, name, amount);
                        else if (type == "Cash")
                            AddItem(cashItems, name, amount);
                    }

                    var types = new List<(string Type, Dictionary<string, long> Items, long Total)>();

                    if (goldItems.Count > 0) types.Add(("Gold", goldItems, totalGold));
                    if (gemItems.Count > 0) types.Add(("Gem", gemItems, totalGem));
                    if (cashItems.Count > 0) types.Add(("Cash", cashItems, totalCash));

                    foreach (var t in types.OrderByDescending(x => x.Total))
                    {
                        Console.WriteLine($"<{t.Type}> ${t.Total}");
                        foreach (var item in t.Items
                            .OrderByDescending(x => x.Key, StringComparer.OrdinalIgnoreCase)
                            .ThenBy(x => x.Value))
                        {
                            Console.WriteLine($"##{item.Key} - {item.Value}");
                        }
                    }
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