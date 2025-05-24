using System;

namespace UndoTextEditor.Models
{
    /// <summary>
    /// Represents a line of text with its creation timestamp
    /// </summary>
    public class TextLine
    {
        /// <summary>
        /// Gets the text content
        /// </summary>
        public string Content { get; }

        /// <summary>
        /// Gets the creation timestamp
        /// </summary>
        public DateTime Timestamp { get; }

        /// <summary>
        /// Initializes a new instance of the TextLine class
        /// </summary>
        /// <param name="content">The text content</param>
        /// <exception cref="ArgumentNullException">Thrown when content is null</exception>
        /// <exception cref="ArgumentException">Thrown when content is empty or whitespace</exception>
        public TextLine(string content)
        {
            if (content == null)
                throw new ArgumentNullException(nameof(content), "Content cannot be null");

            if (string.IsNullOrWhiteSpace(content))
                throw new ArgumentException("Content cannot be empty or whitespace", nameof(content));

            Content = content;
            Timestamp = DateTime.Now;
        }

        /// <summary>
        /// Returns a string representation of the text line
        /// </summary>
        public override string ToString()
        {
            return $"[{Timestamp:HH:mm:ss}] {Content}";
        }
    }
}