namespace LibraryManagementSystem.Domain.Entities;

/// <summary>
/// Represents a book entity in the library system.
/// </summary>
public class Book
{
    /// <summary>
    /// Gets or sets the unique identifier for the book.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the title of the book.
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the author of the book.
    /// </summary>
    public string Author { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the International Standard Book Number (ISBN) of the book.
    /// </summary>
    public string ISBN { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the year the book was published.
    /// </summary>
    public int PublishedYear { get; set; }

    /// <summary>
    /// Gets or sets the genre/category of the book.
    /// </summary>
    public string Genre { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the total number of copies available in the library.
    /// </summary>
    public int TotalCopies { get; set; }

    /// <summary>
    /// Gets or sets the number of copies currently available for borrowing.
    /// </summary>
    public int AvailableCopies { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the book record was created.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the book record was last updated.
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// Gets a value indicating whether the book is available for borrowing.
    /// </summary>
    public bool IsAvailable => AvailableCopies > 0;

    /// <summary>
    /// Returns a string representation of the book.
    /// </summary>
    /// <returns>A formatted string containing book details.</returns>
    public override string ToString()
    {
        return $"[{Id}] {Title} by {Author} (ISBN: {ISBN}) - Available: {AvailableCopies}/{TotalCopies}";
    }
}
