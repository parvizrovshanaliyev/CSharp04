namespace LibraryManagementSystem.Models;

/// <summary>
/// Base class for library items
/// </summary>
public class LibraryItem
{
    public string Title { get; private set; }
    public string Author { get; private set; }
    public int PublishYear { get; private set; }

    public LibraryItem(string title, string author, int publishYear)
    {
        Title = title;
        Author = author;
        PublishYear = publishYear;
    }

    public virtual void DisplayInfo()
    {
        Console.WriteLine($"[Item] Title: {Title}, Author: {Author}, Year: {PublishYear}");
    }
}