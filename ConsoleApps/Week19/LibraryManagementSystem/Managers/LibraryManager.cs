using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.Enums;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Managers
{
    /// <summary>
    /// Manages the library's collection of items including books, magazines and articles.
    /// Handles operations like adding, deleting, searching and displaying items.
    /// </summary>
    public class LibraryManager
    {
        /// <summary>
        /// Array to store all library items
        /// </summary>
        private readonly LibraryItem[] _libraryItems;

        /// <summary>
        /// Current count of items in the library
        /// </summary>
        private int _itemCount;

        /// <summary>
        /// Maximum number of items the library can hold
        /// </summary>
        private const int MaxItems = 100;

        /// <summary>
        /// Initializes a new instance of the LibraryManager class
        /// </summary>
        public LibraryManager()
        {
            /*
             * Initialize the items array with maximum capacity of 100 items.
             * This array will store all library items including books, magazines and articles.
             * The array size is fixed to ensure efficient memory usage and prevent unbounded growth.
             */
            _libraryItems = new LibraryItem[MaxItems];

            /*
             * Initialize the item count to 0.
             * This counter will be incremented when items are added and
             * decremented when items are removed to maintain an accurate count.
             */
            _itemCount = 0;
        }

        /// <summary>
        /// Adds a new item to the library collection
        /// </summary>
        /// <param name="item">The library item to add</param>
        /// <returns>True if item was added successfully, false otherwise</returns>
        public bool AddItem(LibraryItem item)
        {
            /*
             * Validate that item is not null before attempting to add.
             * This prevents null reference exceptions and data corruption.
             * Return false and display error message if validation fails.
             */
            if (item == null)
            {
                Console.WriteLine("Error: Cannot add null item");
                return false;
            }

            /*
             * Check if library has reached maximum capacity of 100 items.
             * This prevents array overflow and ensures system stability.
             * Return false and display error if at capacity.
             */
            if (_itemCount > MaxItems)
            {
                Console.WriteLine("Error: Library is full");
            }

            /*
             * Add the new item to the array at the current count position.
             * Increment the count using post-increment operator.
             * Display success message and return true to indicate successful addition.
             */
            _libraryItems[_itemCount++] = item;
            Console.WriteLine("Item added successfully");
            return true;
        }

        /// <summary>
        /// Displays information about all items in the library
        /// </summary>
        public void DisplayAllItemInfo()
        {
            /*
             * Check if library is empty before attempting to display items.
             * This prevents unnecessary processing and provides better user feedback.
             * Display error message and return if no items exist.
             */
            if (_itemCount == 0)
            {
                Console.WriteLine("Error: No items in library");
            }

            Console.WriteLine("\n Library Items:");

            /*
             * Iterate through all items in the library up to the current count.
             * For each item:
             * 1. Display its index number (1-based for user-friendly display)
             * 2. Call the item's DisplayInfo method to show its details
             */
            for (int i = 0; i < _itemCount; i++)
            {
                Console.Write($"{i + 1}. ");
                _libraryItems[i].DisplayInfo();
            }
        }

        /// <summary>
        /// Searches for items by title or author
        /// </summary>
        /// <param name="searchTerm">The term to search for in titles and authors</param>
        /// <returns>Array of matching library items</returns>
        public LibraryItem[] SearchItems(string searchTerm)
        {
            /*
             * Validate that search term is not null, empty or whitespace.
             * This ensures meaningful search results and prevents unnecessary processing.
             * Return empty array if validation fails.
             */
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                Console.WriteLine("Search term cannot be empty.");
                return Array.Empty<LibraryItem>();
            }

            /*
             * Normalize search term by:
             * 1. Trimming leading/trailing whitespace
             * 2. Converting to lowercase for case-insensitive comparison
             */
            searchTerm = searchTerm.Trim().ToLower();

            int matchCount = 0;

            /*
             * First pass through items:
             * Count how many items match the search term in either title or author.
             * This count will be used to create an appropriately sized result array.
             */
            for (int i = 0; i < _itemCount; i++)
            {
                LibraryItem item = _libraryItems[i];

                if (item.Title.ToLower().Contains(searchTerm) ||
                    item.Author.ToLower().Contains(searchTerm))
                {
                    matchCount++;
                }
            }

            /*
             * Create array sized exactly to hold all matching items.
             * This prevents wasted memory from oversized arrays.
             */
            LibraryItem[] matchedItems = new LibraryItem[matchCount];
            int matchedIndex = 0;

            /*
             * Second pass through items:
             * Populate the results array with matching items.
             * Use separate index counter to track position in results array.
             */
            for (int i = 0; i < _itemCount; i++)
            {
                LibraryItem item = _libraryItems[i];

                if (item.Title.ToLower().Contains(searchTerm) ||
                    item.Author.ToLower().Contains(searchTerm))
                {
                    matchedItems[matchedIndex++] = _libraryItems[i];
                }
            }

            return matchedItems;
        }

        /// <summary>
        /// Deletes an item from the library at the specified index
        /// </summary>
        /// <param name="index">The index of the item to delete</param>
        /// <returns>True if deletion was successful, false otherwise</returns>
        public bool DeleteItem(int index)
        {
            /*
             * Validate that the provided index is within the valid range:
             * 1. Not negative
             * 2. Less than current item count
             * Return false and display error if validation fails.
             */
            if (index < 0 || index >= _itemCount)
            {
                Console.WriteLine("Invalid item index");
                return false;
            }

            /*
             * Shift all remaining elements one position to the left to fill the gap.
             * This maintains array continuity and prevents fragmentation.
             * Start from the deletion index to shift subsequent items.
             * 
             * Example:
             * Initial array: [A, B, C, D, E]
             * Delete index 1 (B)
             * After shift: [A, C, D, E, null]
             * Each element after B shifts left one position
             */
            for (int i = index; i < _itemCount - 1; i++)
            {
                _libraryItems[i] = _libraryItems[i + 1];
            }

            /*
             * Clean up after deletion:
             * 1. Set the last element to null to prevent memory leaks
             * 2. Decrement the item count
             * 3. Display success message
             */
            _libraryItems[_itemCount - 1] = null;
            _itemCount--;
            Console.WriteLine("Item deleted successfully");
            return true;
        }

        /// <summary>
        /// Creates a new library item of the specified type
        /// </summary>
        /// <param name="type">The type of item to create</param>
        /// <param name="title">The title of the item</param>
        /// <param name="author">The author of the item</param>
        /// <param name="publishYear">The year the item was published</param>
        /// <param name="additionalInfo">Additional info specific to the item type (genre, issue number, or journal name)</param>
        /// <returns>The created library item, or null if creation failed</returns>
        public LibraryItem CreateNewItem(
            ItemType type,
            string title,
            string author,
            int publishYear,
            string additionalInfo)
        {
            /*
             * Validate basic item properties that apply to all item types:
             * 1. Title and author must not be null, empty or whitespace
             * 2. Publish year must be between 1000 and current year
             * Return null and display appropriate error message if validation fails
             */
            if (string.IsNullOrWhiteSpace(title) ||
                string.IsNullOrWhiteSpace(author))
            {
                Console.WriteLine("Title and author cannot be empty.");
                return null;
            }

            if (publishYear < 1000 || publishYear > DateTime.Now.Year)
            {
                Console.WriteLine($"Publish year must be between 1000 and {DateTime.Now.Year}.");
                return null;
            }

            /*
             * Create appropriate item type based on the ItemType enum:
             * - Book: Requires valid genre string
             * - Magazine: Requires valid positive issue number
             * - Article: Requires valid journal name
             * Each case includes specific validation for its additional info
             */
            switch (type)
            {
                case ItemType.Book:
                    if (string.IsNullOrWhiteSpace(additionalInfo))
                    {
                        Console.WriteLine("Genre cannot be empty.");
                        return null;
                    }

                    return new Book(title, author, publishYear, additionalInfo);

                case ItemType.Magazine:
                    if (!int.TryParse(additionalInfo, out int issueNumber) || issueNumber <= 0)
                    {
                        Console.WriteLine("Invalid issue number.");
                        return null;
                    }

                    return new Magazine(title, author, publishYear, issueNumber);

                case ItemType.Article:
                    if (string.IsNullOrWhiteSpace(additionalInfo))
                    {
                        Console.WriteLine("Journal name cannot be empty.");
                        return null;
                    }

                    return new Article(title, author, publishYear, additionalInfo);

                default:
                    Console.WriteLine("Invalid item type.");
                    return null;
            }
        }
    }
}

