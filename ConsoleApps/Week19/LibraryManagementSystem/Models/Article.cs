namespace LibraryManagementSystem.Models;

/// <summary>
///  Derived class: Article
/// </summary>
public class Article : LibraryItem
{
    public string JournalName { get; private set; }

    public Article(string title, string author, int publishYear, string journalName)
        : base(title, author, publishYear)
    {
        JournalName = journalName;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Journal: {JournalName}");
    }
}