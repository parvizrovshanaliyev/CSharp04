namespace QuizGame;

class Program
{
    static void Main(string[] args)
    {
        /*
     * Task: Quiz Game
     * 
     * Description:
     * Create a quiz game to test basic C# concepts. Each question is presented one at a time.
     * - Display each question and its options.
     * - Validate user input (ensure it’s a number between 1 and 4).
     * - Check if the answer is correct and update the score.
     * - Display the total score and feedback at the end.
     * 
     * Sample Input and Output:
     * Question 1: What is the correct syntax to output "Hello, World!" in C#?
     * 1. print("Hello, World!");
     * 2. Console.WriteLine("Hello, World!");
     * 3. echo "Hello, World!";
     * 4. printf("Hello, World!");
     * Enter your answer (1-4): 2
     * Correct!
     * ...
     * Quiz Complete! You scored 12 out of 15.
     * Feedback: Great work! Keep practicing.
     */

        int score = 0; // Initialize the user's score.

        // Question 1
        Console.WriteLine("\nQuestion 1: What is the correct syntax to output 'Hello, World!' in C#?");
        Console.WriteLine("1. print(\"Hello, World!\");");
        Console.WriteLine("2. Console.WriteLine(\"Hello, World!\");");
        Console.WriteLine("3. echo \"Hello, World!\";");
        Console.WriteLine("4. printf(\"Hello, World!\");");

        int userAnswer;
        bool isValid;
        do
        {
            Console.Write("Enter your answer (1-4): ");
            string input = Console.ReadLine();
            isValid = int.TryParse(input, out userAnswer) && userAnswer >= 1 && userAnswer <= 4;

            if (!isValid)
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
            }
        } while (!isValid);

        if (userAnswer == 2) score++;

        // Question 2
        Console.WriteLine("\nQuestion 2: Which data type is used to store text in C#?");
        Console.WriteLine("1. text");
        Console.WriteLine("2. char");
        Console.WriteLine("3. string");
        Console.WriteLine("4. txt");

