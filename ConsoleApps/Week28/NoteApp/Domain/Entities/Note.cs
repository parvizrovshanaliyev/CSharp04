using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp.Domain.Entities;

/// <summary>
/// Represents a note entity in the application.
/// This class serves as the core domain model for storing note information.
/// </summary>
public class Note
{
    /// <summary>
    /// Gets or sets the title of the note.
    /// The title serves as a brief description or heading for the note.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Gets or sets the main content or body of the note.
    /// This contains the actual note text or information.
    /// </summary>
    public string Content { get; set; }

    /// <summary>
    /// Gets or sets the creation timestamp of the note.
    /// Automatically initialized to the current date and time when the note is created.
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    /// <summary>
    /// Converts the note to its string representation.
    /// </summary>
    /// <returns>
    /// A formatted string containing the note's creation time, title, and content,
    /// with a separator line at the end.
    /// </returns>
    public override string ToString()
    {
        /*
         * Format the note data in a readable format:
         * - Creation timestamp in square brackets
         * - Title on the same line as timestamp
         * - Content on the next line
         * - Separator (---) to distinguish between multiple notes
         */
        var data = $"[{this.CreatedAt}] {this.Title}\n{this.Content}\n---\n";
        return data;
    }
}