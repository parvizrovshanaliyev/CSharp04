using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.BankingSystem;

/// <summary>
/// Transaction methods for deposit and withdrawal.
/// </summary>
public partial class BankAccount
{
    private decimal[] transactions = new decimal[100];
    private int transactionCount = 0;

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Invalid deposit amount.");
            return;
        }
        Balance += amount;
        LogTransaction(amount);
        Console.WriteLine($"Deposited: ${amount:F2}, New Balance: ${Balance:F2}");
        TransactionNotification("Deposit", amount);
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= 0 || amount > Balance)
        {
            Console.WriteLine("Invalid or insufficient funds.");
            return;
        }
        Balance -= amount;
        LogTransaction(-amount);
        Console.WriteLine($"Withdrawn: ${amount:F2}, New Balance: ${Balance:F2}");
        TransactionNotification("Withdrawal", amount);
    }

    private void LogTransaction(decimal amount)
    {
        if (transactionCount < transactions.Length)
            transactions[transactionCount++] = amount;
    }

    public void DisplayTransactionHistory()
    {
        Console.WriteLine("Transaction History:");
        for (int i = 0; i < transactionCount; i++)
        {
            Console.WriteLine($" - {(transactions[i] > 0 ? "Deposit" : "Withdrawal")}: ${Math.Abs(transactions[i]):F2}");
        }
    }

    /// <summary>
    /// Partial method for transaction notifications.
    /// </summary>
    partial void TransactionNotification(string type, decimal amount);
}
