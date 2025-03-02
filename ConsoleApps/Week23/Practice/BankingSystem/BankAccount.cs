using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.BankingSystem;

/// <summary>
/// Core account details such as Account Number, Holder, and Balance.
/// </summary>
public partial class BankAccount
{
    /// <summary>
    /// Gets or sets the account number of the bank account.
    /// </summary>
    public string AccountNumber { get; set; }

    /// <summary>
    /// Gets or sets the account holder's name.
    /// </summary>
    public string AccountHolder { get; set; }

    /// <summary>
    /// Gets the current balance of the account.
    /// </summary>
    public decimal Balance { get; private set; }
}