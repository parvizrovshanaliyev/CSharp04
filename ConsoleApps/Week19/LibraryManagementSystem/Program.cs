using LibraryManagementSystem.Enums;
using LibraryManagementSystem.Managers;
using LibraryManagementSystem.Models;
using System;

namespace LibraryManagementSystem
{
    /// <summary>
    /// Main program class for the Library Management System
    /// </summary>
    /// <remarks>
    /// This class serves as the entry point for the Library Management System application.
    /// It handles:
    /// - User authentication
    /// - Menu navigation
    /// - Library operations (add, search, delete, display items)
    /// - User interaction and input validation
    /// </remarks>
    internal class Program
    {
        /// <summary>
        /// Entry point of the application
        /// </summary>
        /// <param name="args">Command line arguments (not used)</param>
        /// <remarks>
        /// The main method follows these steps:
        /// 1. Initializes system managers
        /// 2. Handles user authentication
        /// 3. Runs the main application menu
        /// </remarks>
        static void Main(string[] args)
        {
            /*
             * Application Initialization and Flow
             * ==================================
             * 
             * Step 1: System Initialization
             * - Create authentication manager for user access control
             * - Create library manager for handling library items
             * - Set up initial system state
             * 
             * Step 2: User Authentication
             * - Handle login process with retry mechanism
             * - Validate user credentials
             * - Provide feedback on authentication status
             * 
             * Step 3: Main Application Loop
             * - Display menu options
             * - Process user input
             * - Execute selected operations
             * - Continue until user chooses to exit
             */

            AuthenticationManager authenticationManager = new AuthenticationManager();
            LibraryManager libraryManager = new LibraryManager();

            // Attempt user login with proper error handling
            if (!authenticationManager.Login())
            {
                Console.WriteLine("Login failed. Exiting program");
                return;
            }

            // Start the main application menu after successful authentication
            RunMainMenu(libraryManager);
        }

        /// <summary>
        /// Manages the main menu loop of the application
        /// </summary>
        /// <param name="libraryManager">The library manager instance to handle operations</param>
        /// <remarks>
        /// This method:
        /// - Displays the menu options
        /// - Handles user input
        /// - Processes menu choices
        /// - Continues until user chooses to exit
        /// </remarks>
        private static void RunMainMenu(LibraryManager libraryManager)
        {
            /*
             * Main Menu Loop
             * ==============
             * 
             * This loop handles the main interaction with the user:
             * 1. Display available options
             * 2. Get user input
             * 3. Validate input
             * 4. Process selected option
             * 5. Repeat until exit is chosen
             * 
             * Input Validation:
             * - Ensures numeric input
             * - Validates range (1-5)
             * - Handles invalid input gracefully
             */

            bool running = true;

            while (running)
            {
                DisplayMenuOptions();

                if (!int.TryParse(Console.ReadLine(), out int choice) && choice == 0)
                {
                    Console.WriteLine("Invalid input. Please a number between 1 and 5.");
                    continue;
                }

                running = ProcessMenuChoice(libraryManager, choice);
            }
        }

        /// <summary>
        /// Processes the user's menu selection
        /// </summary>
        /// <param name="libraryManager">The library manager instance</param>
        /// <param name="choice">The user's menu choice</param>
        /// <returns>True to continue running, false to exit</returns>
        /// <remarks>
        /// Handles the following operations:
        /// 1. Add new items
        /// 2. List all items
        /// 3. Search for items
        /// 4. Delete items
        /// 5. Exit the application
        /// </remarks>
        private static bool ProcessMenuChoice(LibraryManager libraryManager, int choice)
        {
            /*
             * Menu Choice Processing
             * =====================
             * 
             * This method handles different menu options:
             * 1. Add item    - Creates and adds new library items
             * 2. List items  - Displays all items in the library
             * 3. Search      - Finds items based on search criteria
             * 4. Delete     - Removes items from the library
             * 5. Exit       - Terminates the application
             * 
             * Each option is handled separately with appropriate
             * error checking and user feedback.
             */

            switch (choice)
            {
                case 1: // Add item
                    AddNewItem(libraryManager);
                    return true;
                case 2: // List All items
                    libraryManager.DisplayAllItemInfo();
                    return true;
                case 3: // Search items
                    SearchItems(libraryManager);
                    return true;
                case 4: // Delete an item
                    DeleteItem(libraryManager);
                    return true;
                case 5: // Exit 
                    Console.WriteLine("Thank you for using LMS!");
                    return false;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number 1 and 5.");
                    return true;
            }
        }

        /// <summary>
        /// Handles the deletion of a library item
        /// </summary>
        /// <param name="libraryManager">The library manager instance</param>
        /// <remarks>
        /// Process:
        /// 1. Displays current items
        /// 2. Gets user input for item selection
        /// 3. Validates input
        /// 4. Performs deletion if valid
        /// </remarks>
        private static void DeleteItem(LibraryManager libraryManager)
        {
            /*
             * Item Deletion Process
             * ====================
             * 
             * Steps:
             * 1. Display current items for selection
             * 2. Get user input for item number
             * 3. Validate input:
             *    - Must be numeric
             *    - Must be within valid range
             *    - Handle cancellation (0)
             * 4. Process deletion
             * 5. Provide feedback on operation result
             */

            libraryManager.DisplayAllItemInfo();

            Console.Write("\nEnter the number of the item to delete (or cancel):");

            if (!int.TryParse(Console.ReadLine(), out int choice) && choice < 0)
            {
                Console.WriteLine("Invalid input");
                return;
            }

            if (choice == 0)
            {
                Console.WriteLine("Deletion cancelled.");
                return;
            }

            libraryManager.DeleteItem(choice - 1);
        }

