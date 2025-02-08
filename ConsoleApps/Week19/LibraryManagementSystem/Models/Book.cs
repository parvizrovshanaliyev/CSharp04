namespace LibraryManagementSystem.Models;

/// <summary>
/// Represents a book in the library system.
/// Inherits from the base LibraryItem class.
/// </summary>
public class Book : LibraryItem
{
    /// <summary>
    /// Gets the genre of the book.
    /// This property can only be set through the constructor.
    /// </summary>
    public string Genre { get; private set; }

    /// <summary>
    /// Initializes a new instance of the Book class.
    /// </summary>
    /// <param name="title">The title of the book</param>
    /// <param name="author">The author(s) of the book</param>
    /// <param name="publishYear">The year the book was published</param>
    /// <param name="genre">The genre of the book</param>
    public Book(string title, string author, int publishYear, string genre)
        : base(title, author, publishYear)
    {
        Genre = genre;
    }

    /// <summary>
    /// Displays detailed information about the book including its base properties
    /// and the genre.
    /// </summary>
    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Genre: {Genre}");
        Console.WriteLine(new string('-', 40)); // Add a separator line
    }

    public void UpdateGenre(string newGenre)
    {
        if (!string.IsNullOrWhiteSpace(newGenre))
        {
            Genre = newGenre;
        }
    }
}