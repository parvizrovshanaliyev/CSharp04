namespace Practice;

public class MethodTasks
{
    /// <summary>
    /// Task 1: Creating and Calling a Simple Method
    /// Description: Print a greeting message to the console.
    /// Sample Output: Hello, welcome to C# programming!
    /// </summary>
    public static void PrintGreeting()
    {
        Console.WriteLine("Hello, welcome to C# programming!");
    }

    /// <summary>
    /// Task 2: Method with Parameters
    /// Description: Print a personalized greeting using the provided name.
    /// Sample Input: Alice
    /// Sample Output: Hello, Alice! Welcome to C# programming.
    /// </summary>
    public static void PrintGreeting(string name)
    {
        Console.WriteLine($"Hello, {name}! Welcome to C# programming.");
    }

    /// <summary>
    /// Task 3: Method with Return Value
    /// Description: Calculate the square of a number and return the result.
    /// Sample Input: 4
    /// Sample Output: The square of 4 is 16.
    /// </summary>
    public static int CalculateSquare(int number)
    {
        return number * number;
    }

    /// <summary>
    /// Task 4: Method Overloading
    /// Description: Demonstrate method overloading by adding two or three numbers.
    /// </summary>
    public static int Add(int a, int b)
    {
        return a + b;
    }

    public static int Add(int a, int b, int c)
    {
        return a + b + c;
    }

    /// <summary>
    /// Task 5: Passing Parameters by Value
    /// Description: Modify a value inside a method without affecting the original variable.
    /// </summary>
    public static void ModifyValue(int value)
    {
        value *= 2;
        Console.WriteLine($"Modified value inside method: {value}");
    }

    /// <summary>
    /// Task 6: Passing Parameters by Reference
    /// Description: Modify a value inside a method and reflect the change in the original variable.
    /// </summary>
    public static void ModifyValue(ref int value)
    {
        value *= 2;
        Console.WriteLine($"Value inside method: {value}");
    }

    /// <summary>
    /// Task 7: Using `out` Parameters
    /// Description: Calculate the quotient and remainder using `out` parameters.
    /// </summary>
    public static void Calculate(int dividend, int divisor, out int quotient, out int remainder)
    {
        quotient = dividend / divisor;
        remainder = dividend % divisor;
    }

    /// <summary>
    /// Task 8: Method with Optional Parameters
    /// Description: Calculate the area of a rectangle or square with optional width.
    /// </summary>
    public static int CalculateArea(int length, int width = 0)
    {
        return width == 0 ? length * length : length * width;
    }

    /// <summary>
    /// Task 9: Recursion in Methods
    /// Description: Calculate the factorial of a number using recursion.
    /// </summary>
    public static int CalculateFactorial(int number)
    {
        if (number == 0) return 1;
        return number * CalculateFactorial(number - 1);
    }

    /// <summary>
    /// Task 10: Using Method to Work with Arrays
    /// Description: Find the largest element in an integer array.
    /// </summary>
    public static int FindLargest(int[] array)
    {
        int max = int.MinValue;
        foreach (var item in array)
        {
            if (item > max) max = item;
        }
        return max;
    }

    /// <summary>
    /// Task 11: Real-World Scenario - Simple Calculator
    /// Description: Perform basic arithmetic operations based on user choice.
    /// </summary>
    public static double Calculate(double a, double b, char operation)
    {
        return operation switch
        {
            '+' => a + b,
            '-' => a - b,
            '*' => a * b,
            '/' => b != 0 ? a / b : throw new DivideByZeroException(),
            _ => throw new InvalidOperationException("Invalid operation")
        };
    }
    
