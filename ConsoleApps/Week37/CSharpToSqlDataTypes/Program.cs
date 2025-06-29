using CSharpToSqlDataTypes.Services;
using CSharpToSqlDataTypes.Enums;
using CSharpToSqlDataTypes.Constants;

namespace CSharpToSqlDataTypes
{
    /// <summary>
    /// Main program class for the C# to SQL Data Types Learning System.
    /// This application provides comprehensive information about C# and SQL data types,
    /// their mappings, best practices, and learning resources.
    /// </summary>
    class Program
    {
        /// <summary>
        /// The main entry point of the application.
        /// </summary>
        /// <param name="args">Command line arguments (not used).</param>
        static void Main(string[] args)
        {
            try
            {
                // Initialize services
                var comparisonService = new DataTypeComparisonService();
                var uiService = new UserInterfaceService(comparisonService);

                // Display welcome message
                DisplayWelcomeMessage();

                // Main application loop
                RunApplication(uiService);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }

        /// <summary>
        /// Displays the welcome message and application information.
        /// </summary>
        static void DisplayWelcomeMessage()
        {
            Console.Clear();
            Console.WriteLine(ApplicationConstants.ApplicationTitle);
            Console.WriteLine(ApplicationConstants.ApplicationSubtitle);
            Console.WriteLine(ApplicationConstants.ApplicationVersion);
            Console.WriteLine(ApplicationConstants.SeparatorLine);
            Console.WriteLine();

            Console.WriteLine("Welcome to the C# to SQL Data Types Learning System!");
            Console.WriteLine();
            Console.WriteLine("This application helps you:");
            Console.WriteLine("• Learn about C# and SQL data types");
            Console.WriteLine("• Understand data type mappings between C# and SQL");
            Console.WriteLine("• Find equivalent data types");
            Console.WriteLine("• View conversion examples and best practices");
            Console.WriteLine("• Search for specific data type information");
            Console.WriteLine();

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        /// <summary>
        /// Runs the main application loop.
        /// </summary>
        /// <param name="uiService">The user interface service.</param>
        static void RunApplication(UserInterfaceService uiService)
        {
            bool continueRunning = true;

            while (continueRunning)
            {
                try
                {
                    // Display main menu and get user choice
                    var choice = uiService.DisplayMainMenu();

                    // Process user choice
                    switch (choice)
                    {
                        case MenuOption.ViewCSharpDataTypes:
                            uiService.DisplayCSharpDataTypes();
                            break;

                        case MenuOption.ViewSqlDataTypes:
                            uiService.DisplaySqlDataTypes();
                            break;

                        case MenuOption.CompareDataTypes:
                            uiService.DisplayDataTypeComparison();
                            break;

                        case MenuOption.FindSqlEquivalent:
                            uiService.FindSqlEquivalent();
                            break;

                        case MenuOption.FindCSharpEquivalent:
                            uiService.FindCSharpEquivalent();
                            break;

                        case MenuOption.ViewConversionExamples:
                            uiService.DisplayConversionExamples();
                            break;

                        case MenuOption.TakeQuiz:
                            DisplayQuizNotImplemented();
                            break;

                        case MenuOption.ViewBestPractices:
                            uiService.DisplayBestPractices();
                            break;

                        case MenuOption.SearchDataTypes:
                            uiService.SearchDataTypes();
                            break;

                        case MenuOption.ViewSizeAndRanges:
                            uiService.DisplaySizeAndRanges();
                            break;

                        case MenuOption.Exit:
                            continueRunning = false;
                            DisplayExitMessage();
                            break;

                        default:
                            Console.WriteLine(ApplicationConstants.InvalidChoiceError);
                            Console.WriteLine(ApplicationConstants.PressAnyKeyMessage);
                            Console.ReadKey();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    Console.WriteLine(ApplicationConstants.PressAnyKeyMessage);
                    Console.ReadKey();
                }
            }
        }

        /// <summary>
        /// Displays a message indicating that the quiz feature is not yet implemented.
        /// </summary>
        static void DisplayQuizNotImplemented()
        {
            Console.Clear();
            Console.WriteLine(ApplicationConstants.QuizHeader);
            Console.WriteLine(ApplicationConstants.SeparatorLine);
            Console.WriteLine();

            Console.WriteLine("Quiz feature is coming soon!");
            Console.WriteLine();
            Console.WriteLine("In future versions, you will be able to:");
            Console.WriteLine("• Take interactive quizzes on data types");
            Console.WriteLine("• Test your knowledge of C# and SQL data types");
            Console.WriteLine("• Get instant feedback on your answers");
            Console.WriteLine("• Track your learning progress");
            Console.WriteLine("• Review questions and explanations");
            Console.WriteLine();

            Console.WriteLine(ApplicationConstants.PressAnyKeyMessage);
            Console.ReadKey();
        }

        /// <summary>
        /// Displays the exit message and thanks the user.
        /// </summary>
        static void DisplayExitMessage()
        {
            Console.Clear();
            Console.WriteLine(ApplicationConstants.ApplicationTitle);
            Console.WriteLine(ApplicationConstants.SeparatorLine);
            Console.WriteLine();

            Console.WriteLine("Thank you for using the C# to SQL Data Types Learning System!");
            Console.WriteLine();
            Console.WriteLine("We hope this application has helped you:");
            Console.WriteLine("• Understand data type mappings between C# and SQL");
            Console.WriteLine("• Learn best practices for data type selection");
            Console.WriteLine("• Improve your database and application design skills");
            Console.WriteLine();

            Console.WriteLine("Key takeaways:");
            Console.WriteLine("• Choose appropriate data types for your specific needs");
            Console.WriteLine("• Consider performance implications of your choices");
            Console.WriteLine("• Use Unicode types for international text");
            Console.WriteLine("• Use DECIMAL for financial calculations");
            Console.WriteLine("• Use DATETIME2 instead of DATETIME for new applications");
            Console.WriteLine();

            Console.WriteLine("Happy coding!");
            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