        /// <summary>
        /// Searches for library items based on user input
        /// </summary>
        /// <param name="libraryManager">The library manager instance</param>
        /// <remarks>
        /// Allows searching by:
        /// - Title
        /// - Author
        /// Displays all matching results or appropriate message if none found
        /// </remarks>
        private static void SearchItems(LibraryManager libraryManager)
        {
            /*
             * Item Search Process
             * ==================
             * 
             * Steps:
             * 1. Get search term from user
             * 2. Perform search operation
             * 3. Handle empty results
             * 4. Display matching items
             * 
             * Search Criteria:
             * - Case-insensitive matching
             * - Matches partial strings
             * - Searches both title and author
             */

            Console.WriteLine("\nEnter search term (title or author): ");
            string searchTerm = Console.ReadLine() ?? "";

            LibraryItem[] searchResult = libraryManager.SearchItems(searchTerm);

            if (searchResult.Length == 0)
            {
                Console.WriteLine("No items found matching your search.");
                return;
            }

            Console.WriteLine($"\nFound {searchResult.Length} items:");
            foreach (var libraryItem in searchResult)
            {
                libraryItem.DisplayInfo();
            }
        }

        /// <summary>
        /// Handles the creation and addition of new library items
        /// </summary>
        /// <param name="libraryManager">The library manager instance</param>
        /// <remarks>
        /// Supports creation of:
        /// - Books
        /// - Magazines
        /// - Articles
        /// Collects all necessary information and validates input
        /// </remarks>
        private static void AddNewItem(LibraryManager libraryManager)
        {
            /*
             * New Item Addition Process
             * ========================
             * 
             * Steps:
             * 1. Get item type selection
             *    - Book
             *    - Magazine
             *    - Article
             * 
             * 2. Collect common information
             *    - Title
             *    - Author
             *    - Publish Year
             * 
             * 3. Get type-specific information
             *    - Book: Genre
             *    - Magazine: Issue Number
             *    - Article: Journal Name
             * 
             * 4. Validate all inputs
             * 5. Create and add the item
             * 6. Provide feedback on success/failure
             */

            Console.WriteLine("\n New Item");
            Console.WriteLine("1. Book");
            Console.WriteLine("2. Magazine");
            Console.WriteLine("3. Article");
            Console.Write("\nEnter item type (1-3): ");

            if (!int.TryParse(Console.ReadLine(), out int choice) && choice < 1 || choice > 3)
            {
                Console.WriteLine("Invalid item type. Please a number between 1 and 3.");
                return;
            }

            ItemType type = (ItemType)choice;

            Console.Write("Enter title: ");
            string title = Console.ReadLine() ?? "";

            Console.Write("Enter author: ");
            string author = Console.ReadLine() ?? "";

            Console.Write("Enter publish year: ");
            if (!int.TryParse(Console.ReadLine(), out int publishYear) && choice == 0)
            {
                Console.WriteLine("Invalid publish year.");
                return;
            }

            string additionalInformation = GetAdditionalInformation(type);

            var item = libraryManager.CreateNewItem(
                type: type,
                title: title,
                author: author,
                publishYear: publishYear,
                additionalInfo: additionalInformation
            );

            if (item != null)
            {
                libraryManager.AddItem(item);
            }
        }

        /// <summary>
        /// Gets additional information specific to each type of library item
        /// </summary>
        /// <param name="type">The type of library item</param>
        /// <returns>The additional information provided by the user</returns>
        /// <remarks>
        /// Collects:
        /// - Genre for books
        /// - Issue number for magazines
        /// - Journal name for articles
        /// </remarks>
        private static string GetAdditionalInformation(ItemType type)
        {
            /*
             * Additional Information Collection
             * ===============================
             * 
             * Handles type-specific information:
             * - Books: Genre information
             * - Magazines: Issue number details
             * - Articles: Journal name
             * 
             * Returns empty string if input is null
             */

            switch (type)
            {
                case ItemType.Book:
                    Console.Write("Enter genre: ");
                    break;
                case ItemType.Magazine:
                    Console.Write("Enter issue number: ");
                    break;
                case ItemType.Article:
                    Console.Write("Enter journal name: ");
                    break;
            }

            return Console.ReadLine() ?? "";
        }

        /// <summary>
        /// Displays the main menu options to the user
        /// </summary>
        /// <remarks>
        /// Shows:
        /// 1. Add new item
        /// 2. List all items
        /// 3. Search items
        /// 4. Delete an item
        /// 5. Logout and Exit
        /// </remarks>
        private static void DisplayMenuOptions()
        {
            /*
             * Menu Display
             * ============
             * 
             * Shows the main menu options:
             * 1. Add new item    - Create and add new items
             * 2. List all items  - Display all library items
             * 3. Search items    - Search functionality
             * 4. Delete an item  - Remove items
             * 5. Logout and Exit - End application
             * 
             * Format:
             * - Clear numbering
             * - Consistent spacing
             * - Input prompt
             */

            Console.WriteLine("\nLibrary Management System Menu:");
            Console.WriteLine("1. Add new item");
            Console.WriteLine("2. List all items");
            Console.WriteLine("3. Search items");
            Console.WriteLine("4. Delete an item");
            Console.WriteLine("5. Logout and Exit");
            Console.Write("\nEnter your choice (1-5): ");
        }
    }
}
