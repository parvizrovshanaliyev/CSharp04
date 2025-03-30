namespace Practice;

/// <summary>
/// Task 1: Handles division by zero using both logical check and try-catch.
/// </summary>
class DivisionTask
{
    /// <summary>
    /// Logical Implementation of division by zero prevention.
    /// </summary>
    public static void LogicalDivision()
    {
        // Prompt user for input
        Console.Write("Enter numerator: ");
        int numerator = int.Parse(Console.ReadLine());
        Console.Write("Enter denominator: ");
        int denominator = int.Parse(Console.ReadLine());

        /*
         * Check if the denominator is zero before division.
         * If zero, display an error message.
         * Otherwise, perform division and display result.
         */
        if (denominator == 0)
            Console.WriteLine("Error: Division by zero is not allowed.");
        else
            Console.WriteLine($"Result: {numerator / denominator}");
    }

    /// <summary>
    /// Try-catch Implementation to handle DivideByZeroException.
    /// </summary>
    public static void TryCatchDivision()
    {
        try
        {
            // Prompt user for input
            Console.Write("Enter numerator: ");
            int numerator = int.Parse(Console.ReadLine());
            Console.Write("Enter denominator: ");
            int denominator = int.Parse(Console.ReadLine());

            // Perform division that may throw exception
            Console.WriteLine($"Result: {numerator / denominator}");
        }
        catch (DivideByZeroException)
        {
            // Handle divide by zero error gracefully
            Console.WriteLine("Error: Division by zero is not allowed.");
        }
    }
}