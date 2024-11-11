using System;

namespace Practice
{
    class Program
    {
        static void Main()
        {
            // Task 1: Print Multiplication Table Using a For Loop
            /*
             * Description:
             * Write a program that prompts the user to enter a number, then prints the multiplication table for that number up to 10.
             *
             * Explanation:
             * Use a `for` loop to iterate from 1 to 10 and multiply the user’s input by each value in the loop.
             *
             * Sample Input and Output:
             *   Enter a number: 5
             *   Output:
             *   5 x 1 = 5
             *   5 x 2 = 10
             *   5 x 3 = 15
             *   ...
             *   5 x 10 = 50
             */
            int number;
            Console.Write("Enter a number for the multiplication table: ");
            while (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.Write("Invalid input. Enter a valid integer: ");
            }
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"{number} x {i} = {number * i}");
            }
            Console.WriteLine();

            // Task 2: Sum of First N Numbers Using a While Loop
            /*
             * Description:
             * Ask the user to enter a positive integer N and calculate the sum of the first N natural numbers.
             *
             * Explanation:
             * Use a `while` loop to add each number from 1 to N to a running total.
             *
             * Sample Input and Output:
             *   Enter a positive integer: 5
             *   Output: The sum of the first 5 numbers is 15
             */
            int n;
            Console.Write("Enter a positive integer to calculate the sum: ");
            while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
            {
                Console.Write("Invalid input. Enter a valid positive integer: ");
            }
            int sum = 0, count = 1;
            while (count <= n)
            {
                sum += count;
                count++;
            }
            Console.WriteLine($"The sum of the first {n} numbers is {sum}");
            Console.WriteLine();

            // Task 3: Find Factorial of a Number Using a For Loop
            /*
             * Description:
             * Write a program that calculates the factorial of a number entered by the user.
             *
             * Explanation:
             * Factorial of N (written as N!) is calculated as N * (N - 1) * ... * 1.
             * Use a `for` loop to multiply each number from 1 to N.
             *
             * Sample Input and Output:
             *   Enter a positive integer: 4
             *   Output: The factorial of 4 is 24
             */
            int factorialNumber;
            Console.Write("Enter a non-negative integer for factorial calculation: ");
            while (!int.TryParse(Console.ReadLine(), out factorialNumber) || factorialNumber < 0)
            {
                Console.Write("Invalid input. Enter a non-negative integer: ");
            }
            int factorial = 1;
            for (int i = 1; i <= factorialNumber; i++)
            {
                factorial *= i;
            }
            Console.WriteLine($"The factorial of {factorialNumber} is {factorial}");
            Console.WriteLine();

            // Task 4: Count Down from N to 1 Using a Do-While Loop
            /*
             * Description:
             * Prompt the user to enter a positive integer N, then print all numbers from N down to 1.
             *
             * Explanation:
             * Use a `do-while` loop that starts at N and decreases by 1 in each iteration until it reaches 1.
             *
             * Sample Input and Output:
             *   Enter a positive integer: 5
             *   Output:
             *   5
             *   4
             *   3
             *   2
             *   1
             */
            int countdown;
            Console.Write("Enter a positive integer to count down: ");
            while (!int.TryParse(Console.ReadLine(), out countdown) || countdown <= 0)
            {
                Console.Write("Invalid input. Enter a valid positive integer: ");
            }
            do
            {
                Console.WriteLine(countdown);
                countdown--;
            } while (countdown >= 1);
            Console.WriteLine();

            // Task 5: Count Occurrences of a Character Using Foreach Loop with Continue
            /*
             * Description:
             * Ask the user to enter a string and a character, then count how many times the character appears in the string.
             *
             * Explanation:
             * Use a `foreach` loop to iterate through each character in the string.
             * Use `continue` to skip characters that don’t match the specified character.
             *
             * Sample Input and Output:
             *   Enter a string: Mississippi
             *   Enter a character to count: s
             *   Output: The character 's' appears 4 times.
             */
            Console.Write("Enter a string: ");
            string inputString = Console.ReadLine();
            char charToCount;
            Console.Write("Enter a character to count: ");
            while (!char.TryParse(Console.ReadLine(), out charToCount))
            {
                Console.Write("Invalid input. Enter a single character: ");
            }
            int charCount = 0;
            foreach (char c in inputString)
            {
                if (c != charToCount)
                    continue;
                charCount++;
            }
            Console.WriteLine($"The character '{charToCount}' appears {charCount} times.");
            Console.WriteLine();

