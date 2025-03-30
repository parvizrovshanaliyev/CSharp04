namespace Practice;

/// <summary>
/// Task 3: Handles array index out of bounds using both logical check and try-catch.
/// </summary>
class ArrayTask
{
    private static int[] numbers = { 1, 2, 3, 4, 5 };

    /// <summary>
    /// Logical Implementation to check if index is within array bounds.
    /// </summary>
    public static void LogicalArrayAccess()
    {
        Console.Write("Enter an index (0-4): ");
        int index = int.Parse(Console.ReadLine());

        /*
         * Validate if index is in range.
         * Prevents IndexOutOfRangeException by checking explicitly.
         */
        if (index >= 0 && index < numbers.Length)
            Console.WriteLine($"Element at index {index}: {numbers[index]}");
        else
            Console.WriteLine("Error: Index out of range. Please enter a valid index.");
    }

    /// <summary>
    /// Try-catch Implementation to catch IndexOutOfRangeException.
    /// </summary>
    public static void TryCatchArrayAccess()
    {
        try
        {
            Console.Write("Enter an index (0-4): ");
            int index = int.Parse(Console.ReadLine());

            // Direct access without validation - may throw exception
            Console.WriteLine($"Element at index {index}: {numbers[index]}");
        }
        catch (IndexOutOfRangeException)
        {
            // Handle out-of-bound access
            Console.WriteLine("Error: Index out of range. Please enter a valid index.");
        }
    }
}