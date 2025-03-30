using System;

namespace GlobalExceptionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Register a global exception handler
            AppDomain.CurrentDomain.UnhandledException += GlobalExceptionHandler;

            try
            {
                Console.WriteLine("Application started.");

                // Call a method that throws an exception
                ThrowUnhandledException();

                Console.WriteLine("Application ended normally.");
            }
            catch (Exception ex)
            {
                // Optional: Catch any exception not already handled
                Console.WriteLine($"Caught in Main(): {ex.Message}");
            }
        }

        /// <summary>
        /// A method that simulates an unexpected exception.
        /// </summary>
        static void ThrowUnhandledException()
        {
            Console.WriteLine("Simulating an unexpected error...");
            throw new InvalidOperationException("Something went wrong!");
        }

        /// <summary>
        /// Handles all unhandled exceptions globally.
        /// </summary>
        static void GlobalExceptionHandler(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine("\n=== GLOBAL EXCEPTION HANDLER ===");
            Exception ex = (Exception)e.ExceptionObject;
            Console.WriteLine($"Unhandled Exception: {ex.Message}");
            Console.WriteLine("The application will now exit safely.");
        }
    }
}