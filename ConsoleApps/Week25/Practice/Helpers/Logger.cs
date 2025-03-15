namespace Practice.Helpers;

/// <summary>
/// Provides logging functionalities with timestamps.
/// </summary>
public static class Logger
{
    public static bool EnableLogging { get; set; } = true;

    /// <summary>
    /// Logs a normal message with a timestamp.
    /// Example:
    /// <code>
    /// Logger.Log("Application started");
    /// // Output: [2025-03-08 10:00:00] Application started
    /// </code>
    /// </summary>
    public static void Log(string message)
    {
        if (EnableLogging)
            Console.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}");
    }

    /// <summary>
    /// Logs an error message with a timestamp.
    /// Example:
    /// <code>
    /// Logger.Error("An error occurred");
    /// // Output: [2025-03-08 10:01:00] ERROR: An error occurred
    /// </code>
    /// </summary>
    public static void Error(string message)
    {
        if (EnableLogging)
            Console.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] ERROR: {message}");
    }
}