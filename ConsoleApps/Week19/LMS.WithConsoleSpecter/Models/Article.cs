namespace LMS.WithConsoleSpecter.Models
{
    public class Article : LibraryItem
    {
        public string JournalName { get; set; }

        public Article(string title, string author, int publishYear, string journalName)
            : base(title, author, publishYear)
        {
            JournalName = journalName;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Article: {Title}, Author: {Author}, Year: {PublishYear}, Journal: {JournalName}");
        }

        public void UpdateJournalName(string journalName)
        {
            JournalName = journalName;
        }
    }
}
