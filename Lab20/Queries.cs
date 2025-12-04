using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Data
{
    internal class Queries
    {
        internal string GetBooksByAgeRestriction(BookStoreContext context, string command)
        {
            var comm = command.ToLower();
            var books = context.Books.AsQueryable();
            var result = new StringBuilder();
            if (Enum.TryParse<BookShop.Models.AgeRestriction>(comm, true, out var ageRestriction))
            {
                books = books.Where(b => b.AgeRestriction == ageRestriction).OrderBy(b => b.Title);
                foreach (var book in books)
                {
                    result.AppendLine(book.Title); result.AppendLine("\n");
                }
            }
            else
            {
                throw new ArgumentException("Invalid age restriction command.");
            }
            return result.ToString().TrimEnd();
        }
        internal string GetGoldenBooks(BookStoreContext context)
        {
            string result = string.Empty;
            var books = context.Books.Where(b => b.EditionType == Models.EditionType.gold && b.Copies < 5000).OrderBy(b => b.BookId);
            foreach (var book in books)
            {
                result += book.Title + Environment.NewLine;
            }
            return result;
        }
        internal string GetBooksByPrice(BookStoreContext context)
        {
            string result = string.Empty;
            var books = context.Books.Where(b => b.Price > 40).OrderByDescending(b => b.Price);
            foreach (var book in books)
            {
                result += book.Title + " " + book.Price + Environment.NewLine;
            }

            return result;
        }
        internal string GetBooksNotReleasedIn(BookStoreContext context, int year)
        {
            string result = string.Empty;
            if (year < 0 && year > 2025)
            {
                throw new ArgumentException("Year can`t be that value");
            }
            var books = context.Books.Where(b => b.ReleaseDate.Year != year).OrderBy(b => b.BookId);
            foreach (var book in books)
            {
                result += book.Title + Environment.NewLine;
            }
            return result;
        }
        internal string GetBooksByCategory(BookStoreContext context, string input)
        {
            var categories = input
                .ToLower()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(c => c.Trim())
                .ToArray();

            var books = context.Books
                .Where(b => b.BookCategory
                    .Any(bc => categories.Contains(bc.Category.Name.ToLower())))
                .OrderBy(b => b.Title);

            var result = new StringBuilder();
            foreach (var book in books)
            {
                result.AppendLine(book.Title);
            }
            return result.ToString().TrimEnd();
        }
        internal string GetBooksReleasedBefore(BookStoreContext BookShopContext, string date1)
        {
            string result = string.Empty;

            if (DateTime.TryParseExact(date1, "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out var dt1))
            {
                var books = BookShopContext.Books
                    .Where(b => b.ReleaseDate < dt1)
                    .OrderByDescending(b => b.ReleaseDate);

                foreach (var book in books)
                {
                    result += $"{book.Title} - {book.EditionType} - ${book.Price}\n";
                }
            }
            else
            {
                throw new ArgumentException("Invalid date format. Please use dd-MM-yyyy.");
            }

            return result;
        }
        internal string GetAuthorNamesEndingIn(BookStoreContext context, string input)
        {
            string result = string.Empty;
            var inputLower = input.ToLower();
            var authors = context.Authors
                .Where(a => a.FirstName.EndsWith(inputLower))
                .OrderBy(a => a.FirstName)
                .ThenBy(a => a.LastName);
            foreach (var author in authors)
            {
                result += $"{author.FirstName} {author.LastName}" + Environment.NewLine;
            }
            return result;
        }
        internal string GetBookTitlesContaining(BookStoreContext context, string input)
        {
            var inp= input.ToLower();
            string result = string.Empty;
            var books = context.Books.Where(b => b.Title.ToLower().Contains(inp)).OrderBy(b => b.Title);
            if (books is null)
            {
                Console.WriteLine("No books found for the given author last name prefix.");
                return result;
            }
            foreach (var book in books)
            {
                result += book.Title + Environment.NewLine;
            }
            return result;
        }
        internal string GetBooksByAuthor(BookStoreContext context, string input)
        {
            string searchInput = input.ToLower();
            string result = string.Empty;
            var books = context.Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(searchInput))
                .OrderBy(b => b.BookId);
            if (books.Any())
            {
                Console.WriteLine("No books found for the given author last name prefix.");
                return result;
            }
            foreach (var book in books)
            {
                result += $"{book.Title} ({book.Author.FirstName} {book.Author.LastName}\n)";
            }
            return result;
        }
        internal int CountBooks(BookStoreContext context, int lengthCheck)
        {
            var booksCount = context.Books
                .Where(b => b.Title.Length > lengthCheck)
                .Count();
            return booksCount;
        }
        internal Dictionary<string, int> CountCopiesByAuthor(BookStoreContext context)
        {
            var books = context.Books.GroupBy(b => new { b.AuthorId, b.Author.FirstName, b.Author.LastName })
                .Select(g => new
                {
                    AuthorFullName = g.Key.FirstName + " " + g.Key.LastName,
                    TotalCopies = g.Sum(b => b.Copies)
                })
                .OrderByDescending(a => a.TotalCopies)
                .ToDictionary(a => a.AuthorFullName, a => a.TotalCopies);
            return books;
        }
        internal Dictionary<string, decimal> GetTotalProfitByCategory(BookStoreContext context)
        {
            var books = context.Categories
                .Select(c => new
                {
                    CategoryName = c.Name,
                    TotalProfit = c.BookCategories
                        .Sum(bc => bc.Book.Price * bc.Book.Copies)
                })
                .OrderBy(c => c.TotalProfit)
                .ToDictionary(c => c.CategoryName, c => c.TotalProfit);
            return books;
        }
       public static string GetMostRecentBooks(BookStoreContext context)
        {
            var categoriesInfo = context.Categories
                .Include(c => c.BookCategories)
                    .ThenInclude(bc => bc.Book)

                .Select(c => new
                {
                    CategoryName = c.Name,
                    TotalBooksCount = c.BookCategories.Count(),
                    RecentBooks = c.BookCategories
                        .Select(bc => bc.Book)
                        .OrderByDescending(b => b.ReleaseDate)
                        .Take(3)
                        .Select(b => new
                        {
                            b.Title,
                            ReleaseYear = b.ReleaseDate.Year
                        })
                        .ToList()
                })
                .OrderByDescending(c => c.TotalBooksCount)
                .ToList();

            StringBuilder output = new StringBuilder();

            foreach (var category in categoriesInfo)
            {
                if (category.RecentBooks.Any())
                {
                    output.AppendLine($"--{category.CategoryName}");

                    foreach (var book in category.RecentBooks)
                    {
                        output.AppendLine($"{book.Title} ({book.ReleaseYear})");
                    }
                }
            }

            return output.ToString().TrimEnd();
        }
        internal void IncreasePrices(BookStoreContext context)
        {
            int year = 2010;
            decimal increaseAmount = 5m;
            var booksToUpdate = context.Books
                .Where(b => b.ReleaseDate.Year < year)
                .ToList();
            foreach (var book in booksToUpdate)
                {
                book.Price += increaseAmount;
            }
            context.SaveChanges();
            Console.WriteLine("Prices updated successfully.");
        }
        internal int RemoveBooks(BookStoreContext context)
        {
            int copiesThreshold = 4200;
            var booksToRemove = context.Books
                .Where(b => b.Copies < copiesThreshold)
                .ToList();
            int removedBooksCount = booksToRemove.Count;
            context.Books.RemoveRange(booksToRemove);
            context.SaveChanges();
            return removedBooksCount;
        }
    }
}
