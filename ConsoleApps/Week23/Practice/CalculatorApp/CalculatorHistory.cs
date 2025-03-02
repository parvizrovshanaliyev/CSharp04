namespace Practice.CalculatorApp;

/// <summary>
/// Represents a calculator that maintains a history of calculations.
/// </summary>
public partial class Calculator
{
    /// <summary>
    /// Stores the history of calculations, with a maximum capacity of 10 entries.
    /// </summary>
    private readonly string[] _history = new string[10];

    /// <summary>
    /// Keeps track of the number of stored calculations.
    /// </summary>
    private int historyCount = 0;

    /// <summary>
    /// Logs a calculation operation and its result in the history.
    /// </summary>
    /// <param name="operation">The mathematical operation performed (e.g., "5 + 3").</param>
    /// <param name="result">The result of the operation.</param>
    public void LogHistory(string operation, double result)
    {
        // Check if there is room in the history array
        if (historyCount < _history.Length)
        {
            // Store the operation and its result as a string
            _history[historyCount++] = $"{operation} = {result}";
        }
        else
        {
            Console.WriteLine("Calculation history is full. Consider clearing the history.");
        }
    }

    /// <summary>
    /// Displays all stored calculations from the history.
    /// </summary>
    public void DisplayHistory()
    {
        Console.WriteLine("Calculation History:");

        // Iterate through the stored history and display each entry
        for (int i = 0; i < historyCount; i++)
        {
            Console.WriteLine($" - {_history[i]}");
        }

        // If history is empty, notify the user
        if (historyCount == 0)
        {
            Console.WriteLine("No calculations recorded.");
        }
    }
}