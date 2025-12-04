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
            command.ToLower();
            var books = context.Books.AsQueryable();
            var result = new StringBuilder();
            if (Enum.TryParse<BookShop.Models.AgeRestriction>(command, true, out var ageRestriction))
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
                .Substring(0, 1)
                .ToUpper()
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
                    result += $"{book.Title} - {book.EditionType} - ${book.Price}";
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
            var authors = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .OrderBy(a => a.FirstName)
                .ThenBy(a => a.LastName);
            foreach (var author in authors)
            {
                result += $"{author.FirstName} {author.LastName}" + Environment.NewLine;
            }
            return result;
        }
    }
}
