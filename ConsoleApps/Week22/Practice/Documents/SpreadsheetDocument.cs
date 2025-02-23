namespace Practice.Documents;

/// <summary>
/// Represents a spreadsheet document.
/// </summary>
public class SpreadsheetDocument : Document
{
    /// <summary>
    /// Gets or sets the title of the spreadsheet.
    /// </summary>
    public override string Title { get; set; }

    /// <summary>
    /// Gets or sets the author of the spreadsheet.
    /// </summary>
    public override string Author { get; set; }

    /// <summary>
    /// Gets or sets the date the spreadsheet was created.
    /// </summary>
    public override DateTime CreatedDate { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="SpreadsheetDocument"/> class.
    /// </summary>
    /// <param name="title">The title of the spreadsheet.</param>
    /// <param name="author">The author of the spreadsheet.</param>
    public SpreadsheetDocument(string title, string author)
    {
        Title = title;
        Author = author;
        CreatedDate = DateTime.Now;
    }

    /// <summary>
    /// Converts the spreadsheet to the specified format.
    /// </summary>
    /// <param name="format">The target format for conversion.</param>
    public override void Convert(string format)
    {
        Console.WriteLine($"Converting Spreadsheet to {format}");
    }

    /// <summary>
    /// Validates the spreadsheet document.
    /// </summary>
    /// <returns>True if the document is valid; otherwise, false.</returns>
    public override bool Validate()
    {
        return !string.IsNullOrEmpty(Title) && !string.IsNullOrEmpty(Author);
    }

    /// <summary>
    /// Gets information about the spreadsheet document.
    /// </summary>
    /// <returns>A string containing the document information.</returns>
    public override string GetDocumentInfo()
    {
        return $"Spreadsheet: {Title} by {Author}, Created on {CreatedDate}";
    }
}
