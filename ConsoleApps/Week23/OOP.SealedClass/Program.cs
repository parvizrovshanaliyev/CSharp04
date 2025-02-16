namespace OOP.SealedClass;

/// <summary>
/// Demonstrates the usage of sealed classes through simple, practical examples.
/// </summary>
internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Sealed Class Examples\n");

        // Example 1: Basic sealed class usage
        Console.WriteLine("Example 1: Basic Sealed Class");
        var calculator = Calculator.Instance;
        Console.WriteLine($"5 + 3 = {calculator.Add(5, 3)}");
        Console.WriteLine($"10 - 4 = {calculator.Subtract(10, 4)}");
        Console.WriteLine();

        // Example 2: Sealed class with immutable properties
        Console.WriteLine("Example 2: Immutable Person");
        var person = new ImmutablePerson("John Doe", new DateTime(1990, 1, 1));
        Console.WriteLine($"Name: {person.Name}");
        Console.WriteLine($"Birth Date: {person.BirthDate:d}");
        Console.WriteLine($"Age: {person.GetAge()} years");
        Console.WriteLine();

        // Example 3: Sealed method in inheritance
        Console.WriteLine("Example 3: Sealed Method");
        var basicPrinter = new Printer();
        var laserPrinter = new LaserPrinter();

        Console.WriteLine("Basic Printer:");
        basicPrinter.Print();

        Console.WriteLine("Laser Printer:");
        laserPrinter.Print();
    }
}

/// <summary>
/// Example 1: A simple sealed class implementing a basic calculator
/// This class cannot be inherited and uses the singleton pattern
/// </summary>
public sealed class Calculator
{
    private static Calculator? _instance;
    private static readonly object _lock = new();

    private Calculator() { } // Private constructor

    public static Calculator Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    _instance ??= new Calculator();
                }
            }
            return _instance;
        }
    }

    public int Add(int a, int b) => a + b;
    public int Subtract(int a, int b) => a - b;
}

/// <summary>
/// Example 2: A sealed class representing an immutable person
/// This class demonstrates why sealed is useful for immutable types
/// </summary>
public sealed class ImmutablePerson
{
    public string Name { get; }
    public DateTime BirthDate { get; }

    public ImmutablePerson(string name, DateTime birthDate)
    {
        Name = name;
        BirthDate = birthDate;
    }

    public int GetAge()
    {
        var today = DateTime.Today;
        var age = today.Year - BirthDate.Year;
        if (BirthDate.Date > today.AddYears(-age)) age--;
        return age;
    }
}

/// <summary>
/// Example 3: Base class for demonstrating sealed methods
/// </summary>
public class Printer
{
    public virtual void Print()
    {
        Console.WriteLine("Printing in black and white...");
    }
}

/// <summary>
/// Example 3: Class with a sealed method
/// The Print method cannot be overridden by classes that inherit from LaserPrinter
/// </summary>
public class LaserPrinter : Printer
{
    public sealed override void Print()
    {
        Console.WriteLine("Printing in high resolution...");
    }
}

// This would cause an error:
//public class SuperLaserPrinter : LaserPrinter
//{
//    public override void Print() // Error: cannot override sealed method
//    {
//        Console.WriteLine("Printing in super high resolution...");
//    }
//}

