namespace Condition.IfStatement;

class Program
{
    static void Main()
    {
        /* 
     * Example 1: Simple if-else statement
     * Checks if a number entered by the user is greater than 5.
     */
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());

        if (number > 5)
        {
            Console.WriteLine("The number is greater than 5.");
        }
        else
        {
            Console.WriteLine("The number is 5 or less.");
        }

        /* 
     * Example 2: if-else if-else statement
     * Categorizes a number based on user input:
     * - Greater than 10, prints "The number is greater than 10."
     * - Between 6 and 10, prints "The number is greater than 5 but 10 or less."
     * - Else, prints "The number is 5 or less."
     */
        Console.Write("Enter another number: ");
        int anotherNumber = int.Parse(Console.ReadLine());

        if (anotherNumber > 10)
        {
            Console.WriteLine("The number is greater than 10.");
        }
        else if (anotherNumber > 5)
        {
            Console.WriteLine("The number is greater than 5 but 10 or less.");
        }
        else
        {
            Console.WriteLine("The number is 5 or less.");
        }

        /* 
     * Example 3: Age Classification with if-else if-else statements
     * This example categorizes a person's age group:
     * - If the age is less than 13, it prints "You are a child."
     * - If the age is between 13 and 19, it prints "You are a teenager."
     * - If the age is between 20 and 64, it prints "You are an adult."
     * - If none of the above, it defaults to "You are a senior."
     *
     * Flowchart:
     *              Start
     *                |
     *           [age < 13]
     *            if true
     *               |
     *       "You are a child"
     *                |
     *          if false
     *               |
     *       [13 <= age <= 19]
     *            if true
     *               |
     *     "You are a teenager"
     *                |
     *          if false
     *               |
     *       [20 <= age <= 64]
     *            if true
     *               |
     *     "You are an adult"
     *                |
     *          if false
     *               |
     *     "You are a senior"
     */
        Console.Write("Enter your age: ");
        int age = int.Parse(Console.ReadLine());

        if (age < 13)
        {
            Console.WriteLine("You are a child.");
        }
        else if (age >= 13 && age <= 19)
        {
            Console.WriteLine("You are a teenager.");
        }
        else if (age >= 20 && age <= 64)
        {
            Console.WriteLine("You are an adult.");
        }
        else
        {
            Console.WriteLine("You are a senior.");
        }

        /* 
     * Example 4: Temperature Ranges
     * This example categorizes temperature into different ranges:
     * - If temperature is below 0, it prints "It's freezing cold."
     * - If temperature is between 0 and 9, it prints "It's cold."
     * - If temperature is between 10 and 19, it prints "It's cool."
     * - If temperature is between 20 and 29, it prints "It's warm."
     * - If none of the above, it defaults to "It's hot."
     */
        Console.Write("Enter the temperature: ");
        int temperature = int.Parse(Console.ReadLine());

        if (temperature < 0)
        {
            Console.WriteLine("It's freezing cold.");
        }
        else if (temperature >= 0 && temperature < 10)
        {
            Console.WriteLine("It's cold.");
        }
        else if (temperature >= 10 && temperature < 20)
        {
            Console.WriteLine("It's cool.");
        }
        else if (temperature >= 20 && temperature < 30)
        {
            Console.WriteLine("It's warm.");
        }
        else
        {
            Console.WriteLine("It's hot.");
        }

        /* 
     * Example 5: Exam Grading System
     * Grades a student based on their score entered by the user.
     */
        Console.Write("Enter your exam score: ");
        int score = int.Parse(Console.ReadLine());

        if (score >= 90)
        {
            Console.WriteLine("Grade: A");
        }
        else if (score >= 80)
        {
            Console.WriteLine("Grade: B");
        }
        else if (score >= 70)
        {
            Console.WriteLine("Grade: C");
        }
        else if (score >= 60)
        {
            Console.WriteLine("Grade: D");
        }
        else
        {
            Console.WriteLine("Grade: F");
        }

        /* 
     * Example 6: Discount Eligibility
     * Checks eligibility for a discount based on user input.
     */
        Console.Write("Enter your age: ");
        int customerAge = int.Parse(Console.ReadLine());

        Console.Write("Are you a student? (yes/no): ");
        bool isStudent = Console.ReadLine().ToLower() == "yes";

        Console.Write("Are you a veteran? (yes/no): ");
        bool isVeteran = Console.ReadLine().ToLower() == "yes";

        if (customerAge >= 65)
        {
            Console.WriteLine("Eligible for senior discount.");
        }
        else if (isStudent)
        {
            Console.WriteLine("Eligible for student discount.");
        }
        else if (isVeteran)
        {
            Console.WriteLine("Eligible for veteran discount.");
        }
        else
        {
            Console.WriteLine("No discount available.");
        }

        /* 
     * Example 7: Login System
     * Simulates a login system by checking username and password entered by the user.
     */
        string username = "admin";
        string password = "password123";

        Console.Write("Enter username: ");
        string inputUsername = Console.ReadLine();

        Console.Write("Enter password: ");
        string inputPassword = Console.ReadLine();

        if (inputUsername == username && inputPassword == password)
        {
            Console.WriteLine("Login successful.");
        }
        else if (inputUsername == username)
        {
            Console.WriteLine("Incorrect password.");
        }
        else
        {
            Console.WriteLine("User not found.");
        }
    }
}