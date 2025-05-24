using System;
using System.Collections.Generic;
using System.Linq;
using UndoTextEditor.Constants;
using UndoTextEditor.Models;
using UndoTextEditor.Repositories;
using UndoTextEditor.Services;

namespace UndoTextEditor
{
    /// <summary>
    /// Main program class that handles the user interface and program flow.
    /// This class is responsible for:
    /// - Initializing the application components
    /// - Managing the main program loop
    /// - Handling user input and menu navigation
    /// - Coordinating between the UI and business logic
    /// - Managing application state and persistence
    /// 
    /// The class follows the Single Responsibility Principle by delegating
    /// specific operations to appropriate service classes while maintaining
    /// control over the overall program flow.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// The text editor service instance that handles all text operations.
        /// This is initialized once and shared throughout the application lifecycle.
        /// </summary>
        private static readonly ITextEditorService _editorService;

        /// <summary>
        /// The name of the file used to persist text data between sessions.
        /// This file is created in the application's execution directory.
        /// </summary>
        private const string SessionFile = "session.txt";

        /// <summary>
        /// Static constructor that initializes the service layer.
        /// This constructor:
        /// - Creates a new file-based repository
        /// - Initializes the text editor service with the repository
        /// - Sets up the dependency chain for the application
        /// 
        /// The static constructor ensures that all required components
        /// are properly initialized before the application starts.
        /// </summary>
        static Program()
        {
            var repository = new FileTextRepository(SessionFile);
            _editorService = new TextEditorService(repository);
        }

        /// <summary>
        /// Main entry point of the application.
        /// This method:
        /// - Loads any previously saved text
        /// - Starts the main program loop
        /// - Handles any unhandled exceptions
        /// 
        /// The method implements a top-level exception handler to ensure
        /// the application exits gracefully even if unexpected errors occur.
        /// </summary>
        /// <param name="args">Command line arguments (not used in this application)</param>
        static void Main(string[] args)
        {
            try
            {
                _editorService.Load();
                RunMainLoop();
            }
            catch (Exception ex)
            {
                Console.WriteLine(Messages.ErrorOccurred, ex.Message);
                Console.WriteLine(Messages.PressKeyToExit);
                Console.ReadKey();
            }
        }

        /// <summary>
        /// Runs the main program loop that handles user interaction.
        /// This method:
        /// - Displays the menu
        /// - Processes user input
        /// - Executes selected operations
        /// - Manages program flow
        /// 
        /// The loop continues until the user chooses to exit,
        /// at which point any changes are saved automatically.
        /// </summary>
        private static void RunMainLoop()
        {
            while (true)
            {
                DisplayMenu();
                var choice = GetUserChoice();

                if (choice == (int)MenuOption.SaveAndExit)
                {
                    _editorService.Save();
                    Console.WriteLine(Messages.ChangesSaved);
                    break;
                }

                ProcessMenuChoice(choice);
                Console.WriteLine(Messages.PressKeyToContinue);
                Console.ReadKey();
                Console.Clear();
            }
        }

        /// <summary>
        /// Displays the main menu of the application.
        /// The menu is constructed using UI constants to ensure
        /// consistency and maintainability of the interface.
        /// </summary>
        private static void DisplayMenu()
        {
            Console.WriteLine(UI.MenuHeader);
            Console.WriteLine(UI.MenuAddText);
            Console.WriteLine(UI.MenuUndoLast);
            Console.WriteLine(UI.MenuViewText);
            Console.WriteLine(UI.MenuClearAll);
            Console.WriteLine(UI.MenuSaveExit);
            Console.Write(Prompts.EnterChoice);
        }

        /// <summary>
        /// Gets and validates the user's menu choice.
        /// This method:
        /// - Reads user input
        /// - Attempts to parse it as an integer
        /// - Returns 0 for invalid input
        /// 
        /// The method ensures that the menu system can handle
        /// invalid input gracefully.
        /// </summary>
        /// <returns>The user's choice as an integer, or 0 for invalid input</returns>
        private static int GetUserChoice()
        {
            return int.TryParse(Console.ReadLine(), out int choice) ? choice : 0;
        }

        /// <summary>
        /// Processes the selected menu choice.
        /// This method:
        /// - Maps the numeric choice to the corresponding MenuOption
        /// - Calls the appropriate handler method
        /// - Provides feedback for invalid choices
        /// 
        /// The method uses the MenuOption enum to ensure type-safe
        /// menu selection and prevent magic numbers.
        /// </summary>
        /// <param name="choice">The user's menu choice</param>
        private static void ProcessMenuChoice(int choice)
        {
            switch (choice)
            {
                case (int)MenuOption.AddText:
                    AddNewText();
                    break;
                case (int)MenuOption.UndoLast:
                    UndoLastEntry();
                    break;
                case (int)MenuOption.ViewText:
                    ViewCurrentText();
                    break;
                case (int)MenuOption.ClearAll:
                    ClearAll();
                    break;
                default:
                    Console.WriteLine(Messages.InvalidChoice);
                    break;
            }
        }

        /// <summary>
        /// Handles adding new text to the editor.
        /// This method:
        /// - Prompts for new text input
        /// - Validates the input
        /// - Adds the text if valid
        /// - Provides appropriate feedback
        /// 
        /// The method uses the text editor service to handle
        /// the actual text addition operation.
        /// </summary>
        private static void AddNewText()
        {
            Console.Write(Prompts.EnterNewLine);
            var content = Console.ReadLine();

            if (_editorService.AddLine(content))
            {
                Console.WriteLine(Messages.TextAdded);
            }
            else
            {
                Console.WriteLine(Messages.TextAddFailed);
            }
        }

        /// <summary>
        /// Handles undoing the last text entry.
        /// This method:
        /// - Attempts to remove the last added line
        /// - Displays the removed text if successful
        /// - Provides feedback if no text is available
        /// 
        /// The method uses the text editor service to handle
        /// the actual undo operation.
        /// </summary>
        private static void UndoLastEntry()
        {
            var removedLine = _editorService.Undo();
            if (removedLine != null)
            {
                Console.WriteLine(Messages.TextRemoved, removedLine.Content);
            }
            else
            {
                Console.WriteLine(Messages.NoTextToUndo);
            }
        }

        /// <summary>
        /// Displays all current text in the editor.
        /// This method:
        /// - Retrieves all text lines
        /// - Checks if any text exists
        /// - Displays text in reverse chronological order
        /// - Provides feedback if no text is available
        /// 
        /// The method uses the text editor service to retrieve
        /// the current text lines.
        /// </summary>
        private static void ViewCurrentText()
        {
            var lines = _editorService.GetAllLines();
            if (!lines.Any())
            {
                Console.WriteLine(Messages.NoTextAvailable);
                return;
            }

            Console.WriteLine(Prompts.CurrentTextHeader);
            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }
        }

        /// <summary>
        /// Handles clearing all text from the editor.
        /// This method:
        /// - Removes all text lines
        /// - Provides feedback to the user
        /// 
        /// The method uses the text editor service to handle
        /// the actual clearing operation.
        /// </summary>
        private static void ClearAll()
        {
            _editorService.Clear();
            Console.WriteLine(Messages.AllTextCleared);
        }
    }
}
