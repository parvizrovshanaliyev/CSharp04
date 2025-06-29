namespace CSharpToSqlDataTypes.Constants
{
    /// <summary>
    /// Contains all application-wide constants used throughout the C# to SQL Data Types application.
    /// This class centralizes all string literals, numeric values, and configuration settings
    /// to ensure consistency and make maintenance easier.
    /// </summary>
    public static class ApplicationConstants
    {
        #region Application Information

        /// <summary>
        /// The main application title displayed in the console interface.
        /// </summary>
        public const string ApplicationTitle = "=== C# to SQL Data Types Learning System ===";

        /// <summary>
        /// The application subtitle displayed below the main title.
        /// </summary>
        public const string ApplicationSubtitle = "Comprehensive Guide to Data Type Mapping and Best Practices";

        /// <summary>
        /// The application version information.
        /// </summary>
        public const string ApplicationVersion = "Version 1.0";

        #endregion

        #region UI Messages

        /// <summary>
        /// Message displayed when waiting for user input to continue.
        /// </summary>
        public const string PressAnyKeyMessage = "\nPress any key to continue...";

        /// <summary>
        /// Prompt message for user menu selection.
        /// </summary>
        public const string EnterChoiceMessage = "Enter your choice: ";

        /// <summary>
        /// Message displayed when clearing the console.
        /// </summary>
        public const string ClearingScreenMessage = "Clearing screen...";

        /// <summary>
        /// Message displayed when returning to the main menu.
        /// </summary>
        public const string ReturningToMenuMessage = "Returning to main menu...";

        #endregion

        #region Menu Options

        /// <summary>
        /// Text for menu option 1 - View C# data types.
        /// </summary>
        public const string MenuOption1 = "1. View C# Data Types";

        /// <summary>
        /// Text for menu option 2 - View SQL data types.
        /// </summary>
        public const string MenuOption2 = "2. View SQL Data Types";

        /// <summary>
        /// Text for menu option 3 - Compare data types.
        /// </summary>
        public const string MenuOption3 = "3. Compare C# and SQL Data Types";

        /// <summary>
        /// Text for menu option 4 - Find SQL equivalent.
        /// </summary>
        public const string MenuOption4 = "4. Find SQL Equivalent for C# Type";

        /// <summary>
        /// Text for menu option 5 - Find C# equivalent.
        /// </summary>
        public const string MenuOption5 = "5. Find C# Equivalent for SQL Type";

        /// <summary>
        /// Text for menu option 6 - View conversion examples.
        /// </summary>
        public const string MenuOption6 = "6. View Data Type Conversion Examples";

        /// <summary>
        /// Text for menu option 7 - Take quiz.
        /// </summary>
        public const string MenuOption7 = "7. Take Data Types Quiz";

        /// <summary>
        /// Text for menu option 8 - View best practices.
        /// </summary>
        public const string MenuOption8 = "8. View Best Practices";

        /// <summary>
        /// Text for menu option 9 - Search data types.
        /// </summary>
        public const string MenuOption9 = "9. Search Data Types";

        /// <summary>
        /// Text for menu option 10 - View size and ranges.
        /// </summary>
        public const string MenuOption10 = "10. View Size and Range Information";

        /// <summary>
        /// Text for menu option 11 - Exit.
        /// </summary>
        public const string MenuOption11 = "11. Exit";

        #endregion

        #region Success Messages

        /// <summary>
        /// Success message for successful data type conversion.
        /// </summary>
        public const string ConversionSuccessMessage = "Data type conversion completed successfully.";

        /// <summary>
        /// Success message for successful search operation.
        /// </summary>
        public const string SearchSuccessMessage = "Search completed successfully.";

        /// <summary>
        /// Success message for quiz completion.
        /// </summary>
        public const string QuizCompletionMessage = "Quiz completed! Check your results.";

        #endregion

        #region Error Messages

        /// <summary>
        /// Error message for invalid menu choice input.
        /// </summary>
        public const string InvalidChoiceError = "Please enter a valid number between 1 and 11.";

        /// <summary>
        /// Error message for data type not found.
        /// </summary>
        public const string DataTypeNotFoundError = "Data type '{0}' not found.";

        /// <summary>
        /// Error message for conversion not possible.
        /// </summary>
        public const string ConversionNotPossibleError = "Conversion from {0} to {1} is not possible.";

        /// <summary>
        /// Error message for invalid input.
        /// </summary>
        public const string InvalidInputError = "Invalid input. Please try again.";

        /// <summary>
        /// Error message for search with no results.
        /// </summary>
        public const string NoSearchResultsError = "No data types found matching your search criteria.";

        /// <summary>
        /// Error message for general application errors.
        /// </summary>
        public const string GeneralError = "An error occurred: {0}";

        #endregion

        #region Input Prompts

        /// <summary>
        /// Prompt message for entering C# data type name.
        /// </summary>
        public const string EnterCSharpTypePrompt = "\nEnter C# data type name: ";

        /// <summary>
        /// Prompt message for entering SQL data type name.
        /// </summary>
        public const string EnterSqlTypePrompt = "\nEnter SQL data type name: ";

        /// <summary>
        /// Prompt message for entering search term.
        /// </summary>
        public const string EnterSearchTermPrompt = "\nEnter search term: ";

        /// <summary>
        /// Prompt message for quiz answer.
        /// </summary>
        public const string EnterQuizAnswerPrompt = "\nEnter your answer: ";

        #endregion

        #region Display Headers

        /// <summary>
        /// Header for C# data types display.
        /// </summary>
        public const string CSharpDataTypesHeader = "\n=== C# Data Types ===";

        /// <summary>
        /// Header for SQL data types display.
        /// </summary>
        public const string SqlDataTypesHeader = "\n=== SQL Data Types ===";

        /// <summary>
        /// Header for data type comparison display.
        /// </summary>
        public const string ComparisonHeader = "\n=== Data Type Comparison ===";

        /// <summary>
        /// Header for conversion examples display.
        /// </summary>
        public const string ConversionExamplesHeader = "\n=== Data Type Conversion Examples ===";

        /// <summary>
        /// Header for best practices display.
        /// </summary>
        public const string BestPracticesHeader = "\n=== Best Practices ===";

        /// <summary>
        /// Header for quiz display.
        /// </summary>
        public const string QuizHeader = "\n=== Data Types Quiz ===";

        /// <summary>
        /// Header for search results display.
        /// </summary>
        public const string SearchResultsHeader = "\n=== Search Results ===";

        /// <summary>
        /// Header for size and range information display.
        /// </summary>
        public const string SizeAndRangeHeader = "\n=== Size and Range Information ===";

        #endregion

        #region Information Messages

        /// <summary>
        /// Information message about data type categories.
        /// </summary>
        public const string DataTypeCategoriesInfo = "Data types are categorized by their characteristics and usage.";

        /// <summary>
        /// Information message about compatibility levels.
        /// </summary>
        public const string CompatibilityLevelsInfo = "Compatibility levels indicate how well data types can be converted.";

        /// <summary>
        /// Information message about best practices.
        /// </summary>
        public const string BestPracticesInfo = "Best practices help you choose the right data types for your needs.";

        /// <summary>
        /// Information message about performance considerations.
        /// </summary>
        public const string PerformanceInfo = "Performance considerations help optimize your database and application.";

        #endregion

        #region Quiz Messages

        /// <summary>
        /// Message displayed at the start of a quiz.
        /// </summary>
        public const string QuizStartMessage = "Welcome to the Data Types Quiz! Answer the questions to test your knowledge.";

        /// <summary>
        /// Message displayed when a quiz answer is correct.
        /// </summary>
        public const string QuizCorrectAnswerMessage = "Correct! Well done!";

        /// <summary>
        /// Message displayed when a quiz answer is incorrect.
        /// </summary>
        public const string QuizIncorrectAnswerMessage = "Incorrect. The correct answer is: {0}";

        /// <summary>
        /// Message displayed at the end of a quiz.
        /// </summary>
        public const string QuizEndMessage = "Quiz completed! Your score: {0}/{1}";

        #endregion

        #region Search Messages

        /// <summary>
        /// Message displayed when search is initiated.
        /// </summary>
        public const string SearchInitiatedMessage = "Searching for data types...";

        /// <summary>
        /// Message displayed when search finds results.
        /// </summary>
        public const string SearchFoundResultsMessage = "Found {0} data type(s) matching your search.";

        /// <summary>
        /// Message displayed when search finds no results.
        /// </summary>
        public const string SearchNoResultsMessage = "No data types found matching your search criteria.";

        #endregion

        #region Formatting Constants

        /// <summary>
        /// Separator line used in console output.
        /// </summary>
        public const string SeparatorLine = "==========================================";

        /// <summary>
        /// Short separator line used in console output.
        /// </summary>
        public const string ShortSeparatorLine = "------------------------------------------";

        /// <summary>
        /// Tab character for indentation.
        /// </summary>
        public const string Tab = "    ";

        /// <summary>
        /// Double tab character for deeper indentation.
        /// </summary>
        public const string DoubleTab = "        ";

        #endregion

        #region File Operations

        /// <summary>
        /// Default filename for saving quiz results.
        /// </summary>
        public const string QuizResultsFileName = "quiz_results.txt";

        /// <summary>
        /// Default filename for saving search history.
        /// </summary>
        public const string SearchHistoryFileName = "search_history.txt";

        #endregion

        #region Help Messages

        /// <summary>
        /// Help message for menu navigation.
        /// </summary>
        public const string MenuHelpMessage = "Use the number keys to navigate the menu.";

        /// <summary>
        /// Help message for search functionality.
        /// </summary>
        public const string SearchHelpMessage = "Enter keywords to search for data types. Search is case-insensitive.";

        /// <summary>
        /// Help message for quiz functionality.
        /// </summary>
        public const string QuizHelpMessage = "Answer the questions to test your knowledge of data types.";

        #endregion
    }
} 