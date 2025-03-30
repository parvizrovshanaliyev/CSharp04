namespace Practice;

/// <summary>
/// Main program entry that runs all tasks with both logical and try-catch implementations.
/// </summary>
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("--- Task 1: Division ---");
        DivisionTask.LogicalDivision();
        DivisionTask.TryCatchDivision();

        Console.WriteLine("\n--- Task 2: Invalid Input ---");
        InputTask.LogicalInput();
        InputTask.TryCatchInput();

        Console.WriteLine("\n--- Task 3: Array Index ---");
        ArrayTask.LogicalArrayAccess();
        ArrayTask.TryCatchArrayAccess();

        Console.WriteLine("\n--- Task 4: Null Reference ---");
        NullReferenceTask.LogicalNullAccess();
        NullReferenceTask.TryCatchNullAccess();

        Console.WriteLine("\n--- Task 5: Bank Account ---");
        BankAccount account = new BankAccount();
        account.Deposit(50);
        account.Withdraw(30);

        try
        {
            account.WithdrawWithException(150);
        }
        catch (InsufficientFundsException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}