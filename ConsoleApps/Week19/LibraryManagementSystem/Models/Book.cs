namespace LibraryManagementSystem.Models;

/// <summary>
/// Derived class: Book
/// </summary>
public class Book : LibraryItem
{
    public string Genre { get; private set; }

    public Book(string title, string author, int publishYear, string genre) : base(title, author, publishYear)
    {
        Genre = genre;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Genre: {Genre}");
    }
}