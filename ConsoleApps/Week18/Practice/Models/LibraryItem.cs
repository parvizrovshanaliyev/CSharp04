namespace Practice.Models
{
    /// <summary>
    /// Represents a base class for items in a library system.
    /// Demonstrates the use of different access modifiers in C#.
    /// </summary>
    public class LibraryItem
    {
        /* Private field - only accessible within this class
         * Used for internal tracking of library items
         */
        private string ItemCode;

        /* Protected field - accessible within this class and derived classes
         * Allows derived classes to access the title while keeping it hidden from external classes
         */
        protected string Title;

        /* Public field - accessible from anywhere
         * Author information is publicly available
         */
        public string Author;

        /// <summary>
        /// Initializes a new instance of the LibraryItem class.
        /// </summary>
        /// <param name="itemCode">Unique identifier for the library item</param>
        /// <param name="title">Title of the library item</param>
        /// <param name="author">Author of the library item</param>
        public LibraryItem(string itemCode, string title, string author)
        {
            ItemCode = itemCode;
            Title = title;
            Author = author;
        }
    }

    /// <summary>
    /// Represents a book in the library system.
    /// Inherits from LibraryItem and demonstrates access to base class members.
    /// </summary>
    public class Book : LibraryItem
    {
        /// <summary>
        /// Initializes a new instance of the Book class.
        /// </summary>
        /// <param name="itemCode">Unique identifier for the book</param>
        /// <param name="title">Title of the book</param>
        /// <param name="author">Author of the book</param>
        public Book(string itemCode, string title, string author) : base(itemCode, title, author)
        {
        }

        /// <summary>
        /// Demonstrates which members of the base class are accessible from a derived class.
        /// </summary>
        public void PrintAccessibleMembers()
        {
            /* This method demonstrates access modifier behavior:
             * - Cannot access ItemCode (private)
             * - Can access Title (protected)
             * - Can access Author (public)
             */
            Console.WriteLine($"Title: {Title}"); // Protected member is accessible
            Console.WriteLine($"Author: {Author}"); // Public member is accessible
        }
    }

    /// <summary>
    /// Represents a magazine in the library system.
    /// Demonstrates access to LibraryItem members from an external class.
    /// </summary>
    public class Magazine
    {
        /// <summary>
        /// Attempts to access different members of a LibraryItem to demonstrate access restrictions.
        /// </summary>
        /// <param name="item">The LibraryItem to access</param>
        public void TryAccessLibraryItemMembers(LibraryItem item)
        {
            /* This method demonstrates access restrictions from an external class:
             * - Cannot access ItemCode (private)
             * - Cannot access Title (protected)
             * - Can access Author (public)
             */
            Console.WriteLine($"Author: {item.Author}"); // Only public member is accessible
        }
    }
}