using System;
using System.Transactions;

namespace Lab_6;

public class Lab_6
{
    public static void Main()
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
}

