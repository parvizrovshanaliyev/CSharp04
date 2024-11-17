using System;

namespace Arrays;

class Program
{
    static void Main(string[] args)
    {
        // --- Introduction to Arrays ---
        /*
         * Arrays are a data structure in C# used to store multiple values of the same type in a single variable.
         * Each value in an array is called an element, and elements are accessed using their index (starting from 0).
         * Arrays are useful for managing collections of data such as numbers, names, or other data types.
         * Memory for arrays is allocated contiguously, making access to elements fast and efficient.
         */

        // --- Declaring and Initializing Arrays ---
        /*
         * You can declare and initialize arrays in multiple ways:
         * 1. Declare an array with a fixed size and assign values later.
         * 2. Declare and initialize an array at the same time.
         * Let's see examples for both:
         */

        // Example 1: Declare with size and assign values later
        int[] numbers = new int[5]; // Creates an array to hold 5 integers
        numbers[0] = 10; // Assigning values to individual indices
        numbers[1] = 20;
        numbers[2] = 30;
        numbers[3] = 40;
        numbers[4] = 50;

        // Example 2: Declare and initialize an array directly -> new string[4]
        string[] names = { "Alice", "Bob", "Charlie", "Diana" };

        int nameDianaIndex = Array.IndexOf(names, "Diana"); // Find index of "Diana"
        Console.WriteLine($"Index of Diana: {nameDianaIndex}"); // Output: 3
        names[nameDianaIndex] = "Princess Diana";

        // --- Accessing Array Elements ---
        /*
         * Accessing elements in an array is done using the index.
         * Indexes start at 0 for the first element, 1 for the second, and so on.
         */
        Console.WriteLine("Accessing Array Elements:");
        Console.WriteLine($"First element in numbers array: {numbers[0]}"); // Output: 10
        Console.WriteLine($"Second element in names array: {names[1]}");   // Output: Bob

        // --- Array Length ---
        /*
         * The `Length` property of an array gives the total number of elements in the array.
         * This is useful for iterating through all elements using loops.
         */
        Console.WriteLine("\nArray Length:");
        Console.WriteLine($"Length of numbers array: {numbers.Length}"); // Output: 5
        Console.WriteLine($"Length of names array: {names.Length}");     // Output: 4

        // --- Iterating Through Arrays ---
        /*
         * You can use loops to traverse through arrays. Commonly used loops are:
         * 1. `for` loop: Provides index-based access, useful when you need the index.
         * 2. `foreach` loop: Simplifies iteration when you only need to read elements.
         * 3. `while` loop: Useful in conditions where iteration depends on external factors.
         */

        Console.WriteLine("\nIterating Through Arrays:");

        // Using a `for` loop
        Console.WriteLine("Using a for loop:");
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.WriteLine($"numbers[{i}] = {numbers[i]}");
        }

        // Using a `foreach` loop
        Console.WriteLine("Using a foreach loop:");
        foreach (string name in names)
        {
            Console.WriteLine(name);
        }

        // --- Updating Array Elements ---
        /*
         * You can modify elements in an array by assigning a new value to a specific index.
         */
        Console.WriteLine("\nUpdating Array Elements:");
        numbers[0] = 99; // Updating the first element
        Console.WriteLine($"Updated first element in numbers array: {numbers[0]}"); // Output: 99

        // --- Multi-Dimensional Arrays ---
        /*
         * Multi-dimensional arrays (like 2D arrays) are arrays with rows and columns, useful for tabular data.
         * Syntax: `dataType[,] arrayName = new dataType[rows, columns];`
         */
        Console.WriteLine("\nMulti-Dimensional Arrays:");
        int[,] matrix = new int[2, 3]
        {
            { 1, 2, 3 },  // Row 1
            { 4, 5, 6 }   // Row 2
        };
        Console.WriteLine($"Element at [1, 2]: {matrix[1, 2]}"); // Output: 6

        // --- Jagged Arrays ---
        /*
         * A jagged array is an array of arrays, where each "row" can have a different size.
         * Syntax: `dataType[][] arrayName = new dataType[outerSize][];`
         */
        Console.WriteLine("\nJagged Arrays:");
        int[][] jaggedArray = new int[2][];
        jaggedArray[0] = new int[] { 1, 2 };     // First "row" has 2 elements
        jaggedArray[1] = new int[] { 3, 4, 5 }; // Second "row" has 3 elements
        Console.WriteLine($"Element at jaggedArray[1][2]: {jaggedArray[1][2]}"); // Output: 5

        // --- Common Array Operations ---
        /*
         * C# provides built-in methods for common array operations:
         * 1. `Array.Sort`: Sorts the elements in ascending order.
         * 2. `Array.Reverse`: Reverses the order of elements.
         * 3. `Array.IndexOf`: Finds the index of a specific element.
         */
        Console.WriteLine("\nCommon Array Operations:");
        int[] unsorted = { 3, 1, 4, 1, 5 };
        Array.Sort(unsorted); // Sort the array
        Console.WriteLine($"Sorted array: {string.Join(", ", unsorted)}"); // Output: 1, 1, 3, 4, 5

        Array.Reverse(unsorted); // Reverse the array
        Console.WriteLine($"Reversed array: {string.Join(", ", unsorted)}"); // Output: 5, 4, 3, 1, 1

        int index = Array.IndexOf(unsorted, 3); // Find index of 3
        Console.WriteLine($"Index of 3: {index}"); // Output: 2

        /*Linq methods
         */

        int max = unsorted.Max();
        int min = unsorted.Min();
        //int sum = unsorted.Sum();

        // --- Practical Scenario: Sum of Array Elements ---
        /*
         * Use loops to calculate the sum of all elements in an array.
         */
        Console.WriteLine("\nPractical Scenario: Sum of Array Elements:");
        int sum = 0;
        //int sum = unsorted.Sum();
        foreach (int num in numbers)
        {
            sum += num;
        }
        Console.WriteLine($"Sum of numbers array: {sum}"); // Output: 289

        // --- Advanced Topics: Resizing Arrays ---
        /*
         * Arrays in C# are fixed in size, but you can resize them using `Array.Resize`.
         */
        Console.WriteLine("\nAdvanced Topic: Resizing Arrays:");
        Array.Resize(ref numbers, 7); // Resize to hold 7 elements
        numbers[5] = 60; // Adding new elements
        numbers[6] = 70;
        Console.WriteLine($"Resized array: {string.Join(", ", numbers)}");
    }
}
