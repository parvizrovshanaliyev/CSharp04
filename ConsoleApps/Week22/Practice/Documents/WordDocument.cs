namespace Practice.Documents;

/// <summary>
/// Represents a Word document with a title, author, and creation date.
/// </summary>
public class WordDocument : Document
{
    /// <summary>
    /// Gets or sets the title of the Word document.
    /// </summary>
    public override string Title { get; set; }

    /// <summary>
    /// Gets or sets the author of the Word document.
    /// </summary>
    public override string Author { get; set; }

    /// <summary>
    /// Gets or sets the creation date of the Word document.
    /// </summary>
    public override DateTime CreatedDate { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="WordDocument"/> class.
    /// </summary>
    /// <param name="title">The title of the Word document.</param>
    /// <param name="author">The author of the Word document.</param>
    public WordDocument(string title, string author)
    {
        Title = title;
        Author = author;
        CreatedDate = DateTime.Now;
    }

    /// <summary>
    /// Converts the Word document to the specified format.
    /// </summary>
    /// <param name="format">The target format for conversion.</param>
    public override void Convert(string format)
    {
        Console.WriteLine($"Converting Word document to {format}");
    }

    /// <summary>
    /// Validates the Word document.
    /// </summary>
    /// <returns><c>true</c> if the document is valid; otherwise, <c>false</c>.</returns>
    public override bool Validate()
    {
        return !string.IsNullOrEmpty(Title) && !string.IsNullOrEmpty(Author);
    }

    /// <summary>
    /// Gets the information of the Word document.
    /// </summary>
    /// <returns>A string containing the document information.</returns>
    public override string GetDocumentInfo()
    {
        return $"Word Document: {Title} by {Author}, Created on {CreatedDate}";
    }
}