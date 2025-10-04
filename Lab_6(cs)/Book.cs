using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Book
    {
        private string title;
        private string author;
        protected decimal price;
        public string Title
        {
            get { return title; }
            set
            {

                if (value.Length < 3)
                {
                    throw new ArgumentException("Title must be at least 3 characters long.");
                }
                title = value;
            }
        }
        public string Author
        {
            get { return author; }
            set
            {
                if (char.IsDigit(value[0]))
                {
                    throw new ArgumentException("Author name cannot start with a digit.");
                }
                author = value;
            }
        }
        public virtual decimal Price
        {
            get { return price; }
            set
            {
                if ( value <= 0)
                {
                    throw new ArgumentException("Prcie can't be negative or 0");
                }
                price = value;
            }
        }
        public Book(string title, string author, decimal price)
        {
            Title = title;
            Author = author;
            Price = price;
        }
        public void showBook()
        {
            Console.WriteLine($"{this.Author}, {this.Title}, {this.Price}");
        }
    }
}
