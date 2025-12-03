using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Models
{
    internal enum AgeRestriction
    {
        Minor = 0,
        Teen = 1,
        Adult = 2
    }
    internal enum EditionType
    {
        Normal = 0,
        Promo = 1,
        Gold = 2
    }
    internal class Book
    {
        public int BookId { get; set; }
        public AgeRestriction AgeRestriction { get; set; }


        public int AuthorId { get; set; }
        public Author Author { get; set; } = null!;
        public int Copies { get; set;}
        public string Description { get; set; } = null!;

        public EditionType EditionType { get; set; }
        public ICollection<BookCategory> BookCategory = new HashSet<BookCategory>();
        public decimal Price { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Title { get; set; } = null!;
    }
}
