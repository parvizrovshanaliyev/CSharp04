using System;

namespace ExceptionHandling;

internal class Program
{
    static void Main(string[] args)
    {
        /*
         * Exception Handling in C#
         * -----------------------
         * 1. try: Contains code that may throw an exception
         * 2. catch: Handles the exception if it occurs
         * 3. finally: Executes whether an exception occurs or not
         * 4. throw: Explicitly throws an exception
         */

        #region Example 1: Basic Exception Handling
        Console.WriteLine("Example 1: Basic Exception Handling");
        try
        {
            // Attempting to divide by zero
            int numerator = 10;
            int denominator = 0;
            int result = numerator / denominator;
        }
        catch (DivideByZeroException ex)
        {
            /*
             * Exception Properties:
             * - Message: Description of the error
             * - StackTrace: Call stack when exception occurred
             * - Source: Name of application/object that caused error
             * - HelpLink: Link to help file associated with exception
             */
            Console.WriteLine("\nDivide By Zero Exception:");
            Console.WriteLine($"Message: {ex.Message}");
            Console.WriteLine($"Source: {ex.Source}");
            Console.WriteLine($"StackTrace: {ex.StackTrace}");
        }
        #endregion

        #region Example 2: Multiple Catch Blocks
        Console.WriteLine("\nExample 2: Multiple Catch Blocks");
        try
        {
            // Attempting to parse invalid number
            string input = "abc";
            int number = int.Parse(input);
        }
        catch (FormatException ex)
        {
            Console.WriteLine($"Format Exception: {ex.Message}");
        }
        catch (OverflowException ex)
        {
            Console.WriteLine($"Overflow Exception: {ex.Message}");
        }
        catch (Exception ex) // General exception handler
        {
            Console.WriteLine($"General Exception: {ex.Message}");
        }
        #endregion

        #region Example 3: Finally Block
        Console.WriteLine("\nExample 3: Finally Block");
        try
        {
            // Simulating some process
            Console.WriteLine("Process started...");
            throw new ApplicationException("Simulated error");
        }
        catch (ApplicationException ex)
        {
            Console.WriteLine($"Error occurred: {ex.Message}");
        }
        finally
        {
            // This block always executes
            Console.WriteLine("Cleanup code in finally block");
        }
        #endregion

        #region Example 4: Custom Exception
        Console.WriteLine("\nExample 4: Custom Exception");
        try
        {
            ValidateAge(-5);
        }
        catch (InvalidAgeException ex)
        {
            Console.WriteLine($"Invalid Age Error: {ex.Message}");
            Console.WriteLine($"Attempted Age: {ex.AttemptedAge}");
        }
        #endregion

        #region Example 5: Exception Filters
        Console.WriteLine("\nExample 5: Exception Filters");
        try
        {
            throw new ArgumentException("Test exception with severity 1", "testParam")
            {
                Source = "Severity1"
            };
        }
        catch (ArgumentException ex) when (ex.Source == "Severity1")
        {
            Console.WriteLine("Caught exception with severity 1");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Caught general argument exception");
        }
        #endregion
    }

    /*
     * Custom Exception Class Example
     * ----------------------------
     * - Inherits from Exception
     * - Includes custom properties
     * - Implements multiple constructors
     */
    public class InvalidAgeException : Exception
    {
        public int AttemptedAge { get; }

        public InvalidAgeException() : base() { }

        public InvalidAgeException(string message)
            : base(message) { }

        public InvalidAgeException(string message, int attemptedAge)
            : base(message)
        {
            AttemptedAge = attemptedAge;
        }

        public InvalidAgeException(string message, Exception innerException)
            : base(message, innerException) { }
    }

    /*
     * Helper Method to Demonstrate Custom Exception
     * ------------------------------------------
     * Validates age and throws custom exception if invalid
     */
    private static void ValidateAge(int age)
    {
        if (age < 0)
        {
            throw new InvalidAgeException(
                "Age cannot be negative.",
                age
            );
        }
        Console.WriteLine($"Age {age} is valid.");
    }
}
