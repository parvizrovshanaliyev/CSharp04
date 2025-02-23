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
    public string AccountNumber { get; set; }
    public string AccountHolder { get; set; }
    public decimal Balance { get; private set; }
}