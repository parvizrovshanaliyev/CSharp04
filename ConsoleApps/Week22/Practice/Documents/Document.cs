namespace Practice.Documents;

/// <summary>
/// Abstract base class representing a document in the system.
/// Provides core functionality for document handling and manipulation.
/// </summary>
public abstract class Document
{
    /// <summary>
    /// Gets or sets the title of the document.
    /// </summary>
    public abstract string Title { get; set; }

    /// <summary>
    /// Gets or sets the author of the document.
    /// </summary>
    public abstract string Author { get; set; }

    /// <summary>
    /// Gets or sets the creation date of the document.
    /// </summary>
    public abstract DateTime CreatedDate { get; set; }

    /// <summary>
    /// Converts the document to the specified format.
    /// </summary>
    /// <param name="format">The target format for conversion.</param>
    public abstract void Convert(string format);

    /// <summary>
    /// Validates the document's required properties.
    /// </summary>
    /// <returns>True if the document is valid; otherwise, false.</returns>
    public abstract bool Validate();

    /// <summary>
    /// Retrieves formatted document information.
    /// </summary>
    /// <returns>A string containing the document's metadata.</returns>
    public abstract string GetDocumentInfo();

    /// <summary>
    /// Displays the document's metadata to the console.
    /// </summary>
    public void DisplayMetadata()
    {
        Console.WriteLine(GetDocumentInfo());
    }
}