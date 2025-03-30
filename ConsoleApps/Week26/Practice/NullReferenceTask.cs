namespace Practice;

/// <summary>
/// Task 4: Handles null reference access using both logical check and try-catch.
/// </summary>
class NullReferenceTask
{
    /// <summary>
    /// Logical Implementation to check if the object is null before use.
    /// </summary>
    public static void LogicalNullAccess()
    {
        string str = null;

        /*
         * Check for null before accessing properties.
         * Prevents NullReferenceException by early check.
         */
        if (str == null)
            Console.WriteLine("Error: The object is null. Cannot access properties of a null object.");
        else
            Console.WriteLine($"Length: {str.Length}");
    }

    /// <summary>
    /// Try-catch Implementation to handle NullReferenceException.
    /// </summary>
    public static void TryCatchNullAccess()
    {
        try
        {
            string str = null;

            // Attempt to access property on a null object
            Console.WriteLine($"Length: {str.Length}");
        }
        catch (NullReferenceException)
        {
            // Handle null object access
            Console.WriteLine("Error: The object is null. Cannot access properties of a null object.");
        }
    }
}