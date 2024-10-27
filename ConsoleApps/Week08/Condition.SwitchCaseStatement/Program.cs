namespace Condition.SwitchCaseStatement;

class Program
{
    static void Main()
    {
        /*
     * Example 1: Days of the Week
     *
     * This example takes an integer input (1-7) representing the day of the week
     * and outputs the corresponding weekday name.
     * - If the input matches one of the cases (1 to 7), it prints the correct day.
     * - The `default` case handles any invalid input by printing an error message.
     * 
     * This example is shown in two versions:
     * - Simple Version: Uses a straightforward `switch` without additional conditions.
     * - Version with `when`: Adds extra conditions for each case, demonstrating how `when` can enhance clarity.
     */

        // Simple Version
        Console.Write("Enter a day number (1-7): ");
        int day = int.Parse(Console.ReadLine());

        switch (day)
        {
            case 1:
                Console.WriteLine("Monday");
                break;
            case 2:
                Console.WriteLine("Tuesday");
                break;
            case 3:
                Console.WriteLine("Wednesday");
                break;
            case 4:
                Console.WriteLine("Thursday");
                break;
            case 5:
                Console.WriteLine("Friday");
                break;
            case 6:
                Console.WriteLine("Saturday");
                break;
            case 7:
                Console.WriteLine("Sunday");
                break;
            default:
                Console.WriteLine("Invalid day number.");
                break;
        }

        // Version with `when`
        Console.Write("Enter a day number (1-7): ");
        day = int.Parse(Console.ReadLine());

        switch (day)
        {
            case int n when n == 1:
                Console.WriteLine("Monday");
                break;
            case int n when n == 2:
                Console.WriteLine("Tuesday");
                break;
            case int n when n == 3:
                Console.WriteLine("Wednesday");
                break;
            case int n when n == 4:
                Console.WriteLine("Thursday");
                break;
            case int n when n == 5:
                Console.WriteLine("Friday");
                break;
            case int n when n == 6:
                Console.WriteLine("Saturday");
                break;
            case int n when n == 7:
                Console.WriteLine("Sunday");
                break;
            default:
                Console.WriteLine("Invalid day number.");
                break;
        }

        /*
     * Example 2: Basic Calculator
     * 
     * This example uses a `switch` statement to perform basic arithmetic operations.
     * The user inputs two numbers and an operator (+, -, *, /), and the program calculates
     * the result based on the chosen operator.
     * - Simple Version: Includes direct operations without checking specific conditions.
     * - Version with `when`: Adds a condition to check for division by zero.
     */

        // Simple Version
        Console.Write("Enter the first number: ");
        double num1 = double.Parse(Console.ReadLine());

        Console.Write("Enter an operator (+, -, *, /): ");
        char op = Console.ReadLine()[0];

        Console.Write("Enter the second number: ");
        double num2 = double.Parse(Console.ReadLine());

        switch (op)
        {
            case '+':
                Console.WriteLine($"Result: {num1 + num2}");
                break;
            case '-':
                Console.WriteLine($"Result: {num1 - num2}");
                break;
            case '*':
                Console.WriteLine($"Result: {num1 * num2}");
                break;
            case '/':
                if (num2 != 0)
                    Console.WriteLine($"Result: {num1 / num2}");
                else
                    Console.WriteLine("Cannot divide by zero.");
                break;
            default:
                Console.WriteLine("Invalid operator.");
                break;
        }

        // Version with `when`
        Console.Write("Enter the first number: ");
        num1 = double.Parse(Console.ReadLine());

        Console.Write("Enter an operator (+, -, *, /): ");
        op = Console.ReadLine()[0];

        Console.Write("Enter the second number: ");
        num2 = double.Parse(Console.ReadLine());

        switch (op)
        {
            case '+' when num2 >= 0:
                Console.WriteLine($"Result: {num1 + num2}");
                break;
            case '-' when num2 >= 0:
                Console.WriteLine($"Result: {num1 - num2}");
                break;
            case '*':
                Console.WriteLine($"Result: {num1 * num2}");
                break;
            case '/' when num2 != 0:
                Console.WriteLine($"Result: {num1 / num2}");
                break;
            case '/' when num2 == 0:
                Console.WriteLine("Cannot divide by zero.");
                break;
            default:
                Console.WriteLine("Invalid operator.");
                break;
        }

        /*
     * Example 3: Season Checker
     * 
     * This example takes a month number (1-12) and outputs the corresponding season.
     * - Simple Version: Groups `case` statements to map month ranges to seasons.
     * - Version with `when`: Adds conditions for each season range for readability.
     */

        // Simple Version
        Console.Write("Enter a month number (1-12): ");
        int month = int.Parse(Console.ReadLine());

        switch (month)
        {
            case 12:
            case 1:
            case 2:
                Console.WriteLine("Winter");
                break;
            case 3:
            case 4:
            case 5:
                Console.WriteLine("Spring");
                break;
            case 6:
            case 7:
            case 8:
                Console.WriteLine("Summer");
                break;
            case 9:
            case 10:
            case 11:
                Console.WriteLine("Autumn");
                break;
            default:
                Console.WriteLine("Invalid month number.");
                break;
        }

        // Version with `when`
        Console.Write("Enter a month number (1-12): ");
        month = int.Parse(Console.ReadLine());

        switch (month)
        {
            case int n when (n == 12 || n == 1 || n == 2):
                Console.WriteLine("Winter");
                break;
            case int n when (n >= 3 && n <= 5):
                Console.WriteLine("Spring");
                break;
            case int n when (n >= 6 && n <= 8):
                Console.WriteLine("Summer");
                break;
            case int n when (n >= 9 && n <= 11):
                Console.WriteLine("Autumn");
                break;
            default:
                Console.WriteLine("Invalid month number.");
                break;
        }

        /*
     * Example 4: Grade Evaluation
     * 
     * This example evaluates a letter grade input and provides feedback based on the grade.
     * - Simple Version: Directly matches grade cases.
     * - Version with `when`: Adds conditions to each `case` for additional flexibility.
     */

        // Simple Version
        Console.Write("Enter your grade (A, B, C, D, F): ");
        char grade = Console.ReadLine().ToUpper()[0];

        switch (grade)
        {
            case 'A':
                Console.WriteLine("Excellent!");
                break;
            case 'B':
                Console.WriteLine("Good job!");
                break;
            case 'C':
                Console.WriteLine("Fair.");
                break;
            case 'D':
                Console.WriteLine("Needs improvement.");
                break;
            case 'F':
                Console.WriteLine("Failed.");
                break;
            default:
                Console.WriteLine("Invalid grade.");
                break;
        }

        // Version with `when`
        Console.Write("Enter your grade (A, B, C, D, F): ");
        grade = Console.ReadLine().ToUpper()[0];

        switch (grade)
        {
            case char g when g == 'A':
                Console.WriteLine("Excellent!");
                break;
            case char g when g == 'B':
                Console.WriteLine("Good job!");
                break;
            case char g when g == 'C':
                Console.WriteLine("Fair.");
                break;
            case char g when g == 'D':
                Console.WriteLine("Needs improvement.");
                break;
            case char g when g == 'F':
                Console.WriteLine("Failed.");
                break;
            default:
                Console.WriteLine("Invalid grade.");
                break;
        }

        /*
     * Example 5: Menu Selection
     * 
     * This example shows a menu selection based on an integer option input.
     * - Simple Version: Matches each option to an action without any additional conditions.
     * - Version with `when`: Uses `when` for additional conditional checks on each option.
     */

        // Simple Version
        Console.WriteLine("Menu:");
        Console.WriteLine("1. View Balance");
        Console.WriteLine("2. Deposit Funds");
        Console.WriteLine("3. Withdraw Funds");
        Console.WriteLine("4. Exit");

        Console.Write("Select an option (1-4): ");
        int option = int.Parse(Console.ReadLine());

        switch (option)
        {
            case 1:
                Console.WriteLine("Viewing Balance...");
                break;
            case 2:
                Console.WriteLine("Depositing Funds...");
                break;
            case 3:
                Console.WriteLine("Withdrawing Funds...");
                break;
            case 4:
                Console.WriteLine("Exiting...");
                break;
            default:
                Console.WriteLine("Invalid option.");
                break;
        }

        // Version with `when`
        Console.WriteLine("Menu:");
        Console.WriteLine("1. View Balance");
        Console.WriteLine("2. Deposit Funds");
        Console.WriteLine("3. Withdraw Funds");
        Console.WriteLine("4. Exit");

        Console.Write("Select an option (1-4): ");
        option = int.Parse(Console.ReadLine());

        switch (option)
        {
            case int n when n == 1:
                Console.WriteLine("Viewing Balance...");
                break;
            case int n when n == 2:
                Console.WriteLine("Depositing Funds...");
                break;
            case int n when n == 3:
                Console.WriteLine("Withdrawing Funds...");
                break;
            case int n when n == 4:
                Console.WriteLine("Exiting...");
                break;
            default:
                Console.WriteLine("Invalid option.");
                break;
        }
    }
}