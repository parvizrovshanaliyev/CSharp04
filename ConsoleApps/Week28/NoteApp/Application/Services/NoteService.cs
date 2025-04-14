using NoteApp.Application.Interfaces;
using NoteApp.Domain.Entities;
using NoteApp.Infrastructure.Services;

namespace NoteApp.Application.Services;

/// <summary>
/// Implements the INoteService interface to provide note management functionality.
/// This service handles the business logic for creating, retrieving, and managing notes,
/// using the file system for persistence through IFileService.
/// </summary>
public class NoteService : INoteService
{
    /*
     * Private fields for dependency injection and configuration
     * - _fileService handles the actual file operations
     * - _filePath defines where notes are stored
     */
    private readonly IFileService _fileService;
    private readonly string _filePath = "notes.txt";

    /// <summary>
    /// Initializes a new instance of the NoteService class.
    /// </summary>
    /// <param name="fileService">The file service implementation to use for persistence.</param>
    public NoteService(IFileService fileService)
    {
        _fileService = fileService;
    }

    /// <summary>
    /// Creates a new note with the specified title and content.
    /// The note is immediately persisted to the file system.
    /// </summary>
    /// <param name="title">The title of the note.</param>
    /// <param name="content">The content of the note.</param>
    public void Create(string title, string content)
    {
        /*
         * Create a new note instance and convert it to string format
         * Append the formatted note to the storage file
         */
        var note = new Note { Title = title, Content = content };
        _fileService.Append(_filePath, note.ToString());
    }

    /// <summary>
    /// Retrieves all notes from the storage.
    /// </summary>
    /// <returns>
    /// A string containing all notes if any exist;
    /// otherwise, returns a message indicating no notes are available.
    /// </returns>
    public string GetAll()
    {
        /*
         * Check if notes file exists before attempting to read
         * Return appropriate message if no notes are found
         */
        return _fileService.Exists(_filePath) ? _fileService.Read(_filePath) : "No notes available.";
    }

    /// <summary>
    /// Removes all notes from the storage.
    /// This operation cannot be undone.
    /// </summary>
    public void Clear()
    {
        /*
         * Delete the entire notes file
         * This effectively removes all stored notes
         */
        _fileService.Delete(_filePath);
    }

    /// <summary>
    /// Checks if any notes exist in the storage.
    /// </summary>
    /// <returns>True if there are any notes; otherwise, false.</returns>
    public bool Any()
    {
        /*
         * Check for existence of the notes file
         * This indicates whether any notes have been created
         */
        return _fileService.Exists(_filePath);
    }
}