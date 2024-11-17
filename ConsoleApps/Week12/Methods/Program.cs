using System;

namespace  Methods;

class Program
{
    static void Main(string[] args)
    {
        // --- Introduction to Methods ---
        /*
         * What are Methods?
         * Methods are reusable blocks of code that perform a specific task.
         * They help organize code, reduce repetition, and make programs easier to read and maintain.
         * 
         * Structure of a Method:
         * - Return Type: The type of data the method returns (e.g., int, string, void).
         * - Name: A descriptive identifier for the method (e.g., CalculateSum).
         * - Parameters: Inputs the method requires (optional).
         * - Body: The logic or actions performed by the method.
         * 
         * Example:
         * int AddNumbers(int a, int b)
         * {
         *     return a + b; // Adds two numbers and returns the result
         * }
         */

        Console.WriteLine("=== C# Methods ===");

        // Example: Basic Method Call
        Console.WriteLine("1. Basic Method Call:");
        Console.WriteLine($"The sum of 5 and 7 is: {AddNumbers(5, 7)}"); // Calls AddNumbers

        // --- Defining and Calling Methods ---
        /*
         * Defining Methods:
         * A method must be defined with its return type, name, and optional parameters.
         * Example:
         *   static int Multiply(int a, int b)
         *   {
         *       return a * b;
         *   }
         * 
         * Calling Methods:
         * To use a method, call it by name and pass arguments (if required).
         * Example:
         *   int result = Multiply(3, 4); // Calls Multiply and stores the result
         */

        Console.WriteLine("\n2. Greeting Method:");
        GreetUser("Alice"); // Calls GreetUser method

        // --- Methods with Return Values ---
        /*
         * Methods can return values using the `return` keyword.
         * - Specify the return type in the method definition.
         * - Use the `return` statement to provide a value back to the caller.
         */

        Console.WriteLine("\n3. Methods with Return Values:");
        int product = Multiply(6, 4); // Calls Multiply
        Console.WriteLine($"The product of 6 and 4 is: {product}");

        // --- Void Methods ---
        /*
         * Void Methods:
         * A `void` method performs an action but does not return any value.
         * Example:
         * void DisplayMessage(string message)
         * {
         *     Console.WriteLine(message);
         * }
         */

        Console.WriteLine("\n4. Void Methods:");
        DisplayMessage("This is a void method example."); // Calls DisplayMessage

        // --- Passing Parameters to Methods ---
        /*
         * Methods can accept inputs, called parameters.
         * - Pass by Value: A copy of the variable is passed to the method (default behavior).
         * - Pass by Reference: The actual variable is passed, allowing the method to modify it.
         */

        Console.WriteLine("\n5. Passing Parameters:");
        int num = 10;
        IncrementByValue(num); // Passes a copy (value is unchanged)
        Console.WriteLine($"After Pass by Value: {num}");

        IncrementByReference(ref num); // Passes the original variable
        Console.WriteLine($"After Pass by Reference: {num}");

        // --- Method Overloading ---
        /*
         * Method Overloading:
         * - Allows multiple methods with the same name but different parameter lists.
         * - The compiler determines which method to call based on the arguments.
         */

        Console.WriteLine("\n6. Method Overloading:");
        Console.WriteLine($"Area of square (side=5): {CalculateArea(5)}");
        Console.WriteLine($"Area of rectangle (length=5, width=10): {CalculateArea(5, 10)}");

        // --- Practical Example: Average Calculation ---
        /*
         * Combine knowledge of methods to solve practical problems.
         * Example: Calculate the average of three numbers.
         */
        Console.WriteLine("\n7. Practical Example - Average Calculation:");
        double average = CalculateAverage(20, 40, 60);
        Console.WriteLine($"The average of 20, 40, and 60 is: {average}");
    }

    // --- Helper Methods ---

    // Method to add two numbers and return the result
    static int AddNumbers(int a, int b)
    {
        return a + b;
    }

    // Method to greet a user by name
    static void GreetUser(string name)
    {
        Console.WriteLine($"Hello, {name}!");
    }

    // Method to multiply two numbers and return the result
    static int Multiply(int a, int b)
    {
        return a * b;
    }

    // Void method to display a message
    static void DisplayMessage(string message)
    {
        Console.WriteLine(message);
    }

    // Method to increment a value by 5 (Pass by Value)
    static void IncrementByValue(int value)
    {
        value += 5; // Only modifies the local copy
    }

    // Method to increment a value by 5 (Pass by Reference)
    static void IncrementByReference(ref int value)
    {
        value += 5; // Modifies the original variable
    }

    // Overloaded method to calculate the area of a square
    static int CalculateArea(int side)
    {
        return side * side;
    }

    // Overloaded method to calculate the area of a rectangle
    static int CalculateArea(int length, int breadth)
    {
        return length * breadth;
    }

    // Method to calculate the average of three numbers
    static double CalculateAverage(int num1, int num2, int num3)
    {
        return (num1 + num2 + num3) / 3.0; // Divide by 3.0 for decimal result
    }
}
