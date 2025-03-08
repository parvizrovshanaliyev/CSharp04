using System;
using System.Linq;

namespace ArrayRealExamples
{
    /// <summary>
    /// Represents a book in the library.
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Gets or sets the title of the book.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the author of the book.
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the book is available.
        /// </summary>
        public bool IsAvailable { get; set; }
    }

    /// <summary>
    /// Manages library books.
    /// </summary>
    public class LibrarySystem
    {

        /// <summary>
        /// Manages the library by viewing available books, borrowing a book, and returning a book.
        /// </summary>
        public static void ManageLibrary()
        {
            Book[] books = new Book[]
            {
                new Book { Title = "1984", Author = "George Orwell", IsAvailable = true },
                new Book { Title = "To Kill a Mockingbird", Author = "Harper Lee", IsAvailable = false },
                new Book { Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", IsAvailable = true }
            };

            // View available books
            Console.WriteLine("Available books:");
            foreach (var book in books)
            {
                if (book.IsAvailable)
                {
                    Console.WriteLine($"{book.Title} by {book.Author}");
                }
            }

            // Borrow a book
            BorrowBook(books, "1984");

            // Return a book
            ReturnBook(books, "To Kill a Mockingbird");
        }

        /// <summary>
        /// Borrows a book from the library.
        /// </summary>
        /// <param name="books">The array of books in the library.</param>
        /// <param name="title">The title of the book to borrow.</param>
        private static void BorrowBook(Book[] books, string title)
        {
            foreach (var book in books)
            {
                if (book.Title == title)
                {
                    if (book.IsAvailable)
                    {
                        book.IsAvailable = false;
                        Console.WriteLine($"You have borrowed \"{book.Title}\".");
                    }
                    else
                    {
                        Console.WriteLine($"\"{book.Title}\" is not available.");
                    }
                    return;
                }
            }
            Console.WriteLine($"\"{title}\" not found in the library.");
        }

        /// <summary>
        /// Returns a book to the library.
        /// </summary>
        /// <param name="books">The array of books in the library.</param>
        /// <param name="title">The title of the book to return.</param>
        private static void ReturnBook(Book[] books, string title)
        {
            foreach (var book in books)
            {
                if (book.Title == title)
                {
                    if (!book.IsAvailable)
                    {
                        book.IsAvailable = true;
                        Console.WriteLine($"You have returned \"{book.Title}\".");
                    }
                    else
                    {
                        Console.WriteLine($"\"{book.Title}\" was not borrowed.");
                    }
                    return;
                }
            }
            Console.WriteLine($"\"{title}\" not found in the library.");
        }
    }
}
