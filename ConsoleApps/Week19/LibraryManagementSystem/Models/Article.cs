namespace LibraryManagementSystem.Models;

/// <summary>
/// Represents an academic or professional article in the library system.
/// Inherits from the base LibraryItem class.
/// </summary>
public class Article : LibraryItem
{
    /// <summary>
    /// Gets the name of the journal in which this article was published.
    /// This property can only be set through the constructor.
    /// </summary>
    public string JournalName { get; private set; }

    /// <summary>
    /// Initializes a new instance of the Article class.
    /// </summary>
    /// <param name="title">The title of the article</param>
    /// <param name="author">The author(s) of the article</param>
    /// <param name="publishYear">The year the article was published</param>
    /// <param name="journalName">The name of the journal containing this article</param>
    public Article(string title, string author, int publishYear, string journalName)
        : base(title, author, publishYear)
    {
        JournalName = journalName;
    }

    /// <summary>
    /// Displays detailed information about the article including its base properties
    /// and the journal name.
    /// </summary>
    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Journal Name: {JournalName}");
        Console.WriteLine(new string('-', 40)); // Add a separator line
    }

    public void UpdateJournalName(string newJournalName)
    {
        if (!string.IsNullOrWhiteSpace(newJournalName))
        {
            JournalName = newJournalName;
        }
    }
}