using System;

namespace UndoTextEditor.Constants
{
    /// <summary>
    /// Represents the available menu options in the text editor.
    /// This enum provides type-safe menu selection and prevents magic numbers in the code.
    /// Each option corresponds to a specific action in the text editor:
    /// - AddText: Allows users to add new text lines
    /// - UndoLast: Removes the most recently added text line
    /// - ViewText: Displays all current text lines
    /// - ClearAll: Removes all text lines
    /// - SaveAndExit: Saves changes and exits the application
    /// </summary>
    public enum MenuOption
    {
        AddText = 1,
        UndoLast = 2,
        ViewText = 3,
        ClearAll = 4,
        SaveAndExit = 5
    }

    /// <summary>
    /// Contains constant messages used throughout the application.
    /// These messages are centralized to ensure consistency in user communication
    /// and make it easier to modify or localize the application.
    /// 
    /// The messages include:
    /// - Success messages
    /// - Error messages
    /// - Information messages
    /// - System messages
    /// 
    /// Some messages use string formatting placeholders ({0}) for dynamic content.
    /// </summary>
    public static class Messages
    {
        /// <summary>Displayed when user enters an invalid menu choice</summary>
        public const string InvalidChoice = "Invalid choice. Please try again.";

        /// <summary>Displayed when a new text line is successfully added</summary>
        public const string TextAdded = "Text added successfully!";

        /// <summary>Displayed when text addition fails (empty or whitespace input)</summary>
        public const string TextAddFailed = "Failed to add text. Make sure it's not empty.";

        /// <summary>Displayed when a text line is removed, includes the removed content</summary>
        public const string TextRemoved = "Removed: {0}";

        /// <summary>Displayed when there are no text lines to undo</summary>
        public const string NoTextToUndo = "No text to undo.";

        /// <summary>Displayed when trying to view text but none exists</summary>
        public const string NoTextAvailable = "No text available.";

        /// <summary>Displayed when all text lines are cleared</summary>
        public const string AllTextCleared = "All text cleared.";

        /// <summary>Displayed when changes are saved and program is exiting</summary>
        public const string ChangesSaved = "Changes saved. Exiting...";

        /// <summary>Displayed when an unexpected error occurs, includes error message</summary>
        public const string ErrorOccurred = "An error occurred: {0}";

        /// <summary>Prompt to continue after an operation</summary>
        public const string PressKeyToContinue = "\nPress any key to continue...";

        /// <summary>Prompt to exit after an error</summary>
        public const string PressKeyToExit = "Press any key to exit...";
    }

    /// <summary>
    /// Contains constant prompts used for user interaction.
    /// These prompts guide users through the application's input requirements
    /// and provide context for the expected input.
    /// 
    /// The prompts are designed to be:
    /// - Clear and concise
    /// - Consistent in style
    /// - Informative about the expected input
    /// </summary>
    public static class Prompts
    {
        /// <summary>Prompt for menu selection</summary>
        public const string EnterChoice = "\nEnter your choice: ";

        /// <summary>Prompt for new text input</summary>
        public const string EnterNewLine = "\nEnter new line: ";

        /// <summary>Header for displaying current text</summary>
        public const string CurrentTextHeader = "\nCurrent text (most recent first):";
    }

    /// <summary>
    /// Contains constant UI elements for the menu system.
    /// These elements define the structure and appearance of the application's
    /// main menu interface.
    /// 
    /// The UI elements are organized to:
    /// - Provide clear navigation options
    /// - Maintain consistent formatting
    /// - Present a professional appearance
    /// - Make the interface intuitive to use
    /// </summary>
    public static class UI
    {
        /// <summary>Main application title</summary>
        public const string MenuHeader = "\n=== Simple Text Editor ===\n";

        /// <summary>Menu separator line</summary>
        public const string MenuSeparator = "──────────────────────────";

        /// <summary>Option to add new text</summary>
        public const string MenuAddText = "1. Add new text";

        /// <summary>Option to undo last text entry</summary>
        public const string MenuUndoLast = "2. Undo last entry";

        /// <summary>Option to view all text</summary>
        public const string MenuViewText = "3. View current text";

        /// <summary>Option to clear all text</summary>
        public const string MenuClearAll = "4. Clear all";

        /// <summary>Option to save and exit</summary>
        public const string MenuSaveExit = "5. Save and exit";
    }
}