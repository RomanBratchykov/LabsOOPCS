using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03_SalesDatabase.Data.Models
{
    internal class Product
    {
        public Product()
        {
            Sales = new HashSet<Sale>();
        }

        public int ProductId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; } 
        public decimal Price { get; set; }
        public string Description { get; set; }

        public ICollection<Sale> Sales { get; set; }
    }
}
