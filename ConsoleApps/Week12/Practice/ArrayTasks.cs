namespace Practice;

public class ArrayTasks
{
    /// <summary>
    /// Task 1: Declaring and Initializing Arrays
    /// Description: Declare and initialize an integer array with five elements and print them.
    /// Explanation: Arrays in C# store multiple values of the same data type. This demonstrates declaring, initializing, and printing arrays.
    /// Sample Input: No input required
    /// Sample Output: Array elements: 1, 2, 3, 4, 5
    /// </summary>
    public static void DeclareAndPrintArrayTask1()
    {
        int[] array = { 1, 2, 3, 4, 5 };
        Console.WriteLine("Array elements: " + string.Join(", ", array));
    }

    /// <summary>
    /// Task 2: Accessing and Modifying Array Elements
    /// Description: Access and modify elements of an integer array based on user input.
    /// Explanation: Arrays allow individual elements to be accessed and modified using indexes.
    /// Sample Input:
    ///     Original array: [1, 2, 3, 4, 5]
    ///     Enter index to modify: 2
    ///     Enter new value: 10
    /// Sample Output: Modified array: [1, 2, 10, 4, 5]
    /// </summary>
    public static void AccessAndModifyArrayTask2()
    {
        int[] array = { 1, 2, 3, 4, 5 };
        Console.WriteLine("Original array: " + string.Join(", ", array));
        Console.Write("Enter index to modify (0-4): ");
        
        if (int.TryParse(Console.ReadLine(), out int index) && index >= 0 && index < array.Length)
        {
            Console.Write("Enter new value: ");
            if (int.TryParse(Console.ReadLine(), out int newValue))
            {
                array[index] = newValue;
                Console.WriteLine("Modified array: " + string.Join(", ", array));
            }
            else
            {
                Console.WriteLine("Invalid value.");
            }
        }
        else
        {
            Console.WriteLine("Invalid index.");
        }
    }

    /// <summary>
    /// Task 3: Iterating Over Arrays Using a `for` Loop
    /// Description: Iterate over an array using a `for` loop and print its elements.
    /// Explanation: The `for` loop uses the array's length to iterate over all elements by index.
    /// Sample Input: Array: [5, 10, 15, 20, 25]
    /// Sample Output:
    ///     Array elements:
    ///     5
    ///     10
    ///     15
    ///     20
    ///     25
    /// </summary>
    public static void IterateArrayWithForLoopTask3()
    {
        int[] array = { 5, 10, 15, 20, 25 };
        Console.WriteLine("Array elements:");
        for (int i = 0; i < array.Length; i++)
        {
            Console.WriteLine(array[i]);
        }
    }

    /// <summary>
    /// Task 4: Array Length and Iterating Using a `foreach` Loop
    /// Description: Find the length of an array and iterate using a `foreach` loop.
    /// Explanation: The `foreach` loop iterates through all elements without needing their indexes.
    /// Sample Input: Array: [2, 4, 6, 8]
    /// Sample Output:
    ///     Array length: 4
    ///     Array elements:
    ///     2
    ///     4
    ///     6
    ///     8
    /// </summary>
    public static void FindLengthAndIterateArrayTask4()
    {
        int[] array = { 2, 4, 6, 8 };
        Console.WriteLine("Array length: " + array.Length);
        Console.WriteLine("Array elements:");

        foreach (int item in array)
        {
            Console.WriteLine(item);
        }
    }

    /// <summary>
    /// Task 5: Finding the Maximum and Minimum Values in an Array
    /// Description: Find the largest and smallest numbers in an integer array.
    /// Explanation: Iterate through the array, comparing each value to find the max and min.
    /// Sample Input: Array: [10, 20, 5, 8, 30]
    /// Sample Output:
    ///     Maximum value: 30
    ///     Minimum value: 5
    /// </summary>
    public static void FindMaxAndMinTask5()
    {
        int[] array = { 10, 20, 5, 8, 30 };
        int max = int.MinValue, min = int.MaxValue;

        foreach (int item in array)
        {
            if (item > max) max = item;
            if (item < min) min = item;
        }

        Console.WriteLine("Maximum value: " + max);
        Console.WriteLine("Minimum value: " + min);
    }

    /// <summary>
    /// Task 6: Summing All Elements in an Array
    /// Description: Calculate the sum of all elements in an array.
    /// Explanation: Traverse the array, adding each element to a running total.
    /// Sample Input: Array: [1, 2, 3, 4, 5]
    /// Sample Output: Sum of elements: 15
    /// </summary>
    public static void CalculateSumOfArrayTask6()
    {
        int[] array = { 1, 2, 3, 4, 5 };
        int sum = 0;
        foreach (int item in array)
        {
            sum += item;
        }
        Console.WriteLine("Sum of elements: " + sum);
    }