    public static int ReadIntFromConsole(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
        
            if (int.TryParse(Console.ReadLine(), out int value))
            {
                return value;
            }
        
            Console.WriteLine("Invalid input. Please enter a valid integer.");
        }
    }
    
    public static void Run()
    {
        // Task 1
        Console.WriteLine("Method Task - Task 1");
        MethodTasks.PrintGreeting();

        // Task 2
        Console.WriteLine("\nMethod Task - Task 2");
        Console.Write("Enter your name: ");
        string name = Console.ReadLine();
        MethodTasks.PrintGreeting(name);

        // Task 3
        Console.WriteLine("\nMethod Task - Task 3");
        int number = ReadIntFromConsole("Enter a number: ");
        int square = MethodTasks.CalculateSquare(number);
        Console.WriteLine($"The square of {number} is {square}");

        // Task 4
        Console.WriteLine("\nMethod Task - Task 4");
        int sum1 = MethodTasks.Add(3, 5);
        int sum2 = MethodTasks.Add(2, 4, 6);
        Console.WriteLine($"Sum of 3 and 5: {sum1}");
        Console.WriteLine($"Sum of 2, 4, and 6: {sum2}");

        // Task 5
        Console.WriteLine("\nMethod Task - Task 5");
        int value = ReadIntFromConsole("Enter a number: ");
        Console.WriteLine($"Original value: {value}");
        MethodTasks.ModifyValue(value);
        Console.WriteLine($"Value after method call: {value}");

        // Task 6
        Console.WriteLine("\nMethod Task - Task 6");
        int refValue = ReadIntFromConsole("Enter a number: ");
        Console.WriteLine($"Value before method call: {refValue}");
        MethodTasks.ModifyValue(ref refValue);
        Console.WriteLine($"Value after method call: {refValue}");

        // Task 7
        Console.WriteLine("\nMethod Task - Task 7");
        int dividend = ReadIntFromConsole("Enter dividend: ");
        int divisor = ReadIntFromConsole("Enter divisor: ");
        MethodTasks.Calculate(dividend, divisor, out int quotient, out int remainder);
        Console.WriteLine($"Quotient: {quotient}, Remainder: {remainder}");

        // Task 8
        Console.WriteLine("\nMethod Task - Task 8");
        int length = ReadIntFromConsole( "Enter length: ");
        Console.Write("Enter width (or press Enter to skip): ");
        string widthInput = Console.ReadLine();
        int width = int.TryParse(widthInput, out int w) ? w : 0;
        int area = MethodTasks.CalculateArea(length, width );
        Console.WriteLine($"Area: {area}");

        // Task 9
        Console.WriteLine("\nMethod Task - Task 9");
        int factNumber = ReadIntFromConsole("Enter a number: ");
        int factorial = MethodTasks.CalculateFactorial(factNumber);
        Console.WriteLine($"Factorial of {factNumber} is {factorial}");

        // Task 10
        Console.WriteLine("\nMethod Task - Task 10");
        Console.Write("Enter array elements (comma-separated): ");
        string input = Console.ReadLine();

        if (!string.IsNullOrEmpty(input))
        {
            // Split input into strings and convert to integers
            string[] stringArray = input.Split(',');
            int[] array = new int[stringArray.Length];

            for (int i = 0; i < stringArray.Length; i++)
            {
                if (int.TryParse(stringArray[i], out int number2))
                {
                    array[i] = number2;
                }
                else
                {
                    Console.WriteLine("Invalid number in input. Defaulting to 0.");
                    array[i] = 0; // Default invalid input to 0
                }
            }

            int largest = MethodTasks.FindLargest(array);
            Console.WriteLine($"Largest element: {largest}");
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a comma-separated list of numbers.");
        }

        // Task 11
        Console.WriteLine("\nMethod Task - Task 11");
        Console.Write("Enter first number: ");
        double a = double.TryParse(Console.ReadLine(), out double num1) ? num1 : 0;
        Console.Write("Enter second number: ");
        double b = double.TryParse(Console.ReadLine(), out double num2) ? num2 : 0;
        Console.Write("Choose operation (+, -, *, /): ");
        char operation = Console.ReadLine()[0];
        try
        {
            Console.WriteLine($"Result: {MethodTasks.Calculate(a, b, operation)}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

}