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
                    if (PayBills(context, userId, 1900.00m))
                    {
                        UserDetails(context, userId);
                    }
                    else
                    {
                      Console.WriteLine("Payment failed.");
                    }
                    
                }
                Console.WriteLine("\nTry to deposit money? Y/N");
                if (Console.ReadLine()?.ToUpper() == "Y")
                {
                    Console.WriteLine("Enter Payment Method ID to deposit to:");
                    if (int.TryParse(Console.ReadLine(), out int pmId))
                    {
                        Console.WriteLine("Enter amount to deposit (e.g., 500.00):");
                        if (decimal.TryParse(Console.ReadLine(), out decimal depositAmount))
                        {
                            if (DepositMoney(context, userId, pmId, depositAmount))
                            {
                                UserDetails(context, userId);
                            }
                        }
                    }
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

        private static bool PayBills(BillsPaymentSystemContext context, int userId, decimal amount)
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
                return false;
            }

            var totalAvailableAmount = user.PaymentMethods
     .Select(pm =>
         (pm.BankAccount?.Balance ??
          pm.CreditCard?.LimitLeft ??
          0m)
       ).Max();
            if (totalAvailableAmount < amount)
            {
                Console.WriteLine("Not enought !");
                return false;
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
            return true;
        }
        private static bool DepositMoney(BillsPaymentSystemContext context, int userId, int paymentMethodId, decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Deposit amount must be positive.");
                return false;
            }

            var paymentMethod = context.PaymentMethods
                .Where(pm => pm.Id == paymentMethodId && pm.UserId == userId)
                .Include(pm => pm.BankAccount)
                .Include(pm => pm.CreditCard)
                .FirstOrDefault();

            if (paymentMethod == null)
            {
                Console.WriteLine($"Payment method with ID {paymentMethodId} for user {userId} not found!");
                return false;
            }

            bool success = false;
            string type = "";

            if (paymentMethod.Type == PaymentType.BankAccount && paymentMethod.BankAccount != null)
            {
                paymentMethod.BankAccount.Deposit(amount);
                type = "Bank Account";
                success = true;
            }
            else if (paymentMethod.Type == PaymentType.CreditCard && paymentMethod.CreditCard != null)
            {
                paymentMethod.CreditCard.Deposit(amount);
                type = "Credit Card (Debt reduction)";
                success = true;
            }
            else
            {
                Console.WriteLine("Error: Payment method type is invalid or object is null.");
            }

            if (success)
            {
                context.SaveChanges();
                Console.WriteLine($"\nDeposit successful! {amount:F2} added to {type} (ID: {paymentMethodId}).");
                return true;
            }

            return false;
        }
    }
}
