using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.CalculatorApp;

/// <summary>
/// Provides advanced arithmetic operations.
/// </summary>
public partial class Calculator
{
    public double Multiply(double a, double b) => a * b;
    public double Divide(double a, double b)
    {
        if (b == 0)
        {
            Console.WriteLine("Error: Division by zero.");
            return double.NaN;
        }
        return a / b;
    }
}
