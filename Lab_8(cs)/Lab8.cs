using System;
using Lab_8_cs_.Automobiles;

namespace Lab8;
internal class Lab8
{
    public static void Main()
    {
        Console.WriteLine("Enter number of task, 1-3, 0 for exit");
       
        while (true)
        {
            int task = int.Parse(Console.ReadLine());
            switch (task)
            {
                case 1:
                    {
                        Console.WriteLine("Enter car parameters: amount of fuel, liters per km, tank volume");
                        string[] carParams = Console.ReadLine().Split(' ');
                        if (carParams.Length != 3)
                        {
                                                       Console.WriteLine("Invalid number of parameters. Please enter exactly three parameters.");
                            break;
                        }
                        Car car = new Car(decimal.Parse(carParams[0]), decimal.Parse(carParams[1]), decimal.Parse(carParams[2]));
                        Console.WriteLine("Enter truck parameters: amount of fuel, liters per km, tank volume");
                        carParams = Console.ReadLine().Split(' ');
                        if (carParams.Length != 3)
                        {
                            Console.WriteLine("Invalid number of parameters. Please enter exactly three parameters.");
                            break;
                        }
                        Truck truck = new Truck(decimal.Parse(carParams[0]), decimal.Parse(carParams[1]), decimal.Parse(carParams[2]));
                        Console.WriteLine("Enter number of commands");
                        int commands = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter commands in format: Drive/Refuel Car/Truck distance/liters");
                        for (int i = 0; i < commands; i++)
                        {
                            string[] action = Console.ReadLine().Split(' ');
                            if (action.Length != 3)
                            {
                                Console.WriteLine("Invalid number of parameters. Please enter exactly three parameters.");
                                break;
                            }
                            if (action[0] == "Drive")
                            {
                                try
                                {
                                    if (action[1] == "Car")
                                    {
                                        car.Drive(decimal.Parse(action[2]));
                                        Console.WriteLine($"Car travelled {action[2]} km");
                                    }
                                    else if (action[1] == "Truck")
                                    {
                                        truck.Drive(decimal.Parse(action[2]));
                                        Console.WriteLine($"Truck travelled {action[2]} km");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid vehicle type. Please enter 'Car' or 'Truck'.");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }
                            else if (action[0] == "Refuel")
                            {
                                try
                                {
                                    if (action[1] == "Car")
                                    {
                                        car.Refuel(decimal.Parse(action[2]));
                                    }
                                    else if (action[1] == "Truck")
                                    {
                                        truck.Refuel(decimal.Parse(action[2]));
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid vehicle type. Please enter 'Car' or 'Truck'.");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid command. Please enter 'Drive' or 'Refuel'.");
                            }
                        }
                        car.ShowInfo();
                        truck.ShowInfo();
                    }
                    break;
                case 2:
                    {
                        Console.WriteLine("Enter car parameters: amount of fuel, liters per km, tank volume");
                        string[] carParams = Console.ReadLine().Split(' ');
                        if (carParams.Length != 3)
                        {
                            Console.WriteLine("Invalid number of parameters. Please enter exactly three parameters.");
                            break;
                        }
                        Car car = new Car(decimal.Parse(carParams[0]), decimal.Parse(carParams[1]), decimal.Parse(carParams[2]));
                        Console.WriteLine("Enter truck parameters: amount of fuel, liters per km, tank volume");


                        carParams = Console.ReadLine().Split(' ');
                        if (carParams.Length != 3)
                        {
                            Console.WriteLine("Invalid number of parameters. Please enter exactly three parameters.");
                            break;
                        }
                        Truck truck = new Truck(decimal.Parse(carParams[0]), decimal.Parse(carParams[1]), decimal.Parse(carParams[2]));

                        Console.WriteLine("Enter bus parameters: amount of fuel, liters per km, tank volume");
                        carParams = Console.ReadLine().Split(' ');
                        if (carParams.Length != 3)
                        {
                            Console.WriteLine("Invalid number of parameters. Please enter exactly three parameters.");
                            break;
                        }
                        Bus bus = new Bus(decimal.Parse(carParams[0]), decimal.Parse(carParams[1]), decimal.Parse(carParams[2]));
                        Console.WriteLine("Enter number of commands");
                        int commands = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter commands in format: Drive/Refuel Car/Truck distance/liters, for bus DriveEmpty/DriveFull/Refuel");
                        for (int i = 0; i < commands; i++)
                        {
                            string[] action = Console.ReadLine().Split(' ');
                            if (action.Length != 3)
                            {
                                Console.WriteLine("Invalid number of parameters. Please enter exactly three parameters.");
                                break;
                            }
                            if (action[0] == "Drive")
                            {
                                try
                                {
                                    if (action[1] == "Car")
                                    {
                                        car.Drive(decimal.Parse(action[2]));
                                    }
                                    else if (action[1] == "Truck")
                                    {
                                        truck.Drive(decimal.Parse(action[2]));
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid vehicle type. Please enter 'Car' or 'Truck'.");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }
                            else if (action[0] == "Refuel")
                            {
                                try
                                {
                                    if (action[1] == "Car")
                                    {
                                        car.Refuel(decimal.Parse(action[2]));
                                    }
                                    else if (action[1] == "Truck")
                                    {
                                        truck.Refuel(decimal.Parse(action[2]));
                                    }
                                    else if (action[1] == "Bus")
                                    {
                                        bus.Refuel(decimal.Parse(action[2]));
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid vehicle type. Please enter 'Car' or 'Truck' or 'Bus'");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }
                            else if (action[0] == "DriveEmpty")
                            {
                                try
                                {
                                    if (action[1] == "Bus")
                                    {
                                        bus = new Bus(bus.AmountOfFuel, bus.FuelConsumptionPerKm, bus.TamkVolume);
                                        bus.Drive(decimal.Parse(action[2]));
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid vehicle type. Please enter 'Bus'.");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }
                            else if (action[0] == "DriveFull")
                            {
                                try
                                {
                                    if (action[1] == "Bus")
                                    {
                                        bus = new Bus(bus.AmountOfFuel, bus.FuelConsumptionPerKm + 1.4m, bus.TamkVolume);
                                        bus.Drive(decimal.Parse(action[2]));
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid vehicle type. Please enter 'Bus'.");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid command. Please enter 'Drive' or 'Refuel'.");
                            }
                        }
                        car.ShowInfo();
                        truck.ShowInfo();
                        bus.ShowInfo();
                    }
                    break;
                case 3: {  }
                    break;
                    case 0:
                    {
                        return;
                    }
                default:
                    Console.WriteLine("Invalid task number. Please enter a number between 0 and 3.");
                    break;
            }
        }
    }
}