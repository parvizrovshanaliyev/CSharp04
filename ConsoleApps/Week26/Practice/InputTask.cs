namespace Practice;

/// <summary>
/// Task 2: Handles invalid user input using both logical check and try-catch.
/// </summary>
class InputTask
{
    /// <summary>
    /// Logical Implementation using int.TryParse to validate user input.
    /// </summary>
    public static void LogicalInput()
    {
        Console.Write("Enter a number: ");
        string input = Console.ReadLine();

        /*
         * TryParse checks whether the input string is a valid integer.
         * If valid, it parses and stores in number.
         * If invalid, it returns false and we show an error.
         */
        if (int.TryParse(input, out int number))
            Console.WriteLine($"You entered: {number}");
        else
            Console.WriteLine("Error: Invalid input. Please enter a valid integer.");
    }

    /// <summary>
    /// Try-catch Implementation to handle FormatException during input conversion.
    /// </summary>
    public static void TryCatchInput()
    {
        try
        {
            Console.Write("Enter a number: ");
            // May throw FormatException if input is not numeric
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine($"You entered: {number}");
        }
        catch (FormatException)
        {
            // Handle invalid format
            Console.WriteLine("Error: Invalid input. Please enter a valid integer.");
        }
    }
}