using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_BillsPaymentSystem.Data.Models
{
    public class CreditCard
    {
        public int CreditCardId { get; set; }
        public decimal Limit { get; set; }
        public decimal MoneyOwed { get; set; }
        public decimal LimitLeft => Limit - MoneyOwed;
        public DateTime ExpirationDate { get; set; }
       public PaymentMethod PaymentMethod { get; set; } = null!;
        public void Deposit(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Amount must be positive.");
            }
            MoneyOwed -= amount;
            if (MoneyOwed < 0) MoneyOwed = 0; 
        }

        public bool Withdraw(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Amount must be positive.");
            }

            if (LimitLeft >= amount)
            {
                MoneyOwed += amount;
                return true;
            }

            return false; 
        }

        public void SetLimit(decimal limit)
        {
            Limit = limit;
        }

        public void SetMoneyOwed(decimal moneyOwed)
        {
            MoneyOwed = moneyOwed;
        }
    }
}
