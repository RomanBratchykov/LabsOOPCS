using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace P01_BillsPaymentSystem.Data.Models
{
    public class BankAccount
    {
        public int BankAccountId { get; set; }
        public decimal Balance { get; set; }
        public string BankName { get; set; } = string.Empty;
        public string SWIFTCode { get; set; } = string.Empty;
        public PaymentMethod PaymentMethod { get; set; } = null!;
        public void Deposit(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Amount must be positive.");
            }

            Balance += amount;
        }

        public bool Withdraw(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Amount must be positive.");
            }

            if (Balance >= amount)
            {
                Balance -= amount;
                return true;
            }

            return false; 
        }

        public void SetBalance(decimal balance)
        {
            Balance = balance;
        }
    }
}

