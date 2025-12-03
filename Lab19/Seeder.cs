using P01_BillsPaymentSystem.Data;
using P01_BillsPaymentSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seeder
{
    public class Seeder
    {
        public void Seed(BillsPaymentSystemContext context)
        {
            context.Database.EnsureCreated();

            if (context.Users.Any())
            {
                return; 
            }

            var user = new User
            {
                FirstName = "Guy",
                LastName = "Gilbert",
                Email = "guy.gilbert@example.com",
                Password = "hashedpassword" 
            };

            var bankAccount1 = new BankAccount { BankName = "Unicredit Bulbank", SWIFTCode = "UNCRBGSF" };
            bankAccount1.SetBalance(2000.00m);

            var bankAccount2 = new BankAccount { BankName = "First Investment Bank", SWIFTCode = "FINVBGSF" };
            bankAccount2.SetBalance(1000.00m);

            var creditCard1 = new CreditCard { ExpirationDate = new DateTime(2025, 3, 1) };
            creditCard1.SetLimit(800.00m);
            creditCard1.SetMoneyOwed(100.00m);

            context.Users.Add(user);
            context.BankAccounts.AddRange(bankAccount1, bankAccount2);
            context.CreditCards.Add(creditCard1);
            context.SaveChanges();

            var paymentMethod1 = new PaymentMethod
            {
                User = user,
                Type = PaymentType.BankAccount,
                BankAccount = bankAccount1
            };

            var paymentMethod2 = new PaymentMethod
            {
                User = user,
                Type = PaymentType.BankAccount,
                BankAccount = bankAccount2
            };

            var paymentMethod3 = new PaymentMethod
            {
                User = user,
                Type = PaymentType.CreditCard,
                CreditCard = creditCard1
            };

            context.PaymentMethods.AddRange(paymentMethod1, paymentMethod2, paymentMethod3);
            context.SaveChanges();
        }
    }
}
