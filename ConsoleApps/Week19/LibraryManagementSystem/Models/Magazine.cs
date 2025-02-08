namespace LibraryManagementSystem.Models;

/// <summary>
/// Represents a magazine in the library system.
/// Inherits from the base LibraryItem class.
/// </summary>
public class Magazine : LibraryItem
{
    /// <summary>
    /// Gets the issue number of the magazine.
    /// This property can only be set through the constructor.
    /// </summary>
    public int IssueNumber { get; private set; }

    /// <summary>
    /// Initializes a new instance of the Magazine class.
    /// </summary>
    /// <param name="title">The title of the magazine</param>
    /// <param name="author">The author(s) of the magazine</param>
    /// <param name="publishYear">The year the magazine was published</param>
    /// <param name="issueNumber">The issue number of the magazine</param>
    public Magazine(string title, string author, int publishYear, int issueNumber)
        : base(title, author, publishYear)
    {
        IssueNumber = issueNumber;
    }

    /// <summary>
    /// Displays detailed information about the magazine including its base properties
    /// and the issue number.
    /// </summary>
    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Issue: {IssueNumber}");
        Console.WriteLine(new string('-', 40)); // Add a separator line
    }


    public void UpdateIssueNumber(int newIssueNumber)
    {
        if (newIssueNumber > 0)
        {
            IssueNumber = newIssueNumber;
        }
    }
}