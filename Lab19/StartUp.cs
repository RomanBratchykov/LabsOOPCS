using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using P01_BillsPaymentSystem.Data.Models;
using P01_BillsPaymentSystem.Data;
using P01_BillsPaymentSystem.Data.EntityConfig;
namespace P01_BillsPaymentSystem
{
    public static class P01_BillsPaymentSystem
    {
        public static void Main()
        {
            using var context = new BillsPaymentSystemContext();

            var seeder = new Seeder.Seeder();
            seeder.Seed(context);

            Console.WriteLine("Enter Id of user:");
            if (int.TryParse(Console.ReadLine(), out int userId))
            {
                UserDetails(context, userId);

                Console.WriteLine("\nTry to pay your bill with 1200? Y/N");
                if (Console.ReadLine()?.ToUpper() == "Y")
                {
                    PayBills(context, userId, 1200.00m);
                    UserDetails(context, userId);
                }
            }
        }

        private static void UserDetails(BillsPaymentSystemContext context, int userId)
        {
            var user = context.Users
                .Where(u => u.UserId == userId)
                .Include(u => u.PaymentMethods)
                    .ThenInclude(pm => pm.BankAccount)
                .Include(u => u.PaymentMethods)
                    .ThenInclude(pm => pm.CreditCard)
                .FirstOrDefault();

            if (user == null)
            {
                Console.WriteLine($"User with id {userId} not found!");
                return;
            }

            Console.WriteLine($"\nUser: {user.FirstName} {user.LastName}");

            Console.WriteLine("Bank Accounts:");
            var bankAccounts = user.PaymentMethods
                .Where(pm => pm.Type == PaymentType.BankAccount && pm.BankAccount != null)
                .Select(pm => pm.BankAccount)
                .OrderBy(ba => ba.BankAccountId)
                .ToList();

            if (bankAccounts.Any())
            {
                foreach (var ba in bankAccounts)
                {
                    Console.WriteLine($"-- ID: {ba.BankAccountId}");
                    Console.WriteLine($"--- Balance: {ba.Balance:F2}");
                    Console.WriteLine($"--- Bank: {ba.BankName}");
                    Console.WriteLine($"--- SWIFT: {ba.SWIFTCode}");
                }
            }
            else
            {
                Console.WriteLine("--- No bank accounts found.");
                return;
            }

            Console.WriteLine("Credit Cards:");
            var creditCards = user.PaymentMethods
                .Where(pm => pm.Type == PaymentType.CreditCard && pm.CreditCard != null)
                .Select(pm => pm.CreditCard)
                .OrderBy(cc => cc.CreditCardId)
                .ToList();

            if (creditCards.Any())
            {
                foreach (var cc in creditCards)
                {
                    Console.WriteLine($"-- ID: {cc.CreditCardId}");
                    Console.WriteLine($"--- Limit: {cc.Limit:F2}");
                    Console.WriteLine($"--- Money Owed: {cc.MoneyOwed:F2}");
                    Console.WriteLine($"--- Limit Left: {cc.LimitLeft:F2}");
                    Console.WriteLine($"--- Expiration Date: {cc.ExpirationDate.ToString("yyyy/MM")}");
                }
            }
            else
            {
                Console.WriteLine("--- No credit cards found.");
            }
        }

        private static void PayBills(BillsPaymentSystemContext context, int userId, decimal amount)
        {
            var user = context.Users
                .Where(u => u.UserId == userId)
                .Include(u => u.PaymentMethods)
                    .ThenInclude(pm => pm.BankAccount)
                .Include(u => u.PaymentMethods)
                    .ThenInclude(pm => pm.CreditCard)
                .FirstOrDefault();

            if (user == null)
            {
                Console.WriteLine($"User with id {userId} not found!");
                return;
            }

            var totalAvailableAmount = user.PaymentMethods
                .Sum(pm => pm.BankAccount?.Balance ?? 0m) +
                user.PaymentMethods
                .Sum(pm => pm.CreditCard?.LimitLeft ?? 0m);

            if (totalAvailableAmount < amount)
            {
                Console.WriteLine("Not enought !");
                return;
            }

            var orderedPaymentMethods = user.PaymentMethods
                .OrderBy(pm => pm.Type)
                .ThenBy(pm => pm.Id)
                .ToList();

            decimal remainingAmount = amount;

            foreach (var pm in orderedPaymentMethods)
            {
                if (remainingAmount <= 0) break;

                if (pm.Type == PaymentType.BankAccount)
                {
                    var ba = pm.BankAccount;
                    if (ba != null)
                    {
                        decimal amountToWithdraw = Math.Min(remainingAmount, ba.Balance);

                        if (ba.Withdraw(amountToWithdraw))
                        {
                            remainingAmount -= amountToWithdraw;
                        }
                    }
                }
                else if (pm.Type == PaymentType.CreditCard)
                {
                    var cc = pm.CreditCard;
                    if (cc != null)
                    {
                        decimal amountToWithdraw = Math.Min(remainingAmount, cc.LimitLeft);

                        if (cc.Withdraw(amountToWithdraw))
                        {
                            remainingAmount -= amountToWithdraw;
                        }
                    }
                }
            }

            context.SaveChanges();

            if (remainingAmount == 0)
            {
                Console.WriteLine($"Bill at the price {amount:F2} successfully paid!");
            }
            else
            {
                Console.WriteLine("Error, you can't pay with this method");
            }
        }
    }
}
