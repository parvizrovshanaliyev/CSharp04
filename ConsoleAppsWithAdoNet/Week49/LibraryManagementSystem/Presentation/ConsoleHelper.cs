namespace LibraryManagementSystem.Presentation;

/// <summary>
/// Console UI helper methods - reduces code repetition and ensures valid input
/// </summary>
public static class ConsoleHelper
{
    #region Input Methods

    /// <summary>
    /// Reads an integer from console. Keeps asking until valid input is provided.
    /// </summary>
    public static int ReadInt(string prompt, int? defaultValue = null)
    {
        while (true)
        {
            Console.Write(defaultValue.HasValue ? $"{prompt}(default: {defaultValue}): " : prompt);
            var input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input) && defaultValue.HasValue)
                return defaultValue.Value;

            if (int.TryParse(input, out int result))
                return result;

            PrintError("Please enter a valid number.");
        }
    }

    /// <summary>
    /// Reads a positive integer (greater than 0) from console.
    /// </summary>
    public static int ReadPositiveInt(string prompt, int? defaultValue = null)
    {
        while (true)
        {
            var value = ReadInt(prompt, defaultValue);
            if (value > 0)
                return value;

            PrintError("Please enter a positive number (greater than 0).");
        }
    }

    /// <summary>
    /// Reads a required string from console. Cannot be empty.
    /// </summary>
    public static string ReadRequiredString(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            var input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input))
                return input.Trim();

            PrintError("This field is required. Please enter a value.");
        }
    }

    /// <summary>
    /// Reads an optional string from console. Returns default if empty.
    /// </summary>
    public static string ReadString(string prompt, string defaultValue = "")
    {
        Console.Write(prompt);
        var input = Console.ReadLine();
        return string.IsNullOrWhiteSpace(input) ? defaultValue : input.Trim();
    }

    /// <summary>
    /// Reads a string for update. Shows current value and keeps it if input is empty.
    /// </summary>
    public static string ReadStringOrKeep(string prompt, string currentValue)
    {
        Console.Write($"{prompt} [{currentValue}]: ");
        var input = Console.ReadLine();
        return string.IsNullOrWhiteSpace(input) ? currentValue : input.Trim();
    }

    /// <summary>
    /// Reads a valid email address from console.
    /// </summary>
    public static string ReadEmail(string prompt, bool required = true)
    {
        while (true)
        {
            Console.Write(prompt);
            var input = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(input))
            {
                if (!required) return "";
                PrintError("Email is required.");
                continue;
            }

            if (input.Contains("@") && input.Contains("."))
                return input;

            PrintError("Please enter a valid email address (example@domain.com).");
        }
    }

    /// <summary>
    /// Reads a year from console (validates range 1800-current year).
    /// </summary>
    public static int ReadYear(string prompt)
    {
        var currentYear = DateTime.Now.Year;
        while (true)
        {
            var year = ReadInt(prompt);
            if (year >= 1800 && year <= currentYear)
                return year;

            PrintError($"Please enter a valid year (1800-{currentYear}).");
        }
    }

    /// <summary>
    /// Asks user for confirmation (Y/N).
    /// </summary>
    public static bool Confirm(string message)
    {
        Console.Write($"{message} (Y/N): ");
        var input = Console.ReadLine()?.Trim().ToUpper();
        return input == "Y" || input == "YES";
    }

    #endregion

    #region Output Methods

    public static void PrintSuccess(string message) => Console.WriteLine($" [SUCCESS] {message}");
    public static void PrintError(string message) => Console.WriteLine($" [ERROR] {message}");
    public static void PrintWarning(string message) => Console.WriteLine($" [WARNING] {message}");
    public static void PrintInfo(string message) => Console.WriteLine($" [INFO] {message}");

    public static void PrintList<T>(IEnumerable<T> items, string title, string emoji = "📋")
    {
        var list = items.ToList();
        Console.WriteLine($"\n{emoji} {title} ({list.Count}):");
        if (list.Count == 0)
            Console.WriteLine("  No records found.");
        else
            list.ForEach(item => Console.WriteLine($"  {item}"));
    }

    public static void PrintItem<T>(T? item, string notFoundMessage = "Not found.") where T : class
    {
        Console.WriteLine(item != null ? $"\n{item}" : $"ℹ️ [INFO] {notFoundMessage}");
    }

    #endregion

    #region Result Methods

    public static void PrintResult(bool success, string successMsg, string errorMsg)
    {
        if (success)
            PrintSuccess(successMsg);
        else
            PrintError(errorMsg);
    }

    public static void PrintAddResult(int id, string entityName)
    {
        PrintSuccess($"{entityName} added with ID: {id}");
    }

    #endregion
}
