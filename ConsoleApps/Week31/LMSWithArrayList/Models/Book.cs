namespace LMSWithArrayList.Models
{
    public class Book : LibraryItem
    {
        public string Genre { get; set; }
        public int PageCount { get; set; }

        public Book(int id, string title, string author, int publishYear, string genre, int pageCount)
            : base(id, title, author, publishYear)
        {
            Genre = genre;
            PageCount = pageCount;
        }

        public override string DisplayInfo()
        {
            return $"ID: {Id}\n" +
                   $"Book: {Title} by {Author} ({PublishYear})\n" +
                   $"Genre: {Genre}, Pages: {PageCount}\n" +
                   $"Status: {(IsAvailable ? "Available" : "Borrowed")}";
        }
    }
}