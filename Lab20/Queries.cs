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
    }
}
