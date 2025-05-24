using ProductInventorySystem.Constants;

namespace ProductInventorySystem.Utils
{
    /// <summary>
    /// Provides utility methods for console operations.
    /// This class encapsulates common console operations to:
    /// - Handle user input
    /// - Display messages
    /// - Manage console interaction
    /// - Provide consistent formatting
    /// </summary>
    public static class ConsoleHelper
    {
        /// <summary>
        /// Gets a non-empty string input from the user.
        /// This method:
        /// - Displays the provided prompt
        /// - Reads user input
        /// - Trims whitespace
        /// - Returns null if input is empty or whitespace
        /// </summary>
        /// <param name="prompt">The prompt to display to the user</param>
        /// <returns>The user input if valid, null if empty or whitespace</returns>
        public static string GetNonEmptyInput(string prompt)
        {
            Console.Write(prompt);
            var input = Console.ReadLine()?.Trim();
            return string.IsNullOrWhiteSpace(input) ? null : input;
        }

        /// <summary>
        /// Gets a menu choice from the user.
        /// This method:
        /// - Displays the choice prompt
        /// - Reads user input
        /// - Validates the input is a number
        /// - Checks if the number corresponds to a valid menu option
        /// - Returns the menu option or null if invalid
        /// </summary>
        /// <returns>The selected menu option if valid, null if invalid</returns>
        public static MenuOption? GetMenuChoice()
        {
            Console.Write(Prompts.EnterChoice);
            if (int.TryParse(Console.ReadLine(), out int choice) &&
                Enum.IsDefined(typeof(MenuOption), choice))
            {
                return (MenuOption)choice;
            }
            return null;
        }

        /// <summary>
        /// Displays a message and waits for a key press.
        /// This method:
        /// - Shows the "press key to continue" message
        /// - Waits for any key press
        /// - Clears the console screen
        /// </summary>
        public static void WaitForKeyPress()
        {
            Console.WriteLine(Messages.PressKeyToContinue);
            Console.ReadKey();
            Console.Clear();
        }

        /// <summary>
        /// Displays a success message to the user.
        /// This method provides a consistent way to show success messages
        /// throughout the application.
        /// </summary>
        /// <param name="message">The success message to display</param>
        public static void ShowSuccess(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// Displays an error message to the user.
        /// This method provides a consistent way to show error messages
        /// throughout the application.
        /// </summary>
        /// <param name="message">The error message to display</param>
        public static void ShowError(string message)
        {
            Console.WriteLine(message);
        }
    }
}