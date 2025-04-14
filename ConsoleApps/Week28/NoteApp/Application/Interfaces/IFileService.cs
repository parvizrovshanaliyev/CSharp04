namespace NoteApp.Application.Interfaces;

/// <summary>
/// Defines the contract for file system operations in the application.
/// This interface abstracts the file handling operations to enable loose coupling
/// and easier testing through dependency injection.
/// </summary>
public interface IFileService
{
    /// <summary>
    /// Appends content to a file at the specified path.
    /// Creates the file if it doesn't exist.
    /// </summary>
    /// <param name="path">The path to the target file.</param>
    /// <param name="content">The content to append to the file.</param>
    void Append(string path, string content);

    /// <summary>
    /// Reads all content from a file at the specified path.
    /// </summary>
    /// <param name="path">The path to the file to read.</param>
    /// <returns>The content of the file as a string.</returns>
    string Read(string path);

    /// <summary>
    /// Deletes the file at the specified path if it exists.
    /// </summary>
    /// <param name="path">The path to the file to delete.</param>
    void Delete(string path);

    /// <summary>
    /// Checks if a file exists at the specified path.
    /// </summary>
    /// <param name="path">The path to check for file existence.</param>
    /// <returns>True if the file exists; otherwise, false.</returns>
    bool Exists(string path);
}