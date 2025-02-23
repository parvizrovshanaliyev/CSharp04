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
