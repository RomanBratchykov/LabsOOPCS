using System;
using Lab_8_cs_.Automobiles;
using Lab_8_cs_.Farm;

namespace Lab8;
internal class Lab8
{
    public static void Main()
    {
        
       
        while (true)
        {
            Console.WriteLine("Enter number of task, 1-3, 0 for exit");
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
                case 3:
                    {
                        Dictionary<Animal, Food> farm = new Dictionary<Animal, Food>();
                        while (true)
                        {
                            Animal animal;
                            Console.WriteLine("Enter animal, help to get info, end to stop");
                            string animalStr = Console.ReadLine();
                            if (animalStr.ToLower() == "end")
                            {
                                break;
                            }
                            if (animalStr.ToLower() == "help")
                            {
                                Console.WriteLine("You need to enter animal by example\n Felines - \"{Type} {Name} {Weight} {LivingRegion} {Breed}\";\r\n• Birds - \"{Type} {Name} {Weight} {WingSize}\";\r\n• Mice and Dogs = \"{Type} {Name} {Weight} {LivingRegion}\";\r\n");
                                continue;
                            }
                            string[] animalParams = animalStr.Split(' ');
                            if (animalParams.Length < 4 && animalParams.Length > 5)
                            {
                                Console.WriteLine("Invalid number of parameters. Please enter correct parameters.");
                                continue;
                            }
                            if (animalParams[0] == "Hen") 
                            {
                                try
                                {
                                    Hen hen = new Hen(animalParams[1], double.Parse(animalParams[2]), double.Parse(animalParams[3]));
                                    animal = hen;
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                    continue;
                                }
                            }
                            else if (animalParams[0] == "Owl" && animalParams.Length == 4) 
                            {
                                try
                                {
                                    Owl owl = new Owl(animalParams[1], double.Parse(animalParams[2]), double.Parse(animalParams[3]));
                                    animal = owl;
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                    continue;
                                }
                            }
                            else if (animalParams[0] == "Mouse" && animalParams.Length == 4)
                            {
                                try
                                {
                                    Mouse mouse = new Mouse(animalParams[1], double.Parse(animalParams[2]), animalParams[3]);
                                    animal = mouse;
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                    continue;
                                }
                            }
                            else if (animalParams[0] == "Dog" && animalParams.Length == 4) 
                            {
                                try
                                {
                                    Dog dog = new Dog(animalParams[1], double.Parse(animalParams[2]), animalParams[3]);
                                    animal = dog;
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                    continue;
                                }
                            }
                            else if (animalParams[0] == "Cat" && animalParams.Length == 5) 
                            {
                                try
                                {
                                    Cat cat = new Cat(animalParams[1], double.Parse(animalParams[2]), animalParams[3], animalParams[4]);
                                    animal = cat;
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                    continue;
                                }
                            }
                            else if (animalParams[0] == "Tiger" && animalParams.Length == 5) 
                            {
                                try
                                {
                                    Tiger tiger = new Tiger(animalParams[1], double.Parse(animalParams[2]), animalParams[3], animalParams[4]);
                                    animal = tiger;
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                    continue;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid animal type. Please enter valid animal.");
                                continue;
                            }
                            
                            Console.WriteLine("Enter food(food type, quantity)");
                            string foodInput = Console.ReadLine();
                            string[] foodParams = foodInput.Split(' ');
                            if (foodParams.Length != 2)
                            {
                                Console.WriteLine("Invalid number of parameters. Please enter exactly two parameters.");
                                continue;
                            }
                            Food food;
                            try
                            {
                                if (foodParams[0] == "Vegetable")
                                {
                                    food = new Vegetable(int.Parse(foodParams[1]));
                                }
                                else if (foodParams[0] == "Fruit")
                                {
                                    food = new Fruit(int.Parse(foodParams[1]));
                                }
                                else if (foodParams[0] == "Meat")
                                {
                                    food = new Meat(int.Parse(foodParams[1]));
                                }
                                else if (foodParams[0] == "Seed")
                                {
                                    food = new Seed(int.Parse(foodParams[1]));
                                }
                                else
                                {
                                    Console.WriteLine("Invalid food type. Please enter valid food.");
                                    continue;
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                continue;
                            }
                            farm.Add(animal, food);
                        }
                        foreach (var item in farm)
                        {
                            try
                            {
                                item.Key.Eat(item.Value);
                                Console.WriteLine(item.Key.ToString());
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        break; // <-- Add this break to prevent fall-through
                    }
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