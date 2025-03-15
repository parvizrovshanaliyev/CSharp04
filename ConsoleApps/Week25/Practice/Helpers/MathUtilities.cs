namespace Practice.Helpers;

/// <summary>
/// Provides utility methods for basic mathematical operations.
/// </summary>
public static class MathUtilities
{
    /// <summary>
    /// Returns the square of a given number.
    /// Example:
    /// <code>
    /// MathUtilities.Square(4) // Returns 16
    /// </code>
    /// </summary>
    public static int Square(int number) => number * number;

    /// <summary>
    /// Returns the cube of a given number.
    /// Example:
    /// <code>
    /// MathUtilities.Cube(3) // Returns 27
    /// </code>
    /// </summary>
    public static int Cube(int number) => number * number * number;

    /// <summary>
    /// Computes the factorial of a given number.
    /// Example:
    /// <code>
    /// MathUtilities.Factorial(5) // Returns 120
    /// </code>
    /// </summary>
    public static int Factorial(int number)
    {
        if (number < 0) throw new ArgumentException("Number must be non-negative.");
        return number == 0 ? 1 : number * Factorial(number - 1);
    }
}