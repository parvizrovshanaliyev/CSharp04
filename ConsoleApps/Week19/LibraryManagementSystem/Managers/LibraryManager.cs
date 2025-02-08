using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagementSystem.Constants;
using LibraryManagementSystem.Enums;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Managers
{
    /// <summary>
    /// Manages the library's collection of items including books, magazines, and articles.
    /// Handles operations like adding, deleting, searching, and displaying items.
    /// </summary>
    public class LibraryManager
    {
        #region Fields
        private readonly LibraryItem[] _libraryItems;
        private int _itemCount;
        private const int MaxItems = 100;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="LibraryManager"/> class.
        /// </summary>
        public LibraryManager()
        {
            _libraryItems = new LibraryItem[MaxItems];
            _itemCount = 0;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Runs the main menu loop.
        /// </summary>
        public void RunMainMenu()
        {
            bool running = true;

            while (running)
            {
                DisplayMenuOptions();
                int choice = GetUserChoice();
                running = ProcessMenuChoice(choice);
            }
        }

        /// <summary>
        /// Adds a new item to the library collection.
        /// </summary>
        /// <param name="item">The library item to add.</param>
        /// <returns>True if item was added successfully, false otherwise.</returns>
        public bool AddItem(LibraryItem item)
        {
            // Validate the item before adding
            if (!ValidateItem(item)) return false;

            // Add item to the array and increment the item count
            _libraryItems[_itemCount++] = item;
            Console.WriteLine("Item added successfully");
            return true;
        }

        /// <summary>
        /// Displays information about all items in the library.
        /// </summary>
        public void DisplayAllItemInfo()
        {
            if (_itemCount == 0)
            {
                Console.WriteLine("Error: No items in library");
                return;
            }

            Console.WriteLine("\nLibrary Items:");
            for (int i = 0; i < _itemCount; i++)
            {
                Console.Write($"{i + 1}. ");
                _libraryItems[i].DisplayInfo();
            }
        }

        /// <summary>
        /// Searches for items by title or author.
        /// </summary>
        /// <param name="searchTerm">The term to search for in titles and authors.</param>
        /// <returns>Array of matching library items.</returns>
        public LibraryItem[] SearchItems(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                Console.WriteLine("Search term cannot be empty.");
                return Array.Empty<LibraryItem>();
            }

            searchTerm = searchTerm.Trim().ToLower();
            LibraryItem[] matchingItems = new LibraryItem[_itemCount];
            int matchCount = 0;

            for (int i = 0; i < _itemCount; i++)
            {
                LibraryItem item = _libraryItems[i];
                if (item != null &&
                    (item.Title.ToLower().Contains(searchTerm) ||
                     item.Author.ToLower().Contains(searchTerm)))
                {
                    matchingItems[matchCount++] = item;
                }
            }

            // Resize the array to the actual number of matches
            Array.Resize(ref matchingItems, matchCount);

            return matchingItems;
        }

        /// <summary>
        /// Deletes an item from the library at the specified index.
        /// </summary>
        /// <param name="index">The index of the item to delete.</param>
        /// <returns>True if deletion was successful, false otherwise.</returns>
        public bool DeleteItem(int index)
        {
            // Validate the index before deleting
            if (!ValidateIndex(index)) return false;

            // Shift all elements after the deleted item one position left
            for (int i = index; i < _itemCount - 1; i++)
            {
                _libraryItems[i] = _libraryItems[i + 1];
            }

            // Nullify the last element and decrement the item count
            _libraryItems[--_itemCount] = null;
            Console.WriteLine("Item deleted successfully");
            return true;
        }

        /// <summary>
        /// Updates an existing library item with new details.
        /// </summary>
        /// <param name="index">The index of the item to update.</param>
        /// <param name="newTitle">The new title of the item.</param>
        /// <param name="newAuthor">The new author of the item.</param>
        /// <param name="newPublishYear">The new publication year of the item.</param>
        /// <param name="newAdditionalInfo">The new additional information (genre for books, issue number for magazines, journal name for articles).</param>
        /// <returns>True if the update was successful, false otherwise.</returns>
        public bool UpdateItem(int index, string newTitle, string newAuthor, int newPublishYear, string newAdditionalInfo)
        {
            if (!ValidateIndex(index) || !ValidateItemDetails(newTitle, newAuthor, newPublishYear)) return false;

            LibraryItem item = _libraryItems[index];
            item.UpdateDetails(newTitle, newAuthor, newPublishYear);

            switch (item)
            {
                case Book book:
                    if (!ValidateAdditionalInfo(newAdditionalInfo, "Genre cannot be empty for books.")) return false;
                    book.UpdateGenre(newAdditionalInfo);
                    break;

                case Magazine magazine:
                    if (!ValidateAdditionalInfo(newAdditionalInfo, "Invalid issue number for magazines.", out int issueNumber) || issueNumber <= 0) return false;
                    magazine.UpdateIssueNumber(issueNumber);
                    break;

                case Article article:
                    if (!ValidateAdditionalInfo(newAdditionalInfo, "Journal name cannot be empty for articles.")) return false;
                    article.UpdateJournalName(newAdditionalInfo);
                    break;

                default:
                    Console.WriteLine("Error: Unknown item type.");
                    return false;
            }

            Console.WriteLine("Item updated successfully.");
            return true;
        }

        /// <summary>
        /// Creates a new library item of the specified type.
        /// </summary>
        /// <param name="type">The type of item to create.</param>
        /// <param name="title">The title of the item.</param>
        /// <param name="author">The author of the item.</param>
        /// <param name="publishYear">The year the item was published.</param>
        /// <param name="additionalInfo">Additional info specific to the item type (genre, issue number, or journal name).</param>
        /// <returns>The created library item, or null if creation failed.</returns>
        public LibraryItem CreateNewItem(ItemType type, string title, string author, int publishYear, string additionalInfo)
        {
            if (!ValidateItemDetails(title, author, publishYear)) return null;

            switch (type)
            {
                case ItemType.Book:
                    if (ValidateAdditionalInfo(additionalInfo, "Genre cannot be empty."))
                        return new Book(title, author, publishYear, additionalInfo);
                    break;

                case ItemType.Magazine:
                    if (ValidateAdditionalInfo(additionalInfo, "Invalid issue number.", out int issueNumber) && issueNumber > 0)
                        return new Magazine(title, author, publishYear, issueNumber);
                    break;

                case ItemType.Article:
                    if (ValidateAdditionalInfo(additionalInfo, "Journal name cannot be empty."))
                        return new Article(title, author, publishYear, additionalInfo);
                    break;
            }

            return null;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Displays the menu options.
        /// </summary>
        private void DisplayMenuOptions()
        {
            Console.WriteLine("\nLibrary Management System Menu:");
            Console.WriteLine("1. Add new item");
            Console.WriteLine("2. List all items");
            Console.WriteLine("3. Search items");
            Console.WriteLine("4. Delete an item");
            Console.WriteLine("5. Update an item");
            Console.WriteLine("6. Logout and Exit");
            Console.Write("\nEnter your choice (1-6): ");
        }

        /// <summary>
        /// Processes the menu choice.
        /// </summary>
        /// <param name="choice">The menu choice.</param>
        /// <returns>True if the menu should continue running, false if it should exit.</returns>
        private bool ProcessMenuChoice(int choice)
        {
            switch (choice)
            {
                case MenuOptions.AddItem:
                    AddNewItem();
                    return true;
                case MenuOptions.ListItems:
                    DisplayAllItemInfo();
                    return true;
                case MenuOptions.SearchItems:
                    SearchItems();
                    return true;
                case MenuOptions.DeleteItem:
                    DeleteItem();
                    return true;
                case MenuOptions.UpdateItem:
                    UpdateItem();
                    return true;
                case MenuOptions.Exit:
                    Console.WriteLine("Thank you for using LMS!");
                    return false;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 6.");
                    return true;
            }
        }

        /// <summary>
        /// Adds a new item to the library.
        /// </summary>
        private void AddNewItem()
        {
            Console.WriteLine("\nNew Item");
            Console.WriteLine("1. Book");
            Console.WriteLine("2. Magazine");
            Console.WriteLine("3. Article");
            Console.WriteLine("4. Cancel");
            Console.Write("\nEnter item type (1-3): ");
            int choice = GetUserChoice();

            if (choice == 4)
            {
                Console.WriteLine("Add item cancelled.");
                return;
            }

            ItemType type = (ItemType)choice;

            string title = GetInput("Enter title: ");
            string author = GetInput("Enter author: ");
            int publishYear = GetValidatedYear("Enter publish year: ");
            string additionalInformation = GetAdditionalInformation(type);

            var item = CreateNewItem(type, title, author, publishYear, additionalInformation);

            if (item != null)
            {
                AddItem(item);
                Console.WriteLine("Item added successfully.");
            }
            else
            {
                Console.WriteLine("Error: Item creation failed.");
            }
        }

        /// <summary>
        /// Validates and retrieves a year from user input.
        /// </summary>
        /// <param name="prompt">The prompt to display to the user.</param>
        /// <returns>The validated year.</returns>
        private int GetValidatedYear(string prompt)
        {
            string userInput = GetInput(prompt);
            int year;

            while (!int.TryParse(userInput, out year) || year < 1000 || year > DateTime.Now.Year)
            {
                Console.WriteLine("Invalid year. Please enter a valid year between 1000 and the current year.");
                userInput = GetInput(prompt);
            }

            return year;
        }

        /// <summary>
        /// Updates an existing item in the library.
        /// </summary>
        private void UpdateItem()
        {
            DisplayAllItemInfo();
            Console.Write("Enter the number of the item to update (or 0 to cancel): ");
            int index = GetUserChoice() - 1;
            if (index < 0)
            {
                Console.WriteLine("Update cancelled.");
                return;
            }

            string newTitle = GetInput("Enter new title: ");
            string newAuthor = GetInput("Enter new author: ");
            int newPublishYear = GetValidatedYear("Enter new publish year: ");
            string newAdditionalInfo = GetInput("Enter new additional information: ");
            UpdateItem(index, newTitle, newAuthor, newPublishYear, newAdditionalInfo);
        }

        /// <summary>
        /// Deletes an item from the library.
        /// </summary>
        private void DeleteItem()
        {
            DisplayAllItemInfo();
            Console.Write("\nEnter the number of the item to delete (or 0 to cancel): ");
            int choice = GetUserChoice();

            if (choice == 0)
            {
                Console.WriteLine("Deletion cancelled.");
                return;
            }

            DeleteItem(choice - 1);
        }

        /// <summary>
        /// Searches for items in the library.
        /// </summary>
        private void SearchItems()
        {
            string searchTerm = GetInput("\nEnter search term (title or author): ");
            var searchResult = SearchItems(searchTerm);

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
        /// Gets additional information based on the item type.
        /// </summary>
        /// <param name="type">The item type.</param>
        /// <returns>The additional information.</returns>
        private string GetAdditionalInformation(ItemType type)
        {
            return type switch
            {
                ItemType.Book => GetInput("Enter genre: "),
                ItemType.Magazine => GetInput("Enter issue number: "),
                ItemType.Article => GetInput("Enter journal name: "),
                _ => ""
            };
        }

        /// <summary>
        /// Gets input from the user.
        /// </summary>
        /// <param name="prompt">The prompt to display to the user.</param>
        /// <returns>The user's input.</returns>
        private string GetInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine() ?? "";
        }

        /// <summary>
        /// Gets the user's choice as an integer.
        /// </summary>
        /// <returns>The user's choice.</returns>
        private int GetUserChoice()
        {
            return int.TryParse(Console.ReadLine(), out int choice) ? choice : 0;
        }

        /// <summary>
        /// Validates a library item.
        /// </summary>
        /// <param name="item">The item to validate.</param>
        /// <returns>True if the item is valid, false otherwise.</returns>
        private bool ValidateItem(LibraryItem item)
        {
            if (item == null)
            {
                Console.WriteLine("Error: Cannot add null item");
                return false;
            }

            if (_itemCount >= MaxItems)
            {
                Console.WriteLine("Error: Library is full");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validates an index.
        /// </summary>
        /// <param name="index">The index to validate.</param>
        /// <returns>True if the index is valid, false otherwise.</returns>
        private bool ValidateIndex(int index)
        {
            if (index < 0 || index >= _itemCount)
            {
                Console.WriteLine("Invalid item index");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validates item details.
        /// </summary>
        /// <param name="title">The title of the item.</param>
        /// <param name="author">The author of the item.</param>
        /// <param name="publishYear">The publication year of the item.</param>
        /// <returns>True if the item details are valid, false otherwise.</returns>
        private bool ValidateItemDetails(string title, string author, int publishYear)
        {
            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(author))
            {
                Console.WriteLine("Title and author cannot be empty.");
                return false;
            }

            if (publishYear < 1000 || publishYear > DateTime.Now.Year)
            {
                Console.WriteLine($"Publish year must be between 1000 and {DateTime.Now.Year}.");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validates additional information.
        /// </summary>
        /// <param name="additionalInfo">The additional information.</param>
        /// <param name="errorMessage">The error message to display if validation fails.</param>
        /// <param name="parsedValue">The parsed value if validation is successful.</param>
        /// <returns>True if the additional information is valid, false otherwise.</returns>
        private bool ValidateAdditionalInfo(string additionalInfo, string errorMessage, out int parsedValue)
        {
            if (!int.TryParse(additionalInfo, out parsedValue))
            {
                Console.WriteLine(errorMessage);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validates additional information.
        /// </summary>
        /// <param name="additionalInfo">The additional information.</param>
        /// <param name="errorMessage">The error message to display if validation fails.</param>
        /// <returns>True if the additional information is valid, false otherwise.</returns>
        private bool ValidateAdditionalInfo(string additionalInfo, string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(additionalInfo))
            {
                Console.WriteLine(errorMessage);
                return false;
            }

            return true;
        }
        #endregion
    }
}