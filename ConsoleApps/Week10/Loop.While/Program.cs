using System;


namespace Loop.While;

public class Program
{
    static void Main()
    {
        // --- Example 1: Basic Counter Using while Loop ---
        /*
         * Description:
         * This example demonstrates a basic `while` loop that counts from 1 to 5.
         * 
         * Structure:
         * - Initializes `count` to 1.
         * - The loop continues as long as `count <= 5`.
         * - In each iteration, `count` is incremented by 1.
         * 
         * Sample Output:
         * Current count: 1
         * Current count: 2
         * Current count: 3
         * Current count: 4
         * Current count: 5
         */

        //int count = 1; // Initialize the counter

        //while (count <= 5) // Condition: Continue while count is less than or equal to 5
        //{
        //    Console.WriteLine("Current count: " + count); // Display current count
        //    count++; // Increment count by 1
        //}

        //Console.WriteLine(); // Blank line for separation


        // --- Example 2: Input Validation Using while Loop ---
        /*
         * Description:
         * This example demonstrates using a `while` loop for input validation.
         * It keeps prompting the user to enter a positive number until a valid number is entered.
         * 
         * Key Concept:
         * This is a common use of `while` loops, where you continue looping until the user meets a condition.
         * 
         * Sample Input/Output:
         * Enter a positive number: -1
         * Please enter a positive number.
         * Enter a positive number: 3
         * You entered a positive number: 3
         */

        //int number = 0;
        //Console.Write("Enter a positive number: ");
        //number = int.Parse(Console.ReadLine());

        //while (number <= 0) // Repeat as long as the input is not a positive number
        //{
        //    Console.WriteLine("Please enter a positive number.");
        //    Console.Write("Enter a positive number: ");
        //    number = int.Parse(Console.ReadLine()); // Ask for input again
        //}

        //Console.WriteLine("You entered a positive number: " + number);
        //Console.WriteLine(); // Blank line for separation

        //////////////////////////////

        //int number = 0;

        //Console.Write("Enter a positive number: ");

        //bool isValidNumberParsing = int.TryParse(Console.ReadLine(), out number); // text
        
        //while (isValidNumberParsing == false || number <= 0)
        //{
        //    Console.WriteLine("Please enter a positive number.");
        //    Console.Write("Enter a positive number: ");

        //    isValidNumberParsing= int.TryParse(Console.ReadLine(), out number);
        //}

        //Console.WriteLine("You entered a positive number: " + number);
        //Console.WriteLine(); // Blank line for separation



        // --- Example 3: Summing Numbers with a while Loop ---
        /*
         * Description:
         * This example asks the user to input numbers to add to a running total. The loop stops when the user types "done".
         * 
         * Key Concept:
         * This example uses an infinite `while (true)` loop with a `break` statement to exit when a specific condition is met.
         * 
         * Sample Input/Output:
         * Enter a number to add (or 'done' to finish): 4
         * Enter a number to add (or 'done' to finish): 3
         * Enter a number to add (or 'done' to finish): done
         * The sum of entered numbers is: 7
         */

        int sum = 0;
        string userInput;

        Console.WriteLine("Enter numbers to add. Type 'done' to finish.");

        while (true) // Infinite loop; will continue until "done" is entered
        {
            Console.Write("Enter a number to add (or 'done' to finish): ");
            userInput = Console.ReadLine();

            if (userInput.ToLower() == "done") // Exit condition for the loop
            {
                break; // Exit the loop
            }

            if (int.TryParse(userInput, out int numberToAdd))
            {
                sum += numberToAdd; // Add valid number to the sum
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }

        Console.WriteLine("The sum of entered numbers is: " + sum);
        Console.WriteLine(); // Blank line for separation


        // --- Example 4: Using a do-while Loop for Input Validation ---
        /*
         * Description:
         * This example uses a `do-while` loop to ensure the user enters a positive number.
         * It works similarly to the previous validation example but uses `do-while`, which guarantees at least one execution.
         * 
         * Sample Input/Output:
         * Enter a positive number: -2
         * Please enter a positive number.
         * Enter a positive number: 5
         * You entered a positive number: 5
         */

        int positiveNumber;

        do
        {
            Console.Write("Enter a positive number: ");
            positiveNumber = int.Parse(Console.ReadLine());

            if (positiveNumber <= 0)
            {
                Console.WriteLine("Please enter a positive number.");
            }

        } while (positiveNumber <= 0); // Condition: Continue until a positive number is entered

        Console.WriteLine("You entered a positive number: " + positiveNumber);
        Console.WriteLine(); // Blank line for separation


        // --- Example 5: Controlled Infinite Loop with do-while ---
        /*
         * Description:
         * This example demonstrates a `do-while` loop that keeps prompting the user until they enter "exit".
         * 
         * Key Concept:
         * The `do-while` loop will run at least once, regardless of the condition.
         * 
         * Sample Input/Output:
         * Type 'exit' to stop the loop: hello
         * You typed: hello
         * Type 'exit' to stop the loop: exit
         * Loop stopped by user command.
         */

        string command;

        do
        {
            Console.Write("Type 'exit' to stop the loop: ");
            command = Console.ReadLine();

            if (command.ToLower() != "exit")
            {
                Console.WriteLine("You typed: " + command);
            }

        } while (command.ToLower() != "exit"); // Loop continues until user types "exit"

        Console.WriteLine("Loop stopped by user command.\n");
    }
}

