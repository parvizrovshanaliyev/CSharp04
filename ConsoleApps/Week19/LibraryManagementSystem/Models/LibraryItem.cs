namespace LibraryManagementSystem.Models;

/// <summary>
/// Represents a base class for all library items in the library system.
/// Provides common properties and methods that all library items share.
/// </summary>
public class LibraryItem
{
    /// <summary>
    /// Gets the title of the library item.
    /// This property can only be set through the constructor.
    /// </summary>
    public string Title { get; private set; }

    /// <summary>
    /// Gets the author of the library item.
    /// This property can only be set through the constructor.
    /// </summary>
    public string Author { get; private set; }

    /// <summary>
    /// Gets the publication year of the library item.
    /// This property can only be set through the constructor.
    /// </summary>
    public int PublishYear { get; private set; }

    /// <summary>
    /// Initializes a new instance of the LibraryItem class.
    /// </summary>
    /// <param name="title">The title of the library item</param>
    /// <param name="author">The author(s) of the library item</param>
    /// <param name="publishYear">The year the item was published</param>
    public LibraryItem(string title, string author, int publishYear)
    {
        Title = title;
        Author = author;
        PublishYear = publishYear;
    }

    /// <summary>
    /// Displays detailed information about the library item.
    /// Can be overridden by derived classes to add additional information.
    /// </summary>
    public virtual void DisplayInfo()
    {
        Console.WriteLine($"[Item] Title: {Title}, Author: {Author}, Year: {PublishYear}");
    }

    public void UpdateDetails(string newTitle, string newAuthor, int newPublishYear)
    {
        if (!string.IsNullOrWhiteSpace(newTitle))
            Title = newTitle;

        if (!string.IsNullOrWhiteSpace(newAuthor))
            Author = newAuthor;

        if (newPublishYear >= 1000 && newPublishYear <= DateTime.Now.Year)
            PublishYear = newPublishYear;
    }
}