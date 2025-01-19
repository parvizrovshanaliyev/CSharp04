namespace LibraryManagementSystem.Models;

/// <summary>
/// Derived class: Magazine
/// </summary>
public class Magazine : LibraryItem
{
    public int IssueNumber { get; private set; }

    public Magazine(string title, string author, int publishYear, int issueNumber)
        : base(title, author, publishYear)
    {
        IssueNumber = issueNumber;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Issue: {IssueNumber}");
    }
}