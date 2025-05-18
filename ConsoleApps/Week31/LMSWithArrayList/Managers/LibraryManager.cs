using System;
using System.Collections;
using LMSWithArrayList.Enums;
using LMSWithArrayList.Extensions;
using LMSWithArrayList.Models;

namespace LMSWithArrayList.Managers
{
    /// <summary>
    /// Manages all library operations and user interface
    /// </summary>
    public class LibraryManager
    {
        #region Fields
        private ArrayList _items;
        private ArrayList _history;
        private int _nextId;
        private string _currentUser;
        private readonly AuthenticationManager _authenticationManager;
        private readonly ItemValidator _itemValidator;
        #endregion

        #region Constructor
        public LibraryManager(AuthenticationManager authenticationManager)
        {
            _items = new ArrayList();
            _history = new ArrayList();
            _nextId = 1;
            _currentUser = "System";
            _authenticationManager = authenticationManager ?? throw new ArgumentNullException(nameof(authenticationManager));
            _itemValidator = new ItemValidator();
        }
        #endregion

        #region Public Methods
        public void SetCurrentUser(string userName)
        {
            _currentUser = userName;
        }

        public void ListAllItems()
        {
            if (_items.Count == 0)
            {
                Console.WriteLine("No items in the library.");
                return;
            }

            Console.WriteLine("\n=== Active Library Items ===");
            foreach (LibraryItem item in _items)
            {
                if (!item.IsDeleted)
                {
                    Console.WriteLine("\n" + item.DisplayInfo());
                    Console.WriteLine("-------------------");
                }
            }
        }

        public void ListDeletedItems()
        {
            var deletedItems = new ArrayList();
            foreach (LibraryItem item in _items)
            {
                if (item.IsDeleted)
                {
                    deletedItems.Add(item);
                }
            }

            if (deletedItems.Count == 0)
            {
                Console.WriteLine("No deleted items found.");
                return;
            }

            Console.WriteLine("\n=== Deleted Library Items ===");
            foreach (LibraryItem item in deletedItems)
            {
                Console.WriteLine("\n" + item.DisplayInfo());
                Console.WriteLine($"Deleted on: {item.DeletedDate:yyyy-MM-dd HH:mm:ss}");
                Console.WriteLine($"Deleted by: {item.DeletedBy}");
                Console.WriteLine("-------------------");
            }
        }

