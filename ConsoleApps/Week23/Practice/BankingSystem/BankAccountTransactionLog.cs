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
/// Handles transaction logging using an array.
/// </summary>
public class TransactionLog
{
    public class TransactionHistory
    {
        public decimal Amount { get; set; }
        public DateTime Time { get; set; }
    }

    private TransactionHistory[] _transactions;
    private int _transactionCount;

    public TransactionLog(int capacity)
    {
        _transactions = new TransactionHistory[capacity];
        _transactionCount = 0;
    }

    public void AddTransaction(decimal amount)
    {
        if (_transactionCount < _transactions.Length)
        {
            _transactions[_transactionCount] = new TransactionHistory { Amount = amount, Time = DateTime.Now };
            _transactionCount++;
        }
        else
        {
            Console.WriteLine("Transaction log is full.");
        }
    }

    public void DisplayTransactions()
    {
        Console.WriteLine("Transaction History:");
        for (int i = 0; i < _transactionCount; i++)
        {
            Console.WriteLine($" - {(_transactions[i].Amount > 0 ? "Deposit" : "Withdrawal")}: ${Math.Abs(_transactions[i].Amount):F2} at {_transactions[i].Time}");
        }
    }
}

