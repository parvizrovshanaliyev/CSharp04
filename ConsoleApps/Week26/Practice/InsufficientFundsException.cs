namespace Practice;

/// <summary>
/// Custom exception thrown when withdrawal violates minimum balance rules.
/// </summary>
class InsufficientFundsException : Exception
{
    public InsufficientFundsException(string message) : base(message) { }
}