    /// <summary>
    /// Task 7: Reversing an Array
    /// Description: Reverse the elements of an array.
    /// Explanation: Traverse the array from the end to the start and print the elements.
    /// Sample Input: Array: [1, 2, 3, 4, 5]
    /// Sample Output: Reversed array: [5, 4, 3, 2, 1]
    /// </summary>
    public static void ReverseArrayTask7()
    {
        int[] array = { 1, 2, 3, 4, 5 };
        Array.Reverse(array);
        Console.WriteLine("Reversed array: " + string.Join(", ", array));
    }

    /// <summary>
    /// Task 8: Sorting an Array
    /// Description: Sort an array in ascending order.
    /// Explanation: Use the built-in method `Array.Sort()` to sort the array.
    /// Sample Input: Array: [10, 5, 20, 15]
    /// Sample Output: Sorted array: [5, 10, 15, 20]
    /// </summary>
    public static void SortArrayTask8()
    {
        int[] array = { 10, 5, 20, 15 };
        Array.Sort(array);
        Console.WriteLine("Sorted array: " + string.Join(", ", array));
    }

    /// <summary>
    /// Task 9: Basic 2D Array Operations
    /// Description: Create a 2D array and display its elements.
    /// Explanation: Use nested loops to iterate through rows and columns of the 2D array.
    /// Sample Input:
    ///     2D Array:
    ///     [1, 2]
    ///     [3, 4]
    /// Sample Output:
    ///     2D Array elements:
    ///     1 2
    ///     3 4
    /// </summary>
    public static void Display2DArrayTask9()
    {
        int[,] array = { { 1, 2 }, { 3, 4 } };
        Console.WriteLine("2D Array elements:");
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                Console.Write(array[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    /// <summary>
    /// Task 10: Real-World Scenario - Finding Duplicate Elements
    /// Description: Find and print duplicate elements in an array.
    /// Explanation: Use a set to track seen elements and identify duplicates.
    /// Sample Input: Array: [1, 2, 3, 2, 4, 5, 1]
    /// Sample Output: Duplicate elements: 1, 2
    /// </summary>
    public static void FindDuplicateElementsTask10()
    {
        int[] array = { 1, 2, 3, 2, 4, 5, 1 };
        bool[] isDuplicate = new bool[array.Length]; // Tracks if an element is already marked as duplicate.

        Console.WriteLine("Duplicate elements:");

        for (int i = 0; i < array.Length; i++) // index 0 : 1
        {
            if (isDuplicate[i]) continue; // Skip already processed duplicates.

            for (int j = i + 1; j < array.Length; j++)  // index 1 :2- length
            {
                if (array[i] == array[j])
                {
                    Console.WriteLine(array[i]); // Print the duplicate.
                    isDuplicate[j] = true; // Mark the duplicate as processed.
                    break; // Avoid printing the same duplicate multiple times.
                }
            }
        }
    }

    /// <summary>
    /// Task 11: Finding the Index of an Element
    /// Description: Find the index of a specific element in an array.
    /// Explanation: Use a loop or `Array.IndexOf()` to find the target element's index.
    /// Sample Input:
    ///     Array: [10, 20, 30, 40]
    ///     Element to find: 30
    /// Sample Output: Element found at index: 2
    /// </summary>
    public static void FindIndexOfElementTask11()
    {
        int[] array = { 10, 20, 30, 40 };
        Console.WriteLine("Array: " + string.Join(", ", array));

        Console.Write("Enter element to find: ");
        if (int.TryParse(Console.ReadLine(), out int target))
        {
            int index = Array.IndexOf(array, target); // 20: index 1

            if (index != -1) // not equal -> element founded
            {
                Console.WriteLine("Element found at index: " + index);
            }
            else
            {
                Console.WriteLine("Element not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input.");
        }
    }
    
    public static void Run()
    {
        Console.WriteLine("Array Tasks - Task 1:");
        ArrayTasks.DeclareAndPrintArrayTask1();

        Console.WriteLine("\nArray Tasks - Task 2:");
        ArrayTasks.AccessAndModifyArrayTask2();

        Console.WriteLine("\nArray Tasks - Task 3:");
        ArrayTasks.IterateArrayWithForLoopTask3();

        Console.WriteLine("\nArray Tasks - Task 4:");
        ArrayTasks.FindLengthAndIterateArrayTask4();

        Console.WriteLine("\nArray Tasks - Task 5:");
        ArrayTasks.FindMaxAndMinTask5();

        Console.WriteLine("\nArray Tasks - Task 6:");
        ArrayTasks.CalculateSumOfArrayTask6();

        Console.WriteLine("\nArray Tasks - Task 7:");
        ArrayTasks.ReverseArrayTask7();

        Console.WriteLine("\nArray Tasks - Task 8:");
        ArrayTasks.SortArrayTask8();

        Console.WriteLine("\nArray Tasks - Task 9:");
        ArrayTasks.Display2DArrayTask9();

        Console.WriteLine("\nArray Tasks - Task 10:");
        ArrayTasks.FindDuplicateElementsTask10();

        Console.WriteLine("\nArray Tasks - Task 11:");
        ArrayTasks.FindIndexOfElementTask11();
    }
}