            // Task 6: Calculate the Average of N Numbers Using For Loop with Break
            /*
             * Description:
             * Ask the user for a number N and then ask them to input N numbers, calculating the average.
             * Stop input if the user enters 0.
             *
             * Explanation:
             * Use a `for` loop to accumulate a sum of N numbers, and use `break` if the user enters 0.
             *
             * Sample Input and Output:
             *   Enter the number of values: 3
             *   Enter number 1: 5
             *   Enter number 2: 0
             *   Output: Input stopped early. The average is 5
             */
            int totalNumbers;
            Console.Write("Enter the number of values: ");
            while (!int.TryParse(Console.ReadLine(), out totalNumbers) || totalNumbers <= 0)
            {
                Console.Write("Invalid input. Enter a positive integer: ");
            }
            int sumValues = 0, enteredCount = 0;
            for (int i = 1; i <= totalNumbers; i++)
            {
                int value;
                Console.Write($"Enter number {i}: ");
                while (!int.TryParse(Console.ReadLine(), out value))
                {
                    Console.Write("Invalid input. Enter a valid integer: ");
                }
                if (value == 0)
                {
                    Console.WriteLine("Input stopped early.");
                    break;
                }
                sumValues += value;
                enteredCount++;
            }
            if (enteredCount > 0)
            {
                double average = (double)sumValues / enteredCount;
                Console.WriteLine($"The average is {average}");
            }
            else
            {
                Console.WriteLine("No valid numbers entered.");
            }
            Console.WriteLine();

            // Task 7: Find the Largest Number Using a For Loop
            /*
             * Description:
             * Prompt the user to enter a number N for how many numbers they’d like to input. Then ask for each number and determine the largest among them.
             *
             * Explanation:
             * Use a `for` loop to compare each entered number to the current largest number.
             *
             * Sample Input and Output:
             *   How many numbers will you enter? 4
             *   Enter number 1: 5
             *   Enter number 2: 10
             *   Enter number 3: 3
             *   Enter number 4: 8
             *   Output: The largest number is 10
             */
            int numCount;
            Console.Write("How many numbers will you enter? ");
            while (!int.TryParse(Console.ReadLine(), out numCount) || numCount <= 0)
            {
                Console.Write("Invalid input. Enter a positive integer: ");
            }
            int largest = int.MinValue;
            for (int i = 1; i <= numCount; i++)
            {
                int currentNumber;
                Console.Write($"Enter number {i}: ");
                while (!int.TryParse(Console.ReadLine(), out currentNumber))
                {
                    Console.Write("Invalid input. Enter a valid integer: ");
                }
                if (currentNumber > largest)
                {
                    largest = currentNumber;
                }
            }
            Console.WriteLine($"The largest number is {largest}");
            Console.WriteLine();

            // Task 8: Check if a Number is Prime Using a For Loop with Break
            /*
             * Description:
             * Write a program that prompts the user to enter a positive integer and checks if it’s a prime number.
             *
             * Explanation:
             * A prime number has no divisors other than 1 and itself.
             * Use a `for` loop to check if any number from 2 to N-1 divides N evenly.
             * Use `break` if a divisor is found, indicating the number is not prime.
             *
             * Sample Input and Output:
             *   Enter a positive integer: 7
             *   Output: 7 is a prime number.
             */
            int primeNumber;
            Console.Write("Enter a positive integer to check if it's prime: ");
            while (!int.TryParse(Console.ReadLine(), out primeNumber) || primeNumber <= 1)
            {
                Console.Write("Invalid input. Enter an integer greater than 1: ");
            }
            bool isPrime = true;
            for (int i = 2; i < primeNumber; i++)
            {
                if (primeNumber % i == 0)
                {
                    isPrime = false;
                    break;
                }
            }
            Console.WriteLine(isPrime ? $"{primeNumber} is a prime number." : $"{primeNumber} is not a prime number.");
            Console.WriteLine();

