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
    }
}   