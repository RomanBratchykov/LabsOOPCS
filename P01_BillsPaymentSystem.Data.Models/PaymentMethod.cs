using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_BillsPaymentSystem.Data.Models
{
    internal enum PaymentType
    {
        BankAccount = 1,
        CreditCard = 2
    }

    internal class PaymentMethod
    {
        public int Id { get; set; }
        public PaymentType Type { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public int? BankAccountId { get; set; }
        public BankAccount? BankAccount { get; set; }
        public int? CreditCardId { get; set; }
        public CreditCard? CreditCard { get; set; }
    }
}
