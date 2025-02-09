namespace LMS.WithConsoleSpecter.Models
{
    public class Magazine : LibraryItem
    {
        public int IssueNumber { get; set; }

        public Magazine(string title, string author, int publishYear, int issueNumber)
            : base(title, author, publishYear)
        {
            IssueNumber = issueNumber;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Magazine: {Title}, Author: {Author}, Year: {PublishYear}, Issue: {IssueNumber}");
        }

        public void UpdateIssueNumber(int issueNumber)
        {
            IssueNumber = issueNumber;
        }
    }
}
