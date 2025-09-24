using System;


namespace Lab_4_cs_;
static public class Lab_4
{
    static public void Main()
    {
        Console.WriteLine("Choose your task 1-4, 0 for exit");
        int task = int.Parse(Console.ReadLine());
        switch (task)
        {
            case 1:
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
                int numberOfPoints= int.Parse(Console.ReadLine());
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
                break;
            case 2:
                {

                }
                break;
            case 3:
                {

                }
                break;
            case 4:
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