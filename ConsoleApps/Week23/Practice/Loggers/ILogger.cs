using System;
using System.IO;
using System.Text;

namespace Practice.Loggers;

/// <summary>
/// Interface defining logging functionalities.
/// This interface provides a contract for logging systems, ensuring a consistent structure for logging messages.
/// It allows multiple implementations such as console logging, file logging, and database logging.
/// </summary>
public interface ILogger
{
    void LogInfo(string message);
    void LogWarning(string message);
    void LogError(string message);
    string[] GetLatestLogs(int count);
}

/// <summary>
/// Logs messages to the console with color-coded log levels.
/// Implements the <see cref="ILogger"/> interface.
/// </summary>
public class ConsoleLogger : ILogger
{
    private readonly string[] logs = new string[100];
    private int logIndex = 0;

    public void LogInfo(string message) => LogMessage("INFO", message, ConsoleColor.Green);
    public void LogWarning(string message) => LogMessage("WARNING", message, ConsoleColor.Yellow);
    public void LogError(string message) => LogMessage("ERROR", message, ConsoleColor.Red);

    private void LogMessage(string level, string message, ConsoleColor color)
    {
        string log = $"[{level}] {DateTime.Now}: {message}";
        if (logIndex < logs.Length)
            logs[logIndex++] = log;
        Console.ForegroundColor = color;
        Console.WriteLine(log);
        Console.ResetColor();
    }

    public string[] GetLatestLogs(int count)
    {
        int startIndex = Math.Max(0, logIndex - count);
        return logs[startIndex..logIndex];
    }
}

/// <summary>
/// Logs messages to a file (simulated file reading).
/// Implements the <see cref="ILogger"/> interface.
/// </summary>
public class FileLogger : ILogger
{
    private readonly string filePath = "logs.txt";
    private readonly string[] logs = new string[100];
    private int logIndex = 0;

    public void LogInfo(string message) => LogToFile("INFO", message);
    public void LogWarning(string message) => LogToFile("WARNING", message);
    public void LogError(string message) => LogToFile("ERROR", message);

    private void LogToFile(string level, string message)
    {
        string log = $"[{level}] {DateTime.Now}: {message}";
        if (logIndex < logs.Length)
            logs[logIndex++] = log;
        Console.WriteLine("(Simulated) Writing to file: " + log);
    }

    public string[] GetLatestLogs(int count)
    {
        Console.WriteLine("(Simulated) Reading from file...");
        int startIndex = Math.Max(0, logIndex - count);
        return logs[startIndex..logIndex];
    }
}

/// <summary>
/// Logs messages to an in-memory database.
/// Implements the <see cref="ILogger"/> interface.
/// </summary>
public class DatabaseLogger : ILogger
{
    private readonly string[] logDatabase = new string[100];
    private int logIndex = 0;

    public void LogInfo(string message) => LogToDatabase("INFO", message);
    public void LogWarning(string message) => LogToDatabase("WARNING", message);
    public void LogError(string message) => LogToDatabase("ERROR", message);

    private void LogToDatabase(string level, string message)
    {
        string log = $"[{level}] {DateTime.Now}: {message}";
        if (logIndex < logDatabase.Length)
            logDatabase[logIndex++] = log;
    }

    public string[] GetLatestLogs(int count)
    {
        int startIndex = Math.Max(0, logIndex - count);
        return logDatabase[startIndex..logIndex];
    }
}
