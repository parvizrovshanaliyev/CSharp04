namespace LMSWithArrayList.Models
{
    public class Magazine : LibraryItem
    {
        public int IssueNumber { get; set; }
        public string Publisher { get; set; }

        public Magazine(int id, string title, string author, int publishYear, int issueNumber, string publisher)
            : base(id, title, author, publishYear)
        {
            IssueNumber = issueNumber;
            Publisher = publisher;
        }

        public override string DisplayInfo()
        {
            return $"ID: {Id}\n" +
                   $"Magazine: {Title} - Issue #{IssueNumber}\n" +
                   $"Author: {Author}, Publisher: {Publisher}\n" +
                   $"Published: {PublishYear}\n" +
                   $"Status: {(IsAvailable ? "Available" : "Borrowed")}";
        }
    }
}