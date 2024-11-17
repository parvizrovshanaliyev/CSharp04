namespace QuizGame;

public class QuizGameWithArrayAndMethod
{
    public static void Run()
    {
        /*
         * Task: Modular Quiz Game
         * 
         * Description:
         * Build a modular quiz game using various types of arrays to store questions, options, and answers:
         * - **One-Dimensional Array**: Used for storing the questions.
         * - **Two-Dimensional Array**: Used for storing multiple-choice options for each question.
         * - **One-Dimensional Array**: Used for storing the correct answers.
         * The program validates user input, calculates the score, and provides feedback based on performance.
         * 
         * Features:
         * 1. Modular design for readability and maintainability.
         * 2. Input validation using loops and `int.TryParse`.
         * 3. Arrays for dynamic and efficient storage of questions and answers.
         */

        Console.WriteLine("Welcome to the C# Quiz Game!\n");

        // One-dimensional array for storing questions
        string[] questions = InitializeQuestions();

        // Two-dimensional array for storing options
        string[,] options = InitializeOptions();

        // One-dimensional array for storing correct answers
        int[] correctAnswers = InitializeAnswers();

        // Run the quiz and calculate the score
        int score = RunQuiz(questions, options, correctAnswers);

        // Display the final score and feedback
        DisplayFinalScore(score, correctAnswers.Length);
    }

    /// <summary>
    /// Initializes and returns the one-dimensional array of questions.
    /// </summary>
    static string[] InitializeQuestions()
    {
        return new string[]
        {
            "What is the correct syntax to output 'Hello, World!' in C#?",
            "Which data type is used to store text in C#?",
            "Which operator is used to add two numbers in C#?",
            "How do you declare an integer variable named 'x' with the value 5?",
            "Which keyword is commonly used to create a conditional statement in C#?",
            "How do you start a `while` loop in C#?",
            "Which keyword is used to exit a loop in C#?",
            "Which operator is used to compare two values in C#?",
            "Which operator is used to combine two conditions in C#?",
            "How do you start a `for` loop in C#?",
            "What is the correct syntax for a multi-line comment in C#?",
            "How do you create a variable with a floating point value in C#?",
            "Which of the following is a reference type in C#?",
            "Which is NOT a loop type in C#?",
            "Which syntax is correct for casting an `int` to `double`?"
        };
    }

    /// <summary>
    /// Initializes and returns the two-dimensional array of options.
    /// </summary>
    static string[,] InitializeOptions()
    {
        return new string[,]
        {
            { "print(\"Hello, World!\");", "Console.WriteLine(\"Hello, World!\");", "echo \"Hello, World!\";", "printf(\"Hello, World!\");" },
            { "text", "char", "string", "txt" },
            { "*", "+", "&", "%" },
            { "int x = 5;", "x int = 5;", "int x = \"5\";", "5 = int x;" },
            { "if", "case", "switch", "goto" },
            { "while x > y {}", "while (x > y) {}", "while x > y: {}", "while (x > y):" },
            { "stop", "end", "break", "exit" },
            { "<>", ">", "<<", "||" },
            { "&", "|", "&&", "$$" },
            { "for (int i = 0; i < 5; i++) {}", "for int i = 0 to 5 {}", "foreach (i in range(5)) {}", "for each i = 0; i < 5" },
            { "/* comment */", "// comment", "# comment", "** comment **" },
            { "float f = 5.99f;", "int f = 5.99;", "double f = \"5.99\";", "num f = 5.99f;" },
            { "int", "string", "bool", "char" },
            { "while", "do-while", "foreach", "repeat" },
            { "(double)x", "[double]x", "{double}x", "convert(double, x)" }
        };
    }

    /// <summary>
    /// Initializes and returns the one-dimensional array of correct answers.
    /// </summary>
    static int[] InitializeAnswers()
    {
        return new int[] { 2, 3, 2, 1, 1, 2, 3, 2, 3, 1, 1, 1, 2, 4, 1 };
    }

    /// <summary>
    /// Runs the quiz, collects answers, validates them, and calculates the score.
    /// </summary>
    static int RunQuiz(string[] questions, string[,] options, int[] correctAnswers)
    {
        int score = 0;

        // Iterate through each question
        for (int i = 0; i < questions.Length; i++)
        {
            Console.WriteLine($"\nQuestion {i + 1}: {questions[i]}");

            // Display options for the current question
            for (int j = 0; j < 4; j++)
            {
                Console.WriteLine($"{j + 1}. {options[i, j]}");
            }

            // Get and validate the user's answer
            int userAnswer = GetValidInput(1, 4);

            // Check if the answer is correct
            if (userAnswer == correctAnswers[i])
            {
                Console.WriteLine("Correct!");
                score++;
            }
            else
            {
                Console.WriteLine($"Wrong! The correct answer is {correctAnswers[i]}: {options[i, correctAnswers[i] - 1]}");
            }
        }

        return score;
    }

    /// <summary>
    /// Validates user input to ensure it is within the specified range.
    /// </summary>
    static int GetValidInput(int min, int max)
    {
        int userAnswer;
        bool isValid;
        do
        {
            Console.Write("Enter your answer (1-4): ");
            string input = Console.ReadLine();
            isValid = int.TryParse(input, out userAnswer) && userAnswer >= min && userAnswer <= max;

            if (!isValid)
            {
                Console.WriteLine($"Invalid input. Please enter a number between {min} and {max}.");
            }
        } while (!isValid);

        return userAnswer;
    }

    /// <summary>
    /// Displays the final score and feedback based on the user's performance.
    /// </summary>
    static void DisplayFinalScore(int score, int totalQuestions)
    {
        Console.WriteLine("\nQuiz Complete!");
        Console.WriteLine($"You scored {score} out of {totalQuestions}.");

        if (score == totalQuestions)
        {
            Console.WriteLine("Excellent! You got all the answers right. You're a C# master!");
        }
        else if (score >= totalQuestions * 0.7)
        {
            Console.WriteLine("Great job! You have a strong understanding of C# basics.");
        }
        else if (score >= totalQuestions * 0.4)
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

