using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.BankingSystem;

/// <summary>
/// Transaction logging and additional features.
/// </summary>
public partial class BankAccount
{
    partial void TransactionNotification(string type, decimal amount)
    {
        Console.WriteLine($"[Notification] {type} of ${amount:F2} processed successfully.");
    }
}


/// <summary>
/// Represents a transaction with amount and timestamp.
/// </summary>
public class TransactionHistory
{
    public decimal Amount { get; }
    public DateTime Time { get; }

    public TransactionHistory(decimal amount, DateTime time)
    {
        Amount = amount;
        Time = time;
    }
}

/// <summary>
/// Handles transaction logging.
/// </summary>
public class TransactionLog
{
    private readonly List<TransactionHistory> _transactions = new List<TransactionHistory>();

    public void AddTransaction(decimal amount)
    {
        _transactions.Add(new TransactionHistory(amount, DateTime.Now));
    }

    public void DisplayTransactions()
    {
        Console.WriteLine("Transaction History:");
        foreach (var transaction in _transactions)
        {
            Console.WriteLine($" - {(transaction.Amount > 0 ? "Deposit" : "Withdrawal")}: ${Math.Abs(transaction.Amount):F2} at {transaction.Time}");
        }
    }
}
