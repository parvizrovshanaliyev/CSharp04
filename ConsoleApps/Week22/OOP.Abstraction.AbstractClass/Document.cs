using System;

namespace OOP.Abstraction.AbstractClass
{
    /// <summary>
    /// Represents an abstract document with basic properties and methods.
    /// </summary>
    public abstract class Document
    {
        /// <summary>
        /// Gets or sets the title of the document.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the author of the document.
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Gets or sets the creation date of the document.
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Processes the document. This method must be implemented by derived classes.
        /// </summary>
        public abstract void Process();

        /// <summary>
        /// Displays the basic information of the document.
        /// </summary>
        public void DisplayInfo()
        {
            Console.WriteLine($"Document: {Title}");
            Console.WriteLine($"Author: {Author}");
            Console.WriteLine($"Created: {CreatedDate}");
        }
    }

    /// <summary>
    /// Represents a PDF document with specific properties and methods.
    /// </summary>
    public class PdfDocument : Document
    {
        /// <summary>
        /// Gets or sets the PDF version of the document.
        /// </summary>
        public string PdfVersion { get; set; }

        /// <summary>
        /// Processes the PDF document.
        /// </summary>
        public override void Process()
        {
            Console.WriteLine($"Processing PDF document: {Title}");
            // Simulate PDF-specific processing logic
            Console.WriteLine($"PDF Version: {PdfVersion}");
        }
    }

    /// <summary>
    /// Represents a Word document with specific properties and methods.
    /// </summary>
    public class WordDocument : Document
    {
        /// <summary>
        /// Gets or sets the Word version of the document.
        /// </summary>
        public string WordVersion { get; set; }

        /// <summary>
        /// Processes the Word document.
        /// </summary>
        public override void Process()
        {
            Console.WriteLine($"Processing Word document: {Title}");
            // Simulate Word-specific processing logic
            Console.WriteLine($"Word Version: {WordVersion}");
        }
    }

    /// <summary>
    /// Represents an Excel document with specific properties and methods.
    /// </summary>
    public class ExcelDocument : Document
    {
        /// <summary>
        /// Gets or sets the Excel version of the document.
        /// </summary>
        public string ExcelVersion { get; set; }

        /// <summary>
        /// Processes the Excel document.
        /// </summary>
        public override void Process()
        {
            Console.WriteLine($"Processing Excel document: {Title}");
            // Simulate Excel-specific processing logic
            Console.WriteLine($"Excel Version: {ExcelVersion}");
        }
    }
}
