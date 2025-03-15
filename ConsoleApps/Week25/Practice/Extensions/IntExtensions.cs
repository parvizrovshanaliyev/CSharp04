namespace Practice.Extensions;

/// <summary>
/// Provides extension methods for integer operations.
/// </summary>
public static class IntExtensions
{
    /// <summary>
    /// Determines whether an integer is even.
    /// Example:
    /// <code>
    /// int number = 4;
    /// bool isEven = number.IsEven(); // Returns true
    /// </code>
    /// </summary>
    public static bool IsEven(this int number) => number % 2 == 0;
}