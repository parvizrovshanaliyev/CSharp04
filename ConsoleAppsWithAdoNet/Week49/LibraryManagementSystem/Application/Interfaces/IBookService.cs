using LibraryManagementSystem.Domain.Entities;

namespace LibraryManagementSystem.Application.Interfaces;

/// <summary>
/// Interface for book service operations.
/// </summary>
public interface IBookService
{
    /// <summary>
    /// Gets all books.
    /// </summary>
    List<Book> GetAllBooks();

    /// <summary>
    /// Gets a book by its unique identifier.
    /// </summary>
    Book? GetBookById(int id);

    /// <summary>
    /// Adds a new book.
    /// </summary>
    int AddBook(Book book);

    /// <summary>
    /// Updates an existing book.
    /// </summary>
    bool UpdateBook(Book book);

    /// <summary>
    /// Deletes a book.
    /// </summary>
    bool DeleteBook(int id);
}
