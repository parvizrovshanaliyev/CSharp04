using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.CalculatorApp;

/// <summary>
/// Handles calculation history.
/// </summary>
public partial class Calculator
{
    private string[] history = new string[10];
    private int historyCount = 0;

    public void LogHistory(string operation, double result)
    {
        if (historyCount < history.Length)
            history[historyCount++] = $"{operation} = {result}";
    }

    public void DisplayHistory()
    {
        Console.WriteLine("Calculation History:");
        for (int i = 0; i < historyCount; i++)
        {
            Console.WriteLine($" - {history[i]}");
        }
    }
}
