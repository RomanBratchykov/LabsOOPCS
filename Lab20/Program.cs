using System;
using BookShop.Data;
using Microsoft.EntityFrameworkCore;

namespace BookShop.StartUp;

public class Program
{
    public static void Main(string[] args)
    {
        using var dbContext = new BookStoreContext();
        dbContext.Database.Migrate();
        Console.WriteLine("Enter number of task (1 to get all info) 2-16, 0 to exit");
        var input = int.Parse(Console.ReadLine()!);
        switch (input)
        {
            case 0:
                return;
            case 1:
                {
                    var books = dbContext.Books.ToList();
                    Console.WriteLine("------------------------");
                    Console.WriteLine("Books");
                    Console.WriteLine("-----------------------");
                    foreach (var book in books)
                    {
                        Console.WriteLine($"{book.Title} - {book.AgeRestriction} - {book.EditionType} - {book.Price}");
                    }
                    Console.WriteLine("------------------------");
                    Console.WriteLine("Authors");
                    Console.WriteLine("-----------------------");
                    var authors = dbContext.Authors.ToList();
                    foreach (var author in authors)
                    {
                        Console.WriteLine($"{author.FirstName} {author.LastName}");
                    }
                    Console.WriteLine("------------------------");
                    Console.WriteLine("Categories");
                    Console.WriteLine("-----------------------");
                    var categories = dbContext.Categories.ToList();
                    foreach (var category in categories)
                    {
                        Console.WriteLine($"{category.Name}");
                    }
                    Console.WriteLine("------------------------");
                    Console.WriteLine("Book Categories");
                    Console.WriteLine("-----------------------");
                    var bookCategories = dbContext.BookCategory.ToList();
                    foreach (var bookCategory in bookCategories)
                    {
                        Console.WriteLine($"BookId: {bookCategory.BookId} - CategoryId: {bookCategory.CategoryId}");
                    }
                }
                break;
                case 2:
                {
                    try
                    {
                        Console.WriteLine("---------------");
                        Console.WriteLine("Task 2");
                        Console.WriteLine("---------------");
                        Console.WriteLine("Enter age restriction");
                        var command = Console.ReadLine()!;
                        var queries = new Queries();
                        var books = queries.GetBooksByAgeRestriction(dbContext, command);
                        Console.WriteLine(books);
                    }
                   catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                break;
            case 3:
                { 
                    Console.WriteLine("---------------");
                    Console.WriteLine("Task 3");
                    Console.WriteLine("---------------");
                    var queries = new Queries();
                    var result = queries.GetGoldenBooks(dbContext);
                    Console.WriteLine(result);
                    
                }
                break;
            case 4:
                {
                    Console.WriteLine("---------------");
                    Console.WriteLine("Task 4");
                    Console.WriteLine("---------------");
                    var queries = new Queries();
                    var result = queries.GetBooksByPrice(dbContext);
                    Console.WriteLine(result);
                }
                break;
            case 5:
                {
                    try
                    {
                        Console.WriteLine("---------------");
                        Console.WriteLine("Task 2");
                        Console.WriteLine("---------------");
                        Console.WriteLine("Enter year");
                        var year = int.Parse(Console.ReadLine()!);
                        var queries = new Queries();
                        var books = queries.GetBooksNotReleasedIn(dbContext, year);
                        Console.WriteLine(books);
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                break;
            case 6:
                {

                }
                break;
            case 7:
                break;
            case 8:
                break;
            case 9:
                break;
            case 10:
                break;
            case 11:
                break;
            case 12:
                break;
            case 13:
                break;
            case 14:
                break;
            case 15:
                break;
            case 16:
                break;
            default:
                Console.WriteLine("Invalid input.");
                break;

        }
    }
}   