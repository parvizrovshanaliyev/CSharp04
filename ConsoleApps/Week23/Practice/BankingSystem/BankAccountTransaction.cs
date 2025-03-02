using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.BankingSystem;



/// <summary>
/// Represents a bank account with deposit and withdrawal functionalities.
/// </summary>
public partial class BankAccount
{
    private readonly TransactionLog _transactionLog = new TransactionLog();

    /// <summary>
    /// Deposits a specified amount into the bank account.
    /// </summary>
    /// <param name="amount">The amount to deposit. Must be greater than zero.</param>
    public void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Invalid deposit amount.");
            return;
        }
        Balance += amount;
        _transactionLog.AddTransaction(amount);
        Console.WriteLine($"Deposited: ${amount:F2}, New Balance: ${Balance:F2}");
        TransactionNotification("Deposit", amount);
    }

    /// <summary>
    /// Withdraws a specified amount from the bank account.
    /// </summary>
    /// <param name="amount">The amount to withdraw. Must be greater than zero and not exceed the balance.</param>
    public void Withdraw(decimal amount)
    {
        if (amount <= 0 || amount > Balance)
        {
            Console.WriteLine("Invalid or insufficient funds.");
            return;
        }
        Balance -= amount;
        _transactionLog.AddTransaction(-amount);
        Console.WriteLine($"Withdrawn: ${amount:F2}, New Balance: ${Balance:F2}");
        TransactionNotification("Withdrawal", amount);
    }

    /// <summary>
    /// Displays the transaction history of the bank account.
    /// </summary>
    public void DisplayTransactionHistory()
    {
        _transactionLog.DisplayTransactions();
    }

    /// <summary>
    /// Partial method for transaction notifications.
    /// </summary>
    /// <param name="type">The type of transaction (Deposit or Withdrawal).</param>
    /// <param name="amount">The amount involved in the transaction.</param>
    partial void TransactionNotification(string type, decimal amount);
}
