namespace Loop.For;
public class Program
{
    static void Main()
    {



        // --- Example 1: Basic For Loop ---
        /*
         * Description:
         * A `for` loop that prints numbers from 1 to 5.
         *
         * Structure:
         * - Initialization: `int i = 1` - Starts the loop with `i` set to 1.
         * - Condition: `i <= 5` - Continues the loop as long as `i` is less than or equal to 5.
         * - Increment: `i++` - Adds 1 to `i` after each loop iteration.
         *
         * Sample Output:
         * Current value of i: 1
         * Current value of i: 2
         * Current value of i: 3
         * Current value of i: 4
         * Current value of i: 5
         */
        //for (int i = 1; i <= 5; i++)
        //{
        //    Console.WriteLine($"Current value of i: {i}");
        //}

        //Console.WriteLine(); // Blank line for separation of examples


        // --- Example 2: Infinite For Loop (Caution) ---
        /*
         * Description:
         * This is an infinite loop. If no condition is provided (i.e., `for(;;)`), the loop runs forever.
         * This loop is commented out by default because it would freeze the program.
         *
         * Warning:
         * Avoid infinite loops unless you intentionally want a process that never stops.
         * Use `Ctrl + C` to stop a running infinite loop.
         *
         * Sample Output (infinite):
         * This is an infinite loop.
         * This is an infinite loop.
         * This is an infinite loop.
         */

        /*
        for (;;)
        {
            Console.WriteLine("This is an infinite loop.");
        }
        */

        // --- Example 3: Using `break` to Stop a Loop Early ---
        /*
         * Description:
         * The `break` statement can exit the loop before the condition is false.
         * This example stops the loop when `i` reaches 3, ending it early.
         *
         * Sample Output:
         * Value of i: 1
         * Value of i: 2
         * Breaking the loop early when i is 3.
         */
        //for (int i = 1; i <= 5; i++)
        //{
        //    if (i == 3)
        //    {
        //        Console.WriteLine("Breaking the loop early when i is 3.");
        //        break; // Exit the loop when `i` is 3
        //    }
        //    Console.WriteLine($"Value of i: {i}");
        //}

        //Console.WriteLine();


        // --- Example 4: Using `continue` to Skip an Iteration ---
        /*
         * Description:
         * The `continue` statement skips the current iteration and moves to the next one.
         * This example skips printing the value of `i` when `i` equals 3.
         *
         * Sample Output:
         * Value of i: 1
         * Value of i: 2
         * Skipping when i is 3.
         * Value of i: 4
         * Value of i: 5
         */
        //for (int i = 1; i <= 5; i++)
        //{
        //    if (i == 3) // true
        //    {
        //        Console.WriteLine("Skipping when i is 3.");
        //        continue; // Skip this iteration when `i` is 3
        //    }

        //    Console.WriteLine($"Value of i: {i}");// 1,2,4,5
        //}

        //Console.WriteLine();


        // --- Example 5: Nested For Loops ---
        /*
         * Description:
         * A `for` loop can be placed inside another `for` loop to create a "nested" loop.
         * This example prints a 3x3 grid of asterisks.
         * Each iteration of the outer loop (rows) runs the inner loop (columns).
         *
         * Sample Output:
         * * * *
         * * * *
         * * * *
         */
        //for (int row = 1; row <= 3; row++)
        //{
        //    for (int col = 1; col <= 3; col++)
        //    {
        //        Console.Write("* ");
        //    }
        //    Console.WriteLine(); // Move to the next line after each row
        //}

        //Console.WriteLine();


        // --- Example 6: Controlled Infinite Loop with `break` ---
        /*
         * Description:
         * This example shows an infinite loop with a condition to exit.
         * The loop continues indefinitely but exits when `counter` reaches 5.
         *
         * Sample Output:
         * Counter: 0
         * Counter: 1
         * Counter: 2
         * Counter: 3
         * Counter: 4
         * Breaking the infinite loop.
         */
        //int counter = 0;

        //for (; ; )
        //{
        //    if (counter >= 5)
        //    {
        //        Console.WriteLine("Breaking the infinite loop.");
        //        break; // Exit the loop when `counter` reaches 5
        //    }

        //    Console.WriteLine($"Counter: {counter}");
        //    counter++;
        //}

        //Console.WriteLine();


        // --- Task 6: Check if String is a Palindrome (Using Loop) ---
        /*
         * Description:
         * Check if a string is a palindrome (same forwards and backwards).
         *
         * Explanation:
         * Convert the string to lowercase, then use a loop to check if the string reads the same forwards and backwards.
         *
         * Sample Input:
         *   Enter a string: Racecar 7/2
         * Sample Output:
         *   The string is a palindrome.
         */

        Console.Write("Enter a string: ");
        string palindromeInputLoop = Console.ReadLine();

        // Normalize the string by converting it to lowercase
        string normalizedLoop = palindromeInputLoop.ToLower();

        bool isPalindrome = true;

        // Loop from start to middle of the string to check if it's a palindrome
        for (int i = 0; i < normalizedLoop.Length / 2; i++)
        {
            char currentChar = normalizedLoop[i];

            Console.WriteLine(currentChar);

            char endChar = normalizedLoop[normalizedLoop.Length - 1 - i];

            Console.WriteLine(endChar);

            // Compare characters from the start and end
            if (normalizedLoop[i] != endChar)
            {
                Console.WriteLine($"{currentChar} != {endChar}");
                isPalindrome = false;
                break;
            }

            Console.WriteLine($"{currentChar} == {endChar}");
        }

        // Display result based on whether the string is a palindrome
        if (isPalindrome)
        {
            Console.WriteLine("The string is a palindrome (Loop).\n");
        }
        else
        {
            Console.WriteLine("The string is not a palindrome (Loop).\n");
        }
    }
}
