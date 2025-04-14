using NoteApp.Application.Interfaces;
using NoteApp.Application.Services;
using NoteApp.Infrastructure.Services;

namespace NoteApp
{
    /// <summary>
    /// The main program class for the Note Application.
    /// Provides a console-based user interface for managing notes.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// The entry point of the application.
        /// Sets up the dependency injection and runs the main application loop.
        /// </summary>
        /// <param name="args">Command line arguments (not used).</param>
        static void Main(string[] args)
        {
            /*
             * Initialize services using dependency injection
             * - FileService provides low-level file operations
             * - NoteService provides high-level note management functionality
             */
            IFileService fileService = new FileService();
            INoteService noteService = new NoteService(fileService);
            bool running = true;

            /*
             * Main application loop
             * Displays menu and handles user input until exit is selected
             */
            while (running)
            {
                /*
                 * Display the main menu
                 * Uses emoji for better visual appeal
                 */
                Console.WriteLine("\n📘 Note Manager");
                Console.WriteLine("1. Add Note");
                Console.WriteLine("2. View Notes");
                Console.WriteLine("3. Delete All Notes");
                Console.WriteLine("0. Exit");
                Console.Write("Select an option: ");

                /*
                 * Handle user input using switch statement
                 * Each case corresponds to a menu option
                 */
                switch (Console.ReadLine())
                {
                    case "1":
                        /*
                         * Add new note
                         * Collect title and content from user
                         */
                        Console.Write("Title: ");
                        string title = Console.ReadLine() ?? string.Empty;
                        Console.Write("Content: ");
                        string content = Console.ReadLine() ?? string.Empty;
                        noteService.Create(title, content);
                        Console.WriteLine("Note saved!");
                        break;

                    case "2":
                        /*
                         * View all notes
                         * Display formatted list of all saved notes
                         */
                        Console.WriteLine("\nYour Notes:");
                        Console.WriteLine(noteService.GetAll());
                        break;

                    case "3":
                        /*
                         * Delete all notes
                         * Clear the entire notes storage
                         */
                        noteService.Clear();
                        Console.WriteLine("All notes deleted.");
                        break;

                    case "0":
                        /*
                         * Exit the application
                         * Set running to false to break the main loop
                         */
                        running = false;
                        break;

                    default:
                        /*
                         * Handle invalid input
                         * Display error message and continue loop
                         */
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }
    }
}
