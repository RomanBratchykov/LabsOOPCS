using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5_cs_
{
    internal class Person
    {
        private string name;
        private decimal money;
        private List<Product> products;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                name = value;
            }
        }
        public decimal Money
        {
            get
            {
                return money;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                money = value;
            }
        }
        public List<Product> Products
        {
            get
            {
                return products;
            }
            set
            {
                products = value;
            }
        }
        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            Products = new List<Product>();
        }
        public void buyProduct(Product product)
        {
            if (Money >= product.Cost)
            {
                Money -= product.Cost;
                Products.Add(product);
                Console.WriteLine($"{Name} bought {product.Name}");
            }
            else
            {
                Console.WriteLine($"{Name} can't afford {product.Name}");
            }
        }
        public void showProducts()
        {
            if (Products == null || Products.Count == 0)
            {
                Console.WriteLine($"{Name} hasn`t bought anything");
            }
            else
            {
                Console.WriteLine($"{Name} - {string.Join(", ", Products.Select(p => p.Name))}");
            }
        }
    }
}