        public void RunMainMenu()
        {
            while (true)
            {
                Console.WriteLine($"\nLibrary Management System - User: {_authenticationManager.GetCurrentUsername()}");
                foreach (MenuOption option in Enum.GetValues(typeof(MenuOption)))
                {
                    Console.WriteLine($"{option.ToInt()}. {option.GetDisplayText()}");
                }
                Console.Write("\nEnter your choice: ");

                if (int.TryParse(Console.ReadLine(), out int choice) &&
                    Enum.IsDefined(typeof(MenuOption), choice))
                {
                    MenuOption selectedOption = (MenuOption)choice;
                    switch (selectedOption)
                    {
                        case MenuOption.AddBook:
                            if (_authenticationManager.IsAdmin())
                                AddBook();
                            else
                                Console.WriteLine("Only administrators can add books.");
                            break;
                        case MenuOption.AddMagazine:
                            if (_authenticationManager.IsAdmin())
                                AddMagazine();
                            else
                                Console.WriteLine("Only administrators can add magazines.");
                            break;
                        case MenuOption.ListAllItems:
                            ListAllItems();
                            break;
                        case MenuOption.ListDeletedItems:
                            ListDeletedItems();
                            break;
                        case MenuOption.SearchItems:
                            SearchItems();
                            break;
                        case MenuOption.BorrowItem:
                            BorrowItem();
                            break;
                        case MenuOption.ReturnItem:
                            ReturnItem();
                            break;
                        case MenuOption.DeleteItem:
                            if (_authenticationManager.IsAdmin())
                                DeleteItem();
                            else
                                Console.WriteLine("Only administrators can delete items.");
                            break;
                        case MenuOption.ViewItemHistory:
                            ViewItemHistory();
                            break;
                        case MenuOption.Exit:
                            _authenticationManager.Logout();
                            Console.WriteLine("Thank you for using the Library Management System!");
                            return;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid menu option.");
                }
            }
        }
        #endregion

        #region Private Methods
        private void AddItem(LibraryItem item)
        {
            if (!_itemValidator.Validate(item))
            {
                return;
            }

            _items.Add(item);
            AddHistory(item.Id, "Added", _currentUser);
            Console.WriteLine($"Item added successfully! ID: {item.Id}");
        }

        private void AddBook()
        {
            Console.Write("Enter title: ");
            string title = Console.ReadLine() ?? string.Empty;
            Console.Write("Enter author: ");
            string author = Console.ReadLine() ?? string.Empty;
            Console.Write("Enter publish year: ");
            if (int.TryParse(Console.ReadLine(), out int year))
            {
                Console.Write("Enter genre: ");
                string genre = Console.ReadLine() ?? string.Empty;
                Console.Write("Enter page count: ");
                if (int.TryParse(Console.ReadLine(), out int pageCount))
                {
                    var book = new Book(_nextId++, title, author, year, genre, pageCount);
                    AddItem(book);
                }
                else
                {
                    Console.WriteLine("Invalid page count.");
                }
            }
            else
            {
                Console.WriteLine("Invalid year.");
            }
        }

        private void AddMagazine()
        {
            Console.Write("Enter title: ");
            string title = Console.ReadLine() ?? string.Empty;
            Console.Write("Enter author: ");
            string author = Console.ReadLine() ?? string.Empty;
            Console.Write("Enter publish year: ");
            if (int.TryParse(Console.ReadLine(), out int year))
            {
                Console.Write("Enter issue number: ");
                if (int.TryParse(Console.ReadLine(), out int issueNumber))
                {
                    Console.Write("Enter publisher: ");
                    string publisher = Console.ReadLine() ?? string.Empty;
                    var magazine = new Magazine(_nextId++, title, author, year, issueNumber, publisher);
                    AddItem(magazine);
                }
                else
                {
                    Console.WriteLine("Invalid issue number.");
                }
            }
            else
            {
                Console.WriteLine("Invalid year.");
            }
        }

        private void SearchItems()
        {
            Console.Write("Enter search term: ");
            string searchTerm = Console.ReadLine() ?? string.Empty;
            var foundItems = new ArrayList();
            searchTerm = searchTerm.ToLower();

            foreach (LibraryItem item in _items)
            {
                if (!item.IsDeleted &&
                    (item.Title.ToLower().Contains(searchTerm) ||
                     item.Author.ToLower().Contains(searchTerm)))
                {
                    foundItems.Add(item);
                }
            }

            if (foundItems.Count == 0)
            {
                Console.WriteLine("No items found matching your search.");
                return;
            }

            Console.WriteLine($"\n=== Found {foundItems.Count} items ===");
            foreach (LibraryItem item in foundItems)
            {
                Console.WriteLine("\n" + item.DisplayInfo());
                Console.WriteLine("-------------------");
            }
        }

        private void BorrowItem()
        {
            Console.Write("Enter item ID to borrow: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                foreach (LibraryItem item in _items)
                {
                    if (item.Id == id && !item.IsDeleted)
                    {
                        if (item.IsAvailable)
                        {
                            item.IsAvailable = false;
                            AddHistory(item.Id, "Borrowed", _currentUser);
                            Console.WriteLine($"Successfully borrowed: {item.Title} (ID: {item.Id})");
                        }
                        else
                        {
                            Console.WriteLine($"Item (ID: {item.Id}) is already borrowed.");
                        }
                        return;
                    }
                }
                Console.WriteLine($"Item with ID {id} not found or has been deleted.");
            }
            else
            {
                Console.WriteLine("Invalid ID.");
            }
        }

        private void ReturnItem()
        {
            Console.Write("Enter item ID to return: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                foreach (LibraryItem item in _items)
                {
                    if (item.Id == id && !item.IsDeleted)
                    {
                        if (!item.IsAvailable)
                        {
                            item.IsAvailable = true;
                            AddHistory(item.Id, "Returned", _currentUser);
                            Console.WriteLine($"Successfully returned: {item.Title} (ID: {item.Id})");
                        }
                        else
                        {
                            Console.WriteLine($"Item (ID: {item.Id}) is already available.");
                        }
                        return;
                    }
                }
                Console.WriteLine($"Item with ID {id} not found or has been deleted.");
            }
            else
            {
                Console.WriteLine("Invalid ID.");
            }
        }

        private void DeleteItem()
        {
            Console.Write("Enter item ID to delete: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                foreach (LibraryItem item in _items)
                {
                    if (item.Id == id && !item.IsDeleted)
                    {
                        item.SoftDelete(_currentUser);
                        AddHistory(item.Id, "Deleted", _currentUser);
                        Console.WriteLine($"Item with ID {id} has been marked as deleted.");
                        return;
                    }
                }
                Console.WriteLine($"Item with ID {id} not found or has already been deleted.");
            }
            else
            {
                Console.WriteLine("Invalid ID.");
            }
        }

        private void ViewItemHistory()
        {
            Console.Write("Enter item ID to view history: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                bool itemExists = false;
                foreach (LibraryItem item in _items)
                {
                    if (item.Id == id)
                    {
                        itemExists = true;
                        break;
                    }
                }

                if (!itemExists)
                {
                    Console.WriteLine($"Item with ID {id} not found.");
                    return;
                }

                var itemHistory = new ArrayList();
                foreach (ItemHistory history in _history)
                {
                    if (history.ItemId == id)
                    {
                        itemHistory.Add(history);
                    }
                }

                if (itemHistory.Count == 0)
                {
                    Console.WriteLine($"No history found for item ID {id}.");
                    return;
                }

                Console.WriteLine($"\n=== History for Item ID {id} ===");
                foreach (ItemHistory history in itemHistory)
                {
                    Console.WriteLine(history.ToString());
                }
            }
            else
            {
                Console.WriteLine("Invalid ID.");
            }
        }

        private void AddHistory(int itemId, string operation, string userName)
        {
            var history = new ItemHistory(itemId, operation, userName);
            _history.Add(history);
        }
        #endregion
    }

