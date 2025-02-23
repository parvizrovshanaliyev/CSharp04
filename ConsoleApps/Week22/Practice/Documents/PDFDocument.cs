namespace Practice.Documents;

/// <summary>
/// Represents a PDF document.
/// </summary>
public class PDFDocument : Document
{
    /// <summary>
    /// Gets or sets the title of the PDF document.
    /// </summary>
    public override string Title { get; set; }

    /// <summary>
    /// Gets or sets the author of the PDF document.
    /// </summary>
    public override string Author { get; set; }

    /// <summary>
    /// Gets or sets the creation date of the PDF document.
    /// </summary>
    public override DateTime CreatedDate { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="PDFDocument"/> class.
    /// </summary>
    /// <param name="title">The title of the PDF document.</param>
    /// <param name="author">The author of the PDF document.</param>
    public PDFDocument(string title, string author)
    {
        Title = title;
        Author = author;
        CreatedDate = DateTime.Now;
    }

    /// <summary>
    /// Converts the PDF document to the specified format.
    /// </summary>
    /// <param name="format">The target format for conversion.</param>
    public override void Convert(string format)
    {
        Console.WriteLine($"Converting PDF to {format}");
    }

    /// <summary>
    /// Validates the PDF document.
    /// </summary>
    /// <returns><c>true</c> if the document is valid; otherwise, <c>false</c>.</returns>
    public override bool Validate()
    {
        return !string.IsNullOrEmpty(Title) && !string.IsNullOrEmpty(Author);
    }

    /// <summary>
    /// Gets the information of the PDF document.
    /// </summary>
    /// <returns>A string containing the document information.</returns>
    public override string GetDocumentInfo()
    {
        return $"PDF Document: {Title} by {Author}, Created on {CreatedDate}";
    }
}