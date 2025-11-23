using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03_SalesDatabase.Data.Models
{
    internal class Customer
    {
        public Customer()
        {
            Sales = new HashSet<Sale>();
        }

        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string CreditCardNumber { get; set; }

        public ICollection<Sale> Sales { get; set; }
    }
}
