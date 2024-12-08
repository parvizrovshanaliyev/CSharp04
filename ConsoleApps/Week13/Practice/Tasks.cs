using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice;

public class Tasks
{
    /// <summary>
    /// Task 1: Filter Even Numbers from an Array
    /// This method filters even numbers from a given array of integers.
    /// It iterates through the array, checks each number for evenness using the modulus operator,
    /// and collects even numbers into a list, which is then returned as an array.
    /// Example:
    /// Input: {23, 12, 45, 36, 19, 8, 50, 17}
    /// Output: {12, 36, 8, 50}
    /// </summary>
    public static int[] FilterEvenNumbers(int[] numbers)
    {
        List<int> evenNumbers = new List<int>();
        foreach (var number in numbers)
        {
            if (number % 2 == 0)
            {
                evenNumbers.Add(number);
            }
        }
        return evenNumbers.ToArray();
    }

    /// <summary>
    /// Task 2: Sort Fruit Names Alphabetically
    /// Sorts an array of fruit names alphabetically using Array.Sort().
    /// Displays each fruit in sorted order, one per line.
    /// **Purpose**:
    /// This method sorts an array of fruit names alphabetically and displays them line by line.
    /// 
    /// **Key Method**:
    /// - `Array.Sort()`:
    ///   - Sorts strings lexicographically based on Unicode values.
    ///   - Sorting is case-sensitive by default (uppercase precedes lowercase).
    /// 
    /// **Steps**:
    /// 1. Use `Array.Sort()` to sort the fruits in alphabetical order.
    /// 2. Iterate through the sorted array using a `foreach` loop.
    /// 3. Print each fruit name on a new line.
    /// 
    /// **Example**:
    /// Input: {"Banana", "Apple", "Grape", "Mango", "Peach"}
    /// Output:
    /// Apple
    /// Banana
    /// Grape
    /// Mango
    /// Peach
    /// 
    /// **Edge Cases**:
    /// - Empty Array: Outputs "Sorted Fruits:" with no further lines.
    /// - Single Element: Outputs the single fruit name.
    /// - Duplicate Values: All duplicates are listed.
    /// 
    /// **Complexity**:
    /// - Time: O(n log n) due to sorting.
    /// - Space: O(1) as the sort is performed in place.
    /// </summary>
    public static void SortFruits(string[] fruits)
    {
        Array.Sort(fruits);
        Console.WriteLine("Sorted Fruits:");
        foreach (var fruit in fruits)
        {
            Console.WriteLine(fruit);
        }
    }

    /// <summary>
    /// Task 3: Print a Tic-Tac-Toe Board
    /// Prints a 3x3 tic-tac-toe board with the given 2D character array.
    /// Uses separators (`|`) and newlines to format the board correctly.
    ///
    /// **Purpose**:
    /// Prints a 3x3 tic-tac-toe board with a 2D character array as input.
    /// Separates columns with `|` and rows with newlines for better readability.
    ///
    /// **Key Method: GetLength**
    /// - Retrieves the size of the array dimensions dynamically.
    /// - `GetLength(0)` → Number of rows.
    /// - `GetLength(1)` → Number of columns.
    ///
    /// **Steps**:
    /// 1. Loop through each row (`GetLength(0)`).
    /// 2. Loop through each column (`GetLength(1)`).
    /// 3. Print the cell's value, followed by `|` if it isn't the last column.
    /// 4. Add a newline at the end of each row.
    ///
    /// **Example**:
    /// Input:
    /// {'X', 'O', 'X'},
    /// {'O', 'X', ' '},
    /// {' ', 'O', 'X'}
    ///
    /// Output:
    /// X | O | X
    /// O | X |  
    ///   | O | X
    ///
    /// **Complexity**:
    /// - Time: O(rows × columns) for all grid elements.
    /// - Space: O(1), no additional memory allocation.
    /// </summary>
    public static void PrintBoard(char[,] board)
    {
        for (int i = 0; i < board.GetLength(0); i++) // Loop through rows
        {
            for (int j = 0; j < board.GetLength(1); j++) // Loop through columns
            {
                Console.Write(board[i, j]);

                if (j < board.GetLength(1) - 1)
                {
                    Console.Write(" | ");
                }
            }
            Console.WriteLine();
        }
    }

