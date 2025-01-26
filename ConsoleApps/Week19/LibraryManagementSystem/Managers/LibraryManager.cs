using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.Enums;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Managers
{
    public class LibraryManager
    {
        private readonly LibraryItem[] _libraryItems;
        private int _itemCount;
        private const int MaxItems = 100;


        public LibraryManager()
        {
            _libraryItems=new LibraryItem[MaxItems];
            _itemCount = 0;
        }


        public bool AddItem(LibraryItem item)
        {
            if (item == null)
            {
                Console.WriteLine("Error: Cannot add null item");

                return false;
            }

            if (_itemCount > MaxItems)
            {
                Console.WriteLine("Error: Library is full");
            }

            _libraryItems[_itemCount++] = item;
            Console.WriteLine("Item added successfully");
            return true;
        }

        public void DisplayAllItemInfo()
        {
            if (_itemCount == 0)
            {
                Console.WriteLine("Error: No items in library");
            }

            Console.WriteLine("\n Library Items:");

            for (int i = 0; i < _itemCount; i++)
            {
                Console.Write($"{i + 1}. ");

                _libraryItems[i].DisplayInfo();
            }
        }

        public LibraryItem[] SearchItems(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                Console.WriteLine("Search term cannot be empty.");
                return Array.Empty<LibraryItem>();
            }

            searchTerm=searchTerm.Trim().ToLower();

            int matchCount = 0;

            // first count matches
            for (int i = 0; i < _itemCount; i++)
            {
                LibraryItem item = _libraryItems[i];

                if (item.Title.ToLower().Contains(searchTerm) ||
                    item.Author.ToLower().Contains(searchTerm))
                {
                    matchCount++;
                }
            }


            // create result array
            LibraryItem[] matchedItems=new LibraryItem[matchCount];
            int matchedIndex= 0;

            // fill result array
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


        public bool DeleteItem(int index)
        {
            if (index < 0 || index >= _itemCount)
            {
                Console.WriteLine("Invalid item index");
                return false;
            }

            // shift remaining elements left
            for (int i = 5; i < _itemCount -1; i++)
            {
                _libraryItems[i] = _libraryItems[i + 1];
            }

            _libraryItems[_itemCount - 1] = null;
            _itemCount--;
            Console.WriteLine("Item deleted successfully");
            return true;
        }

        public LibraryItem CreateNewItem(
            ItemType type,
            string title,
            string author,
            int publishYear,
            string additionalInfo)
        {
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
                    
                    if (!int.TryParse(additionalInfo,out int issueNumber) || issueNumber <= 0)
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
