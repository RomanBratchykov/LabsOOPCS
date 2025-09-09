using System;

public class Lab1
{
    public static void Main()
    {
        Console.WriteLine("Red");
        Console.WriteLine("task 5:");
        int x = -100, x1 = 128, x2 = -3540, x3 = 64876;
        long y = 2147483648, y1 = -1141583228;
        Console.WriteLine($"int: {x}, {x1}, {x2}, {x3}");
        Console.WriteLine($"long: {y}, {y1}");
        Console.WriteLine("task 6:");
        double z = 3.141592653589793238, z1 = 1.60217657, z2 = 7.8184261974584555216535342341;
        Console.WriteLine("double: {0}, {1}, {2}", z, z1, z2);
        string string1 = "Chernivtsi National University\r\n", string2 = "I love programming\n";
        char char1 = 'B', char2 = 'y', char3 = 'e';
        Console.WriteLine("task 7:");
        Console.WriteLine("string: {0}{1}", string1, string2);
        Console.WriteLine("char: {0}, {1}, {2}", char1, char2, char3);
        Console.WriteLine("task 8:");
        int a, b, c;
        float avg;
        Console.Write("Enter first integer: ");
        a = int.Parse(Console.ReadLine());
        Console.Write("Enter second integer: ");
        b = int.Parse(Console.ReadLine());
        Console.Write("Enter third integer: ");
        c = int.Parse(Console.ReadLine());
        avg = (a + b + c) / 3.0f;
        Console.WriteLine("The average is: " + avg);
    }
}
