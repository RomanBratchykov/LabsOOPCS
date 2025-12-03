using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace P01_BillsPaymentSystem.Data.Models
{
    internal class BankAccount
    {
        public int BankAccountId { get; set; }
        public decimal Balance { get; set; }
        public string BankName { get; set; } = string.Empty;
        public string SWIFTCode { get; set; } = string.Empty;  

    }
}
