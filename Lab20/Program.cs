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
                        Console.WriteLine("Task 5");
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
                    try
                    {
                        Console.WriteLine("---------------");
                        Console.WriteLine("Task 6");
                        Console.WriteLine("---------------");
                        Console.WriteLine("Enter categories with spacing");
                        var categories = Console.ReadLine()!;
                        var queries = new Queries();
                        var books = queries.GetBooksByCategory(dbContext, categories);
                        Console.WriteLine(books);
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                break;
            case 7:
                {
                    try
                    {
                        Console.WriteLine("---------------");
                        Console.WriteLine("Task 7");
                        Console.WriteLine("---------------");
                        Console.WriteLine("Enter year format dd-mm-YYYY");
                        var date = Console.ReadLine()!;
                        var queries = new Queries();
                        var books = queries.GetBooksReleasedBefore(dbContext, date);
                        Console.WriteLine(books);
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                break;
            case 8:
                {
                    try
                    {
                        Console.WriteLine("---------------");
                        Console.WriteLine("Task 8");
                        Console.WriteLine("---------------");
                        Console.WriteLine("Enter last letter of author name");
                        var lastLetters = Console.ReadLine()!;
                        var queries = new Queries();
                        var books = queries.GetAuthorNamesEndingIn(dbContext, lastLetters);
                        Console.WriteLine(books);
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                break;
            case 9:
                try
                {
                    Console.WriteLine("---------------");
                    Console.WriteLine("Task 9");
                    Console.WriteLine("---------------");
                    Console.WriteLine("Enter letters which should be in book title");
                    var lastLetters = Console.ReadLine()!;
                    var queries = new Queries();
                    var books = queries.GetBookTitlesContaining(dbContext, lastLetters);
                    Console.WriteLine(books);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                break;
            case 10:
                try
                {
                    Console.WriteLine("---------------");
                    Console.WriteLine("Task 10");
                    Console.WriteLine("---------------");
                    Console.WriteLine("Enter first letters of author");
                    var lastLetters = Console.ReadLine()!;
                    var queries = new Queries();
                    var books = queries.GetBooksByAuthor(dbContext, lastLetters);
                    Console.WriteLine(books);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                break;
            case 11:
                {
                    Console.WriteLine("---------------");
                    Console.WriteLine("Task 11");
                    Console.WriteLine("---------------");
                    Console.WriteLine("Enter length of title");
                    var lengthCheck = int.Parse(Console.ReadLine()!);
                    var queries = new Queries();
                    var books = queries.CountBooks(dbContext, lengthCheck);
                    Console.WriteLine(books);
                }
                break;
            case 12:
                {
                    Console.WriteLine("---------------");
                    Console.WriteLine("Task 12");
                    Console.WriteLine("---------------");
                    var queries = new Queries();
                    var books = queries.CountCopiesByAuthor(dbContext);
                    foreach (var book in books)
                    {
                        Console.WriteLine($"{book.Key} - {book.Value}");
                    }
                }
                break;
            case 13:
                {
                    Console.WriteLine("---------------");
                    Console.WriteLine("Task 13");
                    Console.WriteLine("---------------");
                    var queries = new Queries();
                    var books = queries.GetTotalProfitByCategory(dbContext);
                    foreach (var book in books)
                    {
                        Console.WriteLine($"{book.Key} - {book.Value:F2}");
                    }
                }
                break;
            case 14:
                {
                    Console.WriteLine("---------------");
                    Console.WriteLine("Task 14");
                    Console.WriteLine("---------------");
                    var result = Queries.GetMostRecentBooks(dbContext);
                    Console.WriteLine(result);
                }
                break;
            case 15:
                {
                    Console.WriteLine("---------------");
                    Console.WriteLine("Task 15");
                    Console.WriteLine("---------------");
                    var queries = new Queries();
                    queries.IncreasePrices(dbContext);
                }
                break;
            case 16:
                {

                }
                break;
            default:
                Console.WriteLine("Invalid input.");
                break;

        }
    }
}   