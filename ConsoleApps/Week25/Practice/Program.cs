using Practice.Extensions;
using Practice.Helpers;

namespace Practice;

class Program
{
    static void Main()
    {
        // Task 1: Math Utilities
        Console.WriteLine("Math Utilities:");
        Console.WriteLine($"Square of 4: {MathUtilities.Square(4)}");
        Console.WriteLine($"Cube of 3: {MathUtilities.Cube(3)}");
        Console.WriteLine($"Factorial of 5: {MathUtilities.Factorial(5)}");
        Console.WriteLine();

        // Task 2: Logger
        Logger.EnableLogging = true;
        Logger.Log("Application started");
        Logger.Error("Null reference exception occurred");
        Console.WriteLine();

        // Task 3: Config Manager
        Console.WriteLine("Config Manager:");
        Console.WriteLine($"Application Name: {ConfigManager.ApplicationName}");
        Console.WriteLine($"Version: {ConfigManager.Version}");
        ConfigManager.Reload();
        Console.WriteLine();

        // Task 4: String Helper
        Console.WriteLine("String Helper:");
        Console.WriteLine($"Is 'racecar' a palindrome? {StringHelper.IsPalindrome("racecar")}");
        Console.WriteLine($"Title Case of 'hello world': {StringHelper.ToTitleCase("hello world")}");
        Console.WriteLine();

        // Task 5: DateTime Helper
        Console.WriteLine("DateTime Helper:");
        Console.WriteLine($"Current Date: {DateTimeHelper.GetCurrentDate()}");
        Console.WriteLine($"Days Between Today and 2025-12-31: {DateTimeHelper.DaysBetween(DateTime.Now, new DateTime(2025, 12, 31))}");



        ////////////////////////////
        // Task 1: Integer Extension - IsEven()
        Console.WriteLine("Integer Extensions:");
        Console.WriteLine($"Is 4 even? {4.IsEven()}");
        Console.WriteLine($"Is 7 even? {7.IsEven()}");
        Console.WriteLine();

        // Task 2: DateTime Extension - GetAge()
        Console.WriteLine("DateTime Extensions:");
        DateTime birthdate = new DateTime(2000, 5, 10);
        Console.WriteLine($"Age for birthdate {birthdate:yyyy-MM-dd}: {birthdate.GetAge()}");
        Console.WriteLine();

        // Task 3: String Extension - WordCount()
        Console.WriteLine("String Extensions:");
        string sentence = "Hello world! This is an extension method.";
        Console.WriteLine($"Word count: {sentence.WordCount()}");
        Console.WriteLine();

        // Task 4: Fibonacci Extension - NthFibonacci()
        Console.WriteLine("Fibonacci Extensions:");
        Console.WriteLine($"5th Fibonacci number: {5.NthFibonacci()}");
        Console.WriteLine($"10th Fibonacci number: {10.NthFibonacci()}");
    }
}