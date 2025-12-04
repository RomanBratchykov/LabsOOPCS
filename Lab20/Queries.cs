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
    }
}
