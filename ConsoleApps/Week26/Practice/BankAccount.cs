namespace Practice;

/// <summary>
/// Task 5: BankAccount class that implements deposit and withdrawal logic with exception handling.
/// </summary>
class BankAccount
{
    /// <summary>
    /// Gets the current account balance.
    /// </summary>
    public decimal Balance { get; private set; } = 100m;

    /// <summary>
    /// Deposits a specified amount into the account. Requires positive amount.
    /// </summary>
    public void Deposit(decimal amount)
    {
        /*
         * Validate that deposit is greater than zero.
         * If valid, add to balance. Otherwise, show error.
         */
        if (amount <= 0)
        {
            Console.WriteLine("Error: Deposit amount must be greater than zero.");
            return;
        }
        Balance += amount;
        Console.WriteLine($"Deposited: ${amount}, New Balance: ${Balance}");
    }

    /// <summary>
    /// Withdraws a specified amount from the account while maintaining minimum balance.
    /// </summary>
    public void Withdraw(decimal amount)
    {
        /*
         * Check if amount is positive and enough balance remains after withdrawal.
         * Maintain minimum balance of $10.
         */
        if (amount <= 0)
        {
            Console.WriteLine("Error: Withdrawal amount must be positive.");
            return;
        }
        if (Balance - amount < 10)
        {
            Console.WriteLine("Error: Insufficient funds. Minimum balance of $10 must be maintained.");
            return;
        }
        Balance -= amount;
        Console.WriteLine($"Withdrew: ${amount}, New Balance: ${Balance}");
    }

    /// <summary>
    /// Withdraws with exception handling for insufficient funds or invalid input.
    /// </summary>
    public void WithdrawWithException(decimal amount)
    {
        /*
         * Throws exceptions for invalid conditions.
         * Used in try-catch to demonstrate exception handling.
         */
        if (amount <= 0)
            throw new ArgumentException("Withdrawal amount must be positive.");

        if (Balance - amount < 10)
            throw new InsufficientFundsException("Insufficient funds. Minimum balance of $10 must be maintained.");

        Balance -= amount;
        Console.WriteLine($"Withdrew: ${amount}, New Balance: ${Balance}");
    }
}