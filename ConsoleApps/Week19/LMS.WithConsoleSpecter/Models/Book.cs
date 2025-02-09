namespace LMS.WithConsoleSpecter.Models
{
    public class Book : LibraryItem
    {
        public string Genre { get; set; }

        public Book(string title, string author, int publishYear, string genre)
            : base(title, author, publishYear)
        {
            Genre = genre;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Book: {Title}, Author: {Author}, Year: {PublishYear}, Genre: {Genre}");
        }

        public void UpdateGenre(string genre)
        {
            Genre = genre;
        }
    }
}