            // Task 9: Print Multiples of a Number Up to N Using While Loop with Continue
            /*
             * Description:
             * Write a program that asks for two numbers: a base number and a limit N. Print all multiples of the base number up to N.
             *
             * Explanation:
             * Use a `while` loop to print multiples of the base number up to N.
             * Use `continue` if the current number is not a multiple of the base number.
             *
             * Sample Input and Output:
             *   Enter the base number: 3
             *   Enter the limit: 20
             *   Output:
             *   3
             *   6
             *   9
             *   12
             *   15
             *   18
             */
            int baseNumber, limit;
            Console.Write("Enter the base number: ");
            while (!int.TryParse(Console.ReadLine(), out baseNumber) || baseNumber <= 0)
            {
                Console.Write("Invalid input. Enter a positive integer: ");
            }
            Console.Write("Enter the limit: ");
            while (!int.TryParse(Console.ReadLine(), out limit) || limit < baseNumber)
            {
                Console.Write("Invalid input. Enter a positive integer greater than or equal to the base number: ");
            }
            int multiple = baseNumber;
            while (multiple <= limit)
            {
                Console.WriteLine(multiple);
                multiple += baseNumber;
            }
            Console.WriteLine();

            // Task 10: Reverse a String Using a For Loop
            /*
             * Description:
             * Ask the user to enter a string and display it in reverse order.
             *
             * Explanation:
             * Use a `for` loop to iterate through the string from the end to the beginning, constructing the reversed version.
             *
             * Sample Input and Output:
             *   Enter a string: Hello
             *   Output: Reversed string: olleH
             */
            Console.Write("Enter a string to reverse: ");
            string inputString2 = Console.ReadLine();
            string reversedString = "";
            for (int i = inputString2.Length - 1; i >= 0; i--)
            {
                reversedString += inputString2[i];
            }
            Console.WriteLine($"Reversed string: {reversedString}");
            Console.WriteLine();

            // Task 11: Find the First Multiple of 7 Using a For Loop with Break
            /*
             * Description:
             * Prompt the user to enter a positive integer N, then use a loop to find the first multiple of 7 between 1 and N.
             *
             * Explanation:
             * Use a `for` loop to iterate from 1 to N.
             * Check if each number is divisible by 7. If true, display the number and use `break` to exit the loop.
             *
             * Sample Input and Output:
             *   Enter a positive integer: 20
             *   Output: The first multiple of 7 between 1 and 20 is 7
             */
            int maxLimit;
            Console.Write("Enter a positive integer to find the first multiple of 7: ");
            while (!int.TryParse(Console.ReadLine(), out maxLimit) || maxLimit <= 0)
            {
                Console.Write("Invalid input. Enter a positive integer: ");
            }
            bool foundMultiple = false;
            for (int i = 1; i <= maxLimit; i++)
            {
                if (i % 7 == 0)
                {
                    Console.WriteLine($"The first multiple of 7 between 1 and {maxLimit} is {i}");
                    foundMultiple = true;
                    break;
                }
            }
            if (!foundMultiple)
            {
                Console.WriteLine($"There is no multiple of 7 between 1 and {maxLimit}");
            }
            Console.WriteLine();

            // Task 12: Print Odd Numbers Using a For Loop with Continue
            /*
             * Description:
             * Write a program that prompts the user to enter a positive integer N and then prints all odd numbers from 1 to N.
             *
             * Explanation:
             * Use a `for` loop to iterate from 1 to N.
             * Use `continue` to skip even numbers and only print odd numbers.
             *
             * Sample Input and Output:
             *   Enter a positive integer: 10
             *   Output:
             *   1
             *   3
             *   5
             *   7
             *   9
             */
            int upperLimit;
            Console.Write("Enter a positive integer to display all odd numbers up to that number: ");
            while (!int.TryParse(Console.ReadLine(), out upperLimit) || upperLimit <= 0)
            {
                Console.Write("Invalid input. Enter a positive integer: ");
            }
            for (int i = 1; i <= upperLimit; i++)
            {
                if (i % 2 == 0)
                {
                    continue;
                }
                Console.WriteLine(i);
            }
            Console.WriteLine();
        }
    }
}