    /// <summary>
    /// Task 4: Calculate Rectangle Area with Default Width
    /// Calculates the area of a rectangle given its length and an optional width (default is 5).
    /// Returns the computed area.
    /// Example:
    /// Input: length = 10
    /// Output: 50 (Default width 5 is used)
    /// </summary>
    public static int CalculateRectangleArea(int length, int width = 5)
    {
        return length * width;
    }

    /// <summary>
    /// Task 5: Calculate Sum and Average of an Array
    /// Computes the sum and average of an integer array.
    /// Uses the `out` keyword to return the results.
    /// Example:
    /// Input: {10, 20, 30, 40, 50}
    /// Output: Sum = 150, Average = 30
    /// </summary>
    public static void CalculateSumAndAverage(int[] numbers, out int sum, out double average)
    {
        sum = 0;
        foreach (var number in numbers)
        {
            sum += number;
        }
        average = (double)sum / numbers.Length;
    }

    /// <summary>
    /// Task 6: Find the Largest Number
    /// Compares two integers and returns the larger of the two.
    /// Example:
    /// Input: 78, 89
    /// Output: 89
    /// </summary>
    public static int FindMax(int num1, int num2)
    {
        return num1 > num2 ? num1 : num2;
    }

    /// <summary>
    /// Task 7: Method Overloading - Display Different Types
    /// Overloaded methods to display messages based on the parameter type:
    /// - `int` → Prints "Number: [value]"
    /// - `string` → Prints "Message: [value]"
    /// - `double` → Prints "Decimal Value: [value]"
    /// Example:
    /// Input: 5, "Hello", 4.75
    /// Output:
    /// Number: 5
    /// Message: Hello
    /// Decimal Value: 4.75
    /// </summary>
    public static void Display(int value)
    {
        Console.WriteLine("Number: " + value);
    }

    public static void Display(string message)
    {
        Console.WriteLine("Message: " + message);
    }

    public static void Display(double value)
    {
        Console.WriteLine("Decimal Value: " + value);
    }

    /// <summary>
    /// Task 8: Box Volume Calculator with Named Arguments
    /// Calculates the volume of a box given its length, width, and height.
    /// Example:
    /// Input: length = 6, width = 4, height = 5
    /// Output: 120
    /// </summary>
    public static int CalculateVolume(int length, int width, int height)
    {
        return length * width * height;
    }

    /// <summary>
    /// Task 9: Swap Two Numbers Using ref and out Parameters
    /// Swaps two numbers using `ref` and calculates their sum using `out`.
    /// 
    /// **Purpose**:
    /// This method demonstrates the use of `ref` and `out` keywords in C#. 
    /// It swaps the values of two integers using `ref` parameters, allowing the changes to be reflected in the caller. 
    /// Additionally, it calculates the sum of the swapped numbers and returns it via an `out` parameter.
    /// 
    /// **How It Works**:
    /// 1. `ref` Keyword:
    ///    - The `ref` keyword enables the method to modify the original variables passed to it. 
    ///    - The variables `num1` and `num2` are directly modified, and their swapped values persist in the calling code.
    /// 2. `out` Keyword:
    ///    - The `out` keyword is used to return the sum of the swapped numbers. 
    ///    - This is useful when the method needs to return multiple outputs (in this case, the modified variables and their sum).
    /// 
    /// **Steps**:
    /// 1. Store the value of `num1` in a temporary variable (`temp`).
    /// 2. Assign the value of `num2` to `num1`, effectively swapping the first number.
    /// 3. Assign the value of `temp` (original `num1`) to `num2`, completing the swap.
    /// 4. Calculate the sum of the swapped values (`num1 + num2`) and assign it to the `out` parameter `sum`.
    /// 
    /// **Example**:
    /// Input:
    ///   a = 10, b = 20
    /// Execution:
    ///   1. Before Swap: num1 = 10, num2 = 20
    ///   2. Swapping: num1 = 20, num2 = 10
    ///   3. Sum Calculation: sum = num1 + num2 = 30
    /// Output:
    ///   Swapped: a = 20, b = 10, Sum = 30
    /// 
    /// **Usage**:
    /// This method is useful in scenarios where:
    /// - Two values need to be swapped in place without creating additional complex structures.
    /// - A related result (like the sum) needs to be calculated and returned alongside the modified values.
    /// 
    /// **Complexity**:
    /// - Time Complexity: O(1) - Constant-time operations for assignment and addition.
    /// - Space Complexity: O(1) - A single temporary variable is used.
    /// </summary>
    public static void SwapNumbers(ref int num1, ref int num2, out int sum)
    {
        int temp = num1;
        num1 = num2;
        num2 = temp;

        sum = num1 + num2;
    }

