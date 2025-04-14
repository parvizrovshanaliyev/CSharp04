namespace NoteApp.Application.Interfaces;

/// <summary>
/// Defines the contract for note management operations in the application.
/// This interface provides high-level operations for managing notes,
/// abstracting the underlying storage implementation.
/// </summary>
public interface INoteService
{
    /// <summary>
    /// Creates a new note with the specified title and content.
    /// </summary>
    /// <param name="title">The title of the note.</param>
    /// <param name="content">The content or body of the note.</param>
    void Create(string title, string content);

    /// <summary>
    /// Retrieves all notes in the system.
    /// </summary>
    /// <returns>A string containing all notes, formatted for display.</returns>
    string GetAll();

    /// <summary>
    /// Removes all notes from the system.
    /// This operation cannot be undone.
    /// </summary>
    void Clear();

    /// <summary>
    /// Checks if any notes exist in the system.
    /// </summary>
    /// <returns>True if there are any notes; otherwise, false.</returns>
    bool Any();
}