/// <summary>
/// Represents the result of attempting to create a library item.
/// Contains success/failure status, error message if failed, and the created item if successful.
/// </summary>
public class ItemCreationResult
{
    /// <summary>
    /// Gets whether the item creation was successful.
    /// </summary>
    public bool IsSuccess { get; }

    /// <summary>
    /// Gets the error message if creation failed, null if successful.
    /// </summary>
    public string Error { get; }

    /// <summary>
    /// Gets the created library item if successful, null if failed.
    /// </summary>
    public LibraryItem Item { get; }

    /// <summary>
    /// Initializes a new instance of the ItemCreationResult class.
    /// </summary>
    /// <param name="isSuccess">Whether the creation was successful</param>
    /// <param name="item">The created item if successful</param>
    /// <param name="error">The error message if failed</param>
    private ItemCreationResult(bool isSuccess, LibraryItem item = null, string error = null)
    {
        IsSuccess = isSuccess;
        Item = item;
        Error = error;
    }

    /// <summary>
    /// Creates a successful result containing the created item.
    /// </summary>
    /// <param name="item">The successfully created library item</param>
    /// <returns>A successful ItemCreationResult</returns>
    public static ItemCreationResult Success(LibraryItem item) => 
        new ItemCreationResult(true, item);
    
    /// <summary>
    /// Creates a failed result containing an error message.
    /// </summary>
    /// <param name="error">The error message describing why creation failed</param>
    /// <returns>A failed ItemCreationResult</returns>
    public static ItemCreationResult Failure(string error) => 
        new ItemCreationResult(false, error: error);
}
