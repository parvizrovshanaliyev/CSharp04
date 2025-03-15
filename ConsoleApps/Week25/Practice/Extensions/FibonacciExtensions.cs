namespace Practice.Extensions;

/// <summary>
/// Provides extension methods for Fibonacci sequence calculations.
/// </summary>
public static class FibonacciExtensions
{
    /// <summary>
    /// Returns the Nth Fibonacci number.
    /// Example:
    /// <code>
    /// int n = 5;
    /// int fib = n.NthFibonacci(); // Returns 5 (0, 1, 1, 2, 3, 5...)
    /// </code>
    /// </summary>
    public static int NthFibonacci(this int n)
    {
        if (n < 0) throw new ArgumentException("N must be a non-negative integer.");
        if (n == 0) return 0;
        if (n == 1) return 1;

        int a = 0, b = 1, temp;
        for (int i = 2; i <= n; i++)
        {
            temp = a + b;
            a = b;
            b = temp;
        }
        return b;
    }
}