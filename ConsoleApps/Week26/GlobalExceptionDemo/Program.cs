using System;
using System.IO;
using System.Threading;

namespace GlobalExceptionDemo
{
    class Program
    {
        // This is the path where we will write exception logs.
        // In a production application, this could be a log file, database, or external logging service.
        private static readonly string logFilePath = @"C:\Logs\ExceptionLog.txt";

        // This flag keeps track of whether any exception has occurred during the application lifecycle.
        // It helps us decide at the end whether the application ended successfully or not.
        private static bool hasException = false;

        static void Main(string[] args)
        {
            /*
             * Register a global exception handler that catches any unhandled exceptions.
             * This is useful in production environments where exceptions may escape try-catch blocks.
             * It helps log errors and gracefully shut down the application instead of crashing silently.
             */
            AppDomain.CurrentDomain.UnhandledException += GlobalExceptionHandler;

            try
            {
                // Inform the user that the application has started.
                Console.WriteLine("=== Application Started ===");

                /*
                 * Start running the core application logic.
                 * In a real-world scenario, this could be a background worker,
                 * scheduled task, message queue listener, or any business process.
                 */
                RunApplication();
            }
            catch (Exception ex)
            {
                /*
                 * This catch block is a secondary safety net.
                 * Even though the global handler exists, it's best practice to wrap your entry point in a try-catch block.
                 * If an exception occurs and is caught here, it is logged, and the app continues to close gracefully.
                 */
                hasException = true;
                LogException(ex, "Caught in Main()");
            }
            finally
            {
                /*
                 * The finally block always runs, regardless of whether an exception occurred.
                 * Here we inform the user how the application ended — either successfully or with an error.
                 */
                if (hasException)
                {
                    Console.WriteLine("Application ended with errors.");
                }
                else
                {
                    Console.WriteLine("=== Application Ended Normally ===");
                }
            }

            // This gives the user time to read any output before the console window closes.
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        /// <summary>
        /// Simulates the core logic of the application.
        /// In real scenarios, this might include network calls, file access, or business logic.
        /// </summary>
        static void RunApplication()
        {
            Console.WriteLine("Running application logic...");

            /*
             * Simulate some processing delay, e.g., fetching data, doing computations, etc.
             * Thread.Sleep is just used here for demonstration.
             */
            Thread.Sleep(1000);

            /*
             * We are intentionally throwing an unhandled exception to simulate a crash.
             * This mimics scenarios like null reference errors, API failures, etc.
             */
            ThrowUnhandledException();
        }

        /// <summary>
        /// Simulates an unexpected runtime error that is not caught locally.
        /// </summary>
        static void ThrowUnhandledException()
        {
            Console.WriteLine("Simulating an unexpected error...");

            /*
             * Throwing an InvalidOperationException to simulate an application failure.
             * This exception will bubble up and be caught by the global handler.
             */
            throw new InvalidOperationException("Unexpected failure in application logic.");
        }

        /// <summary>
        /// Handles any unhandled exceptions globally.
        /// This gets triggered if an exception is not caught anywhere in the application.
        /// </summary>
        static void GlobalExceptionHandler(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine("\n=== GLOBAL EXCEPTION HANDLER ===");

            /*
             * Check if the event's ExceptionObject is actually an Exception instance.
             * This is usually the case unless something very unusual happens.
             */
            if (e.ExceptionObject is Exception ex)
            {
                hasException = true; // Set the flag to indicate an exception occurred

                // Log the exception with a context message
                LogException(ex, "Global Exception Handler");

                // Inform the user in the console
                Console.WriteLine("A fatal error occurred. The application will now exit safely.");
            }
            else
            {
                // If for some reason the exception object is not an Exception, just show a generic error message
                Console.WriteLine("An unknown fatal error occurred.");
            }

            /*
             * Optional: Pause the application to allow the user to read the output.
             * In a headless service, this might not be necessary.
             */
            Console.ReadKey();
        }

        /// <summary>
        /// Logs the exception message and stack trace.
        /// Output goes both to the console and a log file on disk.
        /// </summary>
        static void LogException(Exception ex, string context)
        {
            /*
             * Build a detailed log message including timestamp, context (where it happened),
             * the exception message, and full stack trace.
             */
            string message = $"[{DateTime.Now}] {context}: {ex.Message}\n{ex.StackTrace}\n";

            // Print the log message to the console for immediate visibility
            Console.WriteLine(message);

            try
            {
                /*
                 * Ensure the log directory exists before trying to write the log file.
                 * If the directory is missing, create it.
                 */
                string dir = Path.GetDirectoryName(logFilePath);
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }

                /*
                 * Append the log message to the file.
                 * Using append ensures we don't overwrite previous logs.
                 */
                File.AppendAllText(logFilePath, message);
            }
            catch (Exception logEx)
            {
                /*
                 * If writing to the log file fails (e.g., due to file permissions),
                 * we inform the user in the console, but don't crash again.
                 */
                Console.WriteLine($"Failed to write to log file: {logEx.Message}");
            }
        }
    }
}
