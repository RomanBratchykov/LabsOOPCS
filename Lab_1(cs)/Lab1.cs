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
        Console.WriteLine("task 9:");
        Console.Write("Enter side a: ");
        double sideA = double.Parse(Console.ReadLine());
        Console.Write("Enter side b: ");
        double sideB = double.Parse(Console.ReadLine());
        Console.Write("Enter height: ");
        double height = double.Parse(Console.ReadLine());
        double area = 0.5 * (sideA + sideB) * height;
        Console.WriteLine("The area of the trapezoid is: " + area);
        Console.WriteLine("task 10, enter number:");
        int n = int.Parse(Console.ReadLine());
        int lastDigit = n % 10;
        Console.WriteLine($"n: {n}, last digit: {lastDigit}");
        Console.WriteLine("task 11, enter number and position:");
        int number = int.Parse(Console.ReadLine());
        int digit = int.Parse(Console.ReadLine());
        if (digit <= 0 || digit > number.ToString().Length)
        {
            Console.WriteLine("-");
        }
        else
        {
            int nDigit = (number / (int)Math.Pow(10, digit - 2)) % 10;
            Console.WriteLine($"number: {number}, digit: {digit}, nDigit: {nDigit}");
        }
        Console.WriteLine("task 12, enter number:");
        int num = int.Parse(Console.ReadLine());
        if (num > 20 && num % 2 == 1)
        {
            Console.WriteLine("true");
        }
        else
        {
            Console.WriteLine("false");
        }
        Console.WriteLine("task 13, enter number:");
        int number13 = int.Parse(Console.ReadLine());
        if (number13 % 9 == 0 && number13 % 11 == 0 && number13 % 13 == 0)
        {
            Console.WriteLine("true");
        }
        else
        {
            Console.WriteLine("false");
        }
        Console.WriteLine("task 14, enter three numbers:");
        int num1 = int.Parse(Console.ReadLine());
        int num2 = int.Parse(Console.ReadLine());
        int num3 = int.Parse(Console.ReadLine());
        Console.WriteLine($"num1: {num1}, num2: {num2}, num3: {num3}");
        Console.Write("The biggest number is: ");
        if (num1 > num2 && num1 > num3)
        {
            Console.WriteLine(num1);
        }
        else if (num2 > num1 && num2 > num3)
        {
            Console.WriteLine(num2);
        }
        else
        {
            Console.WriteLine(num3);
        }
        Console.WriteLine("task 15, enter three numbers:");
        int n1 = int.Parse(Console.ReadLine());
        int n2 = int.Parse(Console.ReadLine());
        int n3 = int.Parse(Console.ReadLine());
        int product = n1 * n2 * n3;
        Console.WriteLine($"n1: {n1}, n2: {n2}, n3: {n3}");
        if (product > 0)
        {
            Console.WriteLine("The product is positive.");
        }
        else if (product < 0)
        {
            Console.WriteLine("The product is negative.");
        }
        else
        {
            Console.WriteLine("The product is zero.");
        }
        Console.WriteLine("task 16, enter number 1-7:");
        int day = int.Parse(Console.ReadLine());
        if (day < 1 && day > 7)
        {
            Console.WriteLine("Don`t exist");
        }
        else
        {
            switch (day)
            {
                case 1:
                    Console.WriteLine("Monday");
                    break;
                case 2:
                    Console.WriteLine("Tuesday");
                    break;
                case 3:
                    Console.WriteLine("Wednesday");
                    break;
                case 4:
                    Console.WriteLine("Thursday");
                    break;
                case 5:
                    Console.WriteLine("Friday");
                    break;
                case 6:
                    Console.WriteLine("Saturday");
                    break;
                case 7:
                    Console.WriteLine("Sunday");
                    break;
            }
        }
        Console.WriteLine("Task 17, enter number:");
        int number17 = int.Parse(Console.ReadLine());
        int result = 1;
        if (number17 < 0)
        {
            Console.WriteLine("Don`t exist");
            return;
        }
        if (number17 == 1)
        {
            Console.WriteLine("1");
            return;
        }
        for (int i = 2; i <= number17; i++)
        {
            result *= i;
        }
        Console.WriteLine($"Factorial of {number17} is: {result}");
    }
}