        do
        {
            Console.Write("Enter your answer (1-4): ");
            string input = Console.ReadLine();
            isValid = int.TryParse(input, out userAnswer) && userAnswer >= 1 && userAnswer <= 4;

            if (!isValid)
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
            }
        } while (!isValid);

        if (userAnswer == 3) score++;

        // Question 3
        Console.WriteLine("\nQuestion 3: Which operator is used to add two numbers in C#?");
        Console.WriteLine("1. *");
        Console.WriteLine("2. +");
        Console.WriteLine("3. &");
        Console.WriteLine("4. %");

        do
        {
            Console.Write("Enter your answer (1-4): ");
            string input = Console.ReadLine();
            isValid = int.TryParse(input, out userAnswer) && userAnswer >= 1 && userAnswer <= 4;

            if (!isValid)
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
            }
        } while (!isValid);

        if (userAnswer == 2) score++;

        // Question 4
        Console.WriteLine("\nQuestion 4: How do you declare an integer variable named 'x' with the value 5?");
        Console.WriteLine("1. int x = 5;");
        Console.WriteLine("2. x int = 5;");
        Console.WriteLine("3. int x = \"5\";");
        Console.WriteLine("4. 5 = int x;");

        do
        {
            Console.Write("Enter your answer (1-4): ");
            string input = Console.ReadLine();
            isValid = int.TryParse(input, out userAnswer) && userAnswer >= 1 && userAnswer <= 4;

            if (!isValid)
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
            }
        } while (!isValid);

        if (userAnswer == 1) score++;

        // Question 5
        Console.WriteLine("\nQuestion 5: Which keyword is commonly used to create a conditional statement in C#?");
        Console.WriteLine("1. if");
        Console.WriteLine("2. case");
        Console.WriteLine("3. switch");
        Console.WriteLine("4. goto");

        do
        {
            Console.Write("Enter your answer (1-4): ");
            string input = Console.ReadLine();
            isValid = int.TryParse(input, out userAnswer) && userAnswer >= 1 && userAnswer <= 4;

            if (!isValid)
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
            }
        } while (!isValid);

        if (userAnswer == 1) score++;

        // Question 6
        Console.WriteLine("\nQuestion 6: How do you start a `while` loop in C#?");
        Console.WriteLine("1. while x > y {}");
        Console.WriteLine("2. while (x > y) {}");
        Console.WriteLine("3. while x > y: {}");
        Console.WriteLine("4. while (x > y):");

        do
        {
            Console.Write("Enter your answer (1-4): ");
            string input = Console.ReadLine();
            isValid = int.TryParse(input, out userAnswer) && userAnswer >= 1 && userAnswer <= 4;

            if (!isValid)
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
            }
        } while (!isValid);

        if (userAnswer == 2) score++;

        // Question 7
        Console.WriteLine("\nQuestion 7: Which keyword is used to exit a loop in C#?");
        Console.WriteLine("1. stop");
        Console.WriteLine("2. end");
        Console.WriteLine("3. break");
        Console.WriteLine("4. exit");

        do
        {
            Console.Write("Enter your answer (1-4): ");
            string input = Console.ReadLine();
            isValid = int.TryParse(input, out userAnswer) && userAnswer >= 1 && userAnswer <= 4;

            if (!isValid)
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
            }
        } while (!isValid);

        if (userAnswer == 3) score++;

        // Question 8
        Console.WriteLine("\nQuestion 8: Which operator is used to compare two values in C#?");
        Console.WriteLine("1. <>");
        Console.WriteLine("2. >");
        Console.WriteLine("3. <<");
        Console.WriteLine("4. ||");

        do
        {
            Console.Write("Enter your answer (1-4): ");
            string input = Console.ReadLine();
            isValid = int.TryParse(input, out userAnswer) && userAnswer >= 1 && userAnswer <= 4;

            if (!isValid)
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
            }
        } while (!isValid);

        if (userAnswer == 2) score++;

        // Question 9
        Console.WriteLine("\nQuestion 9: Which operator is used to combine two conditions in C#?");
        Console.WriteLine("1. &");
        Console.WriteLine("2. |");
        Console.WriteLine("3. &&");
        Console.WriteLine("4. $$");

        do
        {
            Console.Write("Enter your answer (1-4): ");
            string input = Console.ReadLine();
            isValid = int.TryParse(input, out userAnswer) && userAnswer >= 1 && userAnswer <= 4;

            if (!isValid)
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
            }
        } while (!isValid);

        if (userAnswer == 3) score++;

        // Question 10
        Console.WriteLine("\nQuestion 10: How do you start a `for` loop in C#?");
        Console.WriteLine("1. for (int i = 0; i < 5; i++) {}");
        Console.WriteLine("2. for int i = 0 to 5 {}");
        Console.WriteLine("3. foreach (i in range(5)) {}");
        Console.WriteLine("4. for each i = 0; i < 5");

        do
        {
            Console.Write("Enter your answer (1-4): ");
            string input = Console.ReadLine();
            isValid = int.TryParse(input, out userAnswer) && userAnswer >= 1 && userAnswer <= 4;

            if (!isValid)
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
            }
        } while (!isValid);

        if (userAnswer == 1) score++;

        // Question 11
        Console.WriteLine("\nQuestion 11: What is the correct syntax for a multi-line comment in C#?");
        Console.WriteLine("1. /* comment */");
        Console.WriteLine("2. // comment");
        Console.WriteLine("3. # comment");
        Console.WriteLine("4. ** comment **");

        do
        {
            Console.Write("Enter your answer (1-4): ");
            string input = Console.ReadLine();
            isValid = int.TryParse(input, out userAnswer) && userAnswer >= 1 && userAnswer <= 4;

            if (!isValid)
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
            }
        } while (!isValid);

        if (userAnswer == 1) score++;

        // Question 12
        Console.WriteLine("\nQuestion 12: How do you create a variable with a floating point value in C#?");
        Console.WriteLine("1. float f = 5.99f;");
        Console.WriteLine("2. int f = 5.99;");
        Console.WriteLine("3. double f = \"5.99\";");
        Console.WriteLine("4. num f = 5.99f;");

        do
        {
            Console.Write("Enter your answer (1-4): ");
            string input = Console.ReadLine();
            isValid = int.TryParse(input, out userAnswer) && userAnswer >= 1 && userAnswer <= 4;

            if (!isValid)
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
            }
        } while (!isValid);

        if (userAnswer == 1) score++;

        // Question 13
        Console.WriteLine("\nQuestion 13: Which of the following is a reference type in C#?");
        Console.WriteLine("1. int");
        Console.WriteLine("2. string");
        Console.WriteLine("3. bool");
        Console.WriteLine("4. char");

        do
        {
            Console.Write("Enter your answer (1-4): ");
            string input = Console.ReadLine();
            isValid = int.TryParse(input, out userAnswer) && userAnswer >= 1 && userAnswer <= 4;

            if (!isValid)
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
            }
        } while (!isValid);

        if (userAnswer == 2) score++;

        // Question 14
        Console.WriteLine("\nQuestion 14: Which is NOT a loop type in C#?");
        Console.WriteLine("1. while");
        Console.WriteLine("2. do-while");
        Console.WriteLine("3. foreach");
        Console.WriteLine("4. repeat");

        do
        {
            Console.Write("Enter your answer (1-4): ");
            string input = Console.ReadLine();
            isValid = int.TryParse(input, out userAnswer) && userAnswer >= 1 && userAnswer <= 4;

            if (!isValid)
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
            }
        } while (!isValid);

        if (userAnswer == 4) score++;

        // Question 15
        Console.WriteLine("\nQuestion 15: Which syntax is correct for casting an `int` to `double`?");
        Console.WriteLine("1. (double)x");
        Console.WriteLine("2. [double]x");
        Console.WriteLine("3. {double}x");
        Console.WriteLine("4. convert(double, x)");

        do
        {
            Console.Write("Enter your answer (1-4): ");
            string input = Console.ReadLine();
            isValid = int.TryParse(input, out userAnswer) && userAnswer >= 1 && userAnswer <= 4;

            if (!isValid)
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
            }
        } while (!isValid);

        if (userAnswer == 1) score++;


        // Display the final score and feedback
        Console.WriteLine("\nQuiz Complete!");
        Console.WriteLine($"You scored {score} out of 15.");

        if (score == 15)
        {
            Console.WriteLine("Excellent! You got all the answers right. You're a C# master!");
        }
        else if (score >= 10)
        {
            Console.WriteLine("Great job! You have a strong understanding of C# basics.");
        }
        else if (score >= 5)
        {
            Console.WriteLine("Not bad! Keep practicing to improve your skills.");
        }
        else
        {
            Console.WriteLine("Don't worry! Review the material and try again to learn more.");
        }

        Console.WriteLine("Thank you for playing the C# Quiz Game!");
    }
}