    /// <summary>
    /// Runs all tasks sequentially.
    /// Demonstrates the functionality of each method by calling it with sample inputs.
    /// Enhanced output for better readability.
    /// </summary>
    public static void Run()
    {
        Console.WriteLine("=== Task 1: Filter Even Numbers ===");
        int[] numbers = { 23, 12, 45, 36, 19, 8, 50, 17 };
        Console.WriteLine("Original Numbers: " + string.Join(", ", numbers));
        int[] evenNumbers = FilterEvenNumbers(numbers);
        Console.WriteLine("Filtered Even Numbers: " + string.Join(", ", evenNumbers));
        Console.WriteLine();

        Console.WriteLine("=== Task 2: Sort Fruit Names Alphabetically ===");
        string[] fruits = { "Banana", "Apple", "Grape", "Mango", "Peach" };
        Console.WriteLine("Original Fruits: " + string.Join(", ", fruits));
        SortFruits(fruits);
        Console.WriteLine();

        Console.WriteLine("=== Task 3: Print a Tic-Tac-Toe Board ===");

        char[,] board = {
        { 'X', 'O', 'X' },
        { 'O', 'X', ' ' },
        { ' ', 'O', 'X' }};


        Console.WriteLine("Tic-Tac-Toe Board:");
        PrintBoard(board);
        Console.WriteLine();

        Console.WriteLine("=== Task 4: Calculate Rectangle Area ===");
        Console.WriteLine("Using default width (5): " + CalculateRectangleArea(10));
        Console.WriteLine("Using provided width (6): " + CalculateRectangleArea(8, 6));
        Console.WriteLine();

        Console.WriteLine("=== Task 5: Calculate Sum and Average of an Array ===");
        int[] array = { 10, 20, 30, 40, 50 };
        Console.WriteLine("Array: " + string.Join(", ", array));
        CalculateSumAndAverage(array, out int sum, out double average);
        Console.WriteLine($"Sum: {sum}, Average: {average}");
        Console.WriteLine();

        Console.WriteLine("=== Task 6: Find the Largest Number ===");
        int[] numbersToCompare = { 34, 78, 12, 89, 23 };
        Console.WriteLine("Numbers: " + string.Join(", ", numbersToCompare));
        int max = FindMax(34, FindMax(78, FindMax(12, FindMax(89, 23))));
        Console.WriteLine("Largest Number: " + max);
        Console.WriteLine();

        Console.WriteLine("=== Task 7: Display Overloaded Methods ===");
        Console.WriteLine("Displaying different types:");
        Display(5);
        Display("Hello");
        Display(4.75);
        Console.WriteLine();

        Console.WriteLine("=== Task 8: Box Volume Calculator ===");
        int volume = CalculateVolume(length: 6, width: 4, height: 5);
        Console.WriteLine($"Volume of the box (Length: 6, Width: 4, Height: 5): {volume}");
        Console.WriteLine();

        Console.WriteLine("=== Task 9: Swap Two Numbers ===");
        int a = 10, b = 20;
        Console.WriteLine($"Before Swap: a = {a}, b = {b}");
        SwapNumbers(ref a, ref b, out int totalSum);
        Console.WriteLine($"After Swap: a = {a}, b = {b}");
        Console.WriteLine($"Sum of swapped numbers: {totalSum}");
        Console.WriteLine();

        Console.WriteLine("=== All Tasks Completed ===");
    }

}
