using System;
using System.Security.Cryptography.X509Certificates;
using System.Transactions;

namespace Lab_6;

public class Lab_6
{
    public static void Main()
    {
        Console.WriteLine("Choose task 1-4, 0 for exit");
        int task = int.Parse(Console.ReadLine());
        switch (task)
        {
            case 1:
                {
                    try
                    {
                        Console.WriteLine("Enter author, title and price");
                        string author = Console.ReadLine();
                        string title = Console.ReadLine();
                        decimal price = decimal.Parse(Console.ReadLine());
                        Book book = new Book(author, title, price);
                        GoldenEditionBook goldenEditionBook = new GoldenEditionBook(author, title, price);
                        book.showBook();
                        goldenEditionBook.showBook();
                    }
                    catch (ArgumentException ae)
                    {
                        Console.WriteLine(ae.Message);

                    }
                }
                break;
            case 2:
                {
                    Console.WriteLine("Enter student name, surname and faculty(example: john doe 894838), end to stop");
                    List<Human> humans = new List<Human>();
                    string input = string.Empty;
                    while(true)
                    {
                        input = Console.ReadLine();
                        if (input.ToLower() == "end") break;
                        string[] parts = input.Split(' ');
                        if (parts.Length != 3)
                        {
                            Console.WriteLine("Invalid input format. Please enter in the format: name surname facultyNumber");
                            continue;
                        }
                        try
                        {
                            Student student = new Student(parts[0], parts[1], parts[2]);
                            humans.Add(student);
                        }
                        catch (ArgumentException ae)
                        {
                            Console.WriteLine(ae.Message);
                        }
                    }
                    Console.WriteLine("Enter worker name, surname, salary per week, and work hours, end to stop");
                    while (true)
                    {
                        input = Console.ReadLine();
                        if (input.ToLower() == "end") break;
                        string[] parts = input.Split(' ');
                        if (parts.Length != 4)
                        {
                            Console.WriteLine("Invalid input format. Please enter in the format: name surname salaryPerWeek workHoursPerDay");
                            continue;
                        }
                        try
                        {
                            Worker worker = new Worker(parts[0], parts[1], decimal.Parse(parts[2]), int.Parse(parts[3]));
                            humans.Add(worker);
                        }
                        catch (ArgumentException ae)
                        {
                            Console.WriteLine(ae.Message);
                        }
                    }
                 
                    foreach (var human in humans)
                    {
                        Console.WriteLine(human);
                        Console.WriteLine();
                    }
                }
                break;
            case 3:
                {
                    Console.WriteLine("Enter artist, song name and length(first minutes second seconds), example: hower jokes 13 23, end to stop");
                    RadioStation radioStation = new RadioStation();
                    string input = string.Empty;
                    while (true)
                    {
                        input = Console.ReadLine();
                        if (input.ToLower() == "end") break;
                        string[] parts = input.Split(' ');
                        if (parts.Length != 4)
                        {
                            Console.WriteLine("Invalid input format. Please enter in the format: artist songName minutes seconds");
                            continue;
                        }
                        try
                        {
                            TimeSpan timeSpan = new TimeSpan(0, int.Parse(parts[2]), int.Parse(parts[3]));
                            Song song = new Song(parts[0], parts[1], timeSpan);
                            radioStation.AddSong(song);
                            Console.WriteLine("Song added.");
                        }
                        catch (InvalidSongException ise)
                        {
                            Console.WriteLine(ise.Message);
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Invalid input format for minutes or seconds.");
                        }
                    }
                    Console.WriteLine($"Songs added: {radioStation.Playlist.Count}");
                    Console.WriteLine($"Playlist length: {radioStation.FullLength.Hours}h {radioStation.FullLength.Minutes}m {radioStation.FullLength.Seconds}s");
                }
                break;
            case 4:
                { 
                    Console.WriteLine("enter food(less than 100 portions) and end to stop");
                    string input = Console.ReadLine();
                    if (input.Length > 1000)
                    {
                        Console.WriteLine("Too much symbols");
                        return;
                    }
                    string[] foods = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    if (foods.Length > 100)
                    {
                        Console.WriteLine("Too much food, Gendalf will burst");
                        return;
                    }
                    var foodFactory = new FoodFactory();
                    int totalHappiness = 0;
                        foreach (var food in foods)
                        {
                            try
                            {
                                var foodItem = FoodFactory.CreateFood(food); 
                                totalHappiness += foodItem.Happiness;
                            }
                            catch (ArgumentException ae)
                            {
                                Console.WriteLine(ae.Message);
                            }
                        }
                    MoodFactory moodFactory = new MoodFactory();
                    Mood mood = moodFactory.CreateMood(totalHappiness);
                    Console.WriteLine($"Total happiness: {totalHappiness}");
                    Console.WriteLine($"Mood:{mood}");
                }
                break;
            case 0:
                return;
            default:
                Console.WriteLine("Invalid task number");
                break;
        }
    }
}