    /// <summary>
    /// Handles validation of library items
    /// </summary>
    internal class ItemValidator
    {
        #region Constants
        private const string ERROR_NULL_ITEM = "Item cannot be null.";
        private const string ERROR_EMPTY_TITLE = "Title cannot be empty.";
        private const string ERROR_EMPTY_AUTHOR = "Author cannot be empty.";
        private const string ERROR_INVALID_YEAR = "Invalid publish year. Must be between 1 and {0}.";
        private const string ERROR_EMPTY_GENRE = "Genre cannot be empty.";
        private const string ERROR_INVALID_PAGE_COUNT = "Page count must be greater than 0.";
        private const string ERROR_INVALID_ISSUE_NUMBER = "Issue number must be greater than 0.";
        private const string ERROR_EMPTY_PUBLISHER = "Publisher cannot be empty.";
        #endregion

        /// <summary>
        /// Validates a library item
        /// </summary>
        /// <param name="item">The item to validate</param>
        /// <returns>True if the item is valid, false otherwise</returns>
        public bool Validate(LibraryItem item)
        {
            if (item == null)
            {
                ShowError(ERROR_NULL_ITEM);
                return false;
            }

            if (!ValidateCommonProperties(item))
            {
                return false;
            }

            return item switch
            {
                Book book => ValidateBook(book),
                Magazine magazine => ValidateMagazine(magazine),
                _ => true
            };
        }

        private bool ValidateCommonProperties(LibraryItem item)
        {
            return ValidateProperty(() => !string.IsNullOrWhiteSpace(item.Title), ERROR_EMPTY_TITLE) &&
                   ValidateProperty(() => !string.IsNullOrWhiteSpace(item.Author), ERROR_EMPTY_AUTHOR) &&
                   ValidateProperty(() => item.PublishYear > 0 && item.PublishYear <= DateTime.Now.Year,
                                  string.Format(ERROR_INVALID_YEAR, DateTime.Now.Year));
        }

        private bool ValidateBook(Book book)
        {
            return ValidateProperty(() => !string.IsNullOrWhiteSpace(book.Genre), ERROR_EMPTY_GENRE) &&
                   ValidateProperty(() => book.PageCount > 0, ERROR_INVALID_PAGE_COUNT);
        }

        private bool ValidateMagazine(Magazine magazine)
        {
            return ValidateProperty(() => magazine.IssueNumber > 0, ERROR_INVALID_ISSUE_NUMBER) &&
                   ValidateProperty(() => !string.IsNullOrWhiteSpace(magazine.Publisher), ERROR_EMPTY_PUBLISHER);
        }

        private bool ValidateProperty(Func<bool> validation, string errorMessage)
        {
            if (!validation())
            {
                ShowError(errorMessage);
                return false;
            }
            return true;
        }

        private void ShowError(string message)
        {
            Console.WriteLine(message);
        }
    }
}