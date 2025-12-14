using LibraryManagementSystem.Domain.Entities;

namespace LibraryManagementSystem.Application.Interfaces;

/// <summary>
/// Interface for book repository operations.
/// </summary>
public interface IBookRepository
{
    /// <summary>
    /// Gets all books from the database.
    /// </summary>
    List<Book> GetAll();

    /// <summary>
    /// Gets a book by its unique identifier.
    /// </summary>
    Book? GetById(int id);

    /// <summary>
    /// Adds a new book to the database.
    /// </summary>
    int Add(Book book);

    /// <summary>
    /// Updates an existing book in the database.
    /// </summary>
    bool Update(Book book);

    /// <summary>
    /// Deletes a book from the database.
    /// </summary>
    bool Delete(int id);
}
