using LibraryManagementSystem.Domain.Entities;

namespace LibraryManagementSystem.Application.Interfaces;

/// <summary>
/// Interface for book borrow record repository operations.
/// </summary>
public interface IBookBorrowRepository
{
    /// <summary>
    /// Gets all borrow records from the database.
    /// </summary>
    List<BookBorrowRecord> GetAll();

    /// <summary>
    /// Gets a borrow record by its unique identifier.
    /// </summary>
    BookBorrowRecord? GetById(int id);

    /// <summary>
    /// Adds a new borrow record to the database.
    /// </summary>
    int Add(BookBorrowRecord record);

    /// <summary>
    /// Updates an existing borrow record in the database.
    /// </summary>
    bool Update(BookBorrowRecord record);

    /// <summary>
    /// Deletes a borrow record from the database.
    /// </summary>
    bool Delete(int id